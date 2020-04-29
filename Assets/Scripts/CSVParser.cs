/*
 *  @class      CSVParser
 *  @purpose    Request card information from locally-stored CSV files and populate card list
 *  
 *  @author     John Georgvich
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVParser
{
    private string actionPath, requirementPath, deckOnePath, deckTwoPath, deckThreePath, deckFourPath; 
    
    public void loadFiles()
    {
        this.actionPath = "Assets/Resources/Data/Actions.csv";
        this.requirementPath = "Assets/Resources/Data/Requirements.csv";
        this.deckOnePath = "Assets/Resources/Data/DeckOne.csv";
        this.deckTwoPath = "Assets/Resources/Data/DeckTwo.csv";
        this.deckThreePath = "Assets/Resources/Data/DeckThree.csv";
        this.deckFourPath = "Assets/Resources/Data/DeckFour.csv";
    }

    public List<string[]> parseRequirements()
    {
        List<string[]> requirementIDs = new List<string[]>();
        using (var parser = new StreamReader(this.requirementPath))
        {
            while (!parser.EndOfStream)
            {
                var line = parser.ReadLine();
                string[] requirementCard = line.Split(',');
                requirementIDs.Add(requirementCard);
            }
        }

        return requirementIDs;
    }

    public List<string[]> parseActionIDs()
    {
        List<string[]> actionIDs = new List<string[]>();
        using (var parser = new StreamReader(this.actionPath))
        {
            while (!parser.EndOfStream)
            {
                var line = parser.ReadLine();
                string[] actionCard = line.Split(',');
                actionIDs.Add(actionCard);
            }
        }

        return actionIDs;
    }

    public Deck deckParse(string deckPath, List<string[]> actionList, List<string[]> requirementList)
    {
        Deck parsedDeck = new Deck();

        using (var parser = new StreamReader(deckPath))
        {
            while (!parser.EndOfStream)
            {
                var line = parser.ReadLine();
                Card tempCard = new Card(line.Split(','));
                parsedDeck.Cards.Add(tempCard);
            }
        }

        foreach(Card card in parsedDeck.Cards)
        {
            for(int i = 0; i < actionList.Count; i++)
            {
                string[] actionArray = actionList[i];
                string actionID = actionArray[0];
                string cardID = actionArray[1];

                if(card.CardID == cardID)
                {
                    card.ActionID.Add(actionID);
                }
            }
            for(int i = 0; i < requirementList.Count; i++)
            {
                string[] requirementArray = requirementList[i];
                string requirementID = requirementArray[0];
                string cardID = requirementArray[1];

                if(card.CardID == cardID)
                {
                    card.reqID.Add(requirementID);
                }
            }
        }

        return parsedDeck;
    }

    public List<Deck> GetDecks(List<string[]> actionList, List<string[]> requirementList)
    {
        List<Deck> parsedDecks = new List<Deck>();
        string[] deckPaths = new string[] { deckOnePath, deckTwoPath, deckThreePath, deckFourPath };

        foreach(string deckPath in deckPaths)
        {
            parsedDecks.Add(deckParse(deckPath, actionList, requirementList));
        }

        return parsedDecks;
    }
}
