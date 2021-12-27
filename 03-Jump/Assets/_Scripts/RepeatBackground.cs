using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidht;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidht = GetComponent<BoxCollider>().size.x/2 * transform.localScale.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos.x - transform.position.x >= repeatWidht)
        {
            transform.position = startPos;
        }
    }
}
