using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Basic : MonoBehaviour
{
    [Header("HP Settings")]
    public int playerHP = 3;
    public int enemyHP = 3;

    [Header("Game Over")]
    public GameObject gameOverPanel;

    [Header("UI")]
    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI enemyHPText;
    public TextMeshProUGUI wordText;
    public TextMeshProUGUI roundText;
    public TMP_InputField inputField;
    public TextMeshProUGUI timerText;

    [Header("Timer")]
    public float timeLimit = 5f;
    private float currentTime;

    private int currentRound = 1;

    private string currentWord;
    private List<string> wordList = new List<string>()
    {
        "apple",
        "banana",
        "coffee",
        "unity",
        "keyboard",
        "battle",
        "dragon"
    };

    void Start()
    {
        StartRound();
    }

    void Update()
    {
        TimerCountdown();
        CheckTyping();
    }

    void StartRound()
    {
        playerHP = 3;
        enemyHP = 3;

        UpdateUI();
        roundText.text = "Round " + currentRound;

        GenerateWord();
        inputField.text = "";
        inputField.ActivateInputField();
    }

    void GenerateWord()
    {
        currentWord = wordList[Random.Range(0, wordList.Count)];
        wordText.text = currentWord;

        currentTime = timeLimit;
    }

    void CheckTyping()
    {
        string typed = inputField.text;

        // Kalau salah huruf
        if (!currentWord.StartsWith(typed))
        {
            PlayerTakeDamage();
            inputField.text = "";
        }

        // Kalau benar satu kata penuh
        if (typed == currentWord)
        {
            EnemyTakeDamage();
            inputField.text = "";
            GenerateWord();
        }
    }

    void TimerCountdown()
    {
        currentTime -= Time.deltaTime;
        timerText.text = currentTime.ToString("F1");

        if (currentTime <= 0)
        {
            PlayerTakeDamage();
            inputField.text = "";
            GenerateWord();
        }
    }

    void PlayerTakeDamage()
{
    playerHP--;
    UpdateUI();

    if (playerHP <= 0)
    {
        GameOver();
    }
}

    void EnemyTakeDamage()
    {
        enemyHP--;
        UpdateUI();

        if (enemyHP <= 0)
        {
            NextRound();
        }
    }

    void UpdateUI()
    {
        playerHPText.text = "Player HP: " + playerHP;
        enemyHPText.text = "Enemy HP: " + enemyHP;
    }

    void NextRound()
    {
        currentRound++;
        Debug.Log("Next Round: " + currentRound);
        StartRound();
    }
    void GameOver()
{
    inputField.interactable = false;

    if (gameOverPanel != null)
        gameOverPanel.SetActive(true);

    Invoke("GoToMainMenu", 2f); // tunggu 2 detik
}

void GoToMainMenu()
{
    SceneManager.LoadScene("MainMenu");
}
}
