using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScript : MonoBehaviour
{
    
    [SerializeField] float lifetime;

    [SerializeField] float projectileVelocity;
    [SerializeField] Rigidbody rb;
    private void Awake()
    {
        Destroy(gameObject, lifetime);
        rb.AddForce(-transform.up * projectileVelocity,ForceMode.Impulse);
    }


}
