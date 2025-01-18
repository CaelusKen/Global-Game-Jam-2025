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

    private void Awake()
    {
        worlds = (GameObject.FindObjectsByType<MapLink>(FindObjectsSortMode.None));
        TextMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {
<<<<<<< HEAD
        worlds = (GameObject.FindObjectsByType<MapLink>(FindObjectsSortMode.None));
        int worldInt = Random.Range(0, worlds.Length);

        
        nextWorld = worlds[worldInt].gameObject;
        if (nextWorld == currentWorld)
=======
        int worldInt = Random.Range(-1, worlds.Length);
        if (worldInt < 0)
>>>>>>> 1b7f13e22d386d0549942f7ca083e0d7dc0502e2
        {
            nextWorld = GameManager.instance.theVoid;
        }
<<<<<<< HEAD
        
        TextMeshPro.text = nextWorld.name;
    }
    public void OnCollisionEnter(Collision collision)
=======
        else
        {
            world = worlds[worldInt].gameObject;
        }
        TextMeshPro.text = world.name;
        _prompt = TextMeshPro.text;
    }

    public string InteractionPrompt => _prompt;

    public void OnTriggerEnter(Collider collision)
>>>>>>> 1b7f13e22d386d0549942f7ca083e0d7dc0502e2
    {
        Debug.Log("Va chạm với: " + collision.gameObject.name);
        ThirdPersonController player = collision.gameObject.GetComponent<ThirdPersonController>();
        if (player)
        {
            if (player.IsBubble)
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
            } else
            {
                player.TeleportToMap(nextWorld);
            }
           
        }
    }

    public bool Interact(PlayerInteractor interactor)
    {
        Debug.Log("Tương tác với " + _prompt);
        return true;
    }
}
