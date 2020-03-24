using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField]
    float distance;
    Camera cam;
    float pixelHeight;
    float pixelWidth;
    float deltaY;
    float maxY = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        UpdateCameraPosition();


    }
    public void UpdateCameraPosition()
    {
        pixelHeight = Mathf.Max(Screen.height, Screen.width);
        pixelWidth = Mathf.Min(Screen.height, Screen.width);
        cam.orthographicSize = (pixelHeight / pixelWidth) * 5.34f;
            //2.65f;// * displayScaleInverse;
    }
#if UNITY_EDITOR
    private void Update()
    {
        UpdateCameraPosition();
    }
#endif

}
