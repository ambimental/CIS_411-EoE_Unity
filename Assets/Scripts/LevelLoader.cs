/*
 *  @class      GameManager.cs
 *  @purpose    This is what controls the loading screen 
 *  
 *  @author     CIS 411
 *  @date       2020/03/01
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    private float counter = 0.1f;
    //serializefield make private objects availabe in untiy inspector
    [SerializeField] private Slider slider;

    //these are used to determin if the tet displayed on the loading says laoding decks or returning to menu
    private bool returnToMenu = true;
    private Text returnToMenuText;

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
    {
        StartCoroutine(LoadAsynchronously("MainMenu")); //calls the coroutine and starts laoding the function asynchronously
    }

        /*
     * @name    LoadAsynchronously
     * @purpose creates a timer like loop to move the slider across the screen
     * 
     * @return 
     */
    IEnumerator LoadAsynchronously(string name) //will be used to load the scene and keep track of the progress
    {
        while (Counter <= 1.0f)
        {
            //put this back to 0.005f when you are done testing - ben
            Counter += 0.05f;
            Slider.value = Counter;
            yield return null;
        }

        SceneManager.LoadSceneAsync(name);
    }

    //accessors and mutators
    public float Counter { get => counter; set => counter = value; }
    public Slider Slider { get => slider; set => slider = value; }
    public bool ReturnToMenu { get => returnToMenu; set => returnToMenu = value; }
    public Text ReturnToMenuText { get => returnToMenuText; set => returnToMenuText = value; }
}
