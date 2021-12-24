using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float speed = 10f, xRange = 15f;
    private float horizontalInput;

    public GameObject projectilePrefab;
    
    
    void Update()
    {
        //Movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(speed * horizontalInput * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        
        //Actions
        if (Input.GetKey(KeyCode.Space))
        {
            //If enter here, must launch a projectile
            Instantiate(projectilePrefab, transform.position,
                projectilePrefab.transform.rotation);
        }
    }
}