using Boo.Lang.Environments;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightIntensity(float restore)
    {
        myLight.intensity += restore;
    }

    public void RestoreLightAngle(float restore)
    {
        myLight.spotAngle = restore;
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay*Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        myLight.spotAngle = (myLight.spotAngle <= minimumAngle) ? minimumAngle : myLight.spotAngle - angleDecay*Time.deltaTime;
    }
}
