using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerLook : MonoBehaviour
{
    private PlayerInputHandler inputHandler;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform visuals;
    [SerializeField] private  Transform weapon;

    public bool IsFacingRight { get; private set; }


    private void Awake()
    {

        inputHandler = GetComponent<PlayerInputHandler>();
        
        if(mainCamera == null)
            mainCamera = Camera.main;
        
        if(mainCamera == null ) 
            Debug.Log("Main Camera Missing");

        Debug.Log(visuals);
    }

    private void Update()
    {
        FlipPlayer();
        RotateWeapon();
    }


    private void RotateWeapon()
    {
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(inputHandler.LookInput);
        Vector2 direction = mouseWorldPosition - (Vector2)weapon.position;

        float angle = Mathf.Atan2(direction.x, direction.x) * Mathf.Rad2Deg;

        weapon.rotation = Quaternion.Euler(0f, 0f, angle);


    }


  private void FlipPlayer()
  {
        Debug.Log($"Player FlippingLogic");
        Vector2 mouseScreenPosition = inputHandler.LookInput;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);

        Vector3 scale = visuals.localScale;
        scale.x = mouseWorldPosition.x > transform.position.x ? 1 : -1; 
       visuals.localScale = scale;

        IsFacingRight = scale.x > 0;

  }
}

