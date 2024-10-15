using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpImpulse = 5f;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    Animator animator;
    MouseTarget mouseTarget;
    private bool shouldJump;
    private string currentState;

    Collider2D bodyColl;
    Collider2D feetColl;

    //Animation states
    const string PLAYER_IDLE = "P_Idle";
    const string PLAYER_RUN = "P_Run";
    const string PLAYER_ATTACK = "P_Attack";
    const string PLAYER_DEAD = "P_Dead";
    const string PLAYER_JUMP = "P_Jump";


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mouseTarget = GameObject.FindObjectOfType<MouseTarget>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if (isGrounded)
        ChangeAnimationState(PLAYER_RUN);
    }

    void OnJump()
    {
        if (isGrounded)
        shouldJump = true;
    }

    void OnFire()
    {
        mouseTarget.MoveToMousePosition();
    }




    private void Update()
    { 
        if (moveInput.Equals(Vector2.zero) && isGrounded)
        {
            ChangeAnimationState(PLAYER_IDLE);
        }
    }

    void FixedUpdate()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        //Mirror the sprite if moving left
        if (moveInput.x != 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(moveInput.x), transform.localScale.y);
        }
        
        //Jump function
        if (isGrounded() && shouldJump)
        {
            rb.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
            ChangeAnimationState(PLAYER_JUMP);
            shouldJump = false;
        }         
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void ChangeAnimationState(string newState)
    {
        //Stop the same animation from over writhing it self
        if (currentState == newState) return;

        //Play animation
        animator.Play(newState);

        //Update current animation
        currentState = newState;
    }

}
