using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public SwordAttack swordAttack;

    public float moveSpeed = 1f;
    public float collisionOffSet = 0.01f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rBody;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;
    private float lastX = 0;
    private float lastY = 0;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate(){
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (!success && movementInput.x != 0)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));

                }

                if (!success && movementInput.y != 0)
                {
                    TryMove(new Vector2(0, movementInput.y));
                }

                animator.SetFloat("posX", movementInput.x);
                animator.SetFloat("posY", movementInput.y);
                animator.SetBool("isMoving", success);
                lastX = movementInput.x;
                lastY = movementInput.y;
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

        }
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction == Vector2.zero) { return false; }
        int count = rBody.Cast(direction, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffSet);

        if (count == 0)
        {
            rBody.MovePosition(rBody.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        return false;
    }

    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    public void SwordAttack()
    {
        LockMovement();
        if (lastX > 0)
        {
            swordAttack.AttackRight();
        }
        else if(lastX < 0) 
        {
            swordAttack.AttackLeft();
        }
        else if (lastY > 0)
        {
            swordAttack.AttackUp();
        }
        else if(lastY < 0)
        {
            swordAttack.AttackDown();
        }
    }

    public void EndSwordAttack()
    {
        UnlockMovement();
        swordAttack.StopAttack();
    }

    public void LockMovement()
    {
        canMove= false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
