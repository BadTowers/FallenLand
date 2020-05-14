using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FallenLand
{
	public class GameManager : MonoBehaviour
	{

		private List<SpoilsCard> SpoilsDeck = new List<SpoilsCard>();
		private List<CharacterCard> CharacterDeck = new List<CharacterCard>();
		private List<ActionCard> ActionDeck = new List<ActionCard>();
		public GameObject CardPrefab;
		private int NumHumanPlayers;
		private int NumComputerPlayers;
		private GameInformation.GameModes GameMode;
		//private List<GameInformation.GameModifier> modifiers = new List<GameInformation.GameModifier>();
		//private GameInformation.SoloII soloIIDifficulty;
		private List<Player> Players = new List<Player>();
		private const int StartingActionCards = 3;
		private const int StartingCharacterCards = 6;
		private const int StartingSpoilsCards = 10;
		private const int MaxActionCards = 7;
		private const int MaxCharacterCards = -1;
		private const int MaxSpoilsCards = -1;
		private List<TownTech> TownTechs;
		private Dictionary<TownTech, int> TechsUsed;
		private const int MaxOfEachTech = 5;
		private const int StartingSalvage = 10;

		void Start()
		{
			//Get the game object from the main menu that knows the game mode, all the modifiers, and the factions picked
			GameObject newGameState = GameObject.Find("GameCreation");

			//Debug.Log(newGameState.GetComponent<GameCreation>().gameMode); //Debug thingy

			if (newGameState != null)
			{
				//Mark as read so the game object can be deleted
				newGameState.GetComponent<GameCreation>().WasRead = true;

				//Debug.Log(newGameState.GetComponent<GameCreation>().faction); //Debug thingy

				//Grab the game mode
				extractGameModeFromGameCreationObject(newGameState);

				//Grab the faction (TODO change this to grab a dictionary of factions and who is each faction)
				Faction faction = newGameState.GetComponent<GameCreation>().GetFaction();

				//Extract the Solo II difficulty if needed
				//if(gameMode == GameInformation.GameModes.SoloII) {
				//	soloIIDifficulty = newGameState.GetComponent<GameCreation>().soloIIDifficulty;
				//}

				//Set the number of human and computer players TODO change this to be passed in from GameCreation object
				NumHumanPlayers = GameInformation.getHumanPlayerCount(GameMode);
				NumComputerPlayers = GameInformation.getComputerPlayerCount(GameMode);

				//Add the players to the list (TODO: Change so later these are added in the order players will go (after dice roll or something))
				for (int i = 0; i < NumHumanPlayers; i++)
				{
					Players.Add(new HumanPlayer(faction, StartingSalvage));
				}
				for (int i = 0; i < NumComputerPlayers; i++)
				{
					//players.Add(new ComputerPlayer(startingSalvage)); //TODO reaccount for when doing a true single player game, not a solo variant
				}

				//Interpret any modifiers
				//TODO


			}
			else
			{
				//TODO handle this better probably
				Debug.Log("Game info not received from game setup.");
				Players.Add(new HumanPlayer(new DefaultFactionInfo().GetDefaultFactionList()[0], StartingSalvage));
			}


			//Create the map layout according to the game state that was passed in
			GameObject mapCreationGO = GameObject.Find("Map");
			MapCreation mapCreation = mapCreationGO.GetComponent<MapCreation>();
			mapCreation.ml = new DefaultMapLayout(); //For now, just do the default. Can be modified later. TODO account for modifiers
			mapCreation.createMap();


			SpoilsDeck = (new DefaultSpoilsCards()).GetSpoilsCards();
			SpoilsDeck = Card.ShuffleDeck(SpoilsDeck);

			CharacterDeck = (new DefaultCharacterCards()).GetCharacterCards();
			CharacterDeck = Card.ShuffleDeck(CharacterDeck);

			ActionDeck = (new DefaultActionCards()).GetActionCards();
			ActionDeck = Card.ShuffleDeck(ActionDeck);


			//TODO create the deck of mission cards


			//TODO create the deck of plains cards


			//TODO create the deck of mountain cards


			//TODO create the deck of city/rad cards


			dealCardsToPlayers();

			countTownTechsThatAreInUse();
		}


		void Update()
		{

		}



		/*****Some public interface functions for the GUI to attach to*******/
		public List<TownTech> GetTownTechs(int playerId)
		{
			return Players[playerId].GetTownTechs();
		}

		public int GetSalvage(int playerId)
		{
			return Players[playerId].GetSalvageAmount();
		}

		public Faction GetFaction(int playerId)
		{
			return Players[playerId].GetPlayerFaction();
		}

		public List<SpoilsCard> GetAuctionHouse(int playerId)
		{
			return Players[playerId].GetAuctionHouseCards();
		}

		public List<ActionCard> GetActionCards(int playerId)
		{
			return Players[playerId].GetActionCards();
		}

		public List<CharacterCard> GetActiveCharacterCards(int playerId)
		{
			return Players[playerId].GetActiveCharacters();
		}

		public List<CharacterCard> GetTownRoster(int playerId)
		{
			return Players[playerId].GetTownRoster();
		}




		/******Some private helper functions******/
		private void extractGameModeFromGameCreationObject(GameObject newGameState)
		{
			GameMode = newGameState.GetComponent<GameCreation>().GetMode();
		}

		private void dealCardsToPlayers()
		{
			for (int i = 0; i < StartingSpoilsCards; i++)
			{
				for (int j = 0; j < Players.Count; j++)
				{
					Players[j].AddSpoilsCardToAuctionHouse(SpoilsDeck[0]); //Add the first card to the next player's hand
					Debug.Log("Dealt card " + SpoilsDeck[0].GetTitle());
					SpoilsDeck.RemoveAt(0); //Remove that card from the deck of cards
				}
			}
			for (int i = 0; i < StartingCharacterCards; i++)
			{
				for (int j = 0; j < Players.Count; j++)
				{
					Players[j].AddCharacterCardToTownRoster(CharacterDeck[0]);
					Debug.Log("Dealt card " + CharacterDeck[0].GetTitle());
					CharacterDeck.RemoveAt(0);
				}
			}
			for (int i = 0; i < StartingActionCards; i++)
			{
				for (int j = 0; j < Players.Count; j++)
				{
					Players[j].AddActionCardToHand(ActionDeck[0]);
					Debug.Log("Dealt card " + ActionDeck[0].GetTitle());
					ActionDeck.RemoveAt(0);
				}
			}
		}

		private void countTownTechsThatAreInUse()
		{
			TownTechs = (new DefaultTownTechs()).GetDefaultTownTechList();
			TechsUsed = new Dictionary<TownTech, int>();
			foreach (TownTech tt in TownTechs)
			{
				TechsUsed[tt] = 0; //Init all town techs to 0 currently used
			}
			foreach (Player p in Players)
			{
				foreach (TownTech tt in p.GetTownTechs())
				{
					//For each town tech for each player, count it
					TechsUsed[tt]++;
				}
			}
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
}
