using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float healthMax;

    [SerializeField] GameObject lootObject;
    [SerializeField] GameObject particleObject;
    bool dead;

    public float GetHealth()
    {
        return health;
    }
    public float GetMaxHealth()
    {
        return healthMax;
    }

    public void DealDamage(float dmg)
    {
        health -= dmg;
        if (health < 0 && !dead)
        {
            Die();
            dead = true;
        }
    }

    private void Die()
    {

        if (lootObject != null)
        {
            Instantiate(lootObject, new Vector3((int)transform.position.x, transform.position.y, (int)transform.position.z), Quaternion.identity);
        }
        if (particleObject != null)
        {
            Instantiate(particleObject, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

}
