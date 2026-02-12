using NUnit.Framework.Constraints;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputHandler), typeof(Rigidbody2D))]
public class Player : Character
{

    //Jumping logic
    [Header("Movement Settings")]
    [SerializeField] private float jumpForce = 10f; // force of my jump 
    [SerializeField] private LayerMask groundlayer; //Checking to see if I'm stadning on the ground layer 
    [SerializeField] private Transform groundCheck; //Position of my ground check 
    [SerializeField] private float groundCheckRadius = 0.2f; // Size of my groudn check 
    //Component references
    private Rigidbody2D rbody;                   //Used to aplly force to move or jump 
    private PlayerInputHandler input;            //Reads the input 
    private bool isGrounded;                     // Holds the result of the ground check operation 
    private float currentSpeedModifier = 1f;

    //Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        // Initiallize here 
        rbody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();


    }

    private void Update()
    {
        // Perform ground check 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundlayer);
       //Debug.Log(isGrounded);

        anim.SetFloat("xVelocity", Mathf.Abs(rbody.linearVelocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rbody.linearVelocity.y);


        //Handle sprite flippig 
        if (input.MoveInput.x != 0 && !isDead)
        {
            transform.localScale = new Vector3(Mathf.Sign(input.MoveInput.x), 1, 1);
        }
    }

        void FixedUpdate()
        {
            if (IsDead)
            {
                return;
            }

            HandleMovment();
            HandleJump();

            //Handle movement 
            //Jumping
            //Mario like falling 
        }
    

    private void HandleMovment()
    {
        //We get input from input handler 
        // We get Move speed from our Parent class 
        float horizontalvelocity = input.MoveInput.x * MoveSpeed * currentSpeedModifier;

        rbody.linearVelocity = new Vector2(horizontalvelocity, rbody.linearVelocity.y);

        currentSpeedModifier = 1f;
    }

    private void HandleJump()
    {
        if (input.JumpTriggered && isGrounded)
        { ApplyJumpForce (); }
    }
    private void ApplyJumpForce()
    {
        rbody.linearVelocity = new Vector2(rbody.linearVelocity.x, 0);
        rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void ApplySpeedModifier(float speedModifier)
    {
        currentSpeedModifier = speedModifier;
    }
    

    //Starts player specific death sequence 
    public override void Die()
    {
        isDead = true;
        Debug.Log("Payer has Died");
    }
        
}
