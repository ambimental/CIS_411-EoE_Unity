using System.Collections;
using System.Collections.Generic;
//using System.Threading.Tasks; //not supported in this language specification
using UnityEngine;
using UnityEngine.UI;

public class CP1AI : MonoBehaviour
{

    //variables
    private CardRetrievalFromDeck holder;
    private ScriptableObject scriptInstance;
    private SpriteRenderer sr;
    public GameObject Hand;
    public Texture2D texSprite;
    public Sprite tempSprite;
    private GameObject cardObject;
    public GameObject cameraHolder; //will be used to hold the main camera object for creating and destoying scripts

    public HideShowBoards changePlayer; //will just be used to go to the next player

    public Card drawnCard; //will be sued to store the card that was just drawn

    public RequirementsCP1 cardReqs; //to call the reqs function
    public ReqsCP1 reqs;

    public bool requirementsWork; //will help determine if the card should be placed or not

    public Transform cardParent; //to get the parent of the card

    public CP2AI cP2; //to call the next function
    public CP1AI cp1;

    public bool waits = false;

    public int round;
    public Text cp1Round;

    public int extraDraw;

    public bool perform = false; //will determine if the function starts or not

    public ActionsCP1 cardAction;

    // Use this for initialization
    void Start()
    {

        Cursor.visible = false; //hides the mouse from the user
        Cursor.lockState = CursorLockMode.Locked; //you cannot use the cursor

        scriptInstance = ScriptableObject.CreateInstance("CardRetrievalFromDeck"); //so you can use the script
        holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>(); //access to script
        changePlayer = GameObject.Find("Main Camera").GetComponent<HideShowBoards>(); //to change players
        cameraHolder = GameObject.Find("Main Camera"); //sets the object to just the main camera

        if (GameManager.Instance.round == 1) //only happens in the first round
        {
            for (int i = 0; i < 5; i++)
            {
                holder.drawCP1Deck(); //adds the cards to the computers hand

                //draws a card and puts it into the hand
                cardParent = GameManager.Instance.cp1AI;
                holder.cardNameHolder = "back_of_card";
                generateCardObject();
                holder.setSpriteCP1(sr); //generating the card object to be placed into the panel
            }
        }

        StartCoroutine("computerPerforms"); //goes through the function needed for the AI
    }

    // Update is called once per frame
    void Update()
    { 

    }

    //Function that  is used to create an object to represent the card
    private void generateCardObject()
    {
        //creating a new gameobject  to hold act as the card
        cardObject = new GameObject(holder.cardNameHolder, typeof(RectTransform));
        //creating a SpriteRenderer to hold the card's Sprite
        sr = cardObject.AddComponent<SpriteRenderer>();
        //setting the rectangle size  of the card object
        cardObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 120);
        //adding a collider to the card object, which is sized based on the rectangle size
        cardObject.AddComponent<BoxCollider2D>().size = cardObject.GetComponent<RectTransform>().sizeDelta;
        //setting the card object's parent to be the Hand, so that it will render in the player's hand
        cardObject.transform.SetParent(cardParent);
        //setting the localScale of the card object, so that it will be appropriately sized
        cardObject.transform.localScale = new Vector3(1f, 1f, 0);
        //adding the HoverClass script to the card object, which allows for hover functionality.
        cardObject.AddComponent<HoverClass>();

