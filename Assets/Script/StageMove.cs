using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StageMove : MonoBehaviour {

    [SerializeField] Slider SliderX;
    [SerializeField] Slider SliderY;
    [SerializeField] Slider SliderZ;

    [SerializeField] Transform StageTra;

    Vector3 rotate;

    public void RotX()
    {
        rotate.x = SliderX.value;
        StageTra.eulerAngles = rotate;
    }

    public void RotY()
    {
        rotate.y = SliderY.value;
        StageTra.eulerAngles = rotate;
    }

    public void RotZ()
    {
        rotate.z = SliderZ.value;
        StageTra.eulerAngles = rotate;
    }

    public void ValueReset()
    {
        SliderX.value = 0f;
        SliderY.value = 0f;
        SliderZ.value = 0f;
    }
}
