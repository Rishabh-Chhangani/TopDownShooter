
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private PlayerInputHandler inputHandler;

    [SerializeField] private float rotationSpeed = 180f;

    [SerializeField] private float maxSpeed = 10f;
    public float acceleration = 70;
    public float deceleration = 50;
    public float currentSpeed = 0;
    public float currentDriveDirection = 1;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponentInParent<PlayerInputHandler>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found.");
            enabled = false;
            return;
        }
        if (inputHandler == null)
        {
            Debug.LogError("PlayerInputHandler not found.");
            enabled = false;
            return;
        }
    }

    public void MoveTank()
    {
        rb.velocity = (Vector2)transform.up * currentSpeed * currentDriveDirection;
    }
    private void UpdateSpeed()
    {
        float verticalInput = inputHandler.MoveInput.y;

        if (Mathf.Abs(verticalInput) > 0.01f)
        {
            currentSpeed += acceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);

            currentDriveDirection = Mathf.Sign(verticalInput);
        }
        else
        {
            currentSpeed -= deceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        }
    }

    public void RotateTank()
    {
        rb.MoveRotation(rb.rotation - inputHandler.MoveInput.x * rotationSpeed * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        UpdateSpeed();
        MoveTank();
        RotateTank();

    }
}
