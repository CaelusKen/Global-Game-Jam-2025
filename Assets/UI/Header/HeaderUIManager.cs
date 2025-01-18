using UnityEngine;
using UnityEngine.UIElements;

public class HeaderUIManager : MonoBehaviour
{
    private VisualElement root;
    private Button inventoryButton;
    private Button settingsButton;
    private VisualElement inventoryDialog;
    private VisualElement settingsDialog;

    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        if (root == null)
        {
            Debug.LogError("Root VisualElement is null. Check your UXML setup.");
            return;
        }

        // Query the container
        var container = root.Q<VisualElement>("container");
        if (container == null)
        {
            Debug.LogError("Container not found! Check its ID in the UXML file.");
            return;
        }

        // Query the buttons inside the container
        inventoryButton = container.Q<Button>("inventoryButton");
        settingsButton = container.Q<Button>("settingsButton");

        if (inventoryButton == null)
            Debug.LogError("Inventory button not found! Check its ID in the UXML file.");
        if (settingsButton == null)
            Debug.LogError("Settings button not found! Check its ID in the UXML file.");

        // Query dialogs
        inventoryDialog = root.Q<VisualElement>("inventoryDialog");
        settingsDialog = root.Q<VisualElement>("settingsDialog");

        if (inventoryDialog == null)
            Debug.LogError("Inventory dialog not found! Check its ID in the UXML file.");
        if (settingsDialog == null)
            Debug.LogError("Settings dialog not found! Check its ID in the UXML file.");

        // Set up button events
        if (inventoryButton != null) inventoryButton.clicked += OpenInventory;
        if (settingsButton != null) settingsButton.clicked += OpenSettings;

        if (inventoryDialog != null) inventoryDialog.style.display = DisplayStyle.None;
        if (settingsDialog != null) settingsDialog.style.display = DisplayStyle.None;

        // Query and set up close buttons
        var closeInventoryButton = root.Q<Button>("closeInventory");
        var closeSettingsButton = root.Q<Button>("closeSettings");

        if (closeInventoryButton != null) closeInventoryButton.clicked += CloseDialogs;
        if (closeSettingsButton != null) closeSettingsButton.clicked += CloseDialogs;

        root.RegisterCallback<KeyDownEvent>(evt =>
        {
            // Check for the specific key press (e.g., 'I' for inventory and 'S' for settings)
            if (evt.keyCode == KeyCode.I)
            {
                OpenInventory();
            }
            else if (evt.keyCode == KeyCode.Q)
            {
                OpenSettings();
            }
        });

    }

    private void OpenInventory()
    {
        PauseGame();
        inventoryDialog.style.display = DisplayStyle.Flex;
    }

    private void OpenSettings()
    {
        PauseGame();
        settingsDialog.style.display = DisplayStyle.Flex;
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
    }

    public void CloseDialogs()
    {
        ResumeGame();
        inventoryDialog.style.display = DisplayStyle.None;
        settingsDialog.style.display = DisplayStyle.None;
    }
}
