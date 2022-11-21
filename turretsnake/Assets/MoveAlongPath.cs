using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongPath : Toggleable
{
    PathToGameObject pathing;
    [SerializeField] float updateTimer;
    float timer;
    [SerializeField] float movementSpeed;
    GridPosition gp;

    private void Start()
    {
        gp = GetComponent<GridPosition>();
        pathing = GetComponent<PathToGameObject>();
    }

    public void Move()
    {
        if (pathing.path.Count > 0)
        {
            gp.AssignXandY(pathing.path[0].x, pathing.path[0].y);

            if (GetComponent<SnakeComponent2>()) //If this script is on a snake, move all blocks along the chain
                GetComponent<SnakeComponent2>().RecursionMove();
        }
    }

    public bool CountDown()
    {
        if (timer > updateTimer)
        {
            timer = 0;
            return true;
        }
        else timer += Time.deltaTime;

        return false;
    }

    public void UpdatePath()
    {
        pathing.UpdatePath();
    }

    void Update()
    {
        if(isOn)
            if (CountDown())
            {
                UpdatePath();
                Move();
            }


    }
}
