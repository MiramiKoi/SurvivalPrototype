using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int attack;

    public List<GameObject> targets;

    private void OnTriggerEnter(Collider other)
    {
        targets.Add(other.TryGetComponent(out Health health) ? other.gameObject : null);
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.gameObject);
    }
    
    public void ApplyDamage(int damage)
    {
        if (targets == null) return;
        
        for (var i = targets.Count - 1; i >= 0; i--)
        {
            if (targets[i] == null) 
            {
                targets.RemoveAt(i);
                continue;
            }

            var health = targets[i].GetComponent<Health>();

            if (health == null) continue;
            
            health.TakeDamage(damage);
            
            Debug.Log($"Attack target {targets[i]} has {damage}");
                
            if (!targets[i].activeSelf)
            {
                targets.RemoveAt(i);
            }
        }
    }
}