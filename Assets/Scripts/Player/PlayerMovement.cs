using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(PlayerInputHandler))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    
    private PlayerInputHandler moveInput;



    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 180f;
    [SerializeField] private float turretRotationSpeed = 180f;


    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        moveInput = GetComponentInParent<PlayerInputHandler>();
        Debug.Log(rb);
      
    }



    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
   
        rb.velocity = (Vector2)rb.transform.up *moveInput.MoveInput.y *moveSpeed;

        rb.MoveRotation(rb.rotation -moveInput.MoveInput.x *rotationSpeed *Time.fixedDeltaTime);

        //Debug.Log(moveInput.MoveInput);
    }
}
