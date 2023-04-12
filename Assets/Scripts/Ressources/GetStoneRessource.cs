using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStoneRessource : MonoBehaviour
{
    public StockStoneResources StockStoneResources;

    public float waitResource = 4;
    public bool startHarvest;
    public bool isHarvesting = false;


    //a villager enters the area
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Villager")
        {
            StockStoneResources.PickedUpResource();
            isHarvesting = true;
        }
    }

    //wait time for retrieve a new resource
    public IEnumerator WaitResource()
    {
        yield return new WaitForSeconds(waitResource);
        if (isHarvesting) 
        { 
            StockStoneResources.PickedUpResource(); 
        }
    }
}
