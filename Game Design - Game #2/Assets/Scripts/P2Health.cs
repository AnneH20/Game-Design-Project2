using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class P2Health: MonoBehaviour
{
    public Slider P2slider;
    public Gradient P2gradient;
    public Image P2fill;

    public void P2SetMaxHealth(int health)
    {
        P2slider.maxValue = health;
        P2slider.value = health;

        P2fill.color = P2gradient.Evaluate(1f);
    }

    public void P2SetHeatlh(int health)
    {
        P2slider.value = health;
        P2fill.color = P2gradient.Evaluate(P2slider.normalizedValue);
    }
}

