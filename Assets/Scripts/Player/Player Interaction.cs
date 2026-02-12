using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private float interactRange = 1.5f; //How close I must be to interact with objects
    [SerializeField] private LayerMask interactableLayer;  //Ensure that I'm interacting with objects 

    //Function that will be called when "Interact" is triggered

    public void OnInteract(InputAction.CallbackContext context)
    //Fire once when pressed/ see if the button was pressed and context begins 
    {
        if(context.started)
        {
            //Perform our Interaction 
            PerformInteraction();
        }
    }

    private void PerformInteraction()
    {           //Find everything on the interactable layer and interact with it 
        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRange, interactableLayer);
        //Check if it hit something
        if (hit != null)
        { 
            //Hit something on interactable layer 
            if(hit.TryGetComponent<IInteractable>(out IInteractable interactable ))
            {
                //the object in interactable layer DOEs have a sript then do this
                interactable.Interact();

                Debug.Log($"Interacted with {hit.name}");
            }
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
