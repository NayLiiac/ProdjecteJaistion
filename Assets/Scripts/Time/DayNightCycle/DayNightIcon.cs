using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightIcon : MonoBehaviour
{
    [SerializeField] private TimeController time;
    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject moon;

    //Ce script sert à définir quelle icône est affichée en fonction de la période définie (nuit ou jour) dans le TimeController
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
