using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public ItemSO itemSO;
    public Image icon;
    public TextMeshProUGUI quantityTxt;
    public int quantity { get; private set; }

    private void Awake()
    {
        icon = GetComponentInChildren<Image>();
        quantityTxt = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void SetItem(ItemSO itemSO)
    {
        this.itemSO = itemSO;
        icon.sprite = itemSO.sprite;
    }
    public void AddItem(int amount)
    {
        quantity += amount;
        quantityTxt.text = quantity.ToString();
    }
    public bool ReduceItem(int amount)
    {
        if (amount > quantity) {return false;}
        quantity -= amount;
        quantityTxt.text = quantity.ToString();
        return true;
    }
}
