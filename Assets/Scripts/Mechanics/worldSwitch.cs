using UnityEngine;
using UnityEngine.Events;

public class worldSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private UnityEvent onActivated;

    private SpriteRenderer sRend;
    private bool isFlipped = false;

    private void Awake()
    {
      sRend = GetComponent<SpriteRenderer>(); //Cachine the reference 
    }

    public void Interact()
    {
        isFlipped = !isFlipped; //Flips the boolean value 

        sRend.sprite = isFlipped ? onSprite : offSprite;

        if(isFlipped)
        {
            onActivated.Invoke();
        }
       

    }
}
