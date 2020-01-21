using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.UI;

public class ObjController : MonoBehaviour
{

    [SerializeField] Transform OffMeshFlag;
    [SerializeField] Transform[] goalobj;
    [SerializeField] Transform camera;
    public Button button;
    NavMeshAgent navMeshAgent;
    bool clerFlag;
    bool mis;
    int StageNum;
    int Index;
    int Length;
    int clearNum;

    void Start()
    {
        clearNum = 0;
        clerFlag = false;
        StageNum = Stage.GetStage();
        Length = goalobj.Length;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    //ボタン押したら動き出す
    public void PushStart()
    {
        mis = false;
        Index = 1;
        button.enabled = false;
        navMeshAgent.destination = goalobj[Index].position;
    }


    //クリア判定
    //クリアしてなかったら所定の位置に戻る
    void OnTriggerEnter(Collider other)
    {
        bool nameflag = other.name == goalobj[Index].name;

        if (mis && Index > clearNum && nameflag)
        {
            Index -= 1;
            navMeshAgent.destination = goalobj[Index].position;
        }
        else if (!mis && Index < Length - 1 && nameflag)
        {
            Index += 1;
            navMeshAgent.destination = goalobj[Index].position;
        }
        else if (other.gameObject.name == OffMeshFlag.name)
        {
            clerFlag = ClerJudg.ClerCheck(StageNum, camera.rotation);
            Debug.Log(clerFlag);
            if (!clerFlag)
            {
                mis = true;
                if (Index >= 1)
                    Index -= 1;
                navMeshAgent.CompleteOffMeshLink();
                navMeshAgent.destination = goalobj[Index].position;
            }
            else
            {
                clearNum++;
            }
        }
        if (other.name == goalobj[0].name)
        {
            button.enabled = true;
        }
    }
}
