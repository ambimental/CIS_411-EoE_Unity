using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugDealer : MonoBehaviour
{
    //variables
    //vars of other classes we created
    private CardRetrievalFromDeck holder;
    //
    private ScriptableObject scriptInstance;
    // ************ sprite things
    private SpriteRenderer sr;
    public Texture2D texSprite;
    public Sprite tempSprite;
    // ************ GAME OBJECTS
    public GameObject Hand;
    private GameObject cardObject;
    // ************* Canvas Things
    //will be used to get the hands size and help to keep the drawn cards
    //from overlapping onto the deck
    private CanvasRenderer handHolder;

    public Text drawText; //will get the text to instruct user to draw more cards

    //initiallization
    private void Start()
    {
        //allowing colliders to work
        Physics.queriesHitTriggers = true;
        //creating an "instance" of the CardRetrievalFromDeck script, allows it to be retrieved as an object
        scriptInstance = ScriptableObject.CreateInstance("CardRetrievalFromDeck");
        //creating a reference to the player's hand, so that cards can be added to it
        Hand = GameObject.Find("Hand");
        //creates the reference to the hand on the board.
        //we will use this later for width information
        handHolder = GameObject.Find("Hand").GetComponent<CanvasRenderer>();

        drawText = GameObject.Find("DrawText").GetComponent<Text>(); //gets the text component so it can be changed

        //draws the initial 5 cards from the deck to the users hand
        for (int i = 0; i < 5; i++)
            DrawCard();
    }

    //Function that runs when the mouse button is clicked down on the deck's collider
    void OnMouseDown()
    {
        if (GameManager.Instance.canDraw == true)
        {
            while (GameManager.Instance.canDraw == true)
            {
                if (GameManager.Instance.getPlayerTotalRegions() < 5) //only one card can be drawn
                {
                    if (GameManager.Instance.playerDrawExtraCard == true) //if the standing action is currently available
                    {
                        if(GameManager.Instance.playerDrawCount == 2)
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 1 More Card!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        else if (GameManager.Instance.playerDrawCount == 1) //if there is 1 available draw left
                        {
                            DrawCard();
                            drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
                            GameManager.Instance.playerDrawCount--;
                        }
                        else GameManager.Instance.canDraw = false; //can no longer draw
                    }
                    else
                    {
                        DrawCard(); //draws a card from the deck
                        GameManager.Instance.canDraw = false;

                        drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
                    }
                }
                else if (GameManager.Instance.getPlayerTotalRegions() < 10 && GameManager.Instance.getPlayerTotalRegions() >= 5) //where two cards can be drawn
                {
                    if (GameManager.Instance.playerDrawExtraCard == true)
                    {
                        if (GameManager.Instance.playerDrawCount == 3) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 2 More Cards!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        if (GameManager.Instance.playerDrawCount == 2) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 1 More Card!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        else if (GameManager.Instance.playerDrawCount == 1) //if there is 1 available draw left
                        {
                            DrawCard();
                            drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
                            GameManager.Instance.playerDrawCount--;
                        }
                        else GameManager.Instance.canDraw = false; //can no longer draw
                    }
                    else
                    {
                        if (GameManager.Instance.playerDrawCount == 2) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 1 More Card!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        else if (GameManager.Instance.playerDrawCount == 1) //if there is 1 available draw left
                        {
                            DrawCard();
                            drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
                            GameManager.Instance.playerDrawCount--;
                        }
                        else GameManager.Instance.canDraw = false; //can no longer draw
                    }
                }
                else if (GameManager.Instance.getPlayerTotalRegions() < 15 && GameManager.Instance.getPlayerTotalRegions() >= 10) //where three cards can be drawn
                {
                    if (GameManager.Instance.playerDrawExtraCard == true)
                    {
                        if (GameManager.Instance.playerDrawCount == 4) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 3 More Cards!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        if (GameManager.Instance.playerDrawCount == 3) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 2 More Cards!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        if (GameManager.Instance.playerDrawCount == 2) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 1 More Card!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        else if (GameManager.Instance.playerDrawCount == 1) //if there is 1 available draw left
                        {
                            DrawCard();
                            drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
                            GameManager.Instance.playerDrawCount--;
                        }
                        else GameManager.Instance.canDraw = false; //can no longer draw}
                    }
                    else
                    {
                        if (GameManager.Instance.playerDrawCount == 3) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 2 More Cards!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        if (GameManager.Instance.playerDrawCount == 2) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 1 More Card!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        else if (GameManager.Instance.playerDrawCount == 1) //if there is 1 available draw left
                        {
                            DrawCard();
                            drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
                            GameManager.Instance.playerDrawCount--;
                        }
                        else GameManager.Instance.canDraw = false; //can no longer draw
                    }
                }
                else if (GameManager.Instance.getPlayerTotalRegions() < 20  && GameManager.Instance.getPlayerTotalRegions() >= 15) //where four cards can be drawn
                {
                    if (GameManager.Instance.playerDrawExtraCard)
                    {
                        if (GameManager.Instance.playerDrawCount == 5) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 4 More Cards!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        if (GameManager.Instance.playerDrawCount == 4) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 3 More Cards!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        if (GameManager.Instance.playerDrawCount == 3) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 2 More Cards!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        if (GameManager.Instance.playerDrawCount == 2) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 1 More Card!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        else if (GameManager.Instance.playerDrawCount == 1) //if there is 1 available draw left
                        {
                            DrawCard();
                            drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
                            GameManager.Instance.playerDrawCount--;
                        }
                        else GameManager.Instance.canDraw = false; //can no longer draw
                    }
                    else
                    {
                        if (GameManager.Instance.playerDrawCount == 4) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 3 More Cards!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        if (GameManager.Instance.playerDrawCount == 3) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 2 More Cards!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        if (GameManager.Instance.playerDrawCount == 2) //if there are 2 available draws left
                        {
                            DrawCard(); //draws a card
                            drawText.text = "Please Draw 1 More Card!";
                            GameManager.Instance.playerDrawCount--;
                            break;
                        }
                        else if (GameManager.Instance.playerDrawCount == 1) //if there is 1 available draw left
                        {
                            DrawCard();
                            drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
                            GameManager.Instance.playerDrawCount--;
                        }
                        else GameManager.Instance.canDraw = false; //can no longer draw
                    }
                }
            }
        }
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
        cardObject.transform.SetParent(Hand.transform);
        //setting the localScale of the card object, so that it will be appropriately sized
        cardObject.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        //adding the HoverClass script to the card object, which allows for hover functionality.
        cardObject.AddComponent<HoverClass>();
        //adding the Draggable script to the card object, which allows it to be dragged and placed appropriately
        cardObject.AddComponent<Draggable>();
        cardObject.AddComponent<DoubleClickDescription>(); //makes the cards able to be clicked on

        cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
    }

    //Function that is called to change the deck's image with an out of cards image
    public void changeDeck()
    {
        //creating a new SpriteRenderer for the deck
        SpriteRenderer swap = GameObject.Find("Deck Draw Placement").AddComponent<SpriteRenderer>();
        //loading the out of cards texture
        texSprite = Resources.Load<Texture2D>("Sprites/Out-Of-Cards");
        //creating a sprite out of said texture
        tempSprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.6666f);
        //setting the SpriteRenderer's sprite to the newly created Sprite
        swap.sprite = tempSprite;
        //setting the SpriteRenderer's sorting level so that it appears above the deck, but  below cards
        swap.sortingOrder = 9;
        //setting the SpriteRenderer's sorting level to Default, so that it is in line with other objects
        swap.sortingLayerName = "Default";
    }

    //Made this its own class so that we could use a for loop to draw 5 cards
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

                    if (deck.Cards.Count == 0)
                    {
                        //calling this script's changeDeck function, which replaces the deck with an out of cards image
                        changeDeck();
                    }
                }
                else
                {
                }
            }
        }
    }
}
