using UnityEngine;

public class Weapon : MonoBehaviour
{
    private PlayerInputHandler playerInputHandler;


    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;


    private PlayerLook playerLook;

    private void Awake()
    {


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

        if (firePoint == null)
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
        GameObject obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Vector2 direction = playerLook.IsFacingRight ? Vector2.right : Vector2.left;
        //Bullet bullet = obj.GetComponent<Bullet>();

        //if (bullet != null)
        //{
        //    bullet.Initialize(direction);
        //}

    }
}
