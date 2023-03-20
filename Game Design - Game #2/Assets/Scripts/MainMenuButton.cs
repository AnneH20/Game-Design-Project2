using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private AudioClip Click;

    public void LoadScreen()
    {
        SoundManager.instance.PlaySound(Click);
        SceneManager.LoadScene("HomeScreen");
    }
}

