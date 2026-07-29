using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerInputHandler : MonoBehaviour
{

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    
    public event Action FirePerformed;
    public event Action ReloadPerformed;
    public event Action PausePerformed;



    public void OnMove(InputValue value)
    {
        MoveInput = value.Get<Vector2>();
        Debug.Log(MoveInput);
    }

    public void OnLook(InputValue value)
    {
        LookInput = value.Get<Vector2>();
        
    }

    public void OnFire(InputValue value)
    {
        FirePerformed?.Invoke();
    }

    public void OnReload(InputValue value)
    {
        ReloadPerformed?.Invoke();
    }

    public void OnPause(InputValue value)
    {
       PausePerformed?.Invoke();
    }

}
