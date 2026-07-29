using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerLook : MonoBehaviour
{
    private PlayerInputHandler inputHandler;
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform player;

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MouseWorldPosition();


    }



  private void MouseWorldPosition()
  {
        Vector2 mouseScreenPosition = inputHandler.LookInput;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    
        if(mouseWorldPosition.x > player.transform.position.x )
        {
            spriteRenderer.flipX = true;
      
        }
        else if(mouseWorldPosition.x < player.transform.position.x)
        {
            spriteRenderer.flipY = false;
        }
        Debug.Log(mouseWorldPosition);

  }
}

