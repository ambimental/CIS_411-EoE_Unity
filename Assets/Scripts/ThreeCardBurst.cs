/*
 *  @class      ThreeCardBurst
 *  @purpose    Provide the player with three additional cards in their hand
 *  
 *  @author     John Georgvich, previous CIS411 group
 *  @date       2020/01/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeCardBurst : MonoBehaviour {

    //  button for TCB
    public Button threeCard;

    //  class variables for button
    public CardRetrievalFromDeck holder;
    public DebugDealer playerDraw;
    private GameObject cardObject;
    public Transform cardParent;
    private SpriteRenderer sr;

    /*
     *  @name       Start()
     *  @purpose    Required for initialization of Unity object
     */
    void Start () {

        threeCard = GameManager.Instance.threeCardBurst;

        holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>(); //gets access to the script
        playerDraw = ScriptableObject.FindObjectOfType<DebugDealer>(); //gets access to the script
        cardParent = GameObject.Find("Game Board Container/Player Board/Board/Player/Hand").transform;

    }
	
	/*
     *  @name       Update()
     *  @purpose    Updates object every frame
     */
	void Update () {
		
	}

    /*
     *  @name       ThreeCardExecute()
     *  @purpose    Executes the TCB as-per game rules; adds three cards to the player's hand and is disabled for the remainder of the game
     */
    public void ThreeCardExecute()
    {
        //  three cards are randomly drawn from the deck
        for(int i = 0; i < 3; i++)
        {
            DrawCard();
        }

        //  disable button after burst is called
        threeCard.gameObject.SetActive(false);
    }

    /*
     *  @name       generateCardObject()
     *  @purpose    generates objects to represent the cards being drawn
     */
    private void generateCardObject()
    {
        //creating a new gameobject  to hold act as the card
        cardObject = new GameObject(holder.cardNameHolder, typeof(RectTransform));
        //creating a SpriteRenderer to hold the card's Sprite
        sr = cardObject.AddComponent<SpriteRenderer>();
        //setting the rectangle size  of the card object
        cardObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 120);
        //adding a collider to the card object, which is sized based on the rectangle size
        cardObject.AddComponent<BoxCollider2D>().size = cardObject.GetComponent<RectTransform>().sizeDelta;
        //setting the card object's parent to be the Hand, so that it will render in the player's hand
        cardObject.transform.SetParent(cardParent);
        //setting the localScale of the card object, so that it will be appropriately sized
        cardObject.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        //adding the HoverClass script to the card object, which allows for hover functionality.
        cardObject.AddComponent<HoverClass>();
        cardObject.AddComponent<ChooseCard>(); //makes it so that you can choose the card
        //to allow mouse to go through the sprite to view what is behind it
        cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
        cardObject.AddComponent<Draggable>();
    }

    /*
     *  @name       DarwCard()
     *  @purpose    Draws a single random card from the deck
     */
    public void DrawCard()
    {
        //looping through each deck in play
        foreach (Deck deck in GameManager.Instance.Decks)
        {
            //finding the correct deck to be used
            if (deck.DeckId == GameManager.Instance.deckPicked)
            {
                //checking to make sure there are cards left in the deck
                if (deck.Cards.Count != 0)
                {
                    //retrieving the object created in the form of the "instance" earlier
                    holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>();
                    //calling  the object's CardDrawRandomizer function, which selects a random card from the deck
                    holder.CardDrawRandomizer();
                    //calling this script's generateCardObject function,  which creates an object to represent the card
                    generateCardObject();
                    //calling the script object's setSprite function, which passes in the SpriteRenderer, and sets it's sprite to the corresponding card chosen in CardDrawRandomizer
                    holder.setSprite(sr);
                }
                else
                {
                }
            }
        }
    }
}
