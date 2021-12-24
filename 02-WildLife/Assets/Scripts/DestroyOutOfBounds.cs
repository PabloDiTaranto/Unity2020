using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] 
    private float topBound = 30f;

    [SerializeField] 
    private float lowerBound = -10f;
    private void Update()
    {
        if (transform.position.z > topBound || transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
