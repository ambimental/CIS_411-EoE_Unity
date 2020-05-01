/*
 *  @class      Player
 *  @purpose    This is the base class for all players and humans and computers will extend from it
 *  
 *  @author     CIS 411
 *  @date       2020/04/06
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //keeps track of how many regions they have to make sure they can draw the right amount if cards
    private int regionCounter;
    //keeps track of how many cards the player can draw based off of how many regions they have
    private int drawCount;
    //  stores selected deckId for the player
    private string deckPicked;
    //  stores player score
    private int score;
    //round 
    private int round;
    //to use three card burst
    private bool threeCardBurstAvailable;

    //keeps track of which board goes next
    private string playerName;

    //deck for the player
    private Deck deck;
    //  create list to hold players cards in hand
    private List<Card> hand;

    //variables to store placement regions they are passed in as strings when objects are created
    private string handGameObject;
    private string regionGameObject;
    private string conditionGameObject;
    private string plantGameObject;
    private string invertebrateGameObject;
    private string animalGameObject;
    private string specialRegionGameObject;
    private string multiplayerGameObject;
    private string microbeGameObject;
    private string fungiGameObject;
    private string discardGameObject;
    private string deckColorGameObject;
    private string deckTextGameObject;
    private string humanGameObject;
    private string scoreGameObject;
    private string roundGameObject;
    private string humanScoreGameObject;
    private string cP1ScoreGameObject;
    private string cP2ScoreGameObject;
    private string cP3ScoreGameObject;

    //  Creates objects  to interact with UI canvas
    //  stores values for round text information
    private Text roundText;
    private Text scoreText;
    private Image deckColor;
    private Text deckText;

    //this is to change all of the score texts on the screen for each player
    private Text humanScoreText;
    private Text cP1ScoreText;
    private Text cP2ScoreText;
    private Text cP3ScoreText;


    //graphics and card objects
    private CardRetrievalFromDeck holder;
    private ScriptableObject scriptInstance;
    private SpriteRenderer sr;
    private Texture2D texSprite;
    private Sprite tempSprite;
    private GameObject cardObject;
    private GameObject cameraHolder; //will be used to hold the main camera object for creating and destoying scripts
    private Transform cardParent;

    //  create lists for player card placements
    private List<Card> regionPlacement;
    private List<Card> specialRegionPlacement;
    private List<Card> plantPlacement;
    private List<Card> animalPlacement;
    private List<Card> invertebratePlacement;
    private List<Card> microbePlacement;
    private List<Card> humanPlacement;
    private List<Card> multiPlacement;
    private List<Card> fungiPlacement;
    private List<Card> conditionPlacement;
    private List<Card> discardPlacement;

    /*
     *  @TODO:
     *      Refactor.
     *  @REASON:
     *      Use flags to determine action/standing action status; not individual variables.
     */
    //  necessary variables for actions and standing actions
    //  extinction flags
    private bool protectedFromExtinction;
    private bool protectedFromInvasiveAnimal;
    private bool protectedFromInvasivePlant;
    private bool noConditionRequirements;
    private bool protectedFromBlight;
    private bool pausedOneTurn;
    private bool protectedFromWeb;
    private bool noDiscard;
    private bool drawExtraCard;
    //  all player ecosystems connected flag
    private bool ecosystemsConnected;
    private bool twentyPointNoDiscard;
    private bool protectedFromInvertebrate;
    //  lists player region individual/total counts
    private int aridCount;
    private int forestCount;
    private int grasslandsCount;
    private int runningWaterCount;
    private int saltWaterCount;
    private int standingWaterCount;
    private int subZeroCount;
    private int mountainRange;
    private int totalRegions;

    /*
     *  @name       Initialize Objects() 
     *  @purpose    acts as constuctor since unitiy doesnt let us create objects of classes normally. Is call when created in Game Manager class
     */
    public virtual void InitializeObjects(string pScoreGameObject, string pRoundGameObject, string pHandGameObject, string pRegionGameObject, string pConditionGameObject, 
        string pPlantGameObject, string pInvertebrateGameObject, string pAnimalGameObject, string pSpecialRegionGameObject, string pMultiplayerGameObject, 
        string pMicrobeGameObject, string pFungiGameObject, string pDiscardGameObject, string pHumanGameObject, string pDeckColorGameObject, string pDeckTextGameObject,
        string pHumanScoreGameObject, string pCP1ScoreGameObject, string pCP2ScoreGameObject, string pCP3ScoreGameObject, string pPlayerName)
    {
     
        //this will all be stuff from parent class below
        Deck = new Deck();
        //  create list to hold player cards in hand
        Hand = new List<Card>();

        //these hold pathnames for UI objects
        ScoreGameObject = pScoreGameObject;
        RoundGameObject = pRoundGameObject;
        HandGameObject = pHandGameObject;
        RegionGameObject = pRegionGameObject;
        ConditionGameObject = pConditionGameObject;
        PlantGameObject = pPlantGameObject;
        InvertebrateGameObject = pInvertebrateGameObject;
        AnimalGameObject = pAnimalGameObject;
        SpecialRegionGameObject = pSpecialRegionGameObject;
        MultiplayerGameObject = pMultiplayerGameObject;
        MicrobeGameObject = pMicrobeGameObject;
        FungiGameObject = pFungiGameObject;
        DiscardGameObject = pDiscardGameObject;
        HumanGameObject = pHumanGameObject;
        DeckColorGameObject = pDeckColorGameObject;
        DeckTextGameObject = pDeckTextGameObject;
        HumanScoreGameObject= pHumanScoreGameObject;
        CP1ScoreGameObject= pCP1ScoreGameObject;
        CP2ScoreGameObject= pCP2ScoreGameObject;
        CP3ScoreGameObject= pCP3ScoreGameObject;

        //game values
        Score = 0;
        Round = 1;

        //sets the name so the round chan change
        PlayerName = pPlayerName;

        //  create lists for player card placements
        RegionPlacement = new List<Card>();
        SpecialRegionPlacement = new List<Card>();
        PlantPlacement = new List<Card>();
        AnimalPlacement = new List<Card>();
        InvertebratePlacement = new List<Card>();
        MicrobePlacement = new List<Card>();
        HumanPlacement = new List<Card>();
        MultiPlacement = new List<Card>();
        FungiPlacement = new List<Card>();
        ConditionPlacement = new List<Card>();
        DiscardPlacement = new List<Card>();

        AridCount = 0;
        ForestCount = 0;
        GrasslandsCount = 0;
        RunningWaterCount = 0;
        SaltWaterCount = 0;
        StandingWaterCount = 0;
        SubZeroCount = 0;
        MountainRange = 0;
        TotalRegions = 0;

        ProtectedFromExtinction = false;
        ProtectedFromInvasiveAnimal = false;
        ProtectedFromInvasivePlant = false;
        NoConditionRequirements = false;
        ProtectedFromBlight = false;
        PausedOneTurn = false;
        ProtectedFromWeb = false;
        NoDiscard = false;
        DrawExtraCard = false;
        EcosystemsConnected = false;
        TwentyPointNoDiscard = false;
        ProtectedFromInvertebrate = false;

        RegionCounter = 0;
        DrawCount = 0;
        ThreeCardBurstAvailable = true;

    }

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}

      /*
    *  @name       GetTotalRegions()
    *  @purpose    adds up all the regions and returns that value so the amount if cards drawn can be determined
    */
    public int GetTotalRegions()
    {
        //local variable to keep track of regions
        int total = 0;

        //  human player region totals
        total += AridCount;
        total += GrasslandsCount;
        total += ForestCount;
        total += RunningWaterCount;
        total += StandingWaterCount;
        total += SaltWaterCount;
        total += SubZeroCount;
        total += MountainRange;

        return total;
    }

    /*
     *  @name       ThreeCardExecute() 
     *  @purpose    used once per game per player and will not be able to be used again once used
     */
    public virtual void ThreeCardExecute(){}

    /*
     *  @name       GenerateCardObjects() 
     *  @purpose    this gets the card from the deck and assigns it to a game object that will be the card you will see omn the screen
     */
    public virtual void GenerateCardObject()
    {
        //creating a new gameobject  to hold act as the card
        CardObject = new GameObject(Holder.CardNameHolder, typeof(RectTransform));
        //creating a SpriteRenderer to hold the card's Sprite
        Sr = CardObject.AddComponent<SpriteRenderer>();
        //setting the rectangle size  of the card object
        CardObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 120);
        //adding a collider to the card object, which is sized based on the rectangle size
        CardObject.AddComponent<BoxCollider2D>().size = CardObject.GetComponent<RectTransform>().sizeDelta;
        //setting the card object's parent to be the Hand, so that it will render in the player's hand
        CardObject.transform.SetParent(CardParent);
        //setting the localScale of the card object, so that it will be appropriately sized
        CardObject.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        //adding the HoverClass script to the card object, which allows for hover functionality.
        CardObject.AddComponent<HoverClass>();
        //adds the component to a canvas group so it can be manipulated and viewed approapriatly
        CardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
    }

        /*
    *  @name       ChangeAllScore()
    *  @purpose    Updates all the scores om the current canvas screen happens after each players turn
    */
    public void ChangeAllScore()
    {
        //updates human score
        HumanScoreText = GameObject.Find(HumanScoreGameObject).GetComponent<Text>();
        HumanScoreText.text = GameManager.Instance.Person.Score.ToString();
        //updates CP1 score
        CP1ScoreText = GameObject.Find(CP1ScoreGameObject).GetComponent<Text>();
        CP1ScoreText.text = GameManager.Instance.CP1.Score.ToString();
        //updates CP2 score
        CP2ScoreText = GameObject.Find(CP2ScoreGameObject).GetComponent<Text>();
        CP2ScoreText.text = GameManager.Instance.CP2.Score.ToString();
        //updates CP3 score
        CP3ScoreText = GameObject.Find(CP3ScoreGameObject).GetComponent<Text>();
        CP3ScoreText.text = GameManager.Instance.CP3.Score.ToString();
    }

        /*
    *  @name       ChangeScore()
    *  @purpose    Change Player score within this class as the cards are being places
    */
    public void ChangeScore(int pScore)
    {
        //  adds integer parameter to existing score
        Score = Score + pScore;

        //  updates score text
        ScoreText = GameObject.Find(ScoreGameObject).GetComponent<Text>();
        ScoreText.text = Score.ToString();
    }

    /*
    *  @name       DrawAmount()
    *  @purpose    Determines how many cars the player will draw then calls the draw function
    */
    public void DrawAmount()
    {
        if (GetTotalRegions() < 5) //will determine how many cards they draw based on regions
        {
            DrawCount = 1;
        }
        else if (GetTotalRegions() < 10) //2 cards drawn
        {
            DrawCount = 2;
        }
        else if (GetTotalRegions() < 15) //3 cards drawn
        {
            DrawCount = 3;
        }
        else if (GetTotalRegions() < 20) //4 cards drawn
        {
            DrawCount = 4;
        }
    }
        
        /*
    *  @name       Draw()
    *  @purpose    draws card. Intentionally left empy becasue human and player draw differenly
    */
    public virtual void Draw(int pDrawAmount){}

        /*
    *  @name       ChangeRound()
    *  @purpose    Change Player round
    */
    public void ChangeRound()
    {
        //assigns the round in this class to game manager
        Round = GameManager.Instance.Round;
        //  updates score text
        RoundText = GameObject.Find(RoundGameObject).GetComponent<Text>();
        RoundText.text = Round.ToString();
    }

        /*
    *  @name       AssignDeck()
    *  @purpose    This loops through the deck list created in the game manager and assigns the correct deck to the player
    */
    public void AssignDeck()
    {
        //loops the though the 4 game manger decks. gmDeck is Game ManagerDeck
        foreach (Deck gmDeck in GameManager.Instance.Decks)
        {
            //when the deck with the same ID as the players is found it copies that deck to the deck of this player
            if (gmDeck.DeckId == DeckPicked)
            {
                //assigns the populated game manager deck to the player deck
                Deck = gmDeck;
            }
        }
    }

    /*
    *  @name       CreateDeckInfo()
    *  @purpose    Tthis assigns the UI elements with the proper data fro the decks that is assigned in the pick deck function
    */
    public void CreateDeckInfo()
    {
        //Debug.Log(Deck.DeckColor);
        //assigns color
        DeckColor = GameObject.Find(DeckColorGameObject).GetComponent<Image>();
        DeckColor.color = Deck.DeckColor;

        //assigns deck name
        DeckText = GameObject.Find(DeckTextGameObject).GetComponent<Text>();
        DeckText.text = Deck.DeckName.ToString();
    }

        /*
    *  @name       StartTurn()
    *  @purpose    deals the player 5 cards if its round one then starts the players turn
    */
    public virtual void StartTurn()
    {
        //assigns deck info and color
        //CreateDeckInfo();
        //Updates the round to current
        ChangeRound();
        //updates the score board
        ChangeAllScore();
        //creating an "instance" of the CardRetrievalFromDeck script, allows it to be retrieved as an object
        ScriptInstance = ScriptableObject.CreateInstance("CardRetrievalFromDeck"); //so you can use the script
        Holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>(); //access to script
        //CameraHolder = GameObject.Find("Main Camera"); //sets the object to just the main camera
    }

    //accessors and mutators
    public Deck Deck { get => deck; set => deck = value; }
    public List<Card> Hand { get => hand; set => hand = value; }
    public List<Card> RegionPlacement { get => regionPlacement; set => regionPlacement = value; }
    public List<Card> SpecialRegionPlacement { get => specialRegionPlacement; set => specialRegionPlacement = value; }
    public List<Card> PlantPlacement { get => plantPlacement; set => plantPlacement = value; }
    public List<Card> AnimalPlacement { get => animalPlacement; set => animalPlacement = value; }
    public List<Card> InvertebratePlacement { get => invertebratePlacement; set => invertebratePlacement = value; }
    public List<Card> MicrobePlacement { get => microbePlacement; set => microbePlacement = value; }
    public List<Card> HumanPlacement { get => humanPlacement; set => humanPlacement = value; }
    public List<Card> MultiPlacement { get => multiPlacement; set => multiPlacement = value; }
    public List<Card> FungiPlacement { get => fungiPlacement; set => fungiPlacement = value; }
    public List<Card> ConditionPlacement { get => conditionPlacement; set => conditionPlacement = value; }
    public List<Card> DiscardPlacement { get => discardPlacement; set => discardPlacement = value; }
    public string DeckPicked { get => deckPicked; set => deckPicked = value; }
    public int Score { get => score; set => score = value; }
    public Text RoundText { get => roundText; set => roundText = value; }
    public Text ScoreText { get => scoreText; set => scoreText = value; }
    public string ScoreGameObject { get => scoreGameObject; set => scoreGameObject = value; }
    public string RoundGameObject { get => roundGameObject; set => roundGameObject = value; }
    public bool ProtectedFromExtinction { get => protectedFromExtinction; set => protectedFromExtinction = value; }
    public bool ProtectedFromInvasiveAnimal { get => protectedFromInvasiveAnimal; set => protectedFromInvasiveAnimal = value; }
    public bool ProtectedFromInvasivePlant { get => protectedFromInvasivePlant; set => protectedFromInvasivePlant = value; }
    public bool NoConditionRequirements { get => noConditionRequirements; set => noConditionRequirements = value; }
    public bool ProtectedFromBlight { get => protectedFromBlight; set => protectedFromBlight = value; }
    public bool PausedOneTurn { get => pausedOneTurn; set => pausedOneTurn = value; }
    public bool ProtectedFromWeb { get => protectedFromWeb; set => protectedFromWeb = value; }
    public bool NoDiscard { get => noDiscard; set => noDiscard = value; }
    public bool DrawExtraCard { get => drawExtraCard; set => drawExtraCard = value; }
    public bool EcosystemsConnected { get => ecosystemsConnected; set => ecosystemsConnected = value; }
    public bool TwentyPointNoDiscard { get => twentyPointNoDiscard; set => twentyPointNoDiscard = value; }
    public bool ProtectedFromInvertebrate { get => protectedFromInvertebrate; set => protectedFromInvertebrate = value; }
    public int AridCount { get => aridCount; set => aridCount = value; }
    public int ForestCount { get => forestCount; set => forestCount = value; }
    public int GrasslandsCount { get => grasslandsCount; set => grasslandsCount = value; }
    public int RunningWaterCount { get => runningWaterCount; set => runningWaterCount = value; }
    public int SaltWaterCount { get => saltWaterCount; set => saltWaterCount = value; }
    public int StandingWaterCount { get => standingWaterCount; set => standingWaterCount = value; }
    public int SubZeroCount { get => subZeroCount; set => subZeroCount = value; }
    public int MountainRange { get => mountainRange; set => mountainRange = value; }
    public int TotalRegions { get => totalRegions; set => totalRegions = value; }
    public int Round { get => round; set => round = value; }
    public int RegionCounter { get => regionCounter; set => regionCounter = value; }
    public int DrawCount { get => drawCount; set => drawCount = value; }
    public string HandGameObject { get => handGameObject; set => handGameObject = value; }
    public string RegionGameObject { get => regionGameObject; set => regionGameObject = value; }
    public string ConditionGameObject { get => conditionGameObject; set => conditionGameObject = value; }
    public string PlantGameObject { get => plantGameObject; set => plantGameObject = value; }
    public string InvertebrateGameObject { get => invertebrateGameObject; set => invertebrateGameObject = value; }
    public string AnimalGameObject { get => animalGameObject; set => animalGameObject = value; }
    public string SpecialRegionGameObject { get => specialRegionGameObject; set => specialRegionGameObject = value; }
    public string MultiplayerGameObject { get => multiplayerGameObject; set => multiplayerGameObject = value; }
    public string MicrobeGameObject { get => microbeGameObject; set => microbeGameObject = value; }
    public string FungiGameObject { get => fungiGameObject; set => fungiGameObject = value; }
    public string DiscardGameObject { get => discardGameObject; set => discardGameObject = value; }
    public CardRetrievalFromDeck Holder { get => holder; set => holder = value; }
    public ScriptableObject ScriptInstance { get => scriptInstance; set => scriptInstance = value; }
    public SpriteRenderer Sr { get => sr; set => sr = value; }
    public Texture2D TexSprite { get => texSprite; set => texSprite = value; }
    public Sprite TempSprite { get => tempSprite; set => tempSprite = value; }
    public GameObject CardObject { get => cardObject; set => cardObject = value; }
    public GameObject CameraHolder { get => cameraHolder; set => cameraHolder = value; }
    public Transform CardParent { get => cardParent; set => cardParent = value; }
    public string DeckColorGameObject { get => deckColorGameObject; set => deckColorGameObject = value; }
    public string DeckTextGameObject { get => deckTextGameObject; set => deckTextGameObject = value; }
    public Image DeckColor { get => deckColor; set => deckColor = value; }
    public Text DeckText { get => deckText; set => deckText = value; }
    public string HumanGameObject { get => humanGameObject; set => humanGameObject = value; }
    public bool ThreeCardBurstAvailable { get => threeCardBurstAvailable; set => threeCardBurstAvailable = value; }
    public string HumanScoreGameObject { get => humanScoreGameObject; set => humanScoreGameObject = value; }
    public string CP1ScoreGameObject { get => cP1ScoreGameObject; set => cP1ScoreGameObject = value; }
    public string CP2ScoreGameObject { get => cP2ScoreGameObject; set => cP2ScoreGameObject = value; }
    public string CP3ScoreGameObject { get => cP3ScoreGameObject; set => cP3ScoreGameObject = value; }
    public Text HumanScoreText { get => humanScoreText; set => humanScoreText = value; }
    public Text CP1ScoreText { get => cP1ScoreText; set => cP1ScoreText = value; }
    public Text CP2ScoreText { get => cP2ScoreText; set => cP2ScoreText = value; }
    public Text CP3ScoreText { get => cP3ScoreText; set => cP3ScoreText = value; }
    public string PlayerName { get => playerName; set => playerName = value; }
}

