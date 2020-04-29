<<<<<<< Updated upstream
﻿///*
// *  @class      CardRetrievalFromDeck
// *  @purpose    Handles retrieval of cards from deck
// *  
// *  @author     John Georgvich, previous CIS411 group
// *  @date       2020/01/22
// */

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CardRetrievalFromDeck : ScriptableObject {

//    //  class variable declaration
//    private int cardDrawHolder;
//    public string cardNameHolder;
//    public Sprite mySprite;
//    private Texture2D texSprite;

//    //  what is this below?
//    //int count = 0; //to be used when drawing a region on the first hand no matter what
//    bool region = false; //to determine if a region was drawn or not

//    /*
//     *  @name       CardDrawRandomizer()
//     *  @purpose    Draw card to the hand of human player
//     */
//    public void CardDrawRandomizer()
//    {
//        //  find currently selected deck
//        foreach (Deck deck in GameManager.Instance.Decks)
//        {
//            if (deck.DeckId == GameManager.Instance.deckPicked)
//            {
//                if (GameManager.Instance.regionCounter == 0)
//                {
//                    region = false;

//                    while(region == false && GameManager.Instance.round == 1)
//                    {
//                        cardDrawHolder = Random.Range(0, (deck.Cards.Count - 1));

//                        if(deck.Cards[cardDrawHolder].CardType == "Region")
//                        {
//                            cardNameHolder = deck.Cards[cardDrawHolder].CardName;
//                            //  adds card to GameManager instance's hand
//                            GameManager.Instance.Hand.Add(deck.Cards[cardDrawHolder]);
//                            //  removes aforementioned card from deck                
//                            deck.Cards.Remove(deck.Cards[cardDrawHolder]);

//                            //  will break loop, but why?
//                            region = true;
//                        }
//                    }
//                }
//                else
//                {
//                    //  select random position in deck
//                    cardDrawHolder = Random.Range(0, (deck.Cards.Count - 1));
//                    //  pulling the selected card's name value
//                    cardNameHolder = deck.Cards[cardDrawHolder].CardName;
//                    //  adds card to GameManager instance's hand
//                    GameManager.Instance.Hand.Add(deck.Cards[cardDrawHolder]);
//                    //  remove card from deck
//                    deck.Cards.Remove(deck.Cards[cardDrawHolder]);
//                }

//                //  count is only 0 after the first draw
//                GameManager.Instance.regionCounter = 1;
//            }
//        }
//    }

//    /*
//     *  @name       drawCP1Deck()
//     *  @purpose    Draw card to the hand of computer player one
//     */
//    public void drawCP1Deck()
//    {
//        //  find currently selected deck
//        foreach (Deck deck in GameManager.Instance.Decks)
//        {
//            if (deck.DeckId == GameManager.Instance.computerOneDeck)
//            {
//                //  select random position in deck
//                cardDrawHolder = Random.Range(0, (deck.Cards.Count - 1));
//                //  pulling the selected card's name value
//                cardNameHolder = deck.Cards[cardDrawHolder].CardName;
//                //  adds card to GameManager instance's hand
//                GameManager.Instance.HandCP1.Add(deck.Cards[cardDrawHolder]);
//                //  remove card from deck
//                deck.Cards.Remove(deck.Cards[cardDrawHolder]);
//            }
//        }
//    }

//    /*
//     *  @name       drawCP2Deck()
//     *  @purpose    Draw card to the hand of computer player two
//     */
//    public void drawCP2Deck()
//    {
//        //  find currently selected deck
//        foreach (Deck deck in GameManager.Instance.Decks)
//        {
//            if (deck.DeckId == GameManager.Instance.computerTwoDeck)
//            {
//                //  select random position in deck
//                cardDrawHolder = Random.Range(0, (deck.Cards.Count - 1));
//                //  pulling the selected card's name value
//                cardNameHolder = deck.Cards[cardDrawHolder].CardName;
//                //  adds card to GameManager instance's hand
//                GameManager.Instance.HandCP2.Add(deck.Cards[cardDrawHolder]);
//                //  remove card from deck
//                deck.Cards.Remove(deck.Cards[cardDrawHolder]);
//            }
//        }
//    }

//    /*
//     *  @name       drawCP3Deck()
//     *  @purpose    Draw card to the hand of computer player three
//     */
//    public void drawCP3Deck()
//    {
//        //  find currently selected deck
//        foreach (Deck deck in GameManager.Instance.Decks)
//        {
//            if (deck.DeckId == GameManager.Instance.computerThreeDeck)
//            {
//                //  select random position in deck
//                cardDrawHolder = Random.Range(0, (deck.Cards.Count - 1));
//                //  pulling the selected card's name value
//                cardNameHolder = deck.Cards[cardDrawHolder].CardName;
//                //  adds card to GameManager instance's hand
//                GameManager.Instance.HandCP3.Add(deck.Cards[cardDrawHolder]);
//                //  remove card from deck
//                deck.Cards.Remove(deck.Cards[cardDrawHolder]);
//            }
//        }
//    }

//    /*
//     *  @name       setSprite()
//     *  @purpose    Based on the newly generated card's name value, pair with appropriate sprite and feed to SpriteRenderer Unity object
//     */
//HELL YEAH THIS IS IT WHER ETHE CARD IS ASSIGNED NAME FOR SPRITE
//    public void setSprite(SpriteRenderer sr)
//    {
//        //  Loads texture based on card name
//        //Debug.Log(cardNameHolder);
//        texSprite = Resources.Load<Texture2D>("Sprites/" + cardNameHolder);   
//        //  create sprite from loaded texture
//        mySprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.666f);

//        //  @DEBUG: Prints to console if Sprite is null
//        if (texSprite == null)
//        {
//            Debug.Log("Sprite is null.");
//        }

//        //  Attach newly created sprite to SpriteRenderer Unity object
//        sr.sprite = mySprite;
//        //  sets sorting level of hand so that sprites do not inappropriately stack
//        sr.sortingOrder = GameManager.Instance.sortingOrder;
//        //  sets active instance to next in sprite sorting order
//        GameManager.Instance.sortingOrder++;
//        //  sets SpriteRenderer's layer name
//        sr.sortingLayerName = "Default";
//    }

//    /*
//     *  @name       setSpriteCP1()
//     *  @purpose    Based on the newly generated card's name value, pair with appropriate sprite and feed to SpriteRenderer Unity object
//     *  
//     *  @ATTN:      See setSprite() for documentation
//     */
//    public void setSpriteCP1(SpriteRenderer sr)
//    {
//        texSprite = Resources.Load<Texture2D>("Sprites/" + cardNameHolder);
//        mySprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.666f);
//        if (texSprite == null)
//        {
//            Debug.Log("Sprite is null.");
//        }
//        sr.sprite = mySprite;
//        sr.sortingOrder = GameManager.Instance.sortingOrder;
//        GameManager.Instance.sortingOrder++;
//        sr.sortingLayerName = "Default";
//    }

//    /*
//     *  @name       setSpriteCP2()
//     *  @purpose    Based on the newly generated card's name value, pair with appropriate sprite and feed to SpriteRenderer Unity object
//     *  
//     *  @ATTN:      See setSprite() for documentation
//     */
//    public void setSpriteCP2(SpriteRenderer sr)
//    {
//        texSprite = Resources.Load<Texture2D>("Sprites/" + cardNameHolder);
//        mySprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.666f);
//        if (texSprite == null)
//        {
//            Debug.Log("Sprite is null.");
//        }
//        sr.sprite = mySprite;
//        sr.sortingOrder = GameManager.Instance.sortingOrder;
//        GameManager.Instance.sortingOrder++;
//        sr.sortingLayerName = "Default";
//    }

//    /*
//     *  @name       setSpriteCP3()
//     *  @purpose    Based on the newly generated card's name value, pair with appropriate sprite and feed to SpriteRenderer Unity object
//     *  
//     *  @ATTN:      See setSprite() for documentation
//     */
//    public void setSpriteCP3(SpriteRenderer sr)
//    {
//        texSprite = Resources.Load<Texture2D>("Sprites/" + cardNameHolder);
//        mySprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.666f);
//        if (texSprite == null)
//        {
//            Debug.Log("Sprite is null.");
//        }
//        sr.sprite = mySprite;
//        sr.sortingOrder = GameManager.Instance.sortingOrder;
//        GameManager.Instance.sortingOrder++;
//        sr.sortingLayerName = "Default";
//    }

//    /*
//     *  @name       setSpriteForPicking()
//     *  @purpose    Based on the newly generated card's name value, pair with appropriate sprite and feed to SpriteRenderer Unity object
//     *  
//     *  @ATTN:      See setSprite() for documentation
//     */
//    public void setSpriteForPicking(SpriteRenderer sr)
//    {
//        texSprite = Resources.Load<Texture2D>("Sprites/" + cardNameHolder);
//        mySprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.666f);
//        if (texSprite == null)
//        {
//            Debug.Log("Sprite is null.");
//        }
//        sr.sprite = mySprite;
//        sr.sortingOrder = GameManager.Instance.sortingOrder;
//        GameManager.Instance.sortingOrder++;
//        sr.sortingLayerName = "Default";
//    }
//}
=======
﻿/*
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
>>>>>>> Stashed changes
