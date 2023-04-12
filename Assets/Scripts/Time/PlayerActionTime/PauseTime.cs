using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTime : MonoBehaviour
{
    public bool isPaused = false;

    //This script is used to pause the game
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

    //To do this, we simply define if the time passes or not.

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

    //The time or the pause is defined depending on if the player launches the pause with the escape key

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
