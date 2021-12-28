using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody _playerRb;

    public float jumpForce = 10f;
    public float gravityMultiplier = 1f;
    private bool _isOnGround = true;

    private bool _gameOver;

    private Animator _animator;
    
    private const string SPEED_MULTIPLIER = "SpeedMultiplier";
    private const string JUMP_TRIG = "Jump_trig";
    private const string JUMP_B = "Jump_b";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE = "DeathType_int";

    public bool GameOver { get => _gameOver; }
    
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityMultiplier;

        _animator = GetComponent<Animator>();
        
        _animator.SetFloat("Speed_f", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        _animator.SetFloat(SPEED_MULTIPLIER, 1 + Time.time/10);
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !_gameOver)
        {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            
            _animator.SetTrigger(JUMP_TRIG);
            
            _animator.SetBool(JUMP_B, true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            _animator.SetBool(JUMP_B, false);

        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game OVER");
            _animator.SetBool(DEATH_B, true);
            _animator.SetInteger(DEATH_TYPE, Random.Range(1,3));
            _gameOver = true;
        }
    }
}
