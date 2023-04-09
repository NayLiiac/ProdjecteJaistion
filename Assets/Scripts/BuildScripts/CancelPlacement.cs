using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelPlacement : MonoBehaviour
{
    public BuildPlacement[] BuildPlacement;

    public void CancelBuild()
    {
        for (int i = 0; i < BuildPlacement.Length; i++) 
        {
            BuildPlacement[i].BuildToMove= null;
            BuildPlacement[i].BuildToPlace= null;
            BuildPlacement[i].selectBuild = false;
            BuildPlacement[i].gameObject.SetActive(false);
            BuildPlacement[i].Grid.SetActive(false);
            BuildPlacement[i].ResourceRequiredOnUI.SetActive(false);
        }

        


    }


}
