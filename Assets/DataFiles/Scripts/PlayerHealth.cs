using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int maxHealth = 100;
    [SerializeField] int health;

    // Start is called before the first frame update

    private void Awake()
    {
        health = maxHealth;
    }

    public void Damage(int hit)
    {
        health -= hit;
        CheckStatus();
    }

    void CheckStatus()
    {
        if (health <= 0)
        {
            print("Youre dead!");
        }
        else
        {
            print("Remaing health: " + health);
        }
    }
}
