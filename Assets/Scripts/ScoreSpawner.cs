using UnityEngine;

public class ScoreSpawner : MonoBehaviour
{
    [Header("Spawn Settings"), Space]
    [SerializeField] Vector2 spawnPosition;
    [SerializeField] Vector2 endPosition;
    [SerializeField] float spawnTime = 3;
    [SerializeField] Score scorePrefab;

    [Header("Debug")]
    [SerializeField] bool showDebug = true;
    [SerializeField] Color spawnColor = Color.green;
    [SerializeField] Color endColor = Color.red;

    float endTime = 0;

    public void InitScoreSpawner()
    {
        endTime = Time.time + spawnTime;
    }

    private void Update()
    {
        if (Time.time >= endTime)
        {
            endTime = Time.time + spawnTime;
            Score newScoreObject = Instantiate(scorePrefab, spawnPosition, Quaternion.identity);
            newScoreObject.InitScore(spawnPosition, endPosition, PokedexData.Instance.GetRandomInTable(PokedexData.Instance.globalLootTable));
        }
    }

    private void OnDrawGizmos()
    {
        if (showDebug)
        {
            Gizmos.color = spawnColor;
            Gizmos.DrawWireSphere(spawnPosition, .5f);
            Gizmos.color = endColor;
            Gizmos.DrawWireSphere(endPosition, .5f);
            Gizmos.color = Color.white;
        }
    }
}
