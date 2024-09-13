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
    public void SiwtchPauseOrPlay()
    {
        if (Time.timeScale == 1)
        {
            PauseAnimationAndRenameButton(0, "Play");
        }
        else
        {
            PauseAnimationAndRenameButton(1, "Pause");
        }
    }
    private void PauseAnimationAndRenameButton(int timeScale, string buttonTitle)
    {
        Time.timeScale = timeScale;
        _buttonTitle.text = buttonTitle;
    }
}
