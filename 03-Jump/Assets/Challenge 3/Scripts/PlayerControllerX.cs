using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    public float bouncinessForce = 10f;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    private MeshRenderer _meshRenderer;

    public float maxPosY = 15f;
    public float minPosY = 1f;

    private float positionY;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
#region ReturnConditions(Bounds Limits and Game Over)

        if(gameOver) return;
        
        positionY = transform.position.y;
        
        if(positionY >= maxPosY)
        {
            transform.position = new Vector3(transform.position.x, maxPosY, transform.position.z);
            playerRb.velocity = Vector3.zero;
            return;
        }

        if (positionY <= minPosY)
        {
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * bouncinessForce);
            return;
        }
#endregion
        
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            _meshRenderer.enabled = false;//Disable MeshRenderer
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
