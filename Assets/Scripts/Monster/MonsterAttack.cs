using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : EntityAttack
{
    protected override void Awake()
    {
        base.Awake();
        this.attackDamage = 1f;
        this.EntityToAttack = "Minion";
    }
}