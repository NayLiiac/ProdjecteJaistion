using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFoodRessource : MonoBehaviour
{
    public int FoodPickedUp = 0;
    public int waitResource = 2;
    public bool startHarvest;

    void Update()
    {
        if (startHarvest)
        {
            RecupResource();
            startHarvest = false;
        }
    }
    void RecupResource()
    {
        FoodPickedUp++;
        StartCoroutine(WaitResource());
    }
    void OnTriggerEnter(Collider collision)
    {
        startHarvest = true;
    }
    void OnTriggerExit(Collider collision)
    {
        startHarvest = false;
        StopCoroutine(WaitResource());
    }
    IEnumerator WaitResource()
    {
        yield return new WaitForSeconds(waitResource);
        RecupResource();
    }
}
