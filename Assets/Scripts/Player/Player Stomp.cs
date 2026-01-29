using UnityEngine;

public class PlayerStomp : MonoBehaviour
{
    public float bounceForce = 10f;
    public Rigidbody playerRigidbody;

    private void OnCollisionEnter2D(Collision2D collision)
    {

       
        //if (playerRigidbody.CompareTag("Enemy"))
        //{
        //    Destroy(collision.gameObject);

        //    playerRigidbody.angularVelocity = new Vector3(playerRigidbody.angularVelocity.x, 0f);
        //    playerRigidbody.AddForce(Vector2.up * bounceForce);

        //    Debug.Log($"Player has stomped");
        //}

        if(collision.rigidbody.CompareTag("Enemy"))
            {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(25f);  
            }
    }


}
