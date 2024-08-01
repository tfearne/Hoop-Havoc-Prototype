using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;       // The coin prefab to instantiate
    public float spawnInterval = 5.0f;  // Time interval between spawns
    public Vector3 spawnAreaMin;        // Minimum position for spawning coins
    public Vector3 spawnAreaMax;        // Maximum position for spawning coins

    private float spawnTimer;

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnCoin();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnCoin()
    {
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}

