using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Staticproblem : MonoBehaviour
{
    private Image mine;

    public Sprite[] frames;

    private bool STOP = false;

    void Start()
    {
        mine = GetComponent<Image>();

        //mine.material.mainTexture = frames[0];
    }

    private void Update()
    {
        int index = (int)(Time.time * 10) % frames.Length;

        if (!STOP)
        {

            mine.sprite = frames[index];

        }

    }

    public void PlayIt()
    {
        STOP = false;
    }

    public void StopIt()
    {
        STOP = true;
    }

}
