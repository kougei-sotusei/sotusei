using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{

    static int lastStage = 9;
    public enum SelectStage
    {
        Title = 0,
        stage
    }

    static SelectStage selectStage = SelectStage.Title;

    static string StageName = "stage_";
    static int StageNum;

    public static int GetStage()
    {
        return StageNum;
    }

    public static void Changestage()
    {
        if (StageNum == lastStage)
            ChengeTitle();
        else
        {
            StageNum += 1;
            SceneManager.LoadScene(StageName + StageNum);
        }
    }

    public static void ChengeTitle()
    {
        StageNum = 0;
        SceneManager.LoadScene("Title");
    }
}
