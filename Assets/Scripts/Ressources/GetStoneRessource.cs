using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStoneRessource : MonoBehaviour
{
    public StockStoneResources StockStoneResources;

    public float waitResource = 4;
    public bool startHarvest;

    void Update()
    {
        if (startHarvest)
        {
            StockStoneResources.RecupResource();
            startHarvest = false;
        }
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
    public IEnumerator WaitResource()
    {
        yield return new WaitForSeconds(waitResource);
        StockStoneResources.RecupResource();
    }
}
