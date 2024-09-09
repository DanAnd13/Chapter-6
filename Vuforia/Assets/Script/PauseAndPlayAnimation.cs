using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseAndPlayAnimation : MonoBehaviour
{
    private TextMeshProUGUI ButtonTitle;
    private void Start()
    {
        ButtonTitle = GetComponentInChildren<TextMeshProUGUI>();
    }
    private bool IsPlaing()
    {
        if (ButtonTitle.text == "Pause")
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public void SiwtchPauseOrPlay(AudioSource Music)
    {
        if (IsPlaing())
        {
            Time.timeScale = 0f;
            Music.Pause();
            ButtonTitle.text = "Play";
        }
        else
        {
            Time.timeScale = 1f;
            Music.Play();
            ButtonTitle.text = "Pause";
        }
    }
}
