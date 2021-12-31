using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveForce;

    private Rigidbody _rigidbody;

    private float forwardInput;

    public bool hasPowerUp;
    public float powerUpForce;
    public float powerUpTime = 7f;
    public GameObject[] powerUpIndicators;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("Prototype 4");
        }
        forwardInput = Input.GetAxis("Vertical");
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = transform.position + 0.5f * Vector3.down;
        }
    }

    void FixedUpdate()
    {
        _rigidbody.AddForce(RotateCamera.Forward * moveForce * forwardInput, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            StartCoroutine(PowerUpCountdown());
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountdown()
    {
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.SetActive(true);
            yield return new WaitForSeconds(powerUpTime/powerUpIndicators.Length);
            indicator.SetActive(false);
        }
        hasPowerUp = false;
    }
}
