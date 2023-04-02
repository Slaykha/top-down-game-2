using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public enum AttackDirection
    {
        left,right,up,down
    }

    public AttackDirection attackDirection;

    Vector2 rightAttackOffSet;
    Collider2D swordCollider;
    
    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffSet = transform.position;
    }

   /* public void Attack()
    {
        switch (attackDirection)
        {
            case AttackDirection.left:  AttackLeft();   break;
            case AttackDirection.right: AttackRight();  break;
            case AttackDirection.up:    AttackUp();     break;
            case AttackDirection.down:  AttackDown();   break;
        }
    }*/

    public void AttackRight()
    {
        print("right");

        swordCollider.enabled = true;

        transform.position = rightAttackOffSet;
    }
    public void AttackLeft()
    {
        print("left");
        swordCollider.enabled = true;
        transform.position = new Vector2(rightAttackOffSet.x * -1, rightAttackOffSet.y);

    }
    public void AttackUp()
    {
        print("up");
        swordCollider.enabled = true;
        transform.position = new Vector2(0, rightAttackOffSet.y * -2);

    }
    public void AttackDown()
    {
        print("down");

        swordCollider.enabled = true;
        transform.position = new Vector2(0, rightAttackOffSet.y * 2);

    }

    public void StopAttack()
    {
        swordCollider.enabled = false;

    }
}