        //to allow mouse to go through the sprite to view what is behind it
        cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
    }

    private void generateDiscardObject()
    {
        //creating a new gameobject  to hold act as the card
        cardObject = new GameObject(holder.cardNameHolder, typeof(RectTransform));
        //creating a SpriteRenderer to hold the card's Sprite
        sr = cardObject.AddComponent<SpriteRenderer>();
        //setting the rectangle size  of the card object
        cardObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 120);
        //adding a collider to the card object, which is sized based on the rectangle size
        cardObject.AddComponent<BoxCollider2D>().size = cardObject.GetComponent<RectTransform>().sizeDelta;
        //setting the card object's parent to be the Hand, so that it will render in the player's hand
        cardObject.transform.SetParent(cardParent);
        //setting the localScale of the card object, so that it will be appropriately sized
        cardObject.transform.localScale = new Vector3(1.0f, 1.0f, 0);
        //adding the HoverClass script to the card object, which allows for hover functionality.
        cardObject.AddComponent<HoverClass>();

        //to allow mouse to go through the sprite to view what is behind it
        cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
    }

    //where teh card things will take place
    IEnumerator computerPerforms()
    {

        changePlayer.ShowCP1();

        if (GameManager.Instance.getCP1TotalRegions() < 5) //will determine how many cards they draw based on regions
        {
            holder.drawCP1Deck(); //draws a card every roun
        }
        else if(GameManager.Instance.getCP1TotalRegions() < 10) //2 cards drawn
        {
            int count = 0;

            while(count < 2)
            {
                holder.drawCP1Deck();
                count++;
            }
        }
        else if(GameManager.Instance.getCP1TotalRegions() < 15) //3 cards drawn
        {
            int count = 0;

            while (count < 3)
            {
                holder.drawCP1Deck();
                count++;
            }
        }
        else if(GameManager.Instance.getCP1TotalRegions() < 20) //4 cards drawn
        {
            int count = 0;

            while (count < 4)
            {
                holder.drawCP1Deck();
                count++;
            }
        }

        //draws a card and puts it into the hand
        cardParent = GameObject.Find("Computer One Board/CP1Hand").transform;
        holder.cardNameHolder = "back_of_card";
        generateCardObject();
        holder.setSpriteCP1(sr); //generating the card object to be placed into the panel

        //add the check for more than 5 region cards here

        //this is where the requirements will be checked
        for (int z = GameManager.Instance.HandCP1.Count - 1; z > -1; z--) //done this way to avoid exception
        {

            for(int i = 0; i < 20; i++)
            {
                yield return null;
            }

            if (GameManager.Instance.HandCP1[z].ReqID.Count != 0)
            {
                cardReqs = GameObject.Find("Main Camera").GetComponent<RequirementsCP1>();

                if (cardReqs.requirementCheck(GameManager.Instance.HandCP1[z])) //determines if they work or not
                    requirementsWork = true;
                else requirementsWork = false;
            }
            else
            {
                requirementsWork = true; //allows it to be played
            }

            if (requirementsWork == true)
            {
                if (GameManager.Instance.HandCP1[z].CardType == "Region") //puts the card into the region placement
                {
                    cardParent = GameObject.Find("Computer One Board/Region Card Placement").transform;
                    holder.cardNameHolder = GameManager.Instance.HandCP1[z].CardName;
                    generateCardObject();
                    holder.setSpriteCP1(sr); //generating the card object to be placed into the panel

                    GameManager.Instance.changeComputerOneScore(GameManager.Instance.HandCP1[z].PointValue);

                    GameManager.Instance.RegionPlacementCP1.Add(GameManager.Instance.HandCP1[z]); //adds it to the regions

                    //checks the region type and changes the variable accordingly
                    if (GameManager.Instance.HandCP1[z].CardName.Contains("Arid"))
                        GameManager.Instance.cp1AridCount++;
                    else if (GameManager.Instance.HandCP1[z].CardName.Contains("Forest"))
                        GameManager.Instance.cp1ForestCount++;
                    else if (GameManager.Instance.HandCP1[z].CardName.Contains("Grasslands"))
                        GameManager.Instance.cp1GrasslandsCount++;
                    else if (GameManager.Instance.HandCP1[z].CardName.Contains("Running-Water"))
                        GameManager.Instance.cp1RunningWaterCount++;
                    else if (GameManager.Instance.HandCP1[z].CardName.Contains("Salt-Water"))
                        GameManager.Instance.cp1SaltWaterCount++;
                    else if (GameManager.Instance.HandCP1[z].CardName.Contains("Standing-Water"))
                        GameManager.Instance.cp1StandingWaterCount++;
                    else if (GameManager.Instance.HandCP1[z].CardName.Contains("Sub-Zero"))
                        GameManager.Instance.cp1SubZeroCount++;

                    GameManager.Instance.HandCP1.Remove(GameManager.Instance.HandCP1[z]);

                    cardParent = GameObject.Find("Computer One Board/CP1Hand").transform;

                    //to keep from a null excpetion error
                    if(GameManager.Instance.HandCP1.Count > 0)
                        Destroy(cardParent.GetChild(0).gameObject);
                }
                else if (GameManager.Instance.HandCP1[z].CardType == "Condition") //puts the card into the condition card
                {
                    cardParent = GameObject.Find("Computer One Board/Condition Card Placement").transform;
                    holder.cardNameHolder = GameManager.Instance.HandCP1[z].CardName;
                    generateCardObject();
                    holder.setSpriteCP1(sr); //generating the card object to be placed into the panel

                    GameManager.Instance.changeComputerOneScore(GameManager.Instance.HandCP1[z].PointValue);

                    GameManager.Instance.ConditionPlacementCP1.Add(GameManager.Instance.HandCP1[z]); //adds it to the regions

                    GameManager.Instance.HandCP1.Remove(GameManager.Instance.HandCP1[z]);

                    cardParent = GameObject.Find("Computer One Board/CP1Hand").transform;

                    if (cardParent.childCount != 0)
                        Destroy(cardParent.GetChild(0).gameObject);
                }
                else if (GameManager.Instance.HandCP1[z].CardType == "Plant") //puts the card into the plant type
                {
                    cardParent = GameObject.Find("Computer One Board/Plant Card Placement").transform;
                    holder.cardNameHolder = GameManager.Instance.HandCP1[z].CardName;
                    generateCardObject();
                    holder.setSpriteCP1(sr); //generating the card object to be placed into the panel

                    GameManager.Instance.changeComputerOneScore(GameManager.Instance.HandCP1[z].PointValue);

                    GameManager.Instance.PlantPlacementCP1.Add(GameManager.Instance.HandCP1[z]); //adds it to the regions

                    GameManager.Instance.HandCP1.Remove(GameManager.Instance.HandCP1[z]);

                    cardParent = GameObject.Find("Computer One Board/CP1Hand").transform;

                    //to avoid a null exception error
                    if(cardParent.childCount != 0)
                        Destroy(cardParent.GetChild(0).gameObject);
                }
                else if (GameManager.Instance.HandCP1[z].CardType == "Invertebrate") //puts the card into the invertebrate pile
                {
                    cardParent = GameObject.Find("Computer One Board/Invertebrate Card Placement").transform;
                    holder.cardNameHolder = GameManager.Instance.HandCP1[z].CardName;
                    generateCardObject();
                    holder.setSpriteCP1(sr); //generating the card object to be placed into the panel

                    GameManager.Instance.changeComputerOneScore(GameManager.Instance.HandCP1[z].PointValue);

                    GameManager.Instance.InvertebratePlacementCP1.Add(GameManager.Instance.HandCP1[z]); //adds it to the regions

                    GameManager.Instance.HandCP1.Remove(GameManager.Instance.HandCP1[z]);

                    cardParent = GameObject.Find("Computer One Board/CP1Hand").transform;

                    if(cardParent.childCount != 0)
                        Destroy(cardParent.GetChild(0).gameObject);
                }
                else if (GameManager.Instance.HandCP1[z].CardType == "Animal") //puts the cards into the animal pile
                {
                    cardParent = GameObject.Find("Computer One Board/Animal Card Placement").transform;
                    holder.cardNameHolder = GameManager.Instance.HandCP1[z].CardName;
                    generateCardObject();
                    holder.setSpriteCP1(sr); //generating the card object to be placed into the panel

                    GameManager.Instance.changeComputerOneScore(GameManager.Instance.HandCP1[z].PointValue);

                    GameManager.Instance.AnimalPlacementCP1.Add(GameManager.Instance.HandCP1[z]); //adds it to the regions

                    GameManager.Instance.HandCP1.Remove(GameManager.Instance.HandCP1[z]);

                    cardParent = GameObject.Find("Computer One Board/CP1Hand").transform;

                    if(cardParent.childCount != 0)
                        Destroy(cardParent.GetChild(0).gameObject);
                }
                else if (GameManager.Instance.HandCP1[z].CardType == "Special Region") //puts the card into the special region pile
                {
                    cardParent = GameObject.Find("Computer One Board/Special Region Placement").transform;
                    holder.cardNameHolder = GameManager.Instance.HandCP1[z].CardName;
                    generateCardObject();
                    holder.setSpriteCP1(sr); //generating the card object to be placed into the panel

                    GameManager.Instance.changeComputerOneScore(GameManager.Instance.HandCP1[z].PointValue);

                    GameManager.Instance.SpecialRegionPlacementCP1.Add(GameManager.Instance.HandCP1[z]); //adds it to the regions

                    GameManager.Instance.HandCP1.Remove(GameManager.Instance.HandCP1[z]);

                    cardParent = GameObject.Find("Computer One Board/CP1Hand").transform;

                    if (cardParent.childCount != 0)
                        Destroy(cardParent.GetChild(0).gameObject);
                }
                else if (GameManager.Instance.HandCP1[z].CardType == "Multi-Player") //puts the card into the multiplayer pile
                {
                    cardParent = GameObject.Find("Computer One Board/Multiplayer Card Placement").transform;
                    holder.cardNameHolder = GameManager.Instance.HandCP1[z].CardName;
                    generateCardObject();
                    holder.setSpriteCP1(sr); //generating the card object to be placed into the panel

                    GameManager.Instance.changeComputerOneScore(GameManager.Instance.HandCP1[z].PointValue);

                    GameManager.Instance.MultiPlacementCP1.Add(GameManager.Instance.HandCP1[z]); //adds it to the regions

                    GameManager.Instance.HandCP1.Remove(GameManager.Instance.HandCP1[z]);

                    cardParent = GameObject.Find("Computer One Board/CP1Hand").transform;

                    if (cardParent.childCount != 0)
                        Destroy(cardParent.GetChild(0).gameObject);
                }
                else if (GameManager.Instance.HandCP1[z].CardType == "Microbe") //puts the card into the microbe pile
                {
                    cardParent = GameObject.Find("Computer One Board/Microbe Card Placement").transform;
                    holder.cardNameHolder = GameManager.Instance.HandCP1[z].CardName;
                    generateCardObject();
                    holder.setSpriteCP1(sr); //generating the card object to be placed into the panel

                    GameManager.Instance.changeComputerOneScore(GameManager.Instance.HandCP1[z].PointValue);

                    GameManager.Instance.MicrobePlacementCP1.Add(GameManager.Instance.HandCP1[z]); //adds it to the regions

                    GameManager.Instance.HandCP1.Remove(GameManager.Instance.HandCP1[z]);

                    cardParent = GameObject.Find("Computer One Board/CP1Hand").transform;

                    if (cardParent.childCount != 0)
                        Destroy(cardParent.GetChild(0).gameObject);
                }
                else if (GameManager.Instance.HandCP1[z].CardType == "Fungi") //puts the card into the fungi pile
                {
                    cardParent = GameObject.Find("Computer One Board/Fungi Card Placement").transform;
                    holder.cardNameHolder = GameManager.Instance.HandCP1[z].CardName;
                    generateCardObject();
                    holder.setSpriteCP1(sr); //generating the card object to be placed into the panel

                    GameManager.Instance.changeComputerOneScore(GameManager.Instance.HandCP1[z].PointValue);

                    GameManager.Instance.FungiPlacementCP1.Add(GameManager.Instance.HandCP1[z]); //adds it to the regions

                    GameManager.Instance.HandCP1.Remove(GameManager.Instance.HandCP1[z]);

                    cardParent = GameObject.Find("Computer One Board/CP1Hand").transform;

                    if (cardParent.childCount != 0)
                        Destroy(cardParent.GetChild(0).gameObject);
                }
            }
        }

        if (GameManager.Instance.HandCP1.Count != 0) //if there is a card left in the hand, it will discad the fits one
        {
            cardParent = GameObject.Find("Computer One Board/Discard Pile Placement").transform;
            holder.cardNameHolder = GameManager.Instance.HandCP1[0].CardName;
            generateDiscardObject();
            holder.setSpriteCP1(sr);

            GameManager.Instance.DiscardPlacementCP1.Add(GameManager.Instance.HandCP1[0]);
            GameManager.Instance.HandCP1.Remove(GameManager.Instance.HandCP1[0]);

            cardParent = GameObject.Find("Computer One Board/CP1Hand").transform;

            if (cardParent.childCount != 0)
                Destroy(cardParent.GetChild(0).gameObject);

            for (int i = 0; i < 20; i++)
            {
                yield return null;
            }

            nextPlayer();

            cameraHolder.AddComponent<CP2AI>(); //adds the script to the main camera so that the player 2 AI starts

            Object.Destroy(cameraHolder.GetComponent<CP1AI>()); //destryos the cp1 script
        }
        else //if there are no cards left in the hand, will just automatically go to the next player
        {
            for (int i = 0; i < 20; i++)
            {
                yield return null;
            }

            nextPlayer();

            cameraHolder.AddComponent<CP2AI>(); //adds the script to the main camera so that the player 2 AI starts

            Object.Destroy(cameraHolder.GetComponent<CP1AI>()); //destryos the cp1 script
        }
    }

    //will be called in the above function whenever they are ready to move on
    public void nextPlayer()
    {
        changePlayer.ShowCP2(); //goes to the next player
    }
}
