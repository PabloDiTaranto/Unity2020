using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    [SerializeField]
    private GameObject plane;
    private Vector3 _offset = new Vector3(25,0,6);


    void Update()
    {
        transform.position = plane.transform.position + _offset;
    }
}
