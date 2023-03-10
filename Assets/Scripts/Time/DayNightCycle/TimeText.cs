using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    public TimeController time;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Update()
    {
        time.UpdateTime();
        UpdateTimeText();
    }
    private void UpdateTimeText()
    {
        timeText.text = time.timeOfDay.ToString("0");
    }
}
