using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera; // 在Inspector中设置主相机  
    public float zoomSpeed = 0.1f; // 缩放速度  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // 滚轮向前滚动  
        {
            mainCamera.fieldOfView -= zoomSpeed; // 缩小视场角，放大界面  
            mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, 1f, 120f); // 限制视场角范围  
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // 滚轮向后滚动  
        {
            mainCamera.fieldOfView += zoomSpeed; // 增大视场角，缩小界面  
            mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, 1f, 120f); // 限制视场角范围  
        }
    }
}
