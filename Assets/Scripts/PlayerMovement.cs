using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] ContactFilter2D groundFilter;

    Rigidbody2D rb;
    Animator ani;
    MouseTarget mouseTarget;
    Collider2D bodyColl;
    Collider2D feetColl;
    ParticleSystem dust;

    Vector2 moveInput;
    bool shouldJump;
    bool isGrounded;

    //Animation states
    const string PLAYER_RUN = "isRunning";
    const string PLAYER_JUMP = "isJumping";


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        mouseTarget = GameObject.FindObjectOfType<MouseTarget>();
        dust = GetComponentInChildren<ParticleSystem>(); 
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if (moveInput != Vector2.zero && isGrounded)
        {
            ani.SetBool(PLAYER_RUN, true);
        }
        else
        {
            ani.SetBool(PLAYER_RUN, false);
        }
        
    }

    void OnJump()
    {
        if (isGrounded)
        shouldJump = true;
    }

    void OnFire()
    {
        if(mouseTarget != null)
        mouseTarget.MoveToMousePosition();
    }

    void Update()
    {
        if (isGrounded)
        {
            ani.SetBool(PLAYER_JUMP, false);
        }
    }

    void FixedUpdate()
    {
        isGrounded = rb.IsTouching(groundFilter);
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        //Mirror the sprite if moving left
        if (moveInput.x != 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(moveInput.x), transform.localScale.y);
        }
        
        //Jump function
        if (isGrounded && shouldJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            ani.SetBool(PLAYER_JUMP, true);
            isGrounded = false;
            shouldJump = false;
            //dust.Play(); //Play particle effect
        }

     
    }
}
