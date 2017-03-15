using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class Image_Save : MonoBehaviour {


    [SerializeField]
    private Region_Capture regionCapture;

    [SerializeField]
    private Renderer regionCaptureColor;

    [SerializeField]
    private RenderTextureCamera rtc;
    
    [HideInInspector]
    private bool scanned = false;
    [HideInInspector]
    private int id = 0;

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
            regionCapture.ColorDebugMode = false;

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
        Image_Object sal = new Image_Object();
        listImage li = new listImage();
        sal.fileLocation = rtc.test;
        sal.coloringPictureCategory = 1;
        sal.coloringPictureName = "testnieuwenaam";
        sal.date = System.DateTime.Now.ToString("dd-MM-yyyy");
        li.addImageObject(sal);
        
        string path = Application.persistentDataPath + "/json/screens.json";
        PlayerPrefs.SetString("screensList", JsonUtility.ToJson(li));
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("screensList"));
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Preview_Screen");

    }

 



}
