using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float spinSpeed = 60f;
    public float translateSpeed = 1f;
    

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * translateSpeed *Time.deltaTime;
        transform.Rotate(Vector3.up * spinSpeed *Time.deltaTime);
    }
}
