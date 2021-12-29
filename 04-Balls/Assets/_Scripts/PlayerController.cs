using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveForce;

    private Rigidbody _rigidbody;

    private float forwardInput;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        _rigidbody.AddForce(RotateCamera.Forward * moveForce * forwardInput, ForceMode.Force);
    }
}
