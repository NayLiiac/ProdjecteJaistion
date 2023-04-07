using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockFoodResources : MonoBehaviour
{
    public GetFoodRessource GetFoodRessource;

    public int FoodPickedUp = 0;

    //PickedUpResource and start coroutine for wait
    public void RecupResource()
    {
        FoodPickedUp++;
        StartCoroutine(GetFoodRessource.WaitResource());
    }
}
