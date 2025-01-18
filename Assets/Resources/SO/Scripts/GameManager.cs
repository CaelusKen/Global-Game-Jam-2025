using StarterAssets;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private GameObject player => GameObject.FindGameObjectWithTag("Player");
    private ThirdPersonController _playerControl => player.GetComponent<ThirdPersonController>();
    public GameObject record => transform.Find("Record").gameObject;
    public GameObject theVoid => transform.Find("The Void").gameObject;
    public Transform firstSpawn => transform.Find("FirstSpawn");

    public int max_record = 4;

    private MapLink[] maps;

    public Action OnWin;
    public enum GameState
    {
        Playing,
        Hover,
        Pause,
        Viewing,
        Win,
    }
    [SerializeField] public GameState state {  get; private set; }

    private void Awake()
    {
        if (instance == null)
        instance = this;

        OnWin += HandleOnWin;
        maps = GameObject.FindObjectsByType<MapLink>(FindObjectsSortMode.None);
    }

    private void Start()
    {
        SetState(GameState.Playing);
        player.transform.position = firstSpawn.position;
        for (int i = 0; i < 4; i++)
        {
            Vector3 pos = RandomTarget().position + new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5));
            GameObject newRecord =  Instantiate(record, pos, Quaternion.identity);
            newRecord.SetActive(true);
        }
    }
    private void HandleOnWin()
    {
        //
    }
    private Transform RandomTarget()
    {
        MapLink ranMap = maps[Random.Range(0, maps.Length)];
        BubbleDream ranBubble = ranMap.bubbles[Random.Range(0, ranMap.maxBubbles)];
        return ranBubble.transform;
    }
    public void SetState(GameState state)
    {
        this.state = state;
        switch (state)
        {
            case GameState.Playing:
                _playerControl.SetMove(true);
                break;
            case GameState.Hover:   
                _playerControl.SetMove(true);
                break;
            case GameState.Pause:
                _playerControl.SetMove(false);
                break;
            case GameState.Viewing:
                _playerControl.SetMove(false);
                break;
        }
    }
}
