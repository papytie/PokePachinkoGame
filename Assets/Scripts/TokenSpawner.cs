using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    [Header("Settings"), Space]

    [Header("Movement Settings")]
    [SerializeField] SpawnPosition SpawnerMove = SpawnPosition.Fixed;
    [SerializeField] Vector2 spawnPosition;
    [SerializeField] Vector2 startPosition;
    [SerializeField] Vector2 endPosition;
    [SerializeField] float movementTime = 3;

    [Header("Spawn Settings")]
    [SerializeField] SpawnTiming spawnTiming = SpawnTiming.OnSpawnTimer;
    [SerializeField] float spawnTime = 1;
    [SerializeField] SpawnType spawnType = SpawnType.OnPos;

    [Header("Grid Settings")]
    [SerializeField] float gridWidth = 16;
    [SerializeField] float gridHeight = 9;
    [SerializeField] int gridColumns = 10;
    [SerializeField] int gridRows = 6;

    [Header("Token Settings")]
    [SerializeField] TokenType tokenType = TokenType.Marble;
    [SerializeField] bool randomSprite = false;
    [SerializeField] SpriteType spriteType;
    [SerializeField] GameObject marbleObject;
    [SerializeField] GameObject scoreObject;
    [SerializeField] GameObject bumperObject;

    [Header("Token Settings")]
    [SerializeField] bool showDebug;
    [SerializeField] Color gridColor = Color.white;
    [SerializeField] Color spawnColor = Color.white;
    [SerializeField] Color startColor = Color.white;
    [SerializeField] Color endColor = Color.white;

    float currentTime = 0;
    float timeIncr = 1;
    float endTime = 0;


    private void Start()
    {
        if (SpawnerMove == SpawnPosition.Moving)
            currentTime = Time.time;

        if (spawnTiming == SpawnTiming.OnSpawnTimer)
            endTime = Time.time + spawnTime;

        if (spawnType == SpawnType.Grid)
            CreateBumperGrid();
    }

    void Update()
    {
        if(SpawnerMove == SpawnPosition.Moving)
        {
            currentTime += Time.deltaTime * timeIncr;
            if (currentTime >= movementTime || currentTime <= 0)
            {
                timeIncr *= -1;
            }
            spawnPosition = Vector2.Lerp(startPosition, endPosition, currentTime/movementTime);
        }

        if (spawnTiming == SpawnTiming.OnSpawnTimer)
        {
            if(Time.time >= endTime) 
            {
                endTime = Time.time + spawnTime;
                SpawnToken(tokenType, spawnPosition);
            }

        }

    }

    void CreateBumperGrid()
    {
        float columnWidth = gridWidth / gridColumns;
        float rowHeight = gridHeight / gridRows;
        Vector2 startPoint = new(transform.position.x - gridWidth / 2 + columnWidth / 2, transform.position.y - gridHeight / 2 + rowHeight / 2);
        bool valid = true;

        for (int i = 0; i < gridColumns; i++)
        {
            valid = !valid;
            for (int j = 0; j < gridRows; j++)
            {
                if (valid)
                {
                    SpawnToken(tokenType, new Vector2(startPoint.x + i * columnWidth, startPoint.y + j * rowHeight));
                    valid = false;
                }
                else valid = true;
            }
        }
    }

    public void SpawnToken(TokenType type, Vector2 pos)
    {
        IToken newToken = null;

        switch (type)
        {
            case TokenType.Marble:
                Marble newMarble = Instantiate(GetObject(tokenType), pos, Quaternion.identity).GetComponent<Marble>();
                //Specific Marble methods
                newToken = newMarble;
                break;

            case TokenType.Bumper:
                Bumper newBumper = Instantiate(GetObject(tokenType), pos, Quaternion.identity).GetComponent<Bumper>();
                //Specific Bumper methods
                newToken = newBumper;
                break;

            case TokenType.Score:
                Score newScore = Instantiate(GetObject(tokenType), pos, Quaternion.identity).GetComponent<Score>();
                newScore.InitLerpPos(startPosition, endPosition);
                newToken = newScore;
                break;
        }

        newToken.InitToken();
        
        if (randomSprite)
            newToken.SetSprite(GetSprite(spriteType, PokedexData.profilesList[Random.Range(0, PokedexData.profilesList.Count)]));
    
    }

    Sprite GetSprite(SpriteType spriteType, PokemonData profile)
    {
        return spriteType switch
        { 
            SpriteType.Portraits => profile.portrait,
            SpriteType.Icons => profile.icon,
            _ => null,
        };
    }

    GameObject GetObject(TokenType type) 
    {
        return type switch
        {
            TokenType.Marble => marbleObject,
            TokenType.Bumper => bumperObject,
            TokenType.Score => scoreObject,
            _ => null,
        };
    }

    private void OnDrawGizmos()
    {
        if(showDebug)
        {
            if(SpawnerMove == SpawnPosition.Moving)
            {
                Gizmos.color = startColor;
                Gizmos.DrawSphere(startPosition, 0.5f);
                Gizmos.color = endColor;
                Gizmos.DrawSphere(endPosition, 0.5f);
            }

            if(SpawnerMove == SpawnPosition.Fixed)
            {
                Gizmos.color = spawnColor;
                Gizmos.DrawWireSphere(spawnPosition, 0.5f);
            }

            if(spawnType == SpawnType.Grid)
            {
                float columnWidth = gridWidth / gridColumns;
                float rowHeight = gridHeight / gridRows;
                Vector2 startPoint = new(transform.position.x - gridWidth / 2 + columnWidth / 2, transform.position.y - gridHeight / 2 + rowHeight / 2);
                bool valid = true;

                for (int i = 0; i < gridColumns; i++)
                {
                    valid = !valid;
                    for (int j = 0; j < gridRows; j++)
                    {
                        if (valid)
                        {
                            Gizmos.color = gridColor;
                            Gizmos.DrawSphere(new Vector2(startPoint.x + i * columnWidth, startPoint.y + j * rowHeight), 0.3f);
                            Gizmos.color = Color.white;
                            valid = false;
                        }
                        else valid = true;
                    }
                }

            }
        }
    }
}

public enum TokenType
{
    Marble = 0,
    Bumper = 1,
    Score = 2,
}

public enum SpawnPosition
{
    Fixed = 0,
    Moving = 1,
}

public enum SpawnTiming
{
    AllAtStart = 0,
    OnSpawnTimer = 1,
}

public enum SpawnType
{
    OnPos = 0,
    Grid = 1,
}

public enum SpriteType
{
    Icons = 0,
    Portraits = 1,
}
