using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachComponentOnHit : MonoBehaviour
{
    [SerializeField] GameObject particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeComponent"))
        {
            SnakeComponent2 hitComponent = other.GetComponent<SnakeComponent2>();
            GridPosition hitPosition = hitComponent.GetComponent<GridPosition>();
            GridPosition thisPosition = GetComponent<GridPosition>();
            if(hitPosition.x == thisPosition.x && hitPosition.y == thisPosition.y) {  //out position
                if (hitComponent.next != null)
                {
                    if (particle != null)
                    {
                        Instantiate(particle, hitComponent.transform.position+Vector3.up, Quaternion.identity);
                    }
                    hitComponent.next.Detatch();
                }
                

                
            }
        }
    }


}
