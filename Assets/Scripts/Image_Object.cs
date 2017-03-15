using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Image_Object {

    public string coloringPictureName;
    public string fileLocation;
    public string date;
    public int coloringPictureCategory;
}
[Serializable]
public class listImage
{   
    public List<Image_Object> loadList = new List<Image_Object>();

    public void addImageObject(Image_Object imageObject)
    {
        loadList.Add(imageObject);
    }
    
}