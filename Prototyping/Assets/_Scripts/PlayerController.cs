using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Range(0,360)]
    public float moveSpeed, rotateSpeed, force;

    private Rigidbody _rigidbody;

    public bool usePhysicsEngine;

    private float verticalInput, horizontalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

       MovePlayer();
       
       KeepPlayerInBounds();
    }

    private void MovePlayer()
    {
        if (usePhysicsEngine)
        {
            //Physics
            _rigidbody.AddForce(Vector3.forward * force * Time.deltaTime * verticalInput, ForceMode.Force);
            _rigidbody.AddTorque(Vector3.up * force * Time.deltaTime * horizontalInput, ForceMode.Force);
        }
        else
        {
            //Transform
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * verticalInput);
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * horizontalInput);
        }
    }

    private void KeepPlayerInBounds()
    {
        if (Mathf.Abs(transform.position.x) >= 24f || Mathf.Abs(transform.position.z) >= 24f)
        {
            //TODO: Refactorizar la variable
            _rigidbody.velocity = Vector3.zero;
            if (transform.position.x > 24f)
            {
                transform.position = new Vector3(24f, transform.position.y, transform.position.z);
            }
            
            if (transform.position.x < -24f)
            {
                transform.position = new Vector3(-24f, transform.position.y, transform.position.z);
            }
            
            if (transform.position.z > 24f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 24f);
            }
            
            if (transform.position.z < -24f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -24f);
            }
        }
    }
}
