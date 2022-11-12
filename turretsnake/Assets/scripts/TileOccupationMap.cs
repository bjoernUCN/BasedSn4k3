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
        }
        else
        {
            Instance = this;
        }
    }

    private Dictionary<Vector2,GameObject> occupiedNodes = new Dictionary<Vector2,GameObject>();

    public bool Has(int x, int y)
    {
        return occupiedNodes.ContainsKey(new Vector2(x, y));
    }

    public GameObject Get(int x, int y)
    {
        return occupiedNodes[new Vector2(x,y)];
    }

    public void Add(int x, int y, GameObject value)
    {
        occupiedNodes.Add(new Vector2(x,y), value);
    }

    public void Remove(int x, int y)
    {
        occupiedNodes.Remove(new Vector2(x, y));
    }

}
