//THIS SCRIPT WILL BE USED FOR THE ACTION CARDS THAT NEED ACCESS TO THE DECK AND THE DISCARD PILE.  
//BASED ON THE TYPE NEEDED, SHOULD BE ABLE TO SORT THROUGH THE DECK AND THE DISCARD PILE, SHOW ALL OF THE CARDS
//TO THE PLAYER, THEN THE PLAYER SHOULD BE ABLE TO SELECT/DRAG THAT CARD TO THE APPROPRIATE ZONE    

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeckAndDiscardPlayer : MonoBehaviour {

    public GameObject viewDeckDiscard; //will be used to view the cards in the discard and the deck pile when needed by the actions
    public HideShowBoards board; //will be used to hide everything while the picking of cards is shown
    public GameObject handShow; //will be used to hide the hand

	// Use this for initialization
	void Start () {
        viewDeckDiscard = GameObject.Find("Deck and Discard Canvas"); //gets the object for the variable
        GameManager.Instance.check = GameObject.Find("Main Camera").GetComponent<CheckDeckAndDiscardPlayer>(); //gets access to the script
        board = GameObject.Find("Main Camera").GetComponent<HideShowBoards>(); //gets access to the script
        handShow = GameObject.Find("Hand"); //gets the hand

        viewDeckDiscard.SetActive(false); //makes sure it doesnt show on the game start
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //will be used when an action requires the deck and discards to be shown
    public void showDeckDiscard()
    {
        board.showNone(); //hides everything
        handShow.SetActive(false);
        viewDeckDiscard.SetActive(true);
        Time.timeScale = 1f;
    }

    public void hideDeckDiscard()
    {
        viewDeckDiscard.SetActive(false);
        Time.timeScale = 0f;
        //board.ShowPlayer(); //shows the player one board again
        handShow.SetActive(true);
        GameManager.Instance.cardInfoPanel.SetActive(false);
    }
}
