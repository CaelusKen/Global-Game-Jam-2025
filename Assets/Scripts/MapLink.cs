using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.LightTransport;

public class MapLink : MonoBehaviour
{
    public List<BubbleDream> bubbles;
    private TextMeshPro TextMeshPro;

    private void Awake()
    {
        bubbles.AddRange(GetComponentsInChildren<BubbleDream>());
        TextMeshPro = GetComponentInChildren<TextMeshPro>();
    }
    private void Start()
    {
        
        TextMeshPro.text = "This is " + this.name;
    }
    public int GetBubble(BubbleDream bubble)
    {
        return bubbles.IndexOf(bubble);
    }
    public BubbleDream GetBubble(int bubble)
    {
        return bubbles[bubble];
    }
}
