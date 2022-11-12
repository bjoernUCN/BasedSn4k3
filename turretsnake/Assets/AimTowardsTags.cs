using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>AimTowardsTags</c> Aims the gameobject towards the nearest GameObject with one of the Tags in the "tags" List
/// </summary>
public class AimTowardsTags : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] public List<string> tags = new List<string>();
    Dictionary<string,List<GameObject>> tagsDictionary = new Dictionary<string,List<GameObject>>();
    public bool HasTarget { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            AddByTag(other.tag, other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            RemoveByTag(other.tag, other.gameObject);
        }
    }


    void Start()
    {
        GetComponent<SphereCollider>().radius = range;

        for (int i = 0; i<tags.Count;i++)
        {
            List<GameObject> l1 = new List<GameObject>();
            tagsDictionary.Add(tags[i], l1);
        }   
    }

    /// <summary>
    /// Method <c>AddByTag</c> Finds list from tag-list dictionary and adds a gameobject to the list that has the specified tag as key
    /// </summary>
    /// <param name="tag"> the Tag of the GameObject </param>
    /// <param name="added"> the added GameObject</param>
    /// 
    private void AddByTag(string tag, GameObject added)
    {
        
        tagsDictionary[tag].Add(added);
    }
    private void RemoveByTag(string tag, GameObject added)
    {
        tagsDictionary[tag].Remove(added);
    }
    private List<GameObject> GetByTag(string tag)
    {
        return tagsDictionary[tag];
    }

    private void Update()
    {
        GameObject nearestTarget = null;

       
        for (int i = 0; i < tags.Count; i++)
        {
            if (GetByTag(tags[i]).Count > 0)
            {
                for (int io = 0; io < GetByTag(tags[i]).Count; io++)
                {
                    if(nearestTarget==null || GetByTag(tags[i])[io]!=null &&
                            Vector3.Distance(nearestTarget.transform.position,transform.position) 
                            > 
                            Vector3.Distance(GetByTag(tags[i])[io].transform.position, transform.position))
                    {
                        //found_target = true;
                        nearestTarget = GetByTag(tags[i])[io];
                    }

                    
                }
            }
        }

       // bool found_target = false;
        //HasTarget = found_target;

        if (nearestTarget != null)
        {
            Vector3 targetPos = nearestTarget.transform.position;
            targetPos.y = transform.position.y;
            transform.forward = targetPos - transform.position;

            HasTarget = true;
        } else HasTarget = false;

        
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (GetByTag(tags[i]).Count > 0)
                {
                    for (int io = 0; io < GetByTag(tags[i]).Count; io++)
                    {
                        //Debug.Log(GetByTag(tags[i])[io].name);
                        Debug.DrawLine(GetByTag(tags[i])[io].transform.position, transform.position, Color.red);
                    }
                }
            }
        }
      
    }

}
