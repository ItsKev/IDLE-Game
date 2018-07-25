using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EntityMovement : MonoBehaviour
{
    protected static GameHandler gameHandler;

    private Transform target;
    private NavMeshAgent nav;
    private float rotationSpeed = 10f;

    protected Transform DefaultTarget { get; set; }
    protected EntityAttack EntityAttackObject { get; set; }

    protected virtual void Awake()
    {
        if (EntityMovement.gameHandler == null)
        {
            EntityMovement.gameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
        }

        this.nav = GetComponent<NavMeshAgent>();
    }
    
    private void FixedUpdate()
    {
        if (this.EntityAttackObject.AttackingEntity != null)
        {
            this.target = this.EntityAttackObject.AttackingEntity.transform;
            this.nav.speed = 3f;
        }
        else
        {
            this.target = this.DefaultTarget;
            this.nav.speed = 5f;
        }

        if (this.EntityAttackObject.IsInAutoAttackRange)
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
