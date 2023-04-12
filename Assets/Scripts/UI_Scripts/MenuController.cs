using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public string SceneName;
    public GameObject pause;

    public void ChangeScene()
    {

        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }



    // Methods in order to return in the main menu while in game
    public void ReturnMenu()
    {
        pause.SetActive(true);
    }

    public void CancelReturnMenu()
    {
        pause.SetActive(false);
    }
}