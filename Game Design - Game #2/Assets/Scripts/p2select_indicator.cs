using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class p2select_indicator : MonoBehaviour
{
    public bool p2selected = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(4f, -2.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !p2selected)
            transform.position = new Vector3(4f, -2.5f, 0f);
        if (Input.GetKeyDown(KeyCode.RightArrow) && !p2selected)
            transform.position = new Vector3(-4f, -2.5f, 0f);

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (p2selected)
            {
                spriteRenderer.color = Color.white;
                p2selected = false;
            }
            else
            {
                spriteRenderer.color = Color.yellow;
                p2selected = true;

                p1select_indicator p1indicator = GameObject.Find("p1select").GetComponent<p1select_indicator>();
                if (p1indicator.p1selected)
                    SceneManager.LoadScene("PlayGame");
            }
        }
    }
}
