using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text = highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        audioManager.PlaySFX(audioManager.pipeSpawnFX);
        if (playerScore > highScore) 
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("High Score", highScore);
            Debug.Log(highScore.ToString());
            highScoreText.text = highScore.ToString();
        }
    }

    public void restartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() 
    {
        gameOverScreen.SetActive(true);
    }

}
