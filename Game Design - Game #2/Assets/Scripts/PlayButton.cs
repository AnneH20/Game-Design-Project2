using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private AudioClip Click;
    public string SceneName;

    public void LoadScreen()
    {
        SoundManager.instance.PlaySound(Click);
        SceneManager.LoadScene(SceneName);
    }
}
