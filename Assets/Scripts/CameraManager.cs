using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera; // 假设这个变量已经在Inspector中关联了主相机  
    public float zoomSpeed = 0.1f; // 缩放速度  

    void Update()
    {
        // 假设你想要通过某个按键（比如鼠标滚轮向上）来放大相机视野  
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            // 增加orthographicSize的值以放大视野  
            mainCamera.orthographicSize += zoomSpeed;
            // 确保orthographicSize不会变得过大  
            mainCamera.orthographicSize = Mathf.Min(mainCamera.orthographicSize, 20);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            // 减小orthographicSize的值以缩小视野  
            mainCamera.orthographicSize -= zoomSpeed;
            // 确保orthographicSize不会变得过小  
            mainCamera.orthographicSize = Mathf.Max(mainCamera.orthographicSize, 5);
        }
    }
}
