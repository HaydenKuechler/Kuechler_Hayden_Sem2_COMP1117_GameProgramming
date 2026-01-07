using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerr : MonoBehaviour

{
    private PlayerStats stats;
    //Component references

    private Rigidbody2D rbody;

    //Field references

    private Vector2 moveInput;

    //Start is called before the first frame update
    void Awake()
    {
        // Initiallize here 
        rbody = GetComponent<Rigidbody2D>();

        stats= new PlayerStats();
        int speed = stats.MoveSpeed;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

   void FixedUpdate()
    {
        ApplyMovement();
    }

    void ApplyMovement ()
    {
        float velocityx = moveInput.x;

        rbody.linearVelocity = new Vector2(velocityx , rbody.linearVelocity.y);
    }

}
