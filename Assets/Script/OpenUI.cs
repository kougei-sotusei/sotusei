using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUI : MonoBehaviour {

    [SerializeField] GameObject Panel;

    public void Open()
    {
        Panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Close()
    {
        Time.timeScale = 1;
        Panel.SetActive(false);
    }
    public void to_Title()
    {
        Panel.SetActive(false);
        Time.timeScale = 1;
        Stage.ChengeTitle();
    }
}
