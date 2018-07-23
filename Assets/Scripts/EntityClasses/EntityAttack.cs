using UnityEngine;
using System.Collections;

public class EntityAttack : MonoBehaviour
{
    [SerializeField] protected float timeBetweenAttacks = 0.5f;
    [SerializeField] protected float attackDamage = 5f;
    [SerializeField] protected float autoAttackRange = 2f;

    private GameObject entity;
    private float attackTimer;
    private EntityHealth health;

    public GameObject Entity
    {
        get { return this.entity; }
        set
        {
            this.entity = value;
            this.HasTargetToAttack = true;
        }
    }

    public bool HasTargetToAttack { get; set; }

    public bool IsInAutoAttackRange { get; private set; }

    protected string EntityToAttack { get; set; }

    protected virtual void Awake()
    {
        this.IsInAutoAttackRange = false;
        this.health = this.gameObject.GetComponent<EntityHealth>();
    }

    private void FixedUpdate()
    {
        if (!this.HasTargetToAttack) return;
        this.attackTimer += Time.deltaTime;
        if (this.attackTimer >= timeBetweenAttacks)
        {
            if (this.entity == null || this.health.isDead)
            {
                this.HasTargetToAttack = false;
                this.IsInAutoAttackRange = false;
            }
            else
            {
                this.CheckIfInAutoAttackRange();
                if (this.IsInAutoAttackRange)
                {
                    var entityHealth = this.entity.GetComponent<EntityHealth>();
                    this.attackTimer = 0f;
                    if (!entityHealth.isDead)
                    {
                        entityHealth.TakeDamage(attackDamage);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        this.AttackIfAbleTo(other);
    }

    private void OnTriggerStay(Collider other)
    {
        this.AttackIfAbleTo(other);
    }

    private void AttackIfAbleTo(Collider other)
    {
        if (this.HasTargetToAttack) return;
        if (other.CompareTag(this.EntityToAttack))
        {
            var entityHealth = other.GetComponent<EntityHealth>();
            if (!entityHealth.isDead)
            {
                this.Entity = other.gameObject;
            }
        }
    }

    private void CheckIfInAutoAttackRange()
    {
        var distance = Vector3.Distance(this.gameObject.transform.position, this.entity.transform.position);
        if (distance <= this.autoAttackRange)
        {
            this.IsInAutoAttackRange = true;
        }
        else
        {
            this.IsInAutoAttackRange = false;
        }
    }
}