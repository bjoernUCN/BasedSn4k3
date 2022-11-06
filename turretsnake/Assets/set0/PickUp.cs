using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour
{
    
    [SerializeField] private GameObject addedObject;
   
    public GameObject GetAddedObject()
    {
        return addedObject;
    }

    public GameObject Eat()
    {
        Destroy(gameObject);
        return Instantiate(addedObject);
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    public GameObject GetHeldObject()
    {
        GameObject g = Instantiate(addedObject);
        return g;
    }

}
