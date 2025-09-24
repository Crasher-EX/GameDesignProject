using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainSpawner : MonoBehaviour
{

    public List<GameObject> terrainPrefabs;
    [SerializeField] float spawnCooldown;
    float currentTime;


    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            SpawnTerrainPrefab();
        }
    }

   


    //Updated terrain spawning prefab with random choice from list
    void SpawnTerrainPrefab()
    {
        currentTime = spawnCooldown;
        int randomSelectedPrefab = Random.Range(0, terrainPrefabs.Count);
        GameObject PrefabInstantiate = terrainPrefabs[randomSelectedPrefab];
        Instantiate(PrefabInstantiate, transform);
    }
}
