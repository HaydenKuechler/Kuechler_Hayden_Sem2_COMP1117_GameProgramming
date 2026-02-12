using UnityEditor.Build;
using UnityEngine;
public class NPCLogic : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject speechBubble;
    public void Interact()
    {
        //Speech bubble doesn't exist 
        if (speechBubble == null)
        {
            return;
        }

        //Speech bubble exist 
        bool isCurrentlyActive = speechBubble.activeSelf;
        speechBubble.SetActive(!isCurrentlyActive);

        Debug.Log("Npc has been interacted with");
    }
}
