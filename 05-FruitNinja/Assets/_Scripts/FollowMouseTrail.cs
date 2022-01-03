using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseTrail : MonoBehaviour
{
    private Camera _mainCamera; 
    private void Start()
    {
       _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }
}
