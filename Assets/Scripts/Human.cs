/*
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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update(){}

    /*
 *  @name       Initialize Objects() extend from parent class and ads additon info specific to human
 *  @purpose    acts as constuctor since unitiy doesnt let us create objects of classes normally. Is call when created in Game Manager class
 */
    public override void InitializeObjects(string pScoreGameObject, string pRoundGameObject, string pHandGameObject, string pRegionGameObject, string pConditionGameObject,
        string pPlantGameObject, string pInvertebrateGameObject, string pAnimalGameObject, string pSpecialRegionGameObject, string pMultiplayerGameObject,
        string pMicrobeGameObject, string pFungiGameObject, string pDiscardGameObject, string pHumanGameObject, string pDeckColorGameObject, string pDeckTextGameObject,
        string pHumanScoreGameObject, string pCP1ScoreGameObject, string pCP2ScoreGameObject, string pCP3ScoreGameObject, string pPlayerName)
    {
        //gets base parent class info
        base.InitializeObjects(pScoreGameObject, pRoundGameObject, pHandGameObject, pRegionGameObject, pConditionGameObject,
        pPlantGameObject, pInvertebrateGameObject, pAnimalGameObject, pSpecialRegionGameObject, pMultiplayerGameObject,
        pMicrobeGameObject, pFungiGameObject, pDiscardGameObject, pHumanGameObject, pDeckColorGameObject, pDeckTextGameObject,
        pHumanScoreGameObject, pCP1ScoreGameObject, pCP2ScoreGameObject, pCP3ScoreGameObject, pPlayerName);
        //info specific to human
        CurrentPlayer = this;
        CanDraw = true;
        CardDiscarded = false;
    }

    /*
    *  @name       StartTurn() extends from parent
    *  @purpose    deals the player 5 cards if its round one then starts the players turn
    */
    public override void StartTurn()
    {
        //execute parent method
        base.StartTurn();
        //allowing colliders to work
        Physics.queriesHitTriggers = true;
        //after the round has changed the player needs to discard again
        CardDiscarded = false;
        //gets the text component so it can be changed
        DrawText = GameObject.Find("DrawText").GetComponent<Text>(); //gets the text component so it can be changed
        //if it is the first round then deal 5 cards automatically
        if (Round == 1 && CanDraw == true) //only happens in the first round
        {
            CreateButtonObjects();
            Draw(5);
        }
        DrawText.text = "Step 1: Play Card(s) \n Step 2: Discard to End Your Turn";
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
    public override void GenerateCardObject()
    {
        //gets the parent class method stuff
        base.GenerateCardObject();
        //adding the Draggable script to the card object, which allows it to be dragged and placed appropriately
        CardObject.AddComponent<Draggable>();
        CardObject.AddComponent<DoubleClickDescription>(); //makes the cards able to be clicked on
        CardObject.GetComponent<DoubleClickDescription>().CreatePlayer(CurrentPlayer);
    }

    /*
    *  @name       Draw(int pAmount) extends from parent
    *  @purpose    gets the card from the deck and calls generate card object and 
    */
    public override void Draw(int pAmount)
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
        SpriteRenderer swap = GameObject.Find("Deck Draw Button").AddComponent<SpriteRenderer>();
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
    public override void ThreeCardExecute()
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
    }

    //accessors and mutators
    public bool CanDraw { get => canDraw; set => canDraw = value; }
    public bool CardDiscarded { get => cardDiscarded; set => cardDiscarded = value; }
    public Text DrawText { get => drawText; set => drawText = value; }
    public Human CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
    public Button ThreeCardBurstButton { get => threeCardBurstButton; set => threeCardBurstButton = value; }
}

