using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject creckBox;
    
    public void TakeDamage (float amount)
    {
        health -= amount;

        if(health <= 0f)
        {
            creckBox.SetActive(true);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
