/*
 *  @class      CardRetrievalFromDeck
 *  @purpose    Handles retrieval of cards from deck
 *  
 *  @author     John Georgvich, previous CIS411 group
 *  @date       2020/01/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRetrievalFromDeck : ScriptableObject
{

    //to store info about card drawn from deck
    private int cardDrawHolder;
    private string cardNameHolder;
    private Sprite mySprite;
    private Texture2D texSprite;
    //used in randomier to make sure that a region card was drawn from the deck the first round
    private bool region;

    /*
     *  @name       CardDrawRandomizer()
     *  @purpose    Draw card to the hand of human player takes in the current instance of the human as a parameter
     */
    public void CardDrawRandomizer(Human pCurrentPlayer)
    {
                if (pCurrentPlayer.RegionCounter == 0)
                {
                    Region = false;

                    while (Region == false && GameManager.Instance.Round == 1)
                    {
                        CardDrawHolder = Random.Range(0, (pCurrentPlayer.Deck.Cards.Count - 1));

                        if (pCurrentPlayer.Deck.Cards[CardDrawHolder].CardType == "Region")
                        {
                            CardNameHolder = pCurrentPlayer.Deck.Cards[CardDrawHolder].CardName;
                            //  adds card to GameManager instance's hand
                            pCurrentPlayer.Hand.Add(pCurrentPlayer.Deck.Cards[CardDrawHolder]);
                            //  removes aforementioned card from deck                
                             pCurrentPlayer.Deck.Cards.Remove(pCurrentPlayer.Deck.Cards[CardDrawHolder]);

                            //ends loop becasue that means a region card was found
                            Region = true;
                        }
                    }
                }
                else
                {
                    //  select random position in deck
                    CardDrawHolder = Random.Range(0, (pCurrentPlayer.Deck.Cards.Count - 1));
                    //  pulling the selected card's name value
                    CardNameHolder = pCurrentPlayer.Deck.Cards[CardDrawHolder].CardName;
                    //  adds card to GameManager instance's hand
                    pCurrentPlayer.Hand.Add(pCurrentPlayer.Deck.Cards[CardDrawHolder]);
                    //  remove card from deck
                    pCurrentPlayer.Deck.Cards.Remove(pCurrentPlayer.Deck.Cards[CardDrawHolder]);
                }

        //  count is only 0 before the first draw
        pCurrentPlayer.RegionCounter = 1;
    }

    /*
     *  @name       CardDrawRandomizer()
     *  @purpose    ensures the first round a region card is drawn. Similiar to above method except this one taks Computer Types
     */
    public void CardDrawRandomizer(Computer pCurrentPlayer)
    {
        if (pCurrentPlayer.RegionCounter == 0)
        {
            Region = false;

            while (Region == false && GameManager.Instance.Round == 1)
            {
                CardDrawHolder = Random.Range(0, (pCurrentPlayer.Deck.Cards.Count - 1));

                if (pCurrentPlayer.Deck.Cards[CardDrawHolder].CardType == "Region")
                {
                    CardNameHolder = pCurrentPlayer.Deck.Cards[CardDrawHolder].CardName;
                    //  adds card to GameManager instance's hand
                    pCurrentPlayer.Hand.Add(pCurrentPlayer.Deck.Cards[CardDrawHolder]);
                    //  removes aforementioned card from deck                
                    pCurrentPlayer.Deck.Cards.Remove(pCurrentPlayer.Deck.Cards[CardDrawHolder]);

                    //ends loop becasue that means a region card was found
                    Region = true;
                }
            }
        }
        else
        {
            //  select random position in deck
            CardDrawHolder = Random.Range(0, (pCurrentPlayer.Deck.Cards.Count - 1));
            //  pulling the selected card's name value
            CardNameHolder = pCurrentPlayer.Deck.Cards[CardDrawHolder].CardName;
            //  adds card to GameManager instance's hand
            pCurrentPlayer.Hand.Add(pCurrentPlayer.Deck.Cards[CardDrawHolder]);
            //  remove card from deck
            pCurrentPlayer.Deck.Cards.Remove(pCurrentPlayer.Deck.Cards[CardDrawHolder]);
        }

        //  count is only 0 before the first draw
        pCurrentPlayer.RegionCounter = 1;
        Debug.Log(cardNameHolder);
    }

    /*
     *  @name       setSprite()
     *  @purpose    Based on the newly generated card's name value, pair with appropriate sprite and feed to SpriteRenderer Unity object humans and computers use this
     */
    public void setSprite(SpriteRenderer sr)
    {
        //  Loads texture based on card name
        TexSprite = Resources.Load<Texture2D>("Sprites/" + CardNameHolder);
        //  create sprite from loaded texture
        MySprite = Sprite.Create(TexSprite, new Rect(0, 0, TexSprite.width, TexSprite.height), new Vector2(0.5f, 0.5f), 1.666f);
        //  Attach newly created sprite to SpriteRenderer Unity object
        sr.sprite = MySprite;
        //  sets sorting level of hand so that sprites do not inappropriately stack
        sr.sortingOrder = GameManager.Instance.SortingOrder;
        //  sets active instance to next in sprite sorting order
        GameManager.Instance.SortingOrder++;
        //  sets SpriteRenderer's layer name
        sr.sortingLayerName = "Default";
    }

    //accessors and mutators
    public int CardDrawHolder { get => cardDrawHolder; set => cardDrawHolder = value; }
    public string CardNameHolder { get => cardNameHolder; set => cardNameHolder = value; }
    public Sprite MySprite { get => mySprite; set => mySprite = value; }
    public Texture2D TexSprite { get => texSprite; set => texSprite = value; }
    public bool Region { get => region; set => region = value; }
}
