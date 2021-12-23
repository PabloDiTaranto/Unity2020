using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;

    private Vector3 offset = new Vector3(0, 4, -5);
    

    private void Update()
    {
        transform.position = player.transform.position + offset;
    }
}