using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    //Private variables 

    [Header("Character Stats")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private int maxHealth =100;

    private int currentHealth;

    private bool isDead = false;
    protected Animator anim;
    //Public properties 
    public float MoveSpeed
    {
        //Read Only, player can't interact with this 
        get { return moveSpeed; }   
    }

    public bool IsDead
    { 
        // Read Only
        get { return isDead; } 
    }

    protected int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        // level of protection

        if (isDead)
        {
            return;
        }

        currentHealth -= amount;
        Debug.Log($" {gameObject.name} Hp is now {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        isDead = true;
        Debug.Log($"{gameObject.name} has died");
    }


}
