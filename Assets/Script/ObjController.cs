using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class ObjController : MonoBehaviour {

    [SerializeField] Transform Startobj;
    [SerializeField] Transform Endobj;
    [SerializeField] Transform camera;

    NavMeshAgent navMeshAgent;
 
    bool clerFlag;
    int StageNum;

    void Start () {
        clerFlag = false;
        StageNum =  Stage.GetStage();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    //ボタン押したら動き出す
    public void PushStart()
    {
        navMeshAgent.destination = Endobj.position;
    }

    //クリア判定
    //クリアしてなかったら所定の位置に戻る
    void OnTriggerEnter(Collider other)
    {
        bool Nameflag = other.gameObject.name == Endobj.name;

        if(Nameflag)
        {
            //clerFlag = ClerJudg.ClerCheck(StageNum, camera.rotation);
            if (clerFlag)
            {
                this.transform.DOMove(
                Startobj.transform.position, 0.5f);
                GetComponent<NavMeshAgent>().enabled = false;
            }
            else
            {
                navMeshAgent.destination = Startobj.position;
            }
        }
    }
}
