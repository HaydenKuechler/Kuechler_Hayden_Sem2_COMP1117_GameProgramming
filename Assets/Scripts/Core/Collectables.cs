using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] protected GameObject feedbackPrefab; // Bonus: FX prefab
    [SerializeField] protected AudioClip collectSound;    // Bonus: Sound clip

    // Virtual method allows children to provide their own version
    public virtual void OnCollect()
    {
        Debug.Log("Item Picked Up");

        // Bonus: Spawn FX and Play Sound
        if (feedbackPrefab != null) Instantiate(feedbackPrefab, transform.position, Quaternion.identity);
        if (collectSound != null) AudioSource.PlayClipAtPoint(collectSound, transform.position);

        Destroy(gameObject);
    }

    // Trigger collection when the player enters the collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollect();
        }
    }
}
