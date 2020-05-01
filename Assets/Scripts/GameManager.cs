/*
 *  @class      GameManager.cs
 *  @purpose    Manages turn-by-turn game loop and game-critical functions
 *  
 *  @author     CIS411
 *  @date       2020/04/10
 */

 //This game manager shiuld be created when the loading screen scene is on and right now is created in the playerboard scene main camera. 
 //We did this because the objects of human and computers were being created only in the loading screen seen and we need it in the playerboard and ran out of time

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

    //this is currently what populated our cards
    public phpImport importer;
    //im not sure what this is used for yet but ill kep it around until i figure it out
    public bool ecosystemsConnected = false;

    //these are the colors that wil be assigned to the decks
    private Color32 appalachianColor;
    private Color32 alleghenyColor;
    private Color32 clarionRiverColor;
    private Color32 peatBogsColor;

    //these are the names that will be assigned to the decks
    private string allegheny;
    private string appalachian;
    private string peat;
    private string clarion;

    /*****************************************************************************/
    /*****************************************************************************/
    /*EVERYTHING BELPOW HERE REGAURDING OBJECTS AND VARIABLES WILL DEFINATELY BE 
     * STAYING IN THE GAME MANAGER CLASS, EVERYTHING ABOVE WILL PROBABLY BE DELETED
     */
    /*****************************************************************************/
    /*****************************************************************************/

    //  create list to hold Deck IDs
    private List<string> deckIds = new List<string>();
    //  create list to hold individual decks until they are assigned to players
    private List<Deck> decks = new List<Deck>();

    //  stores round number
    private int round;

    //  stores sorting layers used throughout different classes to display objects in front of everything
    private int sortingOrder = 10;

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

        Debug.Log("GameManagerCreated");
        //populates DeckId Class and then creates decks and populates the decklist
        CreateDecks();

        //populates decks in deck list
        gameObject.AddComponent<phpImport>();

        //  sets initial round number
        Round = 1;

        //this is how we inialize objects
        //initializing Human Person Player
        PersonGO = new GameObject("Person");
        PersonGO.AddComponent<Human>();
        Person = GameObject.Find("Person").GetComponent<Human>();
        Person.InitializeObjects("PlayerScoreText", "PlayerRoundText", "Hand", "Region Card Placement", "Condition Card Placement", 
            "Plant Card Placement", "Invertebrate Card Placement", "Animal Card Placement", "Special Region Card Placement", "Multiplayer Card Placement",
            "Microbe Card Placement", "Fungi Card Placement", "Discard Pile Placement", "Human Card Placement", "PlayerColor", "PlayerDeckText", 
            "PlayerScoreText", "ComputerOneScoreText", "ComputerTwoScoreText", "ComputerThreeScoreText", "Person");

        //Initilizing CP1 Player
        CP1GO = new GameObject("CP1");
        CP1GO.AddComponent<Computer>();
        CP1 = GameObject.Find("CP1").GetComponent<Computer>();
        CP1.InitializeObjects("Computer One Board/Main Images and Placements/Computer1Button/ComputerOneScoreText", "Computer One Board/Main Images and Placements/ComputerOneRoundText", 
            "Computer One Board/CP1Hand", "Computer One Board/Region Card Placement", "Computer One Board/Condition Card Placement", "Computer One Board/Plant Card Placement", 
            "Computer One Board/Invertebrate Card Placement", "Computer One Board/Animal Card Placement", "Computer One Board/Special Region Card Placement", 
            "Computer One Board/Multiplayer Card Placement", "Computer One Board/Microbe Card Placement", "Computer One Board/Fungi Card Placement", 
            "Computer One Board/Discard Pile Placement", "Computer One Board/Human Card Placement", "CP1Color", "CP1DeckText", "Computer One Board/Main Images and Placements/PlayerButton/PlayerScoreText",
            "Computer One Board/Main Images and Placements/Computer1Button/ComputerOneScoreText", "Computer One Board/Main Images and Placements/Computer2Button/ComputerTwoScoreText",
            "Computer One Board/Main Images and Placements/Computer3Button/ComputerThreeScoreText", "CP1");

        //Initilizing CP2 Player
        CP2GO = new GameObject("CP2");
        CP2GO.AddComponent<Computer>();
        CP2 = GameObject.Find("CP2").GetComponent<Computer>();
        CP2.InitializeObjects("Computer Two Board/Main Images and Placements/Computer2Button/ComputerTwoScoreText", "Computer Two Board/Main Images and Placements/ComputerTwoRoundText", "Computer Two Board/CP2Hand",
            "Computer Two Board/Region Card Placement", "Computer Two Board/Condition Card Placement", "Computer Two Board/Plant Card Placement",
            "Computer Two Board/Invertebrate Card Placement", "Computer Two Board/Animal Card Placement", "Computer Two Board/Special Region Card Placement",
            "Computer Two Board/Multiplayer Card Placement", "Computer Two Board/Microbe Card Placement", "Computer Two Board/Fungi Card Placement",
            "Computer Two Board/Discard Pile Placement", "Computer Two Board/Human Card Placement", "CP2Color", "CP2DeckText", "Computer Two Board/Main Images and Placements/PlayerButton/PlayerScoreText",
            "Computer Two Board/Main Images and Placements/Computer1Button/ComputerOneScoreText", "Computer Two Board/Main Images and Placements/Computer2Button/ComputerTwoScoreText",
            "Computer Two Board/Main Images and Placements/Computer3Button/ComputerThreeScoreText1", "CP2");

        //Initilizing CP3 Player
        CP3GO = new GameObject("CP3");
        CP3GO.AddComponent<Computer>();
        CP3 = GameObject.Find("CP3").GetComponent<Computer>();
        CP3.InitializeObjects("Computer Three Board/Main Images and Placements/Computer3Button/ComputerThreeScoreText", "Computer Three Board/Main Images and Placements/ComputerThreeRoundText", "Computer Three Board/CP3Hand", 
            "Computer Three Board/Region Card Placement", "Computer Three Board/Condition Card Placement", "Computer Three Board/Plant Card Placement", 
            "Computer Three Board/Invertebrate Card Placement", "Computer Three Board/Animal Card Placement", "Computer Three Board/Special Region Card Placement", 
            "Computer Three Board/Multiplayer Card Placement", "Computer Three Board/Microbe Card Placement", "Computer Three Board/Fungi Card Placement", 
            "Computer Three Board/Discard Pile Placement", "Computer Three Board/Human Card Placement", "CP3Color", "CP3DeckText", "Computer Three Board/Main Images and Placements/PlayerButton/PlayerScoreText",
            "Computer Three Board/Main Images and Placements/Computer1Button/ComputerOneScoreText", "Computer Three Board/Main Images and Placements/Computer2Button/ComputerTwoScoreText",
            "Computer Three Board/Main Images and Placements/Computer3Button/ComputerThreeScoreText","CP3");



        /******************************************************/
        /******************************************************/
        //this will all be moved to the pick deck class but for now we have the game manager being created from the main camera inthe playerboard scene
        //hard codes deck for now
        Person.Deck = Decks[0];
        CP1.Deck = Decks[1];
        CP2.Deck = Decks[2];
        CP3.Deck = Decks[3];

        //instantiates colors and names
        AppalachianColor = new Color32(166, 135, 82, 128);
        AlleghenyColor = new Color32(58, 102, 44, 128);
        ClarionRiverColor = new Color32(116, 126, 140, 128);
        PeatBogsColor = new Color32(124, 56, 58, 128);
        Allegheny = "Allegheny National Forest";
        Appalachian = "Appalachian Homestead";
        Peat = "Peat Bogs";
        Clarion = "Clarion River";

        //sets human card values
        Person.Deck.DeckName = Allegheny;
        Person.Deck.DeckColor = AlleghenyColor;
        CP1.Deck.DeckName = Appalachian;
        CP1.Deck.DeckColor = AppalachianColor;
        CP2.Deck.DeckName = Peat;
        CP2.Deck.DeckColor = PeatBogsColor;
        CP3.Deck.DeckName = Clarion;
        CP3.Deck.DeckColor = ClarionRiverColor;     
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


    /*
     *  @name       CreateBoards()
     *  @purpose    Assigns the correct game objects to create an isntance of hideshow boards to change screens there is one 
     *  created ere and one created in the editor attached to the avatar buttons but this is serparate from that
     */
    public void CreateBoards()
    {
        HideShowGO = new GameObject("HideShow");
        HideShowGO.AddComponent<HideShowBoards>();
        HideShow = GameObject.Find("HideShow").GetComponent<HideShowBoards>();
    }

    /*
     *  @name       NextPlayer()
     *  @purpose    This function is used to change the canvas and is basically the game loop. at teh end of each players turn this is called. 
     *  For the human it is called when a card is discarded. for a computer it is called at the end of the courtine.
     *  
     */
    public void NextPlayer(string pPlayerName)
    {
        //quickly goes through each canvas and sets the correct score values that way they are all up to date
        HideShow.ShowPlayer();
        Person.ChangeAllScore();
        HideShow.ShowCP3();
        CP3.ChangeAllScore();
        HideShow.ShowCP2();
        CP2.ChangeAllScore();
        HideShow.ShowCP1();
        CP1.ChangeAllScore();

        //goes through each player and executes accordingly
        if (pPlayerName == "Person")
        {
            //Cursor.visible = false; //hides the mouse from the user
            //Cursor.lockState = CursorLockMode.Locked; //you cannot use the cursor  
            HideShow.ShowCP1();
            CP1.CreateDeckInfo();
            CP1.StartTurn();

        }
        else if (pPlayerName == "CP1")
        {
            HideShow.ShowCP2();
            CP2.CreateDeckInfo();
            CP2.StartTurn();
        }
        else if (pPlayerName == "CP2")
        {
            HideShow.ShowCP3();
            CP3.CreateDeckInfo();
            CP3.StartTurn();
        }
        else if (pPlayerName == "CP3")
        {
            //updates the game manager round
            UpdateRound();
            //shows mouse
            Cursor.visible = true;
            //enables mouse
            Cursor.lockState = CursorLockMode.None;
            //shows the human player
            HideShow.ShowPlayer();
            //after the round has changed the player can draw again
            Person.CanDraw = true;
            //starts the players turn automatically 
            Person.StartTurn();
        }
    }

    /*
     *  @name       StartHumanTurn()
     *  @purpose   Starts teh human turn
     *  Note: in order for any UI to be manipulated it the canvas or scene which the object that is being accessed on needs to be visible
     */
    public void StartHumanTurn()
    {
        if (round == 1)
        {
            CreateBoards(); 
            Person.CreateDeckInfo();

        }
            //starts the players loop
            Person.StartTurn();
    }


    /*
     *  @name       winOrLose
     *  @purpose    determines whether the human player has won or lost
     */
    public void winOrLose()
    {
        //  if human playerScore is less than computer player scores
        if (Person.Score < CP1.Score || Person.Score < CP2.Score || Person.Score < CP3.Score)
        {
            //  load game-lose screen
            SceneManager.LoadScene("LoseScene");
        }
        else
        {
            //  load game-win screen
            SceneManager.LoadScene("WinScene");
        }

        //  resets round number
        Round = 1;

        //  clear human and computer player hands
        Person.Hand.Clear();
        CP1.Hand.Clear();
        CP2.Hand.Clear();
        CP3.Hand.Clear();
    }

    /*
     *  @name       restartGame()
     *  @purpose    on new game, destroy GameManager object and create a new one
     *  This is called in the change scene and if it is the loading screen this function is called
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
        if (Round != 10)
        {
            //  increment round number
            Round++;
        }
        //  if round number is 10
        else if (Round == 10)
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
    public int Round { get => round; set => round = value; }
    public int SortingOrder { get => sortingOrder; set => sortingOrder = value; }
    public List<string> DeckIds { get => deckIds; set => deckIds = value; }
    public List<Deck> Decks { get => decks; set => decks = value; }
    public Color32 AppalachianColor { get => appalachianColor; set => appalachianColor = value; }
    public Color32 AlleghenyColor { get => alleghenyColor; set => alleghenyColor = value; }
    public Color32 ClarionRiverColor { get => clarionRiverColor; set => clarionRiverColor = value; }
    public Color32 PeatBogsColor { get => peatBogsColor; set => peatBogsColor = value; }
    public string Allegheny { get => allegheny; set => allegheny = value; }
    public string Appalachian { get => appalachian; set => appalachian = value; }
    public string Peat { get => peat; set => peat = value; }
    public string Clarion { get => clarion; set => clarion = value; }
}

