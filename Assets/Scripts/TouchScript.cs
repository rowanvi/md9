using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TouchScript : MonoBehaviour {

    private bool takingPicture = false;
    public LayerMask layermask;
    public string screenshotName;
    bool[] test = new bool[32];

    void Start()
    {
    }
    //On only 1 finger it takes a screenshot
    void Update()
    {

        if (Input.touchCount == 1 && !takingPicture)
        {
            Touch touch = Input.GetTouch(0);
            takingPicture = true;

      

            screenshotName = "Screenshot_ " + System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png";
            Application.CaptureScreenshot(screenshotName);

            // ~(0) Reset it to render every layer
            Camera.current.cullingMask = ~(0);
            takingPicture = false;
        }

    }
}
