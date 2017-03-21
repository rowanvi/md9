using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Image_Load : MonoBehaviour {

    //Initialization of variables
    public GameObject ListItemPrefab;
    public GameObject ContentPanel;


    public Action<Texture> OnTextureLoaded;

    private string loadUrl;


    //Load the texture on the mapping
    IEnumerator loadTexture(string url)
    {
        //Creates new file url and return the texture of it and render it on the object.
        Debug.Log("www");
        Debug.Log(url);
        WWW www = new WWW(url);
        yield return www;
        Debug.Log(www.texture);
        OnTextureLoaded(www.texture);
        Destroy(this.gameObject);
    }

    public void LoadTexture(string url)
    {
        StartCoroutine(loadTexture(url));
    }

    void Start()
    {
        LoadTexture(loadUrl);
    }

    public static Image_Load CreateImageLoader(string url)
    {
        GameObject ga = new GameObject("Image loader:" + url);
        Image_Load imgLoad = ga.AddComponent<Image_Load>();
        imgLoad.loadUrl = url;
        return imgLoad;
    }


    

}

