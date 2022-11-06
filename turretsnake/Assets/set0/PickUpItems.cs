using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    Core c;
    private void Awake()
    {
        c = GetComponent<Core>();
    }

    public void ForceUpdate()
    {        
        GameObject obj = TileOccupationMap.Instance.GetAtXY(c.mapPosX, c.mapPosZ);

        if (obj.GetComponent<Type>()!=null)
        switch (obj.GetComponent<Type>().componentType)
        {
            case ComponentType.HealthPickup:
                {
                    c.Grow(obj.GetComponent<PickUp>().GetAddedObject());
                    Debug.Log("hp pickup");
                    obj.GetComponent<PickUp>().Eat();
                }
                
                break;
            default:
                break;
        }

    }



}
