using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TypingMenu : MonoBehaviour
{
    public TMP_InputField inputField;
    private AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    void Start()
    {
        AudioManager.instance.playLobbyBGM();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckInput();
        }
    }

    void CheckInput()
    {
        string command = inputField.text.ToLower();

        if (command == "play")
        {
            SceneManager.LoadScene("LevelDifficulty");
        }
        if (command == "settings")
        {
            SceneManager.LoadScene("settings");
        }
        else if (command == "exit")
        {
            Application.Quit();
            Debug.Log("Game Closed");
        }

        inputField.text = "";
        inputField.ActivateInputField();
    }
}
