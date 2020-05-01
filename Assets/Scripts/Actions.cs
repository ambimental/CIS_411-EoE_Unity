/*
 *  @class   Actions.cs
 *  @purpose Determine what actions the player will take 
 * 
 *  @author     John Georgvich, previous CIS411 group
 *  @date       2020/01/23
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Actions : MonoBehaviour
{

//    /*
//     *  @name       Start()
//     *  @purpose    Used by Unity engine to initialize objects
//     */
//    void Start()
//    {

//    }

//    /*
//     *  @name       Update()
//     *  @purpose    Used by Unity engine to update game object frame-by-frame
//     */
//    void Update()
//    {
//    }

//    /*
//     *  @name       checkAction()
//     *  @purpose    Determine whether or not card has an action associated with it
//     *  
//     *  @param      Card card;  Card object to inspect for associated action
//     */
//    public void checkAction(Card card)
//    {
//        //  stores actionIDs
//        List<string> actions = new List<string>();

//        //  for each string in card actionID
//        foreach (string x in card.ActionID)
//        {
//            //  save string to instanced variable and add to actions list
//            string actionId = x;
//            actions.Add(actionId);
//        }


//        foreach (string x in actions)
//        {
//            Type type = typeof(Acts);
//            Acts ClassObject = new Acts();
//            MethodInfo method = type.GetMethod(x);
//            method.Invoke(ClassObject, null);
//        }
//    }
//}

///*
// *  @class      Acts
// *  @purpose    Holds all actions (get rid of this shit)
// *  
// *  @author     John Georgvich, previous CIS411 group
// *  @date       2020/01/23
// */
//public class Acts
//{
//    //  create public/private objects for "acts class"
//    //  all of this shit is going away anyway, who cares
//    public CardRetrievalFromDeck holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>();
//    public DebugDealer playerDraw = ScriptableObject.FindObjectOfType<DebugDealer>();
//    private GameObject cardObject;
//    public Transform cardParent;
//    private SpriteRenderer sr;

//    //  determines if requirements are met and retrieves necessary requirements
//    public bool requirementsWork = false;
//    public Requirements cardReqs;

//    int deckCount = 0;
//    int discardCount = 0;
//    bool display = true;

//    /*
//     *  @name       generateCardObject()
//     *  @purpose    Creates an instance of card object
//     */
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
//        cardObject.AddComponent<ChooseCard>(); //makes it so that you can choose the card
//        //to allow mouse to go through the sprite to view what is behind it
//        cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
//    }

//    void Start()
//    {

//    }

//    //Human - Biologist
//    public void a002() //Special Action: Locate and play one animal from the deck or discard pile. Discard after use.
//    {
//        GameManager.Instance.pickCardHolder = GameObject.Find("Player/Animal Card Placement").transform; //sets parent

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.deckPicked) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].CardType == "Animal") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(deck.Cards[i])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                            deckCount++;
//                    }
//                }
//                for (int j = 0; j < GameManager.Instance.DiscardPlacement.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacement[j].CardType == "Animal")
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(GameManager.Instance.DiscardPlacement[j])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                            discardCount++;
//                    }
//                }
//            }

//            if (deckCount == 0 && discardCount == 0)
//            {
//                display = false;
//            }
//        }

//        if (display)
//        {
//            GameManager.Instance.check.showDeckDiscard(); //will show the decks and discard

//            foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//            {
//                if (deck.DeckId == GameManager.Instance.deckPicked) //checks to make sure that the players deck is the one that is being used
//                {
//                    for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                    {
//                        if (deck.Cards[i].CardType == "Animal") //if the card type is an animal, it should execute and display the card in selection canvas
//                        {
//                            cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                            if (cardReqs.requirementCheck(deck.Cards[i])) //determines if they work or not
//                                requirementsWork = true;
//                            else requirementsWork = false;

//                            if (requirementsWork == true)
//                            {
//                                GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list

