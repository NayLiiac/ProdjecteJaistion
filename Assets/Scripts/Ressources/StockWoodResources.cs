using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StockWoodResources : MonoBehaviour
{
    public GetWoodRessource GetWoodRessource;
    public int WoodPickedUp = 0;

    public TextMeshProUGUI WoodNumber;

    //PickedUpResource and start coroutine for wait
    public void PickedUpResource()
    {
        WoodPickedUp++;
        StartCoroutine(GetWoodRessource.WaitResource());

        UpdateResourceText();
    }

    public void UpdateResourceText()
    {
        WoodNumber.text = WoodPickedUp.ToString();
    }


    void Start()
    {
        UpdateResourceText();
    }
}
