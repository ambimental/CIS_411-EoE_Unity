//WILL BE USED TO KEEP TRACK OF ALL GLOABAL VARIABLES AND ASPECTS OF THE GAME

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static GameManager _instance = null; //makes sure it can be used in all other scripts

    public static GameManager Instance
    {
        get
        {
            //creates the game manager instance
            if(_instance == null) //if the object is currently null
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    public bool canDraw = true;

    public GameObject playerView; //to show the player area again
    public CanvasGroup playerCanvas; //to show the player canvas

    //list to hold the deck IDS
    public List<string> DeckIds = new List<string>();

    //List to hold the deck as a deck type
    public List<Deck> Decks = new List<Deck>();

    public List<Card> Hand = new List<Card>(); //will be used to store the cards tha are in the hand

    public List<Card> RegionPlacement = new List<Card>();
    public List<Card> SpecialRegionPlacement = new List<Card>();
    public List<Card> PlantPlacement = new List<Card>();
    public List<Card> AnimalPlacement= new List<Card>();
    public List<Card> InvertebratePlacement = new List<Card>();
    public List<Card> MicrobePlacement = new List<Card>();
    public List<Card> HumanPlacement = new List<Card>();
    public List<Card> MultiPlacement = new List<Card>();
    public List<Card> FungiPlacement = new List<Card>();
    public List<Card> ConditionPlacement = new List<Card>();
    public List<Card> DiscardPlacement = new List<Card>();

    //Computer one deck, hand and placements
    public List<Deck> cp1Deck = new List<Deck>(); //this will hold the deck for computer one
    public List<Card> HandCP1 = new List<Card>(); //will be used to store the cards tha are in the hand

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

    //Computer two deck, hand and placements
    public List<Deck> cp2Deck = new List<Deck>(); //this will hold the deck for computer two
    public List<Card> HandCP2 = new List<Card>(); //will be used to store the cards tha are in the hand

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

    //Computer three deck, hand and placements
    public List<Deck> cp3Deck = new List<Deck>(); //this will hold the deck for computer two
    public List<Card> HandCP3 = new List<Card>(); //will be used to store the cards tha are in the hand

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

    //lists will be used for the placement of the discard and the deck selection parts
    public List<Card> DeckSelectionList = new List<Card>();
    public List<Card> DiscardSelectionList = new List<Card>();

    //holds the colors of the decks so that they can be used
    public Color32 appalachianColor = new Color32(166, 135, 82, 128); //tanish
    public Color32 alleghenyColor = new Color32(58, 102, 44, 128); //greenish
    public Color32 clarionRiverColor = new Color32(116, 126, 140, 128); //grayish
    public Color32 peatBogsColor = new Color32(124, 56, 58, 128); //maroonish

    public Sprite anfTitle;
    public Sprite ahTitle;
    public Sprite crTitle;
    public Sprite pbTitle;

    //determines which deck was picked in the beginning
    public string deckPicked;
    public string computerOneDeck;
    public string computerTwoDeck;
    public string computerThreeDeck;

    //keep track of what round we are in
    public int round;

    //to keep the score of each player and computer
    public int playerScore;
    public int computerOneScore;
    public int computerTwoScore;
    public int computerThreeScore;

    //will be used to keep track of the sorting layers of the images
    public int sortingOrder = 10;

    //determines if you won or lost the game
    public bool win;
    public bool lose;

    //will bes used to change the text of the rounds
    public Text playerRound;
    public Text oneRound;
    public Text twoRound;
    public Text threeRound;

    //will bes ued to change the text of the scores
    public Text pScore;
    public Text oneScore;
    public Text twoScore;
    public Text threeScore;

    //will be used for the cards hand placements
    public Transform cp1Hand;
    public Transform cp2Hand;
    public Transform cp3Hand;

    public GameObject cardInfoPanel; //will be used to show the card information
    public Text nameCard;
    public Text descriptionCard;
    public Image imageCard;
    public Button specialActionButton; //to help determie if special action button is to be used 

    //used for the performAction script - to get the card name
    public GameObject DraggedCard;

    public Transform cp1AI;

    public phpImport importer;

    public Button endTurnButton; //the button and text for ending your turn
    public Button threeCardBurst; //button to activate the 3 card burst

    public CheckDeckAndDiscardPlayer check; //to be used when needing to look at the deck and the discard pile

    public Transform pickCardHolder; //this varbale is used to store the parent of where the picked card should go
    //this variable will be set in the actions of the player

    public Image pickExtinction; //will be used to show the extinction choices

    public bool cardDiscarded = false; //for the use when dragging cards
    public int regionCounter = 0; //used for the intial draw to determine if there is a region that needs to be drawn

    public bool playerActionCanBeUsed = false; //this is going to be used whenever the player clicks on the card to read the description, 
                                               //if false, the specaial action button will not be clickable and will read other text

    public GameObject AcidicWatersCanvas; //canvas for the acidic waters

    public Button cp1AcidButton; //buttons for picking which acidic waters to choose
    public Button cp2AcidButton;
    public Button cp3AcidButton;

    public Text cp1AcidText; //txt for the acidic waters page
    public Text cp2AcidText;
    public Text cp3AcidText;

    //ALL THE VARIABLES THAT WILL BE NEEDED FOR THE ACTIONS ND STANDING ACTIONS OF THE CARDS
    public bool playerProtectedFromExtinction = false; //protects player from extinction if true
    public bool cp1ProtectedFromExtinction = false;
    public bool cp2ProtectedFromExtinction = false;
    public bool cp3ProtectedFromExtinction = false;

    public bool playerProtectedFromInvasiveAnimal = false; //will be used when the player is protected from an invasive animal species
    public bool cp1ProtectedFromInvasiveAnimal = false;
    public bool cp2ProtectedFromInvasiveAnimal = false;
    public bool cp3ProtectedFromInvasiveAnimal = false;

    public bool playerProtectedFromInvasivePlant = false; //willl protect the players from an invasive plant species
    public bool cp1ProtectedFromInvasivePlant = false;
    public bool cp2ProtectedFromInvasivePlant = false;
    public bool cp3ProtectedFromInvasivePlant = false;

    public bool playerNoConditionRequirements = false; //players can play condition cards without requirements if this is true
    public bool cp1NoConditionRequirements = false;
    public bool cp2NoConditionRequirements = false;
    public bool cp3NoConditionRequirements = false;

    public bool playerProtectedFromBlight = false; //players ecostsyem is pritected from blight
    public bool cp1ProtectedFromBlight = false;
    public bool cp2ProtectedFromBlight = false;
    public bool cp3ProtectedFromBlight = false;

    public bool playerPausedOneTurn = false; //the players actions will be paused for one round
    public bool cp1PausedOneTurn = false;
    public bool cp2PausedOneTurn = false;
    public bool cp3PausedOneTurn = false;

    public bool playerProtectedFromWeb = false; //the players will be protected from the web of life and standing actions that affect more than one ecosystem
    public bool cp1ProtectedFromWeb = false;
    public bool cp2ProtectedFromWeb = false;
    public bool cp3ProtectedFromWeb = false;

    public bool playerNoDiscard = false; //players no longer have to discard when this is true
    public bool cp1NoDiscard = false;
    public bool cp2NoDiscard = false;
    public bool cp3NoDiscard = false;

    public bool playerDrawExtraCard = false; //players will be able to draw an extra card
    public bool cp1DrawExtraCard = false;
    public bool cp2DrawExtraCard = false;
    public bool cp3DrawExtraCard = false;

    public bool ecosystemsConnected = false; //this vaiable will determine if all the ecosystems are connected

    public bool playerTwentyPointNoDiscard = false; //players can keep a 20 point card in their hand wthout discarding it
    public bool cp1TwentyPointNoDiscard = false;
    public bool cp2TwentyPointNoDiscard = false;
    public bool cp3TwentyPointNoDiscard = false;

    public bool playerProtectedFromInvertebrate = false; //players are protected from invasive invertebrates species
    public bool cp1ProtectedFromInvertebrate = false;
    public bool cp2ProtectedFromInvertebrate = false;
    public bool cp3ProtectedFromInvertebrate = false;

    //these variables will be used when getting the region information - keeps track of number of regions and types and sepcial regions
    public int playerAridCount = 0; //player regions
    public int playerForestCount = 0;
    public int playerGrasslandsCount = 0;
    public int playerRunningWaterCount = 0;
    public int playerSaltWaterCount = 0;
    public int playerStandingWaterCount = 0;
    public int playerSubZeroCount = 0;
    public int playerMountainRange = 0;
    public int playerTotalRegions = 0;

    public int cp1AridCount = 0; //cp1 regions
    public int cp1ForestCount = 0;
    public int cp1GrasslandsCount = 0;
    public int cp1RunningWaterCount = 0;
    public int cp1SaltWaterCount = 0;
    public int cp1StandingWaterCount = 0;
    public int cp1SubZeroCount = 0;
    public int cp1MountainRange = 0;
    public int cp1TotalRegions = 0;

    public int cp2AridCount = 0; //cp2 regions
    public int cp2ForestCount = 0;
    public int cp2GrasslandsCount = 0;
    public int cp2RunningWaterCount = 0;
    public int cp2SaltWaterCount = 0;
    public int cp2StandingWaterCount = 0;
    public int cp2SubZeroCount = 0;
    public int cp2MountainRange = 0;
    public int cp2TotalRegions = 0;

    public int cp3AridCount = 0; //cp3 regions
    public int cp3ForestCount = 0;
    public int cp3GrasslandsCount = 0;
    public int cp3RunningWaterCount = 0;
    public int cp3SaltWaterCount = 0;
    public int cp3StandingWaterCount = 0;
    public int cp3SubZeroCount = 0;
    public int cp3MountainRange = 0;
    public int cp3TotalRegions = 0;

    public int playerDrawCount = 0;

    //must have this before the start functions
    public void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(_instance);
    }

    // Use this for initialization
    void Start () {
        //just adds the deck ids to the list
        DeckIds.Add("D001");
        DeckIds.Add("D002");
        DeckIds.Add("D003");
        DeckIds.Add("D004");
        foreach (string id in DeckIds) //Loop through deckID list to make deck list
        {
            Deck deck = new Deck();
            deck.DeckId = id;
            //decks.Add(deck);
            Decks.Add(deck);
        }

        gameObject.AddComponent<phpImport>();

        round = 1; //just sets the initial round
    }
    
    //will determine if you have won the game or lost
    public void winOrLose()
    {
        //if the players score is less than any of the computers score, you lose
        if(playerScore < computerOneScore || playerScore < computerTwoScore || playerScore < computerThreeScore)
        {
            lose = true;
            win = false;

            SceneManager.LoadScene("LoseScene"); //will take you to the loser scene 
        }
        else //if it is not less than any of the computer scores or tied with one of them, then you win
        {
            win = true;
            lose = false;

            SceneManager.LoadScene("WinScene"); //will take you to the winners scene
        }

        round = 1; //resets the rounds

        Hand.Clear(); //clears the hands
        HandCP1.Clear();
        HandCP2.Clear();
        HandCP3.Clear();
    }

    //will be used to reset the game
    public void restartGame()
    {
        Destroy(this.GetComponent<GameManager>()); //deletes the current game manager
        this.gameObject.AddComponent<GameManager>(); //creates a new one from scratch
    }
    
    //willbe used to change the round text
    public void changeRound()
    {
        cardDiscarded = false;

        if (round != 10)
        {
            round++; //adds 1 to the round, will be called after all four players have taken a turn (Max 10)

            //change the player round text
            playerRound = GameObject.Find("PlayerRoundText").GetComponent<Text>();
            playerRound.text = round.ToString();
        }
        else if ( round == 10)
        {
            winOrLose();
        }
    }

    //will be used to change the players score
    public void changePlayerScore(int score)
    {
        playerScore = playerScore + score; //adds the score to the player score

        //changes the score of the player
        pScore = GameObject.Find("PlayerScoreText").GetComponent<Text>();
        pScore.text = playerScore.ToString();
    }

    //will be used to change computer one's score
    public void changeComputerOneScore(int score)
    {
        computerOneScore = computerOneScore + score; //adds the score to the computer one score

        //change the score of computer one
        oneScore = GameObject.Find("ComputerOneScoreText").GetComponent<Text>();
        oneScore.text = computerOneScore.ToString();
    }

    //will be used to change the computer two's score
    public void changeComputerTwoScore(int score)
    {
        computerTwoScore = computerTwoScore + score; //adds the score to the computer two score

        //changes the score of computer two
        twoScore = GameObject.Find("ComputerTwoScoreText").GetComponent<Text>();
        twoScore.text = computerTwoScore.ToString();
    }

    //will be used to change the score for computer three
    public void changeComputerThreeScore(int score)
    {
        computerThreeScore = computerThreeScore + score; //adds the score to the computer three score

        //will change the score of computer three
        threeScore = GameObject.Find("ComputerThreeScoreText").GetComponent<Text>();
        threeScore.text = computerThreeScore.ToString();
    }

    public void enableTurnButton()
    {
        endTurnButton = GameObject.Find("EndTurnButton").GetComponent<Button>();
        endTurnButton.interactable = true;
    }

    public void disableTurnButton() //just diables the button functionality
    {
        endTurnButton.interactable = false;
    }

    public void makeButtonInvisible() //makes the end turn button not visible
    {
        endTurnButton.gameObject.SetActive(false); //button should no longer be visible
    }

    public void makeButtonVisible() //makes the end turn button visible to the player
    {
        endTurnButton.gameObject.SetActive(true); //button should be visible now
    }

    public int getPlayerTotalRegions() //to calculate the total regions of the player in one funtion rather than typing it out all the time
    {
        int total = 0;

        total += playerAridCount; //just gets the regions and adds them to the total
        total += playerGrasslandsCount;
        total += playerForestCount;
        total += playerRunningWaterCount;
        total += playerStandingWaterCount;
        total += playerSaltWaterCount;
        total += playerSubZeroCount;
        total += playerMountainRange;

        return total;
    }

    public int getCP1TotalRegions()
    {
        int total = 0;

        total += cp1AridCount; //just gets the regions and adds them to the total
        total += cp1GrasslandsCount;
        total += cp1ForestCount;
        total += cp1RunningWaterCount;
        total += cp1StandingWaterCount;
        total += cp1SaltWaterCount;
        total += cp1SubZeroCount;
        total += cp1MountainRange;

        return total;
    }

    public int getCP2TotalRegions()
    {
        int total = 0;

        total += cp2AridCount; //just gets the regions and adds them to the total
        total += cp2GrasslandsCount;
        total += cp2ForestCount;
        total += cp2RunningWaterCount;
        total += cp2StandingWaterCount;
        total += cp2SaltWaterCount;
        total += cp2SubZeroCount;
        total += cp2MountainRange;

        return total;
    }

    public int getCP3TotalRegions()
    {
        int total = 0;

        total += cp3AridCount; //just gets the regions and adds them to the total
        total += cp3GrasslandsCount;
        total += cp3ForestCount;
        total += cp3RunningWaterCount;
        total += cp3StandingWaterCount;
        total += cp3SaltWaterCount;
        total += cp3SubZeroCount;
        total += cp3MountainRange;

        return total;
    }
}

