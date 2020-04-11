//THE ACTIONS FOR THE COMPUTER ONE AI

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ActionsCP3 : MonoBehaviour
{

//    // Use this for initialization
//    void Start()
//    {
//    }

//    // Update is called once per frame
//    void Update()
//    {
//    }

//    //will determine whether or not the card has an action what to ddo with it
//    public void checkAction(Card card)
//    {
//        List<string> actions = new List<string>(); //to store the action ids

//        foreach (string x in card.ActionID)
//        {
//            string actionId = x;
//            actions.Add(actionId); //adds the ids to the list
//        }

//        foreach (string x in actions)
//        {
//            Type type = typeof(ActsCP3);
//            ActsCP3 ClassObject = new ActsCP3();
//            MethodInfo method = type.GetMethod(x);
//            method.Invoke(ClassObject, null);
//        }
//    }
//}

//public class ActsCP3
//{
//    public CardRetrievalFromDeck holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>(); //gets access to the script
//    public DebugDealer playerDraw = ScriptableObject.FindObjectOfType<DebugDealer>(); //gets access to the script
//    private GameObject cardObject;
//    public Transform cardParent; //to get the parent of the card
//    private SpriteRenderer sr;

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
//        cardObject.AddComponent<ChooseCard>(); //makes it so that you can choose the card
//        //to allow mouse to go through the sprite to view what is behind it
//        cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
//    }

//    void Start()
//    {

//    }

//    //Biologist
//    public void a001() //Standing Action: While the biologist is in play, the ecosystem is protected from Invasive Animal Species. Discard after use
//    {
//        //will be used to protect the AI 1 from an invasive animal
//        GameManager.Instance.cp3ProtectedFromInvasiveAnimal = true;
//    }

//    //Human - Biologist
//    public void a002() //Special Action: Locate and play one animal from the deck or discard pile. Discard after use.
//    {
//        GameManager.Instance.pickCardHolder = GameObject.Find("Computer Three Board/Animal Card Placement").transform; //sets parent
//        bool deckCard = false; //these two bools will determine where the card came from
//        bool discardCard = false;

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.computerThreeDeck) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].CardType == "Animal") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list
//                    }
//                }

//                for (int j = 0; j < GameManager.Instance.DiscardPlacementCP3.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacementCP3[j].CardType == "Animal")
//                    {
//                        GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacementCP3[j]); //if an animal, adds to the discard selection list
//                    }
//                }

//                //The discard and the deck list will be compared to see which card has the highest point value, which is what will be returned for the AI
//                Card cardHolder = GameManager.Instance.DeckSelectionList[0]; //sets the first variable for testing

//                for (int x = 1; x < GameManager.Instance.DeckSelectionList.Count; x++)//if the new card is greater than the original, change the variable
//                {
//                    if (GameManager.Instance.DeckSelectionList[x].PointValue > cardHolder.PointValue)
//                    {
//                        cardHolder = GameManager.Instance.DeckSelectionList[x];
//                        deckCard = true;
//                        deckCard = false;
//                    }
//                }

//                for (int x = 1; x < GameManager.Instance.DiscardSelectionList.Count; x++) //if there is a card in the discard pile with greater value, it will replace the card holder
//                {
//                    if (GameManager.Instance.DiscardSelectionList[x].PointValue > cardHolder.PointValue)
//                    {
//                        cardHolder = GameManager.Instance.DiscardSelectionList[x];
//                        discardCard = true;
//                        deckCard = false;
//                    }
//                }

//                //determine which pile the cardHolder came from and where to get rid of the card in the AI playing field
//                if (deckCard == true)
//                {
//                    cardParent = GameManager.Instance.pickCardHolder;

//                    holder.cardNameHolder = cardHolder.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr); //sets image to the card

//                    GameManager.Instance.changeComputerOneScore(cardHolder.PointValue); //changes the players score

//                    GameManager.Instance.AnimalPlacementCP3.Add(cardHolder); //adds the selected card to the animal placement list

//                    for (int i = 0; i < deck.Cards.Count; i++) //goes through the deck, finds the card, then removes it from the deck list
//                    {
//                        if (deck.Cards[i].CardName == cardHolder.CardName)
//                        {
//                            deck.Cards.Remove(cardHolder); //removes the card
//                            break; //just breaks the for loop
//                        }
//                    }
//                }
//                else if (discardCard == true)
//                {
//                    cardParent = GameManager.Instance.pickCardHolder;

