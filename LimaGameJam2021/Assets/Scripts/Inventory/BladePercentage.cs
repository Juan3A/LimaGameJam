using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladePercentage : MonoBehaviour
{
    private Image blade;

    void Start()
    {
        blade = GetComponent<Image>();


        //Blade.DamageBlade(50);
    }

    void Update()
    {
        blade.fillAmount = Blade.BladeIntegrity()*0.01f;
    }
}
