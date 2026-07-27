using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(PlayerInputHandler))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInputHandler input;
    [SerializeField] private float moveSpeed = 10f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
    }

    private void FixedUpdate()
    {
        rb.velocity = input.MoveInput * moveSpeed;
    }
}
