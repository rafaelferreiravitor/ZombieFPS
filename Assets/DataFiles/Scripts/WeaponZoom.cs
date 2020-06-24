using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{

    float zoomIn = 20f;
    float zoomOut = 60f;
    Camera fpsCamera;

    private void Awake()
    {
        fpsCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            fpsCamera.fieldOfView = (fpsCamera.fieldOfView == zoomOut) ? zoomIn : zoomOut;
        }
    }
}
