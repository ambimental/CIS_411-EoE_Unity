﻿/*
 *  @class      GameManager.cs
 *  @purpose    Manages turn-by-turn game loop and game-critical functions
 *  
 *  @author     CIS411
 *  @date       2020/04/10
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //  ensures GameManager can be used in all scripts (interact with other game objects)
    private static GameManager _instance = null;

    /*
     * @name    Instance
     * @purpose Creates instance of GameManager if instance does not currently exist, stores created instance in public static object
     * 
     * @return  Instance of GameManager to public static GameManager object _instance
     */
    public static GameManager Instance
    {
        get
        {
            //  check if static GameManager object is null
            if(_instance == null)
            {
                //  if static object is null, create and add new GameManager object
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            //  return newly created GameManager object in static object _instance
            return _instance;
        }
    }

    //  stores player scores
    public int playerScore;
    public int computerOneScore;
    public int computerTwoScore;
    public int computerThreeScore;

    //  stores values for round text information
    //i dont think we will need these becasue we wil update this within the players calss
    public Text playerRound;
    public Text oneRound;
    public Text twoRound;
    public Text threeRound;

    //  stores values for player score information
    //we will need these becasue we need to update each UIscore element, not just the one specific to the player 
    //we will need more of these
    public Text pScore;
    public Text oneScore;
    public Text twoScore;
    public Text threeScore;

    //this is currently what populated our cards
    public phpImport importer;


    //these are all here until we figure out the requirements part
    public List<Card> Hand = new List<Card>();
    public List<Card> RegionPlacement = new List<Card>();
    public List<Card> SpecialRegionPlacement = new List<Card>();
    public List<Card> PlantPlacement = new List<Card>();
    public List<Card> AnimalPlacement = new List<Card>();
    public List<Card> InvertebratePlacement = new List<Card>();
    public List<Card> MicrobePlacement = new List<Card>();
    public List<Card> HumanPlacement = new List<Card>();
    public List<Card> MultiPlacement = new List<Card>();
    public List<Card> FungiPlacement = new List<Card>();
    public List<Card> ConditionPlacement = new List<Card>();
    public List<Card> DiscardPlacement = new List<Card>();
    public List<Deck> cp1Deck = new List<Deck>();
    public List<Card> HandCP1 = new List<Card>();
    public List<Card> RegionPlacementCP1 = new List<Card>();
    public List<Card> SpecialRegionPlacementCP1 = new List<Card>();
    public List<Card> PlantPlacementCP1 = new List<Card>();
    public List<Card> AnimalPlacementCP1 = new List<Card>();
    public List<Card> InvertebratePlacementCP1 = new List<Card>();
    public List<Card> MicrobePlacementCP1 = new List<Card>();
    public List<Card> HumanPlacementCP1 = new List<Card>();
    public List<Card> MultiPlacementCP1 = new List<Card>();
    public List<Card> FungiPlacementCP1 = new List<Card>();
    public List<Card> ConditionPlacementCP1 = new List<Card>();
    public List<Card> DiscardPlacementCP1 = new List<Card>();
    public List<Deck> cp2Deck = new List<Deck>();
    public List<Card> HandCP2 = new List<Card>();
    public List<Card> RegionPlacementCP2 = new List<Card>();
    public List<Card> SpecialRegionPlacementCP2 = new List<Card>();
    public List<Card> PlantPlacementCP2 = new List<Card>();
    public List<Card> AnimalPlacementCP2 = new List<Card>();
    public List<Card> InvertebratePlacementCP2 = new List<Card>();
    public List<Card> MicrobePlacementCP2 = new List<Card>();
    public List<Card> HumanPlacementCP2 = new List<Card>();
    public List<Card> MultiPlacementCP2 = new List<Card>();
    public List<Card> FungiPlacementCP2 = new List<Card>();
    public List<Card> ConditionPlacementCP2 = new List<Card>();
    public List<Card> DiscardPlacementCP2 = new List<Card>();
    public List<Deck> cp3Deck = new List<Deck>();
    public List<Card> HandCP3 = new List<Card>();
    public List<Card> RegionPlacementCP3 = new List<Card>();
    public List<Card> SpecialRegionPlacementCP3 = new List<Card>();
    public List<Card> PlantPlacementCP3 = new List<Card>();
    public List<Card> AnimalPlacementCP3 = new List<Card>();
    public List<Card> InvertebratePlacementCP3 = new List<Card>();
    public List<Card> MicrobePlacementCP3 = new List<Card>();
    public List<Card> HumanPlacementCP3 = new List<Card>();
    public List<Card> MultiPlacementCP3 = new List<Card>();
    public List<Card> FungiPlacementCP3 = new List<Card>();
    public List<Card> ConditionPlacementCP3 = new List<Card>();
    public List<Card> DiscardPlacementCP3 = new List<Card>();
    public bool playerProtectedFromExtinction = false;
    public bool cp1ProtectedFromExtinction = false;
    public bool cp2ProtectedFromExtinction = false;
    public bool cp3ProtectedFromExtinction = false;
    public bool playerProtectedFromInvasiveAnimal = false;
    public bool cp1ProtectedFromInvasiveAnimal = false;
    public bool cp2ProtectedFromInvasiveAnimal = false;
    public bool cp3ProtectedFromInvasiveAnimal = false;
    public bool playerProtectedFromInvasivePlant = false;
    public bool cp1ProtectedFromInvasivePlant = false;
    public bool cp2ProtectedFromInvasivePlant = false;
    public bool cp3ProtectedFromInvasivePlant = false;
    public bool playerNoConditionRequirements = false;
    public bool cp1NoConditionRequirements = false;
    public bool cp2NoConditionRequirements = false;
    public bool cp3NoConditionRequirements = false;
    public bool playerProtectedFromBlight = false;
    public bool cp1ProtectedFromBlight = false;
    public bool cp2ProtectedFromBlight = false;
    public bool cp3ProtectedFromBlight = false;
    public bool playerPausedOneTurn = false;
    public bool cp1PausedOneTurn = false;
    public bool cp2PausedOneTurn = false;
    public bool cp3PausedOneTurn = false;
    public bool playerProtectedFromWeb = false;
    public bool cp1ProtectedFromWeb = false;
    public bool cp2ProtectedFromWeb = false;
    public bool cp3ProtectedFromWeb = false;
    public bool playerNoDiscard = false;
    public bool cp1NoDiscard = false;
    public bool cp2NoDiscard = false;
    public bool cp3NoDiscard = false;
    public bool playerDrawExtraCard = false;
    public bool cp1DrawExtraCard = false;
    public bool cp2DrawExtraCard = false;
    public bool cp3DrawExtraCard = false;
    public bool ecosystemsConnected = false;
    public bool playerTwentyPointNoDiscard = false;
    public bool cp1TwentyPointNoDiscard = false;
    public bool cp2TwentyPointNoDiscard = false;
    public bool cp3TwentyPointNoDiscard = false;
    public bool playerProtectedFromInvertebrate = false;
    public bool cp1ProtectedFromInvertebrate = false;
    public bool cp2ProtectedFromInvertebrate = false;
    public bool cp3ProtectedFromInvertebrate = false;
    public int playerAridCount = 0;
    public int playerForestCount = 0;
    public int playerGrasslandsCount = 0;
    public int playerRunningWaterCount = 0;
    public int playerSaltWaterCount = 0;
    public int playerStandingWaterCount = 0;
    public int playerSubZeroCount = 0;
    public int playerMountainRange = 0;
    public int playerTotalRegions = 0;
    public int cp1AridCount = 0; 
    public int cp1ForestCount = 0;
    public int cp1GrasslandsCount = 0;
    public int cp1RunningWaterCount = 0;
    public int cp1SaltWaterCount = 0;
    public int cp1StandingWaterCount = 0;
    public int cp1SubZeroCount = 0;
    public int cp1MountainRange = 0;
    public int cp1TotalRegions = 0;
    public int cp2AridCount = 0;
    public int cp2ForestCount = 0;
    public int cp2GrasslandsCount = 0;
    public int cp2RunningWaterCount = 0;
    public int cp2SaltWaterCount = 0;
    public int cp2StandingWaterCount = 0;
    public int cp2SubZeroCount = 0;
    public int cp2MountainRange = 0;
    public int cp2TotalRegions = 0;
    public int cp3AridCount = 0;
    public int cp3ForestCount = 0;
    public int cp3GrasslandsCount = 0;
    public int cp3RunningWaterCount = 0;
    public int cp3SaltWaterCount = 0;
    public int cp3StandingWaterCount = 0;
    public int cp3SubZeroCount = 0;
    public int cp3MountainRange = 0;
    public int cp3TotalRegions = 0;


    private bool firstRound;
    /*****************************************************************************/
    /*****************************************************************************/
    /*EVERYTHING BELPOW HERE REGAURDING OBJECTS AND VARIABLES WILL DEFINATELY BE 
     * STAYING IN THE GAME MANAGER CLASS, EVERYTHING ABOVE WILL PROBABLY BE DELETED
     */
    /*****************************************************************************/
    /*****************************************************************************/
    
        //  create list to hold Deck IDs
    public List<string> DeckIds = new List<string>();
    //  create list to hold individual decks until they are assigned to players
    public List<Deck> Decks = new List<Deck>();

    //  stores round number
    public int round;

    //  stores sorting layers used throughout different classes to display objects in front of everything
    public int sortingOrder = 10;

    //  determines win/loss status for human player
    public bool win;
    public bool lose;

    /*these are what are needed to create the player objects
     the GameObject is what is created the add a compenent to
     the Class object is what the game compentent is assigned to its just the way unity makes you do it*/
    private GameObject personGO;
    private Human person;
    private GameObject cP1GO;
    private Computer cP1;
    private GameObject cP2GO;
    private Computer cP2;
    private GameObject cP3GO;
    private Computer cP3;

    //this is to be able to hide and show the boards
    private GameObject hideShowGO;
    private HideShowBoards hideShow;

    /*
     *  @name       Awake()
     *  @purpose    
     */
    public void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(_instance);
    }

    /*
     *  @name       Start
     *  @purpose    initialize GameManager object 
     */
    void Start () {
        
        CreateDecks();

        //populates decks
        gameObject.AddComponent<phpImport>();

        //  sets initial round number
        round = 1;
        firstRound = true;

        //this is how we inialize objects
        //initializing Human Person Player
        PersonGO = new GameObject("Person");
        PersonGO.AddComponent<Human>();
        Person = GameObject.Find("Person").GetComponent<Human>();
        Person.InitializeObjects("PlayerScoreText", "PlayerRoundText", "Hand", "Region Card Placement",
            "Condition Card Placement", "Plant Card Placement", "Invertebrate Card Placement",
            "Animal Card Placement", "Special Region Placement", "Multiplayer Card Placement",
            "Microbe Card Placement", "Fungi Card Placement", "Discard Pile Placement", "Human Card Placement", "PlayerColor",
            "PlayerDeckText");

        //Initilizing CP1 Player
        CP1GO = new GameObject("CP1");
        CP1GO.AddComponent<Computer>();
        CP1 = GameObject.Find("CP1").GetComponent<Computer>();
        CP1.InitializeObjects("Computer One Board/ComputerOneScoreText", "Computer One Board/ComputerOneRoundText", "Computer One Board/CP1Hand", "Computer One Board/Region Card Placement",
            "Computer One Board/Condition Card Placement", "Computer One Board/Plant Card Placement", "Computer One Board/Invertebrate Card Placement", 
            "Computer One Board/Animal Card Placement", "Computer One Board/Special Region Placement", "Computer One Board/Multiplayer Card Placement", 
            "Computer One Board/Microbe Card Placement", "Computer One Board/Fungi Card Placement", "Computer One Board/Discard Pile Placement", "Computer One Board/Human Card Placement",
            "CP1Color","CP1DeckText");

        //Initilizing CP2 Player
        CP2GO = new GameObject("CP2");
        CP2GO.AddComponent<Computer>();
        CP2 = GameObject.Find("CP2").GetComponent<Computer>();
        CP2.InitializeObjects("Computer Two Board/ComputerTwoScoreText", "Computer Two Board/ComputerTwoRoundText", "Computer Two Board/CP2Hand", "Computer Two Board/Region Card Placement",
            "Computer Two Board/Condition Card Placement", "Computer Two Board/Plant Card Placement", "Computer Two Board/Invertebrate Card Placement",
            "Computer Two Board/Animal Card Placement", "Computer Two Board/Special Region Placement", "Computer Two Board/Multiplayer Card Placement",
            "Computer Two Board/Microbe Card Placement", "Computer Two Board/Fungi Card Placement", "Computer Two Board/Discard Pile Placement", "Computer Two Board/Human Card Placement",
            "CP2Color", "CP2DeckText");

        //Initilizing CP3 Player
        CP3GO = new GameObject("CP3");
        CP3GO.AddComponent<Computer>();
        CP3 = GameObject.Find("CP3").GetComponent<Computer>();
        CP3.InitializeObjects("Computer Three Board/ComputerThreeScoreText", "Computer Three Board/ComputerThreeRoundText", "Computer Three Board/CP3Hand", "Computer Three Board/Region Card Placement",
            "Computer Three Board/Condition Card Placement", "Computer Three Board/Plant Card Placement", "Computer Three Board/Invertebrate Card Placement",
            "Computer Three Board/Animal Card Placement", "Computer Three Board/Special Region Placement", "Computer Three Board/Multiplayer Card Placement",
            "Computer Three Board/Microbe Card Placement", "Computer Three Board/Fungi Card Placement", "Computer Three Board/Discard Pile Placement", "Computer Three Board/Human Card Placement",
            "CP3Color", "CP3DeckText");

        //hard codes deck for now
        Person.Deck = Decks[0];
        CP1.Deck = Decks[1];
        CP2.Deck = Decks[2];
        CP3.Deck = Decks[3];
    }

        /*
     *  @name       CreateDecks()
     *  @purpose    Hard code deck IDs to a list then creates a deck and adds it to deck list with an id associated with it
     */
    public void CreateDecks()
    {
        //  adds individual deck IDs to list
        DeckIds.Add("D001");
        DeckIds.Add("D002");
        DeckIds.Add("D003");
        DeckIds.Add("D004");

        //  for each deckID in list DeckIds
        foreach (string id in DeckIds)
        {
            //  create a new deck
            Deck deck = new Deck();
            //  set new deck ID to id in list
            deck.DeckId = id;
            //  add newly created deck to Deck list
            Decks.Add(deck);
        }

    }


    //this is kind of a temporary start function for the player that needs worked out but functions for now
    public void StuffForLater()
    {
        //i have the hide show here for now becasue at this point the playerboard scene has already been created
        //creates hide show boards object
        
        //this is temporary but its so we dont remake objects and get erros
        if (FirstRound == true)
        {
            HideShowGO = new GameObject("HideShow");
            HideShowGO.AddComponent<HideShowBoards>();
            HideShow = GameObject.Find("HideShow").GetComponent<HideShowBoards>();
        }

        Person.StartTurn();
        
        //Cursor.visible = false; //hides the mouse from the user
        //Cursor.lockState = CursorLockMode.Locked; //you cannot use the cursor
    }

    public void StartComputerLoop()
    {
        Cursor.visible = false; //hides the mouse from the user
        Cursor.lockState = CursorLockMode.Locked; //you cannot use the cursor     
        //CP1
        HideShow.ShowCP1();
        CP1.StartTurn();
        for (int i = 0; i < 100; i++) { }
        //CP2
        HideShow.ShowCP2();
        CP2.StartTurn();
        for (int i = 0; i < 100; i++) { }
        //CP3
        HideShow.ShowCP3();
        CP3.StartTurn();
        for (int i = 0; i < 100; i++) { }
        //Back to player
        Cursor.visible = true; //hides the mouse from the user
        Cursor.lockState = CursorLockMode.None; //you cannot use the cursor  
        HideShow.ShowPlayer();
        //CP2.Begin turn or whatever
        //some function that updates all scores to current canvas
        //ShowCP3()
        //CP# begin turn or whatever
        //some function that updates all scores to current canvas
        //ShowPlayer
        //increase round
        //if round 10 win lose
        //restart the game
    }


    /*
     *  @name       winOrLose
     *  @purpose    determines whether the human player has won or lost
     */
    public void winOrLose()
    {
        //  if human playerScore is less than computer player scores
        if (playerScore < computerOneScore || playerScore < computerTwoScore || playerScore < computerThreeScore)
        {
            //  set lose to true
            lose = true;
            //  set win to false
            win = false;

            //  load game-lose screen
            SceneManager.LoadScene("LoseScene");
        }
        else
        {
            //  set win to true
            win = true;
            //  set lose to false
            lose = false;

            //  load game-win screen
            SceneManager.LoadScene("WinScene");
        }

        //  resets round number
        round = 1;

        //  clear human and computer player hands
        Hand.Clear();
        HandCP1.Clear();
        HandCP2.Clear();
        HandCP3.Clear();
    }

    /*
     *  @name       restartGame()
     *  @purpose    on new game, destroy GameManager object and create a new one
     */
    public void restartGame()
    {
        //  destroy existing GameManager object
        Destroy(this.GetComponent<GameManager>());
        //  create new GameManager object
        this.gameObject.AddComponent<GameManager>();
    }
    
    /*
     *  @name       changeRound()
     *  @purpose    progress game across round numbers
     */
    public void UpdateRound()
    {

        //  check if round number is not 10
        if (round != 10)
        {
            //  increment round number
            round++;

            //  update round text
            playerRound = GameObject.Find("PlayerRoundText").GetComponent<Text>();
            playerRound.text = round.ToString();
        }
        //  if round number is 10
        else if (round == 10)
        {
            //  end game; see winOrLose()
            winOrLose();
        }
    }

    //accessors and mutators
    public GameObject PersonGO { get => personGO; set => personGO = value; }
    public Human Person { get => person; set => person = value; }
    public GameObject CP1GO { get => cP1GO; set => cP1GO = value; }
    public Computer CP1 { get => cP1; set => cP1 = value; }
    public GameObject CP2GO { get => cP2GO; set => cP2GO = value; }
    public Computer CP2 { get => cP2; set => cP2 = value; }
    public GameObject CP3GO { get => cP3GO; set => cP3GO = value; }
    public Computer CP3 { get => cP3; set => cP3 = value; }
    public GameObject HideShowGO { get => hideShowGO; set => hideShowGO = value; }
    public HideShowBoards HideShow { get => hideShow; set => hideShow = value; }
    public bool FirstRound { get => firstRound; set => firstRound = value; }
}

