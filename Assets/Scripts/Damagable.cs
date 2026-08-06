using System;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    private int currentHealth;
    public int maxHealth = 100;

    

    public event Action OnDeath;
    public event Action OnDamaged;
    public event Action<float> OnHeatlhChanged;


    private void Awake()
    {
        currentHealth = maxHealth;
    }


    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            OnHeatlhChanged?.Invoke((float)currentHealth / maxHealth);
        }
    }

    public void TakeDamage(int damagePoints)
    {
        CurrentHealth -= damagePoints;
        if(currentHealth <= 0)
        {
       
            Die();
        }
        else
        {
            OnDamaged?.Invoke();
            Debug.Log(currentHealth);
        }
    }

    public void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);

    }



   
}