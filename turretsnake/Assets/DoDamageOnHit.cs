using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamageOnHit : MonoBehaviour
{

    [SerializeField] float dmg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DoDamage(other.gameObject);
        }
    }

    private void DoDamage(GameObject g)
    {
        if(g.GetComponent<Health>())
            g.GetComponent<Health>().DealDamage(dmg);
        if(g.GetComponent<HealthReference>())
            g.GetComponent<HealthReference>().DealDamage(dmg);
    }
}
