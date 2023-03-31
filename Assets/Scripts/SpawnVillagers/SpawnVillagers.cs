using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnVillagers : MonoBehaviour
{

    public GameObject spawnVillagersPrefab;
    
    public void VillagersSpawn()
    {

        Instantiate(spawnVillagersPrefab);

    }

}
