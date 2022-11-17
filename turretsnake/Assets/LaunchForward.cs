using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchForward : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    private void Awake()
    {
        rb.AddForce(transform.up * speed,ForceMode.Impulse);
    }


}
