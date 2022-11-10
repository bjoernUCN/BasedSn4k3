using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_BarListenToHealth : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Image img;
    private void LateUpdate()
    {
        if (health != null)
        {
            img.fillAmount = health.GetHealth()/health.GetMaxHealth();
        }
    }
}
