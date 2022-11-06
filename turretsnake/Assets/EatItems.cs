using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItems : MonoBehaviour
{
    private List<GameObject>pickUps = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ItemComponent")){
          
            if (!pickUps.Contains(other.gameObject))
            {
                pickUps.Add(other.gameObject);
            }

            if(pickUps.Count>0)
            AddToSnake();
        }   
    }


    private void AddToSnake()
    {
        for (int i = 0; i < pickUps.Count; i++)
        {
            GetComponent<SnakeComponent2>().GetLast().Attatch(pickUps[i].GetComponent<PickUp>().GetHeldObject().GetComponent<SnakeComponent2>());
            pickUps[i].GetComponent<PickUp>().Delete();
            pickUps.RemoveAt(i);

        }


       /* foreach (GameObject item in pickUps)
        {
            // GameObject added = item.GetComponent<PickUp>().Eat();
            // GetComponent<SnakeComponent2>().GetLast().Attatch(added.GetComponent<SnakeComponent2>());
            GetComponent<SnakeComponent2>().GetLast().Attatch(item.GetComponent<PickUp>().GetHeldObject().GetComponent<SnakeComponent2>());
            //item.GetComponent<PickUp>().Delete();

        }*/
        
    }

}
