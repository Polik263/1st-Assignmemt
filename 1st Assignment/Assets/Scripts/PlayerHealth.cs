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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(20);
        }
    }
}
