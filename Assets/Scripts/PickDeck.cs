///*
// *  @class      PickDeck
// *  @purpose    Facilitate player deck selection
// *  
// *  @author     John Georgvich, previous CIS411 group
// *  @date       2020/01/22
// */

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PickDeck : MonoBehaviour {

//    //  random deck class variable
//    public int randomDeck;

//    /*
//     *  @name       Start()
//     *  @purpose    Required to initialize by Unity
//     *  
//     *  @ATTN:      donotdestroyonload so variable is not destroyed
//     */
//    public void Start()
//    {
//        //  ???
//        //dbConnect = new databaseConnection();
//    }

//    /*
//     *  @name       SelectedDeck()
//     *  @purpose    Determines which deck was selected and assigns CP decks based on that
//     *  
//     *  @param      int deck;   deck selected by human player
//     */
//    public void SelectedDeck(int deck)
//    { 
//        /*
//         *  This (awful) line of if statements assigns decks to computer players based on the human player's selected deck.
//         *  NOTE: int deck parameter does NOT correspond to deck ID; there is an OB1 error.
//         *      if int deck = 0, deck ID is D001 and so on
//         *  Deck listing:
//         *      int deck    deckID      Deck Name
//         *      0           D001        Allegheny Forest
//         *      1           D002        Appalachian Homestead
//         *      2           D003        Peat Bogs
//         *      3           D004        Clarion River
//         *  Selection tree:
//         *      if human selects D001; CP1 D002, CP2 D003, CP3 D004
//         *      if human selects D002; CP1 D001, CP2 D003, CP3 D004
//         *      if human selects D003; CP1 D001, CP2 D002, CP3 D004
//         *      if human selects D004; CP1 D001, CP2 D002, CP3 D003
//         */

//        if(deck == 0)
//        {
//            GameManager.Instance.deckPicked = "D001";

//            GameManager.Instance.computerOneDeck = "D002";
//            GameManager.Instance.computerTwoDeck = "D003";
//            GameManager.Instance.computerThreeDeck = "D004";
//            //dbConnect.startConnection(GameManager.Instance);
//        }
//        else if(deck == 1)
//        {
//            GameManager.Instance.deckPicked = "D002";

//            GameManager.Instance.computerOneDeck = "D001";
//            GameManager.Instance.computerTwoDeck = "D003";
//            GameManager.Instance.computerThreeDeck = "D004";
//           // dbConnect.startConnection(GameManager.Instance);
//        }
//        else if(deck == 2)
//        {
//            GameManager.Instance.deckPicked = "D003";

//            GameManager.Instance.computerOneDeck = "D001";
//            GameManager.Instance.computerTwoDeck = "D002";
//            GameManager.Instance.computerThreeDeck = "D004";
//            //dbConnect.startConnection(GameManager.Instance);
//        }
//        else if(deck == 3)
//        {
//            GameManager.Instance.deckPicked = "D004";

//            GameManager.Instance.computerOneDeck = "D001";
//            GameManager.Instance.computerTwoDeck = "D002";
//            GameManager.Instance.computerThreeDeck = "D003";
//           // dbConnect.startConnection(GameManager.Instance);
//        }
//    }
//}
