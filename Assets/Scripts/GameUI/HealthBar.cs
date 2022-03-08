using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;

    private void Awake() 
    {
        slider = GetComponent<Slider>();
    }

    public void InitHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void UpdateHealth(int health)
    {
        slider.value = health;
    }
}
