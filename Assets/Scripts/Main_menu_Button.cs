using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu_Button : MonoBehaviour {

	// Use this for initialization
	public void ScanMenu () {
        SceneManager.LoadScene("Scan_Screen");
    }

    public void ScanBack()
    {
        SceneManager.LoadScene("Main_Menu");
    }


}
