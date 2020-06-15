using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class GameManager : MonoBehaviour, IMyTurnManagerCallbacks, IOnEventCallback
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
		private bool ReceivedMyFactionInformation;
		private MyTurnManager TurnManager;
		private Phases CurrentPhase;

		#region UnityFunctions
		void Start()
		{
			MyUserId = "";
			GameIsSetUpAtStart = false;
			ReceivedMyFactionInformation = false;
			TurnManager = this.gameObject.AddComponent<MyTurnManager>();
			TurnManager.TurnManagerListener = this;
			CurrentPhase = Phases.Game_Start_Setup;
			NumHumanPlayers = PhotonNetwork.PlayerList.Length; //TODO account for single player when that's implemented
			NumComputerPlayers = 0; //No computer players implemented for now. Will change when AI is added

			registerPhotonCallbacks();

			//Add placeholder players
			for (int i = 0; i < NumHumanPlayers; i++)
            {
				Faction faction = new Faction("Dummy", new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION));
                Players.Add(new HumanPlayer(faction, StartingSalvage));
            }

            //Figure out our user ID
            Photon.Realtime.Player[] allPlayers = PhotonNetwork.PlayerList;
			for (int i = 0; i < allPlayers.Length; i++)
			{
				if (allPlayers[i].IsLocal)
				{
					MyUserId = allPlayers[i].UserId;
					break;
				}
			}
			if (MyUserId == "")
			{
				Debug.LogError("Didn't find user's id...");
			}

			//Get the game object from the main menu that knows the game mode, all the modifiers, and the factions picked
			NewGameState = GameObject.Find("GameCreation");

			if (NewGameState != null && PhotonNetwork.IsMasterClient)
			{
				extractGameModeFromGameCreationObject(NewGameState);

				//Extract the Solo II difficulty if needed
				//if(gameMode == GameInformation.GameModes.SoloII) {
				//	soloIIDifficulty = newGameState.GetComponent<GameCreation>().soloIIDifficulty;
				//}

				//Send the factions to the other players
				Dictionary<int, string> factions = NewGameState.GetComponent<GameCreation>().GetFactions();
				foreach (KeyValuePair<int, string> entry in factions)
				{
					int playerIndex = entry.Key;
					string factionName = entry.Value;
					if (!PhotonNetwork.PlayerList[playerIndex].IsMasterClient)
					{
						object content = new FactionNetworking(factionName, playerIndex);
						RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { PhotonNetwork.PlayerList[playerIndex].ActorNumber } };
						SendOptions sendOptions = new SendOptions { Reliability = true };
						PhotonNetwork.RaiseEvent(Constants.EvSendFactionInformation, content, raiseEventOptions, sendOptions);
					}
					DefaultFactionInfo defaultFactionInfo = new DefaultFactionInfo();
					Faction faction = defaultFactionInfo.GetFactionFromName(factionName);
					if (faction == null)
					{
						Debug.LogError("Faction info passed in was bad... We got " + factionName + " but couldn't find such a faction.");
					}
					Players[playerIndex] = new HumanPlayer(faction, StartingSalvage);
				}
				ReceivedMyFactionInformation = true;

				//Interpret any modifiers
				//TODO when these are implemented
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
            if (!GameIsSetUpAtStart && ReceivedMyFactionInformation)
			{
				FactionPerkManager.HandlePhase(this);

				if (PhotonNetwork.IsMasterClient)
				{
					dealCardsToPlayers();
					countTownTechsThatAreInUse();
					StartTurn();
				}

				GameIsSetUpAtStart = true;
            }
        }

		public void OnEnable()
		{
			PhotonNetwork.AddCallbackTarget(this);
		}

		public void OnDisable()
		{
			PhotonNetwork.RemoveCallbackTarget(this);
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
			bool techsHandled = false;
			CurrentPhase = phase;

			//Auto phases that require no user input
			switch (phase)
            {
				case Phases.Effects_Resolve_Subphase:
					Debug.Log("Resolve effects and move on!");
					//TODO
					EndPhase(GetIndexForMyPlayer());
					break;
				case Phases.Town_Business_Deal:
					Debug.Log("Deal action cards!");
					townBusinessPhase_DealSubphase();
					TownTechManager.HandlePhase(this);
					techsHandled = true;
					EndPhase(GetIndexForMyPlayer());
					break;
				case Phases.End_Turn_Adjust_Turn_Marker:
					Debug.Log("Move turn marker chip!");
					//TODO
					EndPhase(GetIndexForMyPlayer());
					break;
				case Phases.End_Turn_Pass_First_Player:
					Debug.Log("Next player becomes first player!");
					//TODO
					EndPhase(GetIndexForMyPlayer());
					break;
				default:
					break;
            }

			FactionPerkManager.HandlePhase(this);
			if (!techsHandled)
			{
				TownTechManager.HandlePhase(this);
			}
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
				TurnManager.BeginNextPhase();
			}
		}

		public void OnEvent(EventData photonEvent)
		{
			byte eventCode = photonEvent.Code;

			if (eventCode == Constants.EvDealCard)
			{
				Debug.Log("Got a card dealt to me!");
				if (photonEvent.CustomData is SpoilsCard)
				{
					SpoilsCard data = (SpoilsCard)photonEvent.CustomData;
					dealSpecificSpoilToPlayer(GetIndexForMyPlayer(), data.GetTitle());
				}
				else if (photonEvent.CustomData is CharacterCard)
				{
					CharacterCard data = (CharacterCard)photonEvent.CustomData;
					dealSpecificCharacterToPlayer(GetIndexForMyPlayer(), data.GetTitle());
				}
				else if (photonEvent.CustomData is ActionCard)
				{
					ActionCard data = (ActionCard)photonEvent.CustomData;
					dealSpecificActionCardToPlayer(GetIndexForMyPlayer(), data.GetTitle());
				}
			}
			else if (eventCode == Constants.EvSendFactionInformation)
			{
				Debug.Log("Got faction info sent to me!");
				FactionNetworking factionInfo = (FactionNetworking)photonEvent.CustomData;
				DefaultFactionInfo defaultFactionInfo = new DefaultFactionInfo();
				Faction faction = defaultFactionInfo.GetFactionFromName(factionInfo.GetFactionName());
				if (faction == null)
				{
					Debug.LogError("OnEvent: Faction info passed in was bad... We got " + factionInfo.GetFactionName() + " but couldn't find such a faction.");
				}
				Players[factionInfo.GetPlayerIndex()] = new HumanPlayer(faction, StartingSalvage);

				if (factionInfo.GetPlayerIndex() == GetIndexForMyPlayer())
				{
					ReceivedMyFactionInformation = true;
				}
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

		public Phases GetCurrentPhase()
		{
			return CurrentPhase;
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

        public List<Player> GetPlayers()
        {
			return Players;
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
				Players[playerIndex].RemoveStowableFromActiveVehicle(card);
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
				Players[playerIndex].AddStowableToActiveVehicle(card);
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

		public void DealSpoilsToPlayer(int playerIndex, int numberOfCardsToDeal)
		{
			for (int i = 0; i < numberOfCardsToDeal; i++)
			{
				Players[playerIndex].AddSpoilsCardToAuctionHouse(SpoilsDeck[0]);
				SpoilsDeck.RemoveAt(0);
			}
		}

        public virtual void DealSpecificSpoilToPlayer(int playerIndex, string cardName)
        {
			if (!PhotonNetwork.PlayerList[playerIndex].IsMasterClient)
			{
				object content = new SpoilsCard(cardName);
				RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { PhotonNetwork.PlayerList[playerIndex].ActorNumber } };
				SendOptions sendOptions = new SendOptions { Reliability = true };
				PhotonNetwork.RaiseEvent(Constants.EvDealCard, content, raiseEventOptions, sendOptions);
			}

			dealSpecificSpoilToPlayer(playerIndex, cardName);
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
			dealSpoilsCardsToPlayers();
			dealCharacterCardsToPlayers();
			dealActionCardsToPlayers();
		}

        public void dealSpoilsCardsToPlayers()
		{
			moveStartingCardsToTheEndOfTheDeck(); //Ensure we don't deal away someone's starting card
			for (int i = 0; i < StartingSpoilsCards; i++)
			{
				for (int j = 0; j < Players.Count; j++)
				{
					Players[j].AddSpoilsCardToAuctionHouse(SpoilsDeck[0]);
					Debug.Log("Dealt spoils card " + SpoilsDeck[0].GetTitle());
					if (!PhotonNetwork.PlayerList[j].IsMasterClient)
					{
						object content = SpoilsDeck[0];
						RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { PhotonNetwork.PlayerList[j].ActorNumber } };
						SendOptions sendOptions = new SendOptions { Reliability = true };
						PhotonNetwork.RaiseEvent(Constants.EvDealCard, content, raiseEventOptions, sendOptions);
					}
					SpoilsDeck.RemoveAt(0);
				}
			}
			Card.ShuffleDeck(SpoilsDeck);
		}

		public void dealCharacterCardsToPlayers()
		{
			for (int i = 0; i < StartingCharacterCards; i++)
			{
				for (int j = 0; j < Players.Count; j++)
				{
					Players[j].AddCharacterCardToTownRoster(CharacterDeck[0]);
					Debug.Log("Dealt character card " + CharacterDeck[0].GetTitle());
					if (!PhotonNetwork.PlayerList[j].IsMasterClient)
					{
						object content = CharacterDeck[0];
						RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { PhotonNetwork.PlayerList[j].ActorNumber } };
						SendOptions sendOptions = new SendOptions { Reliability = true };
						PhotonNetwork.RaiseEvent(Constants.EvDealCard, content, raiseEventOptions, sendOptions);
					}
					CharacterDeck.RemoveAt(0);
				}
			}
		}

		public void dealActionCardsToPlayers()
		{
			for (int i = 0; i < StartingActionCards; i++)
			{
				for (int j = 0; j < Players.Count; j++)
				{
					Players[j].AddActionCardToHand(ActionDeck[0]);
					Debug.Log("Dealt action card " + ActionDeck[0].GetTitle());
					if (!PhotonNetwork.PlayerList[j].IsMasterClient)
					{
						object content = ActionDeck[0];
						RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { PhotonNetwork.PlayerList[j].ActorNumber } };
						SendOptions sendOptions = new SendOptions { Reliability = true };
						PhotonNetwork.RaiseEvent(Constants.EvDealCard, content, raiseEventOptions, sendOptions);
					}
					ActionDeck.RemoveAt(0);
				}
			}
		}

		public void moveStartingCardsToTheEndOfTheDeck()
		{
			for (int i = 0; i < SpoilsDeck.Count; i++)
			{
				if (SpoilsDeck[i].GetIsStartingCard())
				{
					SpoilsCard card = SpoilsDeck[i];
					SpoilsDeck.RemoveAt(i);
					SpoilsDeck.Add(card);
				}
			}
		}

		public void dealSpecificSpoilToPlayer(int playerIndex, string cardName)
		{
			bool found = false;
			for (int i = 0; i < SpoilsDeck.Count; i++)
			{
				if (SpoilsDeck[i].GetTitle() == cardName)
				{
					Players[playerIndex].AddSpoilsCardToAuctionHouse(SpoilsDeck[i]);
					SpoilsDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to deal specific card " + cardName + " to player, but it was not found in the deck");
			}
		}

		public void dealSpecificCharacterToPlayer(int playerIndex, string cardName)
		{
			bool found = false;
			for (int i = 0; i < CharacterDeck.Count; i++)
			{
				if (CharacterDeck[i].GetTitle() == cardName)
				{
					Players[playerIndex].AddCharacterCardToTownRoster(CharacterDeck[i]);
					CharacterDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to deal specific card " + cardName + " to player, but it was not found in the deck");
			}
		}

		public void dealSpecificActionCardToPlayer(int playerIndex, string cardName)
		{
			bool found = false;
			for (int i = 0; i < ActionDeck.Count; i++)
			{
				if (ActionDeck[i].GetTitle() == cardName)
				{
					Players[playerIndex].AddActionCardToHand(ActionDeck[i]);
					ActionDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to deal specific card " + cardName + " to player, but it was not found in the deck");
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

		private void registerPhotonCallbacks()
		{
			PhotonPeer.RegisterType(typeof(SpoilsCard), Constants.EvDealCard, SpoilsCard.SerializeSpoilsCard, SpoilsCard.DeserializeSpoilsCard);
			PhotonPeer.RegisterType(typeof(FactionNetworking), Constants.EvSendFactionInformation, FactionNetworking.SerializeFaction, FactionNetworking.DeserializeFaction);
			PhotonPeer.RegisterType(typeof(CharacterCard), Constants.SendCharacterCardEventRegistration, CharacterCard.SerializeCharacterCard, CharacterCard.DeserializeCharacterCard);
			PhotonPeer.RegisterType(typeof(ActionCard), Constants.SendActionCardEventRegistration, ActionCard.SerializeActionCard, ActionCard.DeserializeActionCard);
		}

		private void townBusinessPhase_DealSubphase()
		{
			for (int i = 0; i < Players.Count; i++)
			{
				Players[i].AddActionCardToHand(ActionDeck[0]);
				Debug.Log("Dealt card " + ActionDeck[0].GetTitle());
				if (!PhotonNetwork.PlayerList[i].IsMasterClient)
				{
					object content = ActionDeck[0];
					RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { PhotonNetwork.PlayerList[i].ActorNumber } };
					SendOptions sendOptions = new SendOptions { Reliability = true };
					PhotonNetwork.RaiseEvent(Constants.EvDealCard, content, raiseEventOptions, sendOptions);
				}
				ActionDeck.RemoveAt(0);
			}
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
		 *      For internet multiplayer, this would be told to the GameUIManager upon initialization
		 *          This would then never change throughout the game since each PC connected would be one player
		 *
		 */
    }
}
