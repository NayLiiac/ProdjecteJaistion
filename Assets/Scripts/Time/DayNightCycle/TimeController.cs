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

    //On d�finit une p�riode de temps qui repr�sente la nuit, et une le jour, et en fonction de cela, on fait spawn un villager au d�but du jour

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


    /*On cr�e les m�thodes permettant de calculer l'heure qu'il est selon les param�tres d�finis, ici le cycleLength
     qui repr�sente la dur�e d'une journ�e totale, soit un cycle. Pour trouver l'heure � laquelle cela correspond selon notre cycleLength, 
    on utilise un modulo*/
    private void UpdateTimeOne()
    {
        timeOfDay = (timeOfDay + Time.deltaTime) % cycleLength;
        roundedTimeOfDay = Mathf.RoundToInt(timeOfDay);
    }

    //Cette deuxi�me m�thode est la m�me mais fait passer le temps deux fois plus rapidement, par exemple pour passer la nuit plus vite
    private void UpdateTimeTwo()
    {
        timeOfDay = (timeOfDay + Time.deltaTime * 2) % cycleLength;
        roundedTimeOfDay = Mathf.RoundToInt(timeOfDay);
    }

    //Cette fonction d�finit quelle m�thode est utilis�e pour le passage du temps, soit en normal soit en *2
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
