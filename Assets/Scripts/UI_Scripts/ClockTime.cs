using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTime : MonoBehaviour
{
    public PauseTime pauseTime;
    public TimeController timeControl;
    public Speed2Time speed2Time;

    public GameObject Needle;
    public int speedClock;
    private int defaultSpeedClock;

     void Start()
    {
        defaultSpeedClock = speedClock;
    }
    public void Update()
    {
        Needle.transform.Rotate(Vector3.back * Time.deltaTime * speedClock); //rotate the clock 

        

        //recover the script PauseTime to check if the time is paused 
        if (pauseTime.isPaused)
        {
            speedClock = 0; //stop the clock rotation for time paused
        }

        if (pauseTime.isPaused == false)
        {
            speedClock = defaultSpeedClock; //put back the clock rotation
        }
    }

    public void ClockSpeed ()
    {
        //if the time is accelerated the clock rotation must be accelerated
        if (speed2Time.isTimeTwo)
        {
            speedClock = speedClock * 2; //accelerate the rotation time
        }

        if (speed2Time.isTimeTwo == false)
        {
            speedClock = defaultSpeedClock; //normal speed
        }
    }
}
