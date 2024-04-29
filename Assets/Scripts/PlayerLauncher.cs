using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLauncher : MonoBehaviour
{
    [Header("Settings"), Space]
    [SerializeField] float height = 5f;
    [SerializeField] float leftBorderThreshold = -5f;
    [SerializeField] float rightBorderThreshold = 5f;
    [SerializeField] float speed = 5f;
    [SerializeField] float acceleration = 50f;
    [SerializeField] float startForce = 100f;
    [SerializeField] float maxForce = 1000f;
    [SerializeField] float forceIncrease = 10f;
    [SerializeField] Marble marblePrefab;
    [SerializeField] float currentForce = 0;

    [Header("Debug")]
    [SerializeField] bool showDebug;
    [SerializeField] Color thresholdColor = Color.blue;

    LauncherControls launcherControls;
    InputAction move;
    InputAction launch;
    InputAction power;
    InputAction aim;
    float currentSpeed = 0;
    Vector2 launchVector = Vector2.zero;
    Vector2 mousePos = Vector2.zero;
    Vector2 mouseWorldPos = Vector2.zero;

    private void Awake()
    {
        launcherControls = new LauncherControls();
        launcherControls.Launcher.Enable();
        move = launcherControls.Launcher.Move;
        launch = launcherControls.Launcher.Launch;
        power = launcherControls.Launcher.Power;
    }

    private void Start()
    {
        ResetPosition();
        currentForce = startForce;
    }

    void Update()
    {
        float moveAxis = move.ReadValue<float>();
        Vector2 position2D = transform.position;
        mousePos = Mouse.current.position.ReadValue();
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        launchVector = (mouseWorldPos - position2D).normalized * currentForce/100;

        //Acceleration factor update
        currentSpeed = Mathf.MoveTowards(currentSpeed, moveAxis * speed, Time.deltaTime * acceleration);

        //Movement
        if (moveAxis >= .1f && transform.position.x >= rightBorderThreshold || moveAxis <= -.1f && transform.position.x <= leftBorderThreshold 
                                                                            || currentSpeed >= .1f && transform.position.x >= rightBorderThreshold 
                                                                            || currentSpeed <= -.1f && transform.position.x <= leftBorderThreshold)
            currentSpeed = 0;
        
        else transform.position = new Vector2(transform.position.x + currentSpeed * Time.deltaTime, height);

        //Launch
        if (launch.IsPressed())
            currentForce = Mathf.MoveTowards(currentForce, maxForce, Time.deltaTime * forceIncrease);

        if(launch.WasReleasedThisFrame())
        {
            LaunchMarble(launchVector, currentForce);
            currentForce = startForce;
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector2(0, height);
    }

    public void LaunchMarble(Vector2 vector, float force)
    {
        Marble newMarble = Instantiate(marblePrefab, transform.position, Quaternion.identity);
        newMarble.InitMarble();
        newMarble.Rigidbody.AddForce(vector * force);
    }

    private void OnDrawGizmos()
    {
        if (showDebug)
        {
            Gizmos.color = thresholdColor;
            Gizmos.DrawLine(new Vector2(leftBorderThreshold, height), new Vector2(rightBorderThreshold, height));
            Vector2 position2D = transform.position;
            Vector2 launchPosition = position2D + launchVector;
            Gizmos.color = Color.red;
            //Gizmos.DrawSphere(mouseWorldPos, 0.1f);
            Gizmos.DrawLine(position2D, launchPosition);
            Gizmos.DrawWireSphere(launchPosition, .2f);
            Gizmos.color = Color.white;
        }
    }
}
