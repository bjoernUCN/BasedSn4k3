using System.Collections.Generic;
using UnityEngine;

public class AimTowardsTags2 : MonoBehaviour
{
    [SerializeField] public List<string> tags = new List<string>();
    List<GameObject> targets = new List<GameObject>();

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

    private void Update()
    {
        if (targets.Count > 0)
        {

            GameObject closest = targets[0];
            if (targets.Count > 1)
            {
                for (int i = 0; i < targets.Count; i++)
                {
                    if (targets[i] == null)
                    {
                        targets.RemoveAt(i);
                    }
                    else
                    {
                        if (closest != null)
                            if (Vector2.Distance(transform.position, closest.transform.position) > Vector2.Distance(transform.position, targets[i].transform.position))
                            {
                                closest = targets[i];
                            }
                    }

                }
            }
            if (closest != null)
            {
                Vector3 targetPos = closest.transform.position;
                //targetPos.y = transform.position.y;
                transform.forward = targetPos - transform.position;
            }

        }


    }
}