//                                cardParent = GameObject.Find("DeckShow").transform; //sets the card parent
//                                holder.cardNameHolder = deck.Cards[i].CardName; //card name needed to get card image
//                                generateCardObject();
//                                holder.setSprite(sr);
//                            }
//                        }
//                    }
//                    for (int j = 0; j < GameManager.Instance.DiscardPlacement.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                    {
//                        if (GameManager.Instance.DiscardPlacement[j].CardType == "Animal")
//                        {
//                            cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                            if (cardReqs.requirementCheck(GameManager.Instance.DiscardPlacement[j])) //determines if they work or not
//                                requirementsWork = true;
//                            else requirementsWork = false;

//                            if (requirementsWork == true)
//                            {
//                                GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacement[j]); //if an animal, adds to the discard selection list

//                                cardParent = GameObject.Find("DiscardShow").transform; //sets the card parent
//                                holder.cardNameHolder = GameManager.Instance.DiscardPlacement[j].CardName; //card name needed to get card image
//                                generateCardObject();
//                                holder.setSprite(sr);
//                            }
//                        }
//                    }
//                }
//            }
//        }

//        //resets these variables for use for other cards
//        deckCount = 0;
//        discardCount = 0;
//        display = true;
//    }

//    //Human - Botanist
//    public void a004() //Special Action: Locate and play one Plant from the deck or discard pile. Discard after use.
//    {
//        GameManager.Instance.pickCardHolder = GameObject.Find("Plant Card Placement").transform; //sets parent

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.deckPicked) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].CardType == "Plant") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(deck.Cards[i])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                        {
//                            deckCount++;
//                        }
//                    }
//                }
//                for (int j = 0; j < GameManager.Instance.DiscardPlacement.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacement[j].CardType == "Plant")
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(GameManager.Instance.DiscardPlacement[j])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                        {
//                            discardCount++;
//                        }
//                    }
//                }

//                if (deckCount == 0 && discardCount == 0)
//                {
//                    display = false;
//                }
//            }
//        }

//        if (display)
//        {
//            GameManager.Instance.check.showDeckDiscard(); //will show the decks and discard

//            foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//            {
//                if (deck.DeckId == GameManager.Instance.deckPicked) //checks to make sure that the players deck is the one that is being used
//                {
//                    for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                    {
//                        if (deck.Cards[i].CardType == "Plant") //if the card type is an animal, it should execute and display the card in selection canvas
//                        {
//                            cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                            if (cardReqs.requirementCheck(deck.Cards[i])) //determines if they work or not
//                                requirementsWork = true;
//                            else requirementsWork = false;

//                            if (requirementsWork == true)
//                            {
//                                GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list

//                                cardParent = GameObject.Find("DeckShow").transform; //sets the card parent
//                                holder.cardNameHolder = deck.Cards[i].CardName; //card name needed to get card image
//                                generateCardObject();
//                                holder.setSpriteForPicking(sr);
//                            }
//                        }
//                    }
//                    for (int j = 0; j < GameManager.Instance.DiscardPlacement.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                    {
//                        if (GameManager.Instance.DiscardPlacement[j].CardType == "Plant")
//                        {
//                            cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                            if (cardReqs.requirementCheck(GameManager.Instance.DiscardPlacement[j])) //determines if they work or not
//                                requirementsWork = true;
//                            else requirementsWork = false;

//                            if (requirementsWork == true)
//                            {
//                                GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacement[j]); //if an animal, adds to the discard selection list

//                                cardParent = GameObject.Find("DiscardShow").transform; //sets the card parent
//                                holder.cardNameHolder = GameManager.Instance.DiscardPlacement[j].CardName; //card name needed to get card image
//                                generateCardObject();
//                                holder.setSpriteForPicking(sr);
//                            }
//                        }
//                    }
//                }
//            }
//        }

//        //resets these variables for use for other cards
//        deckCount = 0;
//        discardCount = 0;
//        display = true;
//    }

//    //Human - Explorer
//    public void a006() //Special Action: Locate and play one Condition card from the deck or discard pile. Discard after use.
//    {
//        GameManager.Instance.pickCardHolder = GameObject.Find("Condition Card Placement").transform; //sets parent

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.deckPicked) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].CardType == "Condition") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(deck.Cards[i])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                        {
//                            deckCount++;
//                        }
//                    }
//                }
//                for (int j = 0; j < GameManager.Instance.DiscardPlacement.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacement[j].CardType == "Condition")
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(GameManager.Instance.DiscardPlacement[j])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                        {
//                            discardCount++;
//                        }
//                    }
//                }

//                if (deckCount == 0 && discardCount == 0)
//                {
//                    display = false;
//                }
//            }
//        }

//        GameManager.Instance.check.showDeckDiscard(); //will show the decks and discard

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.deckPicked) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].CardType == "Condition") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(deck.Cards[i])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                        {
//                            GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list

//                            cardParent = GameObject.Find("DeckShow").transform; //sets the card parent
//                            holder.cardNameHolder = deck.Cards[i].CardName; //card name needed to get card image
//                            generateCardObject();
//                            holder.setSpriteForPicking(sr);
//                        }
//                    }
//                }
//                for (int j = 0; j < GameManager.Instance.DiscardPlacement.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacement[j].CardType == "Condition")
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(GameManager.Instance.DiscardPlacement[j])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                        {
//                            GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacement[j]); //if an animal, adds to the discard selection list

//                            cardParent = GameObject.Find("DiscardShow").transform; //sets the card parent
//                            holder.cardNameHolder = GameManager.Instance.DiscardPlacement[j].CardName; //card name needed to get card image
//                            generateCardObject();
//                            holder.setSpriteForPicking(sr);
//                        }
//                    }
//                }
//            }
//        }

//        //resets these variables for use for other cards
//        deckCount = 0;
//        discardCount = 0;
//        display = true;
//    }

//    //Human - Ranger 
//    public void a008() //Special Action: The Ranger can be used to remove the Man-Eater multi-player card from play without removing the species it is played on.  Discard ranger and Man-eater cards if used in this way
//    {
//        //MAN EATER CURRENTLY NOT IN THE DATABASE SO THIS IS NOT NEEDED RIGHT NOW ND THERE IS REALLY NO WAY TO TEST IT
//    }

//    //Human - Two Sisters in the Wild
//    public void a010() //Special Action: If Two Sisters in the Wild is discarded, all players draw three cards
//    {
//        //will draw three cards to the players hand
//        for (int i = 0; i < 3; i++)
//            playerDraw.DrawCard(); //draws

//        //draws 3 cards to cp1 hand
//        for (int i = 0; i < 3; i++)
//            holder.drawCP1Deck(); //draws

//        //draws 3 cards to cp2 hand
//        for (int i = 0; i < 3; i++)
//            holder.drawCP2Deck(); //draws

//        //draws 3 cards to cp3 hand
//        for (int i = 0; i < 3; i++)
//            holder.drawCP3Deck(); //draws
//    }

//    //Multiplayer - Acidic Waters
//    public void a011() //Actions: When played, up to three Running, Standing or Salt Water regions can be stacked in one pile with acidic waters on top.  These regions are no longer able to sustain life while acidic waters is in play
//    {
//        // CHECKS IF THERE IS A COMPUTER THAT CAN HAVE ACIDIC WATERS PLAYED ON IT

//        //will help determine if they can be played on or not
//        bool acid1 = false;
//        bool acid2 = false;
//        bool acid3 = false;

//        // Computer one check
//        //checks to make sure there are even enough regions to be used - only has to be one
//        if ((GameManager.Instance.cp1SaltWaterCount + GameManager.Instance.cp1StandingWaterCount + GameManager.Instance.cp1RunningWaterCount) > 0)
//        {
//            //if enough are able to be used, then make the option visible to the plyer
//            acid1 = true;
//        }

//        // Computer two check
//        //checks to make sure there are even enough regions to be used - only has to be one
//        if ((GameManager.Instance.cp2SaltWaterCount + GameManager.Instance.cp2StandingWaterCount + GameManager.Instance.cp2RunningWaterCount) > 0)
//        {
//            //if enough are able to be used, then make the option visible to the plyer
//            acid2 = true;
//        }

//        // Computer three check
//        //checks to make sure there are even enough regions to be used - only has to be one
//        if ((GameManager.Instance.cp3SaltWaterCount + GameManager.Instance.cp3StandingWaterCount + GameManager.Instance.cp3RunningWaterCount) > 0)
//        {
//            //if enough are able to be used, then make the option visible to the plyer
//            acid3 = true;
//        }

//        //if any are true, the canvas is shown
//        GameManager.Instance.AcidicWatersCanvas.SetActive(true); //shows the canvas

//        //displays the option to choose which player should get the acidic waters
//        if (acid1 == true)
//        {

//        }
//        if (acid2 == true)
//        {

//        }
//        if (acid3 == true)
//        {

//        }
//    }

//    //Multiplayer - Children at Play
//    public void a012() //Actions: All actions within one player's ecosystem are paused for one turn.
//    {
//        GameManager.Instance.playerPausedOneTurn = true; //this will make it so that the players actions will be paused for one round
//    }

//    //Multipayer - Extinction
//    public void a013() //Actions: One Species is now extinct. All players remove any copies of this Species from the game.
//    {
//        //GameManager.Instance.pickExtinction.gameObject.SetActive(true); //makes it so that the extinction choices can be made
//    }

//    //Multiplayer - Isolated Ecosystems
//    public void a014() //Actions: While Isolated Ecosystem is in play, this player’s ecosystem is not affected by Web of Life or other cards with standing actions that affect more than one ecosystem
//    {
//        GameManager.Instance.playerProtectedFromWeb = true; //protects the player from the web of life and other standing actions cards
//    }

//    //Multiplayer - Temperature Drop
//    public void a015() //Actions: Discard Temperature Drop directly from your hand. All actions within one player’s ecosystem are paused for one turn
//    {
//        //discards from your hand, then pause for a turn
//        GameManager.Instance.playerPausedOneTurn = true; //will make it so it pauses
//    }

//    //Human - Grandpa Strohm
//    public void a019() //Special Action: Grandpa Strohm can be used to locate and play any one card from your deck or discard pile. if used this way remove grandpa strohm from the game
//    {
//        //parent cannot be set that early here due to the fact that it can be any card
//        //GameManager.Instance.pickCardHolder = GameObject.Find("Invertebrate Card Placement").transform; //sets parent

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.deckPicked) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck - should be able to display all cards that can be played
//                {
//                    cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                    if (cardReqs.requirementCheck(deck.Cards[i])) //determines if they work or not
//                        requirementsWork = true;
//                    else requirementsWork = false;

//                    if (requirementsWork == true)
//                    {
//                        deckCount++;
//                    }
//                }
//                for (int j = 0; j < GameManager.Instance.DiscardPlacement.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                    if (cardReqs.requirementCheck(GameManager.Instance.DiscardPlacement[j])) //determines if they work or not
//                        requirementsWork = true;
//                    else requirementsWork = false;

//                    if (requirementsWork == true)
//                    {
//                        discardCount++;
//                    }
//                }
//            }

//            if (discardCount == 0 && deckCount == 0)
//            {
//                display = false;
//            }
//        }

//        GameManager.Instance.check.showDeckDiscard(); //will show the decks and discard

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.deckPicked) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck - should be able to display all cards that can be played
//                {
//                    cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                    if (cardReqs.requirementCheck(deck.Cards[i])) //determines if they work or not
//                        requirementsWork = true;
//                    else requirementsWork = false;

