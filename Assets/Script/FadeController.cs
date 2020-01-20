﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour {

    Image image;

    static  bool flag;
    float alfa=0f;
    float fadeSpeed = 0.01f;


    void Start()
    {
        image = GetComponent<Image>();
    }
    void Update () {

        if (flag)
            StartFade();
	}

    private void StartFade()
    {
        alfa += fadeSpeed;

        image.color = new Color(255, 255, 255, alfa);

        if (alfa>1)
        {
            Stage.Changestage();
            Reset();
        }

    }

    private void Reset()
    {
        flag = false;
        alfa = 0;
        image.color = new Color(255, 255, 255, 0);
        GetComponent<Image>().enabled = false;
    }

    public  void FadeFlag()
    {
        GetComponent<Image>().enabled = true;
        flag = true;
    }
}
