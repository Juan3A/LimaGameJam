using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPCamera : MonoBehaviour
{

    ColorGrading colorGradingLayer = null;

    private float sat;

    void Start()
    {
        //PostProccessingValues.Saturation = -100f;

        sat = PostProccessingValues.Saturation;

        PostProcessVolume volume = gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out colorGradingLayer);


    }

    // Update is called once per frame
    void Update()
    {
        PostProccessingValues.Saturation = sat;
        colorGradingLayer.saturation.value = PostProccessingValues.Saturation;
    }
}

public static class PostProccessingValues
{
    public static float Saturation =-100f;



}