using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockFoodResources : MonoBehaviour
{
    public GetFoodRessource GetFoodRessource;
    public BuildPlacement build;

    public int FoodPickedUp = 0;
    public int foodBoost = 2;

    public TextMeshProUGUI FoodNumber;

    //PickedUpResource and start coroutine for wait
    public void RecupResource()
    {
        if (build.isFarmBuilt == false)
        {
            FoodPickedUp++;
            
        }
        if (build.isFarmBuilt)
        {
            FoodPickedUp += foodBoost;

        }

        UpdateResourceText();
        StartCoroutine(GetFoodRessource.WaitResource());
    }

    public void UpdateResourceText()
    {
        FoodNumber.text = FoodPickedUp.ToString();
    }


    void Start()
    {
        UpdateResourceText();
    }
}
