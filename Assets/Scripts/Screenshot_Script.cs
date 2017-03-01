using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot_Script : MonoBehaviour {
    public string screenshotName;
    private bool takingPicture = false;

    // Use this for initialization
    public void Screenshot () {
        if (!takingPicture)
        {
            StartCoroutine(BeforePicture());
            takingPicture = true;
            //screenshotName = "Screenshot_ " + System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png";
            //Application.CaptureScreenshot(screenshotName);
                
            StartCoroutine(AfterPicture());         
            takingPicture = false;

            
         }
    }

    IEnumerator AfterPicture()
    {
        yield return new WaitForEndOfFrame();
        // ~(0) Reset it to render every layer
        Camera.main.cullingMask = ~(0);
    }

    IEnumerator BeforePicture()
    {
        Camera.main.cullingMask = ~(1 << 9);
        yield return new WaitForEndOfFrame();
        
    }

}
