using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongPath : MonoBehaviour
{
    PathToGameObject pathing;
    [SerializeField] float updateTimer;
    float timer;
    [SerializeField] float movementSpeed;
    GridPosition gp;
    private void Start()
    {
        gp= GetComponent<GridPosition>();
        pathing = GetComponent<PathToGameObject>();
    }

    void Update()
    {
        if (timer > updateTimer)
        {
            timer = 0;
            pathing.UpdatePath();

            //move entity
            if(pathing.path.Count > 0)
            {
                gp.AssignXandY(pathing.path[0].x, pathing.path[0].y);
                
                if(GetComponent<SnakeComponent2>()) //If this script is on a snake, move all blocks along the chain
                    GetComponent<SnakeComponent2>().RecursionMove();
            }
                
        } else timer+=Time.deltaTime;

        /*if (pathing.path.Count > 0)
        {
            //transform.Translate((new Vector3(pathing.path[0].x,0,pathing.path[0].y) - transform.position) * Time.deltaTime * movementSpeed);
          
        }*/

        


    }
}
