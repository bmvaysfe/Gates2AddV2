using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test2 : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }
	
    
	// Update is called once per frame
	void Update () {
		
	}
    
    //  future support as of 09.08.17
    /*
    public void StartNextLevel2()
    {
        SceneManager.LoadScene("Test2");
    }

    */
    //  End the game
    public void ExitGame()
    {
        Application.Quit();
    }

}
