using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class GameManager : MonoBehaviour, IMyTurnManagerCallbacks
	{
		private List<SpoilsCard> SpoilsDeck = new List<SpoilsCard>();
		private List<CharacterCard> CharacterDeck = new List<CharacterCard>();
		private List<ActionCard> ActionDeck = new List<ActionCard>();
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
		private Dictionary<string, int> TechsUsed;
		private const int MaxOfEachTech = 5;
		private const int StartingSalvage = 10;
		private string MyUserId;
		private GameObject NewGameState;
		private bool GameIsSetUpAtStart;
		private MyTurnManager TurnManager;

		#region UnityFunctions
		void Start()
		{
			MyUserId = "";
			TurnManager = this.gameObject.AddComponent<MyTurnManager>();
			TurnManager.TurnManagerListener = this;

			//Get the game object from the main menu that knows the game mode, all the modifiers, and the factions picked
			NewGameState = GameObject.Find("GameCreation");

			if (NewGameState != null)
			{
				//Grab the game mode
				extractGameModeFromGameCreationObject(NewGameState);

				//Extract the Solo II difficulty if needed
				//if(gameMode == GameInformation.GameModes.SoloII) {
				//	soloIIDifficulty = newGameState.GetComponent<GameCreation>().soloIIDifficulty;
				//}

				//Set the number of human and computer players
				NumHumanPlayers = PhotonNetwork.PlayerList.Length; //TODO account for single player when that's implemented
				NumComputerPlayers = 0; //No computer players implemented for now. Will change when AI is added

				//Figure out our user ID
				Photon.Realtime.Player[] allPlayers = PhotonNetwork.PlayerList;
				Photon.Realtime.Player[] allPlayersButMe = PhotonNetwork.PlayerListOthers;
				for (int i = 0; i < allPlayers.Length; i++)
				{
					bool found = false;
					for (int j = 0; j < allPlayersButMe.Length; j++)
					{
						if (allPlayers[i].UserId == allPlayersButMe[j].UserId)
						{
							found = true;
						}
					}
					if (!found)
					{
						MyUserId = allPlayers[i].UserId;
					}
				}
				if (MyUserId == "")
				{
					Debug.LogError("Didn't find user's id...");
				}

				//Interpret any modifiers
				//TODO when these are implemented
			}
			else
			{
				//TODO handle this better probably. This is the case where I start debugging from the game scene rather than the main menu
				Debug.LogError("Game info not received from game setup.");
				Players.Add(new HumanPlayer(new DefaultFactionInfo().GetDefaultFactionList()[0], StartingSalvage));
			}


			//Create the map layout according to the game state that was passed in
			GameObject mapCreationGO = GameObject.Find("Map");
			MapCreation mapCreation = mapCreationGO.GetComponent<MapCreation>();
			mapCreation.CreateMap();


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
		}

		void Update()
		{
			if (NewGameState.GetComponent<GameCreation>().GetFactions().Count > 0 && !GameIsSetUpAtStart)
			{
				Debug.Log("Factions have come through!");
				for (int i = 0; i < NumHumanPlayers; i++)
				{
					string currentUserId = PhotonNetwork.PlayerList[i].UserId;
					Faction faction = NewGameState.GetComponent<GameCreation>().GetFaction(currentUserId);
					Players.Add(new HumanPlayer(faction, StartingSalvage));
				}

				dealCardsToPlayers();

				countTownTechsThatAreInUse();

				GameIsSetUpAtStart = true;

				StartTurn();
			}
		}
        #endregion

        #region TurnManagerCallbacks
		public void OnTurnBegins(int turn)
        {
			Debug.Log("OnTurnBegins: " + turn);
        }

        public void OnTurnCompleted(int turn)
		{
			Debug.Log("OnTurnCompleted: " + turn);
        }

		public void OnPhaseBegins(Phases phase)
		{
			Debug.Log("OnPhaseBegins: " + phase.ToString());
		}

		public void OnPhaseCompleted(Phases phase)
		{
			Debug.Log("OnPhaseCompleted: " + phase.ToString());
		}

		public void OnPlayerMove(Photon.Realtime.Player player, Phases phase, object move)
		{
			throw new System.NotImplementedException();
		}

		public void OnPlayerFinished(Photon.Realtime.Player player, Phases phase, object move)
		{
            if (TurnManager.IsPhaseCompletedByAll)
            {
				//Go to next phase
				TurnManager.BeginNextPhase();

			}
		}
		#endregion

		#region PublicAPI
		public void StartTurn()
		{
			if (PhotonNetwork.IsMasterClient)
			{
				TurnManager.BeginNextTurn();
			}
		}

		public List<TownTech> GetTownTechs(int playerId)
		{
			List<TownTech> techs = new List<TownTech>();
			if (playerId < Players.Count)
			{
				techs = Players[playerId].GetTownTechs();
			}
			return techs;
		}

		public int GetSalvage(int playerIndex)
		{
			int salvage = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				salvage = Players[playerIndex].GetSalvageAmount();
			}
			return salvage;
		}

		public Faction GetFaction(int playerIndex)
		{
			Faction faction = new Faction("dummy faction", new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION));
			if (isPlayerIndexInRange(playerIndex))
			{
				faction = Players[playerIndex].GetPlayerFaction();
			}
			return faction;
		}

		public List<SpoilsCard> GetAuctionHouse(int playerIndex)
		{
			List<SpoilsCard> spoils = new List<SpoilsCard>();
			if (isPlayerIndexInRange(playerIndex))
			{
				spoils = Players[playerIndex].GetAuctionHouseCards();
			}
			return spoils;
		}

		public List<ActionCard> GetActionCards(int playerIndex)
		{
			List<ActionCard> actionCards = new List<ActionCard>();
			if (isPlayerIndexInRange(playerIndex))
			{
				actionCards = Players[playerIndex].GetActionCards();
			}
			return actionCards;
		}

		public List<CharacterCard> GetActiveCharacterCards(int playerIndex)
		{
			List<CharacterCard> characterCards = new List<CharacterCard>();
			if (isPlayerIndexInRange(playerIndex))
			{
				characterCards = Players[playerIndex].GetActiveCharacters();
			}
			return characterCards;
		}

		public List<CharacterCard> GetTownRoster(int playerIndex)
		{
			List<CharacterCard> townRoster = new List<CharacterCard>();
			if (isPlayerIndexInRange(playerIndex))
			{
				townRoster = Players[playerIndex].GetTownRoster();
			}
			return townRoster;
		}

		public SpoilsCard GetActiveVehicle(int playerIndex)
		{
			SpoilsCard vehicle = null;
			if (isPlayerIndexInRange(playerIndex))
			{
				vehicle = Players[playerIndex].GetActiveVehicle();
			}
			return vehicle;
		}

		public Dictionary<Skills, int> GetActiveCharacterStats(int playerIndex, int characterIndex)
		{
			Dictionary<Skills, int> stats = null;
			if (isPlayerIndexInRange(playerIndex))
			{
				stats = Players[playerIndex].GetActiveCharacterStats(characterIndex);
			}
			return stats;
		}

		public int GetActiveCharacterCarryWeight(int playerIndex, int characterIndex)
		{
			int weight = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				weight = Players[playerIndex].GetActiveCharacterCarryWeight(characterIndex);
			}
			return weight;
		}

		public Dictionary<Skills, int> GetActiveVehicleStats(int playerIndex)
		{
			Dictionary<Skills, int> stats = null;
			if (isPlayerIndexInRange(playerIndex))
			{
				stats = Players[playerIndex].GetActiveVehicleStats();
			}
			return stats;
		}

		public int GetActiveVehicleCarryWeight(int playerIndex)
		{
			int weight = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				weight = Players[playerIndex].GetActiveVehicleCarryWeight();
			}
			return weight;
		}

		public int GetIndexForMyPlayer()
		{
			int returnIndex = 0;

			for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
			{
				if (PhotonNetwork.PlayerList[i].UserId == MyUserId)
				{
					returnIndex = i;
				}
			}

			return returnIndex;
		}

		public string GetMyUserId()
		{
			return MyUserId;
		}

		public int GetTurn()
		{
			return TurnManager.Turn;
		}

		public Photon.Realtime.Player GetCurrentPlayer()
		{
			return TurnManager.CurrentPlayer;
		}

		public Phases GetPhase()
		{
			return TurnManager.Phase;
		}

		public void RemoveSpoilFromAuctionHouse(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveSpoilsCardFromAuctionHouse(card);
			}
		}

		public void RemoveCharacterFromTownRoster(int playerIndex, CharacterCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveCharacterFromTownRoster(card);
			}
		}

		public void RemoveSpoilsCardFromPlayerActiveParty(int playerIndex, int characterSlotIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveSpoilsCardFromActiveCharacter(characterSlotIndex, card);
			}
		}

		public void RemoveCharacterFromActiveParty(int playerIndex, int characterSlotFoundIn)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveCharacterFromParty(characterSlotFoundIn);
			}
		}

		public void RemoveSpoilsCardFromActiveVehicle(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveSpoilsCardFromActiveVehicle(card);
			}
		}

		public void RemoveActiveVehicle(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveActiveVehicle();
			}
		}

		public void AssignSpoilsCardToCharacter(int playerIndex, int characterIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddSpoilsToCharacter(characterIndex, card);
			}
		}

		public void AssignCharacterToParty(int playerIndex, int characterIndex, CharacterCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddCharacterToParty(characterIndex, card);
			}
		}

		public void AddSpoilsToAuctionHouse(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddSpoilsCardToAuctionHouse(card);
			}
		}

		public void AddCharacterToTownRoster(int playerIndex, CharacterCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddCharacterCardToTownRoster(card);
			}
		}

		public void AddVehicleToActiveParty(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddVehicleToParty(card);
			}
		}

		public void AddSpoilsToActiveVehicle(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddStowableToVehicle(card);
			}
		}

		public bool IsAllowedToApplySpoilsToCharacterSlot(int playerIndex, SpoilsCard card, int characterIndex)
		{
			bool isAllowed = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				isAllowed = Players[playerIndex].IsAllowedToAddSpoilsCardToCharacter(characterIndex, card);
			}
			return isAllowed;
		}

		public bool IsAllowedToApplySpoilsToVehicleSlot(int playerIndex, SpoilsCard card)
		{
			bool isAllowed = false;
			if (card != null && isPlayerIndexInRange(playerIndex))
			{
				List<SpoilsTypes> types = card.GetSpoilsTypes();
				if (types.Contains(SpoilsTypes.Vehicle))
				{
					isAllowed = Players[playerIndex].IsAllowedToEquipVehicleToSlot();
				}
				else
				{
					isAllowed = Players[playerIndex].IsAllowedToEquipSpoilsToVehicle(card);
				}
			}
			return isAllowed;
		}

		public bool IsAllowedToApplyCharacterToCharacterSlot(int playerIndex, int characterIndex)
		{
			bool isAllowed = false;
			if (isPlayerIndexInRange(playerIndex) && characterIndex != Constants.VEHICLE_INDEX)
			{
				isAllowed = Players[playerIndex].IsAllowedToAddCharacterToParty(characterIndex);
			}
			return isAllowed;
		}

		public int GetNumberOfActiveVehicles(int playerIndex)
		{
			int count = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				count = Players[playerIndex].GetNumberOfActiveVehicles();
			}
			return count;
		}

        public void EndPhase(int playerIndex)
        {
			if (isPlayerIndexInRange(playerIndex))
			{
				TurnManager.SendMove(null, true);
			}
		}
		#endregion

		#region HelperFunctions
		private void extractGameModeFromGameCreationObject(GameObject newGameState)
		{
			GameMode = newGameState.GetComponent<GameCreation>().GetMode();
		}

		private void dealCardsToPlayers()
		{
			Debug.Log("dealCardsToPlayers");
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
			TechsUsed = new Dictionary<string, int>();
			foreach (TownTech tt in TownTechs)
			{
				TechsUsed[tt.GetTechName()] = 0; //Init all town techs to 0 currently used
			}
			foreach (Player p in Players)
			{
				foreach (TownTech tt in p.GetTownTechs())
				{
					//For each town tech for each player, count it
					TechsUsed[tt.GetTechName()]++;
				}
			}
		}

		private bool isPlayerIndexInRange(int playerIndex)
		{
			return playerIndex >= 0 && playerIndex < Players.Count;
		}
        #endregion



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
