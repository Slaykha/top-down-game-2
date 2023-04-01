using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffSet = 0.01f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rBody;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate(){
        if(movementInput != Vector2.zero){
            bool success = TryMove(movementInput);

            if (!success && movementInput.x != 0)
            {
                success = TryMove(new Vector2(movementInput.x, 0));

            }

            if (!success && movementInput.y != 0)
            {
                TryMove(new Vector2(0, movementInput.y));
            }

            animator.SetFloat("moveX", movementInput.x);
            animator.SetFloat("moveY", movementInput.y);
            animator.SetBool("isMoving", success);
        }
        else
        {
            animator.SetFloat("moveX", movementInput.x);
            animator.SetFloat("moveY", movementInput.y);
            animator.SetBool("isMoving", false);
        }

        spriteRenderer.flipX = false;
        if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
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
}
