using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelDifficultySelection : MonoBehaviour
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

        if (command == "basic")
        {
            SceneManager.LoadScene("basic");
        }
        if (command == "moderate")
        {
            SceneManager.LoadScene("moderate");
        }
        if (command == "advanced")
        {
            SceneManager.LoadScene("advanced");
        }
        if (command == "conscientious")
        {
            SceneManager.LoadScene("conscientious");
        }

        inputField.text = "";
        inputField.ActivateInputField();
    }
}
