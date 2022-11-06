using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartFollow : MonoBehaviour
{
    [SerializeField] PartFollow next;
    public void UpdatePosition(Vector3 position)
    {
        Vector3 positionPrev = transform.position;
        transform.position = position;
        if (next != null)
        {
            next.UpdatePosition(positionPrev);
        }
    }

}
