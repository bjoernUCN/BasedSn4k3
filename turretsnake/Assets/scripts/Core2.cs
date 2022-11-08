using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core2 : MonoBehaviour
{
    UserInput userInput;
    [SerializeField] float moveSpeed;
    [SerializeField] float speedLimit; 
    Rigidbody rb;



    void Awake()
    {
        userInput = GetComponent<UserInput>();
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        rb.AddForce(userInput.GetMovementDir() * (Time.deltaTime * moveSpeed));



    }
}
