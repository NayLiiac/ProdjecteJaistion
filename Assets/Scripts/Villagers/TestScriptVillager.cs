using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptVillager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VillagerManager.instance.NightTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
