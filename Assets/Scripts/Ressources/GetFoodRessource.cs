using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFoodRessource : MonoBehaviour
{
    public StockFoodResources StockFoodResources;

    public int waitResource = 2;
    public bool startHarvest;

    void Update()
    {
        if (startHarvest)
        {
            StockFoodResources.RecupResource();
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
        StockFoodResources.RecupResource();
    }
}
