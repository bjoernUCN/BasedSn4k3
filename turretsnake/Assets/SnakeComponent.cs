using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeComponent : MonoBehaviour
{
    [SerializeField] SnakeComponent next;
    [SerializeField] public SnakeComponent prev;
    GridPosition gridPosition;
    float xLast, yLast;

    public bool attatched = true;
    public bool loopCheck = false;

    private void Awake()
    {
        gridPosition = GetComponent<GridPosition>();
    }

    public void MoveSnake()
    {
        if (next != null && next.attatched && attatched && !loopCheck)
        {
            loopCheck = true;
            GridPosition nextPosition = next.transform.GetComponent<GridPosition>();
            nextPosition.x = xLast;
            nextPosition.y = yLast;
            next.MoveSnake();
            loopCheck = false;
        }
      

        xLast = gridPosition.x;
        yLast = gridPosition.y;

    }

  
    public float GetLastX() { return xLast; }
    public float GetLastY() { return yLast; }

    public SnakeComponent GetLast()
    {
        SnakeComponent returnSnake = this;
            if (next != null && attatched && next.attatched&& !loopCheck && next.gameObject!=this.gameObject)
        {
            loopCheck=true;
            returnSnake = next.GetLast();
        }
               

        loopCheck = false;
        return returnSnake;
            
    }

    public SnakeComponent GetLast(GameObject exception)
    {
        SnakeComponent returnSnake = this;
        if (next != null && attatched && next.attatched && !loopCheck && next.gameObject != this.gameObject && this.gameObject!=exception)
        {
            loopCheck = true;
            returnSnake = next.GetLast();
        }


        loopCheck = false;
        return returnSnake;

    }


    public void ChainDetach()
    {
        if (attatched)
        {
            attatched = false;
            if (next != null)
            {
                next.ChainDetach();
            }
                

            next = null;
        }
    }

    

    public void ChainAttach()
    {
        if (!attatched)
        {
            attatched = true;
            if (next != null && !next.attatched)
                next.ChainAttach();
        }
       
       
    }

    public void Add(GameObject added_part)
    {
        next = added_part.GetComponent<SnakeComponent>();
        next.prev = this;
    }

}
