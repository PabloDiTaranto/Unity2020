using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefabs;
    private Vector3 spawnPos;
    private float startDelay = 2f;
    private float repeatRate = 2f;
    private int obstacleIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }  
    

    private void SpawnObstacle()
    {
        obstacleIndex = Random.Range(0, obstaclesPrefabs.Length);
        Instantiate(obstaclesPrefabs[obstacleIndex], spawnPos, obstaclesPrefabs[obstacleIndex].transform.rotation);
    }
}
