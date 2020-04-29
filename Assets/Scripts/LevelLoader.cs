//WILL BE USED TO CREATE THE INITIAL LOADING SCREEN FOR THE GAME

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    float counter = 0.1f;
    public Slider slider;

<<<<<<< Updated upstream
    public void loadLevel() //will load the next level whenever is necessary
=======
    /*
    * @name    Start
    * @purpose calls the level loader that starts the couroutine
    * @return  void
    */
    void Start()
    {
        //finds the text object
        ReturnToMenuText = GameObject.Find("Loading Text").GetComponent<Text>();

        //based off of if the player is starting the game or returning to the main menu the text is changed
        if (ReturnToMenu == true)
        {
            ReturnToMenuText.text = "Going to Main Menu...";
        }

        LoadLevel();
    }

        /*
     * @name    loadLevel
     * @purpose starts a coroutine to start the level loader slider then transitions to Main Menu Scene
     * 
     * @return  void
     */
    public void LoadLevel()
>>>>>>> Stashed changes
    {
        StartCoroutine(LoadAsynchronously("MainMenu")); //calls the coroutine and starts laoding the function asynchronously
    }

    IEnumerator LoadAsynchronously(string name) //will be used to load the scene and keep track of the progress
    {
        while (counter <= 1.0f)
        {
<<<<<<< Updated upstream
            counter += 0.005f;
            slider.value = counter;
=======
            //put this back to 0.005f when you are done testing - ben
            Counter += 0.005f;
            Slider.value = Counter;
>>>>>>> Stashed changes
            yield return null;
        }

        SceneManager.LoadSceneAsync(name);
    }

    private void Start()
    {
        loadLevel();
    }
}
