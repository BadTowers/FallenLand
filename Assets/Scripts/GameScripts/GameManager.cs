﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private List<SpoilsCard> spoilsDeck = new List<SpoilsCard>();
	private List<SpoilsCard> discardSpoilsDeck = new List<SpoilsCard>();
	private List<CharacterCard> characterDeck = new List<CharacterCard>();
	private List<CharacterCard> discardCharacterDeck = new List<CharacterCard>();
	private List<ActionCard> actionDeck = new List<ActionCard>();
	private List<ActionCard> discardActionDeck = new List<ActionCard>();
	public GameObject cardPrefab;
	private int numHumanPlayers;
	private int numComputerPlayers;
	private GameInformation.GameModes gameMode;
	private List<GameInformation.GameModifier> modifiers = new List<GameInformation.GameModifier>();
	private GameInformation.SoloII soloIIDifficulty;
	private List<Player> players = new List<Player>();
	private int startingActionCards = 3;
	private int startingCharacterCards = 6;
	private int startingSpoilsCards = 10;
	private int maxActionCards = 7;
	private int maxCharacterCards = -1;
	private int maxSpoilsCards = -1;
	private List<TownTech> techs;
	private Dictionary<TownTech, int> techsUsed;
	private int maxOfEachTech = 5;
    private int startingSalvage = 10;

	void Start(){
		//Get the game object from the main menu that knows the game mode, all the modifiers, and the factions picked
		GameObject newGameState = GameObject.Find("GameCreation");

		//Debug.Log(newGameState.GetComponent<GameCreation>().gameMode); //Debug thingy

		if (newGameState != null) {
			//Mark as read so the game object can be deleted
			newGameState.GetComponent<GameCreation> ().wasRead = true;

            //Debug.Log(newGameState.GetComponent<GameCreation>().faction); //Debug thingy

            //Grab the game mode
            extractGameModeFromGameCreationObject(newGameState);

            //Grab the faction (TODO change this to grab a dictionary of factions and who is each faction)
            Faction faction = newGameState.GetComponent<GameCreation>().getFaction();

			//Extract the Solo II difficulty if needed
			if(gameMode == GameInformation.GameModes.SoloII) {
				soloIIDifficulty = newGameState.GetComponent<GameCreation>().soloIIDifficulty;
			}

			//Set the number of human and computer players TODO change this to be passed in from GameCreation object
			numHumanPlayers = GameInformation.getHumanPlayerCount(gameMode);
            numComputerPlayers = GameInformation.getComputerPlayerCount(gameMode);

			//Add the players to the list (TODO: Change so later these are added in the order players will go (after dice roll or something))
			for(int i = 0; i < numHumanPlayers; i++) {
				players.Add(new HumanPlayer(faction, startingSalvage));
			}
			for(int i = 0; i < numComputerPlayers; i++) {
				//players.Add(new ComputerPlayer(startingSalvage)); //TODO reaccount for when doing a true single player game, not a solo variant
			}

			//Interpret any modifiers
			//TODO


		} else {
            //TODO handle this better probably
			Debug.Log ("Game info not received from game setup.");
			players.Add(new HumanPlayer(new DefaultFactionInfo().GetDefaultFactionList()[0], startingSalvage));
		}


		//Create the map layout according to the game state that was passed in
		GameObject mapCreationGO = GameObject.Find("Map");
		MapCreation mapCreation = mapCreationGO.GetComponent<MapCreation>();
		mapCreation.ml = new DefaultMapLayout(); //For now, just do the default. Can be modified later. TODO account for modifiers
		mapCreation.createMap();


		spoilsDeck = (new DefaultSpoilsCards()).GetSpoilsCards();
		spoilsDeck = Card.ShuffleDeck(spoilsDeck);

		characterDeck = (new DefaultCharacterCards()).GetCharacterCards();
		characterDeck = Card.ShuffleDeck(characterDeck);

		actionDeck = (new DefaultActionCards()).GetActionCards();
		actionDeck = Card.ShuffleDeck(actionDeck);


		//TODO create the deck of mission cards


		//TODO create the deck of plains cards


		//TODO create the deck of mountain cards


		//TODO create the deck of city/rad cards


		//TODO deal cards to player(s)
		//Spoils
		for(int i = 0; i < startingSpoilsCards; i++) {
			for(int j = 0; j < players.Count; j++) {
				players[j].AddSpoilsCardToAuctionHouse(spoilsDeck[0]); //Add the first card to the next player's hand
				Debug.Log("Dealt card " + spoilsDeck[0].GetTitle());
				spoilsDeck.RemoveAt(0); //Remove that card from the deck of cards
			}
		}
		//Character
		for(int i = 0; i < startingCharacterCards; i++) {
			for(int j = 0; j < players.Count; j++) {
				players[j].AddCharacterCardToTownRoster(characterDeck[0]);
				Debug.Log("Dealt card " + characterDeck[0].GetTitle());
				characterDeck.RemoveAt(0);
			}
		}
		//Action
		for(int i = 0; i < startingActionCards; i++) {
			for(int j = 0; j < players.Count; j++) {
				players[j].AddActionCardToHand(actionDeck[0]);
				Debug.Log("Dealt card " + actionDeck[0].GetTitle());
				actionDeck.RemoveAt(0);
			}
		}

        //Count how many town techs are assigned to begin
        techs = (new DefaultTownTechs()).GetDefaultTownTechList();
		techsUsed = new Dictionary<TownTech, int>();
        foreach (TownTech tt in techs)
		{
			techsUsed[tt] = 0; //Init all town techs to 0 currently used
        }
        foreach (Player p in players)
		{
            foreach (TownTech tt in p.GetTownTechs())
			{
                //For each town tech for each player, count it
                techsUsed[tt]++;
            }
        }
  	}


	void Update()
	{

	}



    /*****Some public interface functions for the GUI to attach to*******/
    public List<TownTech> GetTownTechs(int playerId)
	{
        return players[playerId].GetTownTechs();
    }

    public int GetSalvage(int playerId)
	{
        return players[playerId].GetSalvageAmount();
    }

    public Faction GetFaction(int playerId)
	{
        return players[playerId].GetPlayerFaction();
    }

	public List<SpoilsCard> GetAuctionHouse(int playerId)
	{
		return players[playerId].GetAuctionHouseCards();
	}

	public List<ActionCard> GetActionCards(int playerId)
	{
		return players[playerId].GetActionCards();
	}

	public List<CharacterCard> GetActiveCharacterCards(int playerId)
	{
		return players[playerId].GetActiveCharacters();
	}

	public List<CharacterCard> GetTownRoster(int playerId)
	{
		return players[playerId].GetTownRoster();
	}




	/******Some private helper functions******/
	private void extractGameModeFromGameCreationObject(GameObject newGameState)
	{
        gameMode = newGameState.GetComponent<GameCreation>().getMode();
    }





    /*
     *
     * THOUGHTS ON GAME MANAGER AND GAME UI MANAGER INTERACTION
     *
     * ENUM CLASS
     *      Would contain reasons for why something could not be returned
     *      If you want to view action cards of another player, this would return that those are private
     *          Perhaps request to view them has to be granted by another player
     *
     * SINGLE PLAYER
     *      Give the GameUIManager the list of player IDs
     *      Inform the GameUIManager which player it is
     *          Useful for requesting to view info of a different player
     *          For single player with one human player, it would be the only human
     *          If I want to see another player's auction house, that would be allowed
     *          If I want to see another player's town roster, that would not be allowed
     *              The GameManager would inform the GameUIManager with an enum why it wasn't allowed to see it
     *              For the town roster, it would return that this must be shared with the player (since it is hidden by default)
     *              The UI could then show in the UI why it cannot view the information so the player can fulfil requirements to do so
     *
     * MULTIPLAYER
     *      Give the GameUIManager the list of player IDs
     *      Inform the GameUIManager which player it is
     *          The GameManger knows this from the list of IPs, which map to their IDs
     *      For local multiplayer, this would rotate out between the human players
     *          GameManager could inform the GameUIManager when the current player changes
     *      For internet multiplayer, this would be told to the GameUIManager upon initialization
     *          This would then never change throughout the game since each PC connected would be one player
     *
     */
}
