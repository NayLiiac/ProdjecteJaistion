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

    public WinCondition winCondition;

    public LayerMask mask;
    public float LastPosY;
    public Vector3 MousePos;

    public bool selectBuild = false;
    public bool buildCollision = false;
    public bool isFarmBuilt = false;

    private Renderer rend;
    public Material matGrid, matDefault, collisionBuild, buildDefault;

    // Récupérer les matériaux collectés par le joueur
    public GetWoodRessource Wood;
    public GetStoneRessource Stone;

    // Récupère les matériaux requis
    public int BuilderRequired;
    public int WoodRequired;
    public int StoneRequired;

    public void BuildPlace(GameObject buildPlace)
    {
        BuildToPlace = buildPlace;
    }
    public void BuildMove(GameObject buildMove)
    {
        BuildToMove = buildMove;
        selectBuild = true;
        gameObject.SetActive(true);

    }
    void Start()
    {
        gameObject.SetActive(false);
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
                    
                    Build.GetComponent<MeshRenderer>().material = collisionBuild;
                }
            }

            if (!buildCollision)
            {
                
                if (Input.GetMouseButtonDown(1) && Wood.WoodPickedUp >= WoodRequired && Stone.StonePickedUp >= StoneRequired && VillagerManager.instance.GetBuilderNumber() >= BuilderRequired)
                {
                    Debug.Log("Placé");
                    Instantiate(BuildToPlace, BuildToMove.transform.position, Quaternion.identity);
                    Grid.SetActive(false);
                    selectBuild = false;

                    //Effet des bâtiments
                    BuildingEffect();

                    //Retrait des ressources 
                    Wood.WoodPickedUp -= WoodRequired;
                    Stone.StonePickedUp -= StoneRequired;
                    gameObject.SetActive(false);

                }
            }
        }
    }
    // Éviter la superposition des bâtiments
    void OnCollisionEnter(Collision collision)
    {

        buildCollision = true;
    }
    void OnCollisionExit(Collision collision)
    {
        Build.GetComponent<MeshRenderer>().material = buildDefault;
        buildCollision = false;
    }

    private void BuildingEffect()
    {
        if (Build.tag == "Bookshop")
        {
            winCondition.progressionWinCondition += 10;
        }

        if (Build.tag == "Museum")
        {
            winCondition.progressionWinCondition += 25;
        }

        if (Build.tag == "Farm")
        {
            isFarmBuilt = true;
        }
    }

}