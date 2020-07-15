using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        ActiveNextWeapon();
    }

    void ActiveNextWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            weaponSlot[activeWeapon].gameObject.SetActive(false);
            activeWeapon++;

            if (activeWeapon == weaponSlot.Count)
                activeWeapon = 0;
            else if (activeWeapon < -1)
                activeWeapon = weaponSlot.Count - 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSlot[activeWeapon].gameObject.SetActive(false);
            activeWeapon = 0;
            weaponSlot[activeWeapon].gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponSlot[activeWeapon].gameObject.SetActive(false);
            activeWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            
            activeWeapon = 2;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            weaponSlot[activeWeapon].gameObject.SetActive(false);

            if (activeWeapon >= weaponSlot.Count - 1)
                activeWeapon = 0;
            else
                activeWeapon++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            weaponSlot[activeWeapon].gameObject.SetActive(false);

            if (activeWeapon <= 0)
                activeWeapon = weaponSlot.Count - 1;
            else
                activeWeapon--;
        }

        weaponSlot[activeWeapon].gameObject.SetActive(true);

    }



}
