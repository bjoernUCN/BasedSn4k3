using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTowardsEnemies : MonoBehaviour
{
   [SerializeField] public float range;
    List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        GetComponent<SphereCollider>().radius = range;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Remove(other.gameObject);
        }
    }

    private void Add(GameObject g)
    {
        enemies.Add(g);
    }

    private void Remove(GameObject g)
    {
        enemies.Remove(g);
    }

    private void FixedUpdate()
    {
        if (enemies.Count > 0)
        {
            float smallestDist = Vector3.Distance(transform.position, enemies[0].transform.position);
            GameObject aimTo = enemies[0];

            for (int i = 1; i < enemies.Count; i++)
            {
                float newDist = Vector3.Distance(transform.position, enemies[i].transform.position);
                if (smallestDist > newDist)
                {
                    smallestDist = newDist;
                    aimTo = enemies[i];
                }
            }

            Vector3 targetPos = aimTo.transform.position;
            targetPos.y = transform.position.y;
            //targetDir.x = 0;
            transform.forward = targetPos - transform.position;


            Debug.Log(aimTo.name);
        }
        
    }


}
