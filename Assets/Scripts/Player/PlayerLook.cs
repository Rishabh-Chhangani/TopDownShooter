using UnityEngine;



public class PlayerLook: MonoBehaviour
{
    [SerializeField] private PlayerInputHandler inputHandler;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private  Transform tankTurretParent;
    [SerializeField] private float turretRotationSpeed = 800f;

    private const float SpriteForwardOffSet = -90F;

    private void Awake()
    {
        if(inputHandler == null)
        {   
            Debug.LogError("PlayerInputHandler is not assigned ");
            enabled = false;
            return;
        }

        if(tankTurretParent == null)
        {
            Debug.LogError("TankTurretParent is not assigned!");
            enabled = false;
            return;
        }
       
        
        if(mainCamera == null)
        {

            mainCamera = Camera.main;
        }
        
        if(mainCamera == null)
        {
            Debug.LogError("MainCamera not found");
            enabled = false;
            return;
        }

    }

    private void Update()
    {
        RotateWeapon();
    }


    private void RotateWeapon()
    {
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(inputHandler.LookInput);

        Vector2 direction = mouseWorldPosition - (Vector2)tankTurretParent.position;



        float desiredAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float localAngle = desiredAngle - tankTurretParent.parent.eulerAngles.z ;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, localAngle);

        float maxRotationThisFrame = turretRotationSpeed * Time.deltaTime;



        tankTurretParent.localRotation = Quaternion.RotateTowards(tankTurretParent.localRotation,targetRotation,maxRotationThisFrame);

    }



}

