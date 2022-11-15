using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTags : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] List<string> tags = new List<string>();
    [SerializeField] GameObject particle;

    private void OnTriggerEnter(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            if (other.GetComponent<Health>() != null)
            {
                other.GetComponent<Health>().DealDamage(damage);
            }
            else if (other.GetComponent<HealthReference>() != null)
            {
                other.GetComponent<HealthReference>().DealDamage(damage);
            }
            if (particle != null)
            {
                Instantiate(particle,transform.position,Quaternion.identity);
            }
        }
    }
}
