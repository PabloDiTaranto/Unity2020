using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    
    private int animalIndex;
    private float spawnRangeX = 20f;
    private float spawnPosZ;

    private void Start()
    {
        spawnPosZ = transform.position.z;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            float xRand = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPos = new Vector3(xRand, 0, spawnPosZ);

            animalIndex = Random.Range(0, enemies.Length);
            
            Instantiate(enemies[animalIndex],
                spawnPos,
                enemies[animalIndex].transform.rotation);
        }
    }
}
