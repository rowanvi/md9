using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu_Button : MonoBehaviour {

	// Use this for initialization
	public void ScanClick () {
        SceneManager.LoadScene("Vuforia_Test");
    }


}
