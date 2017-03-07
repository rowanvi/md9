using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Screenshot_Script : MonoBehaviour {

    [SerializeField]
    private Region_Capture regionCapture;

    [SerializeField]
    private Renderer regionCaptureColor;

    [SerializeField]
    private RenderTextureCamera rtc;
    
    [HideInInspector]
    private bool scanned = false;

    public String fileName;

    void Start()
    {
        regionCapture.OnFocusedTarget += MakeScreenshot;
  
    }



    private void MakeScreenshot()
    {
   
            if (!scanned)
            {
                Camera.main.cullingMask = ~(1 << 9);
                StartCoroutine(Scan());

                scanned = true;

            }
        
    }

    private IEnumerator Scan()
    {

    
        yield return new WaitForEndOfFrame();
        regionCaptureColor.material.SetInt("_KG", 0);
        regionCaptureColor.material.SetInt("_KR", 0);
        yield return new WaitForSeconds(2);
        rtc.MakeScreen();
        yield return new WaitForEndOfFrame();
        StartCoroutine(Save());
        Camera.main.cullingMask = ~(0);

    }

    private IEnumerator Save()
    {
        yield return new WaitForEndOfFrame();
        Save_And_Load sal = new Save_And_Load();
        sal.fileLocation = rtc.test;
        sal.coloringPictureCategory = 1;
        sal.coloringPictureName = "test2";
        sal.date = "7-3-2017";
        string json = JsonUtility.ToJson(sal);

        string path = Application.persistentDataPath + "/json/screens.json";
        File.AppendAllText(path, json);

        Debug.Log(json);

    }

 



}
