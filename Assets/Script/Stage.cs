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
        One,
        Two,
        Three,
        Four,
        Five,
        Tutorial
    }

    static SelectStage selectStage = SelectStage.Title;

    public static int GetStage()
    {
        return (int)selectStage;
    }

    public static void SetNowStage(SelectStage stage)
    {
        selectStage = stage;
    }

    public static int MaxStageNum()
    {
        return (int)System.Enum.GetNames(typeof(SelectStage)).Length;
    }

    public static void Change()
    {
        switch (selectStage)
        {
            case SelectStage.Title:
                SceneManager.LoadScene("One");
                break;
            case SelectStage.One:
                SceneManager.LoadScene("Two");
                break;
            case SelectStage.Two:
                SceneManager.LoadScene("Three");
                break;
            case SelectStage.Three:
                SceneManager.LoadScene("Four");
                break;
            case SelectStage.Four:
                SceneManager.LoadScene("Five");
                break;
            case SelectStage.Five:
                SceneManager.LoadScene("Title");
                break;
        }
        
        if(selectStage!=SelectStage.Five)
        {
            selectStage += 1;
        }
        else
        {
            selectStage = 0;
        }

    }
    public static void ChengeTitle()
    {
        SceneManager.LoadScene("Title");
        selectStage = 0;
    }
}
