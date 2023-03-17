using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVillagers : MonoBehaviour
{
    public bool canSpawnVillagers = false;
    public GameObject spawnVillagersPrefab;
    
    public int MaxSpawnVillagers = 1;
    public int SpawnedVillagers = 0;

    // Update is called once per frame
    void Update()
    {
        if (canSpawnVillagers && SpawnedVillagers < MaxSpawnVillagers)
        {
            Instantiate(spawnVillagersPrefab);
            SpawnedVillagers++;
        }
        
    }
}
