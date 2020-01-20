using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUI : MonoBehaviour {

    [SerializeField] GameObject Panel;

    public void Open()
    {
        Panel.SetActive(true);
    }
    public void Close()
    {
        Panel.SetActive(false);
    }
    public void to_Title()
    {
        Panel.SetActive(false);
        Stage.ChengeTitle();
    }
}
