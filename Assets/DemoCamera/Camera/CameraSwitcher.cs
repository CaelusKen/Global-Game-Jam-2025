using UnityEngine;
using Cinemachine;
using DG.Tweening;
using System.Collections.Generic;
using StarterAssets;
public class CameraSwitcher : MonoBehaviour
{

    [SerializeField] List<CinemachineVirtualCamera> cameras;
    // Cinemachine Cameras
    public int activeCamera = 0;

    private void Reset()
    {
        cameras.Clear();  // Xóa dữ liệu cũ để tránh trùng lặp
        cameras.AddRange(GetComponentsInChildren<CinemachineVirtualCamera>());
    }
    private void Start()
    {
        
        cameras[0].Priority = 10;
    }
   
    private void Update()
    {
      
        // Phím 1 → Góc nhìn ngang (Orthographic)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("switch");
            Switch();
        }


    }
    private void HideCam()
    {
        foreach (var cam in cameras)
        {
            cam.Priority = 0;
        }
    }

    

    // Kích hoạt Cinemachine Camera
    private void Switch()
    {
        HideCam();
        activeCamera++;
        if (activeCamera >= cameras.Count)
        {
            activeCamera = 0;
        }
        cameras[activeCamera].Priority = 10;
        if (activeCamera == 0) { 
            GameManager.instance.SetState(GameManager.GameState.Playing);
        }
        if (activeCamera > 0)
        {
            GameManager.instance.SetState(GameManager.GameState.Viewing);
        }
    }
}
