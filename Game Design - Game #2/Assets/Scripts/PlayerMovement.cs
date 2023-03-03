using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body; //created a reference to the player rigidbody 2d

    private void Awake() //create Awake Method load when you load the script
    {
        body = GetComponent<Rigidbody2D>();   
    }


    private void Update() //constatly checks for updates like when the player presses left or right
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);

        //flip player when moving left-right
        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
         else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
