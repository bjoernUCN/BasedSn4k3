using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    
    [SerializeField] float weaponCooldown;

   
    float _timer;

    // Update is called once per frame
    void Update()
    {
        if (_timer > weaponCooldown)
        {
            _timer = 0;
            Fire();
        }
        else { _timer+=Time.deltaTime; }
    }

    private void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }

}
