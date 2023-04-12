using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTime : MonoBehaviour
{
    public bool isPaused = false;

    //The time or the pause is defined depending on if the player launches the pause with the escape key
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            if (!isPaused)
            {
                Time.timeScale = 0.0f;
                isPaused = true;
            }

            else
            {
                Time.timeScale = 1.0f;
                isPaused = false;
            }
        }
    }
}
