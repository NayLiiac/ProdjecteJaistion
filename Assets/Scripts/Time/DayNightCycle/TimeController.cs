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

    public SpawnVillagers spawnVillager;

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

        if (timeOfDay > 7.9 && timeOfDay < 8.1)
        {

            spawnVillager.VillagersSpawn();

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
