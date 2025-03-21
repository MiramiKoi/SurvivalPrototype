using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [field: SerializeField] public int CurrentHealth {get; private set;}

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
