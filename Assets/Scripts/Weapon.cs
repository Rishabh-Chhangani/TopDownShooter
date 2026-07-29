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

    private void Awake()
    {
        playerInputHandler = GetComponentInParent<PlayerInputHandler>();
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
        GameObject obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
