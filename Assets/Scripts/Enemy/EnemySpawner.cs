using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {
  [SerializeField] private float spawnRate = 1f; //How often the enemy spawn
  [SerializeField] private GameObject[] enemyPrefabs;
  [SerializeField] private bool canSpawn = true;

  private void Start() {
    StartCoroutine(Spawner());
  }

  private IEnumerator Spawner() {
    WaitForSeconds wait = new WaitForSeconds(spawnRate);

    while (canSpawn) {
        yield return wait;
        int rand = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyToSpawn = enemyPrefabs[rand];

        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        
    }
  }
}
