using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPCamera : MonoBehaviour
{
    private float sat;

    void Start()
    {

        sat = PostProccessingValues.Saturation;

    }

    // Update is called once per frame
    void Update()
    {
        PostProccessingValues.SaturationOfcamera(sat);
    }
}

public static class PostProccessingValues
{
    public static float Saturation =-100f;

    public static void SaturationOfcamera(float cantidad)
    {
        ColorGrading colorGradingLayer = null;

        PostProcessVolume volume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out colorGradingLayer);

        Saturation = cantidad;

        colorGradingLayer.saturation.value = PostProccessingValues.Saturation;
    }

}