using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    GridPosition gridPosition;
    public float timeMoveCooldown;
    UserInput uimp;
    float timer;

    [SerializeField] bool useCollsion;
    CollisionManager collisionManager;

    void Start()
    {
        //uimp = GetComponent<UserInput>();
        uimp = UserInput.GetInstance();
        gridPosition = GetComponent<GridPosition>();

        if(useCollsion) collisionManager = GetComponent<CollisionManager>();
    }



    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 movementDirection = uimp.GetMovementDir();
        if (movementDirection != Vector3.zero && collisionManager.CanGoTo(movementDirection))
        {
            ChangePosition((int)movementDirection.x, (int)movementDirection.z);
        }

        //DEBUG
        //collisionManager.CanGoTo(movementDirection);
        //DEBUG

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
