using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject powerUpPrefab;

    private float spawnRange = 9f;

    public int enemyCount;
    public int enemyWave = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(enemyWave);
    }

    private void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if (enemyCount <= 0)
        {
            enemyWave++;
            Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
            SpawnEnemyWave(enemyWave);
        }
    }

    /// <summary>
    /// Genera una posicion aleatoria dentro de la zona de juego 
    /// </summary>
    /// <returns>Devuelve una posicion aleatoria dentro de la zona de juego</returns>
    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    /// <summary>
    /// Metodo que genera un numero determinado de enemigos en pantalla
    /// </summary>
    /// <param name="numberOfEnemies"> Cantidad de enemigos a spawnear (Int)</param>
    private void SpawnEnemyWave(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
}
