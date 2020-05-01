/*
 *  @class      DoublClick.cs
 *  @purpose    Double click cards and choose their actions
 *  
 *  @author     CIS411
 *  @date       2020/01/22
 */
/* THIS SCRIPT WILL BE USED TO DOUBLE CLICK ON CARDS IN THE PLAYING FIELD - FOR NOW YOU WILL ONLY BE ABLE TO CLICK THE CARDS THAT YOU HAVE PLAYED AND THAT 
   ARE ON THE FIELD, NOT IN YOUR HAND.

   ---> Double click action
     ---> Open up panel
       ---> Display card image and card information
         --->have the ability to close the panel or if the card has an action, to perform that action
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoubleClickDescription : MonoBehaviour, IPointerClickHandler
{
    private Text nameOfCard;
    private Image imageOfCard;
    private Text descriptionOfCard;
    private Text actions;
    //private Button buttonActionEnabler;
    private Card cardHolder;
    private Player thePlayer; //will be used to hold the card info 

    ///*********************************************************************/
    ////this is all added for the multiplayer functionality
    ////used to find which computer the humans multiplayer card effects
    //private string multiplayerComputer;
    ////multiplayer buttons
    //private Button buttonMultiComputerOne;
    //private Button buttonMultiComputerTwo;
    //private Button buttonMultiComputerThree;
    //private Computer comp;




    // Use this for initialization
    void Start()
    {

        //this creates an instacne of the hover class to make sure the card goes back to size
        //initializing Human Person Player

        //ButtonMultiComputerOne = GameObject.Find("MultiComputerOneButton").GetComponent<Button>();
        //ButtonMultiComputerTwo = GameObject.Find("MultiComputerTwoButton").GetComponent<Button>();
        //ButtonMultiComputerThree = GameObject.Find("MultiComputerThreeButton").GetComponent<Button>();

        ////adds listeneers to the buttons
        //ButtonMultiComputerOne.onClick.AddListener(ButtonOneClick);
        //ButtonMultiComputerTwo.onClick.AddListener(ButtonTwoClick);
        //ButtonMultiComputerThree.onClick.AddListener(ButtonThreeClick);

    }

    /*
      * @name    CreatePlayer()
      * @purpose Creates a player object so this class can be used by all
      * 
      */
    public void CreatePlayer(Player pPlayer)
    {
        ThePlayer = pPlayer;
        CastPlayer();
    }
    
    /*
      * @name    CastPlayer()
      * @purpose This downcasts the correct player to wether or not it is a human or computer.
      * 
      * @return  bool
      */
    public void CastPlayer()
    {
        if (ThePlayer.GetType() == typeof(Human))
        {
            ThePlayer = (Human)ThePlayer;
        }
        else
        {
            ThePlayer = (Computer)ThePlayer;
        }
    }

    // Update is called once per frame
    void Update(){ }


    ///****************************************************/
    ///****************************************************/
    ////this is all stuff for the multi player

    //void ButtonOneClick()
    //{
    //    MultiplayerButtonClick("ComputerOne");
    //}
    //void ButtonTwoClick()
    //{
    //    MultiplayerButtonClick("ComputerTwo");
    //}
    //void ButtonThreeClick()
    //{
    //    MultiplayerButtonClick("ComputerThree");
    //}

    //public void ShowMultiplayerButtons()
    //{
    //    ButtonMultiComputerOne.interactable = true;
    //    ButtonMultiComputerTwo.interactable = true;
    //    ButtonMultiComputerThree.interactable = true;
    //}

    ////assigns the correct computer object based off whoch butto was clicked
    //public void AssignComputer(string pComputer)
    //{
    //    if(pComputer == "ComputerOne")
    //    {
    //        Comp = GameManager.Instance.CP1;
    //    }
    //    else if (pComputer == "ComputerTwo")
    //    {
    //        Comp = GameManager.Instance.CP2;
    //    }
    //    else if (pComputer == "ComputerThree")
    //    {
    //        Comp = GameManager.Instance.CP3;
    //    }
    //}

    //public void ShowBoards()
    //{
    //    if (Comp == GameManager.Instance.CP1)
    //    {
    //        GameManager.Instance.HideShow.ShowCP1();
    //    }
    //    else if (Comp == GameManager.Instance.CP2)
    //    {
    //        GameManager.Instance.HideShow.ShowCP2();
    //    }
    //    else if (Comp == GameManager.Instance.CP3)
    //    {
    //        GameManager.Instance.HideShow.ShowCP3();
    //    }
    //}

    //public void MultiplayerButtonClick(string pComputer)
    //{
    //    //assigns the correct computer to the computer object
    //    AssignComputer(pComputer);
    //    //calls the test function to carry out the moving of cards
    //    MoveMultiCard();
    //}


    //public void MoveMultiCard()
    //{
    //    Debug.Log("begin test function");
    //    //makes sure that the approapiate canvas is displayed quickly so the graphic can be painted becasue you cant change
    //    //ui elements without the screen being visible
    //    ShowBoards();
    //    Debug.Log("show baords was called");
    //    //this is to take the current instacnce which is the card that was double clicked and assigns it to temp object
    //    //SETTING THE FILTERS FOR THE CARDS NAMES SO THAT THEY PRINT OUT PROPERLY
    //    string nameHolder = this.gameObject.name; //this will be used to hold the name until it is correct
    //    Transform parentHolder = this.gameObject.transform.parent;

    //    //goes through and matches the name, then proceeds to print the actions
    //    for (int i = 0; i < ThePlayer.Hand.Count; i++)
    //    {
    //        if (ThePlayer.Hand[i].CardName == nameHolder)
    //        {
    //            CardHolder = ThePlayer.Hand[i]; //sets the card holder for the rest of the things needed to be set
    //        }
    //    }

    //    if (nameHolder.Contains("Special")) //special region filter
    //    {
    //        this.transform.SetParent(GameObject.Find(Comp.SpecialRegionGameObject).transform);
    //        this.transform.localScale = new Vector3(1.0f, 1.0f, 0);
    //        Comp.SpecialRegionPlacement.Add(CardHolder);
    //        ThePlayer.Hand.Remove(CardHolder);
    //    }
    //    else if (nameHolder.Contains("Region")) //region name filter
    //    {           
    //        this.transform.SetParent(GameObject.Find(Comp.RegionGameObject).transform);
    //        this.transform.localScale = new Vector3(1.0f, 1.0f, 0);
    //        Comp.RegionPlacement.Add(CardHolder);
    //        ThePlayer.Hand.Remove(CardHolder);
    //    }
    //    else if (nameHolder.Contains("Plant")) //plant name filter
    //    {
    //        this.transform.SetParent(GameObject.Find(Comp.PlantGameObject).transform);
    //        this.transform.localScale = new Vector3(1.0f, 1.0f, 0);
    //        Comp.PlantPlacement.Add(CardHolder);
    //        ThePlayer.Hand.Remove(CardHolder);
    //    }
    //    else if (nameHolder.Contains("Multi")) //multiplayer name filter
    //    {
    //        this.transform.SetParent(GameObject.Find(Comp.MultiplayerGameObject).transform);
    //        this.transform.localScale = new Vector3(1.0f, 1.0f, 0);
    //        Comp.MultiPlacement.Add(CardHolder);
    //        ThePlayer.Hand.Remove(CardHolder);
    //    }
    //    else if (nameHolder.Contains("Condition")) //condition name filter
    //    {
    //        this.transform.SetParent(GameObject.Find(Comp.ConditionGameObject).transform);
    //        this.transform.localScale = new Vector3(1.0f, 1.0f, 0);
    //        Comp.ConditionPlacement.Add(CardHolder);
    //        ThePlayer.Hand.Remove(CardHolder);
    //    }
    //    else if (nameHolder.Contains("Invertebrate")) //invertebrate name filter
    //    {
    //        this.transform.SetParent(GameObject.Find(Comp.InvertebrateGameObject).transform);
    //        this.transform.localScale = new Vector3(1.0f, 1.0f, 0);
    //        Comp.InvertebratePlacement.Add(CardHolder);
    //        ThePlayer.Hand.Remove(CardHolder);
    //    }
    //    else if (nameHolder.Contains("Fungi")) //fungi name filter
    //    {
    //        this.transform.SetParent(GameObject.Find(Comp.FungiGameObject).transform);
    //        this.transform.localScale = new Vector3(1.0f, 1.0f, 0);
    //        Comp.FungiPlacement.Add(CardHolder);
    //        ThePlayer.Hand.Remove(CardHolder);
    //    }
    //    else if (nameHolder.Contains("Human")) //humam name filter
    //    {
    //        this.transform.SetParent(GameObject.Find(Comp.HumanGameObject).transform);
    //        this.transform.localScale = new Vector3(1.0f, 1.0f, 0);
    //        Comp.HumanPlacement.Add(CardHolder);
    //        ThePlayer.Hand.Remove(CardHolder);
    //    }
    //    else if (nameHolder.Contains("Animal")) //animal name filter
    //    {
    //        this.transform.SetParent(GameObject.Find(Comp.AnimalGameObject).transform);
    //        this.transform.localScale = new Vector3(1.0f, 1.0f, 0);
    //        Comp.AnimalPlacement.Add(CardHolder);
    //        ThePlayer.Hand.Remove(CardHolder);
    //    }
    //    else if (nameHolder.Contains("Microbe")) //microbe name filter
    //    {
    //        this.transform.SetParent(GameObject.Find(Comp.MicrobeGameObject).transform);
    //        this.transform.localScale = new Vector3(1.0f, 1.0f, 0);
    //        Comp.MicrobePlacement.Add(CardHolder);
    //        ThePlayer.Hand.Remove(CardHolder);
    //    }

    //    //shows the human canvas screen
    //    GameManager.Instance.HideShow.ShowPlayer();
    //}

    ////end of multiplayer stuff

    ///****************************************************/
    ///****************************************************/

    public void OnPointerClick(PointerEventData eventData)
    {
        //makes sure that it was double clicked
        if (eventData.clickCount == 2)
        {
            //shows the card info board
            GameManager.Instance.HideShow.ShowCardInfo();

            //assigns the objects to UI objects
            NameOfCard = GameObject.Find("CardName").GetComponent<Text>();
            ImageOfCard = GameObject.Find("CardImage").GetComponent<Image>();
            DescriptionOfCard = GameObject.Find("CardDescription").GetComponent<Text>();
            //ButtonActionEnabler = GameObject.Find("ActionButton").GetComponent<Button>();

            //SETTING THE FILTERS FOR THE CARDS NAMES SO THAT THEY PRINT OUT PROPERLY
            string nameHolder = this.gameObject.name; //this will be used to hold the name until it is correct
            Transform parentHolder = this.gameObject.transform.parent;

            //goes through and matches the name, then proceeds to print the actions
            for (int i = 0; i < ThePlayer.Hand.Count; i++)
            {
                if (ThePlayer.Hand[i].CardName == nameHolder)
                {
                    CardHolder = ThePlayer.Hand[i]; //sets the card holder for the rest of the things needed to be set
                }
            }

            if (nameHolder.Contains("Special")) //special region filter
            {
                Description();

                string[] name = nameHolder.Split('-');
                string anotherName = "";

                for (int i = 2; i < name.Length; i++)
                    anotherName += name[i] + " ";

                NameOfCard.text = anotherName;

                //prints the actions
                DescriptionOfCard.text += "\n" + CardHolder.StandingAction.ToString();

                if (CardHolder.SpecialAction == "" || CardHolder.SpecialAction == null)
                {
                    //ButtonActionEnabler.gameObject.SetActive(false);
                }
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    //ButtonActionEnabler.gameObject.SetActive(true);
                }
            }
            else if (nameHolder.Contains("Region")) //region name filter
            {

                DescriptionOfCard.text = ""; //just resets it incase there is one that is completeley empty

                //goes through andmatches the name, then proceeds to print the actions
                for (int i = 0; i < ThePlayer.Hand.Count; i++)
                {
                    if (ThePlayer.Hand[i].CardName == nameHolder)
                    {
                        CardHolder = ThePlayer.Hand[i]; //sets the card holder for the rest of the things needed to be set
                    }
                }

                Description();

                if (nameHolder.Contains("Forest"))
                    NameOfCard.text = "Forest";
                else if (nameHolder.Contains("Running-Water"))
                    NameOfCard.text = "Running Water";
                else if (nameHolder.Contains("Standing-Water"))
                    NameOfCard.text = "Standing Water";
                else if (nameHolder.Contains("Grasslands"))
                    NameOfCard.text = "Grasslands";

                //prints the actions
                DescriptionOfCard.text += "\n" + CardHolder.StandingAction;

                if (CardHolder.SpecialAction == "" || CardHolder.SpecialAction == null)
                {
                    //ButtonActionEnabler.gameObject.SetActive(false);
                }
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    //ButtonActionEnabler.gameObject.SetActive(true);
                }
            }
            else if (nameHolder.Contains("Plant")) //plant name filter
            {
                DescriptionOfCard.text = ""; //just resets it incase there is one that is completeley empty

                //goes through andmatches the name, then proceeds to print the actions
                for (int i = 0; i < ThePlayer.Hand.Count; i++)
                {
                    if (ThePlayer.Hand[i].CardName == nameHolder)
                    {
                        CardHolder = ThePlayer.Hand[i]; //sets the card holder for the rest of the things needed to be set
                    }
                }

                Description();

                string[] name = nameHolder.Split('-');
                string anotherName = "";

                for (int i = 1; i < name.Length; i++)
                    anotherName += name[i] + " ";

                NameOfCard.text = anotherName;

                //prints the actions
                DescriptionOfCard.text += "\n" + CardHolder.StandingAction;

                if (CardHolder.SpecialAction == "" || CardHolder.SpecialAction == null)
                {
                    //ButtonActionEnabler.gameObject.SetActive(false);
                }
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    //ButtonActionEnabler.gameObject.SetActive(true);
                }
            }
            else if (nameHolder.Contains("Multi")) //multiplayer name filter
            {


                //shows the multiplayer buttons on screen
               // ShowMultiplayerButtons();

                DescriptionOfCard.text = ""; //just resets it incase there is one that is completeley empty

                //goes through andmatches the name, then proceeds to print the actions
                for (int i = 0; i < ThePlayer.Hand.Count; i++)
                {
                    if (ThePlayer.Hand[i].CardName == nameHolder)
                    {
                        CardHolder = ThePlayer.Hand[i]; //sets the card holder for the rest of the things needed to be set
                    }
                }

                Description();

                string[] name = nameHolder.Split('-');
                string anotherName = "";

                for (int i = 1; i < name.Length; i++)
                    anotherName += name[i] + " ";

                NameOfCard.text = anotherName;

                //prints the actions
                DescriptionOfCard.text += "\n" + CardHolder.StandingAction;

                if (CardHolder.SpecialAction == "" || CardHolder.SpecialAction == null)
                {
                    // ButtonActionEnabler.gameObject.SetActive(false);
                }
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    //ButtonActionEnabler.gameObject.SetActive(true);
                }
            }
            else if (nameHolder.Contains("Condition")) //condition name filter
            {
                DescriptionOfCard.text = ""; //just resets it incase there is one that is completeley empty

                //goes through andmatches the name, then proceeds to print the actions
                for (int i = 0; i < ThePlayer.Hand.Count; i++)
                {
                    if (ThePlayer.Hand[i].CardName == nameHolder)
                    {
                        CardHolder = ThePlayer.Hand[i]; //sets the card holder for the rest of the things needed to be set
                    }
                }

                Description();

                string[] name = nameHolder.Split('-');
                string anotherName = "";

                for (int i = 1; i < name.Length; i++)
                    anotherName += name[i] + " ";

                NameOfCard.text = anotherName;

                //prints the actions
                DescriptionOfCard.text += "\n" + CardHolder.StandingAction;

                if (CardHolder.SpecialAction == "" || CardHolder.SpecialAction == null)
                {
                    //ButtonActionEnabler.gameObject.SetActive(false);
                }
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    //ButtonActionEnabler.gameObject.SetActive(true);
                }
            }
            else if (nameHolder.Contains("Invertebrate")) //invertebrate name filter
            {
                DescriptionOfCard.text = ""; //just resets it incase there is one that is completeley empty

                //goes through andmatches the name, then proceeds to print the actions
                for (int i = 0; i < ThePlayer.Hand.Count; i++)
                {
                    if (ThePlayer.Hand[i].CardName == nameHolder)
                    {
                        CardHolder = ThePlayer.Hand[i]; //sets the card holder for the rest of the things needed to be set
                    }
                }

                Description();

                string[] name = nameHolder.Split('-');
                string anotherName = "";

                for (int i = 1; i < name.Length; i++)
                    anotherName += name[i] + " ";

                NameOfCard.text = anotherName;

                //prints the actions
                DescriptionOfCard.text += "\n" + CardHolder.StandingAction;

                if (CardHolder.SpecialAction == "" || CardHolder.SpecialAction == null)
                {
                    //ButtonActionEnabler.gameObject.SetActive(false);
                }
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    //ButtonActionEnabler.gameObject.SetActive(true);
                }
            }
            else if (nameHolder.Contains("Fungi")) //fungi name filter
            {
                DescriptionOfCard.text = ""; //just resets it incase there is one that is completeley empty

                //goes through andmatches the name, then proceeds to print the actions
                for (int i = 0; i < ThePlayer.Hand.Count; i++)
                {
                    if (ThePlayer.Hand[i].CardName == nameHolder)
                    {
                        CardHolder = ThePlayer.Hand[i]; //sets the card holder for the rest of the things needed to be set
                    }
                }

                Description();

                string[] name = nameHolder.Split('-');
                string anotherName = "";

                for (int i = 1; i < name.Length; i++)
                    anotherName += name[i] + " ";

                NameOfCard.text = anotherName;

                //prints the actions
                DescriptionOfCard.text += "\n" + CardHolder.StandingAction;

                if (CardHolder.SpecialAction == "" || CardHolder.SpecialAction == null)
                {
                    //ButtonActionEnabler.gameObject.SetActive(false);
                }
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                   // ButtonActionEnabler.gameObject.SetActive(true);
                }
            }
            else if (nameHolder.Contains("Human")) //humam name filter
            {
                DescriptionOfCard.text = ""; //just resets it incase there is one that is completeley empty

                //goes through andmatches the name, then proceeds to print the actions
                for (int i = 0; i < ThePlayer.Hand.Count; i++)
                {
                    if (ThePlayer.Hand[i].CardName == nameHolder)
                    {
                        CardHolder = ThePlayer.Hand[i];
                    }
                }

                Description();

                string[] name = nameHolder.Split('-');
                string anotherName = "";

                for (int i = 1; i < name.Length; i++)
                    anotherName += name[i] + " ";

                NameOfCard.text = anotherName;

                //prints the actions
                DescriptionOfCard.text += "\n" + CardHolder.StandingAction;

                if (CardHolder.SpecialAction == "" || CardHolder.SpecialAction == null)
                {
                    //ButtonActionEnabler.gameObject.SetActive(false);
                }
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    //ButtonActionEnabler.gameObject.SetActive(true);
                }
            }
            else if (nameHolder.Contains("Animal")) //animal name filter
            {
                DescriptionOfCard.text = ""; //just resets it incase there is one that is completeley empty

                //goes through andmatches the name, then proceeds to print the actions
                for (int i = 0; i < ThePlayer.Hand.Count; i++)
                {
                    if (ThePlayer.Hand[i].CardName == nameHolder)
                    {
                        CardHolder = ThePlayer.Hand[i]; //sets the card holder for the rest of the things needed to be set
                    }
                }

                Description();

                string[] name = nameHolder.Split('-');
                string anotherName = "";

                for (int i = 1; i < name.Length; i++)
                    anotherName += name[i] + " ";

                NameOfCard.text = anotherName;

                //prints the actions
                DescriptionOfCard.text += "\n" + CardHolder.StandingAction;

                if (CardHolder.SpecialAction == "" || CardHolder.SpecialAction == null)
                {
                    //ButtonActionEnabler.gameObject.SetActive(false);
                }
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    //ButtonActionEnabler.gameObject.SetActive(true);
                }
            }
            else if (nameHolder.Contains("Microbe")) //microbe name filter
            {
                DescriptionOfCard.text = ""; //just resets it incase there is one that is completeley empty

                //goes through andmatches the name, then proceeds to print the actions
                for (int i = 0; i < ThePlayer.Hand.Count; i++)
                {
                    if (ThePlayer.Hand[i].CardName == nameHolder)
                    {
                        CardHolder = ThePlayer.Hand[i]; //sets the card holder for the rest of the things needed to be set
                    }
                }

                Description();

                string[] name = nameHolder.Split('-');
                string anotherName = "";

                for (int i = 1; i < name.Length; i++)
                    anotherName += name[i] + " ";

                NameOfCard.text = anotherName;

                //prints the actions
                DescriptionOfCard.text += "\n" + CardHolder.StandingAction;

                if (CardHolder.SpecialAction == "" || CardHolder.SpecialAction == null)
                {
                    //ButtonActionEnabler.gameObject.SetActive(false);
                }
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    //ButtonActionEnabler.gameObject.SetActive(true);
                }
            }

            //sets the image to the current image of card
            ImageOfCard.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void Description()
        {
            //adding the description based off of everything else
            if (CardHolder.Kingdom != "")
                DescriptionOfCard.text += "Kingdom: " + CardHolder.Kingdom + "\n";
            if (CardHolder.Subkingdom != "")
                DescriptionOfCard.text += "SubKingdom: " + CardHolder.Subkingdom + "\n";
            if (CardHolder.Superphylum != "")
                DescriptionOfCard.text += "Superphylum: " + CardHolder.Superphylum + "\n";
            if (CardHolder.Phylum != "")
                DescriptionOfCard.text += "Phylum: " + CardHolder.Phylum + "\n";
            if (CardHolder.Subphylum != "")
                DescriptionOfCard.text += "SubPhylum: " + CardHolder.Subphylum + "\n";
            if (CardHolder.Superclass != "")
                DescriptionOfCard.text += "Superclass: " + CardHolder.Superclass + "\n";
            if (CardHolder.CardClass != "")
                DescriptionOfCard.text += "Class: " + CardHolder.CardClass + "\n";
            if (CardHolder.Subclass != "")
                DescriptionOfCard.text += "Subclass: " + CardHolder.Subclass + "\n";
            if (CardHolder.Superorder != "")
                DescriptionOfCard.text += "Superorder: " + CardHolder.Superorder + "\n";
            if (CardHolder.Order != "")
                DescriptionOfCard.text += "Order: " + CardHolder.Order + "\n";
            if (CardHolder.Suborder != "")
                DescriptionOfCard.text += "Suborder: " + CardHolder.Suborder + "\n";
            if (CardHolder.Superfamily != "")
                DescriptionOfCard.text += "Superfamily: " + CardHolder.Superfamily + "\n";
            if (CardHolder.Family != "")
                DescriptionOfCard.text += "Fsmily: " + CardHolder.Family + "\n";
            if (CardHolder.Subfamily != "")
                DescriptionOfCard.text += "Subfamily: " + CardHolder.Subfamily + "\n";
            if (CardHolder.Supergenus != "")
                DescriptionOfCard.text += "Supergenus: " + CardHolder.Supergenus + "\n";
            if (CardHolder.Genus != "")
                DescriptionOfCard.text += "Genus: " + CardHolder.Genus + "\n";
            if (CardHolder.Subgenus != "")
                DescriptionOfCard.text += "Subgenus: " + CardHolder.Subgenus + "\n";
            if (CardHolder.Species != "")
                DescriptionOfCard.text += "Species: " + CardHolder.Species + "\n";
            if (CardHolder.Subspecies != "")
                DescriptionOfCard.text += "Subspecies: " + CardHolder.Subspecies + "\n";
            if (CardHolder.AnimalSize != "")
                DescriptionOfCard.text += "Animal Size: " + CardHolder.AnimalSize + "\n";
            if (CardHolder.AnimalEnvironment != "")
                DescriptionOfCard.text += "Animal Environment: " + CardHolder.AnimalEnvironment + "\n";
            if (CardHolder.AnimalDiet != "")
                DescriptionOfCard.text += "Animal Diet: " + CardHolder.AnimalDiet + "\n";
            if (CardHolder.PlantType != "")
                DescriptionOfCard.text += "Plant Type: " + CardHolder.PlantType + "\n";
            if (CardHolder.RegionType != "")
                DescriptionOfCard.text += "Regiontype: " + CardHolder.RegionType + "\n";
            if (CardHolder.Domain != "")
                DescriptionOfCard.text += "Domain: " + CardHolder.Domain + "\n";
            if (CardHolder.Infraclass != "")
                DescriptionOfCard.text += "Infraclass: " + CardHolder.Infraclass + "\n";
            if (CardHolder.Infraorder != "")
                DescriptionOfCard.text += "Infraorder: " + CardHolder.Infraorder + "\n";
            if (CardHolder.Section != "")
                DescriptionOfCard.text += "Section: " + CardHolder.Section + "\n";
            if (CardHolder.Tribe != "")
                DescriptionOfCard.text += "Tribe: " + CardHolder.Tribe + "\n";
            if (CardHolder.Division != "")
                DescriptionOfCard.text += "Division: " + CardHolder.Division + "\n";
            if (CardHolder.Superdivision != "")
                DescriptionOfCard.text += "Superdivision: " + CardHolder.Superdivision + "\n";
            if (CardHolder.Subdivision != "")
                DescriptionOfCard.text += "Subdivision: " + CardHolder.Subdivision + "\n";
            if (CardHolder.Fungi_type != "")
                DescriptionOfCard.text += "Fungi Type: " + CardHolder.Fungi_type + "\n";
    }

    //accessors and mutators
    public Player ThePlayer { get => thePlayer; set => thePlayer = value; }
    public Text NameOfCard { get => nameOfCard; set => nameOfCard = value; }
    public Image ImageOfCard { get => imageOfCard; set => imageOfCard = value; }
    public Text DescriptionOfCard { get => descriptionOfCard; set => descriptionOfCard = value; }
    public Text Actions { get => actions; set => actions = value; }
    //public Button ButtonActionEnabler { get => buttonActionEnabler; set => buttonActionEnabler = value; }
    public Card CardHolder { get => cardHolder; set => cardHolder = value; }
    //public string MultiplayerComputer { get => multiplayerComputer; set => multiplayerComputer = value; }
    //public Button ButtonMultiComputerOne { get => buttonMultiComputerOne; set => buttonMultiComputerOne = value; }
    //public Button ButtonMultiComputerTwo { get => buttonMultiComputerTwo; set => buttonMultiComputerTwo = value; }
    //public Button ButtonMultiComputerThree { get => buttonMultiComputerThree; set => buttonMultiComputerThree = value; }
    //public Computer Comp { get => comp; set => comp = value; }
}
