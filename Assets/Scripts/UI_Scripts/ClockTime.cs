using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTime : MonoBehaviour
{
    public TimeController timeControl;
    public PauseTime pauseTime;

    public GameObject Needle;
    public int needleSpeed;

    public void Update()
    {
       
        //rotate the clock 
        Needle.transform.Rotate(Vector3.back * (360 / timeControl.cycleLength) * Time.deltaTime * needleSpeed);

        if (pauseTime.isPaused)
        {
            needleSpeed = 0;
        }
        else
        {
            needleSpeed = timeControl.timeSpeed;
        }
    }
}
