using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public P1Enemy P1;
    public P2Enemy P2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            Debug.Log("Player 1 fell off");
            P1.outOfBounds();

        }
        if (other.CompareTag("Player2"))
        {
            Debug.Log("Player 2 fell off");
            P2.outOfBounds();
        }
    }
          
}
