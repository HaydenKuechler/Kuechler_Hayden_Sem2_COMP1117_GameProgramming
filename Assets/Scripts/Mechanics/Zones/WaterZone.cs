using UnityEngine;

public class WaterZone : Zone
{
    [SerializeField] private float speedModifier = 0.5f;
    protected override void ApplyZoneEffect(Player player)
    {
        //reduce my players speed modifier 
        player.ApplySpeedModifier(speedModifier);
    }
}
