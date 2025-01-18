using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<ItemUI> items;
    private static InventoryUI _inventoryUI;
    public static InventoryUI inventoryUI => _inventoryUI;
    private ItemSO record => Resources.Load<ItemSO>("SO/Record");
    private void Awake()
    {
        if (_inventoryUI != null)
        {
            Destroy(_inventoryUI);
        }
        _inventoryUI = this;

        items.Clear();
        items.AddRange( GetComponentsInChildren<ItemUI>());
    }

    private void Start()
    {
        items[0].SetItem(Resources.Load<ItemSO>("Bubble Orb"));
        items[1].SetItem(Resources.Load<ItemSO>("Dream Stair"));
    }
    public int GetQuantityOfItem(ItemSO item)
    {
        return GetItemUI(item).quantity;
    }
    public void AddItem(ItemSO item, int amount)
    {
        GetItemUI(item).AddItem(amount);
        if (GetQuantityOfItem(record) == GameManager.instance.max_record)
        {
            GameManager.instance.OnWin?.Invoke();
        }
    }
    public bool ReduceItem(ItemSO item, int amount)
    {
        return GetItemUI(item).ReduceItem(amount);
    }
    private ItemUI GetItemUI(ItemSO item)
    {
        foreach (ItemUI item1 in items)
        {
            if( item1.itemSO == item)
            {
                return item1;
            }
        }
        return null;
    }
}