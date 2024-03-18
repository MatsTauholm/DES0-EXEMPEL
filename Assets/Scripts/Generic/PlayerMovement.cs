using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpImpulse = 5f;

    public ContactFilter2D groundFilter;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private bool isGrounded => rb.IsTouching(groundFilter);
    private bool shouldJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetStartPos(float newPosX, float newPosY)
    {
        transform.position = new Vector3(newPosX,newPosY);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (isGrounded)
        shouldJump = true;
    }
    private void Update()
    {
        //isGrounded = rb.IsTouching(groundFilter);  
    }

    void FixedUpdate()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        if (isGrounded && shouldJump)
        {
            rb.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
            shouldJump = false;
        }         
    }

}
