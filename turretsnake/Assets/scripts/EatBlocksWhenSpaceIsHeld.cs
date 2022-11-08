using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBlocksWhenSpaceIsHeld : MonoBehaviour
{
    bool active;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            active = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
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
                    
                }
            }
        }
    }

}
