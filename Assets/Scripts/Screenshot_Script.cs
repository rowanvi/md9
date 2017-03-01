using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Screenshot_Script : MonoBehaviour {

    [SerializeField]
    private Region_Capture regionCapture;

    [SerializeField]
    private Renderer regionCaptureColor;

    [SerializeField]
    private RenderTextureCamera rtc;
    
    [HideInInspector]
    private bool scanned = false;

    void Start()
    {
        regionCapture.OnFocusedTarget += MakeScreenshot;
    }

    private void MakeScreenshot()
    {
        if (!scanned)
        {
            Camera.main.cullingMask = ~(0);
            StartCoroutine(Scan());
            scanned = true;
        }
    }

    private IEnumerator Scan()
{

    yield return new WaitForSeconds(3);
    yield return new WaitForEndOfFrame();

        regionCaptureColor.material.SetInt("_KG", 0);
        rtc.MakeScreen();

}




}
