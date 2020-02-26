using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public static bool gamePaused = false; //determines if the game is paused or not

    public GameObject pauseMenuUI; //to get the pause menu 

	// Use this for initialization
	void Start () {
        pauseMenuUI = GameObject.Find("Pause");
        pauseMenuUI.SetActive(false); //sets it t false on the start
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //will resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false); //sets the pause menu not active
        Time.timeScale = 1f; //returns game back to normal
        gamePaused = false;
    }

    //will pause the game
    public void Pause()
    {
        pauseMenuUI.SetActive(true); //sets the pause menu to active
        Time.timeScale = 0f; //freezes the game
        gamePaused = true;
    }
}
