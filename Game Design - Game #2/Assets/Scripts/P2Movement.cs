using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator P2animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Player 2 Horizontal") * runSpeed;

        P2animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Player 2 Jump"))
        {
            jump = true;
            P2animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Player 2 Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Player 2 Crouch"))
        {
            crouch = false;
        }

    }

    public void OnLanding()
    {
        P2animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        P2animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
