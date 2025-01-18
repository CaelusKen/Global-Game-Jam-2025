using StarterAssets;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleDream : MonoBehaviour, IInteractable
{
    public GameObject world;
    private MapLink[] worlds;
    private TextMeshPro TextMeshPro;

    private string _prompt;

    private void Awake()
    {
        worlds = (GameObject.FindObjectsByType<MapLink>(FindObjectsSortMode.None));
        TextMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {
        int worldInt = Random.Range(-1, worlds.Length);
        if (worldInt < 0)
        {
            world = GameManager.instance.theVoid;
        }
        else
        {
            world = worlds[worldInt].gameObject;
        }
        TextMeshPro.text = world.name;
        _prompt = TextMeshPro.text;
    }

    public string InteractionPrompt => _prompt;

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Va chạm với: " + collision.gameObject.name);

        if (collision.gameObject.layer == LayerMask.NameToLayer("Bubble"))
        {
            int index = transform.root.GetComponent<MapLink>().GetBubble(this);
            Debug.Log(index);
            if (index >= 0)
            {
                for (int i = 0; i < worlds.Length; i++)
                {
                    worlds[i].GetBubble(index).gameObject.SetActive(false);
                }
            }
        } else if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ThirdPersonController controller =  collision.GetComponent<ThirdPersonController>();
            controller.TeleportToMap(world);
        }
    }

    public bool Interact(PlayerInteractor interactor)
    {
        Debug.Log("Tương tác với " + _prompt);
        return true;
    }
}
