using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test1 : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartNextLevel2()
    {
        SceneManager.LoadScene("Test2");
    }

    //  End the game
    public void ExitGame()
    {
        Application.Quit();
    }

}
