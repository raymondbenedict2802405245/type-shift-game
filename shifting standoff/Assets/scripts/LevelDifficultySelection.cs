using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelDifficultySelection : MonoBehaviour
{
    public TMP_InputField inputField;
    private AudioManager audioManager;

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

        if (command == "tutorial")
        {   AudioManager.instance.stopgameBGM();
            SceneManager.LoadScene("tutorial");
        }
        if (command == "basic")
        {   AudioManager.instance.stopgameBGM();
            SceneManager.LoadScene("basic");
        }
        if (command == "moderate")
        {   AudioManager.instance.stopgameBGM();
            SceneManager.LoadScene("moderate");
        }
        if (command == "advanced")
        {   AudioManager.instance.stopgameBGM();
            SceneManager.LoadScene("advanced");
        }
        if (command == "conscientious")
        {   AudioManager.instance.stopgameBGM();
            SceneManager.LoadScene("conscientious");
        }
        if (command == "endless mode")
        {   AudioManager.instance.stopgameBGM();
            SceneManager.LoadScene("endless");
        }

        inputField.text = "";
        inputField.ActivateInputField();
    }
}
