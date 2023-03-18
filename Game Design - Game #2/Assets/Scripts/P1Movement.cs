using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator P1animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Player 1 Horizontal") * runSpeed;

        P1animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Player 1 Jump"))
        {
            jump = true;
            P1animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Player 1 Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Player 1 Crouch"))
        {
            crouch = false;
        }

    }

    public void OnLanding()
    {
        P1animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        P1animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}