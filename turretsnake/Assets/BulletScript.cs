using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float dmg;
    [SerializeField] float lifetime;

    [SerializeField] float projectileVelocity;
    [SerializeField] Rigidbody rb;
    private void Awake()
    {
        Destroy(gameObject, lifetime);
        rb.AddForce(-transform.up * projectileVelocity,ForceMode.Impulse);
    }

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
        Debug.Log("Hit " + g.name);
    }


}
