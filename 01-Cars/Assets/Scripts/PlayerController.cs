using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //PROPIEDADES
    [Range(0, 20), SerializeField,
     Tooltip("CurrentVelocity")]
    private float speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Vector3.forward * Time.deltaTime);
    }
}
