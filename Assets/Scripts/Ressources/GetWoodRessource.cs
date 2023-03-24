using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWoodRessource : MonoBehaviour
{
    public int WoodPickedUp = 0;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            WoodPickedUp++;
        }
    }
}
