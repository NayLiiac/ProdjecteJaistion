using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStoneRessource : MonoBehaviour
{
    public int StonePickedUp = 0;
    public float waitResource = 4;
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
        StonePickedUp++;
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
