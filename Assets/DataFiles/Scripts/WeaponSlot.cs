using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] List<Weapon> weaponSlot = new List<Weapon>();
    int activeWeapon = 0;

    private void Awake()
    {

        foreach (Transform item in transform)
        {
            weaponSlot.Add(item.GetComponent<Weapon>());
        }
        if (weaponSlot != null) {
            foreach (var item in weaponSlot)
            {
                item.gameObject.SetActive(false);
            }
            weaponSlot[activeWeapon].gameObject.SetActive(true);
        }
        else
        {
            print("No weapon could be found");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeActiveWeapon();
        }
    }

    void ChangeActiveWeapon()
    {
        weaponSlot[activeWeapon].gameObject.SetActive(false);
        activeWeapon++;

        if (activeWeapon == weaponSlot.Count)
            activeWeapon = 0;
        else if (activeWeapon <-1)
            activeWeapon = weaponSlot.Count-1;
        
        weaponSlot[activeWeapon].gameObject.SetActive(true);
    }

    
}
