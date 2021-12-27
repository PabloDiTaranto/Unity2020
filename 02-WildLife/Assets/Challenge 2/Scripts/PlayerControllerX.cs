using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float spawnDogRate = 1f;
    private float counterDogRate;

    private bool canSpawnDog;

    private void Start()
    {
        counterDogRate = spawnDogRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (counterDogRate < spawnDogRate)
        {
            counterDogRate += Time.deltaTime;
            //return;
        }
        else if(!canSpawnDog)
        {
            canSpawnDog = true;
        }
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canSpawnDog)
        {
            SpawnDog();
            counterDogRate = 0f;
            canSpawnDog = false;
        }
    }

    private void SpawnDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
    }
}
