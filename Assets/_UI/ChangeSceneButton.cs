using UnityEngine;

public class ChangeSceneButton : MonoBehaviour
{
    public void LoadScene2(string sceneName)
    {
        LevelManager.Instance.LoadScene(sceneName);
    }

  
}