//                    holder.cardNameHolder = cardHolder.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr); //sets image to the card

//                    GameManager.Instance.changeComputerOneScore(cardHolder.PointValue); //changes the players score

//                    GameManager.Instance.AnimalPlacementCP3.Add(cardHolder); //adds the selected card to the animal placement list

//                    for (int i = 0; i < GameManager.Instance.DiscardPlacementCP3.Count; i++) //goes through the discard pile, finds the card, then removes it from the deck list
//                    {
//                        if (GameManager.Instance.DiscardPlacementCP3[i].CardName == cardHolder.CardName)
//                        {
//                            GameManager.Instance.DiscardPlacementCP3.Remove(cardHolder); //removes the card
//                            break; //just breaks the for loop
//                        }
//                    }
//                }
//            }
//        }

//        //clears the lists so that other actions can use them
//        GameManager.Instance.DeckSelectionList.Clear();
//        GameManager.Instance.DiscardSelectionList.Clear();
//    }

//    //Human - Botanist
//    public void a003() //Standing Action: While the Botanist is in play, the ecosystem is protected from one Invasive Plant species.  Discard after use
//    {
//        //will protect the player from one invasive species
//        GameManager.Instance.cp3ProtectedFromInvasivePlant = true;
//    }

//    //Human - Botanist
//    public void a004() //Special Action: Locate and play one Plant from the deck or discard pile. Discard after use.
//    {
//        GameManager.Instance.pickCardHolder = GameObject.Find("Computer Three Board/Plant Card Placement").transform; //sets parent
//        bool deckCard = false; //these two bools will determine where the card came from
//        bool discardCard = false;

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.computerThreeDeck) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].CardType == "Plant") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list
//                    }
//                }

//                for (int j = 0; j < GameManager.Instance.DiscardPlacementCP3.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacementCP3[j].CardType == "Plant")
//                    {
//                        GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacementCP3[j]); //if an animal, adds to the discard selection list
//                    }
//                }

//                //The discard and the deck list will be compared to see which card has the highest point value, which is what will be returned for the AI
//                Card cardHolder = GameManager.Instance.DeckSelectionList[0]; //sets the first variable for testing

//                for (int x = 1; x < GameManager.Instance.DeckSelectionList.Count; x++)//if the new card is greater than the original, change the variable
//                {
//                    if (GameManager.Instance.DeckSelectionList[x].PointValue > cardHolder.PointValue)
//                    {
//                        cardHolder = GameManager.Instance.DeckSelectionList[x];
//                        deckCard = true;
//                        deckCard = false;
//                    }
//                }

//                for (int x = 1; x < GameManager.Instance.DiscardSelectionList.Count; x++) //if there is a card in the discard pile with greater value, it will replace the card holder
//                {
//                    if (GameManager.Instance.DiscardSelectionList[x].PointValue > cardHolder.PointValue)
//                    {
//                        cardHolder = GameManager.Instance.DiscardSelectionList[x];
//                        discardCard = true;
//                        deckCard = false;
//                    }
//                }

//                //determine which pile the cardHolder came from and where to get rid of the card in the AI playing field
//                if (deckCard == true)
//                {
//                    cardParent = GameManager.Instance.pickCardHolder;

//                    holder.cardNameHolder = cardHolder.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr); //sets image to the card

//                    GameManager.Instance.changeComputerOneScore(cardHolder.PointValue); //changes the players score

//                    GameManager.Instance.PlantPlacementCP3.Add(cardHolder); //adds the selected card to the animal placement list

//                    for (int i = 0; i < deck.Cards.Count; i++) //goes through the deck, finds the card, then removes it from the deck list
//                    {
//                        if (deck.Cards[i].CardName == cardHolder.CardName)
//                        {
//                            deck.Cards.Remove(cardHolder); //removes the card
//                            break; //just breaks the for loop
//                        }
//                    }
//                }
//                else if (discardCard == true)
//                {
//                    cardParent = GameManager.Instance.pickCardHolder;

