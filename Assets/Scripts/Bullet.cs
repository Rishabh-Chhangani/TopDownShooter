using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float lifetime;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BulletMovement();
        DestroyBullet();
    }
    private void BulletMovement()
    {
        Vector2 direction = Vector2.right;
        rb.velocity = direction * bulletSpeed;
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject,lifetime);
    }


}
