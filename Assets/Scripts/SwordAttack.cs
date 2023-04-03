using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Vector2 rightAttackOffSet;
    Collider2D swordCollider;
    
    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffSet = transform.position;
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;

        transform.position = rightAttackOffSet;
    }
    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.position = new Vector2(rightAttackOffSet.x * -1, rightAttackOffSet.y);

    }
    public void AttackUp()
    {
        swordCollider.enabled = true;
        transform.position = new Vector2(0, rightAttackOffSet.y * -2);

    }
    public void AttackDown()
    {
        swordCollider.enabled = true;
        transform.position = new Vector2(0, rightAttackOffSet.y * 2);

    }

    public void StopAttack()
    {
        swordCollider.enabled = false;

    }
}
