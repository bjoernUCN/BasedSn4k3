using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>DeleteOnHitTags</c> GameObject is deleted when trigger enters object with tag in <c>AimTowardsTarget</c>
/// <para>Note: Field "aimTowardsTags" needs to be set immedialy when GameObject is instanciated</para>
/// </summary>
public class DeleteOnHitTags : MonoBehaviour
{
    AimTowardsTags aimTowardsTags;

    private void Start()
    {
        aimTowardsTags = GetComponent<SmartBulletScript>().aimTowardsTags;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (aimTowardsTags.tags.Contains(other.tag))
        {
            Destroy(gameObject);
        }
    }
}
