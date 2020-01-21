using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClerJudg
{

    static float[] ClerRotX = new float[] { 0, 45, 30, 16, 5 };
    static float[] ClerRotY = new float[] { 0, 168, 360-100, 360-144, 5 };
    static float[] ClerRotZ = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0,0};

    static float[] ErrorValueX = new float[] { 0, 7, 10, 3, 5 };//誤差
    static float[] ErrorValueY = new float[] { 0, 5, 68, 1, 5 };
    static float[] ErrorValueZ = new float[] { 0, 0, 0, 0, 4 };
    static bool flag;

    public static bool ClerCheck(int Stagenum, Quaternion CameraRot)
    {
        Vector3 rot;
        Vector3 cameraRot = CameraRot.eulerAngles;

        flag = false;

        rot.x = cameraRot.x - ClerRotX[Stagenum];
        rot.y = cameraRot.y - ClerRotY[Stagenum];
        rot.z = cameraRot.z - ClerRotZ[Stagenum];

        Debug.Log(rot);
        Debug.Log(cameraRot);

        if (0 <= rot.x && 0 <= rot.y && 0 <= rot.z)
        {
            Debug.Log("a");
            if (rot.x <= ErrorValueX[Stagenum] && rot.y <= ErrorValueY[Stagenum] && rot.z <= ErrorValueZ[Stagenum])
                flag = true;
        }

        return flag;
    }
}
