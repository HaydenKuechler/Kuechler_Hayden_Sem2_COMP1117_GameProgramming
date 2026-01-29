using UnityEngine;

public class PlayersHealth : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float pushForce = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //If my position is greater than enemys position 
            if (transform.position.x > collision.transform.position.x)
            {

                Debug.Log("Enemy has hit you from the left side)");
            }
            else
            {
                Debug.Log("Enemy hit me from the right side");
            }
        }
    }

}
