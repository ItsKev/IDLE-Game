using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAttack : EntityAttack
{
    protected override void Awake()
    {
        base.Awake();
        this.attackDamage = 10f;
        this.EntityToAttack = "Monster";
    }
}