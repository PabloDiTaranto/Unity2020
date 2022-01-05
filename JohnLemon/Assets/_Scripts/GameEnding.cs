using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;

    public float displayImageDuration = 1f;

    private bool _isPlayerAtExit, _isPlayerCaught;
    
    public GameObject player;

    public CanvasGroup exitBackgroundImageCanvasGroup;

    public CanvasGroup caughtBackgroundImageCanvasGroup;

    public AudioSource exitAudio, caughtAudio;
    private bool hasAudioPlay;

    private float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            _isPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if (_isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (_isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    /// <summary>
    /// Lanza la imagen de fin de partida
    /// </summary>
    /// <param name="imageCanvasGroup">Imagen de fin de partida correspondiente</param>
    /// <param name="doRestart">Si se debe o no reiniciar la partida</param>
    private void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {

        if (!hasAudioPlay)
        {
            audioSource.Play();
            hasAudioPlay = true;
        }
        
        timer += Time.deltaTime;
        imageCanvasGroup.alpha = timer / fadeDuration;
            
        if (timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Application.Quit();
            }
            
        }
    }

    /// <summary>
    /// Cambia el valor del booleano si el player es atrapado
    /// </summary>
    public void CatchPlayer()
    {
        _isPlayerCaught = true;
    }
}
