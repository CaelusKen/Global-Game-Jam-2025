using System;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Action _onYesAction;
    public void SetText(string text)
    {
        _text.text = text;
    }
    public void SetYesAction(Action onYesAction)
    {
        _onYesAction += onYesAction;
    }

    // Gọi khi nút Yes được nhấn
    public void YesButton()
    {
        Debug.Log(_onYesAction.Method);
        _onYesAction?.Invoke(); // Thực thi hành động nếu không null
        ClosePopup(); // Đóng popup sau khi nhấn
    }
    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}
