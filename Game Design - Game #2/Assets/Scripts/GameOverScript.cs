using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject player1;
    public GameObject player2;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        player1.SetActive(false);
        player2.SetActive(false);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("HomeScreen");
        Debug.Log("Main Menu");
    }

    public void rematch()
    {
        SceneManager.LoadScene("PlayGame");
        Debug.Log("Rematch");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
