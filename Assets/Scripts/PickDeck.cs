/*
 *  @class      PickDeck
 *  @purpose    Facilitate player deck selection and assigns deck attributes
 *  
 *  @author     CIS 411
 *  @date       2020/04/07
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickDeck : MonoBehaviour
{
    //these are the colors that wil be assigned to the decks
    private Color32 appalachianColor;
    private Color32 alleghenyColor;
    private Color32 clarionRiverColor;
    private Color32 peatBogsColor;

    //these are the names that will be assigned to the decks
    private string allegheny;
    private string appalachian;
    private string peat;
    private string clarion;

    /*
     *  @name       Start()
     *  @purpose    Required to initialize by Unity
     *  
     *  @ATTN:      donotdestroyonload so variable is not destroyed
     */
    public void Start()
    {
        //instantiates colors and names
        AppalachianColor = new Color32(166, 135, 82, 128);
        AlleghenyColor = new Color32(58, 102, 44, 128);
        ClarionRiverColor = new Color32(116, 126, 140, 128);
        PeatBogsColor = new Color32(124, 56, 58, 128);
        Allegheny = "Allegheny National Forest";
        Appalachian= "Appalachian Homestead";
        Peat = "Peat Bogs";
        Clarion = "Clarion River";
    }

    /*
     *  @name       SelectedDeck()
     *  @purpose    Determines which deck was selected and assigns CP decks based on that
     *  
     *  @param      int deck;   deck selected by human player
     */
    public void SelectedDeck(int deck)
    {
        /*
         *  This line of if statements assigns decks to computer players based on the human player's selected deck.
         *  NOTE: int deck parameter does NOT correspond to deck ID; there is an OB1 error.
         *      if int deck = 0, deck ID is D001 and so on
         *  Deck listing:
         *      int deck    deckID      Deck Name
         *      0           D001        Allegheny Forest
         *      1           D002        Appalachian Homestead
         *      2           D003        Peat Bogs
         *      3           D004        Clarion River
         *  Selection tree:
         *      if human selects D001; CP1 D002, CP2 D003, CP3 D004
         *      if human selects D002; CP1 D001, CP2 D003, CP3 D004
         *      if human selects D003; CP1 D001, CP2 D002, CP3 D004
         *      if human selects D004; CP1 D001, CP2 D002, CP3 D003
         *      
         *      the deck number is passed in from the button on the "pickstarterdeck" scene that is where it comes from
         */


        //this will  be used to assign decks and deck info once the game manger is created on loading screen and works that way
        if (deck == 0)
        {
            //sets human canvas values
            //GameManager.Instance.Person.DeckPicked = "D001";
            //GameManager.Instance.Person.AssignDeck();
            //Debug.Log("Deck picked" + GameManager.Instance.Person.Deck.Cards.Count);
            //GameManager.Instance.Person.Deck.DeckName = Allegheny ;
            //GameManager.Instance.Person.Deck.DeckColor = AlleghenyColor;
            //Debug.Log("PickDeck deck color" + GameManager.Instance.Person.Deck.DeckColor);
            //Debug.Log("PickDeck deck count" + GameManager.Instance.Person.Deck.Cards.Count);
            //Debug.Log("PickDeck deck ID" + GameManager.Instance.Person.Deck.DeckId);

            ////sets Cp1 canvas values
            //GameManager.Instance.CP1.DeckPicked = "D002";
            ////GameManager.Instance.CP1.AssignDeck();
            //GameManager.Instance.CP1.Deck.DeckName = Appalachian;
            //GameManager.Instance.CP1.Deck.DeckColor = AppalachianColor;

            ////sets CP2 canvas values
            //GameManager.Instance.CP2.DeckPicked = "D003";
            ////GameManager.Instance.CP2.AssignDeck();
            //GameManager.Instance.CP2.Deck.DeckName = Peat;
            //GameManager.Instance.CP2.Deck.DeckColor = PeatBogsColor;


            ////sets CP3 canvas values
            //GameManager.Instance.CP3.DeckPicked = "D004";
            ////GameManager.Instance.CP3.AssignDeck();
            //GameManager.Instance.CP3.Deck.DeckName = Clarion;
            //GameManager.Instance.CP3.Deck.DeckColor = ClarionRiverColor;

        }
        else if (deck == 1)
        {
            //sets human canvas values
            //GameManager.Instance.Person.DeckPicked = "D002";
            ////GameManager.Instance.Person.AssignDeck();
            //GameManager.Instance.Person.Deck.DeckName = Appalachian;
            //GameManager.Instance.Person.Deck.DeckColor = AppalachianColor;
            ////sets Cp1 canvas values
            //GameManager.Instance.CP1.DeckPicked = "D001";
            ////GameManager.Instance.CP1.AssignDeck();
            //GameManager.Instance.CP1.Deck.DeckName = Allegheny;
            //GameManager.Instance.CP1.Deck.DeckColor = AlleghenyColor;

            ////sets CP2 canvas values
            //GameManager.Instance.CP2.DeckPicked = "D003";
            ////GameManager.Instance.CP2.AssignDeck();
            //GameManager.Instance.CP2.Deck.DeckName = Peat;
            //GameManager.Instance.CP2.Deck.DeckColor = PeatBogsColor;

            ////sets CP3 canvas values
            //GameManager.Instance.CP3.DeckPicked = "D004";
            ////GameManager.Instance.CP3.AssignDeck();
            //GameManager.Instance.CP3.Deck.DeckName = Clarion;
            //GameManager.Instance.CP3.Deck.DeckColor = ClarionRiverColor;

        }
        else if (deck == 2)
        {
            //sets human canvas values
           // GameManager.Instance.Person.DeckPicked = "D003";
           // GameManager.Instance.Person.AssignDeck();
            //GameManager.Instance.Person.Deck.DeckName = Peat;
            //GameManager.Instance.Person.Deck.DeckColor = PeatBogsColor;

           // //sets Cp1 canvas values
           // GameManager.Instance.CP1.DeckPicked = "D001";
           // //GameManager.Instance.CP1.AssignDeck();
           // GameManager.Instance.CP1.Deck.DeckName = Allegheny;
           // GameManager.Instance.CP1.Deck.DeckColor = AlleghenyColor;

           // //sets CP2 canvas values
           // GameManager.Instance.CP2.DeckPicked = "D002";
           // //GameManager.Instance.CP2.AssignDeck();
           // GameManager.Instance.CP2.Deck.DeckName = Appalachian;
           // GameManager.Instance.CP2.Deck.DeckColor = AppalachianColor;

           // //sets CP3 canvas values
           // GameManager.Instance.CP3.DeckPicked = "D004";
           //// GameManager.Instance.CP3.AssignDeck();
           // GameManager.Instance.CP3.Deck.DeckName = Clarion;
           // GameManager.Instance.CP3.Deck.DeckColor = ClarionRiverColor;

        }
        else if (deck == 3)
        {
            //sets human canvas values
            //GameManager.Instance.Person.DeckPicked = "D004";
            //GameManager.Instance.Person.AssignDeck();
            //GameManager.Instance.Person.Deck.DeckName = Clarion;
            //GameManager.Instance.Person.Deck.DeckColor = ClarionRiverColor;

            ////sets Cp1 canvas values
            //GameManager.Instance.CP1.DeckPicked = "D001";
            ////GameManager.Instance.CP1.AssignDeck();
            //GameManager.Instance.CP1.Deck.DeckName = Allegheny;
            //GameManager.Instance.CP1.Deck.DeckColor = AlleghenyColor;

            ////sets CP2 canvas values
            //GameManager.Instance.CP2.DeckPicked = "D002";
            ////GameManager.Instance.CP2.AssignDeck();
            //GameManager.Instance.CP2.Deck.DeckName = Appalachian;
            //GameManager.Instance.CP2.Deck.DeckColor = AppalachianColor;

            //// //sets CP3 canvas values
            //GameManager.Instance.CP3.DeckPicked = "D003";
            ////GameManager.Instance.CP3.AssignDeck();
            //GameManager.Instance.CP3.Deck.DeckName = Peat;
            //GameManager.Instance.CP3.Deck.DeckColor = PeatBogsColor;
        }
        //Debug.Log("End deck count" + GameManager.Instance.Person.Deck.Cards.Count);
        //Debug.Log("End deck ID" + GameManager.Instance.Person.Deck.DeckId);

    }

    //accessors and mutators
    public Color32 AppalachianColor { get => appalachianColor; set => appalachianColor = value; }
    public Color32 AlleghenyColor { get => alleghenyColor; set => alleghenyColor = value; }
    public Color32 ClarionRiverColor { get => clarionRiverColor; set => clarionRiverColor = value; }
    public Color32 PeatBogsColor { get => peatBogsColor; set => peatBogsColor = value; }
    public string Allegheny { get => allegheny; set => allegheny = value; }
    public string Appalachian { get => appalachian; set => appalachian = value; }
    public string Peat { get => peat; set => peat = value; }
    public string Clarion { get => clarion; set => clarion = value; }
}