//                    holder.cardNameHolder = cardHolder.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr); //sets image to the card

//                    GameManager.Instance.changeComputerOneScore(cardHolder.PointValue); //changes the players score

//                    GameManager.Instance.PlantPlacementCP3.Add(cardHolder); //adds the selected card to the animal placement list

//                    for (int i = 0; i < GameManager.Instance.DiscardPlacementCP3.Count; i++) //goes through the discard pile, finds the card, then removes it from the deck list
//                    {
//                        if (GameManager.Instance.DiscardPlacementCP3[i].CardName == cardHolder.CardName)
//                        {
//                            GameManager.Instance.DiscardPlacementCP3.Remove(cardHolder); //removes the card
//                            break; //just breaks the for loop
//                        }
//                    }
//                }
//            }
//        }

//        //clears the lists so that other actions can use them
//        GameManager.Instance.DeckSelectionList.Clear();
//        GameManager.Instance.DiscardSelectionList.Clear();
//    }

//    //Human - Explorer
//    public void a005() //Standing Action: While the Explorer is in play, the ecosystem can play Condition cards without meeting the conditions requirements
//    {
//        //will allow theuser to play condition cards without the requirements
//        GameManager.Instance.cp3NoConditionRequirements = true;
//    }

//    //Human - Explorer
//    public void a006() //Special Action: Locate and play one Condition card from the deck or discard pile. Discard after use.
//    {
//        GameManager.Instance.pickCardHolder = GameObject.Find("Computer Three Board/Condition Card Placement").transform; //sets parent
//        bool deckCard = false; //these two bools will determine where the card came from
//        bool discardCard = false;

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.computerThreeDeck) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].CardType == "Condition") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list
//                    }
//                }

//                for (int j = 0; j < GameManager.Instance.DiscardPlacementCP3.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacementCP3[j].CardType == "Condition")
//                    {
//                        GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacementCP3[j]); //if an animal, adds to the discard selection list
//                    }
//                }

//                //The discard and the deck list will be compared to see which card has the highest point value, which is what will be returned for the AI
//                Card cardHolder = GameManager.Instance.DeckSelectionList[0]; //sets the first variable for testing

//                for (int x = 1; x < GameManager.Instance.DeckSelectionList.Count; x++)//if the new card is greater than the original, change the variable
//                {
//                    if (GameManager.Instance.DeckSelectionList[x].PointValue > cardHolder.PointValue)
//                    {
//                        cardHolder = GameManager.Instance.DeckSelectionList[x];
//                        deckCard = true;
//                        deckCard = false;
//                    }
//                }

//                for (int x = 1; x < GameManager.Instance.DiscardSelectionList.Count; x++) //if there is a card in the discard pile with greater value, it will replace the card holder
//                {
//                    if (GameManager.Instance.DiscardSelectionList[x].PointValue > cardHolder.PointValue)
//                    {
//                        cardHolder = GameManager.Instance.DiscardSelectionList[x];
//                        discardCard = true;
//                        deckCard = false;
//                    }
//                }

//                //determine which pile the cardHolder came from and where to get rid of the card in the AI playing field
//                if (deckCard == true)
//                {
//                    cardParent = GameManager.Instance.pickCardHolder;

//                    holder.cardNameHolder = cardHolder.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr); //sets image to the card

//                    GameManager.Instance.changeComputerOneScore(cardHolder.PointValue); //changes the players score

//                    GameManager.Instance.ConditionPlacementCP3.Add(cardHolder); //adds the selected card to the animal placement list

//                    for (int i = 0; i < deck.Cards.Count; i++) //goes through the deck, finds the card, then removes it from the deck list
//                    {
//                        if (deck.Cards[i].CardName == cardHolder.CardName)
//                        {
//                            deck.Cards.Remove(cardHolder); //removes the card
//                            break; //just breaks the for loop
//                        }
//                    }
//                }
//                else if (discardCard == true)
//                {
//                    cardParent = GameManager.Instance.pickCardHolder;

//                    holder.cardNameHolder = cardHolder.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr); //sets image to the card

//                    GameManager.Instance.changeComputerOneScore(cardHolder.PointValue); //changes the players score

//                    GameManager.Instance.ConditionPlacementCP3.Add(cardHolder); //adds the selected card to the animal placement list

