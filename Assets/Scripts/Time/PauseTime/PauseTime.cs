using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTime : MonoBehaviour
{
    public bool isPaused = false;

    private void TogglePause()
    {
        if (isPaused)
        {
            Pause();
        }

        else
        {
            Resume();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
        
    }

    private void Resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            if (!isPaused)
            {
                Pause();
            }

            else
            {
                Resume();
            }


        }
    }




}
