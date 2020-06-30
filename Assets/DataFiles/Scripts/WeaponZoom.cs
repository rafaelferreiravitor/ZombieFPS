using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] float zoomIn = 20f;
    float zoomOut = 60f;
    Camera fpsCamera;

    float ZoomXSensitivity;
    float ZoomYSensitivity;

    float regularXSensitivity;
    float regularYSensitivity;

    RigidbodyFirstPersonController player;

    private void Awake()
    {
        fpsCamera = Camera.main;
        var playerObject = GameObject.FindObjectOfType<RigidbodyFirstPersonController>();
        player = playerObject.GetComponent<RigidbodyFirstPersonController>();

    }

    private void OnDisable()
    {
        if (fpsCamera.fieldOfView == zoomIn)
        {
            ZoomOut();
        }
    }

    private void ZoomOut()
    {
        fpsCamera.fieldOfView = zoomOut;
        player.mouseLook.XSensitivity *= 2f;
        player.mouseLook.YSensitivity *= 2f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (fpsCamera.fieldOfView == zoomOut)
                ZoomIn();
            else
                ZoomOut();

        }
    }

    private void ZoomIn()
    {
        fpsCamera.fieldOfView = zoomIn;
        player.mouseLook.XSensitivity *= 0.5f;
        player.mouseLook.YSensitivity *= 0.5f;
    }
}
