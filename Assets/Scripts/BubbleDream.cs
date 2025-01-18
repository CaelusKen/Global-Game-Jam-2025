using StarterAssets;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleDream : MonoBehaviour
{
    public GameObject world;
    private MapLink[] worlds;
    private TextMeshPro TextMeshPro;
    private void Awake()
    {
        TextMeshPro = GetComponentInChildren<TextMeshPro>();
    }
    private void Start()
    {
        worlds = (GameObject.FindObjectsByType<MapLink>(FindObjectsSortMode.None));
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
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bubble")
        {
            int index = world.GetComponent<MapLink>().GetBubble(this);
            if (index >= 0)
            {
                for (int i = 0; i < worlds.Length; i++)
                {
                    worlds[i].GetBubble(index).gameObject.SetActive(false);
                }
            }
            Debug.Log(index);
            
        }
    }
}
