using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.UI;

public class ObjController : MonoBehaviour
{

    [SerializeField] Transform[] OffMeshFlag;
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
        Index = clearNum+1;
        button.enabled = false;
        navMeshAgent.destination = goalobj[Index].position;
    }


    //クリア判定
    //クリアしてなかったら所定の位置に戻る
    void OnTriggerEnter(Collider other)
    {
        bool nameflag = other.name == goalobj[Index].name;

        if (mis && Index > clearNum && nameflag)//帰り道のルートをただるため
        {
            Index -= 1;
            navMeshAgent.destination = goalobj[Index].position;
        }
        else if (!mis && Index < Length - 1 && nameflag)//生き道ののルートをただるため
        {
            Index += 1;
            navMeshAgent.destination = goalobj[Index].position;
        }
        else if (other.gameObject.name == OffMeshFlag[clearNum].name)//足場が離れているところを通れるかどうかの判定
        {
            clerFlag = ClerJudg.ClerCheck(camera.rotation);
            if (!clerFlag && !mis)
            {
                mis = true;
                if (Index >= 1)
                    Index -= 1;
                navMeshAgent.CompleteOffMeshLink();
                navMeshAgent.destination = goalobj[Index].position;
            }
            else if(clerFlag)
            {
                clearNum++;
            }
        }
        if (other.name == goalobj[clearNum].name)
        {
            button.enabled = true;
        }
    }
}
