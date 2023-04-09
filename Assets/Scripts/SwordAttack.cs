using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public float damage = 1;
    Vector2 rightAttackOffSet;
    
    private void Start()
    {
        rightAttackOffSet = transform.position;
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;

        transform.localPosition = rightAttackOffSet;
    }
    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(rightAttackOffSet.x * -1, rightAttackOffSet.y);

    }
    public void AttackUp()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(0, rightAttackOffSet.y * -1 - (float)0.1);

    }
    public void AttackDown()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(0, rightAttackOffSet.y * 3);

    }

    public void StopAttack()
    {
        swordCollider.enabled = false;

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") 
        {
            // Deal damage
            Enemy enemy = collision.GetComponent<Enemy>();

            if(enemy != null)
            {
                enemy.Health -= damage;
            }
        }
    }
}
