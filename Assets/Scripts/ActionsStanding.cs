// THIS SCRIPT WILL BE USED TO MAKE THE STANDING ACTIONS WORK - NEEDED TO SEPERATE THE STANDING FROM THE SPECIAL

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ActionsStanding : MonoBehaviour
{

    //public bool requirementsWork = false; //determines whether or not the requirements will work

    // Use this for initialization
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    //will determine if the card has a standing action and wether or not it can be executed
    //public void checkStandingAction(Card card)
    //{
    //    List<string> standingActions = new List<string>(); //stores the action ids

    //    foreach (string x in card.ActionID)
    //    {
    //        string actionId = x;
    //        standingActions.Add(actionId);
    //    }

    //    foreach (string x in standingActions)
    //    {
    //        Type type = typeof(StandingActions);
    //        StandingActions ClassObject = new StandingActions();
    //        MethodInfo method = type.GetMethod(x);
    //        method.Invoke(ClassObject, null);
    //    }
    //}

    //public class StandingActions //where the standing actions will be executed
    //{
    //    Biologist
    //    public void a001() //Standing Action: While the biologist is in play, the ecosystem is protected from Invasive Animal Species. Discard after use.
    //    {
    //        CANT BE DONE UNTIL MULTIPLAYER CARDS

    //        will be used to protect the player from invasive animals
    //        GameManager.Instance.playerProtectedFromInvasiveAnimal = true;
    //    }

    //    Human - Botanist
    //    public void a003() //Standing Action: While the Botanist is in play, the ecosystem is protected from one Invasive Plant species.  Discard after use
    //    {
    //        CANT BE DONE UNTIL MULTIPLAYER CARDS

    //        will protect the player from one invasive species
    //        GameManager.Instance.playerProtectedFromInvasivePlant = true;
    //    }

    //    Human - Explorer
    //    public void a005() //Standing Action: While the Explorer is in play, the ecosystem can play Condition cards without meeting the conditions requirements
    //    {
    //        will allow theuser to play condition cards without the requirements
    //        GameManager.Instance.playerNoConditionRequirements = true;
    //    }

    //    Human - Ranger
    //    public void a007() //Standing Action: While the Ranger is in play, the ecosystem is protected from Blight. Discard if Blight is used.
    //    {
    //        CANT BE DONE UNTIL MULTIPLAYER CARDS ARE DONE


    //        GameManager.Instance.playerProtectedFromBlight = true;
    //    }

    //    Human - Two Sisters in the Wild
    //    public void a009() //Standing Action: While Two Sisters in the Wild is in play, your ecosystem is protected from Extinction
    //    {
    //        CANT BE DONE UNTIL MULTIPLAYERS ARE DONE

    //        GameManager.Instance.playerProtectedFromExtinction = true; //player will be protected from exitinction while this is true
    //    }

    //    Human - Grandma Moore
    //    public void a016() //Standing Action: When Grandma Moore is in play, you no longer need to discard at the end of your turn
    //    {
    //        GameManager.Instance.playerNoDiscard = true; //player no longer has to discard

    //        GameManager.Instance.enableTurnButton(); //enables the turn button
    //    }

    //    Human - Grandma Strohm
    //    public void a017() //Standing Action: While Grandma Strohm is in play, draw an extra card at the beginning of your turn
    //    {
    //        GameManager.Instance.playerDrawExtraCard = true; //player can now draw an extra card at the beginning of the round
    //    }

    //    Human - Grandpa Strohm
    //    public void a018() //Standing Action: While in play, Grandpa Strohm just watches everything happen.
    //    {
    //        nothing goes here
    //    }

    //    Human - Conservation Engineer
    //    public void a024() //Standing Action: While the Conservation Engineer is in play, you can keep one 20+ point card in your hand and not have to discard it
    //    {
    //        GameManager.Instance.playerTwentyPointNoDiscard = true; //player can keep one twenty point card in their hand 
    //    }

    //    Human - Entomologist
    //    public void a026() //Standing Action: While the Entomologist is in play, the ecosystem is protected from one invasive invertebrate.  Discard after use
    //    {
    //        CANT BE DONE UNTIL MULTIPLAYER CARDS ARE DONE

    //        GameManager.Instance.playerProtectedFromInvertebrate = true; //player is protected from invaive invertebrate
    //    }

    //    Special Regions - Farmers Cove
    //    public void a035() // Farmer’s Cove provides: 1 Grassland region and 1 Running Water region.
    //    {
    //        GameManager.Instance.playerGrasslandsCount++;
    //        GameManager.Instance.playerRunningWaterCount++;
    //    }

    //    Special Region - The Strohmstead
    //    public void a036() //The Strohmstead provides: 1 Forest region, 1 Grasslands region, 1 Standing Water region, and 1 Running water region
    //    {
    //        GameManager.Instance.playerForestCount++;
    //        GameManager.Instance.playerGrasslandsCount++;
    //        GameManager.Instance.playerStandingWaterCount++;
    //        GameManager.Instance.playerRunningWaterCount++;
    //    }

    //    Special Region - Hunters Ridge
    //    public void a037() //Hunter’s Ridge provides: 1 Forest region and 1 Grassland region.
    //    {
    //        GameManager.Instance.playerForestCount++;
    //        GameManager.Instance.playerGrasslandsCount++;

    //        Debug.Log(GameManager.Instance.getPlayerTotalRegions());
    //    }

    //    Animal - Domesticated Cat
    //    public void a039() //If no humans are in play within your ecosystem, Domesticated Cat will move to the player on the right.  Repeat this action until it finds an ecosystem with a human.  if no humans are in play, discard domesticated cat
    //    {
    //        ???????????????????????
    //    }

    //    Animal - Domesticated Chicken
    //    public void a040() //Domesticated Chicken cannot migrate and is human-dependant. Discard if no humans are in play within your ecosystem
    //    {
    //        ????????????????????????????????????????????/
    //    }

    //    Animal - Domesticated Dog
    //    public void a041() //Domesticated Dog will remain in play for three additional rounds without a human. If no humans are in play at the end of the third round, discard domdesticated dog.
    //    {
    //        ????????????????????????????????????????????????????????????????????????
    //    }

    //    Invertebrate - Goldenrod Soldier Beetle
    //    public void a042() //If Goldenrod is played, Goldenrod Soldier Beetle can be played directly from the deck or discard pile at the beginning of the next round
    //    {

    //    }

    //    Plant - Alfalfa
    //    public void a043() //The round after Alfalfa is played, a Tiny or Small Invertebrate can be played from the deck or discard pile
    //    {

    //    }

    //    Plant - Common Dandelion
    //    public void a044() //Common Dandelion is immune to Invasive Plant Species. It cannot be discarded or relocated once played
    //    {
    //        description not finished 
    //    }

    //    Plant - Orange Hawkweed
    //    public void a045() //The round after Orange Hawkweed is played, a fly from the Genus: Musca can be played directly from the deck or discard pile
    //    {
    //        description not finished but im pretty sure i know whats going one
    //    }

    //    Microbe - Spirulina Algae
    //    public void a048() //Spirulina Algae also counts as a Groundcover Plant.
    //    {
    //        for (int i = 0; i < GameManager.Instance.MicrobePlacement.Count; i++) //goes through the microbe placement list
    //        {
    //            if (GameManager.Instance.MicrobePlacement[i].CardName == "Microbe-Spirulina-Algae") //if the correct card is here, sets the plant type to groundcover
    //                GameManager.Instance.MicrobePlacement[i].PlantType = "Groundcover";
    //        }
    //    }

    //    Plant - White Birch
    //    public void a049() //White Birch can be played directly from the deck or discard pile if your ecosystem is affected by Forest fire
    //    {
    //        ?????????????????????
    //    }

    //    Special Region - Animal Sanctuary
    //    public void a050() //Animal Sanctuary can support any 1 Animal species, regardless of its requirements.
    //    {
    //        does this mean you can pt down any card or what im not really sure
    //    }

    //    Human - Biologist
    //    public void a002() //Special Action: Locate and play one animal from the deck or discard pile. Discard after use.
    //    {
    //    }

    //    Human - Botanist
    //    public void a004() //Special Action: Locate and play one Plant from the deck or discard pile. Discard after use.
    //    {
    //    }

    //    Human - Explorer
    //    public void a006() //Special Action: Locate and play one Condition card from the deck or discard pile. Discard after use.
    //    {
    //    }

    //    Human - Ranger 
    //    public void a008() //Special Action: The Ranger can be used to remove the Man-Eater multi-player card from play without removing the species it is played on.  Discard ranger and Man-eater cards if used in this way
    //    {
    //    }

    //    Human - Two Sisters in the Wild
    //    public void a010() //Special Action: If Two Sisters in the Wild is discarded, all players draw three cards
    //    {
    //    }

    //    Multiplayer - Acidic Waters
    //    public void a011() //Actions: When played, up to three Running, Standing or Salt Water regions can be stacked in one pile with acidic waters on top.  These regions are no longer able to sustain life while acidic waters is in play
    //    {
    //    }

    //    Multiplayer - Children at Play
    //    public void a012() //Actions: All actions within one player's ecosystem are paused for one turn.
    //    {
    //    }

    //    Multipayer - Extinction
    //    public void a013() //Actions: One Species is now extinct. All players remove any copies of this Species from the game.
    //    {
    //    }

    //    Multiplayer - Isolated Ecosystems
    //    public void a014() //Actions: While Isolated Ecosystem is in play, this player’s ecosystem is not affected by Web of Life or other cards with standing actions that affect more than one ecosystem
    //    {
    //    }

    //    Multiplayer - Temperature Drop
    //    public void a015() //Actions: Discard Temperature Drop directly from your hand. All actions within one player’s ecosystem are paused for one turn
    //    {
    //    }

    //    Human - Grandpa Strohm
    //    public void a019() //Special Action: Grandpa Strohm can be used to locate and play any one card from your deck or discard pile. if used this way remove grandpa strohm from the game
    //    {
    //    }

    //    Multiplayer - Blight
    //    public void a020() //Actions: Play on one Plant card. Discard affected Plant card and Blight card at the end of the affected players next turn.
    //    {
    //    }

    //    Multiplayer - Ideal Conditions
    //    public void a021() //Actions: Discard Ideal Conditions from your hand directly to the discard pile. All players draw three cards
    //    {
    //    }

    //    Multiplayer - Invasive Invertebrate Species
    //    public void a022() //Actions: Play on one Invertebrate card. That card is now an Invasive Species. At the end of the affected players turn discard one invertebrate from play that is not affected by the invasive invertebrate species card.  Continue this prpcess until the card affected by the invasive invertebrate is the only invertebrate card in the ecosystem
    //    {
    //    }

    //    Multiplayer - Web of Life
    //    public void a023() //Actions: All players’ ecosystems are now connected. What affects one affects them all including standing actions effects from multiplayer cards and human cards.  Discard but after the last round ends
    //    {
    //    }

    //    Human - Conservation Engineer
    //    public void a025() //Special Action: Locate and play one 20 point or greater card from the deck or discard pile. Discard after use.
    //    {
    //    }

    //    Human - Entomologist
    //    public void a027() //Special Action: Locate and play one invertebrate from the deck or discard pile. Discard after use.
    //    {
    //    }

    //    Multiplayer - Relocate Species
    //    public void a028() //Actions: Move one non-human Species in play to another ecosystem. Place Relocate Species behind the relocated card.
    //    {
    //    }

    //    Multiplayer - Forest Fire
    //    public void a029() //Actions: When played, up to three Forest regions are stacked in one pile with Forest Fire placed on top.  These regions are no longer forests while forest fire is in play.  Treat these regions as grasslands.  Discard Forest fire if all affected regions are no longer in play
    //    {
    //    }

    //    Animal - Barred Owl - I believe this is what is considered an invasive animal - unless its a multiplayer card??
    //    public void a030() //If three Canopy Plants and two Tiny or Small Animals are in play, Barred Owl can be played directly from the deck or discard pile
    //    {
    //    }

    //    Plant - Allegheny Blackberry
    //    public void a031() //When Allegheny Blackberry is played, also place one playable Understory or Canopy Plant from your deck or discard pile directly into play
    //    {
    //    }

    //    Plant - Bigtooth Aspen
    //    public void a032() //Bigtooth Aspen can be played directly from the deck or discard pile if your ecosystem is affected by forest fire
    //    {
    //    }

    //    Plant - Eastern White Pine
    //    public void a033() //When Eastern White Pine is played, an herbivore can be played directly from the deck or discard pile 
    //    {
    //    }

    //    Plant - White Birch
    //    public void a034() //White Birch can be played directly from the deck or discard pile if your ecosystem is affected by Forest fire
    //    {
    //    }

    //    Animal - Black Rat Snake - Invasive animal species???
    //    public void a038() //If two Animals from the Order: Rodentia are in play, Black Rat Snake can be placed directly into play from the deck or the discard pile if its requirements are met
    //    {
    //    }

    //    Invertebrate - Globe Skimmer Dragonfly
    //    public void a046() //At the beginning of your turn, Globe Skimmer moves from its current ecosystem to the ecosystem on its right, even if the ecosystem doesn't meet the globe skimeer's requirements
    //    {
    //    }

    //    Microbe - Iron Bacteria
    //    public void a047() //Iron Bacteria neutralizes the effect of Acidic Waters.
    //    {
    //    }

    //    Animal - Barn Owl
    //    public void a051() //If two animals from the class mammalia are in play, Barn Owl can be played directly from the deck or discard pile at the beginning of your next turn
    //    {
    //    }
    //}
}
