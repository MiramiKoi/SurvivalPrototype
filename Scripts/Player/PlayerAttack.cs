using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [HideInInspector] public UnityEvent isAttacking;
    
        [SerializeField] private SphereCollider attackCollider;
        [SerializeField] private Transform attackZone;

        [SerializeField] private LayerMask interactionLayers;
    
        [SerializeField] private int damage = 10;
    
        private int _initialDamage;

        private void Awake()
        {
            _initialDamage = damage;
        }
    
        public void Interact()
        {
            var hitObjects = Physics.OverlapSphere(attackZone.position , attackCollider.radius, interactionLayers);
        
            foreach (var hit in hitObjects)
            {
                if (!hit.TryGetComponent(out Health health)) continue;
            
                health.TakeDamage(damage);
            
                Debug.Log($"Атаковал: {hit.name}, осталось {health.CurrentHealth} HP");
            
                isAttacking.Invoke();
            }
        }

        public void SetDamage(int value)
        {
            damage = value;
        }

        public void SetInitialDamage()
        {
            damage = _initialDamage;
        }
    }
}