using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildPlacement : MonoBehaviour     //vidéo https://www.youtube.com/watch?v=ImiyFWZkMAA 
{
    public GameObject BuildToPlace;
    public GameObject BuildToMove;
    public LayerMask mask;
    public float LastPosY;
    public Vector3 MousePos;

    private Renderer rend;
    public Material matGrid, matDefault;
    

    void Update()
    {
        MousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(MousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            int Posx = (int)Mathf.Round(hit.point.x);
            int Posz = (int)Mathf.Round(hit.point.z);

            BuildToMove.transform.position = new Vector3(Posx, LastPosY, Posz);
        }
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(BuildToPlace, BuildToMove.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
