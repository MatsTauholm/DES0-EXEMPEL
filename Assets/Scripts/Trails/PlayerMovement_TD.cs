using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_TD : MonoBehaviour
{
    //Variabler
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] Camera cam;

    Rigidbody2D rb;
    Vector2 moveInput;
    Vector2 mousePos;
    Vector2 smoothedMoveInput;
    Vector2 moveInputSmooth;

    float angle = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        //Här hämtar vi muspekarens Screenposition och omvandlar den till worldposition för att enklare veta vart musen är i förhållande till spelaren
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position; //Vector matte för att ta reda på riktningen spelaren ska rotera mot
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; //Här använder vi Atan2 för att få fram riktningens radian och därefter omvandla den till grader
    }

    void OnMove(InputValue value) //Om spelaren trycker på WASD
    {
        moveInput = value.Get<Vector2>(); //Lagra värdet i en vector2 för att veta vilket håll spelaren ska gå åt
    }
    void FixedUpdate()
    {
        //Smoothed movement
        smoothedMoveInput = Vector2.SmoothDamp(smoothedMoveInput, moveInput, ref moveInputSmooth, 0.01f);
        rb.velocity = smoothedMoveInput * moveSpeed; //Förflytta spelaren med hjälp av dess rigidbody

        //Roteration
        Vector2 lookDir = mousePos - rb.position; //Vector matte för att ta reda på riktningen spelaren ska rotera mot
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; //Här använder vi Atan2 för att få fram riktningens radian och därefter omvandla den till grader
        rb.rotation = angle; //Rotera spelarens rigidbody med hjälp av graderna vi fått fram
    }
}
