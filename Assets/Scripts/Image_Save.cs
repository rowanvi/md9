using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class Image_Save : MonoBehaviour {

    //Needed variables from the plugin region capture.
    [SerializeField]
    private Region_Capture regionCapture;

    [SerializeField]
    private Renderer regionCaptureColor;

    [SerializeField]
    private RenderTextureCamera rtc;
    
    //Other necessary variables.
    [HideInInspector]
    private bool scanned = false;
    [HideInInspector]
    private int id = 0;

    public String fileName;

    //On start it set the action OnFocusTarget assigned to the method makeScreenshot
    void Start()
    {
        regionCapture.OnFocusedTarget += MakeScreenshot;
  
    }


    //Make screen checks if it is already scanned. It also calls the scan method.
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


    //Scan method is for scanning and calling the makescreen method.
    private IEnumerator Scan()
    {

        //Turns the debug colors off
        yield return new WaitForEndOfFrame();
        regionCaptureColor.material.SetInt("_KG", 0);
        regionCaptureColor.material.SetInt("_KR", 0);
        //Makescreen method
        yield return new WaitForSeconds(2);
        rtc.MakeScreen();
        yield return new WaitForEndOfFrame();
        //Save method
        StartCoroutine(Save());
        Camera.main.cullingMask = ~(0);

    }

    //Save method saves the image in to the data of the device
    // and also store the object into the player prefs
    // this is for loading the image without any coloring picture.
    private IEnumerator Save()
    {
        
        yield return new WaitForEndOfFrame();
        Image_Object sal = new Image_Object();
      
        sal.fileLocation = rtc.test;
        sal.coloringPictureCategory = 1;
        sal.coloringPictureName = System.DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");

        sal.date = System.DateTime.Now.ToString("dd-MM-yyyy");
        string jsonData = PlayerPrefs.GetString("screensList");

        listImage data;
        if (string.IsNullOrEmpty(jsonData))
        {
            data = new listImage();
        }
        else data = JsonUtility.FromJson<listImage>(jsonData);

        data.addImageObject(sal);
        PlayerPrefs.SetString("screensList", JsonUtility.ToJson(data));
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("screensList"));


    }

 



}
