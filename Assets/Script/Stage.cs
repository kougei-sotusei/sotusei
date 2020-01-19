using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {

    public enum SelectStage
    {
        One=1,
        Two,
        Three,
        Four,
        Five
    }

    static SelectStage selectStage=SelectStage.One;

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
}
