using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealth : MonoBehaviour {

    [SerializeField]
    private float startingHealth = 100;
    [SerializeField]
    private float currentHealth;

    public bool isDead { get; private set; }

    [SerializeField]
    private Image healthBar;

	// Use this for initialization
    private void Awake ()
	{
	    this.isDead = false;
        this.currentHealth = this.startingHealth;
	}
	

    public void TakeDamage(float amount)
    {
        this.currentHealth -= amount;
       
        this.healthBar.fillAmount = this.currentHealth / this.startingHealth;

        if (this.currentHealth <= 0)
        {
            this.isDead = true;
            Destroy(this.gameObject);
        }
    }
}
