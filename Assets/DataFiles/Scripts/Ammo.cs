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
        public AmmonType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo()
    {
        return ammoAmount;
    }

    public void ReduceAmmo()
    {
        ammoAmount--;
    }


}
