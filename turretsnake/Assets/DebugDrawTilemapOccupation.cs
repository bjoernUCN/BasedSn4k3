using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawTilemapOccupation : MonoBehaviour
{
    TileOccupationMap instance;
    void Start()
    {
        instance = TileOccupationMap.Instance;
    }

    
 
    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            int x = Mathf.RoundToInt(transform.position.x);
            int y = Mathf.RoundToInt(transform.position.z);
            if (instance.Has(x, y))
            {
                Gizmos.color = Color.red;
                Debug.DrawRay(transform.position, transform.up*10);
                Gizmos.DrawWireCube(new Vector3(x, 0, y), new Vector3(1, 10, 1));

                //Gizmos.DrawWireCube(instance.Get(x, y).transform.position, new Vector3(1, 10, 1));
                //Debug.Log(instance.Get(x, y).transform.position.x + "__" + x);

            }
        }
       
    }
}
