using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    private int enemyCount;
    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int prefabIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[prefabIndex], GenerateRandomPosition(), enemyPrefab[prefabIndex].transform.rotation);
        }
    }
    Vector3 GenerateRandomPosition()
    {
        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new (xPos, 0, zPos);
        return spawnPos;
    }

    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
    }
}
