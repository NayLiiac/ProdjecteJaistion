using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StockStoneResources : MonoBehaviour
{
    public GetStoneRessource GetStoneRessource;
    public int StonePickedUp = 0;

    public TextMeshProUGUI StoneNumber;

    //PickedUpResource and start coroutine for wait
    public void RecupResource()
    {
        StonePickedUp++;
        StartCoroutine(GetStoneRessource.WaitResource());

        UpdateResourceText();
    }

    public void UpdateResourceText()
    {
        StoneNumber.text = StonePickedUp.ToString();
    }


    void Start()
    {
        UpdateResourceText();    
    }
}
