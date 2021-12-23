using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //PROPIEDADES
    [Range(0, 20), SerializeField,
     Tooltip("Max Linear Velocity")]
    private float speed = 5f;

    [Range(0, 90), SerializeField,
     Tooltip("Max Turn Velocity")]
    private float turnSpeed = 30f;

    private float horizontalInput;
    private float verticalInput;
   

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(speed * verticalInput *  Time.deltaTime * Vector3.forward);

        if (Mathf.Abs(verticalInput) < 0.01f) return;
        
        transform.Rotate(turnSpeed * horizontalInput * Time.deltaTime * Vector3.up);
    }
}
