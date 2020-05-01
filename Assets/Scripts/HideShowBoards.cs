/*
 *  @class      HideShowBoard.cs
 *  @purpose    makes each canvas visible depending on function
 *  
 *  @author     CIS 411
 *  @date       2020/04/07
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideShowBoards : MonoBehaviour {

    //these are to change the position in canvas group to bring to front of canvas to be seen
    private CanvasGroup personCG;
    private CanvasGroup cp1CG;
    private CanvasGroup cp2CG;
    private CanvasGroup cp3CG;
    private CanvasGroup pauseCG;
    private CanvasGroup showDeckDiscardCG;
    private CanvasGroup cardInfoPanelCG;
    private CanvasGroup acidicWatersCG;
    private CanvasGroup learnToPlayCG;

    //these set the canvas active so they can be seen
    private GameObject showPerson; //for showin the player and cp boards
    private GameObject showCP1;
    private GameObject showCP2;
    private GameObject showCP3;
    private GameObject showPause;
    private GameObject showDeckDiscard;
    private GameObject showCardInfoPanel;
    private GameObject showAcidicWaters;
    private GameObject showLearnToPlay;

        /*
     * @name    Start
     * @purpose Initializes objects
     * 
     * @return  Void
     */
    void Start() {

        //Initializes all objects to the appropriate canvas groups
        PersonCG = GameObject.Find("Player Board").GetComponent<CanvasGroup>();      
        Cp1CG = GameObject.Find("CP1 Board").GetComponent<CanvasGroup>();
        Cp2CG = GameObject.Find("CP2 Board").GetComponent<CanvasGroup>();
        Cp3CG = GameObject.Find("CP3 Board").GetComponent<CanvasGroup>();
        PauseCG = GameObject.Find("Pause").GetComponent<CanvasGroup>();
        ShowDeckDiscardCG = GameObject.Find("ShowDeckDiscard").GetComponent<CanvasGroup>();
        CardInfoPanelCG = GameObject.Find("CardInfoPanel").GetComponent<CanvasGroup>();
        AcidicWatersCG = GameObject.Find("AcidicWatersChoiceCanvas").GetComponent<CanvasGroup>();
        LearnToPlayCG = GameObject.Find("LearnToPlay").GetComponent<CanvasGroup>();
        //instializes objects to the appropriate canvas
        ShowPerson = GameObject.Find("Player");
        ShowCP11 = GameObject.Find("CP1 Board");
        ShowCP21 = GameObject.Find("CP2 Board");
        ShowCP31 = GameObject.Find("CP3 Board");
        ShowPause1 = GameObject.Find("Pause"); 
        ShowDeckDiscard1 = GameObject.Find("ShowDeckDiscard"); 
        ShowCardInfoPanel = GameObject.Find("CardInfoPanel"); 
        ShowAcidicWaters1 = GameObject.Find("AcidicWatersChoiceCanvas"); 
        ShowLearnToPlay1 = GameObject.Find("LearnToPlay"); 
    }

       /*
     * @name    ShowPlayer, ShowCP1, ShowCP2, ShowCP3, S
     * @purpose disables and all canvases and shows the correct one based off of wich method
     * 
     * @return  Void
     */
     //shows person player
    public void ShowPlayer()
    {
        ShowNone();
        PersonCG.alpha = 1f;
        PersonCG.blocksRaycasts = true;
        PersonCG.interactable = true;
        ShowPerson.SetActive(true);      
    }

    //will show computer board 1
    public void ShowCP1()
    {
        ShowNone();
        Cp1CG.alpha = 1f;
        Cp1CG.blocksRaycasts = true;
        Cp1CG.interactable = true;
        ShowCP11.SetActive(true);
    }

    //will show computer board 2
    public void ShowCP2()
    {
        ShowNone();
        Cp2CG.alpha = 1f;
        Cp2CG.blocksRaycasts = true;
        Cp2CG.interactable = true;
        ShowCP21.SetActive(true);
    }

    //will show computer board 3
    public void ShowCP3()
    {
        ShowNone();
        Cp3CG.alpha = 1f;
        Cp3CG.blocksRaycasts = true;
        Cp3CG.interactable = true;
        ShowCP31.SetActive(true);
    }

    //will show pause menu
    public void ShowPause()
    {
        ShowNone();   
        PauseCG.alpha = 1f;
        PauseCG.blocksRaycasts = true;
        PauseCG.interactable = true;
        ShowPause1.SetActive(true);
    }

    //will show deck discard
    //in this current version of the game this is never used
    public void ShowDeckDiscard()
    {
        ShowNone();
        ShowDeckDiscardCG.alpha = 1f;
        ShowDeckDiscardCG.blocksRaycasts = true;
        ShowDeckDiscardCG.interactable = true;
        ShowDeckDiscard1.SetActive(true);
    }

    //will show card info
    //this is different than the others becasue we need the cnvas that is worked on to still be active so the 
    //hover class zoom goes back to normal
    public void ShowCardInfo()
    {
        //this is set to 2 so it is in fron of the previously active canvas
        CardInfoPanelCG.alpha = 2f;
        CardInfoPanelCG.blocksRaycasts = true;
        CardInfoPanelCG.interactable = true;
        ShowCardInfoPanel.SetActive(true);
    }

    //will show acidic waters
    public void ShowAcidicWaters()
    {
        ShowNone();
        AcidicWatersCG.alpha = 1f;
        AcidicWatersCG.blocksRaycasts = true;
        AcidicWatersCG.interactable = true;
        ShowAcidicWaters1.SetActive(true);
    }

    //will show learn to play
    public void ShowLearnToPlay()
    {
        ShowNone();
        LearnToPlayCG.alpha = 1f;
        LearnToPlayCG.blocksRaycasts = true;
        LearnToPlayCG.interactable = true;
        ShowLearnToPlay1.SetActive(true);
    }

    //will show none
    public void ShowNone() //disables all canvases
    {
        //disables person
        PersonCG.alpha = 0f;
        PersonCG.blocksRaycasts = false;
        PersonCG.interactable = false;
        ShowPerson.SetActive(false);

        //disables CP1
        Cp1CG.alpha = 0f;
        Cp1CG.blocksRaycasts = false;
        Cp1CG.interactable = false;
        ShowCP11.SetActive(false);

        //disables cp2
        Cp2CG.alpha = 0f;
        Cp2CG.blocksRaycasts = false;
        Cp2CG.interactable = false;
        ShowCP21.SetActive(false);

        //disables cp3
        Cp3CG.alpha = 0f;
        Cp3CG.blocksRaycasts = false;
        Cp3CG.interactable = false;
        ShowCP31.SetActive(false);

        //disables pause
        PauseCG.alpha = 0f;
        PauseCG.blocksRaycasts = false;
        PauseCG.interactable = false;
        ShowPause1.SetActive(false);

        //disables deck discard
        ShowDeckDiscardCG.alpha = 0f;
        ShowDeckDiscardCG.blocksRaycasts = false;
        ShowDeckDiscardCG.interactable = false;
        ShowDeckDiscard1.SetActive(false);

        //disables card info panel
        CardInfoPanelCG.alpha = 0f;
        CardInfoPanelCG.blocksRaycasts = false;
        CardInfoPanelCG.interactable = false;
        ShowCardInfoPanel.SetActive(false);

        //disables acidic waters 
        AcidicWatersCG.alpha = 0f;
        AcidicWatersCG.blocksRaycasts = false;
        AcidicWatersCG.interactable = false;
        ShowAcidicWaters1.SetActive(false);

        //disables learn to play
        LearnToPlayCG.alpha = 0f;
        LearnToPlayCG.blocksRaycasts = false;
        LearnToPlayCG.interactable = false;
        ShowLearnToPlay1.SetActive(false);

    }

    //accessors and mutators
    public CanvasGroup PersonCG { get => personCG; set => personCG = value; }
    public CanvasGroup Cp1CG { get => cp1CG; set => cp1CG = value; }
    public CanvasGroup Cp2CG { get => cp2CG; set => cp2CG = value; }
    public CanvasGroup Cp3CG { get => cp3CG; set => cp3CG = value; }
    public CanvasGroup PauseCG { get => pauseCG; set => pauseCG = value; }
    public CanvasGroup ShowDeckDiscardCG { get => showDeckDiscardCG; set => showDeckDiscardCG = value; }
    public CanvasGroup CardInfoPanelCG { get => cardInfoPanelCG; set => cardInfoPanelCG = value; }
    public CanvasGroup AcidicWatersCG { get => acidicWatersCG; set => acidicWatersCG = value; }
    public CanvasGroup LearnToPlayCG { get => learnToPlayCG; set => learnToPlayCG = value; }
    public GameObject ShowPerson { get => showPerson; set => showPerson = value; }
    public GameObject ShowCP11 { get => showCP1; set => showCP1 = value; }
    public GameObject ShowCP21 { get => showCP2; set => showCP2 = value; }
    public GameObject ShowCP31 { get => showCP3; set => showCP3 = value; }
    public GameObject ShowPause1 { get => showPause; set => showPause = value; }
    public GameObject ShowDeckDiscard1 { get => showDeckDiscard; set => showDeckDiscard = value; }
    public GameObject ShowCardInfoPanel { get => showCardInfoPanel; set => showCardInfoPanel = value; }
    public GameObject ShowAcidicWaters1 { get => showAcidicWaters; set => showAcidicWaters = value; }
    public GameObject ShowLearnToPlay1 { get => showLearnToPlay; set => showLearnToPlay = value; }
}
