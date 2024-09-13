using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseAndPlayAnimation : MonoBehaviour
{
    private TextMeshProUGUI _buttonTitle;

    private void Awake()
    {
        _buttonTitle = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void SwitchPauseOrPlay()
    {
        if (Time.timeScale == 1)
        {
            PauseAnimationAndRenamingButton(0, "Play");
        }
        else
        {
            PauseAnimationAndRenamingButton(1, "Pause");
        }
    }
    private void PauseAnimationAndRenamingButton(int timeScale, string buttonTitle)
    {
        Time.timeScale = timeScale;
        _buttonTitle.text = buttonTitle;
    }
}
