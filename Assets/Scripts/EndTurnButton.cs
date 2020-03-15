// THIS SCRIPT WILL BE USED TO START THE AI.  WILL ONLY BE CALLED WHEN THE END TURN BUTTON IS CLICKED

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour {

    Button endTurnButton; //will be used to access the onclick for the button itself

    GameObject mainCamera; //will be used when adding the script to the main menu object

    // Use this for initialization
    void Start () {
        endTurnButton = GameObject.Find("EndTurnButton").GetComponent<Button>();
        mainCamera = GameObject.Find("Main Camera");

        Button btn = endTurnButton; //just to use another variable so nothing is messed up
        btn.onClick.AddListener(TaskOnClick); //when the button is clicked, this is what occurs
	}

    void TaskOnClick()
    {
        //I BEN DISABLED THIS JUST AS A REMINDER TO MYSELF
        //mainCamera.AddComponent<CP1AI>(); //adds this script to the main camera
    }

}
