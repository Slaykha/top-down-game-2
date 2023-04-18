using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{

    public float damage = 1;
    public float knockbackForce = 250f;

    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collision = col.collider;
        IDamagable damageable = col.collider.GetComponent<IDamagable>();

        if(damageable != null && col.collider.tag == "Player")
        {
            print(transform.position);
            print(collision.transform.position);
            Vector2 direction = (collision.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;

            damageable.OnHit(damage, knockback);
        }
    }
}
