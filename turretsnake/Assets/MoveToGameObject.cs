using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGameObject : MonoBehaviour
{
    public GameObject target;

    private void LateUpdate()
    {
        if (target != null)
        {
           transform.position = Camera.main.WorldToScreenPoint(target.transform.position);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
