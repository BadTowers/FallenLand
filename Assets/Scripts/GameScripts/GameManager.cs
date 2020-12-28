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
		private List<SpoilsCard> SpecialSpoilsDeck = new List<SpoilsCard>();
		private List<CharacterCard> CharacterDeck = new List<CharacterCard>();
		private List<ActionCard> ActionDeck = new List<ActionCard>();
		private List<PlainsCard> PlainsDeck = new List<PlainsCard>();
		private List<SpoilsCard> DiscardedSpoilsDeck = new List<SpoilsCard>();
		private List<CharacterCard> DiscardedCharacters = new List<CharacterCard>();
		private List<ActionCard> DiscardedActionCards = new List<ActionCard>();
		private List<PlainsCard> DiscardedPlainsCards = new List<PlainsCard>();
		private int NumHumanPlayers;
		private GameInformation.GameModes GameMode;
		//private List<GameInformation.GameModifier> modifiers = new List<GameInformation.GameModifier>();
		//private GameInformation.SoloII soloIIDifficulty;
		private List<Player> Players = new List<Player>();
		private const int StartingActionCards = 3;
		private const int StartingCharacterCards = 6;
		private const int StartingSpoilsCards = 10;
		private const int MaxActionCards = 7;
		private const int MaxPsych = 3;
		private const int MaxNumberOfPlayers = 5;
		private const int MovementWeekCost = 1;
		private const int EncounterWeekCost = 1;
		private List<TownTech> TownTechs;
		private Dictionary<string, int> TechsUsed;
		private const int MaxOfEachTech = 5;
		private const int StartingSalvage = 10;
		private const int StartingTownHealth = 30;
		private const int StartingPrestige = 1;
		private const int NumberOfMissions = 7;
		private string MyUserId;
		private GameObject NewGameState;
		private bool GameIsSetUpAtStart;
		private bool ReceivedMyFactionInformation;
		private MyTurnManager TurnManager;
		private Phases CurrentPhase;
		private PlayerPieceManager PlayerPieceManagerInst;
		private MissionManager MissionManagerInst;
		private Dice DiceRoller;
		private bool IsMyPhaseEnded;
		private MouseManager MouseManagerInst;
		private MapLayout MapLayoutInst;
		private List<EncounterCard> CurrentPlayerEncounter;
		private bool EncounterWasSent;

		#region UnityFunctions
		void Awake()
		{
			MyUserId = "";
			GameIsSetUpAtStart = false;
			ReceivedMyFactionInformation = false;
			IsMyPhaseEnded = false;
			TurnManager = this.gameObject.AddComponent<MyTurnManager>();
			TurnManager.TurnManagerListener = this;
			CurrentPhase = Phases.Game_Start_Setup;
			NumHumanPlayers = PhotonNetwork.PlayerList.Length; //TODO account for single player when that's implemented
			PlayerPieceManagerInst = this.gameObject.AddComponent<PlayerPieceManager>();
			MissionManagerInst = new MissionManager();
			DiceRoller = new Dice();
			MouseManagerInst = GameObject.Find("MouseManager").GetComponent<MouseManager>();
			MapLayoutInst = new DefaultMapLayout();
			CurrentPlayerEncounter = new List<EncounterCard>();

			registerPhotonCallbacks();

			//Add placeholder players
			for (int i = 0; i < NumHumanPlayers; i++)
            {
				Faction faction = new Faction("Dummy", new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION));
				Players.Add(new HumanPlayer(faction, StartingSalvage));
				CurrentPlayerEncounter.Add(null);

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

			//Create the map layout according to the game state that was passed in
			GameObject mapCreationGO = GameObject.Find("Map");
			MapCreation mapCreation = mapCreationGO.GetComponent<MapCreation>();
			mapCreation.CreateMap(MapLayoutInst);
			PlayerPieceManagerInst.SetMap(mapCreation);
			MissionManagerInst.SetMap(mapCreation);

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

					//Send faction information to other players
					object content = new FactionNetworking(factionName, playerIndex);
					sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvSendFactionInformation);

					DefaultFactionInfo defaultFactionInfo = new DefaultFactionInfo();
					Faction faction = defaultFactionInfo.GetFactionFromName(factionName);
					if (faction == null)
					{
						Debug.LogError("Faction info passed in was bad... We got " + factionName + " but couldn't find such a faction.");
					}
					Player newPlayer = new HumanPlayer(faction, StartingSalvage);
					newPlayer.SetTownHealth(StartingTownHealth);
					newPlayer.SetPrestige(StartingPrestige);
					Players[playerIndex] = newPlayer;
					PlayerPieceManagerInst.CreatePiece(faction, playerIndex);
					Players[playerIndex].SetPartyLocation(faction.GetBaseLocation());
				}
				ReceivedMyFactionInformation = true;

				generateMissionLocations();
				sendMissionLocationsToOtherPlayers();

				//Interpret any modifiers
				//TODO when these are implemented
			}

			SpoilsDeck = (new DefaultSpoilsCards()).GetSpoilsCards();
			SpoilsDeck = Card.ShuffleDeck(SpoilsDeck);

			SpecialSpoilsDeck = (new DefaultSpecialSpoilsCards()).GetSpoilsCards(); //No need to shuffle these as they won't be dealt out normally.

			CharacterDeck = (new DefaultCharacterCards()).GetCharacterCards();
			CharacterDeck = Card.ShuffleDeck(CharacterDeck);

			ActionDeck = (new DefaultActionCards()).GetActionCards();
			ActionDeck = Card.ShuffleDeck(ActionDeck);

			PlainsDeck = (new DefaultPlainsCards()).GetPlainsCards();
			PlainsDeck = Card.ShuffleDeck(PlainsDeck);

			//TODO create the deck of mission cards


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

			int myIndex = GetIndexForMyPlayer();
			if (isPlayerIndexInRange(myIndex) && Players[myIndex].GetPlayerIsMoving())
			{
				Coordinates lastClickedHexCoordinates = MouseManagerInst.GetLastHexClickedCoodinates();
				if (lastClickedHexCoordinates != null)
				{
					MouseManagerInst.ClearLastHexClickedCoodinates();
					Players[myIndex].SetPlayerIsMoving(false);
					if (isAllowedToMoveHere(myIndex, lastClickedHexCoordinates))
					{
						PartyExploitsNetworking content = new PartyExploitsNetworking(myIndex, Constants.PARTY_EXPLOITS_MOVEMENT);
						content.SetMoveToLocation(lastClickedHexCoordinates);
						
						sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvPartyExploits);
						handlePartyExploitsNetworkUpdate(content);
					}
				}
			}
			else if (isPlayerIndexInRange(myIndex) && Players[myIndex].GetPlayerIsDoingAnEncounter() && !EncounterWasSent)
			{
				Debug.Log("Picking an encounter card to do");
				PartyExploitsNetworking content = new PartyExploitsNetworking(myIndex, Constants.PARTY_EXPLOITS_ENCOUNTER);
				content.SetEncounterType((byte)GetPlayerEncounterType(myIndex));
				int cardIndex = 0;
				bool prechecksHeld;
				do
				{
					prechecksHeld = true;
					List<Precheck> prechecks = PlainsDeck[cardIndex].GetPrechecks();
					if (prechecks.Count == 0)
					{
						break;
					}
					for (int precheckIndex = 0; precheckIndex < prechecks.Count; precheckIndex++)
					{
						if (!prechecks[precheckIndex].PrechecksHold(this, myIndex))
						{
							Debug.Log("Precheck didn't hold. Moving to next encounter card.");
							cardIndex++;
							prechecksHeld = false;
							break;
						}
					}

					if(cardIndex >= PlainsDeck.Count)
                    {
						Debug.LogError("Ran out of cards. Should shuffle and network to everyone else to shuffle!");
						//TODO actually shuffle
						cardIndex = 0;
						break; //for now
					}
				}
				while (cardIndex < PlainsDeck.Count && !prechecksHeld);
				string nextPlainsEncounterCardName = PlainsDeck[cardIndex].GetTitle();
				content.SetEncounterCardName(nextPlainsEncounterCardName);
				sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvPartyExploits);
				handlePartyExploitsNetworkUpdate(content);
				EncounterWasSent = true;
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
			Players[GetIndexForMyPlayer()].SetRemainingPartyExploitWeeks(4);
		}

        public void OnTurnCompleted(int turn)
		{
			Debug.Log("OnTurnCompleted: " + turn);
        }

		public void OnPhaseBegins(Phases phase)
		{
			bool techsHandled = false;
			CurrentPhase = phase;
			IsMyPhaseEnded = false;

			Debug.Log("OnPhaseBegins: " + phase.ToString());

			switch (phase)
            {
				case Phases.Effects_Resolve_Subphase: //Auto phase that require no user input
					Debug.Log("Resolve effects and move on!");
					//TODO resolve effects
					if(PhotonNetwork.IsMasterClient)
                    {
						endPhaseForAllPlayers();
					}
					break;
				case Phases.Town_Business_Deal: //Auto phase that require no user input
					Debug.Log("Deal action cards!");
					if (PhotonNetwork.IsMasterClient)
					{
						townBusinessPhase_DealSubphase();
					}
					TownTechManager.HandlePhase(this);
					techsHandled = true;
					if (PhotonNetwork.IsMasterClient)
					{
						endPhaseForAllPlayers();
					}
					break;
				case Phases.End_Turn_Adjust_Turn_Marker: //Auto phase that require no user input
					Debug.Log("Move turn marker chip!");
					//TODO
					if (PhotonNetwork.IsMasterClient)
					{
						endPhaseForAllPlayers();
					}
					break;
				case Phases.End_Turn_Pass_First_Player: //Auto phase that require no user input
					Debug.Log("Next player becomes first player!");
					//TODO
					if (PhotonNetwork.IsMasterClient)
					{
						endPhaseForAllPlayers();
					}
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
            if (TurnManager.IsPhaseCompletedByAll && PhotonNetwork.IsMasterClient)
            {
				TurnManager.BeginNextPhase();
			}
		}

		public void OnEvent(EventData photonEvent)
		{
			byte eventCode = photonEvent.Code;

			if (eventCode == Constants.EvDealCard)
			{
				Debug.Log("Card we sent to me!");
				CardNetworking cardInfo = (CardNetworking)photonEvent.CustomData;
				int playerIndex = cardInfo.GetPlayerIndex();
				string cardName = cardInfo.GetCardName();
				if (cardInfo.GetCardByte() == Constants.SPOILS_CARD)
				{
					dealSpecificSpoilToPlayerFromDeck(playerIndex, cardName);
				}
				else if (cardInfo.GetCardByte() == Constants.CHARACTER_CARD)
				{
					dealSpecificCharacterToPlayerFromDeck(playerIndex, cardName);
				}
				else if (cardInfo.GetCardByte() == Constants.ACTION_CARD)
				{
					dealSpecificActionCardToPlayerFromDeck(playerIndex, cardName);
				}
				else if (cardInfo.GetCardByte() == Constants.SPECIAL_SPOILS_CARD)
				{
					dealSpecificSpoilToPlayerFromSpecialDeck(playerIndex, cardName);
				}
				else if(cardInfo.GetCardByte() == Constants.DISCARDED_SPOILS_CARD)
                {
					dealSpecificSpoilToPlayerFromDiscardDeck(playerIndex, cardName);
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
				Player newPlayer = new HumanPlayer(faction, StartingSalvage);
				newPlayer.SetTownHealth(StartingTownHealth);
				newPlayer.SetPrestige(StartingPrestige);
				Players[factionInfo.GetPlayerIndex()] = newPlayer;
				Players[factionInfo.GetPlayerIndex()].SetPartyLocation(faction.GetBaseLocation());

				if (factionInfo.GetPlayerIndex() == GetIndexForMyPlayer())
				{
					ReceivedMyFactionInformation = true;
				}

				PlayerPieceManagerInst.CreatePiece(faction, factionInfo.GetPlayerIndex());
			}
			else if (eventCode == Constants.EvSendPlayerInformation)
			{
				Debug.Log("Received updated player information");
				PlayerCardNetworking playerInfo = (PlayerCardNetworking)photonEvent.CustomData;
				handlePlayerNetworkUpdate(playerInfo);
			}
			else if (eventCode == Constants.EvRequestUpdateToPlayerInformation)
			{
				Debug.Log("Got a request to update player information");
				object playerInfo = photonEvent.CustomData;
				sendNetworkEvent(playerInfo, ReceiverGroup.Others, Constants.EvSendPlayerInformation);
				handlePlayerNetworkUpdate((PlayerCardNetworking)playerInfo);
			}
			else if (eventCode == Constants.EvMissionLocation)
			{
				Debug.Log("Received mission location information");
				MissionLocationNetworking missionLocationInfo = (MissionLocationNetworking)photonEvent.CustomData;
				MissionManagerInst.AddMissionLocation(missionLocationInfo.GetMissionNumber(), missionLocationInfo.GetRandomLocationNumber());
			}
			else if (eventCode == Constants.EvTownEventRoll)
			{
				Debug.Log("Received a town event roll networking event");
				handleTownEventRollNetworkUpdate(photonEvent.CustomData);
			}
			else if (eventCode == Constants.EvPartyExploits)
			{
				Debug.Log("Received a party exploits event");
				handlePartyExploitsNetworkUpdate(photonEvent.CustomData);
			}
			else if (eventCode == Constants.EvEncounterStatus)
			{
				handleEncounterStatusEvent((EncounterStatusNetworking)photonEvent.CustomData);
			}
			else if (eventCode == Constants.EvMovement)
			{
				handleMovementNetworkEvent(photonEvent.CustomData);
			}
			else if (eventCode == Constants.EvCharacterHealth)
			{
				handleCharacterHealthEvent(photonEvent.CustomData);
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

		public MapLayout GetMapLayout()
		{
			return MapLayoutInst;
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

		public int GetTownHealth(int playerIndex)
		{
			int townHealth = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				townHealth = Players[playerIndex].GetTownHealth();
			}
			return townHealth;
		}

		public int GetPrestige(int playerIndex)
		{
			int prestige = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				prestige = Players[playerIndex].GetPrestige();
			}
			return prestige;
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

		public int GetActiveCharacterRemainingCarryWeight(int playerIndex, int characterIndex)
		{
			int weight = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				weight = Players[playerIndex].GetActiveCharacterRemainingCarryWeight(characterIndex);
			}
			return weight;
		}

		public int GetActiveCharacterTotalCarryWeight(int playerIndex, int characterIndex)
        {
			int weight = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				weight = Players[playerIndex].GetActiveCharacterTotalCarryWeight(characterIndex);
			}
			return weight;
		}

		public int GetActiveCharacterUsedCarryWeight(int playerIndex, int characterIndex)
		{
			int weight = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				weight = Players[playerIndex].GetActiveCharacterUsedCarryWeight(characterIndex);
			}
			return weight;
		}

		public int GetActiveCharacterRemainingPsych(int playerIndex, int characterIndex)
		{
			int remainingPsych = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				remainingPsych = Players[playerIndex].GetActiveCharacterRemainingPsych(characterIndex);
			}
			return remainingPsych;
		}

		public void SetActiveCharacterRemainingPsych(int playerIndex, int characterIndex, int remainingPsych)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].SetActiveCharacterRemainingPsych(characterIndex, remainingPsych);
			}
		}

		public int GetActiveVehicleTotalCarryWeight(int playerIndex)
		{
			int weight = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				weight = Players[playerIndex].GetActiveVehicleTotalCarryWeight();
			}
			return weight;
		}

		public int GetActiveVehicleUsedCarryWeight(int playerIndex)
		{
			int weight = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				weight = Players[playerIndex].GetActiveVehicleUsedCarryWeight();
			}
			return weight;
		}

		public int GetMaxPsych()
		{
			return MaxPsych;
		}

		public int GetMaxNumberOfPlayers()
		{
			return MaxNumberOfPlayers;
		}

		public int GetActiveCharacterRemainingHealth(int playerIndex, int characterIndex)
		{
			int remainingHealth = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				remainingHealth = Players[playerIndex].GetActiveCharacterRemainingHealth(characterIndex);
			}
			return remainingHealth;
		}

		public int GetActiveCharacterMaxHealth(int playerIndex, int characterIndex)
		{
			int maxHealth = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				maxHealth = Players[playerIndex].GetActiveCharacterMaxHealth(characterIndex);
			}
			return maxHealth;
		}

		public int GetActiveCharacterPsychResistance(int playerIndex, int characterIndex)
		{
			int psychRes = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				psychRes = Players[playerIndex].GetActiveCharacterPsychResistance(characterIndex);
			}
			return psychRes;
		}

		public int GetRemainingPartyExploitWeeks(int playerIndex)
		{
			int remainingWeeks = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				remainingWeeks = Players[playerIndex].GetRemainingPartyExploitWeeks();
			}
			return remainingWeeks;
		}


		public Dictionary<Skills, int> GetActiveVehicleStats(int playerIndex)
		{
			Dictionary<Skills, int> stats = new Dictionary<Skills, int>();
			if (isPlayerIndexInRange(playerIndex))
			{
				stats = Players[playerIndex].GetActiveVehicleStats();
			}
			return stats;
		}

		public int GetActiveVehicleRemainingCarryWeight(int playerIndex)
		{
			int weight = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				weight = Players[playerIndex].GetActiveVehicleRemainingCarryWeight();
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

		public EncounterCard GetCurrentEncounter(int playerIndex)
		{
			EncounterCard encounter = null;
			if (isPlayerIndexInRange(playerIndex))
			{
				encounter = CurrentPlayerEncounter[playerIndex];
			}
			return encounter;
		}

		public void RemoveSpoilFromAuctionHouse(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].RemoveSpoilsCardFromAuctionHouse(card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.REMOVE_FROM_AUCTION_HOUSE, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void RemoveCharacterFromTownRoster(int playerIndex, CharacterCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].RemoveCharacterFromTownRoster(card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.REMOVE_FROM_TOWN_ROSTER, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void RemoveSpoilsCardFromPlayerActiveParty(int playerIndex, int characterSlotIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].RemoveSpoilsCardFromActiveCharacter(characterSlotIndex, card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.REMOVE_SPOILS_FROM_SLOT, card.GetTitle(), characterSlotIndex);
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void RemoveCharacterFromActiveParty(int playerIndex, int characterSlotFoundIn)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveCharacterFromParty(characterSlotFoundIn);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.REMOVE_CHARACTER_FROM_SLOT, "", characterSlotFoundIn);
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void RemoveSpoilsCardFromActiveVehicle(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].RemoveStowableFromActiveVehicle(card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.REMOVE_SPOILS_FROM_VEHICLE, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void RemoveActiveVehicle(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveActiveVehicle();
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.REMOVE_VEHICLE, "");
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AssignSpoilsCardToCharacter(int playerIndex, int characterIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].AddSpoilsToCharacter(characterIndex, card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.ADD_SPOILS_TO_SLOT, card.GetTitle(), characterIndex);
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AssignCharacterToParty(int playerIndex, int characterIndex, CharacterCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].AddCharacterToParty(characterIndex, card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.ADD_CHARACTER_TO_SLOT, card.GetTitle(), characterIndex);
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AddSpoilsToAuctionHouse(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].AddSpoilsCardToAuctionHouse(card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.ADD_TO_AUCTION_HOUSE, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AddCharacterToTownRoster(int playerIndex, CharacterCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].AddCharacterCardToTownRoster(card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.ADD_TO_TOWN_ROSTER, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AddVehicleToActiveParty(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].AddVehicleToParty(card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.ADD_VEHICLE, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AddSpoilsToActiveVehicle(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].AddSpoilsToActiveVehicle(card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.ADD_SPOILS_TO_VEHICLE, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
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
			//TODO consider removing player index from this function...
			IsMyPhaseEnded = true;
			if (isPlayerIndexInRange(playerIndex))
			{
				TurnManager.SendMove(null, true);
			}
		}

		public void DealSpoilsToPlayer(int playerIndex, int numberOfCardsToDeal)
		{
			for (int i = 0; i < numberOfCardsToDeal; i++)
			{
				object content = new CardNetworking(SpoilsDeck[0].GetTitle(), playerIndex, Constants.SPOILS_CARD);
				sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
				dealSpecificSpoilToPlayerFromDeck(playerIndex, SpoilsDeck[0].GetTitle());
			}
		}

		public void DealCharactersToPlayer(int playerIndex, int numberOfCardsToDeal)
		{
			for (int i = 0; i < numberOfCardsToDeal; i++)
			{
				object content = new CardNetworking(CharacterDeck[0].GetTitle(), playerIndex, Constants.CHARACTER_CARD);
				sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
				dealSpecificCharacterToPlayerFromDeck(playerIndex, CharacterDeck[0].GetTitle());
			}
		}

		public void DealNextRelicSpoilsToPlayer(int playerIndex)
		{
			for (int i = 0; i < SpoilsDeck.Count; i++)
			{
				if (SpoilsDeck[i].GetIsRelic())
				{
					object content = new CardNetworking(SpoilsDeck[i].GetTitle(), playerIndex, Constants.SPOILS_CARD);
					sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
					dealSpecificSpoilToPlayerFromDeck(playerIndex, SpoilsDeck[i].GetTitle());
					break;
				}
			}
		}

		public bool DealNextMasterCharacterToPlayer(int playerIndex)
		{
			bool characterDealt = false;
			for (int i = 0; i < CharacterDeck.Count; i++)
			{
				if (CharacterDeck[i].GetIsMaster())
				{
					object content = new CardNetworking(CharacterDeck[i].GetTitle(), playerIndex, Constants.CHARACTER_CARD);
					sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
					dealSpecificCharacterToPlayerFromDeck(playerIndex, CharacterDeck[i].GetTitle());
					characterDealt = true;
					break;
				}
			}
			return characterDealt;
		}

		public void ApplyPsychDamageToWholeParty(int playerIndex, int amountOfDamage)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
				{
					int currentCharacterPsychLeft = Players[playerIndex].GetActiveCharacterRemainingPsych(characterIndex);
					currentCharacterPsychLeft -= amountOfDamage;
					Players[playerIndex].SetActiveCharacterRemainingPsych(characterIndex, currentCharacterPsychLeft);
				}
			}
		}

		public void LoseMostValuableSpoilsThatAreNotVehicle(int playerIndex, int amountOfCardsToLose)
		{
			int mostExpensiveAmount = 0;
			SpoilsCard mostExpensiveCard = null;
			int characterIndexFoundOn = 0;
			bool wasOnCharacter = false;
			bool wasOnVehicle = false;
			bool wasInAuctionHouse = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				//Look through all characters
				for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
				{
					if (Players[playerIndex].GetActiveCharacters()[characterIndex] != null)
					{
						List<SpoilsCard> equippedCharacterSpoils = Players[playerIndex].GetActiveCharacters()[characterIndex].GetEquippedSpoils();
						for (int spoilsIndex = 0; spoilsIndex < equippedCharacterSpoils.Count; spoilsIndex++)
						{
							if (equippedCharacterSpoils[spoilsIndex].GetSellValue() > mostExpensiveAmount)
							{
								mostExpensiveAmount = equippedCharacterSpoils[spoilsIndex].GetSellValue();
								mostExpensiveCard = equippedCharacterSpoils[spoilsIndex];
								wasOnCharacter = true;
								characterIndexFoundOn = characterIndex;
							}
						}
					}
				}
				//Look through vehicle
				if (Players[playerIndex].GetActiveVehicle() != null)
				{
					List<SpoilsCard> equippedVehicleSpoils = Players[playerIndex].GetActiveVehicle().GetEquippedSpoils();
					for (int spoilsIndex = 0; spoilsIndex < equippedVehicleSpoils.Count; spoilsIndex++)
					{
						if (equippedVehicleSpoils[spoilsIndex].GetSellValue() > mostExpensiveAmount)
						{
							mostExpensiveAmount = equippedVehicleSpoils[spoilsIndex].GetSellValue();
							mostExpensiveCard = equippedVehicleSpoils[spoilsIndex];
							wasOnCharacter = false;
							wasOnVehicle = true;
						}
					}
				}
				//Look through auction house
				List<SpoilsCard> auctionHouseSpoils = Players[playerIndex].GetAuctionHouseCards();
				for (int spoilsIndex = 0; spoilsIndex < auctionHouseSpoils.Count; spoilsIndex++)
				{
					if (auctionHouseSpoils[spoilsIndex].GetSellValue() > mostExpensiveAmount)
					{
						mostExpensiveAmount = auctionHouseSpoils[spoilsIndex].GetSellValue();
						mostExpensiveCard = auctionHouseSpoils[spoilsIndex];
						wasOnCharacter = false;
						wasOnVehicle = false;
						wasInAuctionHouse = true;
					}
				}

				if (wasOnCharacter)
				{
					Players[playerIndex].RemoveSpoilsCardFromActiveCharacter(characterIndexFoundOn, mostExpensiveCard);
					DiscardedSpoilsDeck.Add(mostExpensiveCard);
				}
				else if (wasOnVehicle)
				{
					Players[playerIndex].RemoveStowableFromActiveVehicle(mostExpensiveCard);
					DiscardedSpoilsDeck.Add(mostExpensiveCard);
				}
				else if (wasInAuctionHouse)
				{
					Players[playerIndex].RemoveSpoilsCardFromAuctionHouse(mostExpensiveCard);
					DiscardedSpoilsDeck.Add(mostExpensiveCard);
				}

				if (playerIndex == GetIndexForMyPlayer())
				{
					EventManager.SpoilsCardDiscard(mostExpensiveCard);
				}
			}
		}

		public void DistributeD6PhysicalDamageToParty(int playerIndex, int numOfD6s)
		{
			if (playerIndex == GetIndexForMyPlayer())
			{
				EventManager.D6DamageNeedsDistributing(numOfD6s); //TODO specify it's physical damage
			}
		}

		public void DistributeD6InfectedDamageToParty(int playerIndex, int numOfD6s)
		{
			if (playerIndex == GetIndexForMyPlayer())
			{
				EventManager.D6DamageNeedsDistributing(numOfD6s); //TODO specify it's infected damage
			}
		}

		public void DistributeD6HealingPhysicalDamage(int playerIndex, int numOfD6s)
		{
			if (playerIndex == GetIndexForMyPlayer())
			{
				EventManager.D6HealingNeedsDistributing(numOfD6s); //TODO specify it's physical damage
			}
		}

		public virtual void DealSpecificSpoilToPlayer(int playerIndex, string cardName)
        {
			object content = new CardNetworking(cardName, playerIndex, Constants.SPOILS_CARD);
			sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
			dealSpecificSpoilToPlayerFromDeck(playerIndex, cardName);
		}

		public void DealSpecificSpecialSpoilToPlayer(int playerIndex, string cardName)
		{
			object content = new CardNetworking(cardName, playerIndex, Constants.SPECIAL_SPOILS_CARD);
			sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
			dealSpecificSpoilToPlayerFromSpecialDeck(playerIndex, cardName);
		}

		public virtual void DealSpecificSpoilToPlayerFromDiscardPile(int playerIndex, string cardName)
		{
			object content = new CardNetworking(cardName, playerIndex, Constants.DISCARDED_SPOILS_CARD);
			sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
			dealSpecificSpoilToPlayerFromDiscardDeck(playerIndex, cardName);
		}

		public int RollTownEvents(int playerIndex)
		{
			int d10Roll = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				d10Roll = DiceRoller.RollDice(Constants.D10);
				object content = new TownEventNetworking(GetIndexForMyPlayer(), d10Roll);
				sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvTownEventRoll);
				handleTownEventRoll(GetIndexForMyPlayer(), d10Roll);
			}

			return d10Roll;
		}

		public bool GetIsItMyTurn()
		{
			bool isItMyTurn = false;

            if (IsMyPhaseEnded)
            {
				isItMyTurn = false;
            }
			else if (PhasesHelpers.IsAsyncPhase(CurrentPhase) || (GetCurrentPlayer() != null && GetCurrentPlayer().UserId == MyUserId))
			{
				isItMyTurn = true;
			}

			return isItMyTurn;
		}

		public void SetPlayerIsMoving(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].SetPlayerIsMoving(true);
				MouseManagerInst.ClearLastHexClickedCoodinates();
			}
		}

		public bool GetPlayerIsMoving(int playerIndex)
		{
			bool playerIsMoving = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				playerIsMoving = Players[playerIndex].GetPlayerIsMoving();
			}
			return playerIsMoving;
		}

		public Coordinates GetPartyLocation(int playerIndex)
		{
			Coordinates location = null;
			if (isPlayerIndexInRange(playerIndex))
			{
				location = Players[playerIndex].GetPartyLocation();
			}
			return location;
		}

		public void SetPlayerIsDoingAnEncounter(int playerIndex, byte encounterType)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].SetPlayerIsDoingAnEncounter(true);
				Players[playerIndex].SetEncounterType(encounterType);
			}
		}

		public bool GetPlayerIsDoingAnEncounter(int playerIndex)
		{
			bool isDoing = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				isDoing = Players[playerIndex].GetPlayerIsDoingAnEncounter();
			}
			return isDoing;
		}

		public int GetPlayerEncounterType(int playerIndex)
		{
			int encounterType = Constants.ENCOUNTER_NONE;
			if (isPlayerIndexInRange(playerIndex))
			{
				encounterType = Players[playerIndex].GetEncounterType();
			}
			return encounterType;
		}

		public int GetSkillTotalForCharacter(int playerIndex, int characterIndex, Skills skill)
		{
			int skillValue = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				skillValue = Players[playerIndex].GetTotalForCharacterSkill(characterIndex, skill);
			}
			return skillValue;
		}

		public int GetSkillTotalForVehicle(int playerIndex, Skills skill)
		{
			int skillValue = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				skillValue = Players[playerIndex].GetTotalForVehicleSkill(skill);
			}
			return skillValue;
		}

		public int GetCharacterAutoSuccesses(int playerIndex, int characterIndex, Skills skill)
		{
			int autoSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				autoSuccesses = Players[playerIndex].GetCharacterAutoSuccesses(characterIndex, skill);
			}
			return autoSuccesses;
		}

		public int GetCharacterRolledSuccesses(int playerIndex, int characterIndex, Skills skill)
		{
			int rolledSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				rolledSuccesses = Players[playerIndex].GetCharacterRolledSuccesses(characterIndex, skill);
			}
			return rolledSuccesses;
		}

		public int GetVehicleAutoSuccesses(int playerIndex, Skills skill)
		{
			int autoSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				autoSuccesses = Players[playerIndex].GetVehicleAutoSuccesses(skill);
			}
			return autoSuccesses;
		}

		public int GetVehicleRolledSuccesses(int playerIndex, Skills skill)
		{
			int rolledSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				rolledSuccesses = Players[playerIndex].GetVehicleRolledSuccesses(skill);
			}
			return rolledSuccesses;
		}

		public int GetTotalSuccesses(int playerIndex, Skills skill)
		{
			int totalSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				totalSuccesses = Players[playerIndex].GetTotalSuccesses(skill);
			}
			return totalSuccesses;
		}

		public int GetLastCharacterRoll(int playerIndex, int characterIndex, Skills skill)
		{
			int lastRoll = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				lastRoll = Players[playerIndex].GetLastCharacterDiceRoll(characterIndex, skill);
			}
			return lastRoll;
		}

		public int GetLastVehicleRoll(int playerIndex, Skills skill)
		{
			int lastRoll = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				lastRoll = Players[playerIndex].GetLastVehicleDiceRoll(skill);
			}
			return lastRoll;
		}

		public void RollCharacterEncounter(int playerIndex, int characterIndex, Skills skill)
		{
			int diceRoll = DiceRoller.RollDice(Constants.D10);
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddCharacterDiceRoll(characterIndex, skill, diceRoll);
			}
		}

		public void RollVehicleEncounter(int playerIndex, Skills skill)
		{
			int diceRoll = DiceRoller.RollDice(Constants.D10);
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddVehicleDiceRoll(skill, diceRoll);
			}
		}

		public bool DoesCharacterHaveRollsRemainingForSkill(int playerIndex, int characterIndex, Skills skill)
		{
			bool hasRemaining = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				int lastRoll = Players[playerIndex].GetLastCharacterDiceRoll(characterIndex, skill);
                if (lastRoll == Constants.HAS_NOT_ROLLED || lastRoll == Constants.CRIT_SUCCESS)
                {
					hasRemaining = true;
				}
			}
            return hasRemaining;
		}

        public bool DoesVehicleHaveRollsRemainingForSkill(int playerIndex, Skills skill)
        {
			bool hasRemaining = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				int lastRoll = Players[playerIndex].GetLastVehicleDiceRoll(skill);
				if (lastRoll == Constants.HAS_NOT_ROLLED || lastRoll == Constants.CRIT_SUCCESS)
				{
					hasRemaining = true;
				}
			}
			return hasRemaining;
		}

		public bool IsEncounterFinished(int playerIndex)
		{
			bool isFinished = true;

			if (isPlayerIndexInRange(playerIndex))
			{
                if (!EncounterWasSuccessful(playerIndex))
                {
					//Check all characters
					for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
					{
						foreach (Skills skill in CurrentPlayerEncounter[playerIndex].GetSkillChecks().Keys)
						{
							if (DoesCharacterHaveRollsRemainingForSkill(playerIndex, characterIndex, skill))
							{
								isFinished = false;
								break;
							}
						}
					}

					//Check vehicle
					foreach (Skills skill in CurrentPlayerEncounter[playerIndex].GetSkillChecks().Keys)
					{
						if (DoesVehicleHaveRollsRemainingForSkill(playerIndex, skill))
						{
							isFinished = false;
							break;
						}
					}
				}
			}

			return isFinished;
		}

		public bool EncounterWasSuccessful(int playerIndex)
		{
			bool wasSuccessful = true;

			if (isPlayerIndexInRange(playerIndex))
			{
				Dictionary<Skills, int> skillChecks = CurrentPlayerEncounter[playerIndex].GetSkillChecks();
				foreach (Skills skill in skillChecks.Keys)
				{
					if (GetTotalSuccesses(playerIndex, skill) < skillChecks[skill])
					{
						wasSuccessful = false;
						break;
					}
				}
			}

			return wasSuccessful;
		}

		public void SetEncounterResultAccepted(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				byte status = (EncounterWasSuccessful(playerIndex)) ? Constants.STATUS_PASSED : Constants.STATUS_FAILED;
				EncounterStatusNetworking encounterStatus = new EncounterStatusNetworking(playerIndex, (byte)GetPlayerEncounterType(playerIndex), status, CurrentPlayerEncounter[playerIndex].GetTitle());
				sendNetworkEvent(encounterStatus, ReceiverGroup.Others, Constants.EvEncounterStatus);
				handleEncounterStatusEvent(encounterStatus);
			}
		}

		public void AddSalvageAtStartOfEncounter(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				EncounterStatusNetworking encounterStatus = new EncounterStatusNetworking(playerIndex, (byte)GetPlayerEncounterType(playerIndex), Constants.STATUS_BEGIN, CurrentPlayerEncounter[playerIndex].GetTitle());
				sendNetworkEvent(encounterStatus, ReceiverGroup.Others, Constants.EvEncounterStatus);
				handleEncounterStatusEvent(encounterStatus);
			}
		}

		public void GainPrestige(int playerIndex, int prestigeAmount)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddPrestige(prestigeAmount);
			}
		}

		public void GainTownHealth(int playerIndex, int townHealthAmount)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddTownHealth(townHealthAmount);
			}
		}

		public void GainSalvageCoins(int playerIndex, int amountToGain)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddSalvageToPlayer(amountToGain);
			}
		}

		public void LosePrestige(int playerIndex, int prestigeAmount)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].SubtractPrestige(prestigeAmount);
			}
		}

		public void LoseTownHealth(int playerIndex, int townHealthAmount)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].SubtractTownHealth(townHealthAmount);
			}
		}

		public void EveryoneLoseTownHealth(int townHealthAmount)
		{
			for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
			{
				Players[playerIndex].SubtractTownHealth(townHealthAmount);
			}
		}

		public void GainPartyExploitsWeeks(int playerIndex, int weeksToGain)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				int currentRemainingWeeks = Players[playerIndex].GetRemainingPartyExploitWeeks();
				currentRemainingWeeks += weeksToGain;
				Players[playerIndex].SetRemainingPartyExploitWeeks(currentRemainingWeeks);
			}
		}

		public void MovePartyToStartingTownLocation(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Coordinates startingTownLocation = Players[playerIndex].GetPlayerFaction().GetBaseLocation();
				MovementNetworking movement = new MovementNetworking(playerIndex, Constants.PARTY_MOVEMENT, startingTownLocation);
				sendNetworkEvent(movement, ReceiverGroup.Others, Constants.EvMovement);
				handleMovementNetworkEvent(movement);
			}
		}

		public void HandleActionsOnBegin()
		{
			int myIndex = GetIndexForMyPlayer();
			if (CurrentPlayerEncounter[myIndex] != null && CurrentPlayerEncounter[myIndex].GetActionsOnBegin().Count > 0)
			{
				for (int i = 0; i < CurrentPlayerEncounter[myIndex].GetActionsOnBegin().Count; i++)
				{
					CurrentPlayerEncounter[myIndex].GetActionsOnBegin()[i].HandleAction(this, myIndex);
				}
			}
		}

		public void DealSetAmountOfInfectedDamageToParty(int playerIndex, int amountOfDamage)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
				{
					Players[playerIndex].AddInfectedDamageToCharacter(characterIndex, amountOfDamage);
				}
			}
		}

		public bool CharacterHasInfectedDamage(int playerIndex, int characterIndex)
		{
			bool hasInfected = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				hasInfected = Players[playerIndex].CharacterHasInfectedDamage(characterIndex);
			}

			return hasInfected;
		}

		public void CharacterCrownTakesD6Damage(int playerIndex, int characterIndex, int numOfD6s, byte damageType)
        {
			if (isPlayerIndexInRange(playerIndex))
            {
				int damage = 0;
				for (int i = 0; i < numOfD6s; i++)
				{
					damage += DiceRoller.RollDice(Constants.D6);
				}
				CharacterHealthNetworking characterHealth = new CharacterHealthNetworking(playerIndex, characterIndex, damageType, damage, false);
				sendNetworkEvent(characterHealth, ReceiverGroup.Others, Constants.EvCharacterHealth);
				int remainingHp = -1;
				if (Players[playerIndex].GetActiveCharacters()[characterIndex] != null)
				{
					remainingHp = Players[playerIndex].GetActiveCharacters()[characterIndex].GetHpRemaining() - damage;
				}
				handleCharacterHealthEvent(characterHealth);
				EventManager.CharacterCrownHasTakenDamage(characterIndex, damage, damageType, remainingHp, false);
			}
		}

		public void CharacterCrownTakesSetAmountOfDamage(int playerIndex, int characterIndex, int amountOfDamage, byte damageType)
		{
			if (isPlayerIndexInRange(playerIndex))
            {
				CharacterHealthNetworking characterHealth = new CharacterHealthNetworking(playerIndex, characterIndex, damageType, amountOfDamage, false);
				sendNetworkEvent(characterHealth, ReceiverGroup.Others, Constants.EvCharacterHealth);
				int remainingHp = -1;
				if (Players[playerIndex].GetActiveCharacters()[characterIndex] != null)
				{
					remainingHp = Players[playerIndex].GetActiveCharacters()[characterIndex].GetHpRemaining() - amountOfDamage;
				}
				handleCharacterHealthEvent(characterHealth);
				EventManager.CharacterCrownHasTakenDamage(characterIndex, amountOfDamage, damageType, remainingHp, false);
			}
		}

		public void DestroyVehicle(int playerIndex)
		{
            if (isPlayerIndexInRange(playerIndex))
            {
				//Discard all the spoils attached to the vehicle
				SpoilsCard vehicle = Players[playerIndex].GetActiveVehicle();
				if(vehicle != null)
                {
					List<SpoilsCard> stowedSpoils = vehicle.GetAttachments();
					for (int spoilsIndex = stowedSpoils.Count - 1; spoilsIndex >= 0; spoilsIndex--)
					{
						SpoilsCard currentStowable = stowedSpoils[spoilsIndex];
						removeSpecificSpoilsFromVehicle(playerIndex, currentStowable.GetTitle());
						SpoilsDeck.Remove(currentStowable);
						DiscardedSpoilsDeck.Add(currentStowable);
					}

					//Discard the vehicle
					Players[playerIndex].RemoveActiveVehicle();
					DiscardedSpoilsDeck.Add(vehicle);

					if (playerIndex == GetIndexForMyPlayer())
					{
						EventManager.VehicleIsDestroyed();
					}
				}
			}
		}

		public void CharacterCrownDiesAndLosesEquipment(int playerIndex, int characterCrownIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				CharacterHealthNetworking healthNetworking = new CharacterHealthNetworking(playerIndex, characterCrownIndex, Constants.DAMAGE_PHYSICAL, 1000, true);
				sendNetworkEvent(healthNetworking, ReceiverGroup.Others, Constants.EvCharacterHealth);
				int remainingHp = (Players[playerIndex].GetActiveCharacters()[characterCrownIndex] != null) ? 0 : -1;
				handleCharacterHealthEvent(healthNetworking);
				EventManager.CharacterCrownHasTakenDamage(characterCrownIndex, 1000, Constants.DAMAGE_PHYSICAL, remainingHp, true);
			}
		}

		public bool IsSpecificCardInSpoilsDeck(string cardName)
		{
			bool isInDeck = false;

			for (int i = 0; i < SpoilsDeck.Count; i++)
			{
				if (SpoilsDeck[i].GetTitle().Equals(cardName))
				{
					isInDeck = true;
					break;
				}
			}

			return isInDeck;
		}

		public bool IsSpecificCardInDiscardedSpoilsDeck(string cardName)
		{
			bool isInDeck = false;

			for (int i = 0; i < DiscardedSpoilsDeck.Count; i++)
			{
				if (DiscardedSpoilsDeck[i].GetTitle().Equals(cardName))
				{
					isInDeck = true;
					break;
				}
			}

			return isInDeck;
		}

		public Dice GetDiceRoller()
		{
			return DiceRoller;
		}
		#endregion












		#region HelperFunctions
		private void extractGameModeFromGameCreationObject(GameObject newGameState)
		{
			GameMode = newGameState.GetComponent<GameCreation>().GetMode();
		}

		private void dealCardsToPlayers()
		{
			if (PhotonNetwork.IsMasterClient)
			{
				Debug.Log("dealCardsToPlayers as master");
				dealSpoilsCardsToPlayers();
				dealCharacterCardsToPlayers();
				dealActionCardsToPlayers();
			}
		}

		//Only called by master client
		private void dealSpoilsCardsToPlayers()
		{
			moveStartingCardsToTheEndOfTheDeck(); //Ensure we don't deal away someone's starting card
			for (int i = 0; i < StartingSpoilsCards; i++)
			{
				for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
				{
					Players[playerIndex].AddSpoilsCardToAuctionHouse(SpoilsDeck[0]);
					Debug.Log("Dealt spoils card " + SpoilsDeck[0].GetTitle());
					object content = new CardNetworking(SpoilsDeck[0].GetTitle(), playerIndex, Constants.SPOILS_CARD);
					sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
					SpoilsDeck.RemoveAt(0);
				}
			}
			Card.ShuffleDeck(SpoilsDeck);
		}

		private void dealCharacterCardsToPlayers()
		{
			for (int i = 0; i < StartingCharacterCards; i++)
			{
				for (int j = 0; j < Players.Count; j++)
				{
					Players[j].AddCharacterCardToTownRoster(CharacterDeck[0]);
					Debug.Log("Dealt character card " + CharacterDeck[0].GetTitle());
					object content = new CardNetworking(CharacterDeck[0].GetTitle(), j, Constants.CHARACTER_CARD);
					sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
					CharacterDeck.RemoveAt(0);
				}
			}
		}

		private void dealActionCardsToPlayers()
		{
			for (int i = 0; i < StartingActionCards; i++)
			{
				for (int j = 0; j < Players.Count; j++)
				{
					Players[j].AddActionCardToHand(ActionDeck[0]);
					Debug.Log("Dealt action card " + ActionDeck[0].GetTitle());
					object content = new CardNetworking(ActionDeck[0].GetTitle(), j, Constants.ACTION_CARD);
					sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
					ActionDeck.RemoveAt(0);
				}
			}
		}

		private void moveStartingCardsToTheEndOfTheDeck()
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

		private void dealSpecificSpoilToPlayerFromDeck(int playerIndex, string cardName)
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

		private void dealSpecificSpoilToPlayerFromDiscardDeck(int playerIndex, string cardName)
		{
			bool found = false;
			for (int i = 0; i < DiscardedSpoilsDeck.Count; i++)
			{
				if (DiscardedSpoilsDeck[i].GetTitle() == cardName)
				{
					Players[playerIndex].AddSpoilsCardToAuctionHouse(DiscardedSpoilsDeck[i]);
					DiscardedSpoilsDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to deal specific DISCARDED SPOILS card " + cardName + " to player, but it was not found in the deck");
			}
		}

		private void dealSpecificSpoilToPlayerFromSpecialDeck(int playerIndex, string cardName)
		{
			bool found = false;
			for (int i = 0; i < SpecialSpoilsDeck.Count; i++)
			{
				if (SpecialSpoilsDeck[i].GetTitle() == cardName)
				{
					Players[playerIndex].AddSpoilsCardToAuctionHouse(SpecialSpoilsDeck[i]);
					SpecialSpoilsDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to deal specific SPECIAL SPOILS card " + cardName + " to player, but it was not found in the deck");
			}
		}

		private void dealSpecificCharacterToPlayerFromDeck(int playerIndex, string cardName)
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

		private void dealSpecificActionCardToPlayerFromDeck(int playerIndex, string cardName)
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

		private void removeSpecificCardFromTownRoster(int playerIndex, string cardName)
		{
			bool found = false;
			List<CharacterCard> townRoster = GetTownRoster(playerIndex);
			for (int i = 0; i < townRoster.Count; i++)
			{
				if (townRoster[i].GetTitle() == cardName)
				{
					CharacterCard characterCard = townRoster[i];
					Players[playerIndex].RemoveCharacterFromTownRoster(characterCard);
					CharacterDeck.Add(characterCard); //TODO something else with this later, like a temp holding place
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to remove specific character card " + cardName + " from player town roster, but it was not found");
			}
		}

		private void removeSpecificCardFromAuctionHouse(int playerIndex, string cardName)
		{
			bool found = false;
			List<SpoilsCard> auctionHouse = GetAuctionHouse(playerIndex);
			for (int i = 0; i < auctionHouse.Count; i++)
			{
				if (auctionHouse[i].GetTitle() == cardName)
				{
					SpoilsCard spoilsCard = auctionHouse[i];
					Players[playerIndex].RemoveSpoilsCardFromAuctionHouse(spoilsCard);
					SpoilsDeck.Add(spoilsCard); //TODO something else with this later, like a temp holding place
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to remove specific spoils card " + cardName + " from player auction house, but it was not found");
			}
		}

		private void removeSpecificSpoilsFromSlot(int playerIndex, int slotIndex, string cardName)
		{
			bool found = false;
			List<SpoilsCard> equippedCards = Players[playerIndex].GetActiveCharacters()[slotIndex].GetEquippedSpoils();
			for (int i = 0; i < equippedCards.Count; i++)
			{
				if (equippedCards[i].GetTitle() == cardName)
				{
					SpoilsCard spoilsCard = equippedCards[i];
					Players[playerIndex].RemoveSpoilsCardFromActiveCharacter(slotIndex, equippedCards[i]);
					SpoilsDeck.Add(spoilsCard); //TODO don't add to the deck but rather some temp place
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to remove specific spoils " + cardName + " from player slot, but it was not found");
			}
		}

		private void removeSpecificSpoilsFromVehicle(int playerIndex, string cardName)
		{
			bool found = false;
			List<SpoilsCard> stowables = Players[playerIndex].GetActiveVehicle().GetEquippedSpoils();
			for (int i = 0; i < stowables.Count; i++)
			{
				if (stowables[i].GetTitle() == cardName)
				{
					SpoilsCard stowable = stowables[i];
					Players[playerIndex].RemoveStowableFromActiveVehicle(stowables[i]);
					SpoilsDeck.Add(stowable); //TODO don't add to spoils deck. Store in temp location
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to remove specific spoils " + cardName + " from vehicle slot, but it was not found");
			}
		}

		private void addSpecificCharacterToSlot(int playerIndex, int slotIndex, string cardName)
		{
			bool found = false;
			for (int i = 0; i < CharacterDeck.Count; i++) //TODO don't grab from deck but some temp location (rework removeSpecificCardFromTownRoster)
			{
				if (CharacterDeck[i].GetTitle() == cardName)
				{
					Players[playerIndex].AddCharacterToParty(slotIndex, CharacterDeck[i]);
					CharacterDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to add specific character " + cardName + " to player slot, but it was not found");
			}
		}

		private void addSpecificSpoilsToSlot(int playerIndex, int slotIndex, string cardName)
		{
			bool found = false;
			for (int i = 0; i < SpoilsDeck.Count; i++) //TODO don't grab from deck but some temp location (rework removeSpecificCardFromTownRoster)
			{
				if (SpoilsDeck[i].GetTitle() == cardName)
				{
					Players[playerIndex].AddSpoilsToCharacter(slotIndex, SpoilsDeck[i]);
					SpoilsDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to add specific spoils " + cardName + " to player slot, but it was not found");
			}
		}

		private void addSpecificSpoilsToVehicle(int playerIndex, string cardName)
		{
			bool found = false;
			for (int i = 0; i < SpoilsDeck.Count; i++) //TODO don't grab from deck but some temp location
			{
				if (SpoilsDeck[i].GetTitle() == cardName)
				{
					Players[playerIndex].AddSpoilsToActiveVehicle(SpoilsDeck[i]);
					SpoilsDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to add specific spoils " + cardName + " to vehicle slot, but it was not found");
			}
		}

		private void addSpecificCardToTownRoster(int playerIndex, string cardName)
		{
			bool found = false;
			for (int i = 0; i < CharacterDeck.Count; i++)
			{
				if (CharacterDeck[i].GetTitle() == cardName)
				{
					CharacterCard characterCard = CharacterDeck[i];
					Players[playerIndex].AddCharacterCardToTownRoster(characterCard);
					CharacterDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to add specific character card " + cardName + " to player town roster, but it was not found");
			}
		}

        private void addSpecificCardToAuctionHouse(int playerIndex, string cardName)
		{
			bool found = false;
			for (int i = 0; i < SpoilsDeck.Count; i++)
			{
				if (SpoilsDeck[i].GetTitle() == cardName)
				{
					SpoilsCard spoilsCard = SpoilsDeck[i];
					Players[playerIndex].AddSpoilsCardToAuctionHouse(spoilsCard);
					SpoilsDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to add specific spoils card " + cardName + " to player auction house, but it was not found");
			}
		}

		private void addSpecificVehicleToParty(int playerIndex, string cardName)
		{
			bool found = false;
			for (int i = 0; i < SpoilsDeck.Count; i++)
			{
				if (SpoilsDeck[i].GetTitle() == cardName)
				{
					SpoilsCard spoilsCard = SpoilsDeck[i];
					Players[playerIndex].AddVehicleToParty(spoilsCard);
					SpoilsDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.Log("Tried to add specific vehicle card " + cardName + " to player party, but it was not found");
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

		private bool isAllowedToMoveHere(int playerIndex, Coordinates coords)
		{
			//TODO implement this function
			return true;
		}

		private void generateMissionLocations()
		{
			List<int> randomLocations = new List<int>();
			for (int missionNumber = 1; missionNumber <= NumberOfMissions; missionNumber++)
			{
				int missionLocation;
				do
				{
					missionLocation = DiceRoller.RollDice(Constants.D100);
				} while (randomLocations.Contains(missionLocation));

				randomLocations.Add(missionLocation);
				MissionManagerInst.AddMissionLocation(missionNumber, missionLocation);
			}
		}

		private void sendMissionLocationsToOtherPlayers()
		{
			List<int> randomNumberLocations = MissionManagerInst.GetRandomNumberLocations();
			for (int currentMissionIndex = 0; currentMissionIndex < randomNumberLocations.Count; currentMissionIndex++)
			{
				object content = new MissionLocationNetworking(currentMissionIndex + 1, randomNumberLocations[currentMissionIndex]);
				sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvMissionLocation);
			}
		}

        private void handleTownEventRoll(int playerIndex, int townEventRoll)
        {
			switch (townEventRoll)
			{
				case 1:
					//Gain 2 prestige, 4 town health, and 1 action/spoils/character (pick 1)
					//TODO deal the card after the user picks which
					Players[playerIndex].AddPrestige(2);
					Players[playerIndex].AddTownHealth(4);
					break;
				case 2:
					Players[playerIndex].AddPrestige(1);
					Players[playerIndex].AddTownHealth(2);
					break;
				case 3:
					Players[playerIndex].AddTownHealth(1);
					break;
				case 4:
				case 5:
				case 6:
				case 7:
					//No effect
					break;
				case 8:
					Players[playerIndex].SubtractTownHealth(1);
					break;
				case 9:
					Players[playerIndex].SubtractPrestige(1);
					Players[playerIndex].SubtractTownHealth(2);
					break;
				case 10:
					//Lose 1 resource of your choosing
					//TODO for now, no effect
					break;
				default:
					//No efect
					break;
			}
		}

		private void handlePartyExploitsMovement(int playerIndex, Coordinates coords)
		{
			int previousWeeksRemaining = Players[playerIndex].GetRemainingPartyExploitWeeks();
			Players[playerIndex].SetRemainingPartyExploitWeeks(previousWeeksRemaining - MovementWeekCost);
			PlayerPieceManagerInst.MovePiece(playerIndex, coords);
			Players[playerIndex].SetPartyLocation(coords);
		}

		private void handlePartyExploitsEncounter(int playerIndex, byte encounterType, string encounterCardName)
		{
			if (encounterType == Constants.ENCOUNTER_PLAINS)
			{
				CurrentPlayerEncounter[playerIndex] = PlainsCard.FindCardInDeckByTitle(encounterCardName, PlainsDeck);
				if (CurrentPlayerEncounter[playerIndex] == null)
				{
					Debug.LogError("Error. Couldn't find plains encounter card with title " + encounterCardName);
				}
			}
			else if (encounterType == Constants.ENCOUNTER_MOUNTAINS)
			{
				//TODO when this deck is implemented
			}
			else if (encounterType == Constants.ENCOUNTER_CITY_RAD)
			{
				//TODO when this deck is implemented
			}
		}

		private void handleEncounterStatusEvent(EncounterStatusNetworking eventStatus)
		{
			int playerIndex = eventStatus.GetPlayerIndex();
			byte status = eventStatus.GetStatus();

			if (isPlayerIndexInRange(playerIndex))
			{
                if (status == Constants.STATUS_BEGIN)
                {
					Players[playerIndex].AddSalvageToPlayer(CurrentPlayerEncounter[playerIndex].GetSalvageReward());
                }
                else if (status == Constants.STATUS_FAILED || status == Constants.STATUS_PASSED)
                {
					//todo encounter card from deck and place it into discard once more encounters are implemented
					Players[playerIndex].SetPlayerIsDoingAnEncounter(false);
					Players[playerIndex].SetEncounterType(Constants.ENCOUNTER_NONE);
					EncounterWasSent = false;

					int previousWeeksRemaining = Players[playerIndex].GetRemainingPartyExploitWeeks();
					Players[playerIndex].SetRemainingPartyExploitWeeks(previousWeeksRemaining - EncounterWeekCost);

					if (status == Constants.STATUS_PASSED)
					{
						EncounterResultsHandler.HandleSuccess(this, playerIndex);
					}
					else
					{
						EncounterResultsHandler.HandleFailure(this, playerIndex);
					}

					Players[playerIndex].ResetAllCharacterDiceRolls();
					Players[playerIndex].ResetAllVehicleDiceRolls();

                    if (eventStatus.GetEncounterType() == Constants.ENCOUNTER_PLAINS)
                    {
						PlainsCard card = PlainsCard.FindCardInDeckByTitle(eventStatus.GetCardName(), PlainsDeck);
						DiscardedPlainsCards.Add(card);
                        PlainsDeck.Remove(card);
                        CurrentPlayerEncounter[playerIndex] = null;
                    }
                    else if (eventStatus.GetEncounterType() == Constants.ENCOUNTER_MOUNTAINS)
                    {
						//TODO when implemented
                    }
					else if (eventStatus.GetEncounterType() == Constants.ENCOUNTER_CITY_RAD)
					{
						//TODO when implemented
                    }

					shuffleEncounterDecksIfNeeded();
				}
			}
		}

		private void registerPhotonCallbacks()
		{
			PhotonPeer.RegisterType(typeof(CardNetworking), Constants.EvDealCard, CardNetworking.SerializeCard, CardNetworking.DeserializeCard);
			PhotonPeer.RegisterType(typeof(FactionNetworking), Constants.EvSendFactionInformation, FactionNetworking.SerializeFaction, FactionNetworking.DeserializeFaction);
			PhotonPeer.RegisterType(typeof(PlayerCardNetworking), Constants.EvSendPlayerInformation, PlayerCardNetworking.SerializePlayerCard, PlayerCardNetworking.DeserializePlayerCard);
			PhotonPeer.RegisterType(typeof(PlayerCardNetworking), Constants.EvRequestUpdateToPlayerInformation, PlayerCardNetworking.SerializePlayerCard, PlayerCardNetworking.DeserializePlayerCard);
			PhotonPeer.RegisterType(typeof(MissionLocationNetworking), Constants.EvMissionLocation, MissionLocationNetworking.SerializeMissionLocation, MissionLocationNetworking.DeserializeMissionLocation);
			PhotonPeer.RegisterType(typeof(TownEventNetworking), Constants.EvTownEventRoll, TownEventNetworking.SerializeTownEventRoll, TownEventNetworking.DeserializeTownEventRoll);
			PhotonPeer.RegisterType(typeof(PartyExploitsNetworking), Constants.EvPartyExploits, PartyExploitsNetworking.SerializePartyExploits, PartyExploitsNetworking.DeserializePartyExploits);
			PhotonPeer.RegisterType(typeof(EncounterStatusNetworking), Constants.EvEncounterStatus, EncounterStatusNetworking.SerializeEncounterStatus, EncounterStatusNetworking.DeserializeEncounterStatus);
			PhotonPeer.RegisterType(typeof(MovementNetworking), Constants.EvMovement, MovementNetworking.SerializeMovement, MovementNetworking.DeserializeMovement);
			PhotonPeer.RegisterType(typeof(CharacterHealthNetworking), Constants.EvCharacterHealth, CharacterHealthNetworking.SerializeCharacterHealth, CharacterHealthNetworking.DeserializeCharacterHealth);
		}

		private void sendNetworkEvent(object content, ReceiverGroup group, byte eventCode)
		{		
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = group };
			SendOptions sendOptions = new SendOptions { Reliability = true };
			PhotonNetwork.RaiseEvent(eventCode, content, raiseEventOptions, sendOptions);
		}

		private void handlePlayerNetworkUpdate(PlayerCardNetworking playerInfo)
		{
			int playerIndex = playerInfo.GetPlayerIndex();
			if (playerIndex == GetIndexForMyPlayer())
			{
				return;
			}
			string cardName = playerInfo.GetCardName();
			int slotIndex = playerInfo.GetSlotIndex();
            if (playerInfo.GetActionByte() == Constants.REMOVE_FROM_TOWN_ROSTER)
            {
                removeSpecificCardFromTownRoster(playerIndex, cardName);
            }
            else if (playerInfo.GetActionByte() == Constants.REMOVE_FROM_AUCTION_HOUSE)
            {
				removeSpecificCardFromAuctionHouse(playerIndex, cardName);
            }
            else if (playerInfo.GetActionByte() == Constants.ADD_CHARACTER_TO_SLOT)
            {
                addSpecificCharacterToSlot(playerIndex, slotIndex, cardName);
            }
            else if (playerInfo.GetActionByte() == Constants.REMOVE_CHARACTER_FROM_SLOT)
            {
				CharacterCard character = Players[playerIndex].GetActiveCharacters()[slotIndex];
				Players[playerIndex].RemoveCharacterFromParty(slotIndex);
				CharacterDeck.Add(character); //TODO don't add to character deck
			}
            else if (playerInfo.GetActionByte() == Constants.ADD_VEHICLE)
            {
				addSpecificVehicleToParty(playerIndex, cardName);
            }
            else if (playerInfo.GetActionByte() == Constants.REMOVE_VEHICLE)
            {
				SpoilsCard vehicle = Players[playerIndex].GetActiveVehicle();
				Players[playerIndex].RemoveActiveVehicle();
				SpoilsDeck.Add(vehicle); //TODO don't add to spoils deck
			}
            else if (playerInfo.GetActionByte() == Constants.ADD_SPOILS_TO_SLOT)
            {
				addSpecificSpoilsToSlot(playerIndex, slotIndex, cardName);
            }
            else if (playerInfo.GetActionByte() == Constants.REMOVE_SPOILS_FROM_SLOT)
            {
				removeSpecificSpoilsFromSlot(playerIndex, slotIndex, cardName);
			}
            else if (playerInfo.GetActionByte() == Constants.ADD_SPOILS_TO_VEHICLE)
            {
				addSpecificSpoilsToVehicle(playerIndex, cardName);
            }
            else if (playerInfo.GetActionByte() == Constants.REMOVE_SPOILS_FROM_VEHICLE)
            {
				removeSpecificSpoilsFromVehicle(playerIndex, cardName);
            }
            else if (playerInfo.GetActionByte() == Constants.ADD_TO_TOWN_ROSTER)
            {
				addSpecificCardToTownRoster(playerIndex, cardName);
			}
			else if (playerInfo.GetActionByte() == Constants.ADD_TO_AUCTION_HOUSE)
            {
				addSpecificCardToAuctionHouse(playerIndex, cardName);
			}

			GameObject.Find("UIManager").GetComponent<GameUIManager>().ForceRedrawCharacterScreen();
		}

		private void handleNetworkingUpdatePlayerInfo(object content)
		{
			if (!PhotonNetwork.IsMasterClient)
			{
				sendNetworkEvent(content, ReceiverGroup.MasterClient, Constants.EvRequestUpdateToPlayerInformation);
			}
			else
			{
				sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvSendPlayerInformation);
			}
		}

		private void handleTownEventRollNetworkUpdate(object content)
		{
			TownEventNetworking townEvent = (TownEventNetworking)content;
			handleTownEventRoll(townEvent.GetPlayerIndex(), townEvent.GetTownEventRoll());
		}

		private void handlePartyExploitsNetworkUpdate(object content)
		{
			PartyExploitsNetworking partyExploitsEvent = (PartyExploitsNetworking)content;
			if (partyExploitsEvent.GetPartyExploitsAction() == Constants.PARTY_EXPLOITS_MOVEMENT)
			{
				handlePartyExploitsMovement(partyExploitsEvent.GetPlayerIndex(), partyExploitsEvent.GetMoveToLocation());
			}
			else if (partyExploitsEvent.GetPartyExploitsAction() == Constants.PARTY_EXPLOITS_ENCOUNTER)
			{
				handlePartyExploitsEncounter(partyExploitsEvent.GetPlayerIndex(), partyExploitsEvent.GetEncounterType(), partyExploitsEvent.GetEncounterCardName());
			}
		}

		private void handleMovementNetworkEvent(object content)
		{
			MovementNetworking movement = (MovementNetworking)content;
			if (movement.GetMovementType() == Constants.PARTY_MOVEMENT)
			{
				int playerIndex = movement.GetPlayerIndex();
				Coordinates coords = movement.GetLocationToMoveTo();
				PlayerPieceManagerInst.MovePiece(playerIndex, coords);
				Players[playerIndex].SetPartyLocation(coords);
			}
		}

		private void handleCharacterHealthEvent(object content)
		{
			CharacterHealthNetworking characterHealth = (CharacterHealthNetworking)content;
			int playerIndex = characterHealth.GetPlayerIndex();
			int characterIndex = characterHealth.GetCharacterIndex();
			if (characterHealth.GetDamageType() == Constants.DAMAGE_PHYSICAL)
			{
				Players[playerIndex].AddPhysicalDamageToCharacter(characterIndex, characterHealth.GetAmountOfDamage());
			}

			handleCharacterDeathIfNecessary(playerIndex, characterIndex, characterHealth.GetShouldDiscardEquipmentIfDead());
		}

		private void handleCharacterDeathIfNecessary(int playerIndex, int characterIndex, bool shouldDiscardEquipmentOnDeath)
		{
			if (Players[playerIndex].GetActiveCharacters()[characterIndex] != null && Players[playerIndex].GetActiveCharacters()[characterIndex].GetHpRemaining() <= 0)
			{
				//Remove spoils
				List<SpoilsCard> equippedSpoilsToMoveBackToAuctionHouse = Players[playerIndex].GetActiveCharacters()[characterIndex].GetEquippedSpoils();
				for (int spoilsIndex = equippedSpoilsToMoveBackToAuctionHouse.Count - 1; spoilsIndex >= 0; spoilsIndex--)
				{
					SpoilsCard card = equippedSpoilsToMoveBackToAuctionHouse[spoilsIndex];
					removeSpecificSpoilsFromSlot(playerIndex, characterIndex, card.GetTitle());
					if (shouldDiscardEquipmentOnDeath)
					{
						SpoilsDeck.Remove(card);
						DiscardedSpoilsDeck.Add(card);
					}
					else
					{
						addSpecificCardToAuctionHouse(playerIndex, card.GetTitle());
					}
				}

				//Remove character
				CharacterCard character = Players[playerIndex].GetActiveCharacters()[characterIndex];
				Players[playerIndex].RemoveCharacterFromParty(characterIndex);
				CharacterDeck.Remove(character);
				DiscardedCharacters.Add(character);
			}
		}

		private void townBusinessPhase_DealSubphase()
		{
			for (int playerIndex = 0; playerIndex < PhotonNetwork.PlayerList.Length; playerIndex++)
			{
				Players[playerIndex].AddActionCardToHand(ActionDeck[0]);
				Debug.Log("Dealt action card " + ActionDeck[0].GetTitle());
				object content = new CardNetworking(ActionDeck[0].GetTitle(), playerIndex, Constants.ACTION_CARD);
				sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
				ActionDeck.RemoveAt(0);
			}
        }

        private void endPhaseForAllPlayers()
        {
			TurnManager.BeginNextPhase();
		}

		private void shuffleEncounterDecksIfNeeded()
        {
			if (PlainsDeck.Count == 0)
			{
				while (DiscardedPlainsCards.Count > 0)
				{
					PlainsDeck.Add(DiscardedPlainsCards[0]);
					DiscardedPlainsCards.RemoveAt(0);
				}
				PlainsDeck = Card.ShuffleDeck(PlainsDeck);
			}

			//todo for mountains

			//todo for city/rad
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
