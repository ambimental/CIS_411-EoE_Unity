//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

////WILL BE USED TO DETERMINE WHERE TO DROP CARDS AND IF THEY ARE ABLE TO DROP THEM
//public class DropCard : MonoBehaviour
//{
//    Draggable currentCard; //will be used to set the aprent of the current card
//    Transform parentFind; //will be used to find the parent of the card

//    int regionz; //all these variables used to change the sorting layer of the sprites so they are on top of eachother
//    int conditionz;
//    int plantz;
//    int invertebratez;
//    int animalz;
//    int specialz;
//    int multiz;
//    int humanz;
//    int microbez;
//    int fungiz;
//    int discardz;

//    private void OnMouseEnter()
//    {
//        //Debug.Log(gameObject.name);

//        //sets the current card to th one being dragged
//        if(Draggable.DraggedInstance != null)
//            currentCard = Draggable.DraggedInstance.GetComponent<Draggable>();
//    }

//    //if the mouse is over the collider this will update every frame
//    private void OnMouseOver()
//    {
//        if(currentCard != null)
//        {
//            if (currentCard.cType == "Region" && gameObject.name == "Region Card Placement")
//            {
//                currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Region Card Placement").transform;

//                //changes the sorting layer so the next prite is on top
//                currentCard.GetComponent<SpriteRenderer>().sortingOrder = regionz;
//                regionz++;
//            }
//            else if (currentCard.cType == "Condition" && gameObject.name == "Condition Card Placement")
//            {
//                currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Condition Card Placement").transform;

//                //changes the sorting layer so the next prite is on top
//                currentCard.GetComponent<SpriteRenderer>().sortingOrder = conditionz;
//                conditionz++;
//            }
//            else if (currentCard.cType == "Plant" && gameObject.name == "Plant Card Placement")
//            {
//                currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Plant Card Placement").transform;

//                //changes the sorting layer so the next prite is on top
//                currentCard.GetComponent<SpriteRenderer>().sortingOrder = plantz;
//                plantz++;
//            }
//            else if (currentCard.cType == "Invertebrate" && gameObject.name == "Invertebrate Card Placement")
//            {
//                currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Invertebrate Card Placement").transform;

//                //changes the sorting layer so the next prite is on top
//                currentCard.GetComponent<SpriteRenderer>().sortingOrder = invertebratez;
//                invertebratez++;
//            }
//            else if (currentCard.cType == "Animal" && gameObject.name == "Animal Card Placement")
//            {
//                currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Animal Card Placement").transform;

//                //changes the sorting layer so the next prite is on top
//                currentCard.GetComponent<SpriteRenderer>().sortingOrder = animalz;
//                animalz++;
//            }
//            else if (currentCard.cType == "Special Region" && gameObject.name == "Special Region Card Placement")
//            {
//                currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Special Region Card Placement").transform;

//                //changes the sorting layer so the next prite is on top
//                currentCard.GetComponent<SpriteRenderer>().sortingOrder = specialz;
//                specialz++;
//            }
//            else if (currentCard.cType == "Multi-Player" && gameObject.name == "Multiplayer Card Placement")
//            {
//                currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Multiplayer Card Placement").transform;

//                //changes the sorting layer so the next prite is on top
//                currentCard.GetComponent<SpriteRenderer>().sortingOrder = multiz;
//                multiz++;
//            }
//            else if (currentCard.cType == "Human" && gameObject.name == "Human Card Placement")
//            {
//                currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Human Card Placement").transform;

//                //changes the sorting layer so the next prite is on top
//                currentCard.GetComponent<SpriteRenderer>().sortingOrder = humanz;
//                humanz++;
//            }
//            else if (currentCard.cType == "Microbe" && gameObject.name == "Microbe Card Placement")
//            {
//                currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Microbe Card Placement").transform;

//                //changes the sorting layer so the next prite is on top
//                currentCard.GetComponent<SpriteRenderer>().sortingOrder = microbez;
//                microbez++;
//            }
//            else if (currentCard.cType == "Fungi" && gameObject.name == "Fungi Card Placement")
//            {
//                currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Fungi Card Placement").transform;

//                //changes the sorting layer so the next prite is on top
//                currentCard.GetComponent<SpriteRenderer>().sortingOrder = fungiz;
//                fungiz++;
//            }
//            else if (gameObject.name == "Discard Pile Placement" && GameManager.Instance.cardDiscarded == false)
//            {
//                currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Discard Pile Placement").transform;

//                //changes the sorting layer so the next prite is on top
//                currentCard.GetComponent<SpriteRenderer>().sortingOrder = discardz;
//                discardz++;
//            }
//            else if (gameObject.name == null)
//            {
//                currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Hand").transform;
//            }
//        }
//    }

//    //when the mouse exits the collider
//    private void OnMouseExit()
//    {
//        if(currentCard != null) //if the user is not hovering over the collider the card does not stay inside the placeholder
//            currentCard.parentReturn = GameObject.Find("Player Board/Board/Player/Hand").transform;
//    }
//}