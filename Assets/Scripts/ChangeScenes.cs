//WILL BE USED TO CHANGE THE SCENE WHENEVER NECESSARY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour {

    //NO NEED FOR START OR UPDATE FUNCTIONS

    // Changes to the appropriate scene
    public void ChangeScene(string sceneName)
    {
        try
        {
            SceneManager.LoadScene(sceneName);

            if (sceneName == "LoadingScreen") //for when the game is restarted - where the game manager should be reset
            {
                GameManager.Instance.restartGame();
            }
        }
        catch
        {
        }
    }
}
