using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    private GameManager gameManager;
    public LayerMask playerLayerMask;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     if(((1 << collision.gameObject.layer) & playerLayerMask) != 0)
        {
            gameManager.SaveData();
            gameManager.LoadNextLevel();
        }
    }
}
