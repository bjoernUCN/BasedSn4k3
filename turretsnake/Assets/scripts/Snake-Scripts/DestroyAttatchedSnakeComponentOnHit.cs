using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAttatchedSnakeComponentOnHit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeComponent"))
        {
            //GetComponent<SnakeComponent>()
            //Check if "true" positions overlap (position id)
            if (other.GetComponent<SnakeComponent>().attatched) { 
            if (other.GetComponent<GridPosition>().x == GetComponent<GridPosition>().x && other.GetComponent<GridPosition>().y == GetComponent<GridPosition>().y)
            {
                
                Debug.Log("hit part " + other.gameObject.name);
                other.GetComponent<SnakeComponent>().ChainDetach();
                Destroy(other.gameObject);
            }
            } else
            {
               

                other.GetComponent<SnakeComponent>().ChainAttach();
                GetComponent<SnakeComponent>().GetLast().Add(other.gameObject);
            }
        }
    }


}
