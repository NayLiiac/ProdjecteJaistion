using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightIcon : MonoBehaviour
{
    [SerializeField] private TimeController time;
    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject moon;
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
