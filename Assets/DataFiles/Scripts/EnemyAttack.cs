using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] GameObject target;
    [SerializeField] int damage = 40;

    public void Attack(){
        print("Attack");
    }



}
