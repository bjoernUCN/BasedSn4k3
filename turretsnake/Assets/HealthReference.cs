using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReference : MonoBehaviour
{
    [SerializeField] Health health;
    public void DealDamage(float dmg)
    {
        health.DealDamage(dmg);
    }
}
