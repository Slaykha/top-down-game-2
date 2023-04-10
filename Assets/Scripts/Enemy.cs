using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour, IDamagable
{
    public float health = 3;
    Rigidbody2D rb;

    Animator animator;
    public float Health
    {
        set
        {
            animator.SetBool("isAlive", true);

            if (value < health)
            {
                animator.SetTrigger("hit");
            }

            health = value;

            if(health <= 0)
            {
                animator.SetBool("isAlive", false);
                animator.SetTrigger("Defeated");
            }
        }
        get
        {
            return health;
        }
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;

        rb.AddForce(knockback);
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }
}
