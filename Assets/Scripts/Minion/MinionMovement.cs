using UnityEngine;
using System.Collections;

public class MinionMovement : EntityMovement
{
    protected override void Awake()
    {
        base.Awake();
        this.DefaultTarget = GameObject.FindGameObjectWithTag("EnemyPylon").transform;
        this.EntityAttackObject = this.gameObject.GetComponent<MinionAttack>();
    }
}
