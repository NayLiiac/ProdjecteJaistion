using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public int progressionWinCondition = 0;
    public int valueWinCondition = 100;
    /*On crée une variable publique qui peut être incrémentée dans d'autres scripts, et une fois qu'elle arrive à 
     la valeur que l'on a défini comme condition de victoire, ici 100 par défaut, on charge une scène de victoire */
    private void Update()
    {
        if (progressionWinCondition == valueWinCondition)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
