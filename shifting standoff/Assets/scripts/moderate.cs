using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class moderate : MonoBehaviour
{
    [Header("HP Settings")]
    public int playerHP = 10;
    public int playerHearts = 10;
    public int enemyHP = 10;

    public int enemyHearts = 10; 

    public Image[] heartsPlayer;
    public Image[] heartsEnemy;
    public Sprite fullHeart;
    public Sprite emptyHeart;

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

    [SerializeField] public Animator animatorPlayer;
    [SerializeField] public Animator animatorDummy;
    private AudioManager audioManager;

private List<string> wordList = new List<string>()
{
    "Abate",
    "Adjudicate",
    "Assimilate",
    "Remonstrate",
    "Obey",
    "Broadcast",
    "Oppose",
    "Participate",
    "Promote",
    "Report",
    "Radiate",
    "Scratch",
    "Tear",
    "Violate",
    "Adroit",
    "Amicable",
    "Benevolent",
    "Considerable",
    "Biological",
    "Balanced",
    "Academic",
    "Logical",
    "Long-term",
    "Magnificent",
    "Miserable",
    "Ridiculous",
    "Romantic",
    "Aberration",
    "Abbreviation",
    "Adversity",
    "Apprehension",
    "Connotation",
    "Determination",
    "Examination",
    "Frequency",
    "Greenhouse",
    "Imagination",
    "Institution",
    "Kindergarten",
    "Questionnaire"
};

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    void Start()
    {
        StartRound();
        AudioManager.instance.playgameBGM();
    }
    void Update()
    {
        // Stop semua logic kalau game sudah selesai
        if (!inputField.interactable) return;

        TimerCountdown();
        CheckTyping();


        for (int i = 0; i< heartsPlayer.Length; i++)
        {   if(i < playerHP)
            {
                heartsPlayer[i].sprite = fullHeart;
            }
            else
            {
                heartsPlayer[i].sprite = emptyHeart;
            }
            
            if(i < playerHearts)
            {
                heartsPlayer[i].enabled = true;
            }
            else
            {
                heartsPlayer[i].enabled = false;
            }
               
        }

    
        for (int i = 0; i< heartsEnemy.Length; i++)
        {   if(i < enemyHP)
            {
                heartsEnemy[i].sprite = fullHeart;
            }
            else
            {
                heartsEnemy[i].sprite = emptyHeart;
            }
            
            if(i < enemyHearts)
            {
                heartsEnemy[i].enabled = true;
            }
            else
            {
                heartsEnemy[i].enabled = false;
            }
               
        }
    }

    void StartRound()
    {
        playerHP = 10;
        enemyHP = 10;

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
        animatorDummy.ResetTrigger("Attack");
        audioManager.playGunshot();
        animatorDummy.SetTrigger("Attack");
        
        animatorPlayer.ResetTrigger("TakeDmg");
        animatorPlayer.SetTrigger("TakeDmg");
        audioManager.playerDmg();

        playerHP--;
        UpdateUI();

        if (playerHP <= 0)
        {
            GameOver();
        }
    }

    void EnemyTakeDamage()
    {
        animatorPlayer.ResetTrigger("Attack");
        audioManager.playGunshot();
        animatorPlayer.SetTrigger("Attack");

        animatorDummy.ResetTrigger("TakeDmg");
        animatorDummy.SetTrigger("TakeDmg");
        audioManager.enemyDmg();

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
            AudioManager.instance.stopgameBGM();
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
        AudioManager.instance.stopgameBGM();
        SceneManager.LoadScene("MainMenu");
    }
}