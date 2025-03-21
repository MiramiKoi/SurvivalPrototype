using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int CurrentHealth {get; private set;}
    
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        
        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
