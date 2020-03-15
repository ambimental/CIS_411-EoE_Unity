///*
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
