using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Speed2Time : MonoBehaviour
{
    public bool isTimeTwo = false;

    //Ce script utilise les fonctions de passage du temps définies dans le TimeController, et si le joueur appuie sur espace, double la vitesse du jeu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isTimeTwo)
            {
                isTimeTwo = true;
            }

            else
            {
                isTimeTwo = false;
            }
        }
    }
}
