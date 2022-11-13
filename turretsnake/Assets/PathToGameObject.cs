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
        //DEBUG FIELD
        //ResetLists();
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.Q))
        {
            if (Open[0] == AsIntVector2(target.transform.position))
            {
                Debug.Log("HitTarget");
            }
            else
            {
                Expand(Open[0]);
            }
        }

        //DEBUG FIELD
        //path = MakePath();
    }

    private void ResetLists()
    {
        Open.Clear();
        Closed.Clear();
        Occupied.Clear();
        path.Clear();
    }

    private List<Vector2> MakePath()
    {
        ResetLists();
        Open.Add(AsIntVector2(transform.position));
        List<Vector2> returnPath = new List<Vector2>();
        while (Open.Count > 0)
        {
            if (Open[0] == AsIntVector2(target.transform.position))
            {
                Debug.Log("HitTarget");
            }
            else
            {
                Expand(Open[0]);
            }    
        }
        return returnPath;
    }

    private void Expand(Vector2 vec)
    {
        //Debug.Log(IsNew(vec + Vector2.up)+ " up");
        if(IsNew(vec + Vector2.up))
            Open.Add(vec + Vector2.up);
        if (IsNew(vec + Vector2.right))
            Open.Add(vec + Vector2.right);
        if (IsNew(vec + Vector2.down))
            Open.Add(vec + Vector2.down);
        if (IsNew(vec + Vector2.left))
            Open.Add(vec + Vector2.left);

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
            //Gizmos.DrawIcon(new Vector3(Open[i].x, 1, Open[i].y), "SpeedScale");
        }
        Gizmos.color = Color.black;
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

    }


}
