using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Image_Load : MonoBehaviour {
    private Image_Object load;
    private string url;
    // Use this for initialization

    void Start()
    {
        doesTextureExcist("testnieuwenaam");
    }
    public void doesTextureExcist(string name)
    {
            

        string path = Application.persistentDataPath + "/json/screens.json";
        string jsonData = PlayerPrefs.GetString("screensList");
        Debug.Log("jsonData:"+jsonData);
        listImage data;
        if (string.IsNullOrEmpty(jsonData))
        {
            data = new listImage();
        }
        else data = JsonUtility.FromJson<listImage>(jsonData);

        for (int i = 0; i < data.loadList.Count; i++)
        {
            Debug.Log(data.loadList[i]);
            if (name.Equals(data.loadList[i].coloringPictureName))
            {
  
                url =  "file://" + data.loadList[i].fileLocation;
                StartCoroutine(loadTexture());
                
            }
        }
        
        
    }

    IEnumerator loadTexture()
    {

        WWW www = new WWW(url);
        yield return www;
        Debug.Log(www.texture);
        Renderer renderer = GetComponent<Renderer>();
        Renderer.FindObjectOfType<MeshRenderer>().material.mainTexture = www.texture;

    }
        


    

}

