/*
 *  @class      ChangeScenes
 *  @purpose    handles scene transition between game scenes
 *  
 *  @author     John Georgvich, previous CIS411 group
 *  @date       2020/01/22
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour {

    /*
     *  @name       ChangeScene()
     *  @purpose    Changes active game scene to appropriate scene
     *  
     *  @param      string sceneName;   the name of the appropriate scene
     */

    public Text changeLoadingText;

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

            /*this will be to change the text if you are exiting game and loading screen is called to restart game and retur to menu, the text
            will say "returning to menu"
            *
            * none of this is instanitated yet its a placeholder code to come back to finsih when ready
            * if (menuReturn=true){
            * ChangeLoadingText();
            * }
            */
        }
        catch
        {
        }
    }

   //the function to change text
   public void ChangeLoadingText()
    {
        //changes the text
        changeLoadingText.text = "RETURNING TO MENU...";
        
        //sets the variable back so text can be changed back to laoding Decks
       // menuReturn = false;


    }
}
