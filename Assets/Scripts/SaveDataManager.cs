using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : Singleton<SaveDataManager> {

    public string previewImageName = "";

    //This method looks of the texture name excist
    public string GetTextureLoadUrlFromName(string name)
    {

        //Variables we need, Jsondata for the data from the json file
        //string path = Application.persistentDataPath + "/json/screens.json";
        string playerData = PlayerPrefs.GetString("screensList");

        //Checks if json data is empty or null, it creates a new one when it's empty.
        listImage data;
        if (string.IsNullOrEmpty(playerData))
        {
            data = new listImage();
        }
        else data = JsonUtility.FromJson<listImage>(playerData);


        //Search for the texture for the mapping.
        Debug.Log(data.loadList.Count);
        for (int i = 0; i < data.loadList.Count; i++)
        {
            Debug.Log(data.loadList[i]);
            if (name.Equals(data.loadList[i].coloringPictureName))
            {
                //Creates data url from file location and start the loadtexture method.

                string url = "file://" + data.loadList[i].fileLocation;
                return url;


            }
        }

        return "";
    }
}
