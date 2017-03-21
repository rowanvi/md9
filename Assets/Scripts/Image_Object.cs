using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Scanned object initialization.
[Serializable]
public class Image_Object {

    public string coloringPictureName;
    public string fileLocation;
    public string date;
    public int coloringPictureCategory;
}

//List of scanned object initialization and add function.
[Serializable]
public class listImage
{   
    public List<Image_Object> loadList = new List<Image_Object>();

    public void addImageObject(Image_Object imageObject)
    {
        loadList.Add(imageObject);
    }
    
}