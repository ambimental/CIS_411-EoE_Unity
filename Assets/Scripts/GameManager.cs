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
using System;


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

    //  create playerView and playerCanvas objects
    public GameObject playerView;
    public CanvasGroup playerCanvas;

    //  stores round number
<<<<<<< Updated upstream
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
    //we may not need these variables we can probably just use one round varibale since we will all always be on same round
    public Text playerRound;
    public Text oneRound;
    public Text twoRound;
    public Text threeRound;

    //  stores values for player score information
    public Text pScore;
    public Text oneScore;
    public Text twoScore;
    public Text threeScore;
    //  button to end turn
    public Button endTurnButton;

    //created object to access funstionc for hide show boards
    public HideShowBoards showBoards;

    //Creates object to show card
    public DisplayOneCard showOneCard;
=======
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
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
    void  Start () {
        //  sets initial round number
        round = 1;
=======
    void Start () {

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
            "Plant Card Placement", "Invertebrate Card Placement", "Animal Card Placement", "Special Region Placement", "Multiplayer Card Placement",
            "Microbe Card Placement", "Fungi Card Placement", "Discard Pile Placement", "Human Card Placement", "PlayerColor", "PlayerDeckText", 
            "PlayerScoreText", "ComputerOneScoreText", "ComputerTwoScoreText", "ComputerThreeScoreText", "Person");

        //Initilizing CP1 Player
        CP1GO = new GameObject("CP1");
        CP1GO.AddComponent<Computer>();
        CP1 = GameObject.Find("CP1").GetComponent<Computer>();
        CP1.InitializeObjects("Computer One Board/Main Images and Placements/Computer1Button/ComputerOneScoreText", "Computer One Board/Main Images and Placements/ComputerOneRoundText", 
            "Computer One Board/CP1Hand", "Computer One Board/Region Card Placement", "Computer One Board/Condition Card Placement", "Computer One Board/Plant Card Placement", 
            "Computer One Board/Invertebrate Card Placement", "Computer One Board/Animal Card Placement", "Computer One Board/Special Region Placement", 
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
            "Computer Two Board/Invertebrate Card Placement", "Computer Two Board/Animal Card Placement", "Computer Two Board/Special Region Placement",
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
            "Computer Three Board/Invertebrate Card Placement", "Computer Three Board/Animal Card Placement", "Computer Three Board/Special Region Placement", 
            "Computer Three Board/Multiplayer Card Placement", "Computer Three Board/Microbe Card Placement", "Computer Three Board/Fungi Card Placement", 
            "Computer Three Board/Discard Pile Placement", "Computer Three Board/Human Card Placement", "CP3Color", "CP3DeckText", "Computer Three Board/Main Images and Placements/PlayerButton/PlayerScoreText",
            "Computer Three Board/Main Images and Placements/Computer1Button/ComputerOneScoreText", "Computer Three Board/Main Images and Placements/Computer2Button/ComputerTwoScoreText",
            "Computer Three Board/Main Images and Placements/Computer3Button/ComputerThreeScoreText","CP3");

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
>>>>>>> Stashed changes
    }


    /*
<<<<<<< Updated upstream
    *  @name       startGameLoop
    *  @purpose    since the main loop has a co routine wqe need this to wrap that function and choose when the coroutine is started
    *  the coroutine is being used to make a 5 second pause in the loop between each computer turn
    */
    public void startGameLoop()
=======
     *  @name       CreateBoards()
     *  @purpose    Assigns the correct game objects to create an isntance of hideshow boards to change screens there is one 
     *  created ere and one created in the editor attached to the avatar buttons but this is serparate from that
     */
    public void CreateBoards()
>>>>>>> Stashed changes
    {
        //calls functionto display one card
        showOneCard.displayCard();

<<<<<<< Updated upstream
        //starts coroutine and calls gameloop function
        StartCoroutine(gameLoop());
=======
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
            CP1.StartTurn();
        }
        else if (pPlayerName == "CP1")
        {
            HideShow.ShowCP2();
            CP2.StartTurn();
        }
        else if (pPlayerName == "CP2")
        {
            HideShow.ShowCP3();
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
>>>>>>> Stashed changes
    }

    /*
    *  @name       gameLoop
    *  @purpose    main loop for game
    */
    IEnumerator gameLoop()
    {
<<<<<<< Updated upstream
        //whitout this swt to 1 it measn it is set to 0 and the loop doesnt functio correctly there must be some parameter set in the inspector that has this set to 1
        Time.timeScale = 1;
       //creates a wait of 5 seconds each time the loop is executed
         WaitForSeconds wait = new WaitForSeconds(1.0f);
        //loop to go through each computer and changes screens
        for (int computerNum = 1; computerNum <= 3; computerNum++)
=======
        if (round == 1)
>>>>>>> Stashed changes
        {
            //shows cp1 board
            if (computerNum == 1)
            {
                Debug.Log("worked cp1");
                showBoards.ShowCP1();

<<<<<<< Updated upstream
            }
            //shows cp2 board
            else if (computerNum == 2)
            {
                Debug.Log("worked c2");
                showBoards.ShowCP2();
            }
            //shows cp3 board
            else if (computerNum == 3)
            {
                Debug.Log("worked c3");
                showBoards.ShowCP3();
            }

            //this is how we implement the pause in the loop 
            yield return wait;
        }
        //shows players board
        Debug.Log("play work");
        showBoards.ShowPlayer();

        //changes scores and round
        changePlayerScore(playerScore);
        changeComputerOneScore(computerOneScore);
        changeComputerTwoScore(computerTwoScore);
        changeComputerThreeScore(computerThreeScore);
        changeRound();
    }
=======
>>>>>>> Stashed changes

    /*
     *  @name       winOrLose
     *  @purpose    determins who wins
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
<<<<<<< Updated upstream
        round = 1;
=======
        Round = 1;

        //  clear human and computer player hands
        Person.Hand.Clear();
        CP1.Hand.Clear();
        CP2.Hand.Clear();
        CP3.Hand.Clear();
>>>>>>> Stashed changes
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
            //  end game; 
            winOrLose();
        }
    }

<<<<<<< Updated upstream
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

}

=======
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
}

>>>>>>> Stashed changes
