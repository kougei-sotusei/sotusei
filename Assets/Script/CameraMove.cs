using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] Camera camera;
    [SerializeField] float SwipeSpeed = 20f;
    [SerializeField] float pinchZoomSpeed = 5f;
    [SerializeField] float MaxSwipe = 30f;
    [SerializeField] float MinSwipe = -20f;
    float MaxAngleX = 85f;
    float MinAngleX = 280f;

    Vector3 MousePos;
    Vector3 CameraPos;
    float PinchZoomDistanceX = 0f;
    float PinchZoomDistanceY = 0f;
    float PinchDistance = 0f;
    bool MouseDown = false;
    bool PinchStart = true;

    [SerializeField] GameObject Player;
    ObjController objController;
    void Start()
    {
        objController = Player.GetComponent<ObjController>();
    }

    void Update()
    {

        if(objController.button.enabled)
        if (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && !MouseDown))
        {
            MousePos = Input.mousePosition;
            MouseDown = true;
        }
        //else if (Input.touchCount == 2)
        //{
        //    if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[1].phase == TouchPhase.Ended)
        //    {
        //        PinchStart = true;
        //    }
        //    else if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved)
        //    {
        //        if (PinchStart)
        //        {
        //            PinchStart = false;

        //            PinchDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
        //            CameraPos = camera.transform.localPosition;
        //        }

        //        float currentPinchDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
        //        float pinchZoomDistance = (PinchDistance - currentPinchDistance) * pinchZoomSpeed * 0.05f;
        //        float cameraPosZ = CameraPos.z - pinchZoomDistance;

        //        camera.transform.localPosition = new Vector3(camera.transform.localPosition.x, camera.transform.localPosition.y, cameraPosZ);
        //    }

        //    MouseDown = false;
        //}

        if (MouseDown)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 distanceMousePos = (mousePos - MousePos);
            float angleX = this.transform.eulerAngles.x - distanceMousePos.y * SwipeSpeed * 0.01f;
            float angleY = this.transform.eulerAngles.y + distanceMousePos.x * SwipeSpeed * 0.01f;

            PinchZoomDistanceX += distanceMousePos.x;
            PinchZoomDistanceY += distanceMousePos.y;

            if ((angleX >= -10 && angleX <= MaxAngleX) || (angleX >= MinAngleX && angleX <= 380))
            {
                this.transform.eulerAngles = new Vector3(angleX, angleY, 0);
            }
            else
            {
                this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, angleY, 0);
            }

            MousePos = mousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            MouseDown = false;

            PinchZoomDistanceX = 0;
            PinchZoomDistanceY = 0;
        }

    }
}
