using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplainController : MonoBehaviour {

    GameObject explainpic;
    //Touch touch;

    // Use this for initialization
    void Start () {
        explainpic = new GameObject("ExplainPic");
        explainpic.transform.parent = GameObject.Find("Canvas").transform;
        explainpic.AddComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        explainpic.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
        explainpic.AddComponent<Image>().sprite = Resources.Load<Sprite>("Explain");
        explainpic.GetComponent<Image>().preserveAspect = true;
        explainpic.GetComponent<Image>().SetNativeSize();
        explainpic.GetComponent<Image>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        /*Touch touch = Input.GetTouch(0);

        if(touch.phase==TouchPhase.Began)
        { explainpic.GetComponent<Image>().enabled = false; }
        */
        if(Input.GetMouseButtonDown(0))
        { explainpic.GetComponent<Image>().enabled = false; }
	}

    public void ImageEnable(){
        explainpic.GetComponent<Image>().enabled = true;
        
    }

}
