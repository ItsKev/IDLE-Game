using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : EntityMovement
{
    protected override void Awake()
    {
        base.Awake();
        this.DefaultTarget = GameObject.FindGameObjectWithTag("FriendlyPylon").transform;
        this.EntityAttackObject = this.gameObject.GetComponent<MonsterAttack>();
    }
}