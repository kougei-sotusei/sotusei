using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjController : MonoBehaviour {

    [SerializeField] Transform obj;

    NavMeshAgent navMeshAgent;
    
    void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.destination = obj.position;
    }
}
