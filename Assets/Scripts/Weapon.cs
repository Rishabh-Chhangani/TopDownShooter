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
        playerInputHandler = GetComponentInParent<PlayerInputHandler>();
        playerLook = GetComponentInParent<PlayerLook>();
    }


    private void OnEnable()
    {
        playerInputHandler.FirePerformed += Fire;
    }
    private void OnDisable()
    {
        playerInputHandler.FirePerformed -= Fire;
    }

    public void Fire()
    {
        if(playerLook.IsFacingRight)
        {

        GameObject obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
        GameObject obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        }
    }
}
