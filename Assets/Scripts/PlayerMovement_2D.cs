using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_2D : MonoBehaviour
{   
    public float speedMultiplier = 5.0f;
    public Rigidbody2D rigidBody;
    public Animator animator;
    protected Vector2 moveDirection;
    protected float moveSpeed;
    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveSpeed = Mathf.Clamp(moveDirection.magnitude, 0.0f, 1.0f);
        moveDirection.Normalize();
        Move();
        AnimateMovement();

        //Sets the idle to the last direction moved
        if (Input.GetAxis("Horizontal") >= 0.1f || Input.GetAxis("Horizontal") <= -0.1f || Input.GetAxis("Vertical") >= 0.1f || Input.GetAxis("Vertical") <= -0.1f)
        {
            animator.SetFloat("LastMoveX", Input.GetAxis("Horizontal"));
            animator.SetFloat("LastMoveY", Input.GetAxis("Vertical"));
        }
    }
    void Move()
    {
        rigidBody.velocity = moveDirection * moveSpeed * speedMultiplier;
    }

    void AnimateMovement()
    {
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveSpeed);
    }

}
