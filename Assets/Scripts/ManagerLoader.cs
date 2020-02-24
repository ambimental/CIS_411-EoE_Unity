/*
 *  @class      ManagerLoader
 *  @purpose    Load GameManager object from prefab
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


    void Awake()
    {
        //  check if GameManager prefab has already been instantiated (see GameManager.cs)
        if (GameManager.Instance == null)
            //  if GameManager prefab has not been instantiated, do so
            Instantiate(gameManager);
    }
}