using UnityEngine;

namespace Interaction
{
    public class Interactable : MonoBehaviour
    {
        private Energy.Energy _energy;
    
        public string interactableName;

        private void Awake()
        {
            _energy = FindFirstObjectByType<Energy.Energy>();
        }

        public void Interact()
        {
            Debug.Log($"Взаимодействую с {interactableName}");
        
            BadInteract();
        }

        private void BadInteract()
        {
            _energy.ResetEnergy();
        }
    }
}