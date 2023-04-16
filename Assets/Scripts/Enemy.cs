using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{

    public float damage = 1;

    void OnCollisionEnter2D(Collision2D col)
    {
    IDamagable damageable = col.collider.GetComponent<IDamagable>();

        if(damageable != null)
        {
            damageable.OnHit(damage);
        }
    }
}
