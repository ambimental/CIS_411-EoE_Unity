/*
 *  @class      phpImport
 *  @purpose    Request card information from online database and populate card list
 *  
 *  @author     John Georgvich, previous CIS411 group
 *  @date       2020-01-22
 */
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class phpImport : MonoBehaviour
{

    /// <summary>
    ///     Class object/variable declaration block
    /// </summary>
    public List<string> cardidA;
    public List<string> cardidR;
    public List<string> actions;
    public List<string> reqs;
    public string actionURL = "https://www.twosistersinthewild.com/databaseconnectionPHP/actionFetcher.php?";
    public string reqURL = "https://www.twosistersinthewild.com/databaseconnectionPHP/reqFetcher.php?";
    public string deckoneURL = "https://www.twosistersinthewild.com/databaseconnectionPHP/dataFetcher.php?deckid=d001";
    public string decktwoURL = "https://www.twosistersinthewild.com/databaseconnectionPHP/dataFetcher.php?deckid=d002";
    public string deckthreeURL = "https://www.twosistersinthewild.com/databaseconnectionPHP/dataFetcher.php?deckid=d004"; //deck three is really deck 4, they got switched in the database
    public string deckfourURL = "https://www.twosistersinthewild.com/databaseconnectionPHP/dataFetcher.php?deckid=d003"; //deck four is really deck 3, switched in the datbase
    WWW hs_get;

    public void Start()
    {
        cardidA = new List<string>();
        cardidR = new List<string>();
        actions = new List<string>();
        reqs = new List<string>();
        StartCoroutine(GetScores());
    }

    /*
     *  @name       GetScores()
     *  @purpose    Retrieve all card data from MySQL database on-site
     *  
     *  @ATTN:      use StartCoroutine when calling this function
     *  @TODO:      document function line-by-line
     */
    public IEnumerator GetScores()
    {
        hs_get = new WWW(actionURL);
        yield return hs_get;
        string[] splitAction = hs_get.text.Split("\n".ToCharArray(), StringSplitOptions.None);
        foreach (string line in splitAction)
        {
            if (line == "---")
            {
                break;
            }
            string[] splitAction2 = line.Split("|".ToCharArray(), StringSplitOptions.None);
            actions.Add(splitAction2[0]);
            cardidA.Add(splitAction2[1]);
        }
        hs_get = new WWW(reqURL);
        yield return hs_get;
        string[] splitReq = hs_get.text.Split("\n".ToCharArray(), StringSplitOptions.None);
        foreach (string line in splitReq)
        {
            if (line == "---")
            {
                break;
            }
            string[] splitReq2 = line.Split("|".ToCharArray(), StringSplitOptions.None);
            reqs.Add(splitReq2[0]);
            cardidR.Add(splitReq2[1]);
        }
        foreach (Deck deck in GameManager.Instance.Decks)
        {
            string deckid = deck.DeckId;
            if (deckid == "D001")
            {
                hs_get = new WWW(deckoneURL);
            }
            else if (deckid == "D002")
            {
                hs_get = new WWW(decktwoURL);
            }
            else if (deckid == "D003")
            {
                hs_get = new WWW(deckthreeURL);
            }
            else if (deckid == "D004")
            {
                hs_get = new WWW(deckfourURL);
            }
            yield return hs_get;
            string[] temp = hs_get.text.Split("\n".ToCharArray(), StringSplitOptions.None);
            foreach (string line in temp)
            {
                if (line == "---")
                {
                    break;
                }
                string[] temp2 = line.Split("|".ToCharArray(), StringSplitOptions.None);
                Card card = new Card();
                card.CardID = temp2[0];
                card.CardName = temp2[1];
                card.CardType = temp2[2];
                card.PointValue = int.Parse(temp2[3]);
                card.Kingdom = temp2[4];
                card.Subkingdom = temp2[5];
                card.Superphylum = temp2[6];
                card.Phylum = temp2[8];
                card.Subphylum = temp2[9];
                card.Superclass = temp2[10];
                card.CardClass = temp2[11];
                card.Subclass = temp2[12];
                card.Superorder = temp2[13];
                card.Order = temp2[14];
                card.Suborder = temp2[15];
                card.Superfamily = temp2[16];
                card.Family = temp2[17];
                card.Subfamily = temp2[18];
                card.Supergenus = temp2[19];
                card.Genus = temp2[20];
                card.Subgenus = temp2[21];
                card.Superspecies = temp2[22];
                card.Species = temp2[23];
                card.Subspecies = temp2[24];
                card.AnimalSize = temp2[25];
                card.AnimalEnvironment = temp2[26];
                card.AnimalDiet = temp2[27];
                card.PlantType = temp2[28];
                card.RegionType = temp2[29];
                card.Domain = temp2[30];
                card.Infraclass = temp2[31];
                card.Infraorder = temp2[32];
                card.Section = temp2[33];
                card.Tribe = temp2[34];
                card.Division = temp2[35];
                card.Superdivision = temp2[36];
                card.Subdivision = temp2[37];
                card.Fungi_type = temp2[38];
                card.StandingAction = temp2[39].ToString();
                card.SpecialAction = temp2[40].ToString();
                card.CardNotes = temp2[41];

                deck.Cards.Add(card);
            }
            foreach(Card card in deck.Cards)
            {
                for(int i = 0; i<actions.Count; i++)
                {
                    if (card.CardID == cardidA[i])
                    {
                        card.ActionID.Add(actions[i]);
                    }
                }
                for (int i = 0; i<reqs.Count; i++)
                {
                    if (card.CardID == cardidR[i])
                    {
                        card.ReqID.Add(reqs[i]);
                    }
                }
            }
        }
    }  
}