using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpImpulse = 5f;
    [SerializeField] GameObject targetJointBall;

    public ContactFilter2D groundFilter;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    Animator animator;

    private bool isGrounded => rb.IsTouching(groundFilter);
    private bool shouldJump;
    private string currentState;

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
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if (isGrounded) {
            ChangeAnimationState(PLAYER_RUN);  
        }
        
    }

    void OnJump()
    {
        if (isGrounded) {
            shouldJump = true;
        }
        
    }

    void OnFire()
    {
        targetJointBall.GetComponent<MouseTarget>().MoveToMousePosition();
    }

    private void Update()
    {
        //isGrounded = rb.IsTouching(groundFilter);

        if (moveInput.Equals(Vector2.zero) && isGrounded)
        {
            ChangeAnimationState(PLAYER_IDLE);
        }
        else
        {
            transform.localScale = new Vector2(Mathf.Sign(moveInput.x), transform.localScale.y);
        }
    }

    void FixedUpdate()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        if (isGrounded && shouldJump) {
            rb.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
            ChangeAnimationState(PLAYER_JUMP);
            shouldJump = false;
        }         
    }

    void ChangeAnimationState(string newState)
    {
        //Stoppa samma animation från att avbryta sig själv
        if (currentState == newState) return;

        //Spela animationen
        animator.Play(newState);

        //Uppdatera den nuvarande animationen
        currentState = newState;
    }

}
