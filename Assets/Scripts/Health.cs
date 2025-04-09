using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
    private UnityEvent<float> onHealthChange;
    [SerializeField]
    private UnityEvent onDamageRecieved;
    [SerializeField]
    private UnityEvent onDeath; 
    private float currentHealth;
    public float CurrentHealth => currentHealth;
    
    public void InitializeHealth()
    {
        SetHealth(maxHealth);
    }

    private void SetHealth(float health)
    {
        currentHealth = health;
        onHealthChange?.Invoke(currentHealth / maxHealth);
    }

    public void TakeDamage(float damage)
    {
        SetHealth(currentHealth - damage);
        if (currentHealth <=0)
        {
            Die();
        }
        else
        {
            onDamageRecieved?.Invoke();
        }
    }
    private void Die()
    {
        onDeath?.Invoke();
    }

}
