using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class TimeController : MonoBehaviour
{
    public float timeOfDay;
    public int roundedTimeOfDay;

    public float cycleLength = 48f;
    public Speed2Time speed;
    public bool isNightTime;
    public int morning = 8;
    public int night = 35;
    public int timeSpeed = 1;

    public SpawnVillagers spawnVillager;
    public bool villagerHasSpawned = false;

    public GetWoodRessource WoodCollector;
    public GetStoneRessource StoneCollector;
    public GetFoodRessource FoodCollector;
    public int resourceCollectTimer = 4;

    void Start()
    {
        VillagerManager.instance.DayTime();
    }
    void Update()
    {
        // Activates at night
        if ((roundedTimeOfDay < morning || roundedTimeOfDay > night) && isNightTime == false)
        {
            isNightTime = true;
            villagerHasSpawned = false;
            VillagerManager.instance.NightTime();

            WoodCollector.isHarvesting = false;
            StoneCollector.isHarvesting = false;
            FoodCollector.isHarvesting = false;

        }

        // Activates at day
        if ((roundedTimeOfDay == 8.0 && !villagerHasSpawned) && isNightTime == true)
        {
            spawnVillager.VillagersSpawn();
            villagerHasSpawned= true;
            isNightTime = false;
            VillagerManager.instance.DayTime();
        }

    }


    // Calculates the time of day at normal speed, using unity's internal clock
    private void UpdateTimeOne()
    {
        timeOfDay = (timeOfDay + Time.deltaTime) % cycleLength;
        roundedTimeOfDay = Mathf.RoundToInt(timeOfDay);
    }

    //Calculates the time of day at twice the speed, using unity's internal clock
    private void UpdateTimeTwo()
    {
        timeOfDay = (timeOfDay + Time.deltaTime * 2) % cycleLength;
        roundedTimeOfDay = Mathf.RoundToInt(timeOfDay);
    }

    //Checks which time to use
    public void UpdateTime()
    {
        if (speed.isTimeTwo)
        {
            UpdateTimeTwo();
            timeSpeed = 2;

            WoodCollector.waitResource = resourceCollectTimer /  2;
            StoneCollector.waitResource = resourceCollectTimer / 2;
            FoodCollector.waitResource = resourceCollectTimer / 2;

            VillagerManager.instance.ChangeVillagerSpeed(8);
        }

        else
        {
            UpdateTimeOne();
            timeSpeed = 1;

            WoodCollector.waitResource = resourceCollectTimer;
            StoneCollector.waitResource = resourceCollectTimer;
            FoodCollector.waitResource = resourceCollectTimer;

            VillagerManager.instance.ChangeVillagerSpeed(4);
        }
    }

}
