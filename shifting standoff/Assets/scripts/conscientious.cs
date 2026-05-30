using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class conscientious : MonoBehaviour
{
    [Header("HP Settings")]
    public int playerHP = 3;
    public int enemyHP = 3;

    [Header("Game Over")]
    public GameObject gameOverPanel;

    [Header("Victory")]
    public GameObject victoryPanel;
    public int maxRound = 5;

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
    "Hippopotomonstrosesquippedaliophobia",
    "Antidisestablishmentarianism",
    "Pneumonoultramicroscopicsilicovolcanoconiosis",
    "Supercalifragilisticexpialidocious",
    "Pseudo-pseudohypoparathyroidism",
    "Floccinaucinihilipilification",
    "Spectrophotofluorometrically",
    "Eellogofusciouhipoppokunurious",
    "Disproportionableness",
    "Counterrevolutionaries",
    "Honorificabilitudinitatibus",
    "Demisemihemidemisemiquaver",
    "Cottonshopeburnfoot",
    "Over-numerousness",
    "Onomatopoeia",
    "Un Feuilleton",
    "Pococurante",
    "Succedaneum",
    "Chiaroscurist",
    "Sacrilegious",
    "Conscientious",
    "Schmaltzy",
    "Uncopyrightable",
    "Dermatoglyphic",
    "Cinematographic",
    "Chromatographic",
    "Spermatogenesis",
    "Twyndyllyngs",
    "Abstemiously",
    "Affectionally",
    "Fracedinously",
    "Gads-preciously",
    "Facetiously",
    "Sub-dermatoglyphic",
    "Scraunched",
    "Euouae",
    "Aegilops",
    "Palindromic",
    "Agglutinative"
};


    void Start()
    {
        StartRound();
    }

    void Update()
    {
        // Stop semua logic kalau game sudah selesai
        if (!inputField.interactable) return;

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
        inputField.interactable = true;
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

        // Salah huruf
        if (!currentWord.StartsWith(typed))
        {
            PlayerTakeDamage();
            inputField.text = "";
        }

        // Kata benar
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

        if (currentRound > maxRound)
        {
            Victory();
            SceneManager.LoadScene("LevelDifficulty");
        }

        Debug.Log("Next Round: " + currentRound);
        StartRound();
    }

    void GameOver()
    {
        inputField.interactable = false;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Invoke("GoToMainMenu", 2f);
    }

    void Victory()
    {
        inputField.interactable = false;

        if (victoryPanel != null)
            victoryPanel.SetActive(true);

        Invoke("GoToMainMenu", 2f);
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}