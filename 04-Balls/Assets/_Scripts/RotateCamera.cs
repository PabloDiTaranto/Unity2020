using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float spinSpeed;

    private float _horizontalInput;

    private static Vector3 _forward;

    public static Vector3 Forward
    {
        get => _forward;
    }

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        
        _transform.Rotate(Vector3.up, _horizontalInput * spinSpeed * Time.deltaTime);

        _forward = _transform.forward;
    }
}