//                    if (requirementsWork == true)
//                    {
//                        GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list

//                        cardParent = GameObject.Find("DeckShow").transform; //sets the card parent
//                        holder.cardNameHolder = deck.Cards[i].CardName; //card name needed to get card image
//                        generateCardObject();
//                        holder.setSprite(sr);
//                    }
//                }
//                for (int j = 0; j < GameManager.Instance.DiscardPlacement.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                    if (cardReqs.requirementCheck(GameManager.Instance.DiscardPlacement[j])) //determines if they work or not
//                        requirementsWork = true;
//                    else requirementsWork = false;

//                    if (requirementsWork == true)
//                    {
//                        GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacement[j]); //if an animal, adds to the discard selection list

//                        cardParent = GameObject.Find("DiscardShow").transform; //sets the card parent
//                        holder.cardNameHolder = GameManager.Instance.DiscardPlacement[j].CardName; //card name needed to get card image
//                        generateCardObject();
//                        holder.setSprite(sr);
//                    }
//                }
//            }
//        }

//        //resets the variables
//        deckCount = 0;
//        discardCount = 0;
//        display = true;
//    }

//    //Multiplayer - Blight
//    public void a020() //Actions: Play on one Plant card. Discard affected Plant card and Blight card at the end of the affected players next turn.
//    {

