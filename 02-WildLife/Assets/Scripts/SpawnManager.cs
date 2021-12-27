using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    
    private int _animalIndex;
    private float spawnRangeX = 14f;
    private float _spawnPosZ;

    [SerializeField, Range(2f, 5f)]
    private float startDelay = 2f;
    [SerializeField, Range(0.1f, 3f)]
    private float spawnInterval = 1.5f;

    private void Start()
    {
        _spawnPosZ = transform.position.z;
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void Update()
    {
        
    }

    private void SpawnRandomAnimal()
    {
        float xRand = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(xRand, 0, _spawnPosZ);

        _animalIndex = Random.Range(0, enemies.Length);
            
        Instantiate(enemies[_animalIndex],
            spawnPos,
            enemies[_animalIndex].transform.rotation);
    }
}
