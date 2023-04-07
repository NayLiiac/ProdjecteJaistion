using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStoneRessource : MonoBehaviour
{
    public int StonePickedUp = 0;
    public float waitResource = 4;
    public bool startHarvest;

    void Update()
    {
        if (startHarvest)
        {
            RecupResource();
            startHarvest = false;
        }
    }

    //PickedUpResource and start coroutine for wait
    void RecupResource()
    {
        StonePickedUp++;
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
        RecupResource();
    }
}
