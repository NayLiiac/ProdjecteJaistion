using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light sun;
    public TimeController time;

    private void Update()
    {
        time.UpdateTime();
        SunRotation(time.timeOfDay / time.cycleLength);
    }

    private void SunRotation(float timePercent)
    {
        sun.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
    }
}
