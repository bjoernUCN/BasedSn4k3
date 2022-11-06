using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileOccupationMap : MonoBehaviour
{
    public static TileOccupationMap Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private Dictionary<Vector2,GameObject> components = new Dictionary<Vector2,GameObject>();
    //private Dictionary<Vector2, ComponentType> temporaryComponents = new Dictionary<Vector2, ComponentType>();

    public GameObject GetAtXY(float x, float y)
    {
        return components[new Vector2(x,y)];
    }

    public void Add(float x, float y, GameObject ct)
    {
        components.Add(new Vector2(x,y), ct);
    }

    public void Remove(float x, float y)
    {
        components.Remove(new Vector2(x, y));
    }

}
