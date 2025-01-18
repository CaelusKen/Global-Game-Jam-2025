using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private GameObject _interactionUIPanel;
    [SerializeField] private TextMeshProUGUI _interactionPromptText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _interactionUIPanel.SetActive(false);
    }

    public bool IsDisplayed = false;

    public void Setup(string prompt) {
        _interactionPromptText.text = prompt;
        _interactionUIPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Hide() {
        _interactionUIPanel.SetActive(false);
        IsDisplayed = false;
    }
}
