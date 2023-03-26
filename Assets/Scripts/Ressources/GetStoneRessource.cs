using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStoneRessource : MonoBehaviour
{
    public int StonePickedUp = 0;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StonePickedUp++;
        }
    }
}
