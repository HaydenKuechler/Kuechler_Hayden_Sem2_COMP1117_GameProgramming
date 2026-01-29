using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour

    //Read Input from the input system and Define diffrent inputs 

{
    // what inputs can my player do right now
    // 1. Move 
    // 2. Jump 
    private Vector2 moveInput;
    private bool jumpTriggered = false; // Jumping?? 
    
    // Public properties to read input values 

    public Vector2 MoveInput
    {
        //Read only
        get { return moveInput; }
    }

    public bool JumpTriggered
    { 
        // Read only 
        get { return jumpTriggered; } 
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        //Save input to the field 
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started) // Pushed the button down 
        {
            jumpTriggered = true;
        }

        else if(context.canceled) //Let go of the button 
        {
            jumpTriggered = false;
        }
    }

}
