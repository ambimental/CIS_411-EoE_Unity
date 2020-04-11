using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CP3AI : MonoBehaviour
{

    ////variables
    //private CardRetrievalFromDeck holder;
    //private ScriptableObject scriptInstance;
    //private SpriteRenderer sr;
    //public GameObject Hand;
    //public Texture2D texSprite;
    //public Sprite tempSprite;
    //private GameObject cardObject;
    //public GameObject cameraHolder; //to hold the main camera object

    //public HideShowBoards changePlayer; //will just be used to go to the next player

    //public Card drawnCard; //will be sued to store the card that was just drawn

    //public RequirementsCP3 cardReqs; //to call the reqs function
    //public ReqsCP3 reqs;

    //public bool requirementsWork; //will help determine if the card should be placed or not

    //public Transform cardParent; //to get the parent of the card

    //public bool waits = false;

    //public int round;

    //public Text cp3Round; //to set the reound text

    //public int extraDraw; //will be used to determine extra draw cards based off region count

    //public int sort; //to keep track of the layer that the sprite is onso that it stacks properly

    //public ActionsCP3 cardAction;

    //// Use this for initialization
    //void Start()
    //{

    //    scriptInstance = ScriptableObject.CreateInstance("CardRetrievalFromDeck"); //so you can use the script
    //    holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>(); //access to script
    //    changePlayer = GameObject.Find("Main Camera").GetComponent<HideShowBoards>(); //to change players
    //    cameraHolder = GameObject.Find("Main Camera"); // to access the scripts of the main camera

    //    if (GameManager.Instance.round == 1) //will only happen in the first round
    //    {
    //        for (int i = 0; i < 5; i++)
    //        {
    //            holder.drawCP3Deck(); //adds the cards to the computers hand

    //            //draws a card and puts it into the hand
    //            cardParent = GameObject.Find("Computer Three Board/CP3Hand").transform;
    //            holder.cardNameHolder = "back_of_card";
    //            generateCardObject();
    //            holder.setSpriteCP1(sr); //generating the card object to be placed into the panel
    //        }
    //    }

    //    round = 0; //starts at 1, goes to 10

    //    sort = 5; //starts at 5

    //    StartCoroutine("computerPerforms");
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //}

    ////Function that  is used to create an object to represent the card
    //private void generateCardObject()
    //{
    //    //creating a new gameobject  to hold act as the card
    //    cardObject = new GameObject(holder.cardNameHolder, typeof(RectTransform));

    //    //creating a SpriteRenderer to hold the card's Sprite
    //    sr = cardObject.AddComponent<SpriteRenderer>();

    //    //setting the rectangle size  of the card object
    //    cardObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 120);
    //    //adding a collider to the card object, which is sized based on the rectangle size
    //    cardObject.AddComponent<BoxCollider2D>().size = cardObject.GetComponent<RectTransform>().sizeDelta;
    //    //setting the card object's parent to be the Hand, so that it will render in the player's hand
    //    cardObject.transform.SetParent(cardParent);
    //    //setting the localScale of the card object, so that it will be appropriately sized
    //    cardObject.transform.localScale = new Vector3(1f, 1f, 0);
    //    //adding the HoverClass script to the card object, which allows for hover functionality.
    //    cardObject.AddComponent<HoverClass>();

    //    //to allow mouse to go through the sprite to view what is behind it
    //    cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
    //}

    //private void generateDiscardObject()
    //{
    //    //creating a new gameobject  to hold act as the card
    //    cardObject = new GameObject(holder.cardNameHolder, typeof(RectTransform));
    //    //creating a SpriteRenderer to hold the card's Sprite
    //    sr = cardObject.AddComponent<SpriteRenderer>();
    //    //setting the rectangle size  of the card object
    //    cardObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 120);
    //    //adding a collider to the card object, which is sized based on the rectangle size
    //    cardObject.AddComponent<BoxCollider2D>().size = cardObject.GetComponent<RectTransform>().sizeDelta;
    //    //setting the card object's parent to be the Hand, so that it will render in the player's hand
    //    cardObject.transform.SetParent(cardParent);
    //    //setting the localScale of the card object, so that it will be appropriately sized
    //    cardObject.transform.localScale = new Vector3(1.0f, 1.0f, 0);
    //    //adding the HoverClass script to the card object, which allows for hover functionality.
    //    cardObject.AddComponent<HoverClass>();

    //    //to allow mouse to go through the sprite to view what is behind it
    //    cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
    //}

    ////where teh card things will take place
    //IEnumerator computerPerforms()
    //{
    //    if (GameManager.Instance.getCP3TotalRegions() < 5) //will determine how many cards they draw based on regions
    //    {
    //        holder.drawCP3Deck(); //draws a card every roun
    //    }
    //    else if (GameManager.Instance.getCP3TotalRegions() < 10) //2 cards drawn
    //    {
    //        int count = 0;

    //        while (count < 2)
    //        {
    //            holder.drawCP3Deck();
    //            count++;
    //        }
    //    }
    //    else if (GameManager.Instance.getCP3TotalRegions() < 15) //3 cards drawn
    //    {
    //        int count = 0;

    //        while (count < 3)
    //        {
    //            holder.drawCP3Deck();
    //            count++;
    //        }
    //    }
    //    else if (GameManager.Instance.getCP3TotalRegions() < 20) //4 cards drawn
    //    {
    //        int count = 0;

    //        while (count < 4)
    //        {
    //            holder.drawCP3Deck();
    //            count++;
    //        }
    //    }

    //    //draws a card and puts it into the hand
    //    cardParent = GameObject.Find("Computer Three Board/CP3Hand").transform;
    //    holder.cardNameHolder = "back_of_card";
    //    generateCardObject();
    //    holder.setSpriteCP1(sr); //generating the card object to be placed into the panel

    //    //add the check for more than 5 region cards here

    //    //this is where the requirements will be checked
    //    for (int z = GameManager.Instance.HandCP3.Count - 1; z > -1; z--) //done this way to avoid exception
    //    {

    //        for (int i = 0; i < 20; i++)
    //        {
    //            yield return null;
    //        }

    //        if (GameManager.Instance.HandCP3[z].ReqID.Count != 0)
    //        {
    //            cardReqs = GameObject.Find("Main Camera").GetComponent<RequirementsCP3>();

    //            if (cardReqs.requirementCheck(GameManager.Instance.HandCP3[z])) //determines if they work or not
    //                requirementsWork = true;
    //            else requirementsWork = false;
    //        }
    //        else
    //        {
    //            requirementsWork = true; //allows it to be played
    //        }

    //        if (requirementsWork == true)
    //        {
    //            if (GameManager.Instance.HandCP3[z].CardType == "Region") //puts the card into the region placement
    //            {
    //                cardParent = GameObject.Find("Computer Three Board/Region Card Placement").transform;
    //                holder.cardNameHolder = GameManager.Instance.HandCP3[z].CardName;
    //                generateCardObject();
    //                holder.setSpriteCP3(sr);//generating the card object to be placed into the panel

    //                GameManager.Instance.changeComputerThreeScore(GameManager.Instance.HandCP3[z].PointValue);

    //                GameManager.Instance.RegionPlacementCP3.Add(GameManager.Instance.HandCP3[z]); //adds it to the regions

    //                //checks the region type and changes the variable accordingly
    //                if (GameManager.Instance.HandCP3[z].CardName.Contains("Arid"))
    //                    GameManager.Instance.cp3AridCount++;
    //                else if (GameManager.Instance.HandCP3[z].CardName.Contains("Forest"))
    //                    GameManager.Instance.cp3ForestCount++;
    //                else if (GameManager.Instance.HandCP3[z].CardName.Contains("Grasslands"))
    //                    GameManager.Instance.cp3GrasslandsCount++;
    //                else if (GameManager.Instance.HandCP3[z].CardName.Contains("Running-Water"))
    //                    GameManager.Instance.cp3RunningWaterCount++;
    //                else if (GameManager.Instance.HandCP3[z].CardName.Contains("Salt-Water"))
    //                    GameManager.Instance.cp3SaltWaterCount++;
    //                else if (GameManager.Instance.HandCP3[z].CardName.Contains("Standing-Water"))
    //                    GameManager.Instance.cp3StandingWaterCount++;
    //                else if (GameManager.Instance.HandCP3[z].CardName.Contains("Sub-Zero"))
    //                    GameManager.Instance.cp3SubZeroCount++;

    //                //actions are checkde and compelted
    //                /*for (int j = 0; j < GameManager.Instance.RegionPlacementCP3.Count; j++) //gets length of array
    //                {
    //                    if (GameManager.Instance.HandCP3[z].CardName == GameManager.Instance.RegionPlacementCP3[j].CardName)
    //                    {
    //                        if (GameManager.Instance.RegionPlacementCP3[j].ActionID.Count != 0) //only goes in if there are action
    //                        {
    //                            cardAction = GameObject.Find("Main Camera").GetComponent<ActionsCP3>(); //gets the script
    //                            Debug.Log(GameManager.Instance.RegionPlacementCP3[j].CardName);
    //                            cardAction.checkAction(GameManager.Instance.RegionPlacementCP3[j]); //executes cards actions
    //                        }
    //                        else
    //                        {
    //                            break; //just gets out of the loop and continues
    //                        }
    //                    }
    //                }*/

    //                GameManager.Instance.HandCP3.Remove(GameManager.Instance.HandCP3[z]);

    //                cardParent = GameObject.Find("Computer Three Board/CP3Hand").transform;

    //                if (cardParent.childCount != 0)
    //                    Destroy(cardParent.GetChild(0).gameObject);
    //            }
    //            else if (GameManager.Instance.HandCP3[z].CardType == "Condition") //puts the card into the condition card
    //            {
    //                cardParent = GameObject.Find("Computer Three Board/Condition Card Placement").transform;
    //                holder.cardNameHolder = GameManager.Instance.HandCP3[z].CardName;
    //                generateCardObject();
    //                holder.setSpriteCP3(sr); //generating the card object to be placed into the panel

    //                GameManager.Instance.changeComputerThreeScore(GameManager.Instance.HandCP3[z].PointValue);

    //                GameManager.Instance.ConditionPlacementCP3.Add(GameManager.Instance.HandCP3[z]); //adds it to the regions

    //                //actions are checkd and completed
    //                /*for (int j = 0; j < GameManager.Instance.ConditionPlacementCP3.Count; j++) //gets length of array
    //                {
    //                    if (GameManager.Instance.HandCP3[z].CardName == GameManager.Instance.ConditionPlacementCP3[j].CardName)
    //                    {
    //                        if (GameManager.Instance.ConditionPlacementCP3[j].ActionID.Count != 0) //only goes in if there are action
    //                        {
    //                            cardAction = GameObject.Find("Main Camera").GetComponent<ActionsCP3>(); //gets the script
    //                            Debug.Log(GameManager.Instance.ConditionPlacementCP3[j].CardName);
    //                            cardAction.checkAction(GameManager.Instance.ConditionPlacementCP3[j]); //executes cards actions
    //                        }
    //                        else
    //                        {
    //                            break; //just gets out of the loop and continues
    //                        }
    //                    }
    //                }*/

    //                GameManager.Instance.HandCP3.Remove(GameManager.Instance.HandCP3[z]);

    //                cardParent = GameObject.Find("Computer Three Board/CP3Hand").transform;

    //                if (cardParent.childCount != 0)
    //                    Destroy(cardParent.GetChild(0).gameObject);
    //            }
    //            else if (GameManager.Instance.HandCP3[z].CardType == "Plant") //puts the card into the plant type
    //            {
    //                cardParent = GameObject.Find("Computer Three Board/Plant Card Placement").transform;
    //                holder.cardNameHolder = GameManager.Instance.HandCP3[z].CardName;
    //                generateCardObject();
    //                holder.setSpriteCP3(sr); //generating the card object to be placed into the panel

    //                GameManager.Instance.changeComputerThreeScore(GameManager.Instance.HandCP3[z].PointValue);

    //                GameManager.Instance.PlantPlacementCP3.Add(GameManager.Instance.HandCP3[z]); //adds it to the regions

    //                //actions are checkd and completed
    //                /*for (int j = 0; j < GameManager.Instance.PlantPlacementCP3.Count; j++) //gets length of array
    //                {
    //                    if (GameManager.Instance.HandCP3[z].CardName == GameManager.Instance.PlantPlacementCP3[j].CardName)
    //                    {
    //                        if (GameManager.Instance.PlantPlacementCP3[j].ActionID.Count != 0) //only goes in if there are action
    //                        {
    //                            cardAction = GameObject.Find("Main Camera").GetComponent<ActionsCP3>(); //gets the script
    //                            Debug.Log(GameManager.Instance.PlantPlacementCP3[j].CardName);
    //                            cardAction.checkAction(GameManager.Instance.PlantPlacementCP3[j]); //executes cards actions
    //                        }
    //                        else
    //                        {
    //                            break; //just gets out of the loop and continues
    //                        }
    //                    }
    //                }*/

    //                GameManager.Instance.HandCP3.Remove(GameManager.Instance.HandCP3[z]);

    //                cardParent = GameObject.Find("Computer Three Board/CP3Hand").transform;

    //                if (cardParent.childCount != 0)
    //                    Destroy(cardParent.GetChild(0).gameObject);
    //            }
    //            else if (GameManager.Instance.HandCP3[z].CardType == "Invertebrate") //puts the card into the invertebrate pile
    //            {
    //                cardParent = GameObject.Find("Computer Three Board/Invertebrate Card Placement").transform;
    //                holder.cardNameHolder = GameManager.Instance.HandCP3[z].CardName;
    //                generateCardObject();
    //                holder.setSpriteCP3(sr); //generating the card object to be placed into the panel

    //                GameManager.Instance.changeComputerThreeScore(GameManager.Instance.HandCP3[z].PointValue);

    //                GameManager.Instance.InvertebratePlacementCP3.Add(GameManager.Instance.HandCP3[z]); //adds it to the regions

    //                //actions are checkd and completed
    //                /*for (int j = 0; j < GameManager.Instance.InvertebratePlacementCP3.Count; j++) //gets length of array
    //                {
    //                    if (GameManager.Instance.HandCP3[z].CardName == GameManager.Instance.InvertebratePlacementCP3[j].CardName)
    //                    {
    //                        if (GameManager.Instance.InvertebratePlacementCP3[j].ActionID.Count != 0) //only goes in if there are action
    //                        {
    //                            cardAction = GameObject.Find("Main Camera").GetComponent<ActionsCP3>(); //gets the script
    //                            Debug.Log(GameManager.Instance.InvertebratePlacementCP3[j].CardName);
    //                            cardAction.checkAction(GameManager.Instance.InvertebratePlacementCP3[j]); //executes cards actions
    //                        }
    //                        else
    //                        {
    //                            break; //just gets out of the loop and continues
    //                        }
    //                    }
    //                }*/

    //                GameManager.Instance.HandCP3.Remove(GameManager.Instance.HandCP3[z]);

    //                cardParent = GameObject.Find("Computer Three Board/CP3Hand").transform;

    //                if(cardParent.childCount != 0)
    //                    Destroy(cardParent.GetChild(0).gameObject);
    //            }
    //            else if (GameManager.Instance.HandCP3[z].CardType == "Animal") //puts the cards into the animal pile
    //            {
    //                cardParent = GameObject.Find("Computer Three Board/Animal Card Placement").transform;
    //                holder.cardNameHolder = GameManager.Instance.HandCP3[z].CardName;
    //                generateCardObject();
    //                holder.setSpriteCP3(sr); //generating the card object to be placed into the panel

    //                GameManager.Instance.changeComputerThreeScore(GameManager.Instance.HandCP3[z].PointValue);

    //                GameManager.Instance.AnimalPlacementCP3.Add(GameManager.Instance.HandCP3[z]); //adds it to the regions

    //                //actions are checked and completed
    //                /*for (int j = 0; j < GameManager.Instance.AnimalPlacementCP3.Count; j++) //gets length of array
    //                {
    //                    if (GameManager.Instance.HandCP3[z].CardName == GameManager.Instance.AnimalPlacementCP3[j].CardName)
    //                    {
    //                        if (GameManager.Instance.AnimalPlacementCP3[j].ActionID.Count != 0) //only goes in if there are action
    //                        {
    //                            cardAction = GameObject.Find("Main Camera").GetComponent<ActionsCP3>(); //gets the script
    //                            Debug.Log(GameManager.Instance.AnimalPlacementCP3[j].CardName);
    //                            cardAction.checkAction(GameManager.Instance.AnimalPlacementCP3[j]); //executes cards actions
    //                        }
    //                        else
    //                        {
    //                            break; //just gets out of the loop and continues
    //                        }
    //                    }
    //                }*/

    //                GameManager.Instance.HandCP3.Remove(GameManager.Instance.HandCP3[z]);

    //                cardParent = GameObject.Find("Computer Three Board/CP3Hand").transform;

    //                if (cardParent.childCount != 0)
    //                    Destroy(cardParent.GetChild(0).gameObject);
    //            }
    //            else if (GameManager.Instance.HandCP3[z].CardType == "Special Region") //puts the card into the special region pile
    //            {
    //                cardParent = GameObject.Find("Computer Three Board/Special Region Placement").transform;
    //                holder.cardNameHolder = GameManager.Instance.HandCP3[z].CardName;
    //                generateCardObject();
    //                holder.setSpriteCP3(sr); //generating the card object to be placed into the panel

    //                GameManager.Instance.changeComputerThreeScore(GameManager.Instance.HandCP3[z].PointValue);

    //                GameManager.Instance.SpecialRegionPlacementCP3.Add(GameManager.Instance.HandCP3[z]); //adds it to the regions

    //                //actions are checked and completed
    //                /*for (int j = 0; j < GameManager.Instance.SpecialRegionPlacementCP3.Count; j++) //gets length of array
    //                {
    //                    if (GameManager.Instance.HandCP3[z].CardName == GameManager.Instance.SpecialRegionPlacementCP3[j].CardName)
    //                    {
    //                        if (GameManager.Instance.SpecialRegionPlacementCP3[j].ActionID.Count != 0) //only goes in if there are action
    //                        {
    //                            cardAction = GameObject.Find("Main Camera").GetComponent<ActionsCP3>(); //gets the script
    //                            Debug.Log(GameManager.Instance.SpecialRegionPlacementCP3[j].CardName);
    //                            cardAction.checkAction(GameManager.Instance.SpecialRegionPlacementCP3[j]); //executes cards actions
    //                        }
    //                        else
    //                        {
    //                            break; //just gets out of the loop and continues
    //                        }
    //                    }
    //                }*/

    //                GameManager.Instance.HandCP3.Remove(GameManager.Instance.HandCP3[z]);

    //                cardParent = GameObject.Find("Computer Three Board/CP3Hand").transform;

    //                if (cardParent.childCount != 0)
    //                    Destroy(cardParent.GetChild(0).gameObject);
    //            }
    //            else if (GameManager.Instance.HandCP3[z].CardType == "Multi-Player") //puts the card into the multiplayer pile
    //            {
    //                cardParent = GameObject.Find("Computer Three Board/Multiplayer Card Placement").transform;
    //                holder.cardNameHolder = GameManager.Instance.HandCP3[z].CardName;
    //                generateCardObject();
    //                holder.setSpriteCP3(sr); //generating the card object to be placed into the panel

    //                GameManager.Instance.changeComputerThreeScore(GameManager.Instance.HandCP3[z].PointValue);

    //                GameManager.Instance.MultiPlacementCP3.Add(GameManager.Instance.HandCP3[z]); //adds it to the regions

    //                //actions are checked and completed
    //                /*for (int j = 0; j < GameManager.Instance.MultiPlacementCP3.Count; j++) //gets length of array
    //                {
    //                    if (GameManager.Instance.HandCP3[z].CardName == GameManager.Instance.MultiPlacementCP3[j].CardName)
    //                    {
    //                        if (GameManager.Instance.MultiPlacementCP3[j].ActionID.Count != 0) //only goes in if there are action
    //                        {
    //                            cardAction = GameObject.Find("Main Camera").GetComponent<ActionsCP3>(); //gets the script
    //                            Debug.Log(GameManager.Instance.MultiPlacementCP3[j].CardName);
    //                            cardAction.checkAction(GameManager.Instance.MultiPlacementCP3[j]); //executes cards actions
    //                        }
    //                        else
    //                        {
    //                            break; //just gets out of the loop and continues
    //                        }
    //                    }
    //                }*/

    //                GameManager.Instance.HandCP3.Remove(GameManager.Instance.HandCP3[z]);

    //                cardParent = GameObject.Find("Computer Three Board/CP3Hand").transform;

    //                if (cardParent.childCount != 0)
    //                    Destroy(cardParent.GetChild(0).gameObject);
    //            }
    //            else if (GameManager.Instance.HandCP3[z].CardType == "Microbe") //puts the card into the microbe pile
    //            {
    //                cardParent = GameObject.Find("Computer Three Board/Microbe Card Placement").transform;
    //                holder.cardNameHolder = GameManager.Instance.HandCP3[z].CardName;
    //                generateCardObject();
    //                holder.setSpriteCP3(sr); //generating the card object to be placed into the panel

    //                GameManager.Instance.changeComputerThreeScore(GameManager.Instance.HandCP3[z].PointValue);

    //                GameManager.Instance.MicrobePlacementCP3.Add(GameManager.Instance.HandCP3[z]); //adds it to the regions

    //                //actions are checked and completed
    //                /*for (int j = 0; j < GameManager.Instance.MicrobePlacementCP3.Count; j++) //gets length of array
    //                {
    //                    if (GameManager.Instance.HandCP3[z].CardName == GameManager.Instance.MicrobePlacementCP3[j].CardName)
    //                    {
    //                        if (GameManager.Instance.MicrobePlacementCP3[j].ActionID.Count != 0) //only goes in if there are action
    //                        {
    //                            cardAction = GameObject.Find("Main Camera").GetComponent<ActionsCP3>(); //gets the script
    //                            Debug.Log(GameManager.Instance.MicrobePlacementCP3[j].CardName);
    //                            cardAction.checkAction(GameManager.Instance.MicrobePlacementCP3[j]); //executes cards actions
    //                        }
    //                        else
    //                        {
    //                            break; //just gets out of the loop and continues
    //                        }
    //                    }
    //                }*/

    //                GameManager.Instance.HandCP3.Remove(GameManager.Instance.HandCP3[z]);

    //                cardParent = GameObject.Find("Computer Three Board/CP3Hand").transform;

    //                if (cardParent.childCount != 0)
    //                    Destroy(cardParent.GetChild(0).gameObject);
    //            }
    //            else if (GameManager.Instance.HandCP3[z].CardType == "Fungi") //puts the card into the fungi pile
    //            {
    //                cardParent = GameObject.Find("Computer Three Board/Fungi Card Placement").transform;
    //                holder.cardNameHolder = GameManager.Instance.HandCP3[z].CardName;
    //                generateCardObject();
    //                holder.setSpriteCP3(sr); //generating the card object to be placed into the panel

    //                GameManager.Instance.changeComputerThreeScore(GameManager.Instance.HandCP3[z].PointValue);

    //                GameManager.Instance.FungiPlacementCP3.Add(GameManager.Instance.HandCP3[z]); //adds it to the regions

    //                //actions are checked and compelted
    //                /*for (int j = 0; j < GameManager.Instance.FungiPlacementCP3.Count; j++) //gets length of array
    //                {
    //                    if (GameManager.Instance.HandCP3[z].CardName == GameManager.Instance.FungiPlacementCP3[j].CardName)
    //                    {
    //                        if (GameManager.Instance.FungiPlacementCP3[j].ActionID.Count != 0) //only goes in if there are action
    //                        {
    //                            cardAction = GameObject.Find("Main Camera").GetComponent<ActionsCP3>(); //gets the script
    //                            Debug.Log(GameManager.Instance.FungiPlacementCP3[j].CardName);
    //                            cardAction.checkAction(GameManager.Instance.FungiPlacementCP3[j]); //executes cards actions
    //                        }
    //                        else
    //                        {
    //                            break; //just gets out of the loop and continues
    //                        }
    //                    }
    //                }*/

    //                GameManager.Instance.HandCP3.Remove(GameManager.Instance.HandCP3[z]);

    //                cardParent = GameObject.Find("Computer Three Board/CP3Hand").transform;

    //                if (cardParent.childCount != 0)
    //                    Destroy(cardParent.GetChild(0).gameObject);
    //            }
    //        }
    //    }

    //    if (GameManager.Instance.HandCP3.Count != 0) //if there is a card left in the hand, it will discad the first one
    //    {
    //        cardParent = GameObject.Find("Computer Three Board/Discard Pile Placement").transform;
    //        holder.cardNameHolder = GameManager.Instance.HandCP3[0].CardName;
    //        generateDiscardObject();
    //        holder.setSpriteCP3(sr);

    //        GameManager.Instance.DiscardPlacementCP3.Add(GameManager.Instance.HandCP3[0]);
    //        GameManager.Instance.HandCP3.Remove(GameManager.Instance.HandCP3[0]);

    //        cardParent = GameObject.Find("Computer Three Board/CP3Hand").transform;

    //        if(cardParent.childCount != 0)
    //            Destroy(cardParent.GetChild(0).gameObject);

    //        for (int i = 0; i < 20; i++)
    //        {
    //            yield return null;
    //        }

    //        nextPlayer();

    //        Object.Destroy(cameraHolder.GetComponent<CP3AI>()); //destryos the cp1 script

    //        GameManager.Instance.canDraw = true; //makes it so you can draw again
    //    }
    //    else //if there are no cards left in the hand, will just automatically go to the next player
    //    {
    //        for (int i = 0; i < 20; i++)
    //        {
    //            yield return null;
    //        }

    //        nextPlayer();

    //        Object.Destroy(cameraHolder.GetComponent<CP3AI>()); //destryos the cp3 script

    //        GameManager.Instance.canDraw = true; //makes it so you can draw again
    //    }
    //}

    ////will be called in the above function whenever they are ready to move on
    //public void nextPlayer()
    //{
    //    Cursor.lockState = CursorLockMode.None; //you can use the cursor again
    //    Cursor.visible = true; //you can see the cursor again

    //    changePlayer.ShowPlayer(); //goes to the next player
    //    GameManager.Instance.changeRound();

    //    //will check to see if the player has the ability to end turns without discarding
    //    if (GameManager.Instance.playerNoDiscard == true)
    //    {
    //        Debug.Log("button should be enabled");
    //    }
    //    else
    //    {
    //        GameManager.Instance.disableTurnButton();
    //    }
    //}
}