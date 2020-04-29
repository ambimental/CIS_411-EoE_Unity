/*
 *  @class      Computer.cs
 *  @purpose    this inherits the player calss and is used to carry out the computer AI
 *  
 *  @author     CIS411
 *  @date       2020/04/14
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Computer : Player
{
   //this is to pass what ever version of computer is being used into methods
    private Computer currentPlayer;

    //these will hold the values to create an object from the script for Requirements
    private GameObject reqGO;
    private Requirements req;
    //will help determine if the card should be placed or not
    private bool requirementsWork;


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
        //info specific to computers
        CurrentPlayer = this;
        RequirementsWork = false;
    }

    //starts the turn of the computer initially dealing 5 cards
    public override void StartTurn()
    {
        //execute parent method
        base.StartTurn();
        //if it is the first round then deal 5 cards automatically
        if (Round == 1) //only happens in the first round
        {
            Draw(5);
        }
        //after the 5 cards aredealt, the procedexd with computer AI alogorithm
        StartCoroutine(ComputerPerforms()); //goes through the function needed for the AI
        //ComputerPerforms();
    }

        /*
    *  @name       Draw(int pAmount) extends from parent
    *  @purpose    gets the card from the deck and calls generate card object and 
    */
    public override void Draw(int pAmount)
    {
        //gets parent frunction
        base.Draw(pAmount);
        //checking to make sure there are cards left in the deck
        if (Deck.Cards.Count != 0)
        {
            //determins how many cards to draw
            for (int i = 0; i < pAmount; i++)
            {
                //retrieving the object created in the form of the "instance" earlier
                Holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>();
                CardParent = GameObject.Find(HandGameObject).transform;
                //calling  the object's CardDrawRandomizer function, which selects a random card from the deck
                Holder.CardDrawRandomizer(CurrentPlayer);
                //changes the sprite so the player cant see the cards in the computers hand
                Holder.CardNameHolder = "back_of_card";
                GenerateCardObject();
                Holder.setSprite(Sr); //generating the card object to be placed into the panel
            }
        }
        else
        {
            //retrieving the object created in the form of the "instance" earlier
            Holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>();
            //sets the parent
            CardParent = GameObject.Find(HandGameObject).transform;
            //calling the object's CardDrawRandomizer function, which selects a random card from the deck
            Holder.CardDrawRandomizer(CurrentPlayer);
            //changes the sprite so the player cant see the cards in the computers hand
            Holder.CardNameHolder = "back_of_card";
            //calling this script's generateCardObject function,  which creates an object to represent the card
            GenerateCardObject();
            //calling the script object's setSprite function, which passes in the SpriteRenderer, and sets it's sprite to the corresponding card chosen in CardDrawRandomizer
            Holder.setSprite(Sr);
        }
    }

    // Update is called once per frame
    void Update()
        {

        }

    /*
     *  @name       ThreeCardExecute() extends parent method
     *  @purpose    used once per game per player and will not be able to be used again once used
     */
    public override void ThreeCardExecute()
    {
        base.ThreeCardExecute();
        Draw(3);
        ThreeCardBurstAvailable = false;
    }

    //where the card things will take place
    IEnumerator ComputerPerforms()
    //public void ComputerPerforms()
    {
        //this instantiates an game object of the class to use as an object and access methods
        //creates a gameobjects
        ReqGO = new GameObject("Req");
        //assigns the script to the game object
        ReqGO.AddComponent<Requirements>();
        //assigns the game object to the script withe the game object
        Req = GameObject.Find("Req").GetComponent<Requirements>();

        //this determinines how many cards the computer draws
        DrawAmount();
        //draws the appropriate amount of cards
        Draw(DrawCount);

        //this is where the requirements will be checked
        for (int z = Hand.Count - 1; z > -1; z--) //done this way to avoid exception
        {
            //creates time using the coroutine
            yield return new WaitForSeconds(5);

            //if the current card has requirements associated with it
            if (Hand[z].ReqID.Count != 0)
            {
                //call the function in requirements to check and pass in the current card and the current instance of the player
                if (Req.RequirementCheck(Hand[z], CurrentPlayer))
                {RequirementsWork = true;}
                else 
                {RequirementsWork = false;}
            }
            //if there are no requirements then the card can automatically be played, usually this is the case with region cards
            else
            {RequirementsWork = true; }

            //if the requirement works then the card is placed in the proper area and move to the correct list
            if (RequirementsWork == true)
            {
                if (Hand[z].CardType == "Region") //puts the card into the region placement
                {
                    //checks the region type and changes the variable accordingly
                    if (Hand[z].CardName.Contains("Arid"))
                        AridCount++;
                    else if (Hand[z].CardName.Contains("Forest"))
                        ForestCount++;
                    else if (Hand[z].CardName.Contains("Grasslands"))
                        GrasslandsCount++;
                    else if (Hand[z].CardName.Contains("Running-Water"))
                        RunningWaterCount++;
                    else if (Hand[z].CardName.Contains("Salt-Water"))
                        SaltWaterCount++;
                    else if (Hand[z].CardName.Contains("Standing-Water"))
                        StandingWaterCount++;
                    else if (Hand[z].CardName.Contains("Sub-Zero"))
                        SubZeroCount++;

                    //calls the method to asssigning the correct sprite and update score and passes in z so it knows which card to work with
                    MoveCard(z, RegionGameObject, RegionPlacement);
                }
                else if (Hand[z].CardType == "Condition") //puts the card into the condition card
                {
                    //calls the method to asssigning the correct sprite and update score and passes in z so it knows which card to work with
                    MoveCard(z, ConditionGameObject, ConditionPlacement);
                }
                else if (Hand[z].CardType == "Plant") //puts the card into the plant type
                {
                    //calls the method to asssigning the correct sprite and update score and passes in z so it knows which card to work with
                    MoveCard(z, PlantGameObject, PlantPlacement);
                }
                else if (Hand[z].CardType == "Invertebrate") //puts the card into the invertebrate pile
                {
                    //calls the method to asssigning the correct sprite and update score and passes in z so it knows which card to work with
                    MoveCard(z, InvertebrateGameObject, InvertebratePlacement);
                }
                else if (Hand[z].CardType == "Animal") //puts the cards into the animal pile
                {
                    //calls the method to asssigning the correct sprite and update score and passes in z so it knows which card to work with
                    MoveCard(z, AnimalGameObject, AnimalPlacement);
                }
                else if (Hand[z].CardType == "Special Region") //puts the card into the special region pile
                {
                    //calls the method to asssigning the correct sprite and update score and passes in z so it knows which card to work with
                    MoveCard(z, SpecialRegionGameObject, SpecialRegionPlacement);
                }
                else if (Hand[z].CardType == "Multi-Player") //puts the card into the multiplayer pile
                {
                    //calls the method to asssigning the correct sprite and update score and passes in z so it knows which card to work with
                    MoveCard(z, MultiplayerGameObject, MultiPlacement);
                }
                else if (Hand[z].CardType == "Microbe") //puts the card into the microbe pile
                {
                    //calls the method to asssigning the correct sprite and update score and passes in z so it knows which card to work with
                    MoveCard(z, MicrobeGameObject, MicrobePlacement);
                }

                else if (Hand[z].CardType == "Fungi") //puts the card into the fungi pile
                {
                    //calls the method to asssigning the correct sprite and update score and passes in z so it knows which card to work with
                    MoveCard(z, FungiGameObject, FungiPlacement);
                }
            }
        }

        if (Hand.Count != 0) //if there is a card left in the hand, it will discad the firsts one
        {
            //calls the method to asssigning the correct sprite and update score and passes in z so it knows which card to work with
            MoveCard(0, DiscardGameObject, DiscardPlacement);

            yield return new WaitForSeconds(2);
        }
        else //if there are no cards left in the hand, will just automatically go to the next player
        {
            yield return new WaitForSeconds(2);
        }

        //calls the game manager instane to change the players turn and passes imn this instances name so we know which player goes nect
        GameManager.Instance.NextPlayer(PlayerName);
    }

    /*
     *  @name       MoveCard() 
     *  @purpose   Moves the card from the hand to the correct placement and takes in the index from the loop so it knows whch card to use
     *  also it updates the score
     */
    public void MoveCard(int pZ, string pParent, List<Card> pListPlacement)
    {
        //assigns where the game object with go to a object
        CardParent = GameObject.Find(pParent).transform;
        //sets the name so the sprite can show the front of card
        Holder.CardNameHolder = Hand[pZ].CardName;
        //creates a new card object
        GenerateCardObject();
        //creates the new sprite with the correct image
        Holder.setSprite(Sr);
        //tells the current game object at play where to go to
        //CardObject.transform.SetParent(CardParent);
        //resizes the card so it fits nicely on the placements
        CardObject.transform.localScale = new Vector3(1.0f, 1.0f, 0);
        
        //updates the score based off the value of the card played
        ChangeScore(Hand[pZ].PointValue);
        //adds the card from the hand to the correct list
        pListPlacement.Add(Hand[pZ]);
        //removes the card just played from the hand
        Hand.Remove(Hand[pZ]);

        //resets the card parent that way if anything funky happens it will return to the hand
        //but since its a computer nothing like that would probably happen casue there is no dragability for the computer
        CardParent = GameObject.Find(HandGameObject).transform;

        //to keep from a null excpetion error
        if (Hand.Count > 0)
            Destroy(CardParent.GetChild(0).gameObject);
    }

    //accessors and mutators
    public bool RequirementsWork { get => requirementsWork; set => requirementsWork = value; }
    public Computer CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
    public GameObject ReqGO { get => reqGO; set => reqGO = value; }
    public Requirements Req { get => req; set => req = value; }
}

