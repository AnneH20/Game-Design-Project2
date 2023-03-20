using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class p1select_indicator : MonoBehaviour
{
    public bool p1selected = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-2.6f, 1.6f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (Input.GetKeyDown(KeyCode.A) && !p1selected)
            transform.position = new Vector3(-2.6f, 1.6f, 0f);
        if (Input.GetKeyDown(KeyCode.D) && !p1selected)
            transform.position = new Vector3(2.6f, 1.6f, 0f);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (p1selected)
            {
                spriteRenderer.color = Color.white;
                p1selected = false;
            }
            else
            {
                spriteRenderer.color = Color.yellow;
                p1selected = true;

                p2select_indicator p2indicator = GameObject.Find("p2select").GetComponent<p2select_indicator>();
                if (p2indicator.p2selected)
                    SceneManager.LoadScene("PlayGame");
            }
        }
    }
}
