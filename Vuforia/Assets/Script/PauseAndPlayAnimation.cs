using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseAndPlayAnimation : MonoBehaviour
{
    private TextMeshProUGUI _buttonTitle;
    private void Start()
    {
        _buttonTitle = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void SiwtchPauseOrPlay()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0f;
            _buttonTitle.text = "Play";
        }
        else
        {
            Time.timeScale = 1f;
            _buttonTitle.text = "Pause";
        }
    }
}
