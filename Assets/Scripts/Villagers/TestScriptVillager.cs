using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptVillager : MonoBehaviour
{
    private bool day = true;
    // Start is called before the first frame update
    void Start()
    {
        VillagerManager.instance.DayTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (day)
            {
                day = false;
                VillagerManager.instance.NightTime();
            }
            else
            {
                day = true;
                VillagerManager.instance.DayTime();
            }
        }
    }
}
