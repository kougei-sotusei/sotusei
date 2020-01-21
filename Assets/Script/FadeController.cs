using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour {

    static Image image;

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

        if (alfa>=1)
        {
            Reset();
            Stage.Changestage();
        }

    }

    private void Reset()
    {
        flag = false;
        alfa = 0;
       // image.color = new Color(255, 255, 255, 0);
        GetComponent<Image>().enabled = false;
    }

    public  void FadeFlagButton()
    {
        image.enabled = true;
        flag = true;
    }

    public static void FadeFlag()
    {
        image.enabled = true;
        flag = true;
    }
}
