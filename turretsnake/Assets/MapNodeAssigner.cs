using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNodeAssigner : MonoBehaviour
{
    private void Start()
    {
        if(!TileOccupationMap.Instance.Has(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)))
            TileOccupationMap.Instance.Add(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z), gameObject);
    }
}
