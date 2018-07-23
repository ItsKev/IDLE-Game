using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : EntityMovement
{
    protected override void Awake()
    {
        base.Awake();
        this.defaultTarget = GameObject.FindGameObjectWithTag("FriendlyPylon").transform;
        this.entityAttack = this.gameObject.GetComponent<MonsterAttack>();
    }
}