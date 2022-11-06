using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreInput : MonoBehaviour
{
    bool w, a, s, d, tab;
    float movementCooldown;
    Core c;


    private void Awake()
    {
        c = GetComponent<Core>();
    }

    void Update()
    {

        if (movementCooldown > 0.5f)
        {
            Vector3 movVec = Vector3.zero;
            


            if (CheckInput(KeyCode.W) && !CheckInput(KeyCode.S))
            {
                movVec += Vector3.forward;
            }
            if (CheckInput(KeyCode.S) && !CheckInput(KeyCode.W))
            {
                movVec -= Vector3.forward;
            }
            if (CheckInput(KeyCode.A) && !CheckInput(KeyCode.D))
            {
                movVec -= Vector3.right;
            }
            if (CheckInput(KeyCode.D) && !CheckInput(KeyCode.A))
            {
                movVec += Vector3.right;
            }

            if (CheckInput(KeyCode.W) || CheckInput(KeyCode.A) || CheckInput(KeyCode.S) || CheckInput(KeyCode.D))
            {
                movementCooldown = 0;
                CommitMovement(movVec);
            }
           
        } else { movementCooldown += Time.deltaTime;}

       

        
    }

    private void CommitMovement(Vector3 movVec)
    {
        c.UpdatePosition(movVec+transform.position);
        //transform.position = movVec + transform.position;
    }

    bool CheckInput(KeyCode key)
    {
        return Input.GetKey(key);
    }
}
