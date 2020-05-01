//THIS SCRIPT WILL BE USED TO CHOOSE A CARD WHENEVER A SPECIAL ACTION REQUIRES IT TO HAPPEN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCard : MonoBehaviour {

//    public Card selectedCard; //to hold the card that wil be selected to display
//    public CheckDeckAndDiscardPlayer showBoard; //will be sued to go back to the player one board

//    //FOR THE CARD OBJET BEING GENERATED
//    public Transform cardParent; //to get the parent of the card
//    private GameObject cardObject;
//    private SpriteRenderer sr;
//    public CardRetrievalFromDeck holder;
//    public DebugDealer playerDraw;

//    // Use this for initialization
//    void Start () {
//        showBoard = GameObject.Find("Main Camera").GetComponent<CheckDeckAndDiscardPlayer>(); //sets object
//        holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>(); //gets access to the script
//        playerDraw = ScriptableObject.FindObjectOfType<DebugDealer>(); //gets access to the script
//}
	
//	// Update is called once per frame
//	void Update () {
		
//	}

//    //Function that  is used to create an object to represent the card
//    private void generateCardObject()
//    {
//        //creating a new gameobject  to hold act as the card
//        cardObject = new GameObject(holder.cardNameHolder, typeof(RectTransform));
//        //creating a SpriteRenderer to hold the card's Sprite
//        sr = cardObject.AddComponent<SpriteRenderer>();
//        //setting the rectangle size  of the card object
//        cardObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 120);
//        //adding a collider to the card object, which is sized based on the rectangle size
//        cardObject.AddComponent<BoxCollider2D>().size = cardObject.GetComponent<RectTransform>().sizeDelta;
//        //setting the card object's parent to be the Hand, so that it will render in the player's hand
//        cardObject.transform.SetParent(cardParent);
//        //setting the localScale of the card object, so that it will be appropriately sized
//        cardObject.transform.localScale = new Vector3(1f, 1f, 0);
//        //adding the HoverClass script to the card object, which allows for hover functionality.
//        cardObject.AddComponent<HoverClass>();
//        //to allow mouse to go through the sprite to view what is behind it
//        cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
//    }

//    //whenever the user clicks down on the object then this function of selecting the card will occur
//    private void OnMouseDown()
//    {
//        //GOES THROUGH THE DECK, GETS THE SELECTED CARD, REMOVES IT FROM THE DECK, ADDS IT TO THE CORRECT PILE, DISPLAYS CARD
//        foreach(Deck deck in GameManager.Instance.Decks)
//        {
//            if(deck.DeckId == GameManager.Instance.deckPicked) //makes sure we are in the right deck
//            {
//                for(int i = 0; i < deck.Cards.Count; i++)
//                {
//                    if (this.gameObject.name == deck.Cards[i].CardName) //makes sure the card in the deck mtches the selected one
//                    {
//                        selectedCard = deck.Cards[i]; //sets the card to the card object for easier use
//                        int changeScore = 0;

//                        //checks the card type to maek sure which pile it is in
//                        if(deck.Cards[i].CardType == "Animal")
//                        {
//                            Debug.Log(selectedCard.CardName);
//                            GameManager.Instance.AnimalPlacement.Add(deck.Cards[i]); //adds it to the placement

//                            cardParent = GameObject.Find("Game Board Container/Player Board/Board/Player/Animal Card Placement").transform; //gets the variable that was set in the actions
//                            holder.cardNameHolder = deck.Cards[i].CardName; //card name needed to get card image
//                            generateCardObject();
//                            holder.setSprite(sr);

//                            changeScore = deck.Cards[i].PointValue;

//                            deck.Cards.Remove(deck.Cards[i]); //removes it from the deck
//                        }
//                        else if (deck.Cards[i].CardType == "Plant")
//                        {
//                            Debug.Log(selectedCard.CardName);
//                            GameManager.Instance.PlantPlacement.Add(deck.Cards[i]); //adds it to placement

//                            cardParent = GameObject.Find("Game Board Container/Player Board/Board/Player/Plant Card Placement").transform;
//                            holder.cardNameHolder = deck.Cards[i].CardName; //card name needed to get card image
//                            generateCardObject();
//                            holder.setSprite(sr);

//                            changeScore = deck.Cards[i].PointValue;

//                            deck.Cards.Remove(deck.Cards[i]); //removes it from the deck
//                        }
//                        else if (deck.Cards[i].CardType == "Condition")
//                        {
//                            Debug.Log(selectedCard.CardName);
//                            GameManager.Instance.ConditionPlacement.Add(deck.Cards[i]); //adds it to the placement

//                            cardParent = GameObject.Find("Game Board Container/Player Board/Board/Player/Condition Card Placement").transform;
//                            holder.cardNameHolder = deck.Cards[i].CardName; //card name needed to get card image
//                            generateCardObject();
//                            holder.setSprite(sr);

//                            changeScore = deck.Cards[i].PointValue;

//                            deck.Cards.Remove(deck.Cards[i]); //removes it from the deck
//                        }
//                        else if (deck.Cards[i].CardType == "Invertebrate")
//                        {
//                            Debug.Log(selectedCard.CardName);
//                            GameManager.Instance.ConditionPlacement.Add(deck.Cards[i]); //adds it to the placement

//                            cardParent = GameObject.Find("Game Board Container/Player Board/Board/Player/Invertebrate Card Placement").transform;
//                            holder.cardNameHolder = deck.Cards[i].CardName; //card name needed to get card image
//                            generateCardObject();
//                            holder.setSprite(sr);

//                            changeScore = deck.Cards[i].PointValue;

//                            deck.Cards.Remove(deck.Cards[i]); //removes it from the deck
//                        }

//                        //to clear the lists that are used
//                        GameManager.Instance.DeckSelectionList.Clear();
//                        GameManager.Instance.DiscardSelectionList.Clear();

//                        //have to clear out the panels that contain the deck and discard piles to ensure there are no problems whenver another card needs to access them
//                        cardParent = GameObject.Find("DeckShow").transform; //gets the deckshow parent set to an object
//                        int deckShowCount = cardParent.childCount; //gets the number of cards in the panel

//                        for (int j = deckShowCount - 1; j >= 0; j--) //to go through the panel cards
//                        {
//                            //goes through the panel and destroys every card in the panel
//                            UnityEngine.Object.Destroy(cardParent.GetChild(j).gameObject);
//                        }

//                        cardParent = GameObject.Find("DiscardShow").transform; //gets the deckshow parent set to an object
//                        int discardShowCount = cardParent.childCount; //gets the number of cards in the panel

//                        for (int j = discardShowCount - 1; j >= 0; j--) //to go through the panel cards
//                        {
//                            //goes through the panel and destroys every card in the panel
//                            UnityEngine.Object.Destroy(cardParent.GetChild(j).gameObject);
//                        }

//                        GameManager.Instance.playerCanvas.alpha = 1f;
//                        GameManager.Instance.playerCanvas.blocksRaycasts = true;
//                        GameManager.Instance.playerCanvas.interactable = true;
//                        GameManager.Instance.playerView.SetActive(true); //sets the view as active
//                        showBoard.hideDeckDiscard(); //goes back to the player

//                        GameManager.Instance.Person.ChangeScore(changeScore); //changes the score
//                    }
//                }
//            }
//        }
//    }
}
