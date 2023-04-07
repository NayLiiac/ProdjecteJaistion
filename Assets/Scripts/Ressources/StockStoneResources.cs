using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockStoneResources : MonoBehaviour
{
    public GetStoneRessource GetStoneRessource;

    public int StonePickedUp = 0;

    //PickedUpResource and start coroutine for wait
    public void RecupResource()
    {
        StonePickedUp++;
        StartCoroutine(GetStoneRessource.WaitResource());
    }
}
