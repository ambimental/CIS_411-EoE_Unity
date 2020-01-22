//CARD OBJECT CLASS - USED TO STORE INFO FROM THE DATABASE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {

    //info from card
    private string cardID;
    private string cardName;
    private string cardType;
    private int pointValue;
    private string kingdom;
    private string subkingdom;
    private string superdivision;
    private string division;
    private string subdivision;
    private string superphylum;
    private string phylum;
    private string subphylum;
    private string cardClass;  //cant just be "class" due to errors in code
    private string superclass;
    private string subclass;
    private string superorder;
    private string order;
    private string suborder;
    private string superfamily;
    private string family;
    private string subfamily;
    private string supergenus;
    private string genus;
    private string subgenus;
    private string superspecies;
    private string species;
    private string subspecies;
    private string animalSize;
    private string animalEnvironment;
    private string animalDiet;
    private string plantType;
    private string regionType;
    private string domain;
    private string infraclass;
    private string infraorder;
    private string section;
    private string tribe;
    private string fungi_type;
    private string standingAction;
    private string specialAction;
    private string cardNotes;

    public List<string> reqID;

    private List<string> actionID;

    //Accesor and mutator methods for all variables
    public string CardID { get { return cardID; } set { cardID = value; } }
    public string CardName { get { return cardName; } set { cardName = value; } }
    public string CardType { get { return cardType; } set { cardType = value; } }
    public int PointValue { get { return pointValue; } set { pointValue = value; } }
    public string Kingdom { get { return kingdom; } set { kingdom = value; } }
    public string Subkingdom { get { return subkingdom; } set { subkingdom = value; } }
    public string Superdivision { get { return superdivision; } set { superdivision = value; } }
    public string Division { get { return division; } set { division = value; } }
    public string Subdivision { get { return subdivision; } set { subdivision = value; } }
    public string Superphylum { get { return superphylum; } set { superphylum = value; } }
    public string Phylum { get { return phylum; } set { phylum = value; } }
    public string Subphylum { get { return subphylum; } set { subphylum = value; } }
    public string CardClass { get { return cardClass; } set { cardClass = value; } }
    public string Superclass { get { return superclass; } set { superclass = value; } }
    public string Subclass { get { return subclass; } set { subclass = value; } }
    public string Superorder { get { return superorder; } set { superorder = value; } }
    public string Order { get { return order; } set { order = value; } }
    public string Suborder { get { return suborder; } set { suborder = value; } }
    public string Superfamily { get { return superfamily; } set { superfamily = value; } }
    public string Family { get { return family; } set { family = value; } }
    public string Subfamily { get { return subfamily; } set { subfamily = value; } }
    public string Supergenus { get { return supergenus; } set { supergenus = value; } }
    public string Genus { get { return genus; } set { genus = value; } }
    public string Subgenus { get { return subgenus; } set { subgenus = value; } }
    public string Superspecies { get { return superspecies; } set { superspecies = value; } }
    public string Species { get { return species; } set { species = value; } }
    public string Subspecies { get { return subspecies; } set { subspecies = value; } }
    public string AnimalSize { get { return animalSize; } set { animalSize = value; } }
    public string AnimalEnvironment { get { return animalEnvironment; } set { animalEnvironment = value; } }
    public string AnimalDiet { get { return animalDiet; } set { animalDiet = value; } }
    public string PlantType { get { return plantType; } set { plantType = value; } }
    public string RegionType { get { return regionType; } set { regionType = value; } }
    public string Domain { get { return domain; } set { domain = value; } }
    public string Infraclass { get { return infraclass; } set { infraclass = value; } }
    public string Infraorder { get { return infraorder; } set { infraorder = value; } }
    public string Section { get { return section; } set { section = value; } }
    public string Tribe { get { return tribe; } set { tribe = value; } }
    public string Fungi_type { get { return fungi_type; } set { fungi_type = value; } }
    public List<string> ReqID { get { return reqID; } set { reqID = value; } }
    public List<string> ActionID { get { return actionID; } set { actionID = value; } }

    public string StandingAction
    {
        get
        {
            return standingAction;
        }

        set
        {
            standingAction = value;
        }
    }

    public string SpecialAction
    {
        get
        {
            return specialAction;
        }

        set
        {
            specialAction = value;
        }
    }

    public string CardNotes
    {
        get
        {
            return cardNotes;
        }

        set
        {
            cardNotes = value;
        }
    }

    public Card() //default constructor
    {
        CardID = "";
        CardName = "";
        CardType = "";
        PointValue = 0;
        Kingdom = "";
        Subkingdom = "";
        Superdivision = "";
        Division = "";
        Subdivision = "";
        Superphylum = "";
        Phylum = "";
        Subphylum = "";
        Superclass = "";
        CardClass = "";
        Subclass = "";
        Superorder = "";
        Order = "";
        Suborder = "";
        Superfamily = "";
        Family = "";
        Subfamily = "";
        Supergenus = "";
        Genus = "";
        Subgenus = "";
        Superspecies = "";
        Species = "";
        Subspecies = "";
        AnimalSize = "";
        AnimalEnvironment = "";
        AnimalDiet = "";
        PlantType = "";
        RegionType = "";
        StandingAction = "";
        SpecialAction = "";
        CardNotes = "";

        reqID = new List<string>();

        actionID = new List<string>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
