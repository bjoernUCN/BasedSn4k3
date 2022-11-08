using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health;

    public void DealDamage(float dmg)
    {
        health -= dmg;
        if (health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
