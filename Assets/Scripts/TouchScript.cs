using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TouchScript : MonoBehaviour {

    public bool touched;

    //On only 1 finger it works.
    void Update()
    {

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            touched = true;
        }
        else
        {
            touched = false;
        }

    }
}
