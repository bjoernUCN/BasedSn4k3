using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleMovement : MonoBehaviour
{
    [SerializeField] public List<string> tags = new List<string>();
    List<GameObject> targets;
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }


}
