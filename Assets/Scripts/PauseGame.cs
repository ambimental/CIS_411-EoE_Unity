using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public static bool gamePaused = false; //determines if the game is paused or not

    /*THIS IS TEMPORARY TO CLOSE THING UNTIL I FIGURE OUT WHERE THE BEST PLACE TO PUT IT IS*/
    public GameObject acidTemp;

    public GameObject pauseMenuUI; //to get the pause menu 
    //creates object for learntToplay panel
    public GameObject learnToPlayUI;

	// Use this for initialization
	void Start () {
        pauseMenuUI = GameObject.Find("Pause");
        pauseMenuUI.SetActive(false); //sets it t false on the start
        //find the learnToPlayScene and assigns it to oject
        learnToPlayUI = GameObject.Find("LearnToPlay");
        //sets the screen so its not visible
        learnToPlayUI.SetActive(false);


        /*THIS IS TEMPORARY TO CLOSE THING UNTIL I FIGURE OUT WHERE THE BEST PLACE TO PUT IT IS*/
        acidTemp = GameObject.Find("AcidicWatersPanel");

}
	
	// Update is called once per frame
	void Update () {
		
	}

    //will resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false); //sets the pause menu not active
        learnToPlayUI.SetActive(false);
        Time.timeScale = 1f; //returns game back to normal
        gamePaused = false;
    }

    //will pause the game
    //fortesting make sure when the learn to playy button "close" is clicked and this function is called it doesnt fuck anything up with the clocl
    public void Pause()
    {
        pauseMenuUI.SetActive(true); //sets the pause menu to active
        //sets the learn to play to inaactive 
        learnToPlayUI.SetActive(false);
        Time.timeScale = 0f; //freezes the game
        gamePaused = true;
    }

    //opens the learn to play canvas where the instructions are shown
    public void LearnToPlay()
    {
        //sets the learn to play panel to active
        pauseMenuUI.SetActive(false);
        learnToPlayUI.SetActive(true);
    }

    public void LearnToPlayClose()
    {
        learnToPlayUI.SetActive(false);
    }

    /*THIS IS TEMPORARY TO CLOSE THING UNTIL I FIGURE OUT WHERE THE BEST PLACE TO PUT IT IS*/
    public void AcidicWatersCloseTemp()
    {
        acidTemp.SetActive(false);
    }

}
