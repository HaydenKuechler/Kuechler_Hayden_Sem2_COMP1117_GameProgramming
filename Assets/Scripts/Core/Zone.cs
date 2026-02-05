using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public abstract class Zone : MonoBehaviour
{
    [Header("Zone Settings")]
    [SerializeField] private Color debugColor = new Color(0, 1, 0.0f);
    
    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // The "Contract" (Every child object MUSt define what happens in this method) 

    protected abstract void ApplyZoneEffect(Player player);

    //Use a trigger to detect the player 
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Ensure the player is in the trigger
        if (collision.TryGetComponent(out Player player))
        {
            ApplyZoneEffect (player);
        }
    }

    //Debug purposes only/ ony visually helpful in the editor to determain diffrent zones (gravity, take damgae etc)
    private void OnDrawGizmos()
    {
        Gizmos.color = debugColor;
        BoxCollider2D box = GetComponent<BoxCollider2D>();

        //Box collider exisit in editor for development proccess
        if(box != null )
        {
            Gizmos.DrawCube(transform.position + (Vector3)box.offset, box.size);
        }



        //Drawing a Circle in editor for development proccess


        // CircleCollider2D circle = GetComponent<CircleCollider2D>();
        // if(circle != null)
        // {
        //     Gizmos.DrawSphere(transform.position, circle.radius);
        // }
    }
}
