using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] public Canvas _loaderCanvas;
    [SerializeField] public Image _processBar;
    private float _target = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        
         // Giữ đối tượng qua các scene
    }


    public async void LoadScene(string nameScene)
    {
        _target = 0;
        _processBar.fillAmount = 0;
        if (string.IsNullOrEmpty(nameScene))
        {
            Debug.LogError("Scene name is empty or null.");
            return;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nameScene);
        asyncLoad.allowSceneActivation = false;
        _loaderCanvas.gameObject.SetActive(true);
        do { 
            Debug.Log($"Loading progress: {asyncLoad.progress * 100}%");
            await Task.Delay(100); // Chờ frame tiếp 
            _target = asyncLoad.progress; // Cập nhật thanh tiến 
        } while (asyncLoad.progress < 0.9f);
        await Task.Delay(1000);
        asyncLoad.allowSceneActivation = true;
        _loaderCanvas.gameObject.SetActive(false);
    }
    private void Update()
    {
        _processBar.fillAmount = Mathf.MoveTowards( _processBar.fillAmount, _target, 3 * Time.deltaTime);
    }
}
