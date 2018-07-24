using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealth : MonoBehaviour {

    [SerializeField]
    protected float startingHealth = 100;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private Image healthBar;

    public event EventHandler EntityDied;

    protected virtual void Awake ()
	{
        this.currentHealth = this.startingHealth;
	}
	

    public void TakeDamage(float amount)
    {
        this.currentHealth -= amount;
       
        this.healthBar.fillAmount = this.currentHealth / this.startingHealth;

        if (this.currentHealth <= 0)
        {
            this.OnEntityDied(new EventArgs());
            Destroy(this.gameObject);
        }
    }

    protected void OnEntityDied(EventArgs eventArgs)
    {
        var handler = EntityDied;
        if (handler != null)
        {
            handler(this, eventArgs);
        }
    }
}
