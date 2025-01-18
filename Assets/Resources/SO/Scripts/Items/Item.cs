using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public ItemSO ItemSO;
    public string InteractionPrompt => this.name;

    public bool Interact(PlayerInteractor interactor)
    {
        InventoryUI.inventoryUI.AddItem(ItemSO, 1);
        this.gameObject.SetActive(false);
        return true;
    }
}
