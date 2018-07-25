using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : EntityAttack
{
    protected override void Awake()
    {
        base.Awake();
        var scaler = EntityAttack.gameHandler.Scaler;
        this.attackDamage = scaler.MonsterAttackDamage;
        this.autoAttackRange = scaler.MonsterAttackRange;
        this.timeBetweenAttacks = 1 / scaler.MonsterAttackSpeed;
        this.EntityToAttack = new string[] { "Minion", "FriendlyPylon" };
    }
}