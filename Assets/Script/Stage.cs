using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{

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

    public static void SetNowStage(SelectStage stage)
    {
        selectStage = stage;
    }

    public static int MaxStageNum()
    {
        return (int)System.Enum.GetNames(typeof(SelectStage)).Length;
    }

    public static void Changestage()
    {
        StageNum += 1;
        Debug.Log(StageName + StageNum);
        SceneManager.LoadScene(StageName + StageNum);
    }

    public static void ChengeTitle()
    {
        selectStage = 0;
        SceneManager.LoadScene("Title");
    }
}
