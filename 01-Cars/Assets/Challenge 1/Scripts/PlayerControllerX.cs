using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [Range(0, 50), SerializeField]
    private float speed = 35f;
    
    [Range(0, 50), SerializeField]
    private float rotationSpeed = 25f;
    
    
    private float _verticalInput;

   

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        _verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(speed  *  Time.deltaTime * Vector3.forward);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate( rotationSpeed * _verticalInput * Time.deltaTime * Vector3.right);
    }
}
