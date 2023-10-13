using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f; // Jak często przeciwnik będzie spawnować
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private bool canMobSpawn = true;

    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private int maxEnemyCount = 4;
    private bool hasSpawnedBoss = false;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canMobSpawn)
        {
            if (spawnedEnemies.Count < maxEnemyCount)
            {
                yield return wait;
                int rand = Random.Range(0, enemyPrefabs.Length);
                GameObject enemyToSpawn = enemyPrefabs[rand];

                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0); 
                Quaternion spawnRotation = Quaternion.identity;

                GameObject spawnedEnemy = Instantiate(enemyToSpawn, spawnPosition, spawnRotation);
                spawnedEnemies.Add(spawnedEnemy);

                if (spawnedEnemies.Count == maxEnemyCount && !hasSpawnedBoss)
                {
                    // Spawn the boss if there are 4 regular enemies and a boss hasn't been spawned yet
                    Vector3 bossSpawnPosition = new Vector3(transform.position.x, transform.position.y, 0); 
                    Quaternion bossSpawnRotation = Quaternion.identity;

                    GameObject boss = Instantiate(bossPrefab, bossSpawnPosition, bossSpawnRotation);
                    spawnedEnemies.Add(boss);
                    hasSpawnedBoss = true;
                }
            }
            else
            {
                // Wait and continue checking for space
                yield return wait;
            }
        }
    }
}
