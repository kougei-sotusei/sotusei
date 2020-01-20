using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class ObjController : MonoBehaviour
{

    [SerializeField] Transform OffMeshStart;
    [SerializeField] Transform OffMeshFlag;
    [SerializeField] Transform[] goleobj;
    [SerializeField] Transform Initialpos;
    [SerializeField] Transform camera;

    NavMeshAgent navMeshAgent;
    bool clerFlag;
    int StageNum;
    int Index;
    int Length;

    void Start()
    {
        clerFlag = false;
        StageNum = Stage.GetStage();
        Length = goleobj.Length;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    //ボタン押したら動き出す
    public virtual void PushStart()
    {
        Index = 0;
        OffMeshStart.gameObject.SetActive(true);
        navMeshAgent.destination = goleobj[0].position;
    }

    //クリア判定
    //クリアしてなかったら所定の位置に戻る
    void OnTriggerEnter(Collider other)
    {
        if (other.name == goleobj[Index].name && Index < Length)
        {
            Index += 1;
            navMeshAgent.destination = goleobj[Index].position;
        }
        else if (other.gameObject.name == OffMeshFlag.name)
        {
            //clerFlag = ClerJudg.ClerCheck(StageNum, camera.rotation);
            if (!clerFlag)
            {
                Index--;
                navMeshAgent.CompleteOffMeshLink();
                navMeshAgent.destination = Initialpos.position;
            }
        }
    }
}
