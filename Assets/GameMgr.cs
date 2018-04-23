using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {

	// Use this for initialization
	public void Start () {
        SceneManager.LoadScene("Test1");
    }

	
	// Update is called once per frame
	void Update () {
		
	}



    //  End the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
