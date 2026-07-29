using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(PlayerInputHandler))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInputHandler moveInput;
    [SerializeField] private float moveSpeed = 10f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveInput = GetComponent<PlayerInputHandler>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput.MoveInput * moveSpeed;
    }
}
