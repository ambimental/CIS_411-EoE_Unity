using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck {

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
		
	}
}
