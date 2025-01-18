using StarterAssets;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private GameObject player => GameObject.FindGameObjectWithTag("Player");
    private ThirdPersonController _playerControl => player.GetComponent<ThirdPersonController>();
    public GameObject targetPoint;
    public GameObject theVoid;
    private MapLink[] maps;
    public enum GameState
    {
        Playing,
        Hover,
        Pause,
        Viewing,
    }
    [SerializeField] public GameState state {  get; private set; }

    private void Awake()
    {
        if (instance == null)
        instance = this;

        maps = GameObject.FindObjectsByType<MapLink>(FindObjectsSortMode.None);
    }

    private void Start()
    {
        SetState(GameState.Playing);
        targetPoint.transform.position =
            maps[Random.Range(0,maps.Length)].bubbles[Random.Range(0, maps.Length)].transform.position;  
    }
    public void ToggleView()
    {
        if (state != GameState.Viewing) 
        SetState(GameState.Viewing);
        else SetState(GameState.Playing);
    }
    public void ToggleHover()
    {
        if (state != GameState.Hover)
            SetState(GameState.Hover);
        else SetState(GameState.Playing);
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
