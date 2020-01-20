using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.UI;

public class ObjController : MonoBehaviour
{

    [SerializeField] Transform OffMeshFlag;
    [SerializeField] Transform[] goleobj;
    [SerializeField] Transform camera;
    [SerializeField] Button button;
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
        Length = goleobj.Length;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    //ボタン押したら動き出す
    public virtual void PushStart()
    {
        mis = false;
        Index = 1;
        button.enabled = false;
        navMeshAgent.destination = goleobj[Index].position;
    }


    //クリア判定
    //クリアしてなかったら所定の位置に戻る
    void OnTriggerEnter(Collider other)
    {
        bool nameflag = other.name == goleobj[Index].name;

        if (mis && Index > clearNum && nameflag)
        {
            Index -= 1;
            navMeshAgent.destination = goleobj[Index].position;
        }
        else if (!mis && Index < Length && nameflag)
        {
            Index += 1;
            navMeshAgent.destination = goleobj[Index].position;
        }
        else if (other.gameObject.name == OffMeshFlag.name)
        {
            //clerFlag = ClerJudg.ClerCheck(StageNum, camera.rotation);
            if (!clerFlag)
            {
                mis = true;
                if (Index >= 1)
                    Index -= 1;
                navMeshAgent.CompleteOffMeshLink();
                navMeshAgent.destination = goleobj[Index].position;
            }
            else
            {
                clearNum++;
            }
        }

        if (other.name == goleobj[0].name)
        {
            button.enabled = true;
        }
    }
}
