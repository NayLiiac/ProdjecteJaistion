using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class BuildPlacement : MonoBehaviour     
// youtube video https://www.youtube.com/watch?v=ImiyFWZkMAA for build placement and spawning grid
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

    // Will check whether or not a farm is build 
    public bool isFarmBuilt = false;
    public GameObject FarmButton;

    public Material matGrid, matDefault, collisionBuild, buildDefault;

    // Pickup resources collected by the player's villagers
    public StockWoodResources Wood;
    public StockStoneResources Stone;

    // How much resources a build requires 
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
                    Debug.Log("Plac�");
                    Instantiate(BuildToPlace, BuildToMove.transform.position, Quaternion.identity);
                    Grid.SetActive(false);
                    selectBuild = false;

                    BuildingEffect();

                    // Consume resources when player chose to place a build
                    Wood.WoodPickedUp -= WoodRequired;
                    Stone.StonePickedUp -= StoneRequired;
                    gameObject.SetActive(false);

                }
            }
        }
    }
    // �viter la superposition des b�timents
    void OnCollisionEnter(Collision collision)
    {
        buildCollision = true;
    }
    void OnCollisionExit(Collision collision)
    {
        Build.GetComponent<MeshRenderer>().material = buildDefault;
        buildCollision = false;
    }


    // Building Effect Method
    void BuildingEffect()
    {
        if (Build.tag == "Bookshop")
        {
            // at each bookshop placed, the player earn x prosperity points, then, check if the player has won
            winCondition.prosperityPoints += 5;
            winCondition.CheckVictory();
        }

        if (Build.tag == "Museum")
        {
            // at each museum placed, the player earn x prosperity points, then, check if the player has won
            winCondition.prosperityPoints += 10;
            winCondition.CheckVictory();
        }

        if (Build.tag == "Farm")
        {
            // when a farm is placed, the player earn a food pickup boost;
            // then, the farm build button disappear, allowing only one farm per run
            isFarmBuilt = true;
            FarmButton.gameObject.SetActive(false);
        }
    }

}