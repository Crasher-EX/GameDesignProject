using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VehicleSpawner : MonoBehaviour
{

    public List<GameObject> vehiclePrefabs;
    [SerializeField] float spawnCooldown;
    [SerializeField] float minCooldown;
    [SerializeField] float maxCooldown;
    public float currentTime;


    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            SpawnTerrainPrefab();
            spawnCooldown = Random.Range(minCooldown, maxCooldown);
        }
    }




    //Updated terrain spawning prefab with random choice from list
    void SpawnTerrainPrefab()
    {
        currentTime = spawnCooldown;
        int randomSelectedPrefab = Random.Range(0, vehiclePrefabs.Count);
        GameObject PrefabInstantiate = vehiclePrefabs[randomSelectedPrefab];
        Instantiate(PrefabInstantiate, transform);
    }
}
