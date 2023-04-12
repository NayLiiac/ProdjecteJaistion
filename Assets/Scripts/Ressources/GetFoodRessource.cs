using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFoodRessource : MonoBehaviour
{
    public StockFoodResources StockFoodResources;

    public int waitResource = 4;
    public bool isHarvesting = false;


    //a villager enters the area
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Villager")
        {
            isHarvesting = true;
            StockFoodResources.PickedUpResource();

        }
    }

    //wait time for retrieve a new resource
    public IEnumerator WaitResource()
    {
        yield return new WaitForSeconds(waitResource);
        if (isHarvesting) 
        { 
            StockFoodResources.PickedUpResource(); 
        }
    }
}
