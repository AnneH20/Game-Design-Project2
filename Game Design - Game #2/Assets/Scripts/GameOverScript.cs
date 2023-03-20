using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject player1;
    public GameObject player2;
    public GameObject timer;
    public GameObject PauseMenuScreen;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
 //       Cursor.visible = false;
 //        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else
        {
 //           Cursor.visible = false;
  //          Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        player1.SetActive(false);
        player2.SetActive(false);
        timer.SetActive(false);
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
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

    public void Pause()
    {
        PauseMenuScreen.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        PauseMenuScreen.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
