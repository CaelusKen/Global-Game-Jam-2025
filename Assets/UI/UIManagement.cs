using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManagement : MonoBehaviour
{
    public static UIManagement Instance;
    [SerializeField] private List<Canvas> _screen;
    [SerializeField] private Popup popup;

    private void Awake()
    {
        if (Instance != null) { 
            Destroy(Instance);
        }
        Instance = this;
    }

    public void CallPopup(string content, Action method)
    {
        popup.SetText(content);
        popup.SetYesAction(method);
        popup.gameObject.SetActive(true);
    }
 }
