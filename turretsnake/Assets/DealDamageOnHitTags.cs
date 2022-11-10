using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnHitTags : MonoBehaviour
{
    AimTowardsTags aimTowardsTags;
    [SerializeField] float damage;

    private void Start()
    {
        aimTowardsTags = GetComponent<SmartBulletScript>().aimTowardsTags;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (aimTowardsTags.tags.Contains(other.tag))
        {
            if (other.GetComponent<Health>() != null)
            {
                other.GetComponent<Health>().DealDamage(damage);
            } else if (other.GetComponent<HealthReference>() != null)
            {
                other.GetComponent<HealthReference>().DealDamage(damage);
            }
        }
    }
}
