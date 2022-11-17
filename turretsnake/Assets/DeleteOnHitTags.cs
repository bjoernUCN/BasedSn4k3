using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>DeleteOnHitTags</c> GameObject is deleted when trigger enters object with tag in <c>tags</c>
/// <para>Note: Field "tags" must be assigned</para>
/// </summary>
public class DeleteOnHitTags : MonoBehaviour
{
    
    [SerializeField] List<string> tags = new List<string>();
    
    private void OnTriggerEnter(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            Destroy(gameObject);
        }
    }
}
