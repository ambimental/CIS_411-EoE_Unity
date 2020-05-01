/*
 *  @class      CheckDeckAndDiscardPlayer
 *  @purpose    Facilitates action cards/card notes that require access to the deck/discard pile
 *  
 *  @author     John Georgvich, previos CIS411 group
 *  @date       2020/01/22
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeckAndDiscardPlayer : MonoBehaviour
{

    ////  used to view the cards in the discard/deck when needed
    //private GameObject viewDeckDiscard;
    ////  used to hide interface when selecting cards
    //private HideShowBoards board;
    ////  used to hide the hand when selecting cards
    //private GameObject handShow;

    ///*
    // *  @name       Start()
    // *  @purpose    Used to initialize Unity objects
    // */
    //void Start()
    //{
    //    viewDeckDiscard = GameObject.Find("Deck and Discard Canvas"); //gets the object for the variable
    //    GameManager.Instance.check = GameObject.Find("Main Camera").GetComponent<CheckDeckAndDiscardPlayer>(); //gets access to the script
    //    board = GameObject.Find("Main Camera").GetComponent<HideShowBoards>(); //gets access to the script
    //    handShow = GameObject.Find("Hand"); //gets the hand

    //    viewDeckDiscard.SetActive(false); //makes sure it doesnt show on the game start
    //}

    ///*
    // *  @name       Update()
    // *  @purpose    Called once-per-frame to update the object
    // */
    //void Update()
    //{

    //}

    ///*
    // *  @name       showDeckDiscard()
    // *  @purpose    hides game board/player hand and shows deck/discard
    // */
    //public void showDeckDiscard()
    //{
    //    board.showNone(); //hides everything
    //    handShow.SetActive(false);
    //    viewDeckDiscard.SetActive(true);
    //}

    ///*
    // *  @name       hideDeckDiscard()
    // *  @purpose    shows game board/player hand and hides deck/discard
    // */
    //public void hideDeckDiscard()
    //{
    //    viewDeckDiscard.SetActive(false);
    //    //board.ShowPlayer(); //shows the player one board again
    //    handShow.SetActive(true);
    //    GameManager.Instance.cardInfoPanel.SetActive(false);
    //}
}