//    }

//    //Multiplayer - Ideal Conditions
//    public void a021() //Actions: have to play ideal conditions, then click buton to perform action, then drawing three cards
//    {
//        //just draws the three cards
//        playerDraw.DrawCard();
//        playerDraw.DrawCard();
//        playerDraw.DrawCard();
//    }

//    //Multiplayer - Invasive Invertebrate Species
//    public void a022() //Actions: Play on one Invertebrate card. That card is now an Invasive Species. At the end of the affected players turn discard one invertebrate from play that is not affected by the invasive invertebrate species card.  Continue this prpcess until the card affected by the invasive invertebrate is the only invertebrate card in the ecosystem
//    {

//    }

//    //Multiplayer - Web of Life
//    public void a023() //Actions: All players’ ecosystems are now connected. What affects one affects them all including standing actions effects from multiplayer cards and human cards.  Discard but after the last round ends
//    {
//        GameManager.Instance.ecosystemsConnected = true; //all ecosystems are connected
//    }

//    //Human - Conservation Engineer
//    public void a025() //Special Action: Locate and play one 20 point or greater card from the deck or discard pile. Discard after use.
//    {
//        GameManager.Instance.check.showDeckDiscard(); //will show the decks and discard

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.deckPicked) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck - should be able to display all cards that can be played
//                {
//                    if (deck.Cards[i].PointValue >= 20)
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(deck.Cards[i])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                        {
//                            GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list

//                            cardParent = GameObject.Find("DeckShow").transform; //sets the card parent
//                            holder.cardNameHolder = deck.Cards[i].CardName; //card name needed to get card image
//                            generateCardObject();
//                            holder.setSprite(sr);
//                        }
//                    }
//                }
//                for (int j = 0; j < GameManager.Instance.DiscardPlacement.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacement[j].PointValue >= 20)
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(GameManager.Instance.DiscardPlacement[j])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                        {
//                            GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacement[j]); //if an animal, adds to the discard selection list

//                            cardParent = GameObject.Find("DiscardShow").transform; //sets the card parent
//                            holder.cardNameHolder = GameManager.Instance.DiscardPlacement[j].CardName; //card name needed to get card image
//                            generateCardObject();
//                            holder.setSprite(sr);
//                        }
//                    }
//                }
//            }
//        }
//    }

//    //Human - Entomologist
//    public void a027() //Special Action: Locate and play one invertebrate from the deck or discard pile. Discard after use.
//    {
//        GameManager.Instance.pickCardHolder = GameObject.Find("Invertebrate Card Placement").transform; //sets parent

//        GameManager.Instance.check.showDeckDiscard(); //will show the decks and discard

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.deckPicked) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].CardType == "Invertebrate") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(deck.Cards[i])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                        {
//                            GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list

//                            cardParent = GameObject.Find("DeckShow").transform; //sets the card parent
//                            holder.cardNameHolder = deck.Cards[i].CardName; //card name needed to get card image
//                            generateCardObject();
//                            holder.setSprite(sr);
//                        }
//                    }
//                }
//                for (int j = 0; j < GameManager.Instance.DiscardPlacement.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacement[j].CardType == "Invertebrate")
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(GameManager.Instance.DiscardPlacement[j])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                        {
//                            GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacement[j]); //if an animal, adds to the discard selection list

//                            cardParent = GameObject.Find("DiscardShow").transform; //sets the card parent
//                            holder.cardNameHolder = GameManager.Instance.DiscardPlacement[j].CardName; //card name needed to get card image
//                            generateCardObject();
//                            holder.setSprite(sr);
//                        }
//                    }
//                }
//            }
//        }
//    }

//    //Multiplayer - Relocate Species
//    public void a028() //Actions: Move one non-human Species in play to another ecosystem. Place Relocate Species behind the relocated card.
//    {
//        //not sure, description is cut off
//    }

//    //Multiplayer - Forest Fire
//    public void a029() //Actions: When played, up to three Forest regions are stacked in one pile with Forest Fire placed on top.  These regions are no longer forests while forest fire is in play.  Treat these regions as grasslands.  Discard Forest fire if all affected regions are no longer in play
//    {
//        //dont know description is cut off
//    }

//    //Animal - Barred Owl - I believe this is what is considered an invasive animal - unless its a multiplayer card??
//    public void a030() //If three Canopy Plants and two Tiny or Small Animals are in play, Barred Owl can be played directly from the deck or discard pile
//    {
//        //dont know description is cut off
//    }

//    //Plant - Allegheny Blackberry
//    public void a031() //When Allegheny Blackberry is played, also place one playable Understory or Canopy Plant from your deck or discard pile directly into play
//    {
//        GameManager.Instance.pickCardHolder = GameObject.Find("Plant Card Placement").transform; //sets parent

//        GameManager.Instance.check.showDeckDiscard(); //will show the decks and discard

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.deckPicked) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].PlantType == "Understory" || deck.Cards[i].PlantType == "Canopy") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(deck.Cards[i])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                        {
//                            GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list

//                            cardParent = GameObject.Find("DeckShow").transform; //sets the card parent
//                            holder.cardNameHolder = deck.Cards[i].CardName; //card name needed to get card image
//                            generateCardObject();
//                            holder.setSprite(sr);
//                        }
//                    }
//                }
//                for (int j = 0; j < GameManager.Instance.DiscardPlacement.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacement[j].PlantType == "Understory" || GameManager.Instance.DiscardPlacement[j].PlantType == "Canopy")
//                    {
//                        cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

//                        if (cardReqs.requirementCheck(GameManager.Instance.DiscardPlacement[j])) //determines if they work or not
//                            requirementsWork = true;
//                        else requirementsWork = false;

//                        if (requirementsWork == true)
//                        {
//                            GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacement[j]); //if an animal, adds to the discard selection list

//                            cardParent = GameObject.Find("DiscardShow").transform; //sets the card parent
//                            holder.cardNameHolder = GameManager.Instance.DiscardPlacement[j].CardName; //card name needed to get card image
//                            generateCardObject();
//                            holder.setSprite(sr);
//                        }
//                    }
//                }
//            }
//        }
//    }

//    //Plant - Bigtooth Aspen
//    public void a032() //Bigtooth Aspen can be played directly from the deck or discard pile if your ecosystem is affected by forest fire
//    {
//        //dont know description is cut off
//    }

//    //Plant - Eastern White Pine
//    public void a033() //When Eastern White Pine is played, an herbivore can be played directly from the deck or discard pile 
//    {
//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.deckPicked) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].AnimalDiet == "Herbivore") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list

//                        cardParent = GameObject.Find("DeckShow").transform; //sets the card parent
//                        holder.cardNameHolder = deck.Cards[i].CardName; //card name needed to get card image
//                        generateCardObject();
//                        holder.setSprite(sr);
//                    }
//                }
//                for (int j = 0; j < GameManager.Instance.DiscardPlacement.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacement[j].AnimalDiet == "Herbivore")
//                    {
//                        GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacement[j]); //if an animal, adds to the discard selection list

//                        cardParent = GameObject.Find("DiscardShow").transform; //sets the card parent
//                        holder.cardNameHolder = GameManager.Instance.DiscardPlacement[j].CardName; //card name needed to get card image
//                        generateCardObject();
//                        holder.setSprite(sr);
//                    }
//                }
//            }
//        }
//    }

//    //Plant - White Birch
//    public void a034() //White Birch can be played directly from the deck or discard pile if your ecosystem is affected by Forest fire
//    {
//        //dont know description os cut off
//    }

//    //Animal - Black Rat Snake - Invasive animal species???
//    public void a038() //If two Animals from the Order: Rodentia are in play, Black Rat Snake can be placed directly into play from the deck or the discard pile if its requirements are met
//    {
//        //??????????????????????
//    }

//    //Invertebrate - Globe Skimmer Dragonfly
//    public void a046() //At the beginning of your turn, Globe Skimmer moves from its current ecosystem to the ecosystem on its right, even if the ecosystem doesn't meet the globe skimeer's requirements
//    {
//        //description not finished please stop this
//    }

//    //Microbe - Iron Bacteria
//    public void a047() //Iron Bacteria neutralizes the effect of Acidic Waters.
//    {

//    }

//    //Animal - Barn Owl
//    public void a051() //If two animals from the class mammalia are in play, Barn Owl can be played directly from the deck or discard pile at the beginning of your next turn
//    {

//    }

//    //Biologist
//    public void a001() //Standing Action: While the biologist is in play, the ecosystem is protected from Invasive Animal Species. Discard after use
//    {
//    }

//    //Human - Botanist
//    public void a003() //Standing Action: While the Botanist is in play, the ecosystem is protected from one Invasive Plant species.  Discard after use
//    {
//    }

//    //Human - Explorer
//    public void a005() //Standing Action: While the Explorer is in play, the ecosystem can play Condition cards without meeting the conditions requirements
//    {
//    }

//    //Human - Ranger
//    public void a007() //Standing Action: While the Ranger is in play, the ecosystem is protected from Blight. Discard if Blight is used.
//    {
//    }

//    //Human - Two Sisters in the Wild
//    public void a009() //Standing Action: While Two Sisters in the Wild is in play, your ecosystem is protected from Extinction
//    {
//    }

//    //Human - Grandma Moore
//    public void a016() //Standing Action: When Grandma Moore is in play, you no longer need to discard at the end of your turn
//    {
//    }

//    //Human - Grandma Strohm
//    public void a017() //Standing Action: While Grandma Strohm is in play, draw an extra card at the beginning of your turn
//    {
//    }

//    //Human - Grandpa Strohm
//    public void a018() //Standing Action: While in play, Grandpa Strohm just watches everything happen.
//    {
//    }

//    //Human - Conservation Engineer
//    public void a024() //Standing Action: While the Conservation Engineer is in play, you can keep one 20+ point card in your hand and not have to discard it
//    {
//    }

//    //Human - Entomologist
//    public void a026() //Standing Action: While the Entomologist is in play, the ecosystem is protected from one invasive invertebrate.  Discard after use
//    {
//    }

//    //Special Regions - Farmers Cove
//    public void a035() // Farmer’s Cove provides: 1 Grassland region and 1 Running Water region.
//    {
//    }

//    //Special Region - The Strohmstead
//    public void a036() //The Strohmstead provides: 1 Forest region, 1 Grasslands region, 1 Standing Water region, and 1 Running water region
//    {
//    }

//    //Special Region - Hunters Ridge
//    public void a037() //Hunter’s Ridge provides: 1 Forest region and 1 Grassland region.
//    {
//    }

//    //Animal - Domesticated Cat
//    public void a039() //If no humans are in play within your ecosystem, Domesticated Cat will move to the player on the right.  Repeat this action until it finds an ecosystem with a human.  if no humans are in play, discard domesticated cat
//    {
//    }

//    //Animal - Domesticated Chicken
//    public void a040() //Domesticated Chicken cannot migrate and is human-dependant. Discard if no humans are in play within your ecosystem
//    {
//    }

//    //Animal - Domesticated Dog
//    public void a041() //Domesticated Dog will remain in play for three additional rounds without a human. If no humans are in play at the end of the third round, discard domdesticated dog.
//    {
//    }

//    //Invertebrate - Goldenrod Soldier Beetle
//    public void a042() //If Goldenrod is played, Goldenrod Soldier Beetle can be played directly from the deck or discard pile at the beginning of the next round
//    {
//    }

//    //Plant - Alfalfa
//    public void a043() //The round after Alfalfa is played, a Tiny or Small Invertebrate can be played from the deck or discard pile
//    {
//    }

//    //Plant - Common Dandelion
//    public void a044() //Common Dandelion is immune to Invasive Plant Species. It cannot be discarded or relocated once played
//    {
//    }

//    //Plant - Orange Hawkweed
//    public void a045() //The round after Orange Hawkweed is played, a fly from the Genus: Musca can be played directly from the deck or discard pile
//    {
//    }

//    //Microbe - Spirulina Algae
//    public void a048() //Spirulina Algae also counts as a Groundcover Plant.
//    {
//    }

//    //Plant - White Birch
//    public void a049() //White Birch can be played directly from the deck or discard pile if your ecosystem is affected by Forest fire
//    {
//    }

//    //Special Region - Animal Sanctuary
//    public void a050() //Animal Sanctuary can support any 1 Animal species, regardless of its requirements.
//    {
//    }

}
