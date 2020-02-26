/*
 *  @class      GameManager.cs
 *  @purpose    Manages turn-by-turn game loop and game-critical functions
 *  
 *  @author     John Georgvich, previous CIS411 group
 *  @date       2020/01/22
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

    public bool canDraw = true;

    //  create playerView and playerCanvas objects
    public GameObject playerView;
    public CanvasGroup playerCanvas;

    //  create list to hold Deck IDs
    public List<string> DeckIds = new List<string>();

    //  create list to hold individual decks
    public List<Deck> Decks = new List<Deck>();

    //  create list to hold player cards in hand
    public List<Card> Hand = new List<Card>();

    //  create lists for player card placements
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

    //  create computer one deck, hand
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

    //  create computer two deck, hand
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

    //  create computer three deck, hand
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

    //  placement of deck selection and discard selection
    public List<Card> DeckSelectionList = new List<Card>();
    public List<Card> DiscardSelectionList = new List<Card>();

    //  holds deck colors
    /*
     *  @TODO:
     *      break color palettes out into functions (get, set)
     *  @REASON:
     *      no declaration in create statement
     *      
     *  appalachianColor = tan-ish
     *  alleghenyColor = green-ish
     *  clarionRiverColor = gray-ish
     *  peatBogsColor = maroon-ish
     */
    public Color32 appalachianColor = new Color32(166, 135, 82, 128);
    public Color32 alleghenyColor = new Color32(58, 102, 44, 128);
    public Color32 clarionRiverColor = new Color32(116, 126, 140, 128);
    public Color32 peatBogsColor = new Color32(124, 56, 58, 128);

    public Sprite anfTitle;
    public Sprite ahTitle;
    public Sprite crTitle;
    public Sprite pbTitle;

    //  stores selected decks for game
    public string deckPicked;
    public string computerOneDeck;
    public string computerTwoDeck;
    public string computerThreeDeck;

    //  stores round number
    public int round;

    //  stores player scores
    public int playerScore;
    public int computerOneScore;
    public int computerTwoScore;
    public int computerThreeScore;

    //  stores sorting layers
    public int sortingOrder = 10;

    //  determines win/loss status for human player
    public bool win;
    public bool lose;

    //  stores values for round text information
    public Text playerRound;
    public Text oneRound;
    public Text twoRound;
    public Text threeRound;

    //  stores values for player score information
    public Text pScore;
    public Text oneScore;
    public Text twoScore;
    public Text threeScore;

    //  placement of cards in-hand for players
    public Transform cp1Hand;
    public Transform cp2Hand;
    public Transform cp3Hand;

    //  object displays card information
    public GameObject cardInfoPanel; 
    public Text nameCard;
    public Text descriptionCard;
    public Image imageCard;
    //  determines special action usage basedon card description
    public Button specialActionButton; 

    //  for @performAction.cs, returns card name
    public GameObject DraggedCard;

    public Transform cp1AI;

    public phpImport importer;

    //  button to end turn
    public Button endTurnButton;
    //  button to use three-card burst ability
    public Button threeCardBurst;

    //  used when checking deck/discard pile
    public CheckDeckAndDiscardPlayer check;

    //  used to store parent of selected card location
    //  set by player actions
    public Transform pickCardHolder;

    //  displays extinction choices
    public Image pickExtinction;

    //  specifies whether or not card was discarded when dragging
    public bool cardDiscarded = false;
    //  used for the intial draw to determine if there is a region that needs to be drawn
    /*
     *  @TODO:
     *      Refactor this.
     *  @REASON:
     *      No declarations in create statements.
     */
    public int regionCounter = 0;

    //  used when player selects card to read description
    //  when false, special action button is unavailable
    public bool playerActionCanBeUsed = false;


    /*
     *  @TODO:
     *      Refactor?
     *  @REASON:
     *      Conditions should be object independent.
     */
    //  canvas for acidic water condition
    public GameObject AcidicWatersCanvas;

    //  buttons for selecting which user to affect with acidic waters
    public Button cp1AcidButton; 
    public Button cp2AcidButton;
    public Button cp3AcidButton;

    //  text for acidic waters affectation
    public Text cp1AcidText;
    public Text cp2AcidText;
    public Text cp3AcidText;

    /*
     *  @TODO:
     *      Refactor.
     *  @REASON:
     *      Use flags to determine action/standing action status; not individual variables.
     */
    //  necessary variables for actions and standing actions
    //  extinction flags
    public bool playerProtectedFromExtinction = false;
    public bool cp1ProtectedFromExtinction = false;
    public bool cp2ProtectedFromExtinction = false;
    public bool cp3ProtectedFromExtinction = false;

    //  invasive animal flags
    public bool playerProtectedFromInvasiveAnimal = false;
    public bool cp1ProtectedFromInvasiveAnimal = false;
    public bool cp2ProtectedFromInvasiveAnimal = false;
    public bool cp3ProtectedFromInvasiveAnimal = false;

    //  invasive plant flags
    public bool playerProtectedFromInvasivePlant = false;
    public bool cp1ProtectedFromInvasivePlant = false;
    public bool cp2ProtectedFromInvasivePlant = false;
    public bool cp3ProtectedFromInvasivePlant = false;

    //  condition card flags
    public bool playerNoConditionRequirements = false;
    public bool cp1NoConditionRequirements = false;
    public bool cp2NoConditionRequirements = false;
    public bool cp3NoConditionRequirements = false;

    //  blight protection flags
    public bool playerProtectedFromBlight = false;
    public bool cp1ProtectedFromBlight = false;
    public bool cp2ProtectedFromBlight = false;
    public bool cp3ProtectedFromBlight = false;

    //  turn pause flags
    public bool playerPausedOneTurn = false;
    public bool cp1PausedOneTurn = false;
    public bool cp2PausedOneTurn = false;
    public bool cp3PausedOneTurn = false;

    //  web of life protection flags
    public bool playerProtectedFromWeb = false;
    public bool cp1ProtectedFromWeb = false;
    public bool cp2ProtectedFromWeb = false;
    public bool cp3ProtectedFromWeb = false;

    //  no discard flags
    public bool playerNoDiscard = false;
    public bool cp1NoDiscard = false;
    public bool cp2NoDiscard = false;
    public bool cp3NoDiscard = false;

    //  extra draw flags
    public bool playerDrawExtraCard = false;
    public bool cp1DrawExtraCard = false;
    public bool cp2DrawExtraCard = false;
    public bool cp3DrawExtraCard = false;

    //  all player ecosystems connected flag
    public bool ecosystemsConnected = false;

    //  discard 20 point card protection flags
    public bool playerTwentyPointNoDiscard = false;
    public bool cp1TwentyPointNoDiscard = false;
    public bool cp2TwentyPointNoDiscard = false;
    public bool cp3TwentyPointNoDiscard = false;

    //  invasive invertibrate flags
    public bool playerProtectedFromInvertebrate = false;
    public bool cp1ProtectedFromInvertebrate = false;
    public bool cp2ProtectedFromInvertebrate = false;
    public bool cp3ProtectedFromInvertebrate = false;

    /*
     *  @TODO:
     *      Refactor.
     *  @REASON:
     *      Region counts can be accessed from player/CP objects?
     */
    //  lists human player region individual/total counts
    public int playerAridCount = 0;
    public int playerForestCount = 0;
    public int playerGrasslandsCount = 0;
    public int playerRunningWaterCount = 0;
    public int playerSaltWaterCount = 0;
    public int playerStandingWaterCount = 0;
    public int playerSubZeroCount = 0;
    public int playerMountainRange = 0;
    public int playerTotalRegions = 0;

    //  lists computer one player region individual/total counts
    public int cp1AridCount = 0; 
    public int cp1ForestCount = 0;
    public int cp1GrasslandsCount = 0;
    public int cp1RunningWaterCount = 0;
    public int cp1SaltWaterCount = 0;
    public int cp1StandingWaterCount = 0;
    public int cp1SubZeroCount = 0;
    public int cp1MountainRange = 0;
    public int cp1TotalRegions = 0;

    //  lists computer two player region individual/total counts
    public int cp2AridCount = 0;
    public int cp2ForestCount = 0;
    public int cp2GrasslandsCount = 0;
    public int cp2RunningWaterCount = 0;
    public int cp2SaltWaterCount = 0;
    public int cp2StandingWaterCount = 0;
    public int cp2SubZeroCount = 0;
    public int cp2MountainRange = 0;
    public int cp2TotalRegions = 0;

    //  lists computer three player region individual/total counts
    public int cp3AridCount = 0;
    public int cp3ForestCount = 0;
    public int cp3GrasslandsCount = 0;
    public int cp3RunningWaterCount = 0;
    public int cp3SaltWaterCount = 0;
    public int cp3StandingWaterCount = 0;
    public int cp3SubZeroCount = 0;
    public int cp3MountainRange = 0;
    public int cp3TotalRegions = 0;

    public int playerDrawCount = 0;

    /*
     *  @name       Awake()
     *  @purpose    start Unity framework; ensure GameManager instance is not destoryed on scene load
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

        //  ???
        gameObject.AddComponent<phpImport>();

        //  sets initial round number
        round = 1;
    }
    
    /*
     *  @name       winOrLose
     *  @purpose    determines whether the human player has won or lost
     */
    public void winOrLose()
    {
        //  if human playerScore is less than computer player scores
        if(playerScore < computerOneScore || playerScore < computerTwoScore || playerScore < computerThreeScore)
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
    public void changeRound()
    {
        //  set player discard value to false, requiring discard
        cardDiscarded = false;

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
        else if ( round == 10)
        {
            //  end game; see winOrLose()
            winOrLose();
        }
    }

    /*
     *  @name       changePlayerScore()
     *  @purpose    update player score when point-bearing cards are played
     *  
     *  @param      int score;  specifies the amount of points to be added to player score
     */
    public void changePlayerScore(int score)
    {
        //  adds integer parameter to existing score
        playerScore = playerScore + score;

        //  updates score text
        pScore = GameObject.Find("PlayerScoreText").GetComponent<Text>();
        pScore.text = playerScore.ToString();
    }

    /*
     *  @name       changeComputerOneScore()
     *  @purpose    update computer player score when point-bearing cards are played
     *  
     *  @param      int score;  specifies the amount of points to be added to computer one player score
     */
    public void changeComputerOneScore(int score)
    {
        //  adds integer parameter to existing score
        computerOneScore = computerOneScore + score;

        //  updates score text
        oneScore = GameObject.Find("ComputerOneScoreText").GetComponent<Text>();
        oneScore.text = computerOneScore.ToString();
    }

    /*
     *  @name       changeComputerTwoScore()
     *  @purpose    update computer player score when point-bearing cards are played
     *  
     *  @param      int score;  specifies the amount of points to be added to computer player two score
     */
    public void changeComputerTwoScore(int score)
    {
        //  adds integer parameter to existing score
        computerTwoScore = computerTwoScore + score;

        //  updates score text
        twoScore = GameObject.Find("ComputerTwoScoreText").GetComponent<Text>();
        twoScore.text = computerTwoScore.ToString();
    }

    /*
     *  @name       changeComputerThreeScore()
     *  @purpose    update computer player score when points-bearing cards are played
     *  
     *  @param      int score;  specifies the amount of points to be added to computer player three score
     */
    public void changeComputerThreeScore(int score)
    {
        //  adds integer parameter to existing score
        computerThreeScore = computerThreeScore + score;

        //  updates score text
        threeScore = GameObject.Find("ComputerThreeScoreText").GetComponent<Text>();
        threeScore.text = computerThreeScore.ToString();
    }

    /*
     *  @name       enableTurnButton()
     *  @purpose    enables button used to end turn
     */
    public void enableTurnButton()
    {
        endTurnButton = GameObject.Find("EndTurnButton").GetComponent<Button>();
        endTurnButton.interactable = true;
    }

    /*
     *  @name       disableTurnButton()
     *  @purpose    disables button used to end turn
     */
    public void disableTurnButton()
    {
        endTurnButton.interactable = false;
    }

    /*
     *  @name       makeButtonInvisible()
     *  @purpose    makes end-turn button invisible
     */
    public void makeButtonInvisible()
    {
        endTurnButton.gameObject.SetActive(false);
    }

    /*
     *  @name       makeButtonVisible()
     *  @purpose    makes end-turn button visible
     */
    public void makeButtonVisible()
    {
        endTurnButton.gameObject.SetActive(true);
    }

    /*
     *  @name       getPlayerTotalRegions()
     *  @purpose    returns human player region totals
     *  
     *  @return     int total;  total amount of regions human player has played
     */
    public int getPlayerTotalRegions()
    {
        int total = 0;

        //  human player region totals
        total += playerAridCount;
        total += playerGrasslandsCount;
        total += playerForestCount;
        total += playerRunningWaterCount;
        total += playerStandingWaterCount;
        total += playerSaltWaterCount;
        total += playerSubZeroCount;
        total += playerMountainRange;

        return total;
    }

    /*
     *  @name       getCP1TotalRegions()
     *  @purpose    returns computer one region totals
     *  
     *  @return     int total; total amount of regions computer player one has played
     */
    public int getCP1TotalRegions()
    {
        int total = 0;

        //  computer player region totals
        total += cp1AridCount;
        total += cp1GrasslandsCount;
        total += cp1ForestCount;
        total += cp1RunningWaterCount;
        total += cp1StandingWaterCount;
        total += cp1SaltWaterCount;
        total += cp1SubZeroCount;
        total += cp1MountainRange;

        return total;
    }

    /*
     *  @name       getCP2TotalRegions()
     *  @purpose    returns computer two region totals
     *  
     *  @return     int total;  total amount of regions computer player two has played
     */
    public int getCP2TotalRegions()
    {
        int total = 0;

        //  computer player region totals
        total += cp2AridCount;
        total += cp2GrasslandsCount;
        total += cp2ForestCount;
        total += cp2RunningWaterCount;
        total += cp2StandingWaterCount;
        total += cp2SaltWaterCount;
        total += cp2SubZeroCount;
        total += cp2MountainRange;

        return total;
    }

    /*
     *  @name       getCP3TotalRegions()
     *  @purpose    returns computer player three region tools
     *  
     *  @return     int total;  total amount of regions computer player three has played
     */
    public int getCP3TotalRegions()
    {
        int total = 0;

        //  computer player region totals
        total += cp3AridCount;
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

