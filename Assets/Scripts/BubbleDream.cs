using StarterAssets;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleDream : MonoBehaviour, IInteractable
{

    public GameObject nextWorld;
    public GameObject currentWorld => this.transform.root.gameObject;

    private MapLink[] worlds;
    private TextMeshPro TextMeshPro;

    private string _prompt;
    private ItemSO dreamStair => Resources.Load<ItemSO>("SO/Dream Stair");

    private void Awake()
    {
        worlds = (GameObject.FindObjectsByType<MapLink>(FindObjectsSortMode.None));
        TextMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {
        worlds = (GameObject.FindObjectsByType<MapLink>(FindObjectsSortMode.None));
        int worldInt = Random.Range(0, worlds.Length);

        
        nextWorld = worlds[worldInt].gameObject;
        if (nextWorld == currentWorld)
        {
            nextWorld = GameManager.instance.theVoid;
        }
        
        TextMeshPro.text = nextWorld.name;
        _prompt = TextMeshPro.text;
    }

    public string InteractionPrompt => _prompt ;


    public bool Interact(PlayerInteractor interactor)
    {

        ThirdPersonController player = interactor.gameObject.GetComponent<ThirdPersonController>();
        if (player && InventoryUI.inventoryUI.GetQuantityOfItem(dreamStair) > 0)
        {
            if (player.IsBubble)
            {
                int index = transform.root.GetComponent<MapLink>().GetBubble(this);
                
                if (index >= 0)
                {
                    for (int i = 0; i < worlds.Length; i++)
                    {
                        worlds[i].GetBubble(index).gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                player.TeleportToMap(nextWorld);
            }
            InventoryUI.inventoryUI.ReduceItem(dreamStair, 1);
        }
        return true;
    }
}
