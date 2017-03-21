using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Image_GetListOfSavedFiles : MonoBehaviour
{

    //Initialization of variables
    private string url;
    public GameObject ListItemPrefab;
    public GameObject ContentPanel;

    void Start()
    {
        GetTextureList();
    }



    public void GetTextureList()
    {

        string playerData = PlayerPrefs.GetString("screensList");
        listImage data;
        if (string.IsNullOrEmpty(playerData))
        {
            data = new listImage();
        }
        else data = JsonUtility.FromJson<listImage>(playerData);

        for (int i = 0; i < data.loadList.Count; i++)
        {

            GameObject newSaveLoad = Instantiate(ListItemPrefab) as GameObject;
            ListButton controller = newSaveLoad.GetComponent<ListButton>();
            controller.nameLabel.text = data.loadList[i].coloringPictureName;

            newSaveLoad.transform.parent = ContentPanel.transform;
            newSaveLoad.transform.localScale = Vector3.one;

            

        }

        


    }
    


}

