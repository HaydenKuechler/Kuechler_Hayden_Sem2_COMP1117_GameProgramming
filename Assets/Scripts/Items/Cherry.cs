using UnityEngine;

public class Cherry : Collectible
{
    public override void OnCollect()
    {
        Debug.Log("Sweet Cherry Picked Up!");
        base.OnCollect(); // Executes base Destroy, Sound, and FX logic
    }
}
