using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    GridPosition gridPosition;
    public float timeMoveCooldown;
    UserInput uimp;
    float timer;

    void Start()
    {
        //uimp = GetComponent<UserInput>();
        uimp = UserInput.GetInstance();
        gridPosition = GetComponent<GridPosition>();
    }


    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (uimp.GetMovementDir() != Vector3.zero)
        {
            ChangePosition((int)uimp.GetMovementDir().x, (int)uimp.GetMovementDir().z);
        }
    }

    private void ChangePosition(int x, int y)
    {
        if (timer > timeMoveCooldown)
        {
            timer = 0;
            /* gridPosition.x += x;
             gridPosition.y += y;*/
            
            gridPosition.AssignXandY(gridPosition.x + x, gridPosition.y + y);
            GetComponent<SnakeComponent2>().RecursionMove();
        }
    }



}
