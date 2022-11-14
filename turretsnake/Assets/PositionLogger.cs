using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLogger : MonoBehaviour
{
    GridPosition gp;
    Vector3 loggedPosition;

    private void Start()
    {
        gp = GetComponent<GridPosition>();
    }
    void Update()
    {
        if(gp.GetFullPosition() != loggedPosition)
        {
            MoveLogTo(loggedPosition, gp.GetFullPosition());
            
        }
    }

    private void MoveLogTo(Vector3 oldPos, Vector3 newPos)
    {

        if (TileOccupationMap.Instance.Add(xAsInt(newPos), zAsInt(newPos), gameObject))
        {
            TileOccupationMap.Instance.Remove(xAsInt(oldPos), zAsInt(oldPos));
            loggedPosition = gp.GetFullPosition();
        }
            
    }

    private int xAsInt(Vector3 vec)
    {
        return Mathf.RoundToInt(vec.x);
    }
    private int zAsInt(Vector3 vec)
    {
        return Mathf.RoundToInt(vec.z);
    }



}
