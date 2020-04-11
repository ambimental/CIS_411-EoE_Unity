using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Computer : Player
{

   //this is to pass what ever version of computer is being used into methods
    private Computer currentPlayer;

    //requirements
    private RequirementsCP1 cardReqs; //to call the reqs function
    private ReqsCP1 reqs;
    private bool requirementsWork; //will help determine if the card should be placed or not

    /*
     *  @name       Initialize Objects() extend from parent class and ads additon info specific to human
     *  @purpose    acts as constuctor since unitiy doesnt let us create objects of classes normally. Is call when created in Game Manager class
     */
    public void InitializeObjects(string pScoreGameObject, string pRoundGameObject, string pHandGameObject, string pRegionGameObject, string pConditionGameObject,
        string pPlantGameObject, string pInvertebrateGameObject, string pAnimalGameObject, string pSpecialRegionGameObject, string pMultiplayerGameObject,
        string pMicrobeGameObject, string pFungiGameObject, string pDiscardGameObject, string pHumanGameObject, string pDeckColorGameObject,
        string pDeckTextGameObject)
    {
        //gets base parent class info
        base.InitializeObjects(pScoreGameObject, pRoundGameObject, pHandGameObject, pRegionGameObject, pConditionGameObject,
        pPlantGameObject, pInvertebrateGameObject, pAnimalGameObject, pSpecialRegionGameObject, pMultiplayerGameObject,
        pMicrobeGameObject, pFungiGameObject, pDiscardGameObject, pHumanGameObject, pDeckColorGameObject,
        pDeckTextGameObject);
        //info specific to computers
        CurrentPlayer = this;
        RequirementsWork = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    //starts the turn of the computer initially dealing 5 cards
    public void StartTurn()
    {
        //execute parent method
        base.StartTurn();
        //if it is the first round then deal 5 cards automatically
        if (GameManager.Instance.round == 1) //only happens in the first round
        {
            Draw(5);
        }
        //after the 5 cards aredealt, the proceded with computer AI alogorithm
        StartCoroutine("computerPerforms"); //goes through the function needed for the AI
    }

        /*
    *  @name       Draw(int pAmount) extends from parent
    *  @purpose    gets the card from the deck and calls generate card object and 
    */
    public void Draw(int pAmount)
    {
        //gets parent frunction
        base.Draw(pAmount);
        //checking to make sure there are cards left in the deck
        if (Deck.Cards.Count != 0)
        {
            //determins how many cards to draw
            for (int i = 0; i < pAmount; i++)
            {
                //retrieving the object created in the form of the "instance" earlier
                Holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>();
                CardParent = GameObject.Find(HandGameObject).transform;
                //calling  the object's CardDrawRandomizer function, which selects a random card from the deck
                Holder.CardDrawRandomizer(CurrentPlayer);
                //changes the sprite so the player cant see the cards in the computers hand
                Holder.CardNameHolder = "back_of_card";
                GenerateCardObject();
                Holder.setSprite(Sr); //generating the card object to be placed into the panel
            }
        }
        else
        {
            //retrieving the object created in the form of the "instance" earlier
            Holder = ScriptableObject.FindObjectOfType<CardRetrievalFromDeck>();
            //sets the parent
            CardParent = GameObject.Find(HandGameObject).transform;
            //calling the object's CardDrawRandomizer function, which selects a random card from the deck
            Holder.CardDrawRandomizer(CurrentPlayer);
            //changes the sprite so the player cant see the cards in the computers hand
            Holder.CardNameHolder = "back_of_card";
            //calling this script's generateCardObject function,  which creates an object to represent the card
            GenerateCardObject();
            //calling the script object's setSprite function, which passes in the SpriteRenderer, and sets it's sprite to the corresponding card chosen in CardDrawRandomizer
            Holder.setSprite(Sr);
        }
    }

    // Update is called once per frame
    void Update()
        {

        }

    /*
     *  @name       ThreeCardExecute() extends parent method
     *  @purpose    used once per game per player and will not be able to be used again once used
     */
    public void ThreeCardExecute()
    {
        base.ThreeCardExecute();
        Draw(3);
        ThreeCardBurstAvailable = false;
    }

    //where teh card things will take place
    IEnumerator computerPerforms()
    {
        //this determinines how many cards the computer draws
        DrawAmount();
        //draws the appropriate amount of cards
        Draw(DrawCount);

        ////this is where the requirements will be checked
        //for (int z = Hand.Count - 1; z > -1; z--) //done this way to avoid exception
        //{
            //i believe this is jsut to slow things down and create time
            for (int i = 0; i < 20; i++)
            {
                yield return null;
            }

        //    if (Hand[z].ReqID.Count != 0)
        //    {
        //        /*************************************Here is where we add new reuirements stuff*******************************************************/
        //        CardReqs = GameObject.Find("Main Camera").GetComponent<RequirementsCP1>();

        //        if (CardReqs.requirementCheck(Hand[z])) //determines if they work or not
        //            RequirementsWork = true;
        //        else RequirementsWork = false;
        //    }
        //    else
        //    {
        //        RequirementsWork = true; //allows it to be played
        //    }

        //    //if the requirement works then the card is placed in the proper area and move to the correct list
        //    //sc
        //    if (RequirementsWork == true)
        //    {
        //        if (Hand[z].CardType == "Region") //puts the card into the region placement
        //        {
        //            CardParent = GameObject.Find(RegionGameObject).transform;
        //            Holder.CardNameHolder = Hand[z].CardName;
        //            generateCardObject();
        //            Holder.setSprite(Sr); //generating the card object to be placed into the panel

        //            ChangeScore(Hand[z].PointValue);

        //            RegionPlacement.Add(Hand[z]); //adds it to the regions

        //            //checks the region type and changes the variable accordingly
        //            if (Hand[z].CardName.Contains("Arid"))
        //                AridCount++;
        //            else if (Hand[z].CardName.Contains("Forest"))
        //                ForestCount++;
        //            else if (Hand[z].CardName.Contains("Grasslands"))
        //                GrasslandsCount++;
        //            else if (Hand[z].CardName.Contains("Running-Water"))
        //                RunningWaterCount++;
        //            else if (Hand[z].CardName.Contains("Salt-Water"))
        //                SaltWaterCount++;
        //            else if (Hand[z].CardName.Contains("Standing-Water"))
        //                StandingWaterCount++;
        //            else if (Hand[z].CardName.Contains("Sub-Zero"))
        //                SubZeroCount++;

        //            Hand.Remove(Hand[z]);

        //            CardParent = GameObject.Find(HandGameObject).transform;

        //            //to keep from a null excpetion error
        //            if (Hand.Count > 0)
        //                Destroy(CardParent.GetChild(0).gameObject);
        //        }
        //        else if (Hand[z].CardType == "Condition") //puts the card into the condition card
        //        {
        //            CardParent = GameObject.Find(ConditionGameObject).transform;
        //            Holder.CardNameHolder = Hand[z].CardName;
        //            generateCardObject();
        //            Holder.setSprite(Sr); //generating the card object to be placed into the panel

        //            ChangeScore(Hand[z].PointValue);

        //            ConditionPlacement.Add(Hand[z]); //adds it to the regions

        //            Hand.Remove(Hand[z]);

        //            CardParent = GameObject.Find(HandGameObject).transform;

        //            if (CardParent.childCount != 0)
        //                Destroy(CardParent.GetChild(0).gameObject);
        //        }
        //        else if (Hand[z].CardType == "Plant") //puts the card into the plant type
        //        {
        //            CardParent = GameObject.Find(PlantGameObject).transform;
        //            Holder.CardNameHolder = Hand[z].CardName;
        //            generateCardObject();
        //            Holder.setSprite(Sr); //generating the card object to be placed into the panel

        //            ChangeScore(Hand[z].PointValue);

        //            PlantPlacement.Add(Hand[z]); //adds it to the regions

        //            Hand.Remove(Hand[z]);

        //            CardParent = GameObject.Find(HandGameObject).transform;

        //            //to avoid a null exception error
        //            if (CardParent.childCount != 0)
        //                Destroy(CardParent.GetChild(0).gameObject);
        //        }
        //        else if (Hand[z].CardType == "Invertebrate") //puts the card into the invertebrate pile
        //        {
        //            CardParent = GameObject.Find(InvertebrateGameObject).transform;
        //            Holder.CardNameHolder = Hand[z].CardName;
        //            generateCardObject();
        //            Holder.setSprite(Sr); //generating the card object to be placed into the panel

        //            ChangeScore(Hand[z].PointValue);

        //            InvertebratePlacement.Add(Hand[z]); //adds it to the regions

        //            Hand.Remove(Hand[z]);

        //            CardParent = GameObject.Find(HandGameObject).transform;

        //            if (CardParent.childCount != 0)
        //                Destroy(CardParent.GetChild(0).gameObject);
        //        }
        //        else if (Hand[z].CardType == "Animal") //puts the cards into the animal pile
        //        {
        //            CardParent = GameObject.Find(AnimalGameObject).transform;
        //            Holder.CardNameHolder = Hand[z].CardName;
        //            generateCardObject();
        //            Holder.setSprite(Sr); //generating the card object to be placed into the panel

        //            ChangeScore(Hand[z].PointValue);

        //            AnimalPlacement.Add(Hand[z]); //adds it to the regions

        //            Hand.Remove(Hand[z]);

        //            CardParent = GameObject.Find(HandGameObject).transform;

        //            if (CardParent.childCount != 0)
        //                Destroy(CardParent.GetChild(0).gameObject);
        //        }
        //        else if (Hand[z].CardType == "Special Region") //puts the card into the special region pile
        //        {
        //            CardParent = GameObject.Find(SpecialRegionGameObject).transform;
        //            Holder.CardNameHolder = Hand[z].CardName;
        //            generateCardObject();
        //            Holder.setSprite(Sr); //generating the card object to be placed into the panel

        //            ChangeScore(Hand[z].PointValue);

        //            SpecialRegionPlacement.Add(Hand[z]); //adds it to the regions

        //            Hand.Remove(Hand[z]);

        //            CardParent = GameObject.Find(HandGameObject).transform;

        //            if (CardParent.childCount != 0)
        //                Destroy(CardParent.GetChild(0).gameObject);
        //        }
        //        else if (Hand[z].CardType == "Multi-Player") //puts the card into the multiplayer pile
        //        {
        //            CardParent = GameObject.Find(MultiplayerGameObject).transform;
        //            Holder.CardNameHolder = Hand[z].CardName;
        //            generateCardObject();
        //            Holder.setSprite(Sr); //generating the card object to be placed into the panel

        //            ChangeScore(Hand[z].PointValue);

        //            MultiPlacement.Add(Hand[z]); //adds it to the regions

        //            Hand.Remove(Hand[z]);

        //            CardParent = GameObject.Find(HandGameObject).transform;

        //            if (CardParent.childCount != 0)
        //                Destroy(CardParent.GetChild(0).gameObject);
        //        }
        //        else if (Hand[z].CardType == "Microbe") //puts the card into the microbe pile
        //        {
        //            CardParent = GameObject.Find(MicrobeGameObject).transform;
        //            Holder.CardNameHolder = Hand[z].CardName;
        //            generateCardObject();
        //            Holder.setSprite(Sr); //generating the card object to be placed into the panel

        //            ChangeScore(Hand[z].PointValue);

        //            MicrobePlacement.Add(Hand[z]); //adds it to the regions

        //            Hand.Remove(Hand[z]);

        //            CardParent = GameObject.Find(HandGameObject).transform;

        //            if (CardParent.childCount != 0)
        //                Destroy(CardParent.GetChild(0).gameObject);
        //        }

        //        else if (Hand[z].CardType == "Fungi") //puts the card into the fungi pile
        //        {
        //            CardParent = GameObject.Find(FungiGameObject).transform;
        //            Holder.CardNameHolder = Hand[z].CardName;
        //            generateCardObject();
        //            Holder.setSprite(Sr); //generating the card object to be placed into the panel

        //            ChangeScore(Hand[z].PointValue);

        //            FungiPlacement.Add(Hand[z]); //adds it to the regions

        //            Hand.Remove(Hand[z]);

        //            CardParent = GameObject.Find(HandGameObject).transform;

        //            if (CardParent.childCount != 0)
        //                Destroy(CardParent.GetChild(0).gameObject);
        //        }
        //    }
        //}

        //if (Hand.Count != 0) //if there is a card left in the hand, it will discad the firsts one
        //{
        //    CardParent = GameObject.Find(DiscardGameObject).transform;
        //    Holder.CardNameHolder = Hand[0].CardName;
        //    generateCardObject();
        //    Holder.setSprite(Sr);

        //    DiscardPlacement.Add(Hand[0]);
        //    Hand.Remove(Hand[0]);

        //    CardParent = GameObject.Find(HandGameObject).transform;

        //    if (CardParent.childCount != 0)
        //        Destroy(CardParent.GetChild(0).gameObject);

            for (int i = 0; i < 20; i++)
            {
                yield return null;
            }

        //    CameraHolder.AddComponent<CP2AI>(); //adds the script to the main camera so that the player 2 AI starts

        //    Object.Destroy(CameraHolder.GetComponent<CP1AI>()); //destryos the cp1 script
        //}
        //else //if there are no cards left in the hand, will just automatically go to the next player
        //{
        //    //this just creates time
        //    for (int i = 0; i < 20; i++)
        //    {
        //        yield return null;
        //    }
        //}
    }

    //accessors and mutators
    public RequirementsCP1 CardReqs { get => cardReqs; set => cardReqs = value; }
    public ReqsCP1 Reqs { get => reqs; set => reqs = value; }
    public bool RequirementsWork { get => requirementsWork; set => requirementsWork = value; }
    public Computer CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
}
