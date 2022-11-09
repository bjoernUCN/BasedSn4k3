using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTowardsMouse : MonoBehaviour
{
    UserInput uImp = UserInput.GetInstance();
    void Update()
    {
        Vector3 targetPos = uImp.GetMousePosition();
        targetPos.y = transform.position.y;
        //targetDir.x = 0;
        transform.forward = targetPos - transform.position;
    }
}
