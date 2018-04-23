using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class GameStart2 : MonoBehaviour
{
    //public GameObject startButton, exitButton;
	// Use this for initialization
	public void StartGame () {
          SceneManager.LoadScene("Test0");
    }
	
    /*
	// Update is called once per frame
	void Update () {
		
	}
    */

    //  End the game
    public void ExitGame()
    {
        Application.Quit(); 
    }
}
