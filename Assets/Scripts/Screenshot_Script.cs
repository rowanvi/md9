using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



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
        sal.coloringPictureName = "123";
        sal.date = "8-3-2017";
        string json = JsonUtility.ToJson(sal);
        string path = rtc.test2 + "/json/screens.json";
        string[] lines = File.ReadAllLines(path);
        string[] lines2 = new string[lines.Length + 2];
        lines2[lines.Length + 1] = json;
        File.WriteAllLines(path, lines2);

         Debug.Log(json);


    }


    private IEnumerator Save2()
    {

            string LogfilePath = rtc.test2 + "/test.txt";
        string TextToWrite = "saads";
    yield return new WaitForEndOfFrame();
        if (TextToWrite == "")
        {
            Debug.Log("You can't create a Textfile !!!" + "Please specify a path and a message");
        }
        if (LogfilePath == "")
        {
            Debug.Log("You can't create a Textfile !!!" + "Please specify a path and a message");
        }
        System.IO.File.AppendAllText(LogfilePath, TextToWrite);
        Debug.Log("Log file created in " + LogfilePath + " your Text was  " + TextToWrite);

    }

    void load()
    {

    }





}


public class LogFile : MonoBehaviour
{

    [Header("Strings for Log-File")]
    public string LogfilePath = "yourpath\\yourfile.txt";
    public string TextToWrite;

    public void CreateLogFile()
    {

        if (TextToWrite == "")
        {
            Debug.Log("You can't create a Textfile !!!" + "Please specify a path and a message");
        }
        if (LogfilePath == "")
        {
            Debug.Log("You can't create a Textfile !!!" + "Please specify a path and a message");
        }
        System.IO.File.WriteAllText(LogfilePath, TextToWrite);
        Debug.Log("Log file created in " + LogfilePath + " your Text was  " + TextToWrite);

    }

}
