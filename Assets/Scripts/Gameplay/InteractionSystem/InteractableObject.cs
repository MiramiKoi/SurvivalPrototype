using Gameplay.Player;
using UnityEngine;

namespace Gameplay.InteractionSystem
{
    public class InteractableObject : MonoBehaviour
    {
        private bool _playerInRange;
        private PlayerController _currentPlayer;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _playerInRange = true;
                
                _currentPlayer = other.GetComponent<PlayerController>();
                _currentPlayer.SetNearbyInteractable(this);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _playerInRange = false;
                
                _currentPlayer.SetNearbyInteractable(null);
                _currentPlayer = null;
            }
        }

        public void Interact()
        {
            Debug.Log("Interacted");

            OnInteract();
        }

        protected virtual void OnInteract()
        {
            Debug.Log("OnInteract");
        }
    }
}