//                    for (int i = 0; i < GameManager.Instance.DiscardPlacementCP3.Count; i++) //goes through the discard pile, finds the card, then removes it from the deck list
//                    {
//                        if (GameManager.Instance.DiscardPlacementCP3[i].CardName == cardHolder.CardName)
//                        {
//                            GameManager.Instance.DiscardPlacementCP3.Remove(cardHolder); //removes the card
//                            break; //just breaks the for loop
//                        }
//                    }
//                }
//            }
//        }

//        //clears the lists so that other actions can use them
//        GameManager.Instance.DeckSelectionList.Clear();
//        GameManager.Instance.DiscardSelectionList.Clear();
//    }

//    //Human - Ranger
//    public void a007() //Standing Action: While the Ranger is in play, the ecosystem is protected from Blight. Discard if Blight is used.
//    {
//        GameManager.Instance.cp3ProtectedFromBlight = true;
//    }

//    //Human - Ranger 
//    public void a008() //Special Action: The Ranger can be used to remove the Man-Eater multi-player card from play without removing the species it is played on.  Discard ranger and Man-eater cards if used in this way
//    {
//        // The Mna-Eater card is currently not in the database so i am leaving this with nothing for now 
//    }

//    //Human - Two Sisters in the Wild
//    public void a009() //Standing Action: While Two Sisters in the Wild is in play, your ecosystem is protected from Extinction
//    {
//        GameManager.Instance.cp3ProtectedFromExtinction = true; //player will be protected from exitinction while this is true
//    }

//    //Human - Two Sisters in the Wild
//    public void a010() //Special Action: If Two Sisters in the Wild is discarded, all players draw three cards
//    {
//        //will draw three cards to the players hand
//        for (int i = 0; i < 3; i++)
//            playerDraw.DrawCard(); //draws

//        //draws 3 cards to CP3 hand
//        for (int i = 0; i < 3; i++)
//            holder.drawCP3Deck(); //draws

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
//        //will have to choose between which player to use the card on - only in decks 1 & 2 - Allegheny national forest & Appalachain Homestead
//        //cannot be used on the Allegheny Forest Deck due to it not having any water regions
//    }

//    //Multiplayer - Children at Play
//    public void a012() //Actions: All actions within one player's ecosystem are paused for one turn.
//    {
//        GameManager.Instance.cp3PausedOneTurn = true; //this will make it so that the players actions will be paused for one round
//    }

//    //Multipayer - Extinction
//    public void a013() //Actions: One Species is now extinct. All players remove any copies of this Species from the game.
//    {
//        //should be able to pick a certain species to make extinct - possibly a new scene or popup box
//    }

//    //Multiplayer - Isolated Ecosystems
//    public void a014() //Actions: While Isolated Ecosystem is in play, this player’s ecosystem is not affected by Web of Life or other cards with standing actions that affect more than one ecosystem
//    {
//        GameManager.Instance.cp3ProtectedFromWeb = true; //protects the player from the web of life and other standing actions cards
//    }

//    //Multiplayer - Temperature Drop
//    public void a015() //Actions: Discard Temperature Drop directly from your hand. All actions within one player’s ecosystem are paused for one turn
//    {
//        //discards from your hand, then pause for a turn
//        GameManager.Instance.cp3PausedOneTurn = true; //will make it so it pauses
//    }

//    //Human - Grandma Moore
//    public void a016() //Standing Action: When Grandma Moore is in play, you no longer need to discard at the end of your turn
//    {
//        GameManager.Instance.cp3NoDiscard = true; //player no longer has to discard
//    }

//    //Human - Grandma Strohm
//    public void a017() //Standing Action: While Grandma Strohm is in play, draw an extra card at the beginning of your turn
//    {
//        GameManager.Instance.cp3DrawExtraCard = true; //player can now draw an extra card at the beginning of the round
//    }

//    //Human - Grandpa Strohm
//    public void a018() //Standing Action: While in play, Grandpa Strohm just watches everything happen.
//    {
//        //nothing goes here
//    }

//    //Human - Grandpa Strohm
//    public void a019() //Special Action: Grandpa Strohm can be used to locate and play any one card from your deck or discard pile. if used this way remove grandpa strohm from the game
//    {
//        //have to make a panel large enough to hold all cards for you to choose from
//    }

