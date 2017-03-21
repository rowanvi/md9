using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TouchScript : MonoBehaviour {

    public int current;
    public Texture[] textures;

    //On only 1 finger it works.
    void Start()
    {
        Renderer.FindObjectOfType<MeshRenderer>().material.mainTexture = textures[0];
        current = 0;
    }

    void Update()
    {

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            SetTexture();
            
        }
       



    }

    public void SetTexture()
    {
        if (current == 1) 
        {

            Renderer.FindObjectOfType<MeshRenderer>().material.mainTexture = textures[0];
            current = 0;
        }else
        {
            Renderer.FindObjectOfType<MeshRenderer>().material.mainTexture = textures[1];
            current = 1;

        }

    }
}
