using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatColourController : MonoBehaviour
{
    
    [SerializeField] Material snakeCoreMaterial;
    [SerializeField] float intensity;
    void Start()
    {
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", snakeCoreMaterial.GetColor("_EmissionColor")*intensity);
        GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
    }

   
}
