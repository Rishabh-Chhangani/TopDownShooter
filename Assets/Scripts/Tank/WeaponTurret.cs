using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(ObjectPool))]
public class WeaponTurret : MonoBehaviour
{
    
    private TankController tankController;


    private AimTurret aimTurret;

    public List<Transform> turretBarrels;
    public TurretData turretData;


    private bool canShoot = true;
    private Collider2D[] tankColliders;
    private float currentDelay = 0;

    private ObjectPool bulletPool;
    [SerializeField]
    private int bulletPoolCount = 10;


    

    private void Awake()
    {

        tankColliders = GetComponentsInParent<Collider2D>();
        
        aimTurret = GetComponentInParent<AimTurret>();
        bulletPool = GetComponent<ObjectPool>();


        tankController = GetComponentInParent<TankController>();

        if(tankController == null)
        {
            Debug.LogError("TankController is not found in parent.");
            enabled = false;
            return;
        }

        if (turretData.bulletPrefab == null)
        {
            Debug.LogError("Bullet Prefab is not assigned.");
            enabled = false;
            return;
        }
    }

    private void Start()
    {
        bulletPool.Initialize(turretData.bulletPrefab, bulletPoolCount);
    }


  

    public void Fire()
    {

        Debug.Log("Fire Called");
        if (canShoot)
        {
            Debug.Log("Can Shoot");
            canShoot = false;
            currentDelay = turretData.reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                Debug.Log("Spwaning");

                GameObject bullet = bulletPool.CreateObject();

                Debug.Log("Bullet : " +  bullet);

                bullet.transform.position = barrel.position;
                bullet.transform.rotation = barrel.rotation;

                Debug.Log("Position = " +  transform.position);

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
            if(currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }



}
