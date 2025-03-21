using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Interaction
{
    public class InteractionSystem : MonoBehaviour
    {
        [SerializeField] private Interactable interactableObject;
    
        [SerializeField] private GameObject interactPanel;
        [SerializeField] private TextMeshProUGUI interactName;
        
        private void Awake()
        {
            interactPanel.SetActive(false);
        }

        public void OnInteractInput(InputAction.CallbackContext context)
        {
            if (interactableObject == null) return;
        
            interactableObject.Interact();
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Interactable interactable)) return;
        
            interactableObject = other.GetComponent<Interactable>();

            OpenInteractUI(other.gameObject);
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out Interactable interactable)) return;
        
            interactableObject = null;
        
            CloseInteractUI();
        }

        private void OnTriggerStay(Collider other)
        {
            if (interactableObject == null) return;
        
            UpdateInteractUI(other.gameObject);
        }

        private void OpenInteractUI(GameObject other)
        {
            UpdateInteractUI(other);
        
            interactPanel.SetActive(true);
        
            interactName.text = other.GetComponent<Interactable>().interactableName;
        }

        private void UpdateInteractUI(GameObject other)
        {
            var screenPosition = UnityEngine.Camera.main.WorldToScreenPoint(other.transform.position);
            interactPanel.transform.position = screenPosition;
        }
    
        private void CloseInteractUI()
        {
            interactPanel.SetActive(false);
        }
    }
}
