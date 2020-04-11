/*
 *  @class      ChangeScenes
 *  @purpose    handles scene transition between game scenes
 *  
 *  @author     CIS 411
 *  @date       2020/01/22
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{

    /*
     *  @name       ChangeScene()
     *  @purpose    Changes active game scene to appropriate scene
     *  
     *  @param      string sceneName;   the name of the appropriate scene
     */
    public void ChangeScene(string sceneName)
    {
        try
        {
            SceneManager.LoadScene(sceneName);

            //  if next scene is LoadingScreen, call GameManager.restartGame()
            if (sceneName == "LoadingScreen")
            {
                GameManager.Instance.restartGame();
            }
        }
        catch
        {
        }
    }
}
