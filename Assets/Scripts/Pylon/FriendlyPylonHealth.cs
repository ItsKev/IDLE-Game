using UnityEngine;
using System.Collections;

public class FriendlyPylonHealth : EntityHealth
{
    protected override void Awake()
    {
        base.Awake();
        var scaler = EntityHealth.gameHandler.Scaler;
        this.startingHealth = scaler.FriendlyPylonHealth;
    }
}
