using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    PlayerHealth target;
    [SerializeField] int damage = 40;


    private void Awake()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void Attack(){
        target.Damage(damage);
        target.GetComponent<DisplayDamage>().DisplayDamageUI();
        print("Attack");
    }



}