//    //Multiplayer - Blight
//    public void a020() //Actions: Play on one Plant card. Discard affected Plant card and Blight card at the end of the affected players next turn.
//    {

//    }

//    //Multiplayer - Ideal Conditions
//    public void a021() //Actions: Discard Ideal Conditions from your hand directly to the discard pile. All players draw three cards
//    {

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
//    public void a024() //Standing Action: While the Conservation Engineer is in play, you can keep one 20+ point card in your hand and not have to discard it
//    {
//        GameManager.Instance.cp3TwentyPointNoDiscard = true; //player can keep one twenty point card in their hand 
//    }

//    //Human - Conservation Engineer
//    public void a025() //Special Action: Locate and play one 20 point or greater card from the deck or discard pile. Discard after use.
//    {

//    }

//    //Human - Entomologist
//    public void a026() //Standing Action: While the Entomologist is in play, the ecosystem is protected from one invasive invertebrate.  Discard after use
//    {
//        GameManager.Instance.cp3ProtectedFromInvertebrate = true; //player is protected from invaive invertebrate
//    }

//    //Human - Entomologist
//    public void a0027() //Special Action: Locate and play one invertebrate from the deck or discard pile. Discard after use.
//    {
//        GameManager.Instance.pickCardHolder = GameObject.Find("Computer Three Board/Invertebrate Card Placement").transform; //sets parent
//        bool deckCard = false; //these two bools will determine where the card came from
//        bool discardCard = false;

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.computerThreeDeck) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].CardType == "Invertebrate") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list
//                    }
//                }

//                for (int j = 0; j < GameManager.Instance.DiscardPlacementCP3.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacementCP3[j].CardType == "Invertebrate")
//                    {
//                        GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacementCP3[j]); //if an animal, adds to the discard selection list
//                    }
//                }

//                //The discard and the deck list will be compared to see which card has the highest point value, which is what will be returned for the AI
//                Card cardHolder = GameManager.Instance.DeckSelectionList[0]; //sets the first variable for testing

//                for (int x = 1; x < GameManager.Instance.DeckSelectionList.Count; x++)//if the new card is greater than the original, change the variable
//                {
//                    if (GameManager.Instance.DeckSelectionList[x].PointValue > cardHolder.PointValue)
//                    {
//                        cardHolder = GameManager.Instance.DeckSelectionList[x];
//                        deckCard = true;
//                        deckCard = false;
//                    }
//                }

//                for (int x = 1; x < GameManager.Instance.DiscardSelectionList.Count; x++) //if there is a card in the discard pile with greater value, it will replace the card holder
//                {
//                    if (GameManager.Instance.DiscardSelectionList[x].PointValue > cardHolder.PointValue)
//                    {
//                        cardHolder = GameManager.Instance.DiscardSelectionList[x];
//                        discardCard = true;
//                        deckCard = false;
//                    }
//                }

//                //determine which pile the cardHolder came from and where to get rid of the card in the AI playing field
//                if (deckCard == true)
//                {
//                    cardParent = GameManager.Instance.pickCardHolder;

//                    holder.cardNameHolder = cardHolder.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr); //sets image to the card

//                    GameManager.Instance.changeComputerOneScore(cardHolder.PointValue); //changes the players score

//                    GameManager.Instance.InvertebratePlacementCP3.Add(cardHolder); //adds the selected card to the animal placement list

//                    for (int i = 0; i < deck.Cards.Count; i++) //goes through the deck, finds the card, then removes it from the deck list
//                    {
//                        if (deck.Cards[i].CardName == cardHolder.CardName)
//                        {
//                            deck.Cards.Remove(cardHolder); //removes the card
//                            break; //just breaks the for loop
//                        }
//                    }
//                }
//                else if (discardCard == true)
//                {
//                    cardParent = GameManager.Instance.pickCardHolder;

//                    holder.cardNameHolder = cardHolder.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr); //sets image to the card

//                    GameManager.Instance.changeComputerOneScore(cardHolder.PointValue); //changes the players score

//                    GameManager.Instance.InvertebratePlacementCP3.Add(cardHolder); //adds the selected card to the animal placement list

