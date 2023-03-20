using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenuScreen;

    public void Pause()
    {
        PauseMenuScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PauseMenuScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HomeScreen");
    }
}
