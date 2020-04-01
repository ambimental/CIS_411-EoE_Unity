//WILL BE USED IN PLACE OF THE MOVE BOARD SCRIPT, WILL INSTEAD HIDE THE BOARDS AND MAKE THEM REAPPEAR WHEN NEEDED

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideShowBoards : MonoBehaviour {


    //will be used to access the canvas groups to disable and enable the view
    public CanvasGroup playerCG;
    public CanvasGroup cp1CG;
    public CanvasGroup cp2CG;
    public CanvasGroup cp3CG;

    public GameObject showPlayer; //for showin the player and cp boards
    public GameObject showCP1;
    public GameObject showCP2;
    public GameObject showCP3;

    //to be used for the round text - can only be changed when they are visible
    public Text cp1Round;
    public Text cp2Round;
    public Text cp3Round;

    public Image player1Color;
    public Image cp1Color;
    public Image cp2Color;
    public Image cp3Color;

    public Text player1DeckText;
    public Text cp1DeckText;
    public Text cp2DeckText;
    public Text cp3DeckText;

    //will be used to set the titel of the decks
    /*public Image playerDeckImage;
    public Image cp1DeckImage;
    public Image cp2DeckImage;
    public Image cp3DeckImage;
    */

    public Text drawText; //will be used to set the player draw text

    //public GameObject cardInfo;

    //public GameObject AcidicWatersCanvas; //for the acidic waters canvas

    //public Text acidCp1Text; //for the acidic waters text
    //public Text acidCp2Text;
    //public Text acidCp3Text;

    //public Button acidCp1Button; //for the acidic waters buttons
    //public Button acidCp2Button;
    //public Button acidCp3Button;

    // Use this for initialization
    void Start() {
        //Initializes all objects to the appropriate canvas groups
        playerCG = GameObject.Find("Player Board").GetComponent<CanvasGroup>();
        //GameManager.Instance.playerCanvas = playerCG; //sets the global variable
        cp1CG = GameObject.Find("CP1 Board").GetComponent<CanvasGroup>();
        cp2CG = GameObject.Find("CP2 Board").GetComponent<CanvasGroup>();
        cp3CG = GameObject.Find("CP3 Board").GetComponent<CanvasGroup>();


        showPlayer = GameObject.Find("Player");
      //  GameManager.Instance.playerView = showPlayer; //sets the global variable
        showCP1 = GameObject.Find("CP1 Board");
        showCP2 = GameObject.Find("CP2 Board");
        showCP3 = GameObject.Find("CP3 Board");

        cp1Round = GameObject.Find("ComputerOneRoundText").GetComponent<Text>();
        cp2Round = GameObject.Find("ComputerTwoRoundText").GetComponent<Text>();
        cp3Round = GameObject.Find("ComputerThreeRoundText").GetComponent<Text>();

        ////finds the variables that need accessed
        //player1Color = GameObject.Find("PlayerColor").GetComponent<Image>();
        //cp1Color = GameObject.Find("CP1Color").GetComponent<Image>();
        //cp2Color = GameObject.Find("CP2Color").GetComponent<Image>();
        //cp3Color = GameObject.Find("CP3Color").GetComponent<Image>();

        ////finds the text variables that need accessed
        //player1DeckText = GameObject.Find("PlayerDeckText").GetComponent<Text>();
        //cp1DeckText = GameObject.Find("CP1DeckText").GetComponent<Text>();
        //cp2DeckText = GameObject.Find("CP2DeckText").GetComponent<Text>();
        //cp3DeckText = GameObject.Find("CP3DeckText").GetComponent<Text>();

        /*
        playerDeckImage = GameObject.Find("PlayerDeckTitleImage").GetComponent<Image>();
        cp1DeckImage = GameObject.Find("CP1DeckTitleImage").GetComponent<Image>();
        cp2DeckImage = GameObject.Find("CP2DeckTitleImage").GetComponent<Image>();
        cp3DeckImage = GameObject.Find("CP3DeckTitleImage").GetComponent<Image>();
        */    

        //sets the hand parents
        //GameManager.Instance.cp1Hand = GameObject.Find("Computer One Board/CP1Hand").transform;
        //GameManager.Instance.cp2Hand = GameObject.Find("Computer Two Board/CP2Hand").transform;
        //GameManager.Instance.cp3Hand = GameObject.Find("Computer Three Board/CP3Hand").transform;

        //cardInfo = GameObject.Find("CardInfoCanvas"); //to get the panel
        //GameManager.Instance.cardInfoPanel = cardInfo;

        //GameManager.Instance.nameCard = GameObject.Find("CardInfoCanvas/CardInfoPanel/CardName").GetComponent<Text>();
        //GameManager.Instance.imageCard = GameObject.Find("CardInfoCanvas/CardInfoPanel/CardImage").GetComponent<Image>();
        //GameManager.Instance.descriptionCard = GameObject.Find("CardInfoCanvas/CardInfoPanel/CardDescription").GetComponent<Text>();
        //GameManager.Instance.specialActionButton = GameObject.Find("CardInfoCanvas/CardInfoPanel/ActionButton").GetComponent<Button>();

        //GameManager.Instance.cp1AI = GameObject.Find("Game Board Container/CP1 Board/CP1 Canvas/Computer One Board/CP1Hand").GetComponent<Transform>();

        //AcidicWatersCanvas = GameObject.Find("AcidicWatersChoiceCanvas"); //gets the canvas
        //GameManager.Instance.AcidicWatersCanvas = AcidicWatersCanvas;

        ////buttons for acidic waters
        //GameManager.Instance.cp1AcidButton = GameObject.Find("AcidicWatersChoiceCanvas/AcidicWatersPanel/Cp1Button").GetComponent<Button>();
        //GameManager.Instance.cp2AcidButton = GameObject.Find("AcidicWatersChoiceCanvas/AcidicWatersPanel/Cp2Button").GetComponent<Button>();
        //GameManager.Instance.cp3AcidButton = GameObject.Find("AcidicWatersChoiceCanvas/AcidicWatersPanel/Cp3Button").GetComponent<Button>();

        ////text for acidic waters
        //GameManager.Instance.cp1AcidText = GameObject.Find("AcidicWatersChoiceCanvas/Cp1Text").GetComponent<Text>();
        //GameManager.Instance.cp2AcidText = GameObject.Find("AcidicWatersChoiceCanvas/Cp2Text").GetComponent<Text>();
        //GameManager.Instance.cp3AcidText = GameObject.Find("AcidicWatersChoiceCanvas/Cp3Text").GetComponent<Text>();



        //text for acidic waters

        //will set the initial colors based off of what the decks are

        //if (GameManager.Instance.deckPicked == "D001")
        //{
        //    player1Color.color = GameManager.Instance.alleghenyColor;
        //    //playerDeckImage.sprite = GameManager.Instance.anfTitle;
        //    player1DeckText.text = "Allegheny National Forest";
        //}
        //else if (GameManager.Instance.deckPicked == "D002")
        //{
        //    player1Color.color = GameManager.Instance.appalachianColor;
        //    //playerDeckImage.sprite = GameManager.Instance.ahTitle;
        //    player1DeckText.text = "Appalachian Homestead";
        //}
        //else if (GameManager.Instance.deckPicked == "D003")
        //{
        //    player1Color.color = GameManager.Instance.peatBogsColor;
        //    //playerDeckImage.sprite = GameManager.Instance.pbTitle;
        //    player1DeckText.text = "Peat Bogs";
        //}
        //else if (GameManager.Instance.deckPicked == "D004")
        //{
        //    player1Color.color = GameManager.Instance.clarionRiverColor;
        //    //playerDeckImage.sprite = GameManager.Instance.crTitle;
        //    player1DeckText.text = "Clarion River";
        //}

        //if (GameManager.Instance.computerOneDeck == "D001") //set cp1 color
        //{
        //    cp1Color.color = GameManager.Instance.alleghenyColor;
        //    //cp1DeckImage.sprite = GameManager.Instance.anfTitle;
        //    cp1DeckText.text = "Allegheny National Forest";
        //}
        //else if (GameManager.Instance.computerOneDeck == "D002")
        //{
        //    cp1Color.color = GameManager.Instance.appalachianColor;
        //    //cp1DeckImage.sprite = GameManager.Instance.ahTitle;
        //    cp1DeckText.text = "Appalachian Homestead";
        //}
        //else if (GameManager.Instance.computerOneDeck == "D003")
        //{
        //    cp1Color.color = GameManager.Instance.peatBogsColor;
        //    //cp1DeckImage.sprite = GameManager.Instance.pbTitle;
        //    cp1DeckText.text = "Peat Bogs";
        //}
        //else if (GameManager.Instance.computerOneDeck == "D004")
        //{
        //    cp1Color.color = GameManager.Instance.clarionRiverColor;
        //    //cp1DeckImage.sprite = GameManager.Instance.crTitle;
        //    cp1DeckText.text = "Clarion River";
        //}

        //if (GameManager.Instance.computerTwoDeck == "D001") //set cp2 color
        //{
        //    cp2Color.color = GameManager.Instance.alleghenyColor;
        //    //cp2DeckImage.sprite = GameManager.Instance.anfTitle;
        //    cp2DeckText.text = "Allegheny National Forest";
        //}
        //else if (GameManager.Instance.computerTwoDeck == "D002")
        //{
        //    cp2Color.color = GameManager.Instance.appalachianColor;
        //    //cp2DeckImage.sprite = GameManager.Instance.ahTitle;
        //    cp2DeckText.text = "Appalachian Homestead";
        //}
        //else if (GameManager.Instance.computerTwoDeck == "D003")
        //{
        //    cp2Color.color = GameManager.Instance.peatBogsColor;
        //    //cp2DeckImage.sprite = GameManager.Instance.pbTitle;
        //    cp2DeckText.text = "Peat Bogs";
        //}
        //else if (GameManager.Instance.computerTwoDeck == "D004")
        //{
        //    cp2Color.color = GameManager.Instance.clarionRiverColor;
        //    //cp2DeckImage.sprite = GameManager.Instance.crTitle;
        //    cp2DeckText.text = "Clarion River";
        //}

        //if (GameManager.Instance.computerThreeDeck == "D001") //set cp3 color
        //{
        //    cp3Color.color = GameManager.Instance.alleghenyColor;
        //    //cp3DeckImage.sprite = GameManager.Instance.anfTitle;
        //    cp3DeckText.text = "Allegheny National Forest";
        //}
        //else if (GameManager.Instance.computerThreeDeck == "D002")
        //{
        //    cp3Color.color = GameManager.Instance.appalachianColor;
        //    //cp3DeckImage.sprite = GameManager.Instance.ahTitle;
        //    cp3DeckText.text = "Appalachian Homestead";
        //}
        //else if (GameManager.Instance.computerThreeDeck == "D003")
        //{
        //    cp3Color.color = GameManager.Instance.peatBogsColor;
        //    //cp3DeckImage.sprite = GameManager.Instance.pbTitle;
        //    cp3DeckText.text = "Peat Bogs";
        //}
        //else if (GameManager.Instance.computerThreeDeck == "D004")
        //{
        //    cp3Color.color = GameManager.Instance.clarionRiverColor;
        //    //cp3DeckImage.sprite = GameManager.Instance.crTitle;
        //    cp3DeckText.text = "Clarion River";
        //}


        drawText = GameObject.Find("DrawText").GetComponent<Text>();
        drawText.text = "Please Draw 1 Card!";

        ////getting access to two of the buttons on the playerboard scene
        GameManager.Instance.endTurnButton = GameObject.Find("EndTurnButton").GetComponent<Button>();
        //GameManager.Instance.threeCardBurst = GameObject.Find("3CardBurst").GetComponent<Button>();

        //will set the initial playing field to this
        playerCG.alpha = 1f;
        playerCG.blocksRaycasts = true;
        playerCG.interactable = true;

        cp1CG.alpha = 0f;
        cp1CG.blocksRaycasts = false;
        cp1CG.interactable = false;

        cp2CG.alpha = 0f;
        cp2CG.blocksRaycasts = false;
        cp2CG.interactable = false;

        cp3CG.alpha = 0f;
        cp3CG.blocksRaycasts = false;
        cp3CG.interactable = false;

        //GameManager.Instance.cardInfoPanel.SetActive(false); //doesnt show the card info panel canvas

        //GameManager.Instance.AcidicWatersCanvas.SetActive(false); //doesnt show the acidic waters canvas
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //willgo back to the player field
    public void ShowPlayer()
    {
        //will set the initial playing field to this
        playerCG.alpha = 1f;
        playerCG.blocksRaycasts = true;
        playerCG.interactable = true;

        showPlayer.SetActive(true);

            ////if function willd etermine and show how mny cards will be drawn
            //if (GameManager.Instance.getPlayerTotalRegions() < 5)
            //{
            //    if (GameManager.Instance.playerDrawExtraCard == true)
            //    {
            //        drawText.text = "Please Draw 2 Cards!";
            //        GameManager.Instance.playerDrawCount = 2;
            //    }
            //    else
            //    {
            //        drawText.text = "Please Draw 1 Card!";
            //        GameManager.Instance.playerDrawCount = 1;
            //    }
            //}
            //else if (GameManager.Instance.getPlayerTotalRegions() < 10)
            //{
            //    if (GameManager.Instance.playerDrawExtraCard == true)
            //    {
            //        drawText.text = "Please Draw 3 Cards!";
            //        GameManager.Instance.playerDrawCount = 3;
            //    }
            //    else
            //    {
            //        drawText.text = "Please Draw 2 Cards!";
            //        GameManager.Instance.playerDrawCount = 2;
            //    }
            //}
            //else if (GameManager.Instance.getPlayerTotalRegions() < 15)
            //{
            //    if (GameManager.Instance.playerDrawExtraCard == true)
            //    {
            //        drawText.text = "Please Draw 4 Cards!";
            //        GameManager.Instance.playerDrawCount = 4;
            //    }
            //    else
            //    {
            //        drawText.text = "Please Draw 3 Cards!";
            //        GameManager.Instance.playerDrawCount = 3;
            //    }
            //}
            //else if (GameManager.Instance.getPlayerTotalRegions() < 20)
            //{
            //    if (GameManager.Instance.playerDrawExtraCard == true)
            //    {
            //        drawText.text = "Please Draw 5 Cards!";
            //        GameManager.Instance.playerDrawCount = 5;
            //    }
            //    else
            //    {
            //        drawText.text = "Please Draw 4 Cards!";
            //        GameManager.Instance.playerDrawCount = 4;
            //    }
            //}

        cp1CG.alpha = 0f;
        cp1CG.blocksRaycasts = false;
        cp1CG.interactable = false;

        showCP1.SetActive(false);

        cp2CG.alpha = 0f;
        cp2CG.blocksRaycasts = false;
        cp2CG.interactable = false;

        showCP2.SetActive(false);

        cp3CG.alpha = 0f;
        cp3CG.blocksRaycasts = false;
        cp3CG.interactable = false;

        showCP3.SetActive(false);

       // GameManager.Instance.cardInfoPanel.SetActive(false);
    }

    //will show computer board 1
    public void ShowCP1()
    {
        //will set the playing field to board 1
        playerCG.alpha = 0f;
        playerCG.blocksRaycasts = false;
        playerCG.interactable = false;

        showPlayer.SetActive(false);
        //sets the canvas group opacity to full 
        cp1CG.alpha = 1f;
        cp1CG.blocksRaycasts = true;
        cp1CG.interactable = true;

        showCP1.SetActive(true);

        if (cp1Round.text != GameManager.Instance.round.ToString()) //should set the round
            cp1Round.text = GameManager.Instance.round.ToString();

        cp2CG.alpha = 0f;
        cp2CG.blocksRaycasts = false;
        cp2CG.interactable = false;

        showCP2.SetActive(false);

        cp3CG.alpha = 0f;
        cp3CG.blocksRaycasts = false;
        cp3CG.interactable = false;

        showCP3.SetActive(false);
    }

    //will show computer board 2
    public void ShowCP2()
    {
        //will set the playing field to board 1
        playerCG.alpha = 0f;
        playerCG.blocksRaycasts = false;
        playerCG.interactable = false;

        showPlayer.SetActive(false);

        cp1CG.alpha = 0f;
        cp1CG.blocksRaycasts = false;
        cp1CG.interactable = false;

        showCP1.SetActive(false);

        cp2CG.alpha = 1f;
        cp2CG.blocksRaycasts = true;
        cp2CG.interactable = true;

        showCP2.SetActive(true);

        if (cp2Round.text != GameManager.Instance.round.ToString()) //should set the round
            cp2Round.text = GameManager.Instance.round.ToString();

        cp3CG.alpha = 0f;
        cp3CG.blocksRaycasts = false;
        cp3CG.interactable = false;

        showCP3.SetActive(false);
    }

    //willshow computer board 3
    public void ShowCP3()
    {
        //will set the playing field to board 1
        playerCG.alpha = 0f;
        playerCG.blocksRaycasts = false;
        playerCG.interactable = false;

        showPlayer.SetActive(false);

        cp1CG.alpha = 0f;
        cp1CG.blocksRaycasts = false;
        cp1CG.interactable = false;

        showCP1.SetActive(false);

        cp2CG.alpha = 0f;
        cp2CG.blocksRaycasts = false;
        cp2CG.interactable = false;

        showCP2.SetActive(false);

        cp3CG.alpha = 1f;
        cp3CG.blocksRaycasts = true;
        cp3CG.interactable = true;

        showCP3.SetActive(true);

        if (cp3Round.text != GameManager.Instance.round.ToString()) //should set the round
            cp3Round.text = GameManager.Instance.round.ToString();
    }

    public void showNone() //will only be used whenever the picking of cards from the deck is happening
    {
        //makes non of them visible
        playerCG.alpha = 0f;
        playerCG.blocksRaycasts = false;
        playerCG.interactable = false;

        showPlayer.SetActive(false);

        cp1CG.alpha = 0f;
        cp1CG.blocksRaycasts = false;
        cp1CG.interactable = false;

        showCP1.SetActive(false);

        cp2CG.alpha = 0f;
        cp2CG.blocksRaycasts = false;
        cp2CG.interactable = false;

        showCP2.SetActive(false);

        cp3CG.alpha = 0f;
        cp3CG.blocksRaycasts = false;
        cp3CG.interactable = false;

        showCP3.SetActive(false);
    }
}