//                    for (int i = 0; i < GameManager.Instance.DiscardPlacementCP3.Count; i++) //goes through the discard pile, finds the card, then removes it from the deck list
//                    {
//                        if (GameManager.Instance.DiscardPlacementCP3[i].CardName == cardHolder.CardName)
//                        {
//                            GameManager.Instance.DiscardPlacementCP3.Remove(cardHolder); //removes the card
//                            break; //just breaks the for loop
//                        }
//                    }
//                }
//            }
//        }

//        //clears the lists so that other actions can use them
//        GameManager.Instance.DeckSelectionList.Clear();
//        GameManager.Instance.DiscardSelectionList.Clear();
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
//        GameManager.Instance.pickCardHolder = GameObject.Find("Computer Three Board/Plant Card Placement").transform; //sets parent
//        bool deckCard = false; //these two bools will determine where the card came from
//        bool discardCard = false;

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.computerThreeDeck) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].PlantType == "Canopy" || deck.Cards[i].PlantType == "Understory") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list
//                    }
//                }

//                for (int j = 0; j < GameManager.Instance.DiscardPlacementCP3.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacementCP3[j].PlantType == "Canopy" || GameManager.Instance.DiscardPlacementCP3[j].PlantType == "Understory")
//                    {
//                        GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacement[j]); //if an animal, adds to the discard selection list
//                    }
//                }

//                //The discard and the deck list will be compared to see which card has the highest point value, which is what will be returned for the AI
//                Card cardHolder = GameManager.Instance.DeckSelectionList[0]; //sets the first variable for testing

//                for (int x = 1; x < GameManager.Instance.DeckSelectionList.Count; x++)//if the new card is greater than the original, change the variable
//                {
//                    if (GameManager.Instance.DeckSelectionList[x].PointValue > cardHolder.PointValue)
//                    {
//                        cardHolder = GameManager.Instance.DeckSelectionList[x];
//                        deckCard = true;
//                        deckCard = false;
//                    }
//                }

//                for (int x = 1; x < GameManager.Instance.DiscardSelectionList.Count; x++) //if there is a card in the discard pile with greater value, it will replace the card holder
//                {
//                    if (GameManager.Instance.DiscardSelectionList[x].PointValue > cardHolder.PointValue)
//                    {
//                        cardHolder = GameManager.Instance.DiscardSelectionList[x];
//                        discardCard = true;
//                        deckCard = false;
//                    }
//                }

//                //determine which pile the cardHolder came from and where to get rid of the card in the AI playing field
//                if (deckCard == true)
//                {
//                    cardParent = GameManager.Instance.pickCardHolder;

//                    holder.cardNameHolder = cardHolder.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr); //sets image to the card

//                    GameManager.Instance.changeComputerOneScore(cardHolder.PointValue); //changes the players score

//                    GameManager.Instance.PlantPlacementCP3.Add(cardHolder); //adds the selected card to the animal placement list

//                    for (int i = 0; i < deck.Cards.Count; i++) //goes through the deck, finds the card, then removes it from the deck list
//                    {
//                        if (deck.Cards[i].CardName == cardHolder.CardName)
//                        {
//                            deck.Cards.Remove(cardHolder); //removes the card
//                            break; //just breaks the for loop
//                        }
//                    }
//                }
//                else if (discardCard == true)
//                {
//                    cardParent = GameManager.Instance.pickCardHolder;

//                    holder.cardNameHolder = cardHolder.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr); //sets image to the card

//                    GameManager.Instance.changeComputerOneScore(cardHolder.PointValue); //changes the players score

//                    GameManager.Instance.PlantPlacementCP3.Add(cardHolder); //adds the selected card to the animal placement list

//                    for (int i = 0; i < GameManager.Instance.DiscardPlacementCP3.Count; i++) //goes through the discard pile, finds the card, then removes it from the deck list
//                    {
//                        if (GameManager.Instance.DiscardPlacementCP3[i].CardName == cardHolder.CardName)
//                        {
//                            GameManager.Instance.DiscardPlacementCP3.Remove(cardHolder); //removes the card
//                            break; //just breaks the for loop
//                        }
//                    }
//                }
//            }
//        }

