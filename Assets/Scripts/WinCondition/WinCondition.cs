using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public int prosperityPoints = 0;
    public int valueWinCondition = 100;
    
    // Check if the player has won, in that case, the game load the victory scene

     public void CheckVictory()
     {
         if (prosperityPoints >= valueWinCondition)
         {
            SceneManager.LoadScene("VictoryScene");
         }
     }
}
