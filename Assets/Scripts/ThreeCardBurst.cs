// THIS SCRIPT WILL BE USED FOR THE THREE VARD BURST BUTTON, WHENEVER IT IS CLICKED, 3 MORE CARDS WILL BE PUT INTO THE HAND OF THE PLAYER.
// ONCE IT IS CLICKED IT SHOULD EITHER BE DISABLED UNTIL FURTHER NOTICE OR IT SHOULD BE COMPLETELY INVISIBLE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeCardBurst : MonoBehaviour {

    public Button threeCard; //to hold the place and reference to the button

    //variables to be used for the card generation
    public CardRetrievalFromDeck holder;
    public DebugDealer playerDraw;
    private GameObject cardObject;
    public Transform cardParent; //to get the parent of the card
    private SpriteRenderer sr;

    // Use this for initialization
    void Start () {

        threeCard = GameManager.Instance.threeCardBurst;

        holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>(); //gets access to the script
        playerDraw = ScriptableObject.FindObjectOfType<DebugDealer>(); //gets access to the script
        cardParent = GameObject.Find("Game Board Container/Player Board/Board/Player/Hand").transform;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //the main method for the three card burst, where the cards are put into the hand
    public void ThreeCardExecute()
    {
        //three cards should bedrawn randomly from the deck
        for(int i = 0; i < 3; i++)
        {
            DrawCard();
        }

        //once cards are drawn, button dissapears because you can no longer use it
        threeCard.gameObject.SetActive(false);
    }

    //Function that  is used to create an object to represent the card
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

    //just call this to draw one random card from thedeck
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
