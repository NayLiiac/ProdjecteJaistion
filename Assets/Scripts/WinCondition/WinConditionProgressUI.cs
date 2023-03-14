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
    

    private void CurrentFill()
    {
        float currentOffset = winCondition.progressionWinCondition - minimum;
        float maxOffset = maximum - minimum;
        float fillAmount = currentOffset / maxOffset;
        mask.fillAmount = fillAmount;
    }

    private void Update()
    {
        CurrentFill();
    }





}
