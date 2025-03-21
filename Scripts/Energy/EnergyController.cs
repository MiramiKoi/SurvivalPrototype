using Player;
using UnityEngine;

namespace Energy
{
    public class EnergyController : MonoBehaviour
    {
        private global::Energy.Energy _energy;
        private PlayerController _playerController;
        private PlayerAttack _playerAttack;
    
        [Header("Затраты энергии")]
        [SerializeField] private float energyOnRun;
        [SerializeField] private float energyOnHit;
    
        [Header("Штрафы")]
        [SerializeField] private float moveSpeedWithoutEnergy;
        [SerializeField] private int damageWithoutEnergy;

        private void Awake()
        {
            _energy = GetComponent<global::Energy.Energy>();
        
            _playerController = FindFirstObjectByType<PlayerController>();
            _playerController.isRunning.AddListener(() => WastingEnergy(energyOnRun));
        
            _playerAttack = FindFirstObjectByType<PlayerAttack>();
            _playerAttack.isAttacking.AddListener(() => WastingEnergy(energyOnHit));
        }
    
        private void WastingEnergy(float value)
        {
            _energy.ReduceEnergy(value);
        
            if (_energy.CurrentEnergy <= 0)
            {
                ApplyPenalties();
            }
            else
            {
                RemovePenalties();
            }
        }

        private void ApplyPenalties()
        {
            _playerController.SetMoveSpeed(moveSpeedWithoutEnergy);
            _playerAttack.SetDamage(damageWithoutEnergy);
        }

        private void RemovePenalties()
        {
            _playerController.SetInitialSpeed();
            _playerAttack.SetInitialDamage();
        }
    }
}