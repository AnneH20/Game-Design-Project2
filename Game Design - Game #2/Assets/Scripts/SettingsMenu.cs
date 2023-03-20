using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public float volumeValue;
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }
    private void Update()
    {
        mainMixer.SetFloat("Volume", volumeValue);
        PlayerPrefs.SetFloat("Volume", volumeValue);
    }

    public void SetVolume(float volume)
    {
        volumeValue = volume;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
