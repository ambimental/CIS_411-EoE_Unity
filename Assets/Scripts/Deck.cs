/*
 *  @class      Decks
 *  @purpose    decks to store cards
 *  
 *  @author     CIS 411
 *  @date       2020/04/06
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck {

    //id of the deck
    private string deckId;
    //stores the cards
    private List<Card> cards; 
    //to store the name and color thats displayed on the UI screen
    private string deckName;
    private Color deckColor;

    /*
    *  @name       Decks()
    *  @purpose    default constructor
    */
    public Deck()
    {
        DeckId = "";
        Cards = new List<Card>();
        deckName= "";
        deckColor= new Color32(0, 0, 0, 0);
    }

    //accessors and mutators
    public string DeckId { get { return deckId; } set { deckId = value; } }
    public List<Card> Cards { get { return cards; } set { cards = value; } }
    public string DeckName { get => deckName; set => deckName = value; }
    public Color DeckColor { get => deckColor; set => deckColor = value; }
}
