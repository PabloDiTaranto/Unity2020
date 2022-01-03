using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public enum GameState
    {
        loading,
        inGame,
        gameOver
    }

    public GameState gameState;

    public List<GameObject> targetPrefabs;
    
    private float spawnRate = 1.5f;

    public TextMeshProUGUI scoreText;

    public Button restartButton;

    private int _score;
    private int Score
    {
        set
        {
            _score = Mathf.Clamp(value, 0, 99999);
        }

        get
        {
            return _score;
        }
    }

    public TextMeshProUGUI gameOverText;

    public GameObject titleScreen;

    private const string MAX_SCORE = "MAX_SCORE";

    private int _numberOfLives = 4;

    public List<GameObject> lives;

    private void Start()
    {
        ShowMaxScore();
    }

    /// <summary>
    /// Metodo que inica una nueva partida
    /// </summary>
    /// <param name="difficulty"> Numero entero que indica la dificultad del juego</param>
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        
        titleScreen.SetActive(false);

        spawnRate /= difficulty;
        _numberOfLives -= difficulty;

        for (int i = 0; i < _numberOfLives; i++)
        {
            lives[i].SetActive(true);
        }
        
        StartCoroutine(SpawnTarget());
        
        Score = 0;
        
        UpdateScore(0); 
    }


    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

    /// <summary>
    /// Actualiza la puntuacion y lo muestra por pantalla
    /// </summary>
    /// <param name="scoreToAdd">Numero de puntos de añadir a la puntuacion global</param>
    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        scoreText.text = "Score:\n" + Score;
    }

    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        scoreText.text = "Max Score:\n" + maxScore;
    }

    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);

        if (Score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, Score);
        }
    }

    /// <summary>
    /// Finaliza el juego y muetsra la pantalla de Game Over
    /// </summary>
    public void GameOver()
    {
        _numberOfLives--;

        if (_numberOfLives >= 0)
        {
            Image heartImage = lives[_numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color = tempColor;
        }

        if (_numberOfLives <= 0)
        {
            SetMaxScore();
            gameState = GameState.gameOver;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
