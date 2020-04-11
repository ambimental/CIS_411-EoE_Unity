////USED TO PERFORM THE ACTIONS OF THE SELECTED CARD

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PerformAction : MonoBehaviour {

//    public GameObject cardObject; //will be used to hold the name of the picked card
//    public Actions cardAction; //will be used to acess the card actions

//    public Card humanCard; //to have the human card information
//    public Card multiCard; //multiplayer card info

//    public Transform cardParent; //to get the parent of the card
//    private SpriteRenderer sr;
//    public CardRetrievalFromDeck holder;

//    // Use this for initialization
//    void Start () {
//        holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>(); //gets access to the script
//    }

//	// Update is called once per frame
//	void Update () {

//	}

//    //will be called to perform the actions of the card
//    public void performAction()
//    {
//        GameManager.Instance.cardInfoPanel.SetActive(false);

//        cardObject = GameManager.Instance.DraggedCard;

//        //CHECKS FOR THE HUMAN ACTIONS
//        for (int j = 0; j < GameManager.Instance.HumanPlacement.Count; j++) //gets length of array
//        {
//            if (cardObject.name == GameManager.Instance.HumanPlacement[j].CardName)
//            {
//                if (GameManager.Instance.HumanPlacement[j].ActionID.Count != 0) //only goes in if there are action
//                {
//                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
//                    cardAction.checkAction(GameManager.Instance.HumanPlacement[j]); //executes cards actions

//                    //WHERE THE HUMAN CARD SHOULD BE REMOVED AND PUT INTO THE DISCARD PILE
//                    humanCard = GameManager.Instance.HumanPlacement[j]; //sets the human card to this
//                    GameManager.Instance.DiscardPlacement.Add(humanCard); //adds this to the discard placementlist

//                    Destroy(cardObject);

//                    cardParent = GameObject.Find("Game Board Container/Player Board/Board/Player/Discard Pile Placement").transform; //sets the card parent
//                    holder.cardNameHolder = humanCard.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr);

//                    GameManager.Instance.HumanPlacement.RemoveAt(j); //removes the card from the array list
//                }
//                else
//                {
//                    break; //just gets out of the loop and continues
//                }
//            }
//        }

//        //CHECKS FOR THE MULTIPLYER ACTIONS
//        for (int j = 0; j < GameManager.Instance.MultiPlacement.Count; j++) //gets length of array
//        {
//            if (cardObject.name == GameManager.Instance.MultiPlacement[j].CardName)
//            {
//                if (GameManager.Instance.MultiPlacement[j].ActionID.Count != 0) //only goes in if there are action
//                {
//                    cardAction = GameObject.Find("Main Camera").GetComponent<Actions>(); //gets the script
//                    cardAction.checkAction(GameManager.Instance.MultiPlacement[j]); //executes cards actions

//                    //WHERE THE Multiplayer CARD SHOULD BE REMOVED AND PUT INTO THE DISCARD PILE
//                    multiCard = GameManager.Instance.MultiPlacement[j]; //sets the human card to this
//                    GameManager.Instance.DiscardPlacement.Add(multiCard); //adds this to the discard placementlist

//                    Destroy(cardObject);

//                    cardParent = GameObject.Find("Game Board Container/Player Board/Board/Player/Discard Pile Placement").transform; //sets the card parent
//                    holder.cardNameHolder = multiCard.CardName; //card name needed to get card image
//                    generateCardObject();
//                    holder.setSprite(sr);

//                    GameManager.Instance.MultiPlacement.RemoveAt(j); //removes the card from the array list
//                }
//                else
//                {
//                    break; //just gets out of the loop and continues
//                }
//            }
//        }
//    }

//    //Function that  is used to create an object to represent the card
//    private void generateCardObject()
//    {
//        //creating a new gameobject  to hold act as the card
//        cardObject = new GameObject(holder.cardNameHolder, typeof(RectTransform));
//        //creating a SpriteRenderer to hold the card's Sprite
//        sr = cardObject.AddComponent<SpriteRenderer>();
//        //setting the rectangle size  of the card object
//        cardObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 120);
//        //adding a collider to the card object, which is sized based on the rectangle size
//        cardObject.AddComponent<BoxCollider2D>().size = cardObject.GetComponent<RectTransform>().sizeDelta;
//        //setting the card object's parent to be the Hand, so that it will render in the player's hand
//        cardObject.transform.SetParent(cardParent);
//        //setting the localScale of the card object, so that it will be appropriately sized
//        cardObject.transform.localScale = new Vector3(1f, 1f, 0);
//        //adding the HoverClass script to the card object, which allows for hover functionality.
//        cardObject.AddComponent<HoverClass>();
//        cardObject.AddComponent<DoubleClickDescription>(); //makes it so that you can click on the cards whenever they are played
//        cardObject.AddComponent<ChooseCard>(); //makes it so that you can choose the card
//        //to allow mouse to go through the sprite to view what is behind it
//        cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false; //will block raycasts so you can see objects behind it with mouse
//    }
//}
