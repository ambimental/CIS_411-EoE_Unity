//WILL DETERMINE WHICH DECK IS PICKED AND WILL DISPLAY THE CARDS ABSED ON THAT DECK

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDeck : MonoBehaviour {

    public int randomDeck;

    //dontdestroyonload in the start so that the variable does not get destroyed
    public void Start()
    {
        //dbConnect = new databaseConnection();
    }

    //to determine which deck it was
    public void SelectedDeck(int deck)
    { 
        //this string of if statements will determine the user deck picked
        if(deck == 0) //allegheny forest
        {
            GameManager.Instance.deckPicked = "D001"; //sets user deck

            GameManager.Instance.computerOneDeck = "D002"; //sets computer deckss
            GameManager.Instance.computerTwoDeck = "D003";
            GameManager.Instance.computerThreeDeck = "D004";
            //dbConnect.startConnection(GameManager.Instance);
        }
        else if(deck == 1) //appalachian homestead
        {
            GameManager.Instance.deckPicked = "D002"; //sets user deck

            GameManager.Instance.computerOneDeck = "D001"; //sets computer decks
            GameManager.Instance.computerTwoDeck = "D003";
            GameManager.Instance.computerThreeDeck = "D004";
           // dbConnect.startConnection(GameManager.Instance);
        }
        else if(deck == 2) //peat bogs
        {
            GameManager.Instance.deckPicked = "D003"; //sets the user deck

            GameManager.Instance.computerOneDeck = "D001"; //sets the computer decks
            GameManager.Instance.computerTwoDeck = "D002";
            GameManager.Instance.computerThreeDeck = "D004";
            //dbConnect.startConnection(GameManager.Instance);
        }
        else if(deck == 3) //clarion river
        {
            GameManager.Instance.deckPicked = "D004"; //sets the user deck

            GameManager.Instance.computerOneDeck = "D001"; //sets the computer decks
            GameManager.Instance.computerTwoDeck = "D002";
            GameManager.Instance.computerThreeDeck = "D003";
           // dbConnect.startConnection(GameManager.Instance);
        }
    }
}
