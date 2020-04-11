/*
 *  @class      DropCard.cs
 *  @purpose    Places the card in the correct placement area when dropped if hovering over a collider
 *  
 *  @author     CIS 411 
 *  @date       2020/4/1
 */

/*This Script works because it is attached to the colliders on the playerboard. It automatically scans every frame 
 * and then since the draggable instance is usesed in theis class that is how this is all connected */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//WILL BE USED TO DETERMINE WHERE TO DROP CARDS AND IF THEY ARE ABLE TO DROP THEM
public class DropCard : MonoBehaviour
{
    private Draggable currentCard; //will be used to set the oarent of the current card
    private Transform parentFind; //will be used to find the parent of the card

    private int regionz; //all these variables used to change the sorting layer of the sprites so they are on top of eachother
    private int conditionz;
    private int plantz;
    private int invertebratez;
    private int animalz;
    private int specialz;
    private int multiz;
    private int humanz;
    private int microbez;
    private int fungiz;
    private int discardz;

    /*
     * @name    OnMouseEnter
     * @purpose When mouse enters collider it sets the current dragged card to current card
     * 
     * @return  Void
     */
    private void OnMouseEnter()
    {
        //sets the current card to th one being dragged
        if (Draggable.DraggedInstance != null)
            CurrentCard = Draggable.DraggedInstance.GetComponent<Draggable>();
    }

    /*
     * @name    OnMouseOver
     * @purpose When the mouse is hovering over the collider the card is assiged to the correct placement
     * 
     * @return  Void
     */
    private void OnMouseOver()
    {
        if (CurrentCard != null)
        {
            if (CurrentCard.CType == "Region" && gameObject.name == "Region Card Placement")
            {
                CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.RegionGameObject).transform;

                //changes the sorting layer so the next prite is on top
                CurrentCard.GetComponent<SpriteRenderer>().sortingOrder = Regionz;
                Regionz++;
            }
            else if (CurrentCard.CType == "Condition" && gameObject.name == "Condition Card Placement")
            {
                CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.ConditionGameObject).transform;

                //changes the sorting layer so the next prite is on top
                CurrentCard.GetComponent<SpriteRenderer>().sortingOrder = Conditionz;
                Conditionz++;
            }
            else if (CurrentCard.CType == "Plant" && gameObject.name == "Plant Card Placement")
            {
                CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.PlantGameObject).transform;

                //changes the sorting layer so the next prite is on top
                CurrentCard.GetComponent<SpriteRenderer>().sortingOrder = Plantz;
                Plantz++;
            }
            else if (CurrentCard.CType == "Invertebrate" && gameObject.name == "Invertebrate Card Placement")
            {
                CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.InvertebrateGameObject).transform;

                //changes the sorting layer so the next prite is on top
                CurrentCard.GetComponent<SpriteRenderer>().sortingOrder = Invertebratez;
                Invertebratez++;
            }
            else if (CurrentCard.CType == "Animal" && gameObject.name == "Animal Card Placement")
            {
                CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.AnimalGameObject).transform;

                //changes the sorting layer so the next prite is on top
                CurrentCard.GetComponent<SpriteRenderer>().sortingOrder = Animalz;
                Animalz++;
            }
            else if (CurrentCard.CType == "Special Region" && gameObject.name == "Special Region Card Placement")
            {
                CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.SpecialRegionGameObject).transform;

                //changes the sorting layer so the next prite is on top
                CurrentCard.GetComponent<SpriteRenderer>().sortingOrder = Specialz;
                Specialz++;
            }
            else if (CurrentCard.CType == "Multi-Player" && gameObject.name == "Multiplayer Card Placement")
            {
                CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.MultiplayerGameObject).transform;

                //changes the sorting layer so the next prite is on top
                CurrentCard.GetComponent<SpriteRenderer>().sortingOrder = Multiz;
                Multiz++;
            }
            else if (CurrentCard.CType == "Human" && gameObject.name == "Human Card Placement")
            {
                CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.HumanGameObject).transform;

                //changes the sorting layer so the next prite is on top
                CurrentCard.GetComponent<SpriteRenderer>().sortingOrder = Humanz;
                Humanz++;
            }
            else if (CurrentCard.CType == "Microbe" && gameObject.name == "Microbe Card Placement")
            {
                CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.MicrobeGameObject).transform;

                //changes the sorting layer so the next prite is on top
                CurrentCard.GetComponent<SpriteRenderer>().sortingOrder = Microbez;
                Microbez++;
            }
            else if (CurrentCard.CType == "Fungi" && gameObject.name == "Fungi Card Placement")
            {
                CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.FungiGameObject).transform;

                //changes the sorting layer so the next prite is on top
                CurrentCard.GetComponent<SpriteRenderer>().sortingOrder = Fungiz;
                Fungiz++;
            }
            else if (gameObject.name == "Discard Pile Placement" && GameManager.Instance.Person.CardDiscarded == false)
            {
                CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.DiscardGameObject).transform;

                //changes the sorting layer so the next prite is on top
                CurrentCard.GetComponent<SpriteRenderer>().sortingOrder = Discardz;
                Discardz++;
            }

            //if there is no gameobject or something did not work right the card goes back to the hand
            else if (gameObject.name == null)
            {
                CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.HandGameObject).transform;
            }
        }
    }

    /*
     * @name    OnMouseExit
     * @purpose When the mouse exits the colliders when drop the card will return to the deck
     * 
     * @return  Void
     */
    private void OnMouseExit()
    {
        if (CurrentCard != null) //if the user is not hovering over the collider the card does not stay inside the placeholder
            //returns the card to the hand
            CurrentCard.ParentReturn = GameObject.Find(GameManager.Instance.Person.HandGameObject).transform;
    }

    /*Accessors and Mutators*/
    public Draggable CurrentCard { get => currentCard; set => currentCard = value; }
    public Transform ParentFind { get => parentFind; set => parentFind = value; }
    public int Regionz { get => regionz; set => regionz = value; }
    public int Conditionz { get => conditionz; set => conditionz = value; }
    public int Plantz { get => plantz; set => plantz = value; }
    public int Invertebratez { get => invertebratez; set => invertebratez = value; }
    public int Animalz { get => animalz; set => animalz = value; }
    public int Specialz { get => specialz; set => specialz = value; }
    public int Multiz { get => multiz; set => multiz = value; }
    public int Humanz { get => humanz; set => humanz = value; }
    public int Microbez { get => microbez; set => microbez = value; }
    public int Fungiz { get => fungiz; set => fungiz = value; }
    public int Discardz { get => discardz; set => discardz = value; }
}
