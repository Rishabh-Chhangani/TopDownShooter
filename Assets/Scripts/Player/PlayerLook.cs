using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerLook : MonoBehaviour
{
    private PlayerInputHandler inputHandler;
    private Camera mainCamera;

    [SerializeField] private Transform visuals;
    public bool IsFacingRight { get; private set; }

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        PlayerFlip();


    }



  private void PlayerFlip()
  {
        Vector2 mouseScreenPosition = inputHandler.LookInput;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    
        if(mouseWorldPosition.x > transform.position.x )
        {
            Vector3 scale = visuals.localScale;
            scale.x = 1;
            visuals.localScale = scale;
            IsFacingRight = true;
            Debug.Log(IsFacingRight);
      
        }
        else if(mouseWorldPosition.x < transform.position.x)
        {
            Vector3 scale = visuals.localScale;
            scale.x = -1;
            visuals.localScale = scale;
            IsFacingRight = false;
            Debug.Log(IsFacingRight);
        }
        Debug.Log(mouseWorldPosition);

  }
}

