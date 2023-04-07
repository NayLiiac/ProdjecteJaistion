using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWoodRessource : MonoBehaviour
{
    public int WoodPickedUp = 0;
    public int waitResource = 3; 
    public bool startHarvest;

    void Update()
    {
        if (startHarvest)
        {
            PickedUpResource();
            startHarvest = false;
        }
    }

    //PickedUpResource and start coroutine for wait
    void PickedUpResource()
    {
        WoodPickedUp++;
        StartCoroutine(WaitResource());
    }

    //a villager enters the area
    void OnTriggerEnter(Collider collision)
    {
        startHarvest = true; 
    }

    //stop the coroutine when the villager is out the area
    void OnTriggerExit(Collider collision) 
    {
        startHarvest = false;
        StopCoroutine(WaitResource()); 
    }

    //wait time for retrieve a new resource
    IEnumerator WaitResource()
    {
        yield return new WaitForSeconds(waitResource); 
        PickedUpResource(); 
    }
}
