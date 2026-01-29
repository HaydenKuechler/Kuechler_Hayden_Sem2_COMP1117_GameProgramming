using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Settings")]
    public float health = 100f;
    public ParticleSystem soulPrefab;

    private bool isDead = false;

    public void TakeDamage(float damage)
    {
        if(isDead) return;
        health -= damage;
        if (health == 0)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Animator>().Play("Death Animation");
            soulPrefab.Play();
        }
    }
}
