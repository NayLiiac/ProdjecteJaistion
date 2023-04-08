using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinConditionProgressUI : MonoBehaviour
{
    [SerializeField] private int minimum;
    [SerializeField] private int maximum;
    [SerializeField] private WinCondition winCondition;
    public Image mask;
    
    // Create a gauge which fills itself with the points earned thanks to museums / bookshops / villagers

    public void CurrentFill()
    {
        float currentOffset = winCondition.prosperityPoints - minimum;
        float maxOffset = maximum - minimum;
        float fillAmount = currentOffset / maxOffset;
        mask.fillAmount = fillAmount;
    }

    void Update()
    {
        CurrentFill();
    }





}
