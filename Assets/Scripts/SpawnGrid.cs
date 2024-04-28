using UnityEngine;

public class SpawnGrid : MonoBehaviour
{
    [Header("Grid Settings"), Space]
    [SerializeField] float gridWidth;
    [SerializeField] float gridHeight;
    [SerializeField] int gridColumns;
    [SerializeField] int gridRows;
    [SerializeField] Bumper bumperPrefab;
    [Header("Debug"), Space]
    [SerializeField] bool showDebug = true;
    [SerializeField] Color gridColor = Color.white;

    public void SpawnBumperGrid()
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
                    Bumper newBumper = Instantiate(bumperPrefab, new Vector2(startPoint.x + i * columnWidth, startPoint.y + j * rowHeight), Quaternion.identity);
                    newBumper.InitBumper();
                    newBumper.SetData(PokedexData.Instance.GetRandomInTable(PokedexData.Instance.globalLootTable));
                    valid = false;
                }
                else valid = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (showDebug)
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
