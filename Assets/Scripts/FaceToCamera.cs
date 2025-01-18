using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
   
    private Camera mainCamera;

    void Start()
    {
        // Lấy camera chính trong scene
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (mainCamera != null)
        {
            // Xoay text để luôn hướng về camera
            transform.LookAt(mainCamera.transform);

            // Giữ text không bị ngược, chỉ xoay theo hướng nhìn
            transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);
        }
    }

}
