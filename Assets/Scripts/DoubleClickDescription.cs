<<<<<<< Updated upstream
﻿///* THIS SCRIPT WILL BE USED TO DOUBLE CLICK ON CARDS IN THE PLAYING FIELD - FOR NOW YOU WILL ONLY BE ABLE TO CLICK THE CARDS THAT YOU HAVE PLAYED AND THAT 
//   ARE ON THE FIELD, NOT IN YOUR HAND.

//   ---> Double click action
//     ---> Open up panel
//       ---> Display card image and card information
//         --->have the ability to close the panel or if the card has an action, to perform that action
//*/


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class DoubleClickDescription : MonoBehaviour, IPointerClickHandler {

//    public GameObject showCardInfo;
//    public RectTransform cardinfo;

//    public Text nameOfCard;
//    public Image imageOfCard;
//    public Text description;
//    public Text actions;
//    public Button buttonEnabler;

//    public Card cardHolder; //will be used to hold the card info 

//	// Use this for initialization
//	void Start () {

//        showCardInfo = GameManager.Instance.cardInfoPanel; //stores the panel in an object
//        cardinfo = showCardInfo.GetComponent<RectTransform>();

//        nameOfCard = GameManager.Instance.nameCard;
//        imageOfCard = GameManager.Instance.imageCard;
//        description = GameManager.Instance.descriptionCard;
//        buttonEnabler = GameManager.Instance.specialActionButton;
//    }
	
//	// Update is called once per frame
//	void Update () {
		
//	}

//    public void OnPointerClick(PointerEventData eventData)
//    {
//        showCardInfo.SetActive(true); //shows the panel
//        cardinfo.SetAsLastSibling();

//        //SETTING THE FILTERS FOR THE CARDS NAMES SO THAT THEY PRINT OUT PROPERLY
//        string nameHolder = this.gameObject.name; //this will be used to hold the name until it is correct

//        if (this.gameObject.transform.parent == GameObject.Find("Hand").transform) //if the card that is clicked is currenty in the hand of the player
//        {
//            //goes through and matches the name, then proceeds to print the actions
//            for (int i = 0; i < GameManager.Instance.Hand.Count; i++)
//            {
//                if (GameManager.Instance.Hand[i].CardName == nameHolder)
//                {
//                    cardHolder = GameManager.Instance.Hand[i]; //sets the card holder for the rest of the things needed to be set
//                }
//            }

//            if (nameHolder.Contains("Special")) //special region filter
//            {
//                //adding the description based off of everything else
//                if (cardHolder.Kingdom != "")
//                    description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//                if (cardHolder.Subkingdom != "")
//                    description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//                if (cardHolder.Superphylum != "")
//                    description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//                if (cardHolder.Phylum != "")
//                    description.text += "Phylum: " + cardHolder.Phylum + "\n";
//                if (cardHolder.Subphylum != "")
//                    description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//                if (cardHolder.Superclass != "")
//                    description.text += "Superclass: " + cardHolder.Superclass + "\n";
//                if (cardHolder.CardClass != "")
//                    description.text += "Class: " + cardHolder.CardClass + "\n";
//                if (cardHolder.Subclass != "")
//                    description.text += "Subclass: " + cardHolder.Subclass + "\n";
//                if (cardHolder.Superorder != "")
//                    description.text += "Superorder: " + cardHolder.Superorder + "\n";
//                if (cardHolder.Order != "")
//                    description.text += "Order: " + cardHolder.Order + "\n";
//                if (cardHolder.Suborder != "")
//                    description.text += "Suborder: " + cardHolder.Suborder + "\n";
//                if (cardHolder.Superfamily != "")
//                    description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//                if (cardHolder.Family != "")
//                    description.text += "Fsmily: " + cardHolder.Family + "\n";
//                if (cardHolder.Subfamily != "")
//                    description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//                if (cardHolder.Supergenus != "")
//                    description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//                if (cardHolder.Genus != "")
//                    description.text += "Genus: " + cardHolder.Genus + "\n";
//                if (cardHolder.Subgenus != "")
//                    description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//                if (cardHolder.Species != "")
//                    description.text += "Species: " + cardHolder.Species + "\n";
//                if (cardHolder.Subspecies != "")
//                    description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//                if (cardHolder.AnimalSize != "")
//                    description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//                if (cardHolder.AnimalEnvironment != "")
//                    description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//                if (cardHolder.AnimalDiet != "")
//                    description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//                if (cardHolder.PlantType != "")
//                    description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//                if (cardHolder.RegionType != "")
//                    description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//                if (cardHolder.Domain != "")
//                    description.text += "Domain: " + cardHolder.Domain + "\n";
//                if (cardHolder.Infraclass != "")
//                    description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//                if (cardHolder.Infraorder != "")
//                    description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//                if (cardHolder.Section != "")
//                    description.text += "Section: " + cardHolder.Section + "\n";
//                if (cardHolder.Tribe != "")
//                    description.text += "Tribe: " + cardHolder.Tribe + "\n";
//                if (cardHolder.Division != "")
//                    description.text += "Division: " + cardHolder.Division + "\n";
//                if (cardHolder.Superdivision != "")
//                    description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//                if (cardHolder.Subdivision != "")
//                    description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//                if (cardHolder.Fungi_type != "")
//                    description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//                string[] name = nameHolder.Split('-');
//                string anotherName = "";

//                for (int i = 2; i < name.Length; i++)
//                    anotherName += name[i] + " ";

//                nameOfCard.text = anotherName;

//                //prints the actions
//                description.text += "\n" + cardHolder.StandingAction.ToString();

//                if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                    buttonEnabler.gameObject.SetActive(false);
//                else
//                {
//                    description.text += "\n" + cardHolder.SpecialAction.ToString();
//                    buttonEnabler.gameObject.SetActive(true);
//                }
//            }
//            else if (nameHolder.Contains("Region")) //region name filter
//            { 

//                description.text = ""; //just resets it incase there is one that is completeley empty

//                //goes through andmatches the name, then proceeds to print the actions
//                for (int i = 0; i < GameManager.Instance.Hand.Count; i++)
//                {
//                    if (GameManager.Instance.Hand[i].CardName == nameHolder)
//                    {
//                        cardHolder = GameManager.Instance.Hand[i]; //sets the card holder for the rest of the things needed to be set
//                    }
//                }

//                //adding the description based off of everything else
//                if (cardHolder.Kingdom != "")
//                    description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//                if (cardHolder.Subkingdom != "")
//                    description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//                if (cardHolder.Superphylum != "")
//                    description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//                if (cardHolder.Phylum != "")
//                    description.text += "Phylum: " + cardHolder.Phylum + "\n";
//                if (cardHolder.Subphylum != "")
//                    description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//                if (cardHolder.Superclass != "")
//                    description.text += "Superclass: " + cardHolder.Superclass + "\n";
//                if (cardHolder.CardClass != "")
//                    description.text += "Class: " + cardHolder.CardClass + "\n";
//                if (cardHolder.Subclass != "")
//                    description.text += "Subclass: " + cardHolder.Subclass + "\n";
//                if (cardHolder.Superorder != "")
//                    description.text += "Superorder: " + cardHolder.Superorder + "\n";
//                if (cardHolder.Order != "")
//                    description.text += "Order: " + cardHolder.Order + "\n";
//                if (cardHolder.Suborder != "")
//                    description.text += "Suborder: " + cardHolder.Suborder + "\n";
//                if (cardHolder.Superfamily != "")
//                    description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//                if (cardHolder.Family != "")
//                    description.text += "Fsmily: " + cardHolder.Family + "\n";
//                if (cardHolder.Subfamily != "")
//                    description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//                if (cardHolder.Supergenus != "")
//                    description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//                if (cardHolder.Genus != "")
//                    description.text += "Genus: " + cardHolder.Genus + "\n";
//                if (cardHolder.Subgenus != "")
//                    description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//                if (cardHolder.Species != "")
//                    description.text += "Species: " + cardHolder.Species + "\n";
//                if (cardHolder.Subspecies != "")
//                    description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//                if (cardHolder.AnimalSize != "")
//                    description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//                if (cardHolder.AnimalEnvironment != "")
//                    description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//                if (cardHolder.AnimalDiet != "")
//                    description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//                if (cardHolder.PlantType != "")
//                    description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//                if (cardHolder.RegionType != "")
//                    description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//                if (cardHolder.Domain != "")
//                    description.text += "Domain: " + cardHolder.Domain + "\n";
//                if (cardHolder.Infraclass != "")
//                    description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//                if (cardHolder.Infraorder != "")
//                    description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//                if (cardHolder.Section != "")
//                    description.text += "Section: " + cardHolder.Section + "\n";
//                if (cardHolder.Tribe != "")
//                    description.text += "Tribe: " + cardHolder.Tribe + "\n";
//                if (cardHolder.Division != "")
//                    description.text += "Division: " + cardHolder.Division + "\n";
//                if (cardHolder.Superdivision != "")
//                    description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//                if (cardHolder.Subdivision != "")
//                    description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//                if (cardHolder.Fungi_type != "")
//                    description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//                if (nameHolder.Contains("Forest"))
//                    nameOfCard.text = "Forest";
//                else if (nameHolder.Contains("Running-Water"))
//                    nameOfCard.text = "Running Water";
//                else if (nameHolder.Contains("Standing-Water"))
//                    nameOfCard.text = "Standing Water";
//                else if (nameHolder.Contains("Grasslands"))
//                    nameOfCard.text = "Grasslands";

//                //prints the actions
//                description.text += "\n" + cardHolder.StandingAction;

//                if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                    buttonEnabler.gameObject.SetActive(false);
//                else
//                {
//                    description.text += "\n" + cardHolder.SpecialAction.ToString();
//                    buttonEnabler.gameObject.SetActive(true);
//                }
//            }
//            else if (nameHolder.Contains("Plant")) //plant name filter
//            {
//                description.text = ""; //just resets it incase there is one that is completeley empty

//                //goes through andmatches the name, then proceeds to print the actions
//                for (int i = 0; i < GameManager.Instance.Hand.Count; i++)
//                {
//                    if (GameManager.Instance.Hand[i].CardName == nameHolder)
//                    {
//                        cardHolder = GameManager.Instance.Hand[i]; //sets the card holder for the rest of the things needed to be set
//                    }
//                }

//                //adding the description based off of everything else
//                if (cardHolder.Kingdom != "")
//                    description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//                if (cardHolder.Subkingdom != "")
//                    description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//                if (cardHolder.Superphylum != "")
//                    description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//                if (cardHolder.Phylum != "")
//                    description.text += "Phylum: " + cardHolder.Phylum + "\n";
//                if (cardHolder.Subphylum != "")
//                    description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//                if (cardHolder.Superclass != "")
//                    description.text += "Superclass: " + cardHolder.Superclass + "\n";
//                if (cardHolder.CardClass != "")
//                    description.text += "Class: " + cardHolder.CardClass + "\n";
//                if (cardHolder.Subclass != "")
//                    description.text += "Subclass: " + cardHolder.Subclass + "\n";
//                if (cardHolder.Superorder != "")
//                    description.text += "Superorder: " + cardHolder.Superorder + "\n";
//                if (cardHolder.Order != "")
//                    description.text += "Order: " + cardHolder.Order + "\n";
//                if (cardHolder.Suborder != "")
//                    description.text += "Suborder: " + cardHolder.Suborder + "\n";
//                if (cardHolder.Superfamily != "")
//                    description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//                if (cardHolder.Family != "")
//                    description.text += "Fsmily: " + cardHolder.Family + "\n";
//                if (cardHolder.Subfamily != "")
//                    description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//                if (cardHolder.Supergenus != "")
//                    description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//                if (cardHolder.Genus != "")
//                    description.text += "Genus: " + cardHolder.Genus + "\n";
//                if (cardHolder.Subgenus != "")
//                    description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//                if (cardHolder.Species != "")
//                    description.text += "Species: " + cardHolder.Species + "\n";
//                if (cardHolder.Subspecies != "")
//                    description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//                if (cardHolder.AnimalSize != "")
//                    description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//                if (cardHolder.AnimalEnvironment != "")
//                    description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//                if (cardHolder.AnimalDiet != "")
//                    description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//                if (cardHolder.PlantType != "")
//                    description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//                if (cardHolder.RegionType != "")
//                    description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//                if (cardHolder.Domain != "")
//                    description.text += "Domain: " + cardHolder.Domain + "\n";
//                if (cardHolder.Infraclass != "")
//                    description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//                if (cardHolder.Infraorder != "")
//                    description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//                if (cardHolder.Section != "")
//                    description.text += "Section: " + cardHolder.Section + "\n";
//                if (cardHolder.Tribe != "")
//                    description.text += "Tribe: " + cardHolder.Tribe + "\n";
//                if (cardHolder.Division != "")
//                    description.text += "Division: " + cardHolder.Division + "\n";
//                if (cardHolder.Superdivision != "")
//                    description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//                if (cardHolder.Subdivision != "")
//                    description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//                if (cardHolder.Fungi_type != "")
//                    description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//                string[] name = nameHolder.Split('-');
//                string anotherName = "";

//                for (int i = 1; i < name.Length; i++)
//                    anotherName += name[i] + " ";

//                nameOfCard.text = anotherName;

//                //prints the actions
//                description.text += "\n" + cardHolder.StandingAction;

//                if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                    buttonEnabler.gameObject.SetActive(false);
//                else
//                {
//                    description.text += "\n" + cardHolder.SpecialAction.ToString();
//                    buttonEnabler.gameObject.SetActive(true);
//                }
//            }
//            else if (nameHolder.Contains("Multi")) //multiplayer name filter
//            {
//                description.text = ""; //just resets it incase there is one that is completeley empty

//                //goes through andmatches the name, then proceeds to print the actions
//                for (int i = 0; i < GameManager.Instance.Hand.Count; i++)
//                {
//                    if (GameManager.Instance.Hand[i].CardName == nameHolder)
//                    {
//                        cardHolder = GameManager.Instance.Hand[i]; //sets the card holder for the rest of the things needed to be set
//                    }
//                }

//                //adding the description based off of everything else
//                if (cardHolder.Kingdom != "")
//                    description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//                if (cardHolder.Subkingdom != "")
//                    description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//                if (cardHolder.Superphylum != "")
//                    description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//                if (cardHolder.Phylum != "")
//                    description.text += "Phylum: " + cardHolder.Phylum + "\n";
//                if (cardHolder.Subphylum != "")
//                    description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//                if (cardHolder.Superclass != "")
//                    description.text += "Superclass: " + cardHolder.Superclass + "\n";
//                if (cardHolder.CardClass != "")
//                    description.text += "Class: " + cardHolder.CardClass + "\n";
//                if (cardHolder.Subclass != "")
//                    description.text += "Subclass: " + cardHolder.Subclass + "\n";
//                if (cardHolder.Superorder != "")
//                    description.text += "Superorder: " + cardHolder.Superorder + "\n";
//                if (cardHolder.Order != "")
//                    description.text += "Order: " + cardHolder.Order + "\n";
//                if (cardHolder.Suborder != "")
//                    description.text += "Suborder: " + cardHolder.Suborder + "\n";
//                if (cardHolder.Superfamily != "")
//                    description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//                if (cardHolder.Family != "")
//                    description.text += "Fsmily: " + cardHolder.Family + "\n";
//                if (cardHolder.Subfamily != "")
//                    description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//                if (cardHolder.Supergenus != "")
//                    description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//                if (cardHolder.Genus != "")
//                    description.text += "Genus: " + cardHolder.Genus + "\n";
//                if (cardHolder.Subgenus != "")
//                    description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//                if (cardHolder.Species != "")
//                    description.text += "Species: " + cardHolder.Species + "\n";
//                if (cardHolder.Subspecies != "")
//                    description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//                if (cardHolder.AnimalSize != "")
//                    description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//                if (cardHolder.AnimalEnvironment != "")
//                    description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//                if (cardHolder.AnimalDiet != "")
//                    description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//                if (cardHolder.PlantType != "")
//                    description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//                if (cardHolder.RegionType != "")
//                    description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//                if (cardHolder.Domain != "")
//                    description.text += "Domain: " + cardHolder.Domain + "\n";
//                if (cardHolder.Infraclass != "")
//                    description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//                if (cardHolder.Infraorder != "")
//                    description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//                if (cardHolder.Section != "")
//                    description.text += "Section: " + cardHolder.Section + "\n";
//                if (cardHolder.Tribe != "")
//                    description.text += "Tribe: " + cardHolder.Tribe + "\n";
//                if (cardHolder.Division != "")
//                    description.text += "Division: " + cardHolder.Division + "\n";
//                if (cardHolder.Superdivision != "")
//                    description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//                if (cardHolder.Subdivision != "")
//                    description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//                if (cardHolder.Fungi_type != "")
//                    description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//                string[] name = nameHolder.Split('-');
//                string anotherName = "";

//                for (int i = 1; i < name.Length; i++)
//                    anotherName += name[i] + " ";

//                nameOfCard.text = anotherName;

//                //prints the actions
//                description.text += "\n" + cardHolder.StandingAction;

//                if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                    buttonEnabler.gameObject.SetActive(false);
//                else
//                {
//                    description.text += "\n" + cardHolder.SpecialAction.ToString();
//                    buttonEnabler.gameObject.SetActive(true);
//                }
//            }
//            else if (nameHolder.Contains("Condition")) //condition name filter
//            {
//                description.text = ""; //just resets it incase there is one that is completeley empty

//                //goes through andmatches the name, then proceeds to print the actions
//                for (int i = 0; i < GameManager.Instance.Hand.Count; i++)
//                {
//                    if (GameManager.Instance.Hand[i].CardName == nameHolder)
//                    {
//                        cardHolder = GameManager.Instance.Hand[i]; //sets the card holder for the rest of the things needed to be set
//                    }
//                }

//                //adding the description based off of everything else
//                if (cardHolder.Kingdom != "")
//                    description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//                if (cardHolder.Subkingdom != "")
//                    description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//                if (cardHolder.Superphylum != "")
//                    description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//                if (cardHolder.Phylum != "")
//                    description.text += "Phylum: " + cardHolder.Phylum + "\n";
//                if (cardHolder.Subphylum != "")
//                    description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//                if (cardHolder.Superclass != "")
//                    description.text += "Superclass: " + cardHolder.Superclass + "\n";
//                if (cardHolder.CardClass != "")
//                    description.text += "Class: " + cardHolder.CardClass + "\n";
//                if (cardHolder.Subclass != "")
//                    description.text += "Subclass: " + cardHolder.Subclass + "\n";
//                if (cardHolder.Superorder != "")
//                    description.text += "Superorder: " + cardHolder.Superorder + "\n";
//                if (cardHolder.Order != "")
//                    description.text += "Order: " + cardHolder.Order + "\n";
//                if (cardHolder.Suborder != "")
//                    description.text += "Suborder: " + cardHolder.Suborder + "\n";
//                if (cardHolder.Superfamily != "")
//                    description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//                if (cardHolder.Family != "")
//                    description.text += "Fsmily: " + cardHolder.Family + "\n";
//                if (cardHolder.Subfamily != "")
//                    description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//                if (cardHolder.Supergenus != "")
//                    description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//                if (cardHolder.Genus != "")
//                    description.text += "Genus: " + cardHolder.Genus + "\n";
//                if (cardHolder.Subgenus != "")
//                    description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//                if (cardHolder.Species != "")
//                    description.text += "Species: " + cardHolder.Species + "\n";
//                if (cardHolder.Subspecies != "")
//                    description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//                if (cardHolder.AnimalSize != "")
//                    description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//                if (cardHolder.AnimalEnvironment != "")
//                    description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//                if (cardHolder.AnimalDiet != "")
//                    description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//                if (cardHolder.PlantType != "")
//                    description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//                if (cardHolder.RegionType != "")
//                    description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//                if (cardHolder.Domain != "")
//                    description.text += "Domain: " + cardHolder.Domain + "\n";
//                if (cardHolder.Infraclass != "")
//                    description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//                if (cardHolder.Infraorder != "")
//                    description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//                if (cardHolder.Section != "")
//                    description.text += "Section: " + cardHolder.Section + "\n";
//                if (cardHolder.Tribe != "")
//                    description.text += "Tribe: " + cardHolder.Tribe + "\n";
//                if (cardHolder.Division != "")
//                    description.text += "Division: " + cardHolder.Division + "\n";
//                if (cardHolder.Superdivision != "")
//                    description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//                if (cardHolder.Subdivision != "")
//                    description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//                if (cardHolder.Fungi_type != "")
//                    description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//                string[] name = nameHolder.Split('-');
//                string anotherName = "";

//                for (int i = 1; i < name.Length; i++)
//                    anotherName += name[i] + " ";

//                nameOfCard.text = anotherName;

//                //prints the actions
//                description.text += "\n" + cardHolder.StandingAction;

//                if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                    buttonEnabler.gameObject.SetActive(false);
//                else
//                {
//                    description.text += "\n" + cardHolder.SpecialAction.ToString();
//                    buttonEnabler.gameObject.SetActive(true);
//                }
//            }
//            else if (nameHolder.Contains("Invertebrate")) //invertebrate name filter
//            {
//                description.text = ""; //just resets it incase there is one that is completeley empty

//                //goes through andmatches the name, then proceeds to print the actions
//                for (int i = 0; i < GameManager.Instance.Hand.Count; i++)
//                {
//                    if (GameManager.Instance.Hand[i].CardName == nameHolder)
//                    {
//                        cardHolder = GameManager.Instance.Hand[i]; //sets the card holder for the rest of the things needed to be set
//                    }
//                }

//                //adding the description based off of everything else
//                if (cardHolder.Kingdom != "")
//                    description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//                if (cardHolder.Subkingdom != "")
//                    description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//                if (cardHolder.Superphylum != "")
//                    description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//                if (cardHolder.Phylum != "")
//                    description.text += "Phylum: " + cardHolder.Phylum + "\n";
//                if (cardHolder.Subphylum != "")
//                    description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//                if (cardHolder.Superclass != "")
//                    description.text += "Superclass: " + cardHolder.Superclass + "\n";
//                if (cardHolder.CardClass != "")
//                    description.text += "Class: " + cardHolder.CardClass + "\n";
//                if (cardHolder.Subclass != "")
//                    description.text += "Subclass: " + cardHolder.Subclass + "\n";
//                if (cardHolder.Superorder != "")
//                    description.text += "Superorder: " + cardHolder.Superorder + "\n";
//                if (cardHolder.Order != "")
//                    description.text += "Order: " + cardHolder.Order + "\n";
//                if (cardHolder.Suborder != "")
//                    description.text += "Suborder: " + cardHolder.Suborder + "\n";
//                if (cardHolder.Superfamily != "")
//                    description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//                if (cardHolder.Family != "")
//                    description.text += "Fsmily: " + cardHolder.Family + "\n";
//                if (cardHolder.Subfamily != "")
//                    description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//                if (cardHolder.Supergenus != "")
//                    description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//                if (cardHolder.Genus != "")
//                    description.text += "Genus: " + cardHolder.Genus + "\n";
//                if (cardHolder.Subgenus != "")
//                    description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//                if (cardHolder.Species != "")
//                    description.text += "Species: " + cardHolder.Species + "\n";
//                if (cardHolder.Subspecies != "")
//                    description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//                if (cardHolder.AnimalSize != "")
//                    description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//                if (cardHolder.AnimalEnvironment != "")
//                    description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//                if (cardHolder.AnimalDiet != "")
//                    description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//                if (cardHolder.PlantType != "")
//                    description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//                if (cardHolder.RegionType != "")
//                    description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//                if (cardHolder.Domain != "")
//                    description.text += "Domain: " + cardHolder.Domain + "\n";
//                if (cardHolder.Infraclass != "")
//                    description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//                if (cardHolder.Infraorder != "")
//                    description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//                if (cardHolder.Section != "")
//                    description.text += "Section: " + cardHolder.Section + "\n";
//                if (cardHolder.Tribe != "")
//                    description.text += "Tribe: " + cardHolder.Tribe + "\n";
//                if (cardHolder.Division != "")
//                    description.text += "Division: " + cardHolder.Division + "\n";
//                if (cardHolder.Superdivision != "")
//                    description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//                if (cardHolder.Subdivision != "")
//                    description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//                if (cardHolder.Fungi_type != "")
//                    description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//                string[] name = nameHolder.Split('-');
//                string anotherName = "";

//                for (int i = 1; i < name.Length; i++)
//                    anotherName += name[i] + " ";

//                nameOfCard.text = anotherName;

//                //prints the actions
//                description.text += "\n" + cardHolder.StandingAction;

//                if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                    buttonEnabler.gameObject.SetActive(false);
//                else
//                {
//                    description.text += "\n" + cardHolder.SpecialAction.ToString();
//                    buttonEnabler.gameObject.SetActive(true);
//                }
//            }
//            else if (nameHolder.Contains("Fungi")) //fungi name filter
//            {
//                description.text = ""; //just resets it incase there is one that is completeley empty

//                //goes through andmatches the name, then proceeds to print the actions
//                for (int i = 0; i < GameManager.Instance.Hand.Count; i++)
//                {
//                    if (GameManager.Instance.Hand[i].CardName == nameHolder)
//                    {
//                        cardHolder = GameManager.Instance.Hand[i]; //sets the card holder for the rest of the things needed to be set
//                    }
//                }

//                //adding the description based off of everything else
//                if (cardHolder.Kingdom != "")
//                    description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//                if (cardHolder.Subkingdom != "")
//                    description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//                if (cardHolder.Superphylum != "")
//                    description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//                if (cardHolder.Phylum != "")
//                    description.text += "Phylum: " + cardHolder.Phylum + "\n";
//                if (cardHolder.Subphylum != "")
//                    description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//                if (cardHolder.Superclass != "")
//                    description.text += "Superclass: " + cardHolder.Superclass + "\n";
//                if (cardHolder.CardClass != "")
//                    description.text += "Class: " + cardHolder.CardClass + "\n";
//                if (cardHolder.Subclass != "")
//                    description.text += "Subclass: " + cardHolder.Subclass + "\n";
//                if (cardHolder.Superorder != "")
//                    description.text += "Superorder: " + cardHolder.Superorder + "\n";
//                if (cardHolder.Order != "")
//                    description.text += "Order: " + cardHolder.Order + "\n";
//                if (cardHolder.Suborder != "")
//                    description.text += "Suborder: " + cardHolder.Suborder + "\n";
//                if (cardHolder.Superfamily != "")
//                    description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//                if (cardHolder.Family != "")
//                    description.text += "Fsmily: " + cardHolder.Family + "\n";
//                if (cardHolder.Subfamily != "")
//                    description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//                if (cardHolder.Supergenus != "")
//                    description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//                if (cardHolder.Genus != "")
//                    description.text += "Genus: " + cardHolder.Genus + "\n";
//                if (cardHolder.Subgenus != "")
//                    description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//                if (cardHolder.Species != "")
//                    description.text += "Species: " + cardHolder.Species + "\n";
//                if (cardHolder.Subspecies != "")
//                    description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//                if (cardHolder.AnimalSize != "")
//                    description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//                if (cardHolder.AnimalEnvironment != "")
//                    description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//                if (cardHolder.AnimalDiet != "")
//                    description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//                if (cardHolder.PlantType != "")
//                    description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//                if (cardHolder.RegionType != "")
//                    description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//                if (cardHolder.Domain != "")
//                    description.text += "Domain: " + cardHolder.Domain + "\n";
//                if (cardHolder.Infraclass != "")
//                    description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//                if (cardHolder.Infraorder != "")
//                    description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//                if (cardHolder.Section != "")
//                    description.text += "Section: " + cardHolder.Section + "\n";
//                if (cardHolder.Tribe != "")
//                    description.text += "Tribe: " + cardHolder.Tribe + "\n";
//                if (cardHolder.Division != "")
//                    description.text += "Division: " + cardHolder.Division + "\n";
//                if (cardHolder.Superdivision != "")
//                    description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//                if (cardHolder.Subdivision != "")
//                    description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//                if (cardHolder.Fungi_type != "")
//                    description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//                string[] name = nameHolder.Split('-');
//                string anotherName = "";

//                for (int i = 1; i < name.Length; i++)
//                    anotherName += name[i] + " ";

//                nameOfCard.text = anotherName;

//                //prints the actions
//                description.text += "\n" + cardHolder.StandingAction;

//                if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                    buttonEnabler.gameObject.SetActive(false);
//                else
//                {
//                    description.text += "\n" + cardHolder.SpecialAction.ToString();
//                    buttonEnabler.gameObject.SetActive(true);
//                }
//            }
//            else if (nameHolder.Contains("Human")) //humam name filter
//            {
//                description.text = ""; //just resets it incase there is one that is completeley empty

//                //goes through andmatches the name, then proceeds to print the actions
//                for (int i = 0; i < GameManager.Instance.Hand.Count; i++)
//                {
//                    if (GameManager.Instance.Hand[i].CardName == nameHolder)
//                    {
//                        cardHolder = GameManager.Instance.Hand[i];
//                    }
//                }

//                //adding the description based off of everything else
//                if (cardHolder.Kingdom != "")
//                    description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//                if (cardHolder.Subkingdom != "")
//                    description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//                if (cardHolder.Superphylum != "")
//                    description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//                if (cardHolder.Phylum != "")
//                    description.text += "Phylum: " + cardHolder.Phylum + "\n";
//                if (cardHolder.Subphylum != "")
//                    description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//                if (cardHolder.Superclass != "")
//                    description.text += "Superclass: " + cardHolder.Superclass + "\n";
//                if (cardHolder.CardClass != "")
//                    description.text += "Class: " + cardHolder.CardClass + "\n";
//                if (cardHolder.Subclass != "")
//                    description.text += "Subclass: " + cardHolder.Subclass + "\n";
//                if (cardHolder.Superorder != "")
//                    description.text += "Superorder: " + cardHolder.Superorder + "\n";
//                if (cardHolder.Order != "")
//                    description.text += "Order: " + cardHolder.Order + "\n";
//                if (cardHolder.Suborder != "")
//                    description.text += "Suborder: " + cardHolder.Suborder + "\n";
//                if (cardHolder.Superfamily != "")
//                    description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//                if (cardHolder.Family != "")
//                    description.text += "Fsmily: " + cardHolder.Family + "\n";
//                if (cardHolder.Subfamily != "")
//                    description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//                if (cardHolder.Supergenus != "")
//                    description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//                if (cardHolder.Genus != "")
//                    description.text += "Genus: " + cardHolder.Genus + "\n";
//                if (cardHolder.Subgenus != "")
//                    description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//                if (cardHolder.Species != "")
//                    description.text += "Species: " + cardHolder.Species + "\n";
//                if (cardHolder.Subspecies != "")
//                    description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//                if (cardHolder.AnimalSize != "")
//                    description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//                if (cardHolder.AnimalEnvironment != "")
//                    description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//                if (cardHolder.AnimalDiet != "")
//                    description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//                if (cardHolder.PlantType != "")
//                    description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//                if (cardHolder.RegionType != "")
//                    description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//                if (cardHolder.Domain != "")
//                    description.text += "Domain: " + cardHolder.Domain + "\n";
//                if (cardHolder.Infraclass != "")
//                    description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//                if (cardHolder.Infraorder != "")
//                    description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//                if (cardHolder.Section != "")
//                    description.text += "Section: " + cardHolder.Section + "\n";
//                if (cardHolder.Tribe != "")
//                    description.text += "Tribe: " + cardHolder.Tribe + "\n";
//                if (cardHolder.Division != "")
//                    description.text += "Division: " + cardHolder.Division + "\n";
//                if (cardHolder.Superdivision != "")
//                    description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//                if (cardHolder.Subdivision != "")
//                    description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//                if (cardHolder.Fungi_type != "")
//                    description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//                string[] name = nameHolder.Split('-');
//                string anotherName = "";

//                for (int i = 1; i < name.Length; i++)
//                    anotherName += name[i] + " ";

//                nameOfCard.text = anotherName;

//                //prints the actions
//                description.text += "\n" + cardHolder.StandingAction;

//                if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                    buttonEnabler.gameObject.SetActive(false);
//                else
//                {
//                    description.text += "\n" + cardHolder.SpecialAction.ToString();
//                    buttonEnabler.gameObject.SetActive(true);
//                }
//            }
//            else if (nameHolder.Contains("Animal")) //animal name filter
//            {
//                description.text = ""; //just resets it incase there is one that is completeley empty

//                //goes through andmatches the name, then proceeds to print the actions
//                for (int i = 0; i < GameManager.Instance.Hand.Count; i++)
//                {
//                    if (GameManager.Instance.Hand[i].CardName == nameHolder)
//                    {
//                        cardHolder = GameManager.Instance.Hand[i]; //sets the card holder for the rest of the things needed to be set
//                    }
//                }

//                //adding the description based off of everything else
//                if (cardHolder.Kingdom != "")
//                    description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//                if (cardHolder.Subkingdom != "")
//                    description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//                if (cardHolder.Superphylum != "")
//                    description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//                if (cardHolder.Phylum != "")
//                    description.text += "Phylum: " + cardHolder.Phylum + "\n";
//                if (cardHolder.Subphylum != "")
//                    description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//                if (cardHolder.Superclass != "")
//                    description.text += "Superclass: " + cardHolder.Superclass + "\n";
//                if (cardHolder.CardClass != "")
//                    description.text += "Class: " + cardHolder.CardClass + "\n";
//                if (cardHolder.Subclass != "")
//                    description.text += "Subclass: " + cardHolder.Subclass + "\n";
//                if (cardHolder.Superorder != "")
//                    description.text += "Superorder: " + cardHolder.Superorder + "\n";
//                if (cardHolder.Order != "")
//                    description.text += "Order: " + cardHolder.Order + "\n";
//                if (cardHolder.Suborder != "")
//                    description.text += "Suborder: " + cardHolder.Suborder + "\n";
//                if (cardHolder.Superfamily != "")
//                    description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//                if (cardHolder.Family != "")
//                    description.text += "Fsmily: " + cardHolder.Family + "\n";
//                if (cardHolder.Subfamily != "")
//                    description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//                if (cardHolder.Supergenus != "")
//                    description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//                if (cardHolder.Genus != "")
//                    description.text += "Genus: " + cardHolder.Genus + "\n";
//                if (cardHolder.Subgenus != "")
//                    description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//                if (cardHolder.Species != "")
//                    description.text += "Species: " + cardHolder.Species + "\n";
//                if (cardHolder.Subspecies != "")
//                    description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//                if (cardHolder.AnimalSize != "")
//                    description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//                if (cardHolder.AnimalEnvironment != "")
//                    description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//                if (cardHolder.AnimalDiet != "")
//                    description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//                if (cardHolder.PlantType != "")
//                    description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//                if (cardHolder.RegionType != "")
//                    description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//                if (cardHolder.Domain != "")
//                    description.text += "Domain: " + cardHolder.Domain + "\n";
//                if (cardHolder.Infraclass != "")
//                    description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//                if (cardHolder.Infraorder != "")
//                    description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//                if (cardHolder.Section != "")
//                    description.text += "Section: " + cardHolder.Section + "\n";
//                if (cardHolder.Tribe != "")
//                    description.text += "Tribe: " + cardHolder.Tribe + "\n";
//                if (cardHolder.Division != "")
//                    description.text += "Division: " + cardHolder.Division + "\n";
//                if (cardHolder.Superdivision != "")
//                    description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//                if (cardHolder.Subdivision != "")
//                    description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//                if (cardHolder.Fungi_type != "")
//                    description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//                string[] name = nameHolder.Split('-');
//                string anotherName = "";

//                for (int i = 1; i < name.Length; i++)
//                    anotherName += name[i] + " ";

//                nameOfCard.text = anotherName;

//                //prints the actions
//                description.text += "\n" + cardHolder.StandingAction;

//                if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                    buttonEnabler.gameObject.SetActive(false);
//                else
//                {
//                    description.text += "\n" + cardHolder.SpecialAction.ToString();
//                    buttonEnabler.gameObject.SetActive(true);
//                }
//            }
//            else if (nameHolder.Contains("Microbe")) //microbe name filter
//            {
//                description.text = ""; //just resets it incase there is one that is completeley empty

//                //goes through andmatches the name, then proceeds to print the actions
//                for (int i = 0; i < GameManager.Instance.Hand.Count; i++)
//                {
//                    if (GameManager.Instance.Hand[i].CardName == nameHolder)
//                    {
//                        cardHolder = GameManager.Instance.Hand[i]; //sets the card holder for the rest of the things needed to be set
//                    }
//                }

//                //adding the description based off of everything else
//                if (cardHolder.Kingdom != "")
//                    description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//                if (cardHolder.Subkingdom != "")
//                    description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//                if (cardHolder.Superphylum != "")
//                    description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//                if (cardHolder.Phylum != "")
//                    description.text += "Phylum: " + cardHolder.Phylum + "\n";
//                if (cardHolder.Subphylum != "")
//                    description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//                if (cardHolder.Superclass != "")
//                    description.text += "Superclass: " + cardHolder.Superclass + "\n";
//                if (cardHolder.CardClass != "")
//                    description.text += "Class: " + cardHolder.CardClass + "\n";
//                if (cardHolder.Subclass != "")
//                    description.text += "Subclass: " + cardHolder.Subclass + "\n";
//                if (cardHolder.Superorder != "")
//                    description.text += "Superorder: " + cardHolder.Superorder + "\n";
//                if (cardHolder.Order != "")
//                    description.text += "Order: " + cardHolder.Order + "\n";
//                if (cardHolder.Suborder != "")
//                    description.text += "Suborder: " + cardHolder.Suborder + "\n";
//                if (cardHolder.Superfamily != "")
//                    description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//                if (cardHolder.Family != "")
//                    description.text += "Fsmily: " + cardHolder.Family + "\n";
//                if (cardHolder.Subfamily != "")
//                    description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//                if (cardHolder.Supergenus != "")
//                    description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//                if (cardHolder.Genus != "")
//                    description.text += "Genus: " + cardHolder.Genus + "\n";
//                if (cardHolder.Subgenus != "")
//                    description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//                if (cardHolder.Species != "")
//                    description.text += "Species: " + cardHolder.Species + "\n";
//                if (cardHolder.Subspecies != "")
//                    description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//                if (cardHolder.AnimalSize != "")
//                    description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//                if (cardHolder.AnimalEnvironment != "")
//                    description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//                if (cardHolder.AnimalDiet != "")
//                    description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//                if (cardHolder.PlantType != "")
//                    description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//                if (cardHolder.RegionType != "")
//                    description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//                if (cardHolder.Domain != "")
//                    description.text += "Domain: " + cardHolder.Domain + "\n";
//                if (cardHolder.Infraclass != "")
//                    description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//                if (cardHolder.Infraorder != "")
//                    description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//                if (cardHolder.Section != "")
//                    description.text += "Section: " + cardHolder.Section + "\n";
//                if (cardHolder.Tribe != "")
//                    description.text += "Tribe: " + cardHolder.Tribe + "\n";
//                if (cardHolder.Division != "")
//                    description.text += "Division: " + cardHolder.Division + "\n";
//                if (cardHolder.Superdivision != "")
//                    description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//                if (cardHolder.Subdivision != "")
//                    description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//                if (cardHolder.Fungi_type != "")
//                    description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//                string[] name = nameHolder.Split('-');
//                string anotherName = "";

//                for (int i = 1; i < name.Length; i++)
//                    anotherName += name[i] + " ";

//                nameOfCard.text = anotherName;

//                //prints the actions
//                description.text += "\n" + cardHolder.StandingAction;

//                if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                    buttonEnabler.gameObject.SetActive(false);
//                else
//                {
//                    description.text += "\n" + cardHolder.SpecialAction.ToString();
//                    buttonEnabler.gameObject.SetActive(true);
//                }
//            }
//        }
//        else if (nameHolder.Contains("Special")) //special region filter
//        {
//            description.text = ""; //just resets it incase there is one that is completeley empty

//            //goes through andmatches the name, then proceeds to print the actions
//            for (int i = 0; i < GameManager.Instance.SpecialRegionPlacement.Count; i++)
//            {
//                if (GameManager.Instance.SpecialRegionPlacement[i].CardName == nameHolder)
//                {
//                    cardHolder = GameManager.Instance.SpecialRegionPlacement[i]; //sets the card holder for the rest of the things needed to be set
//                }
//            }

//            //adding the description based off of everything else
//            if (cardHolder.Kingdom != "")
//                description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//            if(cardHolder.Subkingdom != "")
//                description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//            if(cardHolder.Superphylum != "")
//                description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//            if(cardHolder.Phylum != "")
//                description.text += "Phylum: " + cardHolder.Phylum + "\n";
//            if(cardHolder.Subphylum != "")
//                description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//            if(cardHolder.Superclass != "")
//                description.text += "Superclass: " + cardHolder.Superclass + "\n";
//            if(cardHolder.CardClass != "")
//                description.text += "Class: " + cardHolder.CardClass + "\n";
//            if(cardHolder.Subclass != "")
//                description.text += "Subclass: " + cardHolder.Subclass + "\n";
//            if(cardHolder.Superorder != "")
//                description.text += "Superorder: " + cardHolder.Superorder + "\n";
//            if(cardHolder.Order != "")
//                description.text += "Order: " + cardHolder.Order + "\n";
//            if(cardHolder.Suborder != "")
//                description.text += "Suborder: " + cardHolder.Suborder + "\n";
//            if(cardHolder.Superfamily != "")
//                description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//            if(cardHolder.Family != "")
//                description.text += "Fsmily: " + cardHolder.Family + "\n";
//            if(cardHolder.Subfamily != "")
//                description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//            if(cardHolder.Supergenus != "")
//                description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//            if(cardHolder.Genus != "")
//                description.text += "Genus: " + cardHolder.Genus + "\n";
//            if(cardHolder.Subgenus != "")
//                description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//            if(cardHolder.Species != "")
//                description.text += "Species: " + cardHolder.Species + "\n";
//            if(cardHolder.Subspecies != "")
//                description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//            if(cardHolder.AnimalSize != "")
//                description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//            if(cardHolder.AnimalEnvironment != "")
//                description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//            if(cardHolder.AnimalDiet != "")
//                description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//            if(cardHolder.PlantType != "")
//                description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//            if(cardHolder.RegionType != "")
//                description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//            if(cardHolder.Domain != "")
//                description.text += "Domain: " + cardHolder.Domain + "\n";
//            if(cardHolder.Infraclass != "")
//                description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//            if(cardHolder.Infraorder != "")
//                description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//            if(cardHolder.Section != "")
//                description.text += "Section: " + cardHolder.Section + "\n";
//            if(cardHolder.Tribe != "")
//                description.text += "Tribe: " + cardHolder.Tribe + "\n";
//            if(cardHolder.Division != "")
//                description.text += "Division: " + cardHolder.Division + "\n";
//            if(cardHolder.Superdivision != "")
//                description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//            if(cardHolder.Subdivision != "")
//                description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//            if(cardHolder.Fungi_type != "")
//                description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//            string[] name = nameHolder.Split('-');
//            string anotherName = "";

//            for (int i = 2; i < name.Length; i++)
//                anotherName += name[i] + " ";

//            nameOfCard.text = anotherName;

//            //prints the actions
//            description.text += "\n" + cardHolder.StandingAction;

//            if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                buttonEnabler.gameObject.SetActive(false);
//            else
//            {
//                description.text += "\n" + cardHolder.SpecialAction.ToString();
//                buttonEnabler.gameObject.SetActive(true);
//            }
//        }
//        else if (nameHolder.Contains("Region")) //region name filter
//        {
//            description.text = ""; //just resets it incase there is one that is completeley empty

//            //goes through andmatches the name, then proceeds to print the actions
//            for (int i = 0; i < GameManager.Instance.RegionPlacement.Count; i++)
//            {
//                if (GameManager.Instance.RegionPlacement[i].CardName == nameHolder)
//                {
//                    cardHolder = GameManager.Instance.RegionPlacement[i]; //sets the card holder for the rest of the things needed to be set
//                }
//            }

//            //adding the description based off of everything else
//            if (cardHolder.Kingdom != "")
//                description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//            if (cardHolder.Subkingdom != "")
//                description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//            if (cardHolder.Superphylum != "")
//                description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//            if (cardHolder.Phylum != "")
//                description.text += "Phylum: " + cardHolder.Phylum + "\n";
//            if (cardHolder.Subphylum != "")
//                description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//            if (cardHolder.Superclass != "")
//                description.text += "Superclass: " + cardHolder.Superclass + "\n";
//            if (cardHolder.CardClass != "")
//                description.text += "Class: " + cardHolder.CardClass + "\n";
//            if (cardHolder.Subclass != "")
//                description.text += "Subclass: " + cardHolder.Subclass + "\n";
//            if (cardHolder.Superorder != "")
//                description.text += "Superorder: " + cardHolder.Superorder + "\n";
//            if (cardHolder.Order != "")
//                description.text += "Order: " + cardHolder.Order + "\n";
//            if (cardHolder.Suborder != "")
//                description.text += "Suborder: " + cardHolder.Suborder + "\n";
//            if (cardHolder.Superfamily != "")
//                description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//            if (cardHolder.Family != "")
//                description.text += "Fsmily: " + cardHolder.Family + "\n";
//            if (cardHolder.Subfamily != "")
//                description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//            if (cardHolder.Supergenus != "")
//                description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//            if (cardHolder.Genus != "")
//                description.text += "Genus: " + cardHolder.Genus + "\n";
//            if (cardHolder.Subgenus != "")
//                description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//            if (cardHolder.Species != "")
//                description.text += "Species: " + cardHolder.Species + "\n";
//            if (cardHolder.Subspecies != "")
//                description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//            if (cardHolder.AnimalSize != "")
//                description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//            if (cardHolder.AnimalEnvironment != "")
//                description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//            if (cardHolder.AnimalDiet != "")
//                description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//            if (cardHolder.PlantType != "")
//                description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//            if (cardHolder.RegionType != "")
//                description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//            if (cardHolder.Domain != "")
//                description.text += "Domain: " + cardHolder.Domain + "\n";
//            if (cardHolder.Infraclass != "")
//                description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//            if (cardHolder.Infraorder != "")
//                description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//            if (cardHolder.Section != "")
//                description.text += "Section: " + cardHolder.Section + "\n";
//            if (cardHolder.Tribe != "")
//                description.text += "Tribe: " + cardHolder.Tribe + "\n";
//            if (cardHolder.Division != "")
//                description.text += "Division: " + cardHolder.Division + "\n";
//            if (cardHolder.Superdivision != "")
//                description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//            if (cardHolder.Subdivision != "")
//                description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//            if (cardHolder.Fungi_type != "")
//                description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//            if (nameHolder.Contains("Forest"))
//                nameOfCard.text = "Forest";
//            else if (nameHolder.Contains("Running-Water"))
//                nameOfCard.text = "Running Water";
//            else if (nameHolder.Contains("Standing-Water"))
//                nameOfCard.text = "Standing Water";
//            else if (nameHolder.Contains("Grasslands"))
//                nameOfCard.text = "Grasslands";

//            //prints the actions
//            description.text += "\n" + cardHolder.StandingAction;

//            if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                buttonEnabler.gameObject.SetActive(false);
//            else
//            {
//                description.text += "\n" + cardHolder.SpecialAction.ToString();
//                buttonEnabler.gameObject.SetActive(true);
//            }
//        }
//        else if(nameHolder.Contains("Plant")) //plant name filter
//        {
//            description.text = ""; //just resets it incase there is one that is completeley empty

//            //goes through andmatches the name, then proceeds to print the actions
//            for (int i = 0; i < GameManager.Instance.PlantPlacement.Count; i++)
//            {
//                if (GameManager.Instance.PlantPlacement[i].CardName == nameHolder)
//                {
//                    cardHolder = GameManager.Instance.PlantPlacement[i]; //sets the card holder for the rest of the things needed to be set
//                }
//            }

//            //adding the description based off of everything else
//            if (cardHolder.Kingdom != "")
//                description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//            if (cardHolder.Subkingdom != "")
//                description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//            if (cardHolder.Superphylum != "")
//                description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//            if (cardHolder.Phylum != "")
//                description.text += "Phylum: " + cardHolder.Phylum + "\n";
//            if (cardHolder.Subphylum != "")
//                description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//            if (cardHolder.Superclass != "")
//                description.text += "Superclass: " + cardHolder.Superclass + "\n";
//            if (cardHolder.CardClass != "")
//                description.text += "Class: " + cardHolder.CardClass + "\n";
//            if (cardHolder.Subclass != "")
//                description.text += "Subclass: " + cardHolder.Subclass + "\n";
//            if (cardHolder.Superorder != "")
//                description.text += "Superorder: " + cardHolder.Superorder + "\n";
//            if (cardHolder.Order != "")
//                description.text += "Order: " + cardHolder.Order + "\n";
//            if (cardHolder.Suborder != "")
//                description.text += "Suborder: " + cardHolder.Suborder + "\n";
//            if (cardHolder.Superfamily != "")
//                description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//            if (cardHolder.Family != "")
//                description.text += "Fsmily: " + cardHolder.Family + "\n";
//            if (cardHolder.Subfamily != "")
//                description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//            if (cardHolder.Supergenus != "")
//                description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//            if (cardHolder.Genus != "")
//                description.text += "Genus: " + cardHolder.Genus + "\n";
//            if (cardHolder.Subgenus != "")
//                description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//            if (cardHolder.Species != "")
//                description.text += "Species: " + cardHolder.Species + "\n";
//            if (cardHolder.Subspecies != "")
//                description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//            if (cardHolder.AnimalSize != "")
//                description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//            if (cardHolder.AnimalEnvironment != "")
//                description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//            if (cardHolder.AnimalDiet != "")
//                description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//            if (cardHolder.PlantType != "")
//                description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//            if (cardHolder.RegionType != "")
//                description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//            if (cardHolder.Domain != "")
//                description.text += "Domain: " + cardHolder.Domain + "\n";
//            if (cardHolder.Infraclass != "")
//                description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//            if (cardHolder.Infraorder != "")
//                description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//            if (cardHolder.Section != "")
//                description.text += "Section: " + cardHolder.Section + "\n";
//            if (cardHolder.Tribe != "")
//                description.text += "Tribe: " + cardHolder.Tribe + "\n";
//            if (cardHolder.Division != "")
//                description.text += "Division: " + cardHolder.Division + "\n";
//            if (cardHolder.Superdivision != "")
//                description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//            if (cardHolder.Subdivision != "")
//                description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//            if (cardHolder.Fungi_type != "")
//                description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//            string[] name = nameHolder.Split('-');
//            string anotherName = "";

//            for (int i = 1; i < name.Length; i++)
//                anotherName += name[i] + " ";

//            nameOfCard.text = anotherName;

//            //prints the actions
//            description.text += "\n" + cardHolder.StandingAction;

//            if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                buttonEnabler.gameObject.SetActive(false);
//            else
//            {
//                description.text += "\n" + cardHolder.SpecialAction.ToString();
//                buttonEnabler.gameObject.SetActive(true);
//            }

//        }
//        else if(nameHolder.Contains("Multi")) //multiplayer name filter
//        {
//            description.text = ""; //just resets it incase there is one that is completeley empty

//            //goes through andmatches the name, then proceeds to print the actions
//            for (int i = 0; i < GameManager.Instance.MultiPlacement.Count; i++)
//            {
//                if (GameManager.Instance.MultiPlacement[i].CardName == nameHolder)
//                {
//                    cardHolder = GameManager.Instance.MultiPlacement[i]; //sets the card holder for the rest of the things needed to be set
//                }
//            }

//            //adding the description based off of everything else
//            if (cardHolder.Kingdom != "")
//                description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//            if (cardHolder.Subkingdom != "")
//                description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//            if (cardHolder.Superphylum != "")
//                description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//            if (cardHolder.Phylum != "")
//                description.text += "Phylum: " + cardHolder.Phylum + "\n";
//            if (cardHolder.Subphylum != "")
//                description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//            if (cardHolder.Superclass != "")
//                description.text += "Superclass: " + cardHolder.Superclass + "\n";
//            if (cardHolder.CardClass != "")
//                description.text += "Class: " + cardHolder.CardClass + "\n";
//            if (cardHolder.Subclass != "")
//                description.text += "Subclass: " + cardHolder.Subclass + "\n";
//            if (cardHolder.Superorder != "")
//                description.text += "Superorder: " + cardHolder.Superorder + "\n";
//            if (cardHolder.Order != "")
//                description.text += "Order: " + cardHolder.Order + "\n";
//            if (cardHolder.Suborder != "")
//                description.text += "Suborder: " + cardHolder.Suborder + "\n";
//            if (cardHolder.Superfamily != "")
//                description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//            if (cardHolder.Family != "")
//                description.text += "Fsmily: " + cardHolder.Family + "\n";
//            if (cardHolder.Subfamily != "")
//                description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//            if (cardHolder.Supergenus != "")
//                description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//            if (cardHolder.Genus != "")
//                description.text += "Genus: " + cardHolder.Genus + "\n";
//            if (cardHolder.Subgenus != "")
//                description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//            if (cardHolder.Species != "")
//                description.text += "Species: " + cardHolder.Species + "\n";
//            if (cardHolder.Subspecies != "")
//                description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//            if (cardHolder.AnimalSize != "")
//                description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//            if (cardHolder.AnimalEnvironment != "")
//                description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//            if (cardHolder.AnimalDiet != "")
//                description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//            if (cardHolder.PlantType != "")
//                description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//            if (cardHolder.RegionType != "")
//                description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//            if (cardHolder.Domain != "")
//                description.text += "Domain: " + cardHolder.Domain + "\n";
//            if (cardHolder.Infraclass != "")
//                description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//            if (cardHolder.Infraorder != "")
//                description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//            if (cardHolder.Section != "")
//                description.text += "Section: " + cardHolder.Section + "\n";
//            if (cardHolder.Tribe != "")
//                description.text += "Tribe: " + cardHolder.Tribe + "\n";
//            if (cardHolder.Division != "")
//                description.text += "Division: " + cardHolder.Division + "\n";
//            if (cardHolder.Superdivision != "")
//                description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//            if (cardHolder.Subdivision != "")
//                description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//            if (cardHolder.Fungi_type != "")
//                description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//            string[] name = nameHolder.Split('-');
//            string anotherName = "";

//            for (int i = 1; i < name.Length; i++)
//                anotherName += name[i] + " ";

//            nameOfCard.text = anotherName;

//            //prints the actions
//            description.text += "\n" + cardHolder.StandingAction;

//            if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                buttonEnabler.gameObject.SetActive(false);
//            else
//            {
//                description.text += "\n" + cardHolder.SpecialAction.ToString();
//                buttonEnabler.gameObject.SetActive(true);
//            }
//        }
//        else if(nameHolder.Contains("Condition")) //condition name filter
//        {
//            description.text = ""; //just resets it incase there is one that is completeley empty

//            //goes through andmatches the name, then proceeds to print the actions
//            for (int i = 0; i < GameManager.Instance.ConditionPlacement.Count; i++)
//            {
//                if (GameManager.Instance.ConditionPlacement[i].CardName == nameHolder)
//                {
//                    cardHolder = GameManager.Instance.ConditionPlacement[i]; //sets the card holder for the rest of the things needed to be set
//                }
//            }

//            //adding the description based off of everything else
//            if (cardHolder.Kingdom != "")
//                description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//            if (cardHolder.Subkingdom != "")
//                description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//            if (cardHolder.Superphylum != "")
//                description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//            if (cardHolder.Phylum != "")
//                description.text += "Phylum: " + cardHolder.Phylum + "\n";
//            if (cardHolder.Subphylum != "")
//                description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//            if (cardHolder.Superclass != "")
//                description.text += "Superclass: " + cardHolder.Superclass + "\n";
//            if (cardHolder.CardClass != "")
//                description.text += "Class: " + cardHolder.CardClass + "\n";
//            if (cardHolder.Subclass != "")
//                description.text += "Subclass: " + cardHolder.Subclass + "\n";
//            if (cardHolder.Superorder != "")
//                description.text += "Superorder: " + cardHolder.Superorder + "\n";
//            if (cardHolder.Order != "")
//                description.text += "Order: " + cardHolder.Order + "\n";
//            if (cardHolder.Suborder != "")
//                description.text += "Suborder: " + cardHolder.Suborder + "\n";
//            if (cardHolder.Superfamily != "")
//                description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//            if (cardHolder.Family != "")
//                description.text += "Fsmily: " + cardHolder.Family + "\n";
//            if (cardHolder.Subfamily != "")
//                description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//            if (cardHolder.Supergenus != "")
//                description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//            if (cardHolder.Genus != "")
//                description.text += "Genus: " + cardHolder.Genus + "\n";
//            if (cardHolder.Subgenus != "")
//                description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//            if (cardHolder.Species != "")
//                description.text += "Species: " + cardHolder.Species + "\n";
//            if (cardHolder.Subspecies != "")
//                description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//            if (cardHolder.AnimalSize != "")
//                description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//            if (cardHolder.AnimalEnvironment != "")
//                description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//            if (cardHolder.AnimalDiet != "")
//                description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//            if (cardHolder.PlantType != "")
//                description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//            if (cardHolder.RegionType != "")
//                description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//            if (cardHolder.Domain != "")
//                description.text += "Domain: " + cardHolder.Domain + "\n";
//            if (cardHolder.Infraclass != "")
//                description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//            if (cardHolder.Infraorder != "")
//                description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//            if (cardHolder.Section != "")
//                description.text += "Section: " + cardHolder.Section + "\n";
//            if (cardHolder.Tribe != "")
//                description.text += "Tribe: " + cardHolder.Tribe + "\n";
//            if (cardHolder.Division != "")
//                description.text += "Division: " + cardHolder.Division + "\n";
//            if (cardHolder.Superdivision != "")
//                description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//            if (cardHolder.Subdivision != "")
//                description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//            if (cardHolder.Fungi_type != "")
//                description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//            string[] name = nameHolder.Split('-');
//            string anotherName = "";

//            for (int i = 1; i < name.Length; i++)
//                anotherName += name[i] + " ";

//            nameOfCard.text = anotherName;

//            //prints the actions
//            description.text += "\n" + cardHolder.StandingAction;

//            if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                buttonEnabler.gameObject.SetActive(false);
//            else
//            {
//                description.text += "\n" + cardHolder.SpecialAction.ToString();
//                buttonEnabler.gameObject.SetActive(true);
//            }
//        }
//        else if(nameHolder.Contains("Invertebrate")) //invertebrate name filter
//        {
//            description.text = ""; //just resets it incase there is one that is completeley empty

//            //goes through andmatches the name, then proceeds to print the actions
//            for (int i = 0; i < GameManager.Instance.InvertebratePlacement.Count; i++)
//            {
//                if (GameManager.Instance.InvertebratePlacement[i].CardName == nameHolder)
//                {
//                    cardHolder = GameManager.Instance.InvertebratePlacement[i]; //sets the card holder for the rest of the things needed to be set
//                }
//            }

//            //adding the description based off of everything else
//            if (cardHolder.Kingdom != "")
//                description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//            if (cardHolder.Subkingdom != "")
//                description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//            if (cardHolder.Superphylum != "")
//                description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//            if (cardHolder.Phylum != "")
//                description.text += "Phylum: " + cardHolder.Phylum + "\n";
//            if (cardHolder.Subphylum != "")
//                description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//            if (cardHolder.Superclass != "")
//                description.text += "Superclass: " + cardHolder.Superclass + "\n";
//            if (cardHolder.CardClass != "")
//                description.text += "Class: " + cardHolder.CardClass + "\n";
//            if (cardHolder.Subclass != "")
//                description.text += "Subclass: " + cardHolder.Subclass + "\n";
//            if (cardHolder.Superorder != "")
//                description.text += "Superorder: " + cardHolder.Superorder + "\n";
//            if (cardHolder.Order != "")
//                description.text += "Order: " + cardHolder.Order + "\n";
//            if (cardHolder.Suborder != "")
//                description.text += "Suborder: " + cardHolder.Suborder + "\n";
//            if (cardHolder.Superfamily != "")
//                description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//            if (cardHolder.Family != "")
//                description.text += "Fsmily: " + cardHolder.Family + "\n";
//            if (cardHolder.Subfamily != "")
//                description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//            if (cardHolder.Supergenus != "")
//                description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//            if (cardHolder.Genus != "")
//                description.text += "Genus: " + cardHolder.Genus + "\n";
//            if (cardHolder.Subgenus != "")
//                description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//            if (cardHolder.Species != "")
//                description.text += "Species: " + cardHolder.Species + "\n";
//            if (cardHolder.Subspecies != "")
//                description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//            if (cardHolder.AnimalSize != "")
//                description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//            if (cardHolder.AnimalEnvironment != "")
//                description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//            if (cardHolder.AnimalDiet != "")
//                description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//            if (cardHolder.PlantType != "")
//                description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//            if (cardHolder.RegionType != "")
//                description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//            if (cardHolder.Domain != "")
//                description.text += "Domain: " + cardHolder.Domain + "\n";
//            if (cardHolder.Infraclass != "")
//                description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//            if (cardHolder.Infraorder != "")
//                description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//            if (cardHolder.Section != "")
//                description.text += "Section: " + cardHolder.Section + "\n";
//            if (cardHolder.Tribe != "")
//                description.text += "Tribe: " + cardHolder.Tribe + "\n";
//            if (cardHolder.Division != "")
//                description.text += "Division: " + cardHolder.Division + "\n";
//            if (cardHolder.Superdivision != "")
//                description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//            if (cardHolder.Subdivision != "")
//                description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//            if (cardHolder.Fungi_type != "")
//                description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//            string[] name = nameHolder.Split('-');
//            string anotherName = "";

//            for (int i = 1; i < name.Length; i++)
//                anotherName += name[i] + " ";

//            nameOfCard.text = anotherName;

//            //prints the actions
//            description.text += "\n" + cardHolder.StandingAction;

//            if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                buttonEnabler.gameObject.SetActive(false);
//            else
//            {
//                description.text += "\n" + cardHolder.SpecialAction.ToString();
//                buttonEnabler.gameObject.SetActive(true);
//            }
//        }
//        else if(nameHolder.Contains("Fungi")) //fungi name filter
//        {
//            description.text = ""; //just resets it incase there is one that is completeley empty

//            //goes through andmatches the name, then proceeds to print the actions
//            for (int i = 0; i < GameManager.Instance.FungiPlacement.Count; i++)
//            {
//                if (GameManager.Instance.FungiPlacement[i].CardName == nameHolder)
//                {
//                    cardHolder = GameManager.Instance.FungiPlacement[i]; //sets the card holder for the rest of the things needed to be set
//                }
//            }

//            //adding the description based off of everything else
//            if (cardHolder.Kingdom != "")
//                description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//            if (cardHolder.Subkingdom != "")
//                description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//            if (cardHolder.Superphylum != "")
//                description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//            if (cardHolder.Phylum != "")
//                description.text += "Phylum: " + cardHolder.Phylum + "\n";
//            if (cardHolder.Subphylum != "")
//                description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//            if (cardHolder.Superclass != "")
//                description.text += "Superclass: " + cardHolder.Superclass + "\n";
//            if (cardHolder.CardClass != "")
//                description.text += "Class: " + cardHolder.CardClass + "\n";
//            if (cardHolder.Subclass != "")
//                description.text += "Subclass: " + cardHolder.Subclass + "\n";
//            if (cardHolder.Superorder != "")
//                description.text += "Superorder: " + cardHolder.Superorder + "\n";
//            if (cardHolder.Order != "")
//                description.text += "Order: " + cardHolder.Order + "\n";
//            if (cardHolder.Suborder != "")
//                description.text += "Suborder: " + cardHolder.Suborder + "\n";
//            if (cardHolder.Superfamily != "")
//                description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//            if (cardHolder.Family != "")
//                description.text += "Fsmily: " + cardHolder.Family + "\n";
//            if (cardHolder.Subfamily != "")
//                description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//            if (cardHolder.Supergenus != "")
//                description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//            if (cardHolder.Genus != "")
//                description.text += "Genus: " + cardHolder.Genus + "\n";
//            if (cardHolder.Subgenus != "")
//                description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//            if (cardHolder.Species != "")
//                description.text += "Species: " + cardHolder.Species + "\n";
//            if (cardHolder.Subspecies != "")
//                description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//            if (cardHolder.AnimalSize != "")
//                description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//            if (cardHolder.AnimalEnvironment != "")
//                description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//            if (cardHolder.AnimalDiet != "")
//                description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//            if (cardHolder.PlantType != "")
//                description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//            if (cardHolder.RegionType != "")
//                description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//            if (cardHolder.Domain != "")
//                description.text += "Domain: " + cardHolder.Domain + "\n";
//            if (cardHolder.Infraclass != "")
//                description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//            if (cardHolder.Infraorder != "")
//                description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//            if (cardHolder.Section != "")
//                description.text += "Section: " + cardHolder.Section + "\n";
//            if (cardHolder.Tribe != "")
//                description.text += "Tribe: " + cardHolder.Tribe + "\n";
//            if (cardHolder.Division != "")
//                description.text += "Division: " + cardHolder.Division + "\n";
//            if (cardHolder.Superdivision != "")
//                description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//            if (cardHolder.Subdivision != "")
//                description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//            if (cardHolder.Fungi_type != "")
//                description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//            string[] name = nameHolder.Split('-');
//            string anotherName = "";

//            for (int i = 1; i < name.Length; i++)
//                anotherName += name[i] + " ";

//            nameOfCard.text = anotherName;

//            //prints the actions
//            description.text += "\n" + cardHolder.StandingAction;

//            if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                buttonEnabler.gameObject.SetActive(false);
//            else
//            {
//                description.text += "\n" + cardHolder.SpecialAction.ToString();
//                buttonEnabler.gameObject.SetActive(true);
//            }
//        }
//        else if(nameHolder.Contains("Human")) //humam name filter
//        {
//            description.text = ""; //just resets it incase there is one that is completeley empty

//            //goes through andmatches the name, then proceeds to print the actions
//            for (int i = 0; i < GameManager.Instance.HumanPlacement.Count; i++)
//            {
//                if (GameManager.Instance.HumanPlacement[i].CardName == nameHolder)
//                {
//                    cardHolder = GameManager.Instance.HumanPlacement[i];
//                }
//            }

//            //adding the description based off of everything else
//            if (cardHolder.Kingdom != "")
//                description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//            if (cardHolder.Subkingdom != "")
//                description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//            if (cardHolder.Superphylum != "")
//                description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//            if (cardHolder.Phylum != "")
//                description.text += "Phylum: " + cardHolder.Phylum + "\n";
//            if (cardHolder.Subphylum != "")
//                description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//            if (cardHolder.Superclass != "")
//                description.text += "Superclass: " + cardHolder.Superclass + "\n";
//            if (cardHolder.CardClass != "")
//                description.text += "Class: " + cardHolder.CardClass + "\n";
//            if (cardHolder.Subclass != "")
//                description.text += "Subclass: " + cardHolder.Subclass + "\n";
//            if (cardHolder.Superorder != "")
//                description.text += "Superorder: " + cardHolder.Superorder + "\n";
//            if (cardHolder.Order != "")
//                description.text += "Order: " + cardHolder.Order + "\n";
//            if (cardHolder.Suborder != "")
//                description.text += "Suborder: " + cardHolder.Suborder + "\n";
//            if (cardHolder.Superfamily != "")
//                description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//            if (cardHolder.Family != "")
//                description.text += "Fsmily: " + cardHolder.Family + "\n";
//            if (cardHolder.Subfamily != "")
//                description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//            if (cardHolder.Supergenus != "")
//                description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//            if (cardHolder.Genus != "")
//                description.text += "Genus: " + cardHolder.Genus + "\n";
//            if (cardHolder.Subgenus != "")
//                description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//            if (cardHolder.Species != "")
//                description.text += "Species: " + cardHolder.Species + "\n";
//            if (cardHolder.Subspecies != "")
//                description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//            if (cardHolder.AnimalSize != "")
//                description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//            if (cardHolder.AnimalEnvironment != "")
//                description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//            if (cardHolder.AnimalDiet != "")
//                description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//            if (cardHolder.PlantType != "")
//                description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//            if (cardHolder.RegionType != "")
//                description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//            if (cardHolder.Domain != "")
//                description.text += "Domain: " + cardHolder.Domain + "\n";
//            if (cardHolder.Infraclass != "")
//                description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//            if (cardHolder.Infraorder != "")
//                description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//            if (cardHolder.Section != "")
//                description.text += "Section: " + cardHolder.Section + "\n";
//            if (cardHolder.Tribe != "")
//                description.text += "Tribe: " + cardHolder.Tribe + "\n";
//            if (cardHolder.Division != "")
//                description.text += "Division: " + cardHolder.Division + "\n";
//            if (cardHolder.Superdivision != "")
//                description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//            if (cardHolder.Subdivision != "")
//                description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//            if (cardHolder.Fungi_type != "")
//                description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//            string[] name = nameHolder.Split('-');
//            string anotherName = "";

//            for (int i = 1; i < name.Length; i++)
//                anotherName += name[i] + " ";

//            nameOfCard.text = anotherName;

//            //prints the actions
//            description.text += "\n" + cardHolder.StandingAction;

//            if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                buttonEnabler.gameObject.SetActive(false);
//            else
//            {
//                description.text += "\n" + cardHolder.SpecialAction.ToString();
//                buttonEnabler.gameObject.SetActive(true);
//            }
//        }
//        else if(nameHolder.Contains("Animal")) //animal name filter
//        {
//            description.text = ""; //just resets it incase there is one that is completeley empty

//            //goes through andmatches the name, then proceeds to print the actions
//            for (int i = 0; i < GameManager.Instance.AnimalPlacement.Count; i++)
//            {
//                if (GameManager.Instance.AnimalPlacement[i].CardName == nameHolder)
//                {
//                    cardHolder = GameManager.Instance.AnimalPlacement[i]; //sets the card holder for the rest of the things needed to be set
//                }
//            }

//            //adding the description based off of everything else
//            if (cardHolder.Kingdom != "")
//                description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//            if (cardHolder.Subkingdom != "")
//                description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//            if (cardHolder.Superphylum != "")
//                description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//            if (cardHolder.Phylum != "")
//                description.text += "Phylum: " + cardHolder.Phylum + "\n";
//            if (cardHolder.Subphylum != "")
//                description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//            if (cardHolder.Superclass != "")
//                description.text += "Superclass: " + cardHolder.Superclass + "\n";
//            if (cardHolder.CardClass != "")
//                description.text += "Class: " + cardHolder.CardClass + "\n";
//            if (cardHolder.Subclass != "")
//                description.text += "Subclass: " + cardHolder.Subclass + "\n";
//            if (cardHolder.Superorder != "")
//                description.text += "Superorder: " + cardHolder.Superorder + "\n";
//            if (cardHolder.Order != "")
//                description.text += "Order: " + cardHolder.Order + "\n";
//            if (cardHolder.Suborder != "")
//                description.text += "Suborder: " + cardHolder.Suborder + "\n";
//            if (cardHolder.Superfamily != "")
//                description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//            if (cardHolder.Family != "")
//                description.text += "Fsmily: " + cardHolder.Family + "\n";
//            if (cardHolder.Subfamily != "")
//                description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//            if (cardHolder.Supergenus != "")
//                description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//            if (cardHolder.Genus != "")
//                description.text += "Genus: " + cardHolder.Genus + "\n";
//            if (cardHolder.Subgenus != "")
//                description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//            if (cardHolder.Species != "")
//                description.text += "Species: " + cardHolder.Species + "\n";
//            if (cardHolder.Subspecies != "")
//                description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//            if (cardHolder.AnimalSize != "")
//                description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//            if (cardHolder.AnimalEnvironment != "")
//                description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//            if (cardHolder.AnimalDiet != "")
//                description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//            if (cardHolder.PlantType != "")
//                description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//            if (cardHolder.RegionType != "")
//                description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//            if (cardHolder.Domain != "")
//                description.text += "Domain: " + cardHolder.Domain + "\n";
//            if (cardHolder.Infraclass != "")
//                description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//            if (cardHolder.Infraorder != "")
//                description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//            if (cardHolder.Section != "")
//                description.text += "Section: " + cardHolder.Section + "\n";
//            if (cardHolder.Tribe != "")
//                description.text += "Tribe: " + cardHolder.Tribe + "\n";
//            if (cardHolder.Division != "")
//                description.text += "Division: " + cardHolder.Division + "\n";
//            if (cardHolder.Superdivision != "")
//                description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//            if (cardHolder.Subdivision != "")
//                description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//            if (cardHolder.Fungi_type != "")
//                description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//            string[] name = nameHolder.Split('-');
//            string anotherName = "";

//            for (int i = 1; i < name.Length; i++)
//                anotherName += name[i] + " ";

//            nameOfCard.text = anotherName;

//            //prints the actions
//            description.text += "\n" + cardHolder.StandingAction;

//            if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                buttonEnabler.gameObject.SetActive(false);
//            else
//            {
//                description.text += "\n" + cardHolder.SpecialAction.ToString();
//                buttonEnabler.gameObject.SetActive(true);
//            }
//        }
//        else if(nameHolder.Contains("Microbe")) //microbe name filter
//        {
//            description.text = ""; //just resets it incase there is one that is completeley empty

//            //goes through andmatches the name, then proceeds to print the actions
//            for (int i = 0; i < GameManager.Instance.MicrobePlacement.Count; i++)
//            {
//                if (GameManager.Instance.MicrobePlacement[i].CardName == nameHolder)
//                {
//                    cardHolder = GameManager.Instance.MicrobePlacement[i]; //sets the card holder for the rest of the things needed to be set
//                }
//            }

//            //adding the description based off of everything else
//            if (cardHolder.Kingdom != "")
//                description.text += "Kingdom: " + cardHolder.Kingdom + "\n";
//            if (cardHolder.Subkingdom != "")
//                description.text += "SubKingdom: " + cardHolder.Subkingdom + "\n";
//            if (cardHolder.Superphylum != "")
//                description.text += "Superphylum: " + cardHolder.Superphylum + "\n";
//            if (cardHolder.Phylum != "")
//                description.text += "Phylum: " + cardHolder.Phylum + "\n";
//            if (cardHolder.Subphylum != "")
//                description.text += "SubPhylum: " + cardHolder.Subphylum + "\n";
//            if (cardHolder.Superclass != "")
//                description.text += "Superclass: " + cardHolder.Superclass + "\n";
//            if (cardHolder.CardClass != "")
//                description.text += "Class: " + cardHolder.CardClass + "\n";
//            if (cardHolder.Subclass != "")
//                description.text += "Subclass: " + cardHolder.Subclass + "\n";
//            if (cardHolder.Superorder != "")
//                description.text += "Superorder: " + cardHolder.Superorder + "\n";
//            if (cardHolder.Order != "")
//                description.text += "Order: " + cardHolder.Order + "\n";
//            if (cardHolder.Suborder != "")
//                description.text += "Suborder: " + cardHolder.Suborder + "\n";
//            if (cardHolder.Superfamily != "")
//                description.text += "Superfamily: " + cardHolder.Superfamily + "\n";
//            if (cardHolder.Family != "")
//                description.text += "Fsmily: " + cardHolder.Family + "\n";
//            if (cardHolder.Subfamily != "")
//                description.text += "Subfamily: " + cardHolder.Subfamily + "\n";
//            if (cardHolder.Supergenus != "")
//                description.text += "Supergenus: " + cardHolder.Supergenus + "\n";
//            if (cardHolder.Genus != "")
//                description.text += "Genus: " + cardHolder.Genus + "\n";
//            if (cardHolder.Subgenus != "")
//                description.text += "Subgenus: " + cardHolder.Subgenus + "\n";
//            if (cardHolder.Species != "")
//                description.text += "Species: " + cardHolder.Species + "\n";
//            if (cardHolder.Subspecies != "")
//                description.text += "Subspecies: " + cardHolder.Subspecies + "\n";
//            if (cardHolder.AnimalSize != "")
//                description.text += "Animal Size: " + cardHolder.AnimalSize + "\n";
//            if (cardHolder.AnimalEnvironment != "")
//                description.text += "Animal Environment: " + cardHolder.AnimalEnvironment + "\n";
//            if (cardHolder.AnimalDiet != "")
//                description.text += "Animal Diet: " + cardHolder.AnimalDiet + "\n";
//            if (cardHolder.PlantType != "")
//                description.text += "Plant Type: " + cardHolder.PlantType + "\n";
//            if (cardHolder.RegionType != "")
//                description.text += "Regiontype: " + cardHolder.RegionType + "\n";
//            if (cardHolder.Domain != "")
//                description.text += "Domain: " + cardHolder.Domain + "\n";
//            if (cardHolder.Infraclass != "")
//                description.text += "Infraclass: " + cardHolder.Infraclass + "\n";
//            if (cardHolder.Infraorder != "")
//                description.text += "Infraorder: " + cardHolder.Infraorder + "\n";
//            if (cardHolder.Section != "")
//                description.text += "Section: " + cardHolder.Section + "\n";
//            if (cardHolder.Tribe != "")
//                description.text += "Tribe: " + cardHolder.Tribe + "\n";
//            if (cardHolder.Division != "")
//                description.text += "Division: " + cardHolder.Division + "\n";
//            if (cardHolder.Superdivision != "")
//                description.text += "Superdivision: " + cardHolder.Superdivision + "\n";
//            if (cardHolder.Subdivision != "")
//                description.text += "Subdivision: " + cardHolder.Subdivision + "\n";
//            if (cardHolder.Fungi_type != "")
//                description.text += "Fungi Type: " + cardHolder.Fungi_type + "\n";

//            string[] name = nameHolder.Split('-');
//            string anotherName = "";

//            for (int i = 1; i < name.Length; i++)
//                anotherName += name[i] + " ";

//            nameOfCard.text = anotherName;

//            //prints the actions
//            description.text += "\n" + cardHolder.StandingAction;

//            if (cardHolder.SpecialAction == "" || cardHolder.SpecialAction == null)
//                buttonEnabler.gameObject.SetActive(false);
//            else
//            {
//                description.text += "\n" + cardHolder.SpecialAction.ToString();
//                buttonEnabler.gameObject.SetActive(true);
//            }
//        }

//        imageOfCard.sprite = gameObject.GetComponent<SpriteRenderer>().sprite; //should set the image for the card
//    }
//}
=======
﻿/*
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
    private Button buttonEnabler;
    private Card cardHolder;
    private Player thePlayer;//will be used to hold the card info 

    // Use this for initialization
    void Start()
    {
        //assigns the objects to UI objects
        NameOfCard = GameObject.Find("CardName").GetComponent<Text>();
        ImageOfCard = GameObject.Find("CardImage").GetComponent<Image>();
        DescriptionOfCard = GameObject.Find("CardDescription").GetComponent<Text>();
        ButtonEnabler = GameObject.Find("ActionButton").GetComponent<Button>();
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

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.CreateBoards();
        GameManager.Instance.HideShow.ShowCardInfo();

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
                    ButtonEnabler.gameObject.SetActive(false);
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    ButtonEnabler.gameObject.SetActive(true);
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
                    ButtonEnabler.gameObject.SetActive(false);
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    ButtonEnabler.gameObject.SetActive(true);
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
                    ButtonEnabler.gameObject.SetActive(false);
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    ButtonEnabler.gameObject.SetActive(true);
                }
            }
            else if (nameHolder.Contains("Multi")) //multiplayer name filter
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
                    ButtonEnabler.gameObject.SetActive(false);
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    ButtonEnabler.gameObject.SetActive(true);
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
                    ButtonEnabler.gameObject.SetActive(false);
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    ButtonEnabler.gameObject.SetActive(true);
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
                    ButtonEnabler.gameObject.SetActive(false);
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    ButtonEnabler.gameObject.SetActive(true);
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
                    ButtonEnabler.gameObject.SetActive(false);
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    ButtonEnabler.gameObject.SetActive(true);
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
                    ButtonEnabler.gameObject.SetActive(false);
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    ButtonEnabler.gameObject.SetActive(true);
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
                    ButtonEnabler.gameObject.SetActive(false);
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    ButtonEnabler.gameObject.SetActive(true);
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
                    ButtonEnabler.gameObject.SetActive(false);
                else
                {
                    DescriptionOfCard.text += "\n" + CardHolder.SpecialAction.ToString();
                    ButtonEnabler.gameObject.SetActive(true);
                }
            }
        
        //sets the image to the current image of card
        ImageOfCard.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
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
    public Button ButtonEnabler { get => buttonEnabler; set => buttonEnabler = value; }
    public Card CardHolder { get => cardHolder; set => cardHolder = value; }
}
>>>>>>> Stashed changes
