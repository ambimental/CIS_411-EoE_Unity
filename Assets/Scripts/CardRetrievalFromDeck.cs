using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRetrievalFromDeck : ScriptableObject {

    //variables
    private int cardDrawHolder;
    public string cardNameHolder;
    public Sprite mySprite;
    private Texture2D texSprite;

    //int count = 0; //to be used when drawing a region on the first hand no matter what
    bool region = false; //to determine if a region was drawn or not

    //Function that picks a random card out of the current deck, adds it to the GameManager Instance's hand, and then removes it from the deck
    public void CardDrawRandomizer()
    {
        //quick foreach loop + if statement combo to find the current deck
        foreach (Deck deck in GameManager.Instance.Decks)
        {
            if (deck.DeckId == GameManager.Instance.deckPicked)
            {
                if (GameManager.Instance.regionCounter == 0)
                {
                    region = false;

                    while(region == false && GameManager.Instance.round == 1)
                    {
                        cardDrawHolder = Random.Range(0, (deck.Cards.Count - 1));

                        if(deck.Cards[cardDrawHolder].CardType == "Region")
                        {
                            cardNameHolder = deck.Cards[cardDrawHolder].CardName;
                            //adding the card to the GameManager Instance's hand via it's location in the list
                            GameManager.Instance.Hand.Add(deck.Cards[cardDrawHolder]); //to add the card being removed from the deck, moves it to the hand
                                                                                       //removing the same card from the deck list
                            deck.Cards.Remove(deck.Cards[cardDrawHolder]);

                            region = true; //will break the loop, never to come back again
                        }
                    }
                }
                else
                {
                    cardDrawHolder = Random.Range(0, (deck.Cards.Count - 1));//selecting a random place within the decklist using an int with a max 1 less than the decksize
                                                                             //pulling the selected card's name value
                    cardNameHolder = deck.Cards[cardDrawHolder].CardName;
                    //adding the card to the GameManager Instance's hand via it's location in the list
                    GameManager.Instance.Hand.Add(deck.Cards[cardDrawHolder]); //to add the card being removed from the deck, moves it to the hand
                                                                               //removing the same card from the deck list
                    deck.Cards.Remove(deck.Cards[cardDrawHolder]);
                }

                GameManager.Instance.regionCounter = 1; //count will only be 0 after the very first draw
            }
        }
    }

    //to draw a card from the computer one deck
    public void drawCP1Deck()
    {
        //quick foreach loop + if statement combo to find the current deck
        foreach (Deck deck in GameManager.Instance.Decks)
        {
            if (deck.DeckId == GameManager.Instance.computerOneDeck)
            {
                //selecting a random place within the decklist using an int with a max 1 less than the decksize
                cardDrawHolder = Random.Range(0, (deck.Cards.Count - 1));
                //pulling the selected card's name value
                cardNameHolder = deck.Cards[cardDrawHolder].CardName;
                //adding the card to the GameManager Instance's hand via it's location in the list
                GameManager.Instance.HandCP1.Add(deck.Cards[cardDrawHolder]); //to add the card being removed from the deck, moves it to the hand
                //removing the same card from the deck list
                deck.Cards.Remove(deck.Cards[cardDrawHolder]);
            }
        }
    }

    //to draw a card from the computer one deck
    public void drawCP2Deck()
    {
        //quick foreach loop + if statement combo to find the current deck
        foreach (Deck deck in GameManager.Instance.Decks)
        {
            if (deck.DeckId == GameManager.Instance.computerTwoDeck)
            {
                //selecting a random place within the decklist using an int with a max 1 less than the decksize
                cardDrawHolder = Random.Range(0, (deck.Cards.Count - 1));
                //pulling the selected card's name value
                cardNameHolder = deck.Cards[cardDrawHolder].CardName;
                //adding the card to the GameManager Instance's hand via it's location in the list
                GameManager.Instance.HandCP2.Add(deck.Cards[cardDrawHolder]); //to add the card being removed from the deck, moves it to the hand
                //removing the same card from the deck list
                deck.Cards.Remove(deck.Cards[cardDrawHolder]);
            }
        }
    }

    //to draw a card from the comuter three deck
    public void drawCP3Deck()
    {
        //quick foreach loop + if statement combo to find the current deck
        foreach (Deck deck in GameManager.Instance.Decks)
        {
            if (deck.DeckId == GameManager.Instance.computerThreeDeck)
            {
                //selecting a random place within the decklist using an int with a max 1 less than the decksize
                cardDrawHolder = Random.Range(0, (deck.Cards.Count - 1));
                //pulling the selected card's name value
                cardNameHolder = deck.Cards[cardDrawHolder].CardName;
                //adding the card to the GameManager Instance's hand via it's location in the list
                GameManager.Instance.HandCP3.Add(deck.Cards[cardDrawHolder]); //to add the card being removed from the deck, moves it to the hand
                //removing the same card from the deck list
                deck.Cards.Remove(deck.Cards[cardDrawHolder]);
            }
        }
    }

    //Function that takes the newly generated card based on it's name, and pairs the Sprite that shares that name with the SpriteRenderer passed into the function
    public void setSprite(SpriteRenderer sr)
    {
        //loading the texture base on the card name
        //Debug.Log(cardNameHolder);
        texSprite = Resources.Load<Texture2D>("Sprites/" + cardNameHolder);   
        //creating a sprite from said texture
        mySprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.666f);
        //FOR DEBUGGING ONLY: checking to make sure the sprite is not null
        if (texSprite == null)
        {
            Debug.Log("Sprite is null.");
        }
        //attaching the newly created sprite to the SpriteRenderer
        sr.sprite = mySprite;
        //sets the sorting level of the hand so thatcards do not stack weirdly on top of eachother
        sr.sortingOrder = GameManager.Instance.sortingOrder;
        GameManager.Instance.sortingOrder++;//makes sure it goes to the next order
        //setting the SpriteRenderer's sorting layer
        sr.sortingLayerName = "Default";
    }

    public void setSpriteCP1(SpriteRenderer sr)
    {
        //loading the texture base on the card name
        //Debug.Log(cardNameHolder);
        texSprite = Resources.Load<Texture2D>("Sprites/" + cardNameHolder);
        //creating a sprite from said texture
        mySprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.666f);
        //FOR DEBUGGING ONLY: checking to make sure the sprite is not null
        if (texSprite == null)
        {
            Debug.Log("Sprite is null.");
        }
        //attaching the newly created sprite to the SpriteRenderer
        sr.sprite = mySprite;
        //setting the SpriteRenderer's  sorting level
        sr.sortingOrder = GameManager.Instance.sortingOrder;
        GameManager.Instance.sortingOrder++;//makes sure it goes to the next order
        //setting the SpriteRenderer's sorting layer
        sr.sortingLayerName = "Default";
    }

    public void setSpriteCP2(SpriteRenderer sr)
    {
        //loading the texture base on the card name
        //Debug.Log(cardNameHolder);
        texSprite = Resources.Load<Texture2D>("Sprites/" + cardNameHolder);
        //creating a sprite from said texture
        mySprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.666f);
        //FOR DEBUGGING ONLY: checking to make sure the sprite is not null
        if (texSprite == null)
        {
            Debug.Log("Sprite is null.");
        }
        //attaching the newly created sprite to the SpriteRenderer
        sr.sprite = mySprite;
        //setting the SpriteRenderer's  sorting level
        sr.sortingOrder = GameManager.Instance.sortingOrder;
        GameManager.Instance.sortingOrder++; //makes sure that it goes to the next sorting order
        //setting the SpriteRenderer's sorting layer
        sr.sortingLayerName = "Default";
    }

    public void setSpriteCP3(SpriteRenderer sr)
    {
        //loading the texture base on the card name
        //Debug.Log(cardNameHolder);
        texSprite = Resources.Load<Texture2D>("Sprites/" + cardNameHolder);
        //creating a sprite from said texture
        mySprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.666f);
        //FOR DEBUGGING ONLY: checking to make sure the sprite is not null
        if (texSprite == null)
        {
            Debug.Log("Sprite is null.");
        }
        //attaching the newly created sprite to the SpriteRenderer
        sr.sprite = mySprite;
        //setting the SpriteRenderer's  sorting level
        sr.sortingOrder = GameManager.Instance.sortingOrder;
        GameManager.Instance.sortingOrder++; //makes sure it goes to the next sorting level
        //setting the SpriteRenderer's sorting layer
        sr.sortingLayerName = "Default";
    }

    //Function that takes the newly generated card based on it's name, and pairs the Sprite that shares that name with the SpriteRenderer passed into the function
    public void setSpriteForPicking(SpriteRenderer sr)
    {
        //loading the texture base on the card name
        //Debug.Log(cardNameHolder);
        texSprite = Resources.Load<Texture2D>("Sprites/" + cardNameHolder);
        //creating a sprite from said texture
        mySprite = Sprite.Create(texSprite, new Rect(0, 0, texSprite.width, texSprite.height), new Vector2(0.5f, 0.5f), 1.666f);
        //FOR DEBUGGING ONLY: checking to make sure the sprite is not null
        if (texSprite == null)
        {
            Debug.Log("Sprite is null.");
        }
        //attaching the newly created sprite to the SpriteRenderer
        sr.sprite = mySprite;
        //sets the sorting level of the hand so thatcards do not stack weirdly on top of eachother
        sr.sortingOrder = GameManager.Instance.sortingOrder;
        GameManager.Instance.sortingOrder++;//makes sure it goes to the next order
        //setting the SpriteRenderer's sorting layer
        sr.sortingLayerName = "Default";
    }
}
