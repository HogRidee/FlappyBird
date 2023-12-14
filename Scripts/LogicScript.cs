using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource pingSFX;
    public int highScore;
    public Text highScoreText;

    // Useful to test our functions
    [ContextMenu("Increase Score")]
    
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        pingSFX.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Start()
    {
        // Load the high score from PlayerPrefs
        LoadHighScore();
        Debug.Log("Loaded High Score: " + highScore);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("High Score", playerScore);
            // Save the high score to PlayerPrefs
            SaveHighScore(); 
            highScoreText.text = "High Score: " + highScore.ToString();
        }
        playerScore = 0;
    }
    // Helper method to load the high score from PlayerPrefs
    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("High Score", 0);
    }

    // Helper method to save the high score to PlayerPrefs
    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("High Score", highScore);
        PlayerPrefs.Save();
    }
    
    public void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}

