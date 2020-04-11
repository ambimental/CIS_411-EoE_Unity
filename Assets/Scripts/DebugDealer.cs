/*
 *  @class      DebugDealer
 *  @purpose    draws intial 5 cards for human and calls card retrieval from deck
 *  
 *  @author     CIS 411
 *  @date       2020/04/06
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugDealer : MonoBehaviour
{
    ////variables
    ////vars of other classes we created
    //private CardRetrievalFromDeck holder;
    ////
    //private ScriptableObject scriptInstance;
    //// ************ sprite things
    //private SpriteRenderer sr;
    //private Texture2D texSprite;
    //private Sprite tempSprite;
    //// ************ GAME OBJECTS
    //private GameObject Hand;
    //private GameObject cardObject;
    //// ************* Canvas Things
    ////will be used to get the hands size and help to keep the drawn cards
    ////from overlapping onto the deck
    //private CanvasRenderer handHolder;

    //private Text drawText; //will get the text to instruct user to draw more cards

    ///*
    // *  @name       Start()
    // *  @purpose    draws 5 cards for human player
    // */
    //private void Start()
    //{
    //    //allowing colliders to work
    //    Physics.queriesHitTriggers = true;
    //    //creating an "instance" of the CardRetrievalFromDeck script, allows it to be retrieved as an object
    //    scriptInstance = ScriptableObject.CreateInstance("CardRetrievalFromDeck");
    //    //creating a reference to the player's hand, so that cards can be added to it
    //    Hand = GameObject.Find("Hand");
    //    //creates the reference to the hand on the board.
    //    //we will use this later for width information
    //    handHolder = GameObject.Find("Hand").GetComponent<CanvasRenderer>();

    //    drawText = GameObject.Find("DrawText").GetComponent<Text>(); //gets the text component so it can be changed

    //    //draws the initial 5 cards from the deck to the users hand
    //    for (int i = 0; i < 5; i++)
    //        DrawCard();
    //}

    ///*
    // *  @name       OnMouseDown()
    // *  @purpose    detrermins how many cards the player can draw
    // */
    //void OnMouseDown()
    //{
    //    if (GameManager.Instance.Person.CanDraw == true)
    //    {
    //        while (GameManager.Instance.Person.CanDraw == true)
    //        {
    //            if (GameManager.Instance.Person.GetTotalRegions() < 5) //only one card can be drawn
    //            {
    //                if (GameManager.Instance.Person.DrawExtraCard == true) //if the standing action is currently available
    //                {
    //                    if (GameManager.Instance.Person.DrawCount == 2)
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 1 More Card!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    else if (GameManager.Instance.Person.DrawCount == 1) //if there is 1 available draw left
    //                    {
    //                        DrawCard();
    //                        drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
    //                        GameManager.Instance.Person.DrawCount--;
    //                    }
    //                    else GameManager.Instance.Person.CanDraw = false; //can no longer draw
    //                }
    //                else
    //                {
    //                    DrawCard(); //draws a card from the deck
    //                    GameManager.Instance.Person.CanDraw = false;

    //                    drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
    //                }
    //            }
    //            else if (GameManager.Instance.Person.GetTotalRegions() < 10 && GameManager.Instance.Person.GetTotalRegions() >= 5) //where two cards can be drawn
    //            {
    //                if (GameManager.Instance.Person.DrawExtraCard == true)
    //                {
    //                    if (GameManager.Instance.Person.DrawCount == 3) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 2 More Cards!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    if (GameManager.Instance.Person.DrawCount == 2) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 1 More Card!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    else if (GameManager.Instance.Person.DrawCount == 1) //if there is 1 available draw left
    //                    {
    //                        DrawCard();
    //                        drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
    //                        GameManager.Instance.Person.DrawCount--;
    //                    }
    //                    else GameManager.Instance.Person.CanDraw = false; //can no longer draw
    //                }
    //                else
    //                {
    //                    if (GameManager.Instance.Person.DrawCount == 2) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 1 More Card!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    else if (GameManager.Instance.Person.DrawCount == 1) //if there is 1 available draw left
    //                    {
    //                        DrawCard();
    //                        drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
    //                        GameManager.Instance.Person.DrawCount--;
    //                    }
    //                    else GameManager.Instance.Person.CanDraw = false; //can no longer draw
    //                }
    //            }
    //            else if (GameManager.Instance.Person.GetTotalRegions() < 15 && GameManager.Instance.Person.GetTotalRegions() >= 10) //where three cards can be drawn
    //            {
    //                if (GameManager.Instance.Person.DrawExtraCard == true)
    //                {
    //                    if (GameManager.Instance.Person.DrawCount == 4) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 3 More Cards!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    if (GameManager.Instance.Person.DrawCount == 3) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 2 More Cards!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    if (GameManager.Instance.Person.DrawCount == 2) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 1 More Card!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    else if (GameManager.Instance.Person.DrawCount == 1) //if there is 1 available draw left
    //                    {
    //                        DrawCard();
    //                        drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
    //                        GameManager.Instance.Person.DrawCount--;
    //                    }
    //                    else GameManager.Instance.Person.CanDraw = false; //can no longer draw}
    //                }
    //                else
    //                {
    //                    if (GameManager.Instance.Person.DrawCount == 3) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 2 More Cards!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    if (GameManager.Instance.Person.DrawCount == 2) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 1 More Card!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    else if (GameManager.Instance.Person.DrawCount == 1) //if there is 1 available draw left
    //                    {
    //                        DrawCard();
    //                        drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
    //                        GameManager.Instance.Person.DrawCount--;
    //                    }
    //                    else GameManager.Instance.Person.CanDraw = false; //can no longer draw
    //                }
    //            }
    //            else if (GameManager.Instance.Person.GetTotalRegions() < 20 && GameManager.Instance.Person.GetTotalRegions() >= 15) //where four cards can be drawn
    //            {
    //                if (GameManager.Instance.Person.DrawExtraCard)
    //                {
    //                    if (GameManager.Instance.Person.DrawCount == 5) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 4 More Cards!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    if (GameManager.Instance.Person.DrawCount == 4) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 3 More Cards!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    if (GameManager.Instance.Person.DrawCount == 3) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 2 More Cards!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    if (GameManager.Instance.Person.DrawCount == 2) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 1 More Card!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    else if (GameManager.Instance.Person.DrawCount == 1) //if there is 1 available draw left
    //                    {
    //                        DrawCard();
    //                        drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
    //                        GameManager.Instance.Person.DrawCount--;
    //                    }
    //                    else GameManager.Instance.Person.CanDraw = false; //can no longer draw
    //                }
    //                else
    //                {
    //                    if (GameManager.Instance.Person.DrawCount == 4) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 3 More Cards!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    if (GameManager.Instance.Person.DrawCount == 3) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 2 More Cards!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    if (GameManager.Instance.Person.DrawCount == 2) //if there are 2 available draws left
    //                    {
    //                        DrawCard(); //draws a card
    //                        drawText.text = "Please Draw 1 More Card!";
    //                        GameManager.Instance.Person.DrawCount--;
    //                        break;
    //                    }
    //                    else if (GameManager.Instance.Person.DrawCount == 1) //if there is 1 available draw left
    //                    {
    //                        DrawCard();
    //                        drawText.text = "Step 1: Play Card(s) \n Step 2: Discard to end your turn";
    //                        GameManager.Instance.Person.DrawCount--;
    //                    }
    //                    else GameManager.Instance.Person.CanDraw = false; //can no longer draw
    //                }
    //            }
    //        }
    //    }
    //}

    ///*
    // *  @name       generateCardObjects()
    // *  @purpose    this gets the card from the deck and assigns it to a game object that will be the card you will see omn the screen
    // */
    //private void generateCardObject()
    //{
    //    //creating a new gameobject  to hold act as the card
    //    cardObject = new GameObject(holder.CardNameHolder, typeof(RectTransform));
    //    //creating a SpriteRenderer to hold the card's Sprite
    //    sr = cardObject.AddComponent<SpriteRenderer>();
    //    //setting the rectangle size  of the card object
    //    cardObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 120);
    //    //adding a collider to the card object, which is sized based on the rectangle size
    //    cardObject.AddComponent<BoxCollider2D>().size = cardObject.GetComponent<RectTransform>().sizeDelta;
    //    //setting the card object's parent to be the Hand, so that it will render in the player's hand
    //    cardObject.transform.SetParent(Hand.transform);
    //    //setting the localScale of the card object, so that it will be appropriately sized
    //    cardObject.transform.localScale = new Vector3(1.5f, 1.5f, 0);
    //    //adding the HoverClass script to the card object, which allows for hover functionality.
    //    cardObject.AddComponent<HoverClass>();
    //    //adding the Draggable script to the card object, which allows it to be dragged and placed appropriately
    //    cardObject.AddComponent<Draggable>();
    //    cardObject.AddComponent<DoubleClickDescription>(); //makes the cards able to be clicked on

    //    cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
    //}

    ///*
    // *  @name       changeDeck()
    // *  @purpose    when the human player is out of sards it replaces the image with an out of cards image
    // */
    //public void changeDeck()
    //{
    //    //creating a new SpriteRenderer for the deck
    //    SpriteRenderer swap = GameObject.Find("Deck Draw Placement").AddComponent<SpriteRenderer>();
    //    //loading the out of cards texture
    //    texSprite = Resources.Load<Texture2D>("Sprites/Out-Of-Cards");
    //    //creating a sprite out of said texture
    //    tempSprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.6666f);
    //    //setting the SpriteRenderer's sprite to the newly created Sprite
    //    swap.sprite = tempSprite;
    //    //setting the SpriteRenderer's sorting level so that it appears above the deck, but  below cards
    //    swap.sortingOrder = 9;
    //    //setting the SpriteRenderer's sorting level to Default, so that it is in line with other objects
    //    swap.sortingLayerName = "Default";
    //}

    ///*
    // *  @name       DrawCard()
    // *  @purpose    gets the card from the deck and calls generate card object 
    // */
    //public void DrawCard()
    //{
    //            //checking to make sure there are cards left in the deck
    //            if (GameManager.Instance.Person.Deck.Cards.Count != 0)
    //            {
    //                //retrieving the object created in the form of the "instance" earlier
    //                holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>();
    //                //calling  the object's CardDrawRandomizer function, which selects a random card from the deck
    //                holder.CardDrawRandomizerHuman(GameManager.Instance.Person.CurrentPlayer);
    //                //calling this script's generateCardObject function,  which creates an object to represent the card
    //                generateCardObject();
    //                //calling the script object's setSprite function, which passes in the SpriteRenderer, and sets it's sprite to the corresponding card chosen in CardDrawRandomizer
    //                holder.setSprite(sr);             
    //            }
    //            else
    //            {
    //                //calling this script's changeDeck function, which replaces the deck with an out of cards image
    //                changeDeck();
    //            }              
    //}
}
