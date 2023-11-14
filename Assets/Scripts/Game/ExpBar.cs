using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
  [SerializeField] private Slider slider;

    public void UpdateExpBar(float currentValue, float maxValue)
    {
        slider.value=currentValue/maxValue;
    }
}
