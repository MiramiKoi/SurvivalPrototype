using UnityEngine;
using UnityEngine.Events;

namespace Energy
{
    public class Energy :MonoBehaviour
    {
        [SerializeField] private float maxEnergy;
        [field :SerializeField] public float CurrentEnergy {get; private set;}

        public UnityEvent energyIsGone;

        private void Awake()
        {
            CurrentEnergy = maxEnergy;
        }
    
        public void ReduceEnergy(float amount)
        {
            CurrentEnergy -= amount;
        
            if (CurrentEnergy <= 0)
            {
                energyIsGone.Invoke();

                CurrentEnergy = 0;
            
                Debug.Log("Применяется штраф");
            }
        }

        public void IncreaseEnergy(float amount)
        {
            CurrentEnergy += amount;
        }

        public void ResetEnergy()
        {
            CurrentEnergy = maxEnergy;
        }
    }
}