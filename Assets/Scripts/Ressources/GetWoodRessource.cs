using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWoodRessource : MonoBehaviour
{
    public int WoodPickedUp = 0;
    public int waitResource = 3;
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
        WoodPickedUp++;
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
