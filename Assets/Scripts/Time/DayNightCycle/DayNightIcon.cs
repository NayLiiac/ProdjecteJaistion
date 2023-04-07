using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightIcon : MonoBehaviour
{
    [SerializeField] private TimeController time;
    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject moon;

    //Ce script sert � d�finir quelle ic�ne est affich�e en fonction de la p�riode d�finie (nuit ou jour) dans le TimeController
    private void Update()
    {
        if(time.isNightTime)
        {
            sun.SetActive(false);
            moon.SetActive(true);
        }

        else
        {
            sun.SetActive(true);
            moon.SetActive(false);
        }
    }
}
