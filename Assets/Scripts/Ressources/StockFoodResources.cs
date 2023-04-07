using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockFoodResources : MonoBehaviour
{
    public GetFoodRessource GetFoodRessource;
    public BuildPlacement build;

    public int FoodPickedUp = 0;
    public int foodBoost = 2;

    //PickedUpResource and start coroutine for wait
    public void RecupResource()
    {
        if (build.isFarmBuilt == false)
        {
            FoodPickedUp++;
        }
        if (build.isFarmBuilt)
        {
            FoodPickedUp = FoodPickedUp + foodBoost;
        }
        StartCoroutine(GetFoodRessource.WaitResource());
    }
}
