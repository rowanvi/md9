using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCubeLoadImage : MonoBehaviour {

    public MeshRenderer meshRenderer;
	// Use this for initialization
	void Start () {
        string url = SaveDataManager.Instance.GetTextureLoadUrlFromName(SaveDataManager.Instance.previewImageName);
        Image_Load il = Image_Load.CreateImageLoader(url);
        il.OnTextureLoaded += TextureLoaded;
    }

    void TextureLoaded(Texture tex)
    {
        Debug.Log(name);
        meshRenderer.material.mainTexture = tex;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
