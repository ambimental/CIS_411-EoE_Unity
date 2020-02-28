//WILL BE USED TO CREATE THE INITIAL LOADING SCREEN FOR THE GAME

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    float counter = 0.1f;
    public Slider slider;

    public void loadLevel() //will load the next level whenever is necessary
    {
        StartCoroutine(LoadAsynchronously("MainMenu")); //calls the coroutine and starts laoding the function asynchronously
    }

    IEnumerator LoadAsynchronously(string name) //will be used to load the scene and keep track of the progress
    {
        while (counter <= 1.0f)
        {
            counter += 0.005f;
            slider.value = counter;
            yield return null;
        }

        SceneManager.LoadSceneAsync(name);
    }

    private void Start()
    {
        loadLevel();
    }
}
