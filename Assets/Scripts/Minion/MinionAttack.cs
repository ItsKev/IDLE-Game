using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAttack : EntityAttack
{
    protected override void Awake()
    {
        base.Awake();
        var scaler = EntityAttack.gameHandler.Scaler;
        this.attackDamage = scaler.MinionAttackDamage;
        this.autoAttackRange = scaler.MinionAttackRange;
        this.timeBetweenAttacks = 1 / scaler.MinionAttackSpeed;
        this.EntityToAttack = new string[] {"Monster", "EnemyPylon"};
    }
}