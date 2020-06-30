using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlot; 
    [SerializeField] int ammoAmount = 10;

    [Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType type)
    {
        return FindAmmoByType(type).ammoAmount;
    }

    public void ReduceAmmo(AmmoType type)
    {
        FindAmmoByType(type).ammoAmount--;
    }

    AmmoSlot FindAmmoByType(AmmoType type)
    {
        foreach (var item in ammoSlot)
        {
            if(item.ammoType == type)
            {
                return item;
            }
        }
        return null;
    }


}
