
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private PlayerInputHandler inputHandler;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 180f;



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

    private void FixedUpdate()
    {
        rb.velocity = (Vector2)transform.up * inputHandler.MoveInput.y * moveSpeed;
        rb.MoveRotation(rb.rotation -inputHandler.MoveInput.x *rotationSpeed *Time.fixedDeltaTime);
    }
}
