using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 3;

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
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
