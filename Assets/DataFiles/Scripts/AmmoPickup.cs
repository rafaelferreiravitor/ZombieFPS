using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType = AmmoType.Bullets;

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        if (player.CompareTag("Player"))
        {
            Ammo ammo = player.GetComponent<Ammo>();
            ammo.IncreaseAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
            
        }
    }
}
