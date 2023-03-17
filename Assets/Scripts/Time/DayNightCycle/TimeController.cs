using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public float timeOfDay;
    public float cycleLength = 24f;
    public Speed2Time speed;

    private void Update()
    {
        
    }

    private void UpdateTimeOne()
    {
        timeOfDay = (timeOfDay + Time.deltaTime) % cycleLength;
    }

    private void UpdateTimeTwo()
    {
        timeOfDay = (timeOfDay + Time.deltaTime*2) % cycleLength;
    }

    public void UpdateTime()
    {
        if (speed.isTimeTwo)
        {
            UpdateTimeTwo();
        }

        else
        {
            UpdateTimeOne();
        }
    }

}
