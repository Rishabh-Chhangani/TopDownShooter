using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float lifetime;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
        
    }
    public void Initialize(Vector2 direction)
    {
        Debug.Log(direction);
        Debug.Log(rb);
        rb.velocity = direction * bulletSpeed;

        Destroy(gameObject, lifetime);
   
    }

  


}
