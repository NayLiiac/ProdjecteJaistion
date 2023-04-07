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

    //On définit une période de temps qui représente la nuit, et une le jour, et en fonction de cela, on fait spawn un villager au début du jour

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


    /*On crée les méthodes permettant de calculer l'heure qu'il est selon les paramètres définis, ici le cycleLength
     qui représente la durée d'une journée totale, soit un cycle. Pour trouver l'heure à laquelle cela correspond selon notre cycleLength, 
    on utilise un modulo*/
    private void UpdateTimeOne()
    {
        timeOfDay = (timeOfDay + Time.deltaTime) % cycleLength;
        roundedTimeOfDay = Mathf.RoundToInt(timeOfDay);
    }

    //Cette deuxième méthode est la même mais fait passer le temps deux fois plus rapidement, par exemple pour passer la nuit plus vite
    private void UpdateTimeTwo()
    {
        timeOfDay = (timeOfDay + Time.deltaTime * 2) % cycleLength;
        roundedTimeOfDay = Mathf.RoundToInt(timeOfDay);
    }

    //Cette fonction définit quelle méthode est utilisée pour le passage du temps, soit en normal soit en *2
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
