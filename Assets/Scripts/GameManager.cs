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
    void  Start () {
        //  sets initial round number
        round = 1;
    }

    /*
    *  @name       startGameLoop
    *  @purpose    since the main loop has a co routine wqe need this to wrap that function and choose when the coroutine is started
    *  the coroutine is being used to make a 5 second pause in the loop between each computer turn
    */
    public void startGameLoop()
    {
        //calls functionto display one card
        showOneCard.displayCard();

        //starts coroutine and calls gameloop function
        StartCoroutine(gameLoop());
    }

    /*
    *  @name       gameLoop
    *  @purpose    main loop for game
    */
    IEnumerator gameLoop()
    {
        //whitout this swt to 1 it measn it is set to 0 and the loop doesnt functio correctly there must be some parameter set in the inspector that has this set to 1
        Time.timeScale = 1;
       //creates a wait of 5 seconds each time the loop is executed
         WaitForSeconds wait = new WaitForSeconds(1.0f);
        //loop to go through each computer and changes screens
        for (int computerNum = 1; computerNum <= 3; computerNum++)
        {
            //shows cp1 board
            if (computerNum == 1)
            {
                Debug.Log("worked cp1");
                showBoards.ShowCP1();

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
        round = 1;
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

