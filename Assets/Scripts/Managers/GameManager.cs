using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        Playing,
        Pause,
        Viewing,
    }
    [SerializeField] public GameState state {  get; private set; }

    private void Awake()
    {
        if (instance == null)
        instance = this;
    }

    private void Start()
    {
        this.state = GameState.Playing;

    }

    public void SetState(GameState state)
    {
        this.state = state;
    }
}
