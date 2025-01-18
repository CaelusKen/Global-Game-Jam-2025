using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class HomeUI : MonoBehaviour
{
    private VisualElement root;
    private Button startButton;
    private Button settingsButton;
    private VisualElement buttonContainer;
    private Button exitButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        
        buttonContainer = root.Q<VisualElement>("button-container");

        startButton = buttonContainer.Q<Button>("start-button");
        settingsButton = buttonContainer.Q<Button>("settings-button");
        exitButton = buttonContainer.Q<Button>("exit-button");

        if (startButton != null) startButton.clicked += StartGame;
        if (settingsButton != null) settingsButton.clicked += OpenSettings;
        if (exitButton != null) exitButton.clicked += QuitGame;
    }

    // Start the game
    private void StartGame()
    {
        SceneManager.LoadScene("LevelSetup");
    }

    // Open the settings menu
    private void OpenSettings()
    {
        SceneManager.LoadScene("Settings_Scene");
    }

    // Quit the game
    private void QuitGame()
    {
        Application.Quit();
    }
}
