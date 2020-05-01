/*
 *  @class      ManagerLoader
 *  @purpose    Load GameManager object from prefab this is used on the loading screen scene attached 
 *  
 *  @author     John Georgvich, previous CIS411 group
 *  @date       2020/01/22
 */
using UnityEngine;
using System.Collections;

public class ManagerLoader : MonoBehaviour
{
    //  create GameManager object prefab
    public GameObject gameManager;

        /*
     * @name    Awake
     * @purpose immediate creates a game manager if one is not created
     * 
     * @return  Instance of GameManager to public static GameManager object _instance
     */
    void Awake()
    {
        //this is commented out for now becasue I have the game running off the creation of the game manager being in the playerboard scene main camera
        ////  check if GameManager prefab has already been instantiated (see GameManager.cs)
        //if (GameManager.Instance == null)
        //    //  if GameManager prefab has not been instantiated, do so
        //    Instantiate(gameManager);
    }
}