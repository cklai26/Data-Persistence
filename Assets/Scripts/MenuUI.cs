using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Import TextMeshPro namespace
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TMP_InputField NameInputField; // Reference to TMP_InputField for the player name

    public void StartNew()
    {
        // Save the entered player name to PlayerNameManager
        string playerName = NameInputField.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerNameManager.Instance.PlayerName = playerName;
            SceneManager.LoadScene(1); // Load the main game scene
        }
        else
        {
            Debug.LogWarning("Player name cannot be empty.");
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // Original code to quit Unity player
#endif
    }
}
