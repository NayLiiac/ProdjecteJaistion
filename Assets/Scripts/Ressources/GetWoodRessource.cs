using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWoodRessource : MonoBehaviour
{
    public StockWoodResources StockWoodResources;
    public int waitResource = 4;
    public bool isHarvesting;

    //a villager enters the area
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Villager")
        {
            isHarvesting = true;
            StockWoodResources.PickedUpResource();
        }
    }

    //wait time for retrieve a new resource
    public IEnumerator WaitResource()
    {
        yield return new WaitForSeconds(waitResource);
        
        if (isHarvesting)
        {
            StockWoodResources.PickedUpResource();
        }
    }
}
