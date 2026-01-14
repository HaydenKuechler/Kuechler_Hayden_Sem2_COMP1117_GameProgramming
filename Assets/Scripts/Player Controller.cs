using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerr : MonoBehaviour

{
    //Inital Player stats 
    [Header("Initial Player stats")]
    [SerializeField] private float initailSpeed = 5;

   // [Header("Initial Jump Height")]
  //  [SerializeField] private float initalHeight = 5;

    [Header("Initial Health")]
    [SerializeField] private int initailHealth = 100;

    


    //Private Variables 
    private Vector2 moveInput;
    private PlayerStats stats;
   
    //Component references
    private Rigidbody2D rbody;

    //Start is called before the first frame update
    void Awake()
    {
        // Initiallize here 
        rbody = GetComponent<Rigidbody2D>();

        stats = new PlayerStats();
        stats.MoveSpeed = initailSpeed;
        stats.MaxHealth = initailHealth;
        stats.CurrentHealth = initailHealth;
       

    }

        void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }

        void OnJump(InputValue value)
        {
            moveInput = value.Get<Vector3>();
        }
    
      

   void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement ()
    {
        float velocityx = moveInput.x * stats.MoveSpeed;

        rbody.linearVelocity = new Vector2(velocityx, rbody.linearVelocity.y);
    }

    

    


    public void TakeDamage(int damageAmount)
    {
        stats.CurrentHealth -= damageAmount;

        Debug.Log("Player has taken damage");
    }
}
