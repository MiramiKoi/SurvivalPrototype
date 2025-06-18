using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
         [Inject] private PlayerInput _input;
         [Inject] private PlayerMovement _playerMovement;

         private void Update()
         {
             _playerMovement.Move(_input.GetMovementInput());
         }
    }
}
