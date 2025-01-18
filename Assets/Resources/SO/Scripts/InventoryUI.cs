using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    [SerializeField] private List<ItemSO> itemSOs ;
    [SerializeField] private List<ItemUI> items;
    [SerializeField] private Transform itemSlotTemplate;
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
     
        itemSlotTemplate = transform.Find("itemSlotTemplate");
        itemSlotTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        itemSOs.AddRange(Resources.LoadAll<ItemSO>("SO"));
        Debug.Log(itemSOs.Count);

        foreach (ItemSO item in itemSOs)
        {
            ItemUI newItem = Instantiate(itemSlotTemplate).GetComponent<ItemUI>();
            newItem.SetItem(item);
            newItem.transform.SetParent(transform, false);
            newItem.gameObject.SetActive(true);
            items.Add(newItem);
            Debug.Log(newItem.itemSO);
        }
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
        foreach (ItemUI itemUI in items)
        {
            if (itemUI.itemSO == item)

                return itemUI;
        }
        return null;
    }
}
