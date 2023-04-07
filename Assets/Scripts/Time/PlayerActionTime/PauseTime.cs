using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTime : MonoBehaviour
{
    public bool isPaused = false;

    //Ce script sert � mettre le jeu en pause
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

    //Pour cela, on d�finit simplement si le temps passe ou pas

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

    //Le temps ou la pause est d�finie selon si le joueur lance la pause avec la touche escape

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
