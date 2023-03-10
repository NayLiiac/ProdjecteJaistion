using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public float timeOfDay;
    public float cycleLength = 24f;
    

    private void Update()
    {
        
    }

    public void UpdateTime()
    {
        timeOfDay = (timeOfDay + Time.deltaTime) % cycleLength;
    }

    

}
