using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class ActionHandler
{
    public static void ActionDelegate(string actionID)
    {
        Type type = typeof(Act);
        MethodInfo method = type.GetMethod(actionID);
        Act a = new Act();
        method.Invoke(a, null);
    }
}

public class Act
{
    public CardRetrievalFromDeck holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>();
    private GameObject cardObject;
    public Transform cardParent;
    private SpriteRenderer sr;

    public bool requirementsWork = false;
    public Requirements cardReqs;
    int deckCount = 0;
    int discardCount = 0;
    bool display = true;

    public void generateCardObject()
    {
        this.cardObject = new GameObject(holder.CardNameHolder, typeof(RectTransform));
        sr = cardObject.AddComponent<SpriteRenderer>();
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
        cardObject.AddComponent<CanvasGroup>().blocksRaycasts = false;
    }

    //  Biologist - Protect from Invasive Animal
    public void a001()
    {
        GameManager.Instance.Person.ProtectedFromInvasiveAnimal = true;
    }

    //  Biologist - Draw animal from deck, discrad Biologist
    public void a002()
    {
        foreach(Card card in GameManager.Instance.Person.Deck.Cards)
        {
            Debug.Log("Searching deck...");
            if(card.CardType == "Animal")
            {
                Debug.Log("Animal located.");
                {
                    Debug.Log("Added to hand.");
                    GameManager.Instance.Person.DrawSpecific(card);
                    GameManager.Instance.Person.ProtectedFromInvasiveAnimal = false;
                    foreach (Card cardRemove in GameManager.Instance.Person.HumanPlacement)
                    {
                        if (cardRemove.CardName == "Biologist")
                        {
                            GameManager.Instance.Person.DiscardPlacement.Add(card);
                            GameManager.Instance.Person.HumanPlacement.Remove(card);
                            return;
                        }
                    }
                }
            }
        }
        return;
    }

    //  Botanist - Protect from Invasive Plant
    public void a003()
    {
        GameManager.Instance.Person.ProtectedFromInvasivePlant = true;
    }

    //  Botanist - Draw plant from deck, discard Botanist
    public void a004()
    {
        foreach (Card card in GameManager.Instance.Person.Deck.Cards)
        {
            Debug.Log("Searching deck...");
            if (card.CardType == "Plant")
            {
                Debug.Log("Plant located.");
                {
                    Debug.Log("Added to hand.");
                    GameManager.Instance.Person.DrawSpecific(card);
                    GameManager.Instance.Person.ProtectedFromInvasivePlant = false;
                    foreach (Card cardRemove in GameManager.Instance.Person.HumanPlacement)
                    {
                        if (cardRemove.CardName == "Botanist")
                        {
                            GameManager.Instance.Person.DiscardPlacement.Add(card);
                            GameManager.Instance.Person.HumanPlacement.Remove(card);
                            return;
                        }
                    }
                }
            }
        }
    }

    //  Explorer - Remove Requirements for playing Conditions
    public void a005()
    {
        GameManager.Instance.Person.NoConditionRequirements = true;
    }

    //  Explorer - Draw Condition from deck, discard Explorer
    public void a006()
    {
        foreach (Card card in GameManager.Instance.Person.Deck.Cards)
        {
            Debug.Log("Searching deck...");
            if (card.CardType == "Condition")
            {
                Debug.Log("Condition located.");
                {
                    Debug.Log("Requirements met. Added to hand.");
                    GameManager.Instance.Person.DrawSpecific(card);
                    GameManager.Instance.Person.NoConditionRequirements = false;
                    foreach (Card cardRemove in GameManager.Instance.Person.HumanPlacement)
                    {
                        if (cardRemove.CardName == "Explorer")
                        {
                            GameManager.Instance.Person.DiscardPlacement.Add(card);
                            GameManager.Instance.Person.HumanPlacement.Remove(card);
                            return;
                        }
                    }
                }
            }
        }
    }

    //  Ranger - Protect from Blight
    public void a007()
    {
        GameManager.Instance.Person.ProtectedFromBlight = true;
    }

    //  Ranger - Remove Man-Eater, discard Ranger
    public void a008()
    {
        foreach(Card card in GameManager.Instance.Person.MultiPlacement)
        {
            if (card.CardName == "Man-Eater")
            {
                GameManager.Instance.Person.MultiPlacement.Remove(card);
            }
        }

        foreach(Card card in GameManager.Instance.Person.HumanPlacement)
        {
            if(card.CardName == "Ranger")
            {
                GameManager.Instance.Person.DiscardPlacement.Add(card);
                GameManager.Instance.Person.HumanPlacement.Remove(card);
                return;
            }
        }
    }

    //  Two Sisters - If card is discarded, all players draw three
    public void a010()
    {
        GameManager.Instance.Person.Draw(3);
        GameManager.Instance.CP1.Draw(3);
        GameManager.Instance.CP2.Draw(3);
        GameManager.Instance.CP3.Draw(3);
    }

    //  Acidic Waters* - When played, up to three Running, Standing, or Salt Water regions can no longer sustain life
    /public void a011(Player target)
    {

    }

    //  Children at Play* - When played, all actions in the selected player's ecosystem are paused for one turn.
    public void a012(Player target)
    {
        target.PausedOneTurn = true;
    }

    //  Extinction* - One species is now extinct. All players remove any copies of this species from their ecosystem, unless protected.
    public void a013()
    {

    }

    //  Isolated Ecosystem* - While in play, this player's ecosystem cannot be affected by Web of Life
    public void a014(Player target)
    {

    }
}
