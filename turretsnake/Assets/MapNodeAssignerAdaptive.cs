using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNodeAssignerAdaptive : MonoBehaviour
{
    // Start is called before the first frame update
    List<Vector2>ClosedNodes = new List<Vector2>();
    List<Vector2> OpenNodes = new List<Vector2>();
    int attempts = 30;
    TileOccupationMap instance;
    Collider coll;
    void Start()
    {
        coll = GetComponent<Collider>();
        //For each vertex,
        //try assign to TileOccupationMap at vertex position
        //AssignVertex all points within collider
        Add(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));

        while (OpenNodes.Count > 0 && attempts>0)
        {
            Debug.Log(attempts + " " + OpenNodes[0]);
            Debug.DrawRay(new Vector3(OpenNodes[0].x, transform.position.y, OpenNodes[0].y), Vector3.up, Color.white, 12);

            ExpandOne();
            attempts--;
            
        }


        instance = TileOccupationMap.Instance;
        foreach (Vector2 node in ClosedNodes)
        {
            Debug.Log("Added " + node);
            Debug.DrawRay(new Vector3(node.x, transform.position.y, node.y), Vector3.up, Color.green, 22);
            AddToMap(node);
        }
    }

    private void AddToMap(Vector2 vec)
    {
        int x = Mathf.RoundToInt(vec.x);
        int y = Mathf.RoundToInt(vec.y);
        TileOccupationMap.Instance.Add(x, y,gameObject);
    }

    private void OnDrawGizmos()
    {
        //Add(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
    }
    private void ExpandOne()
    {
        if (Collsion(OpenNodes[0] + Vector2.up))
            Add(OpenNodes[0] + Vector2.up);

        if (Collsion(OpenNodes[0] + Vector2.right))
            Add(OpenNodes[0] + Vector2.right);

        if (Collsion(OpenNodes[0] + Vector2.down))
            Add(OpenNodes[0] + Vector2.down);

        if (Collsion(OpenNodes[0] + Vector2.left))
            Add(OpenNodes[0] + Vector2.left);
        
        Close(OpenNodes[0]);
    }

    bool Collsion(Vector2 vec)
    {
        float x = vec.x;
        float y = 1;
        float z = vec.y;

        return (coll.ClosestPoint(new Vector3(x, y, z)) == new Vector3(x, y, z));
    }

    private void Add(Vector2 vec)
    {
        int x = Mathf.RoundToInt(vec.x);
        int y = Mathf.RoundToInt(vec.y);
        //If new added node is not in open nodes or closed nodes (do not check the same node twice)
        if (!OpenNodes.Contains(new Vector2(x, y)) && !ClosedNodes.Contains(new Vector2(x, y)))
            OpenNodes.Add(new Vector2(x, y));
    }

    private void Add(int x, int y)
    {
        //If new added node is not in open nodes or closed nodes (do not check the same node twice)
        if(!OpenNodes.Contains(new Vector2(x, y)) && !ClosedNodes.Contains(new Vector2(x, y)))
            OpenNodes.Add(new Vector2(x, y));
    }

    private void Close(Vector2 vec)
    {
        int x = Mathf.RoundToInt(vec.x);
        int y = Mathf.RoundToInt(vec.y);

        OpenNodes.Remove(new Vector2(x, y));
        ClosedNodes.Add(new Vector2(x, y));
    }


    private void AssignVertex(int x,int y)
    {
        if (!TileOccupationMap.Instance.Has(x, y))
            TileOccupationMap.Instance.Add(x, y, gameObject);
    }
}
