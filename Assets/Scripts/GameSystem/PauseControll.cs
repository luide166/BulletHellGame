using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControll : MonoBehaviour
{
    float previousTimeScale = 1;
    public GameObject pausePanel;

    public static bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            SpeedUp();
        }
    }

    public void TogglePause()
    {
        if(Time.timeScale > 0)
        {
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            AudioListener.pause = true;
            pausePanel.active = true;

            isPaused = true;
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = previousTimeScale;
            AudioListener.pause = false;
            pausePanel.active = false;

            isPaused = false;
        }
    }

    public void SpeedUp()
    {
        Time.timeScale *= 1.5f;
    }
}
