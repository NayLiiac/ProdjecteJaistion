using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockWoodResources : MonoBehaviour
{
    public GetWoodRessource GetWoodRessource;
    public int WoodPickedUp = 0;

    //PickedUpResource and start coroutine for wait
    public void PickedUpResource()
    {
        WoodPickedUp++;
        StartCoroutine(GetWoodRessource.WaitResource());
    }
}
