using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public float timeOfDay;
    public float cycleLength = 24f;
    public Speed2Time speed;
    public bool isNightTime;
    public int morning = 8;
    public int night = 20;

    private void Update()
    {
        if (timeOfDay < morning || timeOfDay > night)
        {
            isNightTime = true;
        }
        else
        {
            isNightTime= false;
        }

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
