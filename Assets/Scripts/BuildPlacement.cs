using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class BuildPlacement : MonoBehaviour     //vidéo https://www.youtube.com/watch?v=ImiyFWZkMAA pour le placement du build et l'apparition de la grille
{
    public GameObject BuildToPlace;
    public GameObject BuildToMove;
    public GameObject Grid;
    public GameObject Build;

    public LayerMask mask;
    public float LastPosY;
    public Vector3 MousePos;

    public bool selectBuild = false;
    public bool buildCollision = false;

    private Renderer rend;
    public Material matGrid, matDefault, collisionBuild, buildDefault;

    void Start()
    {
        rend = GameObject.Find("Ground").GetComponent<Renderer>();
    }
    public void BuildPlace(GameObject buildPlace)
    {
        BuildToPlace = buildPlace;
    }
    public void BuildMove(GameObject buildMove)
    {
        BuildToMove = buildMove;
        selectBuild = true;
    }
    void Update()
    {
        if (selectBuild)
        {
            Grid.SetActive(true);

            MousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(MousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                int PosX = (int)Mathf.Round(hit.point.x);
                int PosZ = (int)Mathf.Round(hit.point.z);

                BuildToMove.transform.position = new Vector3(PosX, LastPosY, PosZ);

                if (buildCollision)
                {
                    Debug.Log("collision");
                    Build.GetComponent<MeshRenderer>().material = collisionBuild;
                }
            }

            if (!buildCollision)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Placé");
                    Instantiate(BuildToPlace, BuildToMove.transform.position, Quaternion.identity);
                    Grid.SetActive(false);
                    selectBuild = false;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collisionTrue");

        buildCollision = true;
    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("collisionfalse");
        Build.GetComponent<MeshRenderer>().material = buildDefault;
        buildCollision = false;
    }
}