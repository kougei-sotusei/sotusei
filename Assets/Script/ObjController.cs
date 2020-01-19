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
        StageNum = = Stage.GetStage();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    //ボタン押したら動き出す
    //一緒にクリアしてるかどうかも判定
    public void PushStart()
    {
        clerFlag = ClerJudg.ClerCheck(StageNum,camera.rotation);

        navMeshAgent.destination = Endobj.position;
    }


    void OnTriggerEnter(Collider other)
    {
        bool Nameflag = other.gameObject.name == Endobj.name;

        if(Nameflag && clerFlag)
        {
            this.transform.DOMove(
            Startobj.transform.position, 0.5f);
            GetComponent<NavMeshAgent>().enabled = false;
        }
        else if (Nameflag)
        {
            navMeshAgent.destination = Startobj.position;
        }
    }
}
