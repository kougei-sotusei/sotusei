using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClerJudg
{

    static float[] ClerRotX = new float[] { 0, 45, 30, 16, 3, 1, 0, 0, 8, 35, 56, 70 };
    static float[] ClerRotY = new float[] { 0, 168, 360 - 100, 360 - 144, 4, 5, 360 - 9, 137, 30,360 - 212, 360 - 185, 12 };
    static float[] ClerRotZ = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    static float[] ErrorValueX = new float[] { 0, 7, 10, 3, 8, 34, 60, 60, 14,8, 7, 4 };//誤差
    static float[] ErrorValueY = new float[] { 0, 5, 68, 5, 5, 5, 3, 3, 5, 48,25, 10 };
    static float[] ErrorValueZ = new float[] { 0, 0, 0, 0, 0 };
    static bool flag;

    static int Stagenum =9;

    public static bool ClerCheck(Quaternion CameraRot)
    {
        Vector3 rot;
        Vector3 cameraRot = CameraRot.eulerAngles;

        flag = false;

        rot.x = cameraRot.x - ClerRotX[Stagenum];
        rot.y = cameraRot.y - ClerRotY[Stagenum];
        // rot.z = cameraRot.z - ClerRotZ[Stagenum];

        if (0 <= rot.x && 0 <= rot.y)
        {
            if (rot.x <= ErrorValueX[Stagenum] && rot.y <= ErrorValueY[Stagenum])
            {
                flag = true;
                Stagenum += 1;
            }
        }
        Debug.Log(Stagenum);

        return flag;
    }
}
