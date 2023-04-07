using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    public TimeController time;
    [SerializeField] private TextMeshProUGUI timeText;

    //Ce script sert à afficher l'heure qu'il est dans notre jeu, définie dans le TimeController
    private void Update()
    {
        UpdateTimeText();
    }
    private void UpdateTimeText()
    {
        timeText.text = time.timeOfDay.ToString("0");
    }
}
