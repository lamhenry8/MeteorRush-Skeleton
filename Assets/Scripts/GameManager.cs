using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    int score;
    bool isGameOver;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        score = 0;
        isGameOver = false;
        UpdateScoreText();
    }

    public bool IsGameOver => isGameOver;

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + score;
    }

    void Update()
    {
        if (isGameOver && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        isGameOver = false;
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}