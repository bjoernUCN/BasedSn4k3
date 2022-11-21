using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathToGameObject))]


public class SlideAlongPath : Toggleable
{
    float pathUpdateTimer;
    [SerializeField] float pathUpdateFrequence;

    PathToGameObject pather;
    Rigidbody rb;

    [SerializeField] float speed;

    void Start()
    {
        pather = GetComponent<PathToGameObject>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pathUpdateTimer > pathUpdateFrequence)
            {UpdatePath(); pathUpdateTimer = 0;}
        else
            pathUpdateTimer += Time.deltaTime;

    }

    private void UpdatePath()
    {
        pather.UpdatePath();
    }

    private void FixedUpdate()
    {
        if (pather.path.Count > 0&& isOn)
        {
            Vector3 target = new Vector3 (pather.path[0].x, 0, pather.path[0].y);
            rb.AddForce((target-transform.position) * speed);
        }
    }
}
