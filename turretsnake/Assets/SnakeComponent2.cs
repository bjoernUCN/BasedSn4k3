using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeComponent2 : MonoBehaviour
{
    public SnakeComponent2 prev;
    public SnakeComponent2 next;
    [SerializeField] private int NumberInRow;
    
    public void Detatch()
    {
        prev.next = null;
        this.prev = null;
    }
    //adds a new component to the chain
    public SnakeComponent2 Attatch(SnakeComponent2 next)
    {
        this.next = next;
        next.prev = this;
        next.NumberInRow = NumberInRow+1;
        return this;
    }

    public void AssignNunber(int i)
    {
        NumberInRow = i;
        if(next!=null)
        next.AssignNunber(i++);
    }


    public void RecursionMove()
    {
        if (prev != null)
        {
            //GetComponent<GridPosition>().x = prev.GetComponent<GridPosition>().x;
            //GetComponent<GridPosition>().y = prev.GetComponent<GridPosition>().y;
            GetComponent<GridPosition>().AssignXandY(   prev.GetComponent<GridPosition>().xLast, 
                                                        prev.GetComponent<GridPosition>().yLast);
        }
        if (next != null)
            next.RecursionMove();
    }

    public SnakeComponent2 GetLast()
    {
        if (next != null && next.prev == this) //if we have a next in chain, and it is attatched to this
        {
            return next.GetLast();
        }
        else
        {
            return this;
        }
    }


}
