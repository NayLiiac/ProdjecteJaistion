using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField] private float timeOfDay;
    [SerializeField] private float cycleLength = 24f;

    private void Update()
    {
        timeOfDay = (timeOfDay + Time.deltaTime) % cycleLength;
        SunRotation(timeOfDay / cycleLength);
    }

    private void SunRotation(float timePercent)
    {
        sun.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
    }
}
