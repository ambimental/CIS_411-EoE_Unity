﻿/*
 *  @class      Human.cs
 *  @purpose    mextend from player and provides everything needed for the human player inlcuding creating cards
 *  
 *  @author     CIS 411
 *  @date       2020/04/07
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Human : Player
{
    //used to pass in current object to differnt classes
    private Human currentPlayer;
    //this is for human
    private bool canDraw;
    //i forget what this is used for- so find out
    private bool cardDiscarded;
    //used to change the text on the human layerboard screen
    private Text drawText;

    //to make the three card burst butto visibile ane not visible
    private Button threeCardBurstButton;
    //will be used to access the end for the button itself
    private Button endTurnBtn;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}

    /*
 *  @name       Initialize Objects() extend from parent class and ads additon info specific to human
 *  @purpose    acts as constuctor since unitiy doesnt let us create objects of classes normally. Is call when created in Game Manager class
 */
    public void InitializeObjects(string pScoreGameObject, string pRoundGameObject, string pHandGameObject, string pRegionGameObject, string pConditionGameObject,
        string pPlantGameObject, string pInvertebrateGameObject, string pAnimalGameObject, string pSpecialRegionGameObject, string pMultiplayerGameObject,
        string pMicrobeGameObject, string pFungiGameObject, string pDiscardGameObject, string pHumanGameObject, string pDeckColorGameObject, string pDeckTextGameObject,
        string pHumanScoreGameObject, string pCP1ScoreGameObject, string pCP2ScoreGameObject, string pCP3ScoreGameObject)
    {
        //gets base parent class info
        base.InitializeObjects(pScoreGameObject, pRoundGameObject, pHandGameObject, pRegionGameObject, pConditionGameObject,
        pPlantGameObject, pInvertebrateGameObject, pAnimalGameObject, pSpecialRegionGameObject, pMultiplayerGameObject,
        pMicrobeGameObject, pFungiGameObject, pDiscardGameObject, pHumanGameObject, pDeckColorGameObject, pDeckTextGameObject,
        pHumanScoreGameObject, pCP1ScoreGameObject, pCP2ScoreGameObject, pCP3ScoreGameObject);
        //info specific to human
        CurrentPlayer = this;
        CanDraw = true;
        CardDiscarded = false;
    }

    /*
    *  @name       StartTurn() extends from parent
    *  @purpose    deals the player 5 cards if its round one then starts the players turn
    */
    public void StartTurn()
    {
        //execute parent method
        base.StartTurn();
        CreateButtonObjects();
        //allowing colliders to work
        Physics.queriesHitTriggers = true;
        drawText = GameObject.Find("DrawText").GetComponent<Text>(); //gets the text component so it can be changed
        //if it is the first round then deal 5 cards automatically
        if (Round == 1) //only happens in the first round
        {
            Draw(5);
        }

            //gets the right amount of cards to draw based off regions its a parent function
            DrawAmount();
            //draws the apropriate amount
            Draw(DrawCount);
            //makes the human player unable to draw again
            CanDraw = false;
    }
    /*
 *  @name       GenerateCardObjects() extend from parent class and ads additon info specific to human
 *  @purpose    this gets the card from the deck and assigns it to a game object that will be the card you will see omn the screen
 */
    private void GenerateCardObject()
    {
        //gets the parent class method stuff
        base.GenerateCardObject();
        //adding the Draggable script to the card object, which allows it to be dragged and placed appropriately
        CardObject.AddComponent<Draggable>();
        CardObject.AddComponent<DoubleClickDescription>(); //makes the cards able to be clicked on
    }

    //i added this script to the Player Draw Deck Placement so when it is clicked this is carried out// im still working on it
    void OnMouseDown()
    {
        //StartTurn();
        //Debug.Log("The Deck Draw Button Was Called");
    }

    /*
    *  @name       Draw(int pAmount) extends from parent
    *  @purpose    gets the card from the deck and calls generate card object and 
    */
    public void Draw(int pAmount)
    {
        //gets parent info
        base.Draw(pAmount);
        //makes sure you can opnly draw once basically
        if (CanDraw == true)
        {
            //checking to make sure there are cards left in the deck
            if (Deck.Cards.Count != 0)
            {
                //determins how many cards to draw
                for (int i = 0; i < pAmount; i++)
                {
                    //retrieving the object created in the form of the "instance" earlier
                    Holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>();
                    //sets the parent
                    CardParent = GameObject.Find(HandGameObject).transform;
                    //calling the object's CardDrawRandomizer function, which selects a random card from the deck
                    Holder.CardDrawRandomizer(CurrentPlayer);
                    //calling this script's generateCardObject function,  which creates an object to represent the card
                    GenerateCardObject();
                    //calling the script object's setSprite function, which passes in the SpriteRenderer, and sets it's sprite to the corresponding card chosen in CardDrawRandomizer
                    Holder.setSprite(Sr);
                }
            }
            else
            {
                //calling this script's changeDeck function, which replaces the deck with an out of cards image
                ChangeDeck();
            }
        }
    }

        /*
     *  @name       changeDeck()
     *  @purpose    when the human player is out of sards it replaces the image with an out of cards image
     */
    public void ChangeDeck()
    {
        //creating a new SpriteRenderer for the deck
        SpriteRenderer swap = GameObject.Find("Deck Draw Placement").AddComponent<SpriteRenderer>();
        //loading the out of cards texture
        TexSprite = Resources.Load<Texture2D>("Sprites/Out-Of-Cards");
        //creating a sprite out of said texture
        TempSprite = Sprite.Create(TexSprite, new Rect(0, 0, TexSprite.width, TexSprite.height), new Vector2(0.5f, 0.5f), 1.6666f);
        //setting the SpriteRenderer's sprite to the newly created Sprite
        swap.sprite = TempSprite;
        //setting the SpriteRenderer's sorting level so that it appears above the deck, but  below cards
        swap.sortingOrder = 9;
        //setting the SpriteRenderer's sorting level to Default, so that it is in line with other objects
        swap.sortingLayerName = "Default";
    }

    /*
     *  @name       ThreeCardExecute() extends parent method
     *  @purpose    used once per game per player and will not be able to be used again once used
     */
    public void ThreeCardExecute()
    {
        base.ThreeCardExecute();
        //makes it so player can draw the cards
        CanDraw = true;
        Draw(3);
        ThreeCardBurstAvailable = false;
        //Disables the button 
        ThreeCardBurstButton.gameObject.SetActive(false);
        ThreeCardBurstButton.interactable = false;
    }

    /*The code below is for buttso associated only woith the human, these get rid of the need to have separate classes for each button*/
        /*
     *  @name       CreateButtonObjects()
     *  @purpose    creates the buttons and adds listeners for when they are clicked
     */
    public void CreateButtonObjects()
    {
        //finds the ThreeCardBurstButton in the scene
        ThreeCardBurstButton = GameObject.Find("3CardBurst").GetComponent<Button>();
        //when the button is clicked, this is what occurs
        ThreeCardBurstButton.onClick.AddListener(ThreeCardExecute);

        //finds the objects in the scene
        EndTurnBtn = GameObject.Find("EndTurnButton").GetComponent<Button>();
        //disable end turn button to start
        EndTurnBtn.interactable = false;
        //when the button is clicked, this is what occurs
        EndTurnBtn.onClick.AddListener(EndTurn);
    }

    /*
     *  @name       EndTurn()
     *  @purpose    is called on end turn button click disables the button and starts the computer loop
     */
    public void EndTurn()
    {
        EndTurnEnable("NotInteractable");
        GameManager.Instance.StartComputerLoop();
    }

    /*
     *  @name       EndTurnEnable()
     *  @purpose    this is used by the draggable script and determines wether or not the end turn button is enabled
     */
    public void EndTurnEnable(string pEndTurn)
    {
        //EndTurnBtn = GameObject.Find("EndTurnButton").GetComponent<Button>();
        if (pEndTurn == "Interactable")
        {
            EndTurnBtn.interactable = true;
        }

        if (pEndTurn == "NotInteractable")
        {
            EndTurnBtn.interactable = false;
        }

        if (pEndTurn == "Active")
        {
            EndTurnBtn.gameObject.SetActive(true);
            EndTurnBtn.interactable = true;
        }

        if (pEndTurn == "NotActive")
        {
            EndTurnBtn.gameObject.SetActive(false);
        }

    }


    //accessors and mutators
    public bool CanDraw { get => canDraw; set => canDraw = value; }
    public bool CardDiscarded { get => cardDiscarded; set => cardDiscarded = value; }
    public Text DrawText { get => drawText; set => drawText = value; }
    public Human CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
    public Button ThreeCardBurstButton { get => threeCardBurstButton; set => threeCardBurstButton = value; }
    public Button EndTurnBtn { get => endTurnBtn; set => endTurnBtn = value; }
}

