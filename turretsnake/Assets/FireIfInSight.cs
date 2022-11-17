using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireIfInSight : MonoBehaviour
{
    [SerializeField] List<string> tags = new List<string>();
    [SerializeField] float cooldown, range;
    [SerializeField] GameObject projectile;

    float timer;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.up, out hit, range, 1))
        {
            Debug.DrawLine(transform.position, hit.point);
            if (tags.Contains(hit.transform.tag))
            {
                CountdownToFire();   
            }
        }   
    }

    private void CountdownToFire()
    {
        if (timer > cooldown)
        {
            timer= cooldown;
            Fire();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void Fire()
    {
        Destroy(Instantiate(projectile, transform.position, transform.rotation), 2);
    }
}
