using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Speed2Time : MonoBehaviour
{
    public bool isTimeTwo = false;


    private void Update()
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
