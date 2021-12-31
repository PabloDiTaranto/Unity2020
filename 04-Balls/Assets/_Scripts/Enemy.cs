using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public float moveForce;
    
    private Rigidbody _rigidbody;

    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _rigidbody.AddForce(lookDirection * moveForce, ForceMode.Force);
    }
}
