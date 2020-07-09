using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int fullHealth = 100;
    int remainningHealth;

    private void Start()
    {
        remainningHealth = fullHealth;
    }

    public void Hit(int hit)
    {

        remainningHealth -= hit;
        CheckStatus();
        BroadcastMessage("OnDamageTaken");
    }

    void CheckStatus()
    {
        if (remainningHealth<=0)
        {
            ///Destroy(gameObject);
            GetComponent<Animator>().SetTrigger("Die");
            SendMessage("Die");
        }
        print(remainningHealth);
    }
}
