/*
 *  @class      Draggable.cs
 *  @purpose    Allows player to drag a card from the deck and then runs requirements and assigns halo glows as well as
 *  this class is where the cards are assigned to the human players different lists
 *  
 *  @author     CIS 411 
 *  @date       2020/4/1
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//beginDragHandler and endDragHandler willnot work without dragHandler
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject DraggedInstance; //gets the object that is being dragged

    //these will hold the values to create an object from the script for Requirements
    private GameObject reqGO;
    private Requirements req;

    //this probably isnt needed
    //will be used to see if the player scene is active - will be used for the halos
    private CanvasGroup sceneCheck;

    private GameObject findPlacement; //will be used to get the panel for the placement and the halo glow
    private GameObject discardPlacement; //to make it easier to make the discard placement glow
    private Component placementHalo; //for the current placement and discard placement
    private Component discardHalo;

    /*************************************************************************************************************/
    /*************************************************************************************************************/
    //temporaily took this out and everyhting with actons everywhere until we are ready o work on that -ben
    private Actions cardAction; //to determine the action
    private ActionsStanding standingActions; //used for the standing actions
    /*************************************************************************************************************/
    /*************************************************************************************************************/

     //this parent return is determind by the "drop" class when the mouse is holvering over colliders
    private Transform parentReturn = null; //to store the parent of the object (the panel)

    //stores the type of the card
    private string cType;

    private bool requirementsWork = false; //will determine if the requirements work or not

    //to determine mouse position for the dragging
    Vector3 _startPosition;
    Vector3 _offsetToMouse;
    float _zDistanceToCamera;

    void Start(){}

    /*
      * @name    OnBeginDrag
      * @purpose Once you begin draging requirements are checked and halos are assigned
      * 
      * @return  Void
      */
    public void OnBeginDrag(PointerEventData eventData)
    {
        //this instantiates an game object of the class to use as an object and access methods
        //creates a gameobjects
        ReqGO = new GameObject("Req");
        //assigns the script to the game object
        ReqGO.AddComponent<Requirements>();
        //assigns the game object to the script withe the game object
        Req = GameObject.Find("Req").GetComponent<Requirements>();

        ParentReturn = this.transform.parent; //gets original parent panel - the hand
        //this makes sure the current card being draggeds return is the hand
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

        CardAction = DraggedInstance.GetComponent<Actions>(); //to access the actions scripts

        /**** CODE BELOW USED TO MAKE THE CORRECT HALO GLOW FOR THE PLACEMENTS ****/
        /**** USES A LOT OF IF STATEMENTS BUT MAKES IT A LITTLE EASIER TO UNDERSTAND WITH JUST USING ONE TYPE VARIABLE ****/
        SceneCheck = GameObject.Find("Game Board Container/Player Board").GetComponent<CanvasGroup>(); //need this to check the alpha
        
        //this is used so many time so i just took it out and pout it up here to organize
        DiscardPlacement = GameObject.Find(GameManager.Instance.Person.DiscardGameObject); //gets discard placement
        DiscardHalo = DiscardPlacement.GetComponent("Halo"); //gets discard halo component

        if (SceneCheck.alpha == 1)//if this is not 1 it means that the player board is not the visible one
        {
            //this is where the requirements will be checked
            //loop through each card in the human hand
            for (int z = 0; z < GameManager.Instance.Person.Hand.Count; z++)
            {
                //if the current card being dagged matches the card in the hand
                if (gameObject.name == GameManager.Instance.Person.Hand[z].CardName) //finds the card you are working with
                {
                    //part of requirement checking 
                    bool executeReqs = true; //to handle executing the reqs

                    if (GameManager.Instance.Person.Hand[z].CardType == "Condition") //determines if the standing action for the explorer is active
                    {
                        if (GameManager.Instance.Person.NoConditionRequirements == true)
                            executeReqs = false;
                    }

                    //this is the basic requirement check routine
                    if (executeReqs == true)
                    {
                        //if the card has requrements associated with it
                        if (GameManager.Instance.Person.Hand[z].ReqID.Count != 0)
                        {
                            //calls the method in requirements and passes in the current card being draged and the current object player 
                            //and gets a true/false value to determine if requirements work
                            if (Req.RequirementCheck(GameManager.Instance.Person.Hand[z], GameManager.Instance.Person.CurrentPlayer)== true)
                            {
                                RequirementsWork = true;
                            }
                            //if the requirements dont work then set the bool
                            else RequirementsWork = false;
                        }
                        //if the card has no rewuirements associated with it then continue 
                        else
                        {
                            RequirementsWork = true; //allows it to be played
                            break;
                        }
                    }
                    else if (executeReqs == false) //so if there is no need to execute the requirements due to actions, will just say they are true
                        RequirementsWork = true;
                }
            }

            /*********************************************************************************************************/
            //From here on enables the halo glows
            if (RequirementsWork == true)//if the requirements work
            {
                for (int j = 0; j < GameManager.Instance.Person.Hand.Count; j++) //the for loop is used to just go through the hand and find the right card
                {
                    //will check the name of the game object with the hand to get the correct index
                    if (gameObject.name == GameManager.Instance.Person.Hand[j].CardName)
                    {
                        CType = GameManager.Instance.Person.Hand[j].CardType; //stores the card type for future use
                    }

                    //will go through each card type and check to see if the halo should light up
                    if (CType == "Region")
                    {
                        HaloGlow(GameManager.Instance.Person.RegionGameObject);                                      
                    }
                    else if (CType == "Condition")
                    {
                        HaloGlow(GameManager.Instance.Person.ConditionGameObject);
                    }
                    else if (CType == "Plant")
                    {
                        HaloGlow(GameManager.Instance.Person.PlantGameObject);                      
                    }
                    else if (CType == "Invertebrate")
                    {
                        HaloGlow(GameManager.Instance.Person.InvertebrateGameObject);                      
                    }
                    else if (CType == "Animal")
                    {
                        HaloGlow(GameManager.Instance.Person.AnimalGameObject);                      
                    }
                    else if (CType == "Special Region")
                    {
                        HaloGlow(GameManager.Instance.Person.SpecialRegionGameObject);                       
                    }
                    else if (CType == "Multi-Player")
                    {
                        HaloGlow(GameManager.Instance.Person.MultiplayerGameObject);
                        
                    }
                    else if (CType == "Human")
                    {
                        HaloGlow(GameManager.Instance.Person.HumanGameObject);                       
                    }
                    else if (CType == "Microbe")
                    {
                        HaloGlow(GameManager.Instance.Person.MicrobeGameObject);
                    }
                    else if (CType == "Fungi")
                    {
                        HaloGlow(GameManager.Instance.Person.FungiGameObject);
                    }
                }
            }
            else if (GameManager.Instance.Person.CardDiscarded == false)//discard pile should still work
            {
                DiscardHalo.GetType().GetProperty("enabled").SetValue(DiscardHalo, true, null); //sets the glow
            }
        }
    }

    /*
      * @name    HaloGlow
      * @purpose this is called to set the glow to the correct placement holder on the player canvas
      * 
      * @return  Void
      */
    public void HaloGlow(string pGameObjectPlacement)
    {
        //takes the parameter and find the correct palcement area
        FindPlacement = GameObject.Find(pGameObjectPlacement);
        PlacementHalo = FindPlacement.GetComponent("Halo"); //gets the halo component

        if (PlacementHalo != null && DiscardHalo != null) //just to make sure there is actually a halo component
        {         
            PlacementHalo.GetType().GetProperty("enabled").SetValue(PlacementHalo, true, null); //sets the glow to true
            if (GameManager.Instance.Person.CardDiscarded == false)
                DiscardHalo.GetType().GetProperty("enabled").SetValue(DiscardHalo, true, null); //sets the glow
        }
    }

        /*
      * @name    DisableHaloGlow()
      * @purpose Once the dragged object is dropped all glowing halos are turned off. this is called at the on end drag method
      * 
      * @return  Void
      */
    public void DisableHaloGlow()
    {
        if (RequirementsWork == false && DiscardHalo != null)
        {
            DiscardHalo.GetType().GetProperty("enabled").SetValue(DiscardHalo, false, null); //sets the glow to false
        }
        else if (DraggedInstance == null)
        {
            if (PlacementHalo != null)
                PlacementHalo.GetType().GetProperty("enabled").SetValue(PlacementHalo, false, null); //sets the glow to false
            if (DiscardHalo != null)
                DiscardHalo.GetType().GetProperty("enabled").SetValue(DiscardHalo, false, null); //sets the glow to false
        }

    }

    /*
      * @name    OnBeginDrag
      * @purpose While you are dragging the card is moved with youre mouse
      * 
      * @return  Void
      */
    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 1)
            return;

        //gets the current positio of the mouse and takes the card with it
        transform.position = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera) + _offsetToMouse);
    }

    /*
      * @name    OnEndDrag
      * @purpose based off of the collider if the card meets requirements it is moved from the hand list to the approapriate card list of the human
      * 
      * @return  Void
      */
    public void OnEndDrag(PointerEventData eventData)
    {
        DraggedInstance.layer = 5; //puts the layer back to the original

        /**** THIS WILL MOVE THE CARD FROM THE HAND LIST TO THE APPROPRIATE LIST BASED ON THE TYPE ****/
        if (ParentReturn.name != "Hand")
        {
            if (ParentReturn.name == "Discard Pile Placement" && GameManager.Instance.Person.CardDiscarded == false) //checks to make sure it wasnt placed in the discard pile first
            {
                //finds the current dragged card type and finds the corresponding one in the hand
                for (int i = 0; i < GameManager.Instance.Person.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Person.Hand[i].CardName)
                    {
                        DraggedInstance.transform.localScale = new Vector3(1.0f, 1.0f, 0); //sets the size to fit the placement area                     
                        GameManager.Instance.Person.DiscardPlacement.Add(GameManager.Instance.Person.Hand[i]); //adds the card to the discard list
                        GameManager.Instance.Person.Hand.Remove(GameManager.Instance.Person.Hand[i]); //removes the card from the hand list

                        GameManager.Instance.Person.CardDiscarded = true;
                    }
                }

                Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                //instead of the end sturn button it automatically starts the computers turn when the card is discarded
                GameManager.Instance.NextPlayer(GameManager.Instance.Person.PlayerName);

            }
            else if (CType == "Region")
            {
                for (int i = 0; i < GameManager.Instance.Person.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Person.Hand[i].CardName)
                    {
                        //changes the player score by adding the point value of card passing through as a parameter
                        GameManager.Instance.Person.ChangeScore(GameManager.Instance.Person.Hand[i].PointValue);

                        //will check what the region type is and accesses/changes the variable
                        if (GameManager.Instance.Person.Hand[i].CardName.Contains("Arid"))
                            GameManager.Instance.Person.AridCount++;
                        else if (GameManager.Instance.Person.Hand[i].CardName.Contains("Forest"))
                            GameManager.Instance.Person.ForestCount++;
                        else if (GameManager.Instance.Person.Hand[i].CardName.Contains("Grasslands"))
                            GameManager.Instance.Person.GrasslandsCount++;
                        else if (GameManager.Instance.Person.Hand[i].CardName.Contains("Running-Water"))
                            GameManager.Instance.Person.RunningWaterCount++;
                        else if (GameManager.Instance.Person.Hand[i].CardName.Contains("Salt-Water"))
                            GameManager.Instance.Person.SaltWaterCount++;
                        else if (GameManager.Instance.Person.Hand[i].CardName.Contains("Standing-Water"))
                            GameManager.Instance.Person.StandingWaterCount++;
                        else if (GameManager.Instance.Person.Hand[i].CardName.Contains("Sub-Zero"))
                            GameManager.Instance.Person.SubZeroCount++;

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes card no longer be abe to be dragged

                        GameManager.Instance.Person.RegionPlacement.Add(GameManager.Instance.Person.Hand[i]); //adds the card to the region list
                        GameManager.Instance.Person.Hand.Remove(GameManager.Instance.Person.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed but we havnt gotten here yet
                        /*for (int j = 0; j < GameManager.Instance.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.Person.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.Person.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.Person.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.Person.HumanPlacement[j]); //executes cards actions
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
            else if (CType == "Condition")
            {
                for (int i = 0; i < GameManager.Instance.Person.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Person.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.Person.ChangeScore(GameManager.Instance.Person.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.Person.ConditionPlacement.Add(GameManager.Instance.Person.Hand[i]); //adds the card to the condition list
                        GameManager.Instance.Person.Hand.Remove(GameManager.Instance.Person.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.Person.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.Person.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.Person.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.Person.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.Person.HumanPlacement[j]); //executes cards actions
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
            else if (CType == "Plant")
            {
                for (int i = 0; i < GameManager.Instance.Person.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Person.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.Person.ChangeScore(GameManager.Instance.Person.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.Person.PlantPlacement.Add(GameManager.Instance.Person.Hand[i]); //adds the card to the plant list
                        GameManager.Instance.Person.Hand.Remove(GameManager.Instance.Person.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.Person.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.Person.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.Person.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.Person.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.Person.HumanPlacement[j]); //executes cards actions
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
            else if (CType == "Invertebrate")
            {
                for (int i = 0; i < GameManager.Instance.Person.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Person.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.Person.ChangeScore(GameManager.Instance.Person.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.Person.InvertebratePlacement.Add(GameManager.Instance.Person.Hand[i]); //adds the card to the invertebrate list
                        GameManager.Instance.Person.Hand.Remove(GameManager.Instance.Person.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.Person.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.Person.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.Person.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.Person.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.Person.HumanPlacement[j]); //executes cards actions
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
            else if (CType == "Animal")
            {
                for (int i = 0; i < GameManager.Instance.Person.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Person.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.Person.ChangeScore(GameManager.Instance.Person.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.Person.AnimalPlacement.Add(GameManager.Instance.Person.Hand[i]); //adds the card to the aniaml list
                        GameManager.Instance.Person.Hand.Remove(GameManager.Instance.Person.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.Person.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.Person.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.Person.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.Person.HumanPlacement[j]); //executes cards actions
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
            else if (CType == "Special Region")
            {
                for (int i = 0; i < GameManager.Instance.Person.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Person.Hand[i].CardName)
                    {
                        //checks for the mountin range
                        if (GameManager.Instance.Person.Hand[i].CardName.Contains("Mountain"))
                            GameManager.Instance.Person.MountainRange++;

                        //changes the player score
                        GameManager.Instance.Person.ChangeScore(GameManager.Instance.Person.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.Person.SpecialRegionPlacement.Add(GameManager.Instance.Person.Hand[i]); //adds the card to the Special Region list
                        GameManager.Instance.Person.Hand.Remove(GameManager.Instance.Person.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        for (int j = 0; j < GameManager.Instance.Person.SpecialRegionPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.Person.SpecialRegionPlacement[j].CardName)
                            {
                                if (GameManager.Instance.Person.SpecialRegionPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    /**********************************************************************************************/
                                    /**********************************************************************************************/
                                    //i commented everything to do with actions out until we are ready to work with it
                                    //Debug.Log("im in");
                                    //standingActions = GameObject.Find("Main Camera").GetComponent<ActionsStanding>(); //gets the script
                                    //standingActions.checkStandingAction(GameManager.Instance.Person.SpecialRegionPlacement[j]); //executes cards actions
                                    /**********************************************************************************************/
                                    /**********************************************************************************************/
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

            //multiplayer needs the added functionality
            else if (CType == "Multi-Player")
            {
                for (int i = 0; i < GameManager.Instance.Person.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Person.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.Person.ChangeScore(GameManager.Instance.Person.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.Person.MultiPlacement.Add(GameManager.Instance.Person.Hand[i]); //adds the card to the Multiplayer list
                        GameManager.Instance.Person.Hand.Remove(GameManager.Instance.Person.Hand[i]); //removes the card from the hand list
                    }
                }
            }
            //human needs the added functionality
            else if (CType == "Human")
            {
                for (int i = 0; i < GameManager.Instance.Person.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Person.Hand[i].CardName)
                    {
                        //GameManager.Instance.DraggedCard = DraggedInstance;

                        //changes the player score
                        GameManager.Instance.Person.ChangeScore(GameManager.Instance.Person.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.Person.HumanPlacement.Add(GameManager.Instance.Person.Hand[i]); //adds the card to the Human list
                        GameManager.Instance.Person.Hand.Remove(GameManager.Instance.Person.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        for (int j = 0; j < GameManager.Instance.Person.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.Person.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.Person.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    /**********************************************************************************************/
                                    /**********************************************************************************************/
                                    //i commented everything to do with actions out until we are ready to get to it
                                    //standingActions = GameObject.Find("Main Camera").GetComponent<ActionsStanding>(); //gets the script
                                    //standingActions.checkStandingAction(GameManager.Instance.Person.HumanPlacement[j]); //executes cards actions
                                    /**********************************************************************************************/
                                    /**********************************************************************************************/
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
            else if (CType == "Microbe")
            {
                for (int i = 0; i < GameManager.Instance.Person.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Person.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.Person.ChangeScore(GameManager.Instance.Person.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.Person.MicrobePlacement.Add(GameManager.Instance.Person.Hand[i]); //adds the card to the Microbe list
                        GameManager.Instance.Person.Hand.Remove(GameManager.Instance.Person.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.Person.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.Person.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.Person.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.Person.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.Person.HumanPlacement[j]); //executes cards actions
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
            else if (CType == "Fungi")
            {
                for (int i = 0; i < GameManager.Instance.Person.Hand.Count; i++) //used to go through the hand
                {
                    if (DraggedInstance.name == GameManager.Instance.Person.Hand[i].CardName)
                    {
                        //changes the player score
                        GameManager.Instance.Person.ChangeScore(GameManager.Instance.Person.Hand[i].PointValue);

                        DraggedInstance.transform.localScale = new Vector3(1f, 1f, 0); //sets the size to fit the placement area

                        Destroy(DraggedInstance.GetComponent<Draggable>()); //makes them no longer be abe to be dragged

                        GameManager.Instance.Person.FungiPlacement.Add(GameManager.Instance.Person.Hand[i]); //adds the card to the Fungi list
                        GameManager.Instance.Person.Hand.Remove(GameManager.Instance.Person.Hand[i]); //removes the card from the hand list

                        //this is where the card actions are checked and executed
                        /*for (int j = 0; j < GameManager.Instance.Person.HumanPlacement.Count; j++) //gets length of array
                        {
                            if (DraggedInstance.name == GameManager.Instance.Person.HumanPlacement[j].CardName)
                            {
                                if (GameManager.Instance.Person.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
                                {
                                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
                                    Debug.Log(GameManager.Instance.Person.HumanPlacement[j].CardName);
                                    cardAction.checkAction(GameManager.Instance.Person.HumanPlacement[j]); //executes cards actions
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

        /**********************************************************************************************/
        /**********************************************************************************************/
        //Im not sure that this is necissary - ben
        ////double click will not work on cards in your hand or in the discard pile
        if (ParentReturn.name != "Hand" && ParentReturn.name != "Discard Pile Placement")
        {
            DraggedInstance.AddComponent<DoubleClickDescription>(); //once placed, adds the option to be double clicked
        }
        /**********************************************************************************************/
        /**********************************************************************************************/

        //this makes cards return to the hand area if not dropped anywhere they are allowed
        this.transform.SetParent(ParentReturn);

        //to make sure there are no sorting issues so that the cards are positioned properly, always amakes sure what ever object
        //uses sorting order is being placed on the very top
        DraggedInstance.GetComponent<SpriteRenderer>().sortingOrder = GameManager.Instance.SortingOrder;
        GameManager.Instance.SortingOrder++;

        DraggedInstance = null; //drops object
        //resets dragging values
        _offsetToMouse = Vector3.zero;

        DisableHaloGlow();
        outOfCards();

        //WHERE THE DISCARD PILE WILL BE CHECKED FOR CARDS WITH CERTAIN ACTIONS THAT NEED CHANGED

        for (int i = 0; i < GameManager.Instance.Person.DiscardPlacement.Count; i++) //to go through the discard pile
        {
            if (GameManager.Instance.Person.DiscardPlacement[i].CardName == "Human-Two-Sisters-In-The-Wild")
                GameManager.Instance.Person.ProtectedFromExtinction = false; //player is no longer protected from extinction
            else if (GameManager.Instance.Person.DiscardPlacement[i].CardName == "Human-Biologist")
                GameManager.Instance.Person.ProtectedFromInvasiveAnimal = false; //player is no longer protected
            else if (GameManager.Instance.Person.DiscardPlacement[i].CardName == "Human-Botanist")
                GameManager.Instance.Person.ProtectedFromInvasivePlant = false; //no longer protected from the invaiev plant
            else if (GameManager.Instance.Person.DiscardPlacement[i].CardName == "Human-Explorer")
                GameManager.Instance.Person.NoConditionRequirements = false; //no longer able to place condition cards without requirements
        }

    }


    /*
      * @name    outOfCards
      * @purpose if you are out of cards the end turn button is automaticall interactable
      * 
      * @return  Void
      */
    public void outOfCards()
    {
        //this automatically enables the end turn button if you are out of cards
        if (GameManager.Instance.Person.CardDiscarded == false)
        {
            if (GameManager.Instance.Person.Hand.Count == 0) //if you play your last card and dont have anymore, automatically goes
            {
                //instead of the end sturn button it automatically starts the computers turn when the card is discarded
                GameManager.Instance.NextPlayer(GameManager.Instance.Person.PlayerName);
            }
        }
    }

    //accessors and mutator
    public GameObject FindPlacement { get => findPlacement; set => findPlacement = value; }
    public GameObject DiscardPlacement { get => discardPlacement; set => discardPlacement = value; }
    public Component PlacementHalo { get => placementHalo; set => placementHalo = value; }
    public Component DiscardHalo { get => discardHalo; set => discardHalo = value; }
    public Actions CardAction { get => cardAction; set => cardAction = value; }
    public ActionsStanding StandingActions { get => standingActions; set => standingActions = value; }
    public Transform ParentReturn { get => parentReturn; set => parentReturn = value; }
    public string CType { get => cType; set => cType = value; }
    public bool RequirementsWork { get => requirementsWork; set => requirementsWork = value; }
    public CanvasGroup SceneCheck { get => sceneCheck; set => sceneCheck = value; }
    public GameObject ReqGO { get => reqGO; set => reqGO = value; }
    public Requirements Req { get => req; set => req = value; }
}
