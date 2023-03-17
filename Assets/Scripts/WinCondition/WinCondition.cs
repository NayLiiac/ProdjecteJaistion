using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public int progressionWinCondition = 0;

    private void Update()
    {
        if (progressionWinCondition == 100)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
