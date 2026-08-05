using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private PlayerInputHandler playerInputHandler;
    private PlayerLook playerLook;

    public List<Transform> turretBarrels;
    [SerializeField] private GameObject bulletPrefab;
    public float reloadDelay = 1;


    private bool canShoot = true;
    private Collider2D[] tankColliders;
    private float currentDelay = 0;

    

    private void Awake()
    {

        tankColliders = GetComponentsInChildren<Collider2D>();
        playerInputHandler = GetComponentInParent<PlayerInputHandler>();
        playerLook = GetComponentInParent<PlayerLook>();



        if (playerInputHandler == null)
        {
            Debug.LogError("PlayerInputHandler not found.");
            enabled = false;
            return;
        }

        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet Prefab is not assigned.");
            enabled = false;
            return;
        }

        if (barrel == null)
        {
            Debug.LogError("Fire Point is not assigned.");
            enabled = false;
            return;
        }
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
        if (playerInputHandler != null)
        {
            playerInputHandler.FirePerformed -= Fire;
        }
    }

    private void Fire()
    {

        Debug.Log("Fire Called");
        if (canShoot)
        {
            Debug.Log("Can Shoot");
            canShoot = false;
            currentDelay = reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                Debug.Log("Spwaning");

                GameObject bullet = Instantiate(bulletPrefab);

                Debug.Log("Bullet : " +  bullet);

                bullet.transform.position = barrel.position;
                bullet.transform.rotation = barrel.rotation;

                Debug.Log("Position = " + bullet.transform.position);

                bullet.GetComponent<Bullet>().Initialize();

                Debug.Log("Initialized");

                foreach (var colllider in tankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), colllider);
                }
            }


        }


    }

    public void Update()
    {
        Reload();
    }

    private void Reload()
    {

        if(canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if(currentDelay <=- 0)
            {
                canShoot = true;
            }
        }
    }



}
