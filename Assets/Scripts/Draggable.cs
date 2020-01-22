//WILL BE USED TO GIVE CARDS THE FUNCIONALITY TO BE DRAGGED

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//beginDragHandler and endDragHandler willnot work without dragHandler
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject DraggedInstance; //gets the object that is being dragged
    public static CanvasGroup sceneCheck; //will be used to see if the player scene is active - will be used for the halos

    public GameObject findPlacement; //will be used to get the panel for the placement and the halo glow
    public GameObject discardPlacement; //to make it easier to make the discard placement glow

    Component placementHalo; //for the current placement and discard placement
    Component discardHalo;

    public Requirements cardReqs; //to call the reqs function
    public Reqs reqs;
    public Actions cardAction; //to determine the action
    public ActionsStanding standingActions; //used for the standing actions

    //to determine mouse position for the dragging
    Vector3 _startPosition;
    Vector3 _offsetToMouse;
    float _zDistanceToCamera;

    public Transform parentReturn = null; //to store the parent of the object (the panel)

    public string cName; //to store the name and the type of the card
    public string cType;
    public int cardIndex; //will store the card index of the currently dragged card

    public bool requirementsWork = false; //will determine if the requirements work or not

    public HideShowBoards changePlayer; //will be sued when the user discards

    public CP1AI cp1AI; //where teh computer one ai will take place

    public CardRetrievalFromDeck holder;
    public DebugDealer playerDraw;
    private GameObject cardObject;
    public Transform cardParent; //to get the parent of the card
    private SpriteRenderer sr;

    //code that executes on the script load
    public void Start()
    {
        holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>(); //gets access to the script
        playerDraw = ScriptableObject.FindObjectOfType<DebugDealer>(); //gets access to the script
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
        cardObject.AddComponent<ChooseCard>(); //makes it so that you can choose the card
        //to allow mouse to go through the sprite to view what is behind it
        cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
    }

    //called every frame
    public void Update()
    {
    }

    //this is where you begin the drag of the object
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentReturn = this.transform.parent; //gets original parent panel - the hand
        this.transform.SetParent(this.transform.parent.parent);

        /**** CODE BELOW USED FOR MOUSE MOVEMENT AND DRAGGING ****/
        if (Input.touchCount > 1)
            return;

        DraggedInstance = gameObject; //determines initial positiong of the cards
        _startPosition = transform.position;
        _zDistanceToCamera = Mathf.Abs(_startPosition.z - Camera.main.transform.position.z);

        _offsetToMouse = _startPosition - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera));

        DraggedInstance.layer = 2; //sets the layer to ignore raycast

        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;

        cardAction = DraggedInstance.GetComponent<Actions>(); //to access the actions scripts

        /**** CODE BELOW USED TO MAKE THE CORRECT HALO GLOW FOR THE PLACEMENTS ****/
        /**** USES A LOT OF IF STATEMENTS BUT MAKES IT A LITTLE EASIER TO UNDERSTAND WITH JUST USING ONE TYPE VARIABLE ****/
        sceneCheck = GameObject.Find("Game Board Container/Player Board").GetComponent<CanvasGroup>(); //need this to check the alpha

        GameManager.Instance.DraggedCard = gameObject;

        if (sceneCheck.alpha == 1)//if this is not 1 it means that the player board is not the visible one
        {
            //this is where the requirements will be checked
            for(int z = 0; z < GameManager.Instance.Hand.Count; z++)
            {
                if(gameObject.name == GameManager.Instance.Hand[z].CardName) //finds the card you are working with
                {
                    bool executeReqs = true; //to handle executing the reqs

                    if (GameManager.Instance.Hand[z].CardType == "Condition") //determines if the standing action for the explorer is active
                    {
                        if (GameManager.Instance.playerNoConditionRequirements == true)
                            executeReqs = false;
                    }

                    if (executeReqs == true)
                    {
                        if (GameManager.Instance.Hand[z].ReqID.Count != 0)
                        {
                            cardReqs = GameObject.Find("Main Camera").GetComponent<Requirements>();

                            if (cardReqs.requirementCheck(GameManager.Instance.Hand[z])) //determines if they work or not
                                requirementsWork = true;
                            else requirementsWork = false;
                        }
                        else
                        {
                            requirementsWork = true; //allows it to be played
                            break;
                        }
                    }
                    else if (executeReqs == false) //so if there is no need to execute the requirements due to actions, will just say they are true
                        requirementsWork = true;
                }
            }

            if (requirementsWork == true)//if the requirements work
            {
                for (int j = 0; j < GameManager.Instance.Hand.Count; j++) //the for loop is used to just go through the hand and find the right card
                {
                    //will check the name of the game object with the hand to get the correct index
                    if (gameObject.name == GameManager.Instance.Hand[j].CardName)
                    {
                        cardIndex = j; //just stores the card index for use
                        cType = GameManager.Instance.Hand[cardIndex].CardType; //stores the card type for future use
                    }

                    //will go through each card type and check to see if the halo should light up
                    if (cType == "Region")
                    {
                        findPlacement = GameObject.Find("Player/Region Card Placement");
                        discardPlacement = GameObject.Find("Player/Discard Pile Placement"); //gets discard placement

                        placementHalo = findPlacement.GetComponent("Halo"); //gets the halo component
                        discardHalo = discardPlacement.GetComponent("Halo"); //gets discard halo component

                        if (placementHalo != null && discardHalo != null) //just to make sure there is actually a halo component
                        {
                            placementHalo.GetType().GetProperty("enabled").SetValue(placementHalo, true, null); //sets the glow to true

                            if (GameManager.Instance.cardDiscarded == false)
                                discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, true, null); //sets the glow
                        }
                    }
                    else if (cType == "Condition")
                    {
                        findPlacement = GameObject.Find("Player/Condition Card Placement");
                        discardPlacement = GameObject.Find("Player/Discard Pile Placement"); //gets discard placement

                        placementHalo = findPlacement.GetComponent("Halo"); //gets the halo component
                        discardHalo = discardPlacement.GetComponent("Halo"); //gets discard halo component

                        if (placementHalo != null) //just to make sure there is actually a halo component
                        {
                            placementHalo.GetType().GetProperty("enabled").SetValue(placementHalo, true, null); //sets the glow to true

                            if (GameManager.Instance.cardDiscarded == false)
                                discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, true, null); //sets the glow
                        }
                    }
                    else if (cType == "Plant")
                    {
                        findPlacement = GameObject.Find("Player/Plant Card Placement");
                        discardPlacement = GameObject.Find("Player/Discard Pile Placement"); //gets discard placement

                        placementHalo = findPlacement.GetComponent("Halo"); //gets the halo component
                        discardHalo = discardPlacement.GetComponent("Halo"); //gets discard halo component

                        if (placementHalo != null) //just to make sure there is actually a halo component
                        {
                            placementHalo.GetType().GetProperty("enabled").SetValue(placementHalo, true, null); //sets the glow to true

                            if (GameManager.Instance.cardDiscarded == false)
                                discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, true, null); //sets the glow
                        }
                    }
                    else if (cType == "Invertebrate")
                    {
                        findPlacement = GameObject.Find("Player/Invertebrate Card Placement");
                        discardPlacement = GameObject.Find("Player/Discard Pile Placement"); //gets discard placement

                        placementHalo = findPlacement.GetComponent("Halo"); //gets the halo component
                        discardHalo = discardPlacement.GetComponent("Halo"); //gets discard halo component

                        if (placementHalo != null) //just to make sure there is actually a halo component
                        {
                            placementHalo.GetType().GetProperty("enabled").SetValue(placementHalo, true, null); //sets the glow to true

                            if (GameManager.Instance.cardDiscarded == false)
                                discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, true, null); //sets the glow
                        }
                    }
                    else if (cType == "Animal")
                    {
                        findPlacement = GameObject.Find("Player/Animal Card Placement");
                        discardPlacement = GameObject.Find("Player/Discard Pile Placement"); //gets discard placement

                        placementHalo = findPlacement.GetComponent("Halo"); //gets the halo component
                        discardHalo = discardPlacement.GetComponent("Halo"); //gets discard halo component

                        if (placementHalo != null) //just to make sure there is actually a halo component
                        {
                            placementHalo.GetType().GetProperty("enabled").SetValue(placementHalo, true, null); //sets the glow to true

                            if (GameManager.Instance.cardDiscarded == false)
                                discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, true, null); //sets the glow
                        }
                    }
                    else if (cType == "Special Region")
                    {
                        findPlacement = GameObject.Find("Player/Special Region Card Placement");
                        discardPlacement = GameObject.Find("Player/Discard Pile Placement"); //gets discard placement

                        placementHalo = findPlacement.GetComponent("Halo"); //gets the halo component
                        discardHalo = discardPlacement.GetComponent("Halo"); //gets discard halo component

                        if (placementHalo != null) //just to make sure there is actually a halo component
                        {
                            placementHalo.GetType().GetProperty("enabled").SetValue(placementHalo, true, null); //sets the glow to true

                            if (GameManager.Instance.cardDiscarded == false)
                                discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, true, null); //sets the glow
                        }
                    }
                    else if (cType == "Multi-Player")
                    {
                        findPlacement = GameObject.Find("Player/Multiplayer Card Placement");
                        discardPlacement = GameObject.Find("Player/Discard Pile Placement"); //gets discard placement

                        placementHalo = findPlacement.GetComponent("Halo"); //gets the halo component
                        discardHalo = discardPlacement.GetComponent("Halo"); //gets discard halo component

                        if (placementHalo != null) //just to make sure there is actually a halo component
                        {
                            placementHalo.GetType().GetProperty("enabled").SetValue(placementHalo, true, null); //sets the glow to true

                            if (GameManager.Instance.cardDiscarded == false)
                                discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, true, null); //sets the glow
                        }
                    }
                    else if (cType == "Human")
                    {
                        findPlacement = GameObject.Find("Player/Human Card Placement");
                        discardPlacement = GameObject.Find("Player/Discard Pile Placement"); //gets discard placement

                        placementHalo = findPlacement.GetComponent("Halo"); //gets the halo component
                        discardHalo = discardPlacement.GetComponent("Halo"); //gets discard halo component

                        if (placementHalo != null) //just to make sure there is actually a halo component
                        {
                            placementHalo.GetType().GetProperty("enabled").SetValue(placementHalo, true, null); //sets the glow to true

                            if (GameManager.Instance.cardDiscarded == false)
                                discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, true, null); //sets the glow
                        }
                    }
                    else if (cType == "Microbe")
                    {
                        findPlacement = GameObject.Find("Player/Microbe Card Placement");
                        discardPlacement = GameObject.Find("Player/Discard Pile Placement"); //gets discard placement

                        placementHalo = findPlacement.GetComponent("Halo"); //gets the halo component
                        discardHalo = discardPlacement.GetComponent("Halo"); //gets discard halo component

                        if (placementHalo != null) //just to make sure there is actually a halo component
                        {
                            placementHalo.GetType().GetProperty("enabled").SetValue(placementHalo, true, null); //sets the glow to true

                            if (GameManager.Instance.cardDiscarded == false)
                                discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, true, null); //sets the glow
                        }
                    }
                    else if (cType == "Fungi")
                    {
                        findPlacement = GameObject.Find("Player/Fungi Card Placement");
                        discardPlacement = GameObject.Find("Player/Discard Pile Placement"); //gets discard placement

                        placementHalo = findPlacement.GetComponent("Halo"); //gets the halo component
                        discardHalo = discardPlacement.GetComponent("Halo"); //gets discard halo component

                        if (placementHalo != null) //just to make sure there is actually a halo component
                        {
                            placementHalo.GetType().GetProperty("enabled").SetValue(placementHalo, true, null); //sets the glow to true

                            if (GameManager.Instance.cardDiscarded == false)
                                discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, true, null); //sets the glow
                        }
                    }
                }
            }
            else if(GameManager.Instance.cardDiscarded == false)//discard pile should still work
            {
                discardPlacement = GameObject.Find("Player/Discard Pile Placement"); //gets discard placement
                discardHalo = discardPlacement.GetComponent("Halo"); //gets discard halo component
                discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, true, null); //sets the glow
            }
        }
    }

    //this is where the drag action takes place
    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 1)
            return;

        //gets the current positio of the mouse and takes the card with it
        transform.position = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera) + _offsetToMouse);
    }

    //this is what happens whenever the drag ends
    public void OnEndDrag(PointerEventData eventData)
    {
        DraggedInstance.layer = 5; //puts the layer back to the original

        //discarded = false;

        /**** THIS WILL MOVE THE CARD FROM THE HAND LIST TO THE APPROPRIATE LIST BASED ON THE TYPE ****/
        if (parentReturn.name != "Hand")
        {
            if (parentReturn.name == "Discard Pile Placement" && GameManager.Instance.cardDiscarded == false) //checks to make sure it wasnt placed in the discard pile first
            {
                for (int i = 0; i < GameManager.Instance.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Hand[i].CardName)
                    {
                        DraggedInstance.transform.localScale = new Vector3(1.0f, 1.0f, 0); //sets the size to fit the placement area

                        GameManager.Instance.DiscardPlacement.Add(GameManager.Instance.Hand[i]); //adds the card to the discard list
                        GameManager.Instance.Hand.Remove(GameManager.Instance.Hand[i]); //removes the card from the hand list

                        GameManager.Instance.cardDiscarded = true;
                    }
                }

                changePlayer = GameObject.Find("Main Camera").GetComponent<HideShowBoards>(); //gets the script

                Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                GameManager.Instance.makeButtonVisible(); //makes the button visible again
                GameManager.Instance.enableTurnButton(); //enables the end turn button

            }
            else if (cType == "Region")
            {
                for (int i = 0; i < GameManager.Instance.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.changePlayerScore(GameManager.Instance.Hand[i].PointValue);

                        //will check what the region type is and accesses/changes the variable
                        if (GameManager.Instance.Hand[i].CardName.Contains("Arid"))
                            GameManager.Instance.playerAridCount++;
                        else if (GameManager.Instance.Hand[i].CardName.Contains("Forest"))
                            GameManager.Instance.playerForestCount++;
                        else if (GameManager.Instance.Hand[i].CardName.Contains("Grasslands"))
                            GameManager.Instance.playerGrasslandsCount++;
                        else if (GameManager.Instance.Hand[i].CardName.Contains("Running-Water"))
                            GameManager.Instance.playerRunningWaterCount++;
                        else if (GameManager.Instance.Hand[i].CardName.Contains("Salt-Water"))
                            GameManager.Instance.playerSaltWaterCount++;
                        else if (GameManager.Instance.Hand[i].CardName.Contains("Standing-Water"))
                            GameManager.Instance.playerStandingWaterCount++;
                        else if (GameManager.Instance.Hand[i].CardName.Contains("Sub-Zero"))
                            GameManager.Instance.playerSubZeroCount++;

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.RegionPlacement.Add(GameManager.Instance.Hand[i]); //adds the card to the region list
                        GameManager.Instance.Hand.Remove(GameManager.Instance.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.HumanPlacement[j]); //executes cards actions
                                }
                                else
                                {
                                    break; //just gets out of the loop and continues
                                }
                            }
                        }*/
                    }
                }
            }
            else if (cType == "Condition")
            {
                for (int i = 0; i < GameManager.Instance.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.changePlayerScore(GameManager.Instance.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.ConditionPlacement.Add(GameManager.Instance.Hand[i]); //adds the card to the condition list
                        GameManager.Instance.Hand.Remove(GameManager.Instance.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.HumanPlacement[j]); //executes cards actions
                                }
                                else
                                {
                                    break; //just gets out of the loop and continues
                                }
                            }
                        }*/
                    }
                }
            }
            else if (cType == "Plant")
            {
                for (int i = 0; i < GameManager.Instance.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.changePlayerScore(GameManager.Instance.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.PlantPlacement.Add(GameManager.Instance.Hand[i]); //adds the card to the plant list
                        GameManager.Instance.Hand.Remove(GameManager.Instance.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.HumanPlacement[j]); //executes cards actions
                                }
                                else
                                {
                                    break; //just gets out of the loop and continues
                                }
                            }
                        }*/
                    }
                }
            }
            else if (cType == "Invertebrate")
            {
                for (int i = 0; i < GameManager.Instance.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.changePlayerScore(GameManager.Instance.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.InvertebratePlacement.Add(GameManager.Instance.Hand[i]); //adds the card to the invertebrate list
                        GameManager.Instance.Hand.Remove(GameManager.Instance.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.HumanPlacement[j]); //executes cards actions
                                }
                                else
                                {
                                    break; //just gets out of the loop and continues
                                }
                            }
                        }*/
                    }
                }
            }
            else if (cType == "Animal")
            {
                for (int i = 0; i < GameManager.Instance.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.changePlayerScore(GameManager.Instance.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.AnimalPlacement.Add(GameManager.Instance.Hand[i]); //adds the card to the aniaml list
                        GameManager.Instance.Hand.Remove(GameManager.Instance.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.HumanPlacement[j]); //executes cards actions
                                }
                                else
                                {
                                    break; //just gets out of the loop and continues
                                }
                            }
                        }*/
                    }
                }
            }
            else if (cType == "Special Region")
            {
                for (int i = 0; i < GameManager.Instance.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Hand[i].CardName)
                    {
                        //checks for the mountin range
                        if (GameManager.Instance.Hand[i].CardName.Contains("Mountain"))
                            GameManager.Instance.playerMountainRange++;

                        //changes the player score
                        GameManager.Instance.changePlayerScore(GameManager.Instance.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.SpecialRegionPlacement.Add(GameManager.Instance.Hand[i]); //adds the card to the Special Region list
                        GameManager.Instance.Hand.Remove(GameManager.Instance.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        for (int j = 0; j < GameManager.Instance.SpecialRegionPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.SpecialRegionPlacement[j].CardName)
                            {
                                if (GameManager.Instance.SpecialRegionPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    //Debug.Log("im in");
                                    standingActions = GameObject.Find("Main Camera").GetComponent<ActionsStanding>(); //gets the script
                                    standingActions.checkStandingAction(GameManager.Instance.SpecialRegionPlacement[j]); //executes cards actions
                                }
                                else
                                {
                                    break; //just gets out of the loop and continues
                                }
                            }
                        }
                    }
                }
            }
            else if (cType == "Multi-Player")
            {
                for (int i = 0; i < GameManager.Instance.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.changePlayerScore(GameManager.Instance.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.MultiPlacement.Add(GameManager.Instance.Hand[i]); //adds the card to the Multiplayer list
                        GameManager.Instance.Hand.Remove(GameManager.Instance.Hand[i]); //removes the card from the hand list
                    }
                }
            }
            else if (cType == "Human")
            {
                for (int i = 0; i < GameManager.Instance.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Hand[i].CardName)
                    {
                        //GameManager.Instance.DraggedCard = DraggedInstance;
                        
                        //changes the player score
                        GameManager.Instance.changePlayerScore(GameManager.Instance.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.HumanPlacement.Add(GameManager.Instance.Hand[i]); //adds the card to the Human list
                        GameManager.Instance.Hand.Remove(GameManager.Instance.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        for(int j = 0; j < GameManager.Instance.HumanPlacement.Count; j++) //gets length of array
                        {
                            if(DraggedInstance.name == GameManager.Instance.HumanPlacement[j].CardName)
                            {
                                if(GameManager.Instance.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    standingActions = GameObject.Find("Main Camera").GetComponent<ActionsStanding>(); //gets the script
                                    standingActions.checkStandingAction(GameManager.Instance.HumanPlacement[j]); //executes cards actions
                                }
                                else
                                {
                                    break; //just gets out of the loop and continues
                                }
                            }
                        }
                    }
                }
            }
            else if (cType == "Microbe")
            {
                for (int i = 0; i < GameManager.Instance.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.changePlayerScore(GameManager.Instance.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.MicrobePlacement.Add(GameManager.Instance.Hand[i]); //adds the card to the Microbe list
                        GameManager.Instance.Hand.Remove(GameManager.Instance.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.HumanPlacement[j]); //executes cards actions
                                }
                                else
                                {
                                    break; //just gets out of the loop and continues
                                }
                            }
                        }*/
                    }
                }
            }
            else if (cType == "Fungi")
            {
                for (int i = 0; i < GameManager.Instance.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.changePlayerScore(GameManager.Instance.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.FungiPlacement.Add(GameManager.Instance.Hand[i]); //adds the card to the Fungi list
                        GameManager.Instance.Hand.Remove(GameManager.Instance.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.HumanPlacement[j]); //executes cards actions
                                }
                                else
                                {
                                    break; //just gets out of the loop and continues
                                }
                            }
                        }*/
                    }
                }
            }
        }

        //double click will not work on cards in your hand or in the discard pile
        if (parentReturn.name != "Hand" && parentReturn.name != "Discard Pile Placement")
        {
            DraggedInstance.AddComponent<DoubleClickDescription>(); //once placed, adds the option to be double clicked
        }

        this.transform.SetParent(parentReturn); //sets the parent

        //to make sure there are no sorting issues so that the cards are positioned properly
        DraggedInstance.GetComponent<SpriteRenderer>().sortingOrder = GameManager.Instance.sortingOrder;
        GameManager.Instance.sortingOrder++;

        DraggedInstance = null; //drops object
        _offsetToMouse = Vector3.zero;

        if (requirementsWork == false && discardHalo != null)
        {
            discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, false, null); //sets the glow to false
        }
        else if (DraggedInstance == null)
        {
            if(placementHalo != null)
                placementHalo.GetType().GetProperty("enabled").SetValue(placementHalo, false, null); //sets the glow to false
            if(discardHalo != null)
                discardHalo.GetType().GetProperty("enabled").SetValue(discardHalo, false, null); //sets the glow to false
        }

        if (GameManager.Instance.cardDiscarded == false)
        {
            if (GameManager.Instance.Hand.Count == 0) //if you play your last card and dont have anymore, automatically goes
            {
                changePlayer = GameObject.Find("Main Camera").GetComponent<HideShowBoards>(); //gets the script

                GameManager.Instance.makeButtonVisible(); //makes the button visible
                GameManager.Instance.enableTurnButton(); //enables the end turn button
            }
        }

        //WHERE THE DISCARD PILE WILL BE CHECKED FOR CARDS WITH CERTAIN ACTIONS THAT NEED CHANGED

        for(int i = 0; i < GameManager.Instance.DiscardPlacement.Count; i++) //to go through the discard pile
        {
            if (GameManager.Instance.DiscardPlacement[i].CardName == "Human-Two-Sisters-In-The-Wild")
                GameManager.Instance.playerProtectedFromExtinction = false; //player is no longer protected from extinction
            else if (GameManager.Instance.DiscardPlacement[i].CardName == "Human-Biologist")
                GameManager.Instance.playerProtectedFromInvasiveAnimal = false; //player is no longer protected
            else if (GameManager.Instance.DiscardPlacement[i].CardName == "Human-Botanist")
                GameManager.Instance.playerProtectedFromInvasivePlant = false; //no longer protected from the invaiev plant
            else if (GameManager.Instance.DiscardPlacement[i].CardName == "Human-Explorer")
                GameManager.Instance.playerNoConditionRequirements = false; //no longer able to place condition cards without requirements
        }

    }
}
