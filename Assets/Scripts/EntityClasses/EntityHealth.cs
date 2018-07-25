using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealth : MonoBehaviour {

    protected static GameHandler gameHandler;

    [SerializeField]
    protected float startingHealth = 100;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private Image healthBar;

    public event EventHandler EntityDied;

    protected virtual void Awake ()
	{
	    if (EntityHealth.gameHandler == null)
	    {
	        EntityHealth.gameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
	    }
	}

    private void Start()
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
