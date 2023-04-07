using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWoodRessource : MonoBehaviour
{
    public StockWoodResources StockWoodResources;
    public bool startHarvest;
    public int waitResource = 3; 

    void Update()
    {
        if (startHarvest)
        {
            StockWoodResources.PickedUpResource();
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
        StockWoodResources.PickedUpResource();
    }

}
