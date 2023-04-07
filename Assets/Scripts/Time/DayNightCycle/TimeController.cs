using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class TimeController : MonoBehaviour
{
    public float timeOfDay;
    public int roundedTimeOfDay;

    public float cycleLength = 24f;
    public Speed2Time speed;
    public bool isNightTime;
    public int morning = 8;
    public int night = 20;

    public SpawnVillagers spawnVillager;
    public bool villagerHasSpawned = false;

    private void Update()
    {

        if (roundedTimeOfDay < morning || roundedTimeOfDay > night)
        {
            isNightTime = true;
            villagerHasSpawned = false;
        }

        if (roundedTimeOfDay == 8.0 && !villagerHasSpawned)
        {

            spawnVillager.VillagersSpawn();
            villagerHasSpawned= true;
            isNightTime = false;
            VillagerManager.instance.DayTime();
        }

    }



    private void UpdateTimeOne()
    {
        timeOfDay = (timeOfDay + Time.deltaTime) % cycleLength;
        roundedTimeOfDay = Mathf.RoundToInt(timeOfDay);
    }

    private void UpdateTimeTwo()
    {
        timeOfDay = (timeOfDay + Time.deltaTime * 2) % cycleLength;
        roundedTimeOfDay = Mathf.RoundToInt(timeOfDay);
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
