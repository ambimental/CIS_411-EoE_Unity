<<<<<<< Updated upstream
﻿///*
// *  @class      Deck
// *  @purpose    Hold/identify player decks and cards within decks
// *  
// *  @author     John Georgvich, previous CIS411 group
// *  @date       2020/01/22
// */

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
>>>>>>> Stashed changes

//public class Deck {

<<<<<<< Updated upstream
//    //  deck id class variable
//    private string deckId;
//    //  List<Card> object used to store all cards in deck
//    private List<Card> cards;

//    /// <summary>
//    /// ACCESSOR/MUTATOR BLOCK
//    /// </summary>
//    public string DeckId { get { return deckId; } set { deckId = value; } }
//    public List<Card> Cards { get { return cards; } set { cards = value; } }

//    /*
//     *  @name       Deck()
//     *  @purpose    Default class constructor for Deck
//     */
//    public Deck()
//    {
//        DeckId = "";
//        Cards = new List<Card>();
//    }

//	/*
//     *  @name       Start()
//     *  @purpose    Used by Unity engine for object initialization
//     */
//	void Start (){
//        DeckId = "";
//        Cards = new List<Card>();
//    }
	
//	/*
//     *  @name       Update()
//     *  @purpose    Updates object every frame
//     */
//	void Update () {
=======
    private string deckId; //id of the deck
    private List<Card> cards; //stores the cards

    //accessors and mutators
    public string DeckId { get { return deckId; } set { deckId = value; } }
    public List<Card> Cards { get { return cards; } set { cards = value; } }

    //default constructor
    public Deck()
    {
        DeckId = "";
        Cards = new List<Card>();
    }

	// Use this for initialization
	void Start () {
        DeckId = "";
        Cards = new List<Card>();
    }
	
	// Update is called once per frame
	void Update () {
>>>>>>> Stashed changes
		
//	}
//}
