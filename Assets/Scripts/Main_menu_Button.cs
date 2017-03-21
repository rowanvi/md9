using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu_Button : MonoBehaviour {

	// Use this for initialization
	public void ScanMenu () {
        SceneManager.LoadScene("Scan_Screen");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Preview_Screen");
    }

    public void LoadScreen()
    {
        SceneManager.LoadScene("test_for_list");
    }

}
