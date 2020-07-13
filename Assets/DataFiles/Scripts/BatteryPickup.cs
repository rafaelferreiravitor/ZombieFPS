using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float batteryLight = 0.8f;
    [SerializeField] float batteryAngle = 90;

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        if (player.CompareTag("Player"))
        {

            FlashLight flashLight = player.GetComponentInChildren<FlashLight>();
            flashLight.RestoreLightAngle(batteryAngle);
            flashLight.RestoreLightIntensity(batteryLight);
            Destroy(gameObject);

        }
    }

}
