using System;
using UnityEngine;
using System.Collections;

public class EntityAttack : MonoBehaviour
{
    protected float timeBetweenAttacks = 0.5f;
    protected float attackDamage = 5f;
    protected float autoAttackRange = 3f;

    private EntityHealth attackingEntity;
    private float attackTimer;

    public EntityHealth AttackingEntity
    {
        get { return this.attackingEntity; }
        set
        {
            this.attackingEntity = value;
            this.HasTargetToAttack = true;
        }
    }

    public bool HasTargetToAttack { get; set; }

    public bool IsInAutoAttackRange { get; private set; }

    protected string[] EntityToAttack { get; set; }

    protected virtual void Awake()
    {
        var entityHealth = this.gameObject.GetComponent<EntityHealth>();
        entityHealth.EntityDied += this.OnEntityDeath;
    }

    private void FixedUpdate()
    {
        if (!this.HasTargetToAttack) return;
        this.attackTimer += Time.deltaTime;
        if (this.attackTimer >= timeBetweenAttacks)
        {
            if (this.AttackingEntity == null)
            {
                this.HasTargetToAttack = false;
                this.IsInAutoAttackRange = false;
            }
            else
            {
                this.CheckIfInAutoAttackRange();
                if (this.IsInAutoAttackRange)
                {
                    this.attackTimer = 0f;
                    this.AttackingEntity.TakeDamage(this.attackDamage);
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
        foreach (var entityName in this.EntityToAttack)
        {
            if (other.CompareTag(entityName))
            {
                this.AttackingEntity = other.GetComponent<EntityHealth>();
                this.AttackingEntity.EntityDied += OnEntityDeath;
                break;
            }
        }
    }

    private void CheckIfInAutoAttackRange()
    {
        var distance = Vector3.Distance(this.gameObject.transform.position, this.AttackingEntity.transform.position);
        if (distance <= this.autoAttackRange)
        {
            this.IsInAutoAttackRange = true;
        }
        else
        {
            this.IsInAutoAttackRange = false;
        }
    }

    private void OnEntityDeath(object sender, EventArgs e)
    {
        this.AttackingEntity = null;
        this.IsInAutoAttackRange = false;
    }
}