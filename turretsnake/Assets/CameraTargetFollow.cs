using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetFollow : MonoBehaviour
{
    Vector3 offset;
    Quaternion rotation;

    [SerializeField] float spd;

    [SerializeField] GameObject target;

    Vector3 newPoint;

    void Start()
    {
        offset = transform.position;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = offset+target.transform.position;
         

    }

    private void FixedUpdate()
    {
        newPoint = Vector3.Lerp(transform.position, offset + target.transform.position, spd * Time.deltaTime);
        transform.position = newPoint;
    }

}
