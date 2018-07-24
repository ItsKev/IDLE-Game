using UnityEngine;
using System.Collections;

public class MonsterHealth : EntityHealth
{
    protected override void Awake()
    {
        this.startingHealth = 100;
        base.Awake();
    }
}
