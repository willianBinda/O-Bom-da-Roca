using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamySpawner : MonoBehaviour
{
    
    public GameObject enemyPrefab;
    private Transform[] spawnPoints;
    public float spawnInterval = 3f;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        // Ignora o primeiro elemento, que é o próprio objeto "Spawn"
        int index = Random.Range(1, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
