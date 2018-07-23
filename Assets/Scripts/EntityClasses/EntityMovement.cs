using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EntityMovement : MonoBehaviour
{

    private Transform target;
    private NavMeshAgent nav;
    private float rotationSpeed = 10f;

    protected Transform defaultTarget { get; set; }
    protected EntityAttack entityAttack { get; set; }

    // Use this for initialization
    protected virtual void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (this.entityAttack.HasTargetToAttack && this.entityAttack.Entity != null)
        {
            this.target = this.entityAttack.Entity.transform;
        }
        else
        {
            this.target = this.defaultTarget;
        }

        if (this.entityAttack.IsInAutoAttackRange)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            nav.SetDestination(target.position);
        }
    }
}
