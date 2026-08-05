using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float lifetime;

    public float speed = 10;
    public int damage = 5;
    public float maxDistance = 10;

    private Vector2 startPosition;
    private float conquerDistance = 0;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //public void Initialize(Vector2 direction)
    //{
    //    Debug.Log(direction);
    //    Debug.Log(rb2d);
    //    rb2d.velocity = direction * bulletSpeed;

    //    Destroy(gameObject, lifetime);

    //}


    private void Update()
    {
        conquerDistance = Vector2.Distance(transform.position, startPosition);
        if(conquerDistance >= maxDistance)
        {
            DisableObject();
        }

        
    }

    private void DisableObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    public void Initialize()
    {
        startPosition = transform.position;
        rb2d.velocity = transform.up * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collied" + collision.name);

        DisableObject();
    }
}
