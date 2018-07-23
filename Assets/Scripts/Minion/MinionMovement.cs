using UnityEngine;
using System.Collections;

public class MinionMovement : EntityMovement
{
    protected override void Awake()
    {
        base.Awake();
        this.defaultTarget = GameObject.FindGameObjectWithTag("EnemyPylon").transform;
        this.entityAttack = this.gameObject.GetComponent<MinionAttack>();
    }
}
