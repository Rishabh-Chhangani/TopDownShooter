using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float speed = 10;
    public int damage = 50;
    public float maxDistance = 100;

    private Vector2 startPosition;
    private float conquerDistance = 0;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        conquerDistance = Vector2.Distance(transform.position, startPosition);
        if(conquerDistance >= maxDistance)
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        rb2d.velocity = Vector2.zero;
        Destroy(gameObject);
    }

    public void Initialize()
    {
        startPosition = transform.position;
        rb2d.velocity = transform.up * speed;
        Debug.Log("Velocity: " + rb2d.velocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collied" + collision.name);
        Damagable damagable = collision.gameObject.GetComponent<Damagable>();

        if (damagable != null)
        {
            damagable.TakeDamage(damage);
            Debug.Log("Damage Object : "+ damagable.name);
        }
        DestroyBullet();
    }
}
