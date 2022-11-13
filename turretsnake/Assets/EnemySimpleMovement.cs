using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleMovement : MonoBehaviour
{
    [SerializeField] public List<string> tags = new List<string>();
    [SerializeField] List<GameObject> targets;
    [SerializeField] GameObject mainTarget;


    //Current path that this enemy will walk in, updates regularly, but is often outdated, still good enough
    [SerializeField] List<Vector2> path = new List<Vector2>();


    private void Update()
    {
        if (targets.Count > 0) //Assign target
        {
            mainTarget = targets[0];
            foreach (GameObject potentialClosestTarget in targets) //Find the closest target and mark it as mainTarget
            {
                if (Vector3.Distance(mainTarget.transform.position, transform.position) > Vector3.Distance(potentialClosestTarget.transform.position, transform.position))
                {
                    mainTarget = potentialClosestTarget;
                }
            }
        }
        
        if (mainTarget != null)
        {
            path.Clear();
            path = GetPathToTarget(
                new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)),
                new Vector2(Mathf.RoundToInt(mainTarget.transform.position.x), Mathf.RoundToInt(mainTarget.transform.position.z))
                ); //Pathfind to the main target, takes our position and target position as parameters

            for (int i = 0; i < path.Count; i++) //DebugDraw path
            {
                
                Debug.DrawRay(new Vector3(path[i].x,1, path[i].y), transform.up*4,Color.black);
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (mainTarget != null)
        {
            if (TileOccupationMap.Instance.Has(Mathf.RoundToInt( mainTarget.transform.position.x),Mathf.RoundToInt( mainTarget.transform.position.z)))
            {
                Gizmos.DrawWireSphere(mainTarget.transform.position,0.5f);
            }
            else
            {
                Gizmos.DrawWireSphere(mainTarget.transform.position, 0.3f);
            }
        }
            
        for (int i = 0; i < path.Count; i++) //DebugDraw path
        {
            Gizmos.DrawWireCube(new Vector3(path[i].x, 1, path[i].y), Vector3.one);
        }
        
    }

    //Gets path to main target
    private List<Vector2> GetPathToTarget(Vector2 origin, Vector2 target)
    {
        //Fields
        List<Vector2> result = new List<Vector2>();
        TileOccupationMap instance = TileOccupationMap.Instance;

        List<Vector2> ClosedPositions = new List<Vector2>();
        List<PathNode> OpenNodes = new List<PathNode>();
        int attempts = 320;
        

        //Logic
        OpenNodes.Add(new PathNode(new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z))));
        //List<PathNode> path = new List<PathNode>();
        while (OpenNodes.Count > 0 && attempts > 0)
        { 
            attempts--;
            if (GetBestNode(origin, target).FoundTarget(target))
            {
                return GetBestNode(origin, target).CompileList(path);
            }
            else
            {
                Expand(GetBestNode(origin, target));
            }
            //Gets nearest point in open_list (search for nearest+closest)
        } 
        if(OpenNodes.Count < 0)
        {
            Debug.Log("0 nodes open");
        }

        if (attempts <= 0)
        {
            Debug.Log("0 attempts left");
        }

        Debug.Log("No way found");
        //Returnal answer
        return result;

        void Expand(PathNode n)
        {
            TryAddPathNodeToOpen(Vector2.up, n);
            TryAddPathNodeToOpen(Vector2.right, n);
            TryAddPathNodeToOpen(Vector2.down, n);
            TryAddPathNodeToOpen(Vector2.left, n);

            OpenNodes.Remove(n);
            ClosedPositions.Add(n.position);
        }

        void TryAddPathNodeToOpen(Vector2 pos, PathNode n)
        {
            if (!instance.Has(Mathf.RoundToInt(pos.x + n.position.x), Mathf.RoundToInt(pos.y + n.position.y) ))
            {   
               
                if (!ClosedPositions.Contains(n.position + pos))
                { //If position+pos has never been visited, add new node to openlist at position
                    OpenNodes.Add(new PathNode(n.position + pos, n));
                    Debug.DrawRay(new Vector3(Mathf.RoundToInt(pos.x + n.position.x), 1, Mathf.RoundToInt(pos.y + n.position.y) + 0.05f), transform.up * 1, Color.blue);
                }
                else
                {
                    Debug.DrawRay(new Vector3(Mathf.RoundToInt(pos.x + n.position.x), 1, Mathf.RoundToInt(pos.y + n.position.y) + 0.05f), transform.up * 1, Color.yellow);
                }
            }
            else
            {
                ClosedPositions.Add(n.position + pos);
                Debug.DrawRay(new Vector3(Mathf.RoundToInt(pos.x + n.position.x), 1, Mathf.RoundToInt(pos.y + n.position.y) + 0.05f), transform.up * 1, Color.red);
                //Debug.DrawRay(new Vector3((pos + n.position).x,1, (pos + n.position).y),transform.up*12,Color.yellow,10);
            }
        }


        //Search pattern
        PathNode GetBestNode(Vector2 origen, Vector2 target)
        {
            PathNode bestNode = OpenNodes[0];
            for (int i = 0; i < OpenNodes.Count; i++)
            {
                if (OpenNodes[i].Get_ASTAR_Heuristic(origen, target) < bestNode.Get_ASTAR_Heuristic(origen, target))
                { bestNode = OpenNodes[i]; }

            }
            return bestNode;
        }
    }






    private void OnTriggerEnter(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            targets.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            targets.Remove(other.gameObject);
        }
    }






    //Class for finding storing vector2's with references another vector2, with the purpose of find a path back
    private class PathNode
    {
        public Vector2 position;
        public PathNode last;
        public PathNode(Vector2 pos, PathNode l)
        {
            position = pos;
            last = l;
        }
        public PathNode(Vector2 pos)
        {
            position = pos;
            last = null;
        }



        public bool FoundTarget(Vector2 target)
        {
            //Debug.Log("found at " + position);
            return (position == target);
        }

        public float Get_ASTAR_Heuristic(Vector2 origin, Vector2 target)
        {
            return Vector2.Distance(position, origin) + Vector2.Distance(position, target);
            //return (position - origin).x + (position - target).x + (position - origin).y + (position - target).y;
        }

        public List<Vector2> CompileList(List<Vector2> path)
        {
            path.Add(this.position);
            if (last != null)
                return last.CompileList(path);
            else
                return path;
        }
    }


}
