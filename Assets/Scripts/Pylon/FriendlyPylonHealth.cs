using UnityEngine;
using System.Collections;

public class FriendlyPylonHealth : EntityHealth
{
    protected override void Awake()
    {
        this.startingHealth = 200f;
        base.Awake();
    }
}
