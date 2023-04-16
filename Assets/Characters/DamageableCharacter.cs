using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DamageableCharacter : MonoBehaviour, IDamagable
{
    public bool disableSimulation = false;
    public float health = 3;
    public bool _targatable = true;
    Rigidbody2D rb;

    Animator animator;

    Collider2D physicsCollider;
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

            if (health <= 0)
            {
                animator.SetBool("isAlive", false);
                Targetable = false;
            }
        }
        get
        {
            return health;
        }
    }

    public bool Targetable { get { return _targatable; } 
        set {
            _targatable = value;

            if (disableSimulation)
            {
                rb.simulated = false;
            }

            physicsCollider.enabled = value;
        } 
    }

    public void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("isAlive", true);

        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
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

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }
}
