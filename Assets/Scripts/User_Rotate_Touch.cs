using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User_Rotate_Touch : MonoBehaviour {

    public Transform cam; // Drag camera here
    public float rotationSpeedMouse; // rotationspeed for mouse

    [SerializeField]
    private float rotationSpeedFinger; // rotationspeed for finger

    private float screenResX;
    private float screenResY;

    void Update()
    {
        //To prevent rotation, don't call this method
        RotateObject();
    }

    private void RotateObject()
    {
        //With 1 finger check movement and apply it on this object
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                //Based on if Unity returns DPI value
                if (Screen.dpi > 0)
                {
                    screenResX = Screen.width / Screen.dpi;
                    screenResY = Screen.height / Screen.dpi;
                    transform.Rotate(cam.right, (touch.deltaPosition.y / screenResY), Space.World);
                    transform.Rotate(-cam.up, (touch.deltaPosition.x / screenResX), Space.World);
                }
                else
                {
                    transform.Rotate(cam.right, (touch.deltaPosition.y / Screen.height), Space.World);
                    transform.Rotate(-cam.up, (touch.deltaPosition.x / Screen.width), Space.World);
                }
            }
        }

        //To test with mouse
        transform.Rotate(cam.right, (Input.GetAxis("Mouse Y") / Screen.height) * rotationSpeedMouse, Space.World);
        transform.Rotate(-cam.up, (Input.GetAxis("Mouse X") / Screen.width) * rotationSpeedMouse, Space.World);
    }

}
