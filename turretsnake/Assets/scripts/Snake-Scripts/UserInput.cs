using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput
{
    public static UserInput instance;
    public static UserInput GetInstance()
    {
        if (instance == null)
        {
            instance = new UserInput();
        }
        return instance;
    }


    enum Dir {none, up,down,right,left }
    Dir dir;

    public Vector3 GetMousePosition()
    {
        Ray temp = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, -Vector3.up / 2);
        float outFloat = 0;

        plane.Raycast(temp, out outFloat);

        //Debug.Log(outFloat);
        //Debug.Log(temp);

        return temp.GetPoint(outFloat);
    }

    public Vector3 GetMovementDir()
    {
        if (Input.GetKeyDown(KeyCode.W)) dir = Dir.up;
        else
        if (Input.GetKeyDown(KeyCode.A)) dir = Dir.left;
        else
        if (Input.GetKeyDown(KeyCode.D)) dir = Dir.right;
        else
        if (Input.GetKeyDown(KeyCode.S)) dir = Dir.down;
        else if(!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.D))
        {
            dir = Dir.none;
        }

       

        Vector3 returnVector = Vector3.zero;

        if(dir == Dir.up) returnVector += Vector3.forward;
        if(dir == Dir.down) returnVector -= Vector3.forward;
        if(dir == Dir.left) returnVector -= Vector3.right;
        if(dir == Dir.right) returnVector += Vector3.right; 

        return returnVector;
    }

  
 
}
