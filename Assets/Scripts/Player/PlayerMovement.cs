
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private PlayerInputHandler inputHandler;


    public TankMovementData movementData;


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
            currentSpeed += movementData.acceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, movementData.maxSpeed);

            currentDriveDirection = Mathf.Sign(verticalInput);
        }
        else
        {
            currentSpeed -= movementData.deceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, movementData.maxSpeed);
        }
    }

    public void RotateTank()
    {
        rb.MoveRotation(rb.rotation - inputHandler.MoveInput.x * movementData.rotationSpeed * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        UpdateSpeed();
        MoveTank();
        RotateTank();

    }
}
