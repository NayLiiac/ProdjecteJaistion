using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Speed2Time : MonoBehaviour
{
    public bool isTimeTwo = false;

    // When the player presses the Space bar, it will double up the speed of the game
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isTimeTwo)
            {
                isTimeTwo = true;
            }

            else
            {
                isTimeTwo = false;
            }
        }
    }
}
