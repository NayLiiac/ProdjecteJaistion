using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public int progressionWinCondition = 0;
    public int valueWinCondition = 100;
    /*On cr�e une variable publique qui peut �tre incr�ment�e dans d'autres scripts, et une fois qu'elle arrive � 
     la valeur que l'on a d�fini comme condition de victoire, ici 100 par d�faut, on charge une sc�ne de victoire */
    private void Update()
    {
        if (progressionWinCondition == valueWinCondition)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