//        //clears the lists so that other actions can use them
//        GameManager.Instance.DeckSelectionList.Clear();
//        GameManager.Instance.DiscardSelectionList.Clear();
//    }

//    //Plant - Bigtooth Aspen
//    public void a032() //Bigtooth Aspen can be played directly from the deck or discard pile if your ecosystem is affected by forest fire
//    {
//        //dont know description is cut off
//    }

//    //Plant - Eastern White Pine
//    public void a033() //When Eastern White Pine is played, an herbivore can be played directly from the deck or discard pile 
//    {
//        GameManager.Instance.pickCardHolder = GameObject.Find("Computer Three Board/Animal Card Placement").transform; //sets parent
//        bool deckCard = false; //these two bools will determine where the card came from
//        bool discardCard = false;

//        foreach (Deck deck in GameManager.Instance.Decks) //gets the decks of the players
//        {
//            if (deck.DeckId == GameManager.Instance.computerThreeDeck) //checks to make sure that the players deck is the one that is being used
//            {
//                for (int i = 0; i < deck.Cards.Count; i++) //to go through each card in the deck
//                {
//                    if (deck.Cards[i].AnimalDiet == "Herbivore") //if the card type is an animal, it should execute and display the card in selection canvas
//                    {
//                        GameManager.Instance.DeckSelectionList.Add(deck.Cards[i]); //adds to the deck list
//                    }
//                }

//                for (int j = 0; j < GameManager.Instance.DiscardPlacementCP3.Count; j++) //this will bes used to check the discard pile and see if there are any animals in it
//                {
//                    if (GameManager.Instance.DiscardPlacementCP3[j].AnimalDiet == "Herbivore")
//                    {
//                        GameManager.Instance.DiscardSelectionList.Add(GameManager.Instance.DiscardPlacement[j]); //if an animal, adds to the discard selection list
//                    }
//                }

//                //The discard and the deck list will be compared to see which card has the highest point value, which is what will be returned for the AI
//                Card cardHolder = GameManager.Instance.DeckSelectionList[0]; //sets the first variable for testing

//                for (int x = 1; x < GameManager.Instance.DeckSelectionList.Count; x++)//if the new card is greater than the original, change the variable
//                {
//                    if (GameManager.Instance.DeckSelectionList[x].PointValue > cardHolder.PointValue)
//                    {
//                        cardHolder = GameManager.Instance.DeckSelectionList[x];
//                        deckCard = true;
//                        deckCard = false;
//                    }
//                }

//                for (int x = 1; x < GameManager.Instance.DiscardSelectionList.Count; x++) //if there is a card in the discard pile with greater value, it will replace the card holder
//                {
//                    if (GameManager.Instance.DiscardSelectionList[x].PointValue > cardHolder.PointValue)
//                    {
//                        cardHolder = GameManager.Instance.DiscardSelectionList[x];
//                        discardCard = true;
//                        deckCard = false;
//                    }
//                }

//                //determine which pile the cardHolder came from and where to get rid of the card in the AI playing field
//                if (deckCard == true)
//                {
//                    cardParent = GameManager.Instance.pickCardHolder;

//                    holder.cardNameHolder = cardHolder.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr); //sets image to the card

//                    GameManager.Instance.changeComputerOneScore(cardHolder.PointValue); //changes the players score

//                    GameManager.Instance.AnimalPlacementCP3.Add(cardHolder); //adds the selected card to the animal placement list

//                    for (int i = 0; i < deck.Cards.Count; i++) //goes through the deck, finds the card, then removes it from the deck list
//                    {
//                        if (deck.Cards[i].CardName == cardHolder.CardName)
//                        {
//                            deck.Cards.Remove(cardHolder); //removes the card
//                            break; //just breaks the for loop
//                        }
//                    }
//                }
//                else if (discardCard == true)
//                {
//                    cardParent = GameManager.Instance.pickCardHolder;

//                    holder.cardNameHolder = cardHolder.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr); //sets image to the card

//                    GameManager.Instance.changeComputerOneScore(cardHolder.PointValue); //changes the players score

//                    GameManager.Instance.AnimalPlacementCP3.Add(cardHolder); //adds the selected card to the animal placement list

