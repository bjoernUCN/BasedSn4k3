using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PathToGameObject))]
public class TargetTagWithPath : MonoBehaviour
{
    PathToGameObject pather;
    List<GameObject> targets = new List<GameObject>();

    [SerializeField] float min_Range, max_Range;
    [SerializeField] List<string> tags = new List<string>();

    [SerializeField] Toggleable onOffToggle;


    void Start()
    {
        pather = GetComponent<PathToGameObject>();
        //onOffToggle = GetComponent<MoveAlongPath>();
        GetComponent<SphereCollider>().radius = max_Range;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tags.Contains(other.tag))
            targets.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (tags.Contains(other.tag))
            targets.Remove(other.gameObject);
    }

    private void FixedUpdate()
    {
        if (targets.Count != 0)
        {
            if (targets[0] == null)
            {
                targets.RemoveAt(0);
                onOffToggle.isOn = false;
            }
            else
            {

                GameObject closest = targets[0];
                foreach (var t in targets)
                {
                    //if (Vector2.Distance(transform.position, t.transform.position) > min_Range)
                    if(t!=null&&closest!=null)
                        if (Vector3.Distance(transform.position, t.transform.position) < Vector3.Distance(transform.position, closest.transform.position))
                        {
                            //Todo, check if enemy is far enough away
                            closest = t;
                        }

                }

                Debug.Log(Vector3.Distance(transform.position, closest.transform.position) + " >? " + min_Range);
                Debug.Log(closest.name);
                Debug.DrawLine(transform.position, closest.transform.position);
                if(closest!= null)
                {
                    onOffToggle.isOn = Vector3.Distance(transform.position, closest.transform.position) >= min_Range;
                    pather.SetTarget(closest);
                }

                
            } 

        }
        //else movementInitializer.isOn = true;
    }
}
