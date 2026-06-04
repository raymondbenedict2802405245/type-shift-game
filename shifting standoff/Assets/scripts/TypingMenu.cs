using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TypingMenu : MonoBehaviour
{
    public TMP_InputField inputField;

    void Start()
    {
        // Fokus langsung ke input field saat scene mulai
        inputField.ActivateInputField();
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
        else if (command == "settings")
        {
            SceneManager.LoadScene("settings");
        }
        else if (command == "quit")
        {
            Application.Quit();
            Debug.Log("Game Closed");
        }

        // Reset dan tetap fokus ke input field
        inputField.text = "";
        inputField.ActivateInputField();
    }
}
