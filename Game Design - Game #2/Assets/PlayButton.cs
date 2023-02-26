using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public string SceneName;

    public void LoadScreen()
    {
        SceneManager.LoadScene(SceneName);
    }
}
