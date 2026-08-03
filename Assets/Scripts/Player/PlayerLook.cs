using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerLook: MonoBehaviour
{
    [SerializeField] private PlayerInputHandler inputHandler;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform tankBaseVisual;
    [SerializeField] private  Transform tankTurretParent;
    [SerializeField] private float turretRotationSpeed = 800f;
    public bool IsFacingRight { get; private set; }


    private void Awake()
    {

       
        
        if(mainCamera == null)
            mainCamera = Camera.main;
        
        if(mainCamera == null ) 
            Debug.Log("Main Camera Missing");

        Debug.Log(tankBaseVisual);
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

        // If your sprite points upward, keep the -90f.
        // If it points right, remove the -90f.
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, desiredAngle - 90f);

        float rotationStep = turretRotationSpeed * Time.deltaTime;

        tankTurretParent.rotation = Quaternion.RotateTowards(
            tankTurretParent.rotation,
            targetRotation,
            rotationStep);

    }


  private void FlipPlayer()
  {
        
        Vector2 mouseScreenPosition = inputHandler.LookInput;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);

        Vector3 scale = tankBaseVisual.localScale;
        scale.x = mouseWorldPosition.x > transform.position.x ? 1 : -1;
        tankBaseVisual.localScale = scale;

        IsFacingRight = scale.x > 0;

  }
}

