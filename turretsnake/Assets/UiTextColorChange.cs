using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class UiTextColorChange : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt;
    [SerializeField] Material mat;

    // Start is called before the first frame update
    void Start()
    {

        txt.color = mat.GetColor("_EmissionColor");
    }


}
