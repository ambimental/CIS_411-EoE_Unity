//THIS SCRIPT WILL BE USED TO TAKE THE USER BACK TO THE MAIN PAGE OF THE WEB SITE OR TO THE STORE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour {

    //will open the store web page
    public void OpenStore()
    {
        if (GameManager.Instance.deckPicked == "D001")
        {
            Application.OpenURL("https://squareup.com/store/twosistersinthewild/item/allegheny-national-forest-starter-deck");
        }
        else if (GameManager.Instance.deckPicked == "D002")
        {
            Application.OpenURL("https://squareup.com/store/twosistersinthewild/item/appalachian-homestead-starter-deck");
        }
        else if (GameManager.Instance.deckPicked == "D003")
        {
            Application.OpenURL("https://squareup.com/store/twosistersinthewild/item/peat-bogs-of-the-allegheny-front-starter-deck");
        }
        else if (GameManager.Instance.deckPicked == "D004")
        {
            Application.OpenURL("https://squareup.com/store/twosistersinthewild/item/clarion-river-starter-deck");
        }

        Application.Quit(); //just closes the application
    }

    //opens coreect store page based on decks
    public void AlleghenyBuy()
    {
        Application.OpenURL("https://squareup.com/store/twosistersinthewild/item/allegheny-national-forest-starter-deck");
        Application.Quit();
    }
    public void AppalachianBuy()
    {
        Application.OpenURL("https://squareup.com/store/twosistersinthewild/item/appalachian-homestead-starter-deck");
        Application.Quit();
    }

    public void PeatBogsBuy()
    {
        Application.OpenURL("https://squareup.com/store/twosistersinthewild/item/peat-bogs-of-the-allegheny-front-starter-deck");
        Application.Quit();
    }

    public void ClarionRiverBuy()
    {
        Application.OpenURL("https://squareup.com/store/twosistersinthewild/item/clarion-river-starter-deck");
        Application.Quit();
    }



    //will open the web home page
    public void OpenHomePage()
    {
        Application.OpenURL("https://www.twosistersinthewild.com/");
        Application.Quit(); //just closes the application
    }

    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/pg/twosistersinthewild/reviews/?ref=page_internal");
        Application.Quit(); //just closes the application
    }

    public void CloseApplication() //to lcose the application - i put it in here because it was just easier to get access to since the buttons are already connected to this script
    {
        Application.Quit(); //closes
    }

    //this bit of code is for the thank you scene to take player to store
    public void EndOpenStore()
    {
        Application.OpenURL("https://squareup.com/store/twosistersinthewild/");
        Application.Quit();
    }
}
