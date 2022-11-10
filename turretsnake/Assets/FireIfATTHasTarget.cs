using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireIfATTHasTarget : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float weaponCooldown;
    [SerializeField] AimTowardsTags aimTowardsTags;

    float _timer;
    
    void Update()
    {
        if (_timer > weaponCooldown && aimTowardsTags.HasTarget)
        {
            _timer = 0;
            Fire();
        }
        else { _timer += Time.deltaTime; }
    }


    private void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation).GetComponent<SmartBulletScript>().aimTowardsTags = aimTowardsTags;
    }

}
