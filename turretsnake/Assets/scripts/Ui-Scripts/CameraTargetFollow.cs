using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    Quaternion rotation;

    [SerializeField] float spd;

    [SerializeField] GameObject target;

    Vector3 newPoint;

    void Start()
    {
        offset = transform.position;
        rotation = transform.rotation;
    }

    

    private void FixedUpdate()
    {
        newPoint = Vector3.Lerp(transform.position, offset + target.transform.position, spd * Time.deltaTime);
        transform.position = newPoint;
    }

}
