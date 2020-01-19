using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClerJudg
{

    static float[] ClerRotX = new float[] { 1, 2, 3, 4, 5 };
    static float[] ClerRotY = new float[] { 1, 2, 3, 4, 5 };
    static float[] ClerRotZ = new float[] { 1, 2, 3, 4, 5 };

    static float[] ErrorValue = new float[] { 1, 2, 3, 4, 5 };//誤差

    static bool flag;

    public static bool ClerCheck(int Stagenum, Quaternion CameraRot)
    {
        Vector3 rot;
        flag = false;
        rot.x = Mathf.Abs(ClerRotX[Stagenum] - CameraRot.x);
        rot.y = Mathf.Abs(ClerRotX[Stagenum] - CameraRot.x);
        rot.z = Mathf.Abs(ClerRotX[Stagenum] - CameraRot.x);

        if (rot.x < ErrorValue[Stagenum] && rot.y < ErrorValue[Stagenum] && rot.z < ErrorValue[Stagenum])
            flag = true;

        return flag;
    }

}
