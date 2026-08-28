using System;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    public int maxHealth = 100;
    private Transform rootEntity;
    

    public event Action OnDeath;
    public event Action OnDamaged;
    public event Action<float> OnHealthChanged;


    private void Awake()
    {
        currentHealth = maxHealth;
        rootEntity = transform.root;

        Debug.Log($"Damagable Awake: {currentHealth}/{maxHealth}");
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
            OnHealthChanged?.Invoke((float)currentHealth / maxHealth);
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
        Debug.Log("Damagable.Die() CALLED");

        OnDeath?.Invoke();
        Destroy(rootEntity.gameObject);

    }   
}