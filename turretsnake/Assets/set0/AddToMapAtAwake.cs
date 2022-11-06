using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToMapAtAwake : MonoBehaviour
{
    private void Start()
    {
        TileOccupationMap.Instance.Add((int)transform.position.x, (int)transform.position.z, gameObject);
    }
}
