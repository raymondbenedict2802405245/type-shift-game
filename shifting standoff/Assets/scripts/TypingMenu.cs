using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TypingMenu : MonoBehaviour
{
    public TMP_InputField inputField;

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
            SceneManager.LoadScene("PlayScene");
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
