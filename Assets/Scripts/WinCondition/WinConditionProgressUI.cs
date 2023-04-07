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
    
    /*On cr�e une jauge en ajustant la taille du mask selon la valeur actuelle de notre progression vers la win condition
     Cette jauge repr�sente la proportion de points que l'on a et donne une bonne repr�sentation visuelle pour �valuer le progr�s qu'il nous reste � faire*/
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
