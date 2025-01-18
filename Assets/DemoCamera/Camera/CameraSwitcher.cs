using UnityEngine;
using Cinemachine;
using DG.Tweening;
using System.Collections.Generic;
using StarterAssets;
public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private static CameraSwitcher _instance;
    public static CameraSwitcher Instance => _instance;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
        cameras.Clear();  // Xóa dữ liệu cũ để tránh trùng lặp
        cameras.AddRange(GetComponentsInChildren<CinemachineVirtualCamera>());
    }
    [SerializeField] List<CinemachineVirtualCamera> cameras;
    // Cinemachine Cameras
    public int activeCamera = 0;

  
    public void HideCam()
    {
        foreach (var item in cameras)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void ShowCam(int camIndex)
    {
        HideCam();
        cameras[camIndex].gameObject.SetActive(true);
    }

}
