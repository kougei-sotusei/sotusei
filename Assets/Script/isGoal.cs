using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGoal : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        FadeController.FadeFlag();
    }
}
