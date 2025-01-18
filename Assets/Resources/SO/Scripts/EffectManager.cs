using Unity.VisualScripting;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private Camera _mainCamera;

    [SerializeField] private static EffectManager _instance;
    public static EffectManager Instance => _instance;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera")?.GetComponent<Camera>();
    }
    public void TeleportEffect()
    {
        
    }
}
