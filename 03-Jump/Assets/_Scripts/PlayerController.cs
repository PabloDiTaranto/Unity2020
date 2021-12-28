using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody _playerRb;

    public float jumpForce = 10f;
    public float gravityMultiplier = 1f;
    private bool _isOnGround = true;

    private bool _gameOver;

    private Animator _animator;

    public ParticleSystem explosion;
    public ParticleSystem dirtTrail;

    public AudioClip[] jumpSound, crashSound;
    private AudioSource _audioSource;
    [Range(0, 1)] public float audioVolumen = 1f;
    
    private const string SPEED_MULTIPLIER = "SpeedMultiplier";
    private const string JUMP_TRIG = "Jump_trig";
    private const string JUMP_B = "Jump_b";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE = "DeathType_int";

    public bool GameOver { get => _gameOver; }

    private bool doOnceDie;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityMultiplier;

        _animator = GetComponent<Animator>();
        
        _animator.SetFloat("Speed_f", 1);

        _audioSource = GetComponent<AudioSource>();
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
            
            dirtTrail.Stop();
            
            _audioSource.PlayOneShot(jumpSound[Random.Range(0, jumpSound.Length)], audioVolumen);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            _animator.SetBool(JUMP_B, false);
            dirtTrail.Play();

        }else if (collision.gameObject.CompareTag("Obstacle") && !doOnceDie)
        {
            Debug.Log("Game OVER");
            _animator.SetBool(DEATH_B, true);
            _animator.SetInteger(DEATH_TYPE, Random.Range(1,3));
            _gameOver = true;
            dirtTrail.Stop();
            explosion.Play();
            _audioSource.PlayOneShot(crashSound[Random.Range(0, crashSound.Length)], audioVolumen);
            doOnceDie = !doOnceDie;
        }
    }
}
