using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    public VillagerManager Manager;

    private void Update()
    {
        if (Manager.villagerList.Count == 0)
        {
            SceneManager.LoadScene("DefeatScene");
        }
    }



}
