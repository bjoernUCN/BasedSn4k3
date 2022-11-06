using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeComponent"))
        {
           
            //Check if "true" positions overlap (position id)
            if (other.GetComponent<SnakeComponent>().attatched)
            {
                if (other.GetComponent<GridPosition>().x == GetComponent<GridPosition>().x && other.GetComponent<GridPosition>().y == GetComponent<GridPosition>().y)
                {
                    
                    if (other.GetComponent<SnakeComponent>().prev != null)
                        other.GetComponent<SnakeComponent>().prev.ChainDetach();
                    else
                        other.GetComponent<SnakeComponent>().ChainDetach();
                    //other.GetComponent<SnakeComponent>().DetachOne();
                }
            }
            else
            {
                other.GetComponent<GridPosition>().x = GetComponent<SnakeComponent>().GetLast().GetComponent<SnakeComponent>().GetLastX();
                other.GetComponent<GridPosition>().y = GetComponent<SnakeComponent>().GetLast().GetComponent<SnakeComponent>().GetLastY();

                other.GetComponent<SnakeComponent>().ChainAttach();
                SnakeComponent last = GetComponent<SnakeComponent>().GetLast(other.gameObject);
                if (other.gameObject != last)
                    last.Add(other.gameObject);
            }
        }
    }
}
