using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    private PlayerInputHandler playerInputHandler; 
    [SerializeField] private PlayerLook playerLook;

    private void Awake()
    {
        Debug.Log("Current Object: " + gameObject.name);

        Transform current = transform;

        while (current != null)
        {
            Debug.Log("Checking: " + current.name);

            PlayerInputHandler input = current.GetComponent<PlayerInputHandler>();
            PlayerLook look = current.GetComponent<PlayerLook>();

            Debug.Log("InputHandler: " + input);
            Debug.Log("PlayerLook: " + look);

            current = current.parent;
        }

        playerInputHandler = GetComponentInParent<PlayerInputHandler>();
        playerLook = GetComponentInParent<PlayerLook>();

        Debug.Log("Final Input: " + playerInputHandler);
        Debug.Log("Final Look: " + playerLook);
    }


    private void OnEnable()
    {
        if (playerInputHandler != null)
        {
            playerInputHandler.FirePerformed += Fire;
        }
    }
    private void OnDisable()
    {
        if(playerInputHandler != null)
        {
            playerInputHandler.FirePerformed -= Fire;
        }
    }

    public void Fire()
    {
        GameObject obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector2 direction = playerLook.IsFacingRight ? Vector2.right : Vector2.left;
        obj.GetComponent<Bullet>().Initialize(direction);

    }
}
