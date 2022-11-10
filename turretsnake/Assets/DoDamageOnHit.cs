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
        //ToDo
        g.GetComponent<Health>().DealDamage(dmg);
        //Debug.Log("Hit " + g.name);
    }
}
