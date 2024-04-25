using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    [Header("Settings"), Space]

    [Header("Movement Settings")]
    [SerializeField] SpawnerMovement SpawnerMove = SpawnerMovement.Fixed;
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
    [SerializeField] SpriteSheet spriteSheet;
    [SerializeField] GameObject marbleObject;
    [SerializeField] GameObject scoreObject;
    [SerializeField] GameObject bumperObject;

    [Header("Token Settings")]
    [SerializeField] bool showDebug;
    [SerializeField] Color gridColor = Color.white;
    [SerializeField] Color startColor = Color.white;
    [SerializeField] Color endColor = Color.white;

    List<Sprite> spriteList;


    float currentTime = 0;
    float timeIncr = 1;
    float endTime = 0;

    private void Awake()
    {
        if(randomSprite)
            spriteList = new List<Sprite>(Resources.LoadAll<Sprite>(GetSpriteListName(spriteSheet)));
    }

    private void Start()
    {
        if (SpawnerMove == SpawnerMovement.Moving)
            currentTime = Time.time;

        if (spawnTiming == SpawnTiming.OnSpawnTimer)
            endTime = Time.time + spawnTime;

        if (spawnType == SpawnType.Grid)
            CreateBumperGrid();
    }

    void Update()
    {
        if(SpawnerMove == SpawnerMovement.Moving)
        {
            currentTime += Time.deltaTime * timeIncr;
            if (currentTime >= movementTime || currentTime <= 0)
            {
                timeIncr *= -1;
            }
            transform.position = Vector2.Lerp(startPosition, endPosition, currentTime/movementTime);
        }

        if (spawnTiming == SpawnTiming.OnSpawnTimer)
        {
            if(Time.time >= endTime) 
            {
                endTime = Time.time + spawnTime;
                SpawnToken(tokenType, transform.position);
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
                newToken = Instantiate(GetObject(tokenType), pos, Quaternion.identity).GetComponent<Marble>();
                break;

            case TokenType.Bumper:
                newToken = Instantiate(GetObject(tokenType), pos, Quaternion.identity).GetComponent<Bumper>();
                break;

            case TokenType.Score:
                newToken = Instantiate(GetObject(tokenType), pos, Quaternion.identity).GetComponent<Score>();
                break;
        }

        newToken.InitToken();
        
        if (randomSprite)
            newToken.SetSprite(spriteList[Random.Range(0, spriteList.Count)]);
    
    }

    string GetSpriteListName(SpriteSheet sprite)
    {
        return sprite switch
        { 
            SpriteSheet.Portraits => GameData.POKEMONS_PORTRAIT_LARGE,
            SpriteSheet.Icons => GameData.POKEMONS_ICONS_SMALL,
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
            if(SpawnerMove == SpawnerMovement.Moving)
            {
                Gizmos.color = startColor;
                Gizmos.DrawSphere(startPosition, 0.5f);
                Gizmos.color = endColor;
                Gizmos.DrawSphere(endPosition, 0.5f);
            }

            if(spawnType == SpawnType.Grid)
            {
                Gizmos.color = gridColor;
                Gizmos.DrawCube(transform.position, new Vector2(gridWidth, gridHeight));
            }
            Gizmos.color = Color.white;
        }
    }
}

public enum TokenType
{
    Marble = 0,
    Bumper = 1,
    Score = 2,
}

public enum SpawnerMovement
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

public enum SpriteSheet
{
    Icons = 0,
    Portraits = 1,
}
