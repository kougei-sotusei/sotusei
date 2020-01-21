using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleStageMove : MonoBehaviour
{

    float speed = 1f;
    float step;
    bool flag = true;
    bool start=true;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject OffMeshFlag;
    ObjController objController;

    void Start()
    {
        objController = Player.GetComponent<ObjController>();
    }
    void Update()
    {

        if (objController.button.enabled && start)
        {
            objController.PushStart();
            start = false;
        }
        if (flag)
        {
            Answer();
        }
        else
        {
            NotAnswer();
        }

        if (objController.button.enabled)
            objController.PushStart();
    }

    void Answer()
    {
        step = speed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(74.8f, 36, 0), step);
        OffMeshFlag.SetActive(false);

        if (objController.button.enabled)
         flag = false;
    }
    void NotAnswer()
    {
        step = speed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(30f, -90, 0), step);
        OffMeshFlag.SetActive(true);

        if (objController.button.enabled)
            flag = true;
    }
}
