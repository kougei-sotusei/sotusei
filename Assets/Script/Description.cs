using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{

    [SerializeField] GameObject description;
    float speed = 0.5f;
    float step;
    bool flag;
    float rot = 180f;

    void Start()
    {
        flag = false;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            flag = true;
        }

        if (flag)
        {
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rot), step);
        }
        if (transform.rotation.z == -rot)
            description.SetActive(false);
    }
}
