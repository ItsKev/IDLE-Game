using UnityEngine;
using System.Collections;

public class MinionHealth : EntityHealth
{
    protected override void Awake()
    {
        this.startingHealth = 50;
        base.Awake();
    }
}
