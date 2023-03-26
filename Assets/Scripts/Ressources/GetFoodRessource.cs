using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFoodRessource : MonoBehaviour
{
    public int FoodPickedUp = 0;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FoodPickedUp++;
        }
    }
}
