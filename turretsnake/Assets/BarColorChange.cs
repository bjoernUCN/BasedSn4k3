using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class BarColorChange : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] Material mat;

    // Start is called before the first frame update
    void Start()
    {
       
        img.color = mat.GetColor("_EmissionColor");
    }

    
}
