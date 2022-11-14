using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator aniator;
    public int maxHealth = 100; // có the thay doi ? giao dien 
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) // nhan dmg
    {
        currentHealth -= damage;

        // play hurt animation
        aniator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        aniator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false; // vo hieu collider2d
        this.enabled = false; // vo hieu scrip enemy
    }


}

