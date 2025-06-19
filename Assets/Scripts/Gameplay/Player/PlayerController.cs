using Gameplay.InteractionSystem;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
         [Inject] private PlayerInput _input;
         [Inject] private PlayerMovement _playerMovement;
         private InteractableObject _nearbyInteractable;
         
         private void Update()
         {
             _playerMovement.Move(_input.GetMovementInput());

             if (_input.GetInteractPressed() && _nearbyInteractable != null)
             {
                 _nearbyInteractable.Interact();
             }
         }
         
         public void SetNearbyInteractable(InteractableObject interactable) 
         {
             _nearbyInteractable = interactable;
         }
    }
}
