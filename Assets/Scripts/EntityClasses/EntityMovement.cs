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
        this.nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (this.entityAttack.AttackingEntity != null)
        {
            this.target = this.entityAttack.AttackingEntity.transform;
            this.nav.speed = 3f;
        }
        else
        {
            this.target = this.defaultTarget;
            this.nav.speed = 5f;
        }

        if (this.entityAttack.IsInAutoAttackRange)
        {
            this.nav.isStopped = true;
            var direction = (target.position - transform.position).normalized;
            var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            this.nav.isStopped = false;
            if (target != null)
            {
                nav.SetDestination(target.position);
            }
        }
    }
}
