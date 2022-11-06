using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] PartFollow next;
    [SerializeField] PartFollow last;

    [SerializeField] List<PartFollow> follows;

    public int mapPosX, mapPosZ;
    PickUpItems pui;

    private void Awake()
    {
        pui = GetComponent<PickUpItems>();
    }

    public void Grow(GameObject g)
    {
        Instantiate(g);
        last = g.GetComponent<PartFollow>();
        follows.Add(last);
    }

    public void GetNewPart(GameObject obj)
    {
        //Spawn new obj at "last" obj position
        last = obj.GetComponent<PartFollow>();
    }

    public void UpdatePosition(Vector3 position)
    {
        Vector3 positionPrev = transform.position;
        transform.position = position;
        MoveTo((int)position.x, (int)position.z);
        if (next != null)
        {
            next.UpdatePosition(positionPrev);
        }
    }


    public void MoveTo(int x, int z)
    {
        pui.ForceUpdate();
        TileOccupationMap.Instance.Remove(mapPosX, mapPosZ);
        mapPosX = x;
        mapPosZ = z;
        TileOccupationMap.Instance.Add(mapPosX, mapPosZ, gameObject);
        Debug.Log(mapPosX+" "+ mapPosZ);

    }

}
