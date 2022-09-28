using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Projectile")
        {
            TakeDamage(5);
        }
        if (collision.collider.tag == "BazookaProjectile")
        {
            TakeDamage(90);
        }

        if (currentHealth <= 0)

        {
            gameObject.GetComponent<MovementAndCamera>().enabled = false;
            
        }
        
    }
}