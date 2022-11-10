using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBlocksWhenSpaceIsHeld : MonoBehaviour
{
    bool active;
    [SerializeField] GameObject particle;
    CollisionManager collisionManager;
    bool permaEat;
    private void Start()
    {
        collisionManager = GetComponent<CollisionManager>();
        permaEat = collisionManager.perma_eat;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || permaEat)
        {
            active = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) && !permaEat)
        {
            active = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            if (other.CompareTag("SnakeComponent"))
            {
                if (other.GetComponent<SnakeComponent2>().prev == null)
                {
                    if(other.GetComponent<GridPosition>().x==GetComponent<GridPosition>().x && other.GetComponent<GridPosition>().y == GetComponent<GridPosition>().y)
                    GetComponent<SnakeComponent2>().GetLast().Attatch(other.GetComponent<SnakeComponent2>());
                   
                        //ToDo, make part move immedialy
                        other.GetComponent<SnakeComponent2>().RecursionMove();

                    if (particle != null)
                    {
                        Instantiate(particle, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }

}
