using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] SpawnGrid spawnGrid;
    [SerializeField] ScoreSpawner scoreSpawner;

    void Start()
    {
        PokedexData.Instance.InitPokedex();
        spawnGrid.SpawnBumperGrid();
        scoreSpawner.InitScoreSpawner();
    }

    void Update()
    {
        
    }
}