//                    for (int i = 0; i < GameManager.Instance.DiscardPlacementCP3.Count; i++) //goes through the discard pile, finds the card, then removes it from the deck list
//                    {
//                        if (GameManager.Instance.DiscardPlacementCP3[i].CardName == cardHolder.CardName)
//                        {
//                            GameManager.Instance.DiscardPlacementCP3.Remove(cardHolder); //removes the card
//                            break; //just breaks the for loop
//                        }
//                    }
//                }
//            }
//        }

//        //clears the lists so that other actions can use them
//        GameManager.Instance.DeckSelectionList.Clear();
//        GameManager.Instance.DiscardSelectionList.Clear();
//    }

//    //Plant - White Birch
//    public void a034() //White Birch can be played directly from the deck or discard pile if your ecosystem is affected by Forest fire
//    {
//        //dont know description os cut off
//    }

//    //Special Regions - Farmers Cove
//    public void a035() // Farmer’s Cove provides: 1 Grassland region and 1 Running Water region.
//    {
//        GameManager.Instance.cp3GrasslandsCount++;
//        GameManager.Instance.cp3RunningWaterCount++;
//    }

//    //Special Region - The Strohmstead
//    public void a036() //The Strohmstead provides: 1 Forest region, 1 Grasslands region, 1 Standing Water region, and 1 Running water region
//    {
//        GameManager.Instance.cp3ForestCount++;
//        GameManager.Instance.cp3GrasslandsCount++;
//        GameManager.Instance.cp3StandingWaterCount++;
//        GameManager.Instance.cp3RunningWaterCount++;
//    }

//    //Special Region - Hunters Ridge
//    public void a037() //Hunter’s Ridge provides: 1 Forest region and 1 Grassland region.
//    {
//        GameManager.Instance.cp3ForestCount++;
//        GameManager.Instance.cp3GrasslandsCount++;
//    }

//    //Animal - Black Rat Snake - Invasive animal species???
//    public void a038() //If two Animals from the Order: Rodentia are in play, Black Rat Snake can be placed directly into play from the deck or the discard pile if its requirements are met
//    {
//        //??????????????????????
//    }

//    //Animal - Domesticated Cat
//    public void a039() //If no humans are in play within your ecosystem, Domesticated Cat will move to the player on the right.  Repeat this action until it finds an ecosystem with a human.  if no humans are in play, discard domesticated cat
//    {
//        //???????????????????????
//    }

//    //Animal - Domesticated Chicken
//    public void a040() //Domesticated Chicken cannot migrate and is human-dependant. Discard if no humans are in play within your ecosystem
//    {
//        //????????????????????????????????????????????/
//    }

//    //Animal - Domesticated Dog
//    public void a041() //Domesticated Dog will remain in play for three additional rounds without a human. If no humans are in play at the end of the third round, discard domdesticated dog.
//    {
//        //????????????????????????????????????????????????????????????????????????
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
//        //description not finished 
//    }

//    //Plant - Orange Hawkweed
//    public void a045() //The round after Orange Hawkweed is played, a fly from the Genus: Musca can be played directly from the deck or discard pile
//    {
//        //description not finished but im pretty sure i know whats going one
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

//    //Microbe - Spirulina Algae
//    public void a048() //Spirulina Algae also counts as a Groundcover Plant.
//    {
//        for (int i = 0; i < GameManager.Instance.MicrobePlacementCP3.Count; i++) //goes through the microbe placement list
//        {
//            if (GameManager.Instance.MicrobePlacementCP3[i].CardName == "Microbe-Spirulina-Algae") //if the correct card is here, sets the plant type to groundcover
//                GameManager.Instance.MicrobePlacementCP3[i].PlantType = "Groundcover";
//        }
//    }

//    //Plant - White Birch
//    public void a049() //White Birch can be played directly from the deck or discard pile if your ecosystem is affected by Forest fire
//    {
//        //?????????????????????
//    }

//    //Special Region - Animal Sanctuary
//    public void a050() //Animal Sanctuary can support any 1 Animal species, regardless of its requirements.
//    {
//        //does this mean you can pt down any card or what im not really sure
//    }

//    //Animal - Barn Owl
//    public void a051() //If two animals from the class mammalia are in play, Barn Owl can be played directly from the deck or discard pile at the beginning of your next turn
//    {

//    }

}