/*
 *  @class      ChooseDeck
 *  @purpose    handles human player deck selection
 *  
 *  @author     John Georgvich, previous CIS411 group
 *  @date       2020/01/22
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDeck : MonoBehaviour {

    public int cr = 0; //clarion river deck
    public int af = 1; //allagheny forest deck
    public int ah = 2; //appalachian homestead deck
    public int pb = 3; //peat bogs deck

    public int chosenDeck = -1; //set to -1 to determine if there are any issues

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //sets the deck chosen
    public void SetDeck(int deck)
    {
        chosenDeck = deck;
    }
}
