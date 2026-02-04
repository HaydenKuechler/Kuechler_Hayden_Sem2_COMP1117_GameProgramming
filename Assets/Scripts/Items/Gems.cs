using UnityEngine;

public class Gem : Collectible
{
    public override void OnCollect()
    {
        Debug.Log("Gem Collected!");
        base.OnCollect();
    }
}
