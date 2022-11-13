using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathToGameObject : MonoBehaviour
{
    [SerializeField] List<Vector2>Open = new List<Vector2>();
    [SerializeField] List<Vector2>Closed = new List<Vector2>();
    [SerializeField] List<Vector2>Occupied = new List<Vector2>();

    [SerializeField] GameObject target;

    Dictionary<Vector2,Vector2> orderPaths = new Dictionary<Vector2,Vector2>();

    public List<Vector2> path;
    private void Start()
    {
        Open.Add(AsIntVector2(transform.position));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.Q))
        {
            if (Open[0] == AsIntVector2(target.transform.position))
            {
                Debug.Log("HitTarget");
                path = RetraceFrom(Open[0], new List<Vector2>());
            }
            else
            {
                Expand(Open[0]);
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
            UpdatePath();

    }

    public void UpdatePath()
    {
        ResetLists();
        Open.Add(AsIntVector2(transform.position));
       
        while (Open.Count > 0)
        {
            Vector2 pos = Open[0];
            if (pos == AsIntVector2(target.transform.position))
            {
                Debug.Log("HitTarget");
                path = RetraceFrom(pos, new List<Vector2>());
                break;
            }
            else
            {
                Expand(pos);
            }
        }
    }

    private List<Vector2> RetraceFrom(Vector2 vector2, List<Vector2> pathToComplete)
    {
        if (orderPaths.ContainsKey(vector2))
        {
            RetraceFrom(orderPaths[vector2], pathToComplete);

            pathToComplete.Add(vector2);
            Debug.DrawLine(new Vector3(vector2.x, 0, vector2.y), new Vector3(orderPaths[vector2].x, 0, orderPaths[vector2].y));
        }
        return pathToComplete;
    }

    private void ResetLists()
    {
        Open.Clear();
        Closed.Clear();
        Occupied.Clear();
        path.Clear();

        orderPaths.Clear();
    }

    private void Expand(Vector2 vec)
    {
        void Add(Vector2 dir)
        {
            Open.Add(vec + dir);
            orderPaths.Add(vec + dir, vec);
        }

        if (IsNew(vec + Vector2.up))
            Add(Vector2.up);
        if (IsNew(vec + Vector2.right))
            Add(Vector2.right);
        if (IsNew(vec + Vector2.down))
            Add(Vector2.down);
        if (IsNew(vec + Vector2.left))
            Add(Vector2.left);

        Open.Remove(vec);
        Closed.Add(vec);
    }

    private bool IsNew(Vector2 vector2)
    {
        if (!Occupied.Contains(vector2)&&TileOccupationMap.Instance.Has(Mathf.RoundToInt(vector2.x),Mathf.RoundToInt(vector2.y)))
        {
            Occupied.Add(vector2);
        }

        return !Open.Contains(vector2) 
            && !Closed.Contains(vector2)
            && !Occupied.Contains(vector2);
    }

    private Vector2 AsIntVector2(Vector3 vec)
    {
        return new Vector2(Mathf.RoundToInt(vec.x), Mathf.RoundToInt(vec.z));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
        for (int i = 0; i < Open.Count; i++)
        {
            CubeAt(Open, i, Vector3.one);
        }

        //Gizmos.color = Color.black;
        Gizmos.color = new Color(0, 0, 0, 0.1f);
        for (int i = 0; i < Closed.Count; i++)
        {
            CubeAt(Closed, i, new Vector3(1,0f,1));
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < Occupied.Count; i++)
        {
            CubeAt(Occupied, i, Vector3.one*0.9f);
        }

        void CubeAt(List<Vector2> vL, int i, Vector3 size)
        {
            Gizmos.DrawWireCube(new Vector3(vL[i].x, 0, vL[i].y), size);
        }


        Gizmos.color = Color.white;
        for (int i = 0; i < path.Count; i++)
        {
            CubeAt(path, i, new Vector3(1.1f,0,1.1f));

            if(i!=0)
                Debug.DrawLine(new Vector3(path[i-1].x,0.5f,path[i-1].y), new Vector3(path[i].x, 0.5f, path[i].y));
        }

    }


}
