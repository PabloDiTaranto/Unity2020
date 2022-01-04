using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    
    private Vector3 movement;
    
    private Animator _animator;

    private Rigidbody _rigidbody;

    [SerializeField]
    private float turnSpeed;

    private Quaternion _rotation = Quaternion.identity;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement.Set(horizontal,0,vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        _animator.SetBool(IS_WALKING, isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward,
            movement, turnSpeed * Time.fixedDeltaTime, 0f);
        
        _rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        _rigidbody.MovePosition(_rigidbody.position + movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(_rotation);
    }
}
