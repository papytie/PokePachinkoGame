using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    [Header("Settings"), Space]
    [Header("Debug")]
    [SerializeField] bool showDebug;


    private void Start()
    {
        
    }

    void Update()
    {
        

    }


    private void OnDrawGizmos()
    {
        if(showDebug)
        {
            
        }
    }
}
