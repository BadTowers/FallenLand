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
		private readonly List<Player> Players = new List<Player>();
		private const int StartingActionCards = 3;
		private const int StartingCharacterCards = 6;
		private const int StartingSpoilsCards = 10;
		private const int MaxActionCards = 7;
		private const int MaxTownTechs = 7;
		private const int MaxPsych = 3;
		private const int MaxNumberOfPlayers = 5;
		private const int MovementWeekCost = 1;
		private const int EncounterWeekCost = 1;
		private const int ResourceWeekCost = 2;
		private const int HealingWeekCost = 2;
		private List<TownTech> TownTechs;
		private Dictionary<string, int> TechsUsed;
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
		private ResourcePieceManager ResourcePieceManagerInst;
		private List<bool> HasDoneEncounterSinceMovement;
		bool ShouldSkipPhase;

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
			ResourcePieceManagerInst = this.gameObject.AddComponent<ResourcePieceManager>();
			MissionManagerInst = new MissionManager();
			DiceRoller = new Dice();
			MouseManagerInst = GameObject.Find("MouseManager").GetComponent<MouseManager>();
			MapLayoutInst = new DefaultMapLayout();
			CurrentPlayerEncounter = new List<EncounterCard>();
			HasDoneEncounterSinceMovement = new List<bool>();

			registerPhotonCallbacks();

			//Add placeholder players
			for (int i = 0; i < NumHumanPlayers; i++)
            {
				Faction faction = new Faction("Dummy", new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION));
				Players.Add(new HumanPlayer(faction, StartingSalvage));
				CurrentPlayerEncounter.Add(null);
				HasDoneEncounterSinceMovement.Add(false);
			}

			figureOutMyUserId();
			createMap();
			handleNewGameNetworkingIfNeeded();
			createDecks();
		}

		void Update()
		{
			handleGameStartIfNeeded();
			handleEffects();
			handleLinks();
			shuffleDecksIfNeeded();
			handlePhase();
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
		}

        public void OnTurnCompleted(int turn)
		{
        }

		public void OnPhaseBegins(Phases phase)
		{
			CurrentPhase = phase;
			IsMyPhaseEnded = false;

			switch (phase)
            {
				case Phases.Effects_Resolve_Subphase:
					handleEffectsResolveSubphase();
					ShouldSkipPhase = true;
					break;
                case Phases.Town_Business_Deal:
                    if (PhotonNetwork.IsMasterClient)
                    {
                        //townBusinessPhase_DealSubphase();
                    }
					ShouldSkipPhase = true;
					break;
                case Phases.Town_Business_Resource_Production:
					handleResourceProduction();
					ShouldSkipPhase = true;
					break;
				case Phases.End_Turn_Pass_First_Player:
					//Reset party exploits for the next turn
					for (int playerIndex = 0; playerIndex < PhotonNetwork.PlayerList.Length; playerIndex++)
					{
						Players[playerIndex].SetRemainingPartyExploitWeeks(4);
					}
					ShouldSkipPhase = true;
					break;
				case Phases.Party_Exploits_Party:
					for (int playerIndex = 0; playerIndex < Players.Count; ++playerIndex)
					{
						int penaltyAmount = Players[playerIndex].GetWeekPenaltyAmount();
						if (penaltyAmount > 0 && Players[playerIndex].GetRemainingPartyExploitWeeks() > 0)
						{
							Players[playerIndex].SetRemainingPartyExploitWeeks(Players[playerIndex].GetRemainingPartyExploitWeeks() - penaltyAmount);
							if (playerIndex == GetIndexForMyPlayer())
							{
								EventManager.ShowGenericPopup("Your delay of " + penaltyAmount.ToString() + " weeks has been applied.");
							}
							Players[playerIndex].ResetWeekPenalty();
						}
					}
					break;
				case Phases.Town_Business_Financial_Sell:
				case Phases.Town_Business_Financial_Purchase:
				case Phases.Town_Business_Town_Events_Chart:
				case Phases.Game_Start_Setup:
					break;
				default:
					//For now, end the phase--there is nothing to do if it isn't one of them from above
					ShouldSkipPhase = true;
					break;
            }

			FactionPerkManager.HandlePhase(this);
			TownTechManager.HandlePhase(this);
		}

		public void OnPhaseCompleted(Phases phase)
		{
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
					//dealSpecificActionCardToPlayerFromDeck(playerIndex, cardName);
				}
				else if (cardInfo.GetCardByte() == Constants.SPECIAL_SPOILS_CARD)
				{
					dealSpecificSpoilToPlayerFromSpecialDeck(playerIndex, cardName);
				}
				else if (cardInfo.GetCardByte() == Constants.DISCARDED_SPOILS_CARD)
				{
					dealSpecificSpoilToPlayerFromDiscardDeck(playerIndex, cardName);
				}
			}
			else if (eventCode == Constants.EvSendFactionInformation)
			{
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
				handleTownTechsOnStart(factionInfo.GetPlayerIndex());

				if (factionInfo.GetPlayerIndex() == GetIndexForMyPlayer())
				{
					ReceivedMyFactionInformation = true;
					MapCreation mapCreation = GameObject.Find("Map").GetComponent<MapCreation>();
					CameraManager mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraManager>();
					mainCamera.MoveCameraToFactionBaseLocation(mapCreation, Players[GetIndexForMyPlayer()].GetPlayerFaction());
				}

				PlayerPieceManagerInst.CreatePiece(faction, factionInfo.GetPlayerIndex());
			}
			else if (eventCode == Constants.EvSendPlayerInformation)
			{
				PlayerCardNetworking playerInfo = (PlayerCardNetworking)photonEvent.CustomData;
				handlePlayerCardNetworkUpdate(playerInfo);
			}
			else if (eventCode == Constants.EvRequestUpdateToPlayerInformation)
			{
				object playerInfo = photonEvent.CustomData;
				sendNetworkEvent(playerInfo, ReceiverGroup.Others, Constants.EvSendPlayerInformation);
				handlePlayerCardNetworkUpdate((PlayerCardNetworking)playerInfo);
			}
			else if (eventCode == Constants.EvMissionLocation)
			{
				MissionLocationNetworking missionLocationInfo = (MissionLocationNetworking)photonEvent.CustomData;
				MissionManagerInst.AddMissionLocation(missionLocationInfo.GetMissionNumber(), missionLocationInfo.GetRandomLocationNumber());
			}
			else if (eventCode == Constants.EvTownEventRoll)
			{
				handleTownEventRollNetworkUpdate(photonEvent.CustomData);
			}
			else if (eventCode == Constants.EvPartyExploits)
			{
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
			else if (eventCode == Constants.EvResource)
			{
				handleResourceEvent((ResourceNetworking)photonEvent.CustomData);
			}
			else if (eventCode == Constants.EvHealingDeed)
			{
				handleHealingDeedEvent((HealingDeedNetworking)photonEvent.CustomData);
			}
			else if (eventCode == Constants.EvShuffle)
			{
				handleShuffleEvent((ShuffleNetworking)photonEvent.CustomData);
			}
			else if (eventCode == Constants.EvSalvage)
			{
				handleSalvageNetworkingEvent((SalvageNetworking)photonEvent.CustomData);
			}
			else if(eventCode == Constants.EvTownDefense)
            {
				handleTownDefenseEvent((TownDefenseNetworking)photonEvent.CustomData);
            }
			else if(eventCode == Constants.EvTownTech)
            {
				handleTownTechEvent((TownTechNetworking)photonEvent.CustomData);
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

		public int GetNumberOfResourcesOwned(int playerIndex)
		{
			int numberOfResourcesOwned = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				numberOfResourcesOwned = Players[playerIndex].GetAllResourcesOwned().Count;
			}
			return numberOfResourcesOwned;
		}

		public int GetBonusMovement(int playerIndex)
		{
			int bonusMovement = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				bonusMovement = Players[playerIndex].GetBonusMovement();
			}
			return bonusMovement;
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

		public bool GetActiveCharacterLinkActive(int playerIndex, int characterIndex)
		{
			bool isActive = false;

			if (isPlayerIndexInRange(playerIndex))
			{
				isActive = Players[playerIndex].GetActiveCharacterLinkActive(characterIndex);
			}

			return isActive;
		}

		public int GetAmountOfInfectedDamageForCharacter(int playerIndex, int characterIndex)
		{
			int amountOfInfectedDamage = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				amountOfInfectedDamage = Players[playerIndex].GetAmountOfInfectedDamageForCharacter(characterIndex);
			}
			return amountOfInfectedDamage;
		}

		public int GetAmountOfRadiationDamageForCharacter(int playerIndex, int characterIndex)
		{
			int amountOfRadiationDamage = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				amountOfRadiationDamage = Players[playerIndex].GetAmountOfRadiationDamageForCharacter(characterIndex);
			}
			return amountOfRadiationDamage;
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

		//TODO rework so that it doesn't look at photon all the time. This will fix a player disconnecting and reconnecting. We can create an order and just stick to it
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
				handleSendingNetworkingUpdatePlayerInfo(content);
				EventManager.AuctionHouseChanged();
			}
		}

		public void RemoveCharacterFromTownRoster(int playerIndex, CharacterCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].RemoveCharacterFromTownRoster(card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.REMOVE_FROM_TOWN_ROSTER, card.GetTitle());
				handleSendingNetworkingUpdatePlayerInfo(content);
				EventManager.TownRosterChanged();
			}
		}

		public void RemoveSpoilsCardFromPlayerActiveParty(int playerIndex, int characterSlotIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				handleOnPartyCardUnequipRewardsAndPunishments(playerIndex, card);
				Players[playerIndex].RemoveSpoilsCardFromActiveCharacter(characterSlotIndex, card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.REMOVE_SPOILS_FROM_SLOT, card.GetTitle(), characterSlotIndex);
				handleSendingNetworkingUpdatePlayerInfo(content);
			}
		}

		public void RemoveCharacterFromActiveParty(int playerIndex, int characterSlotFoundIn)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.REMOVE_CHARACTER_FROM_SLOT, "", characterSlotFoundIn);
				handleSendingNetworkingUpdatePlayerInfo(content);
				removeCharacterFromParty(playerIndex, characterSlotFoundIn);
			}
		}

		public void MoveCharacterBetweenSlots(int playerIndex, int characterSlotFoundIn, int characterSlotMovingTo)
        {
			if (isPlayerIndexInRange(playerIndex))
            {
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.MOVE_CHARACTER_BETWEEN_SLOTS, "", characterSlotFoundIn, characterSlotMovingTo);
				handleSendingNetworkingUpdatePlayerInfo(content);
				moveCharacterBetweenSlots(playerIndex, characterSlotFoundIn, characterSlotMovingTo);
			}
		}

		public void RemoveSpoilsCardFromActiveVehicle(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				handleOnPartyCardUnequipRewardsAndPunishments(playerIndex, card);
				Players[playerIndex].RemoveStowableFromActiveVehicle(card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.REMOVE_SPOILS_FROM_VEHICLE, card.GetTitle());
				handleSendingNetworkingUpdatePlayerInfo(content);
			}
		}

		public void RemoveActiveVehicle(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				handleOnPartyCardUnequipRewardsAndPunishments(playerIndex, Players[playerIndex].GetActiveVehicle());
				Players[playerIndex].RemoveVehicleFromParty();
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.REMOVE_VEHICLE, "");
				handleSendingNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AssignSpoilsCardToCharacter(int playerIndex, int characterIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].AddSpoilsToCharacter(characterIndex, card);
				handleOnPartyCardEquipRewardsAndPunishments(playerIndex, card, characterIndex);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.ADD_SPOILS_TO_SLOT, card.GetTitle(), characterIndex);
				handleSendingNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AssignCharacterToParty(int playerIndex, int characterIndex, CharacterCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].AddCharacterToParty(characterIndex, card);
				handleOnPartyCardEquipRewardsAndPunishments(playerIndex, card, characterIndex);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.ADD_CHARACTER_TO_SLOT, card.GetTitle(), characterIndex);
				handleSendingNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AddSpoilsToAuctionHouse(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].AddSpoilsCardToAuctionHouse(card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.ADD_TO_AUCTION_HOUSE, card.GetTitle());
				handleSendingNetworkingUpdatePlayerInfo(content);
				EventManager.AuctionHouseChanged();
			}
		}

		public void AddCharacterToTownRoster(int playerIndex, CharacterCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].AddCharacterCardToTownRoster(card);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.ADD_TO_TOWN_ROSTER, card.GetTitle());
				handleSendingNetworkingUpdatePlayerInfo(content);
				EventManager.TownRosterChanged();
			}
		}

		public void AddVehicleToActiveParty(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].AddVehicleToParty(card);
				handleOnPartyCardEquipRewardsAndPunishments(playerIndex, card, Constants.VEHICLE_INDEX);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.ADD_VEHICLE, card.GetTitle());
				handleSendingNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AddSpoilsToActiveVehicle(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex) && card != null)
			{
				Players[playerIndex].AddSpoilsToActiveVehicle(card);
				handleOnPartyCardEquipRewardsAndPunishments(playerIndex, card, Constants.VEHICLE_INDEX);
				object content = new PlayerCardNetworking(GetIndexForMyPlayer(), Constants.ADD_SPOILS_TO_VEHICLE, card.GetTitle());
				handleSendingNetworkingUpdatePlayerInfo(content);
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

		public bool IsAllowedToApplyCharacterToCharacterSlot(int playerIndex, int characterIndex, int carryCapacity)
		{
			bool isAllowed = false;
			if (isPlayerIndexInRange(playerIndex) && characterIndex != Constants.VEHICLE_INDEX)
			{
				isAllowed = Players[playerIndex].IsAllowedToAddCharacterToParty(characterIndex, carryCapacity);
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

		public void DealSpoilsCardsToPlayer(int playerIndex, int numberOfCardsToDeal)
		{
			for (int i = 0; i < numberOfCardsToDeal; i++)
			{
				object content = new CardNetworking(SpoilsDeck[0].GetTitle(), playerIndex, Constants.SPOILS_CARD);
				sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
				dealSpecificSpoilToPlayerFromDeck(playerIndex, SpoilsDeck[0].GetTitle());
			}
		}

		public void DealCharacterCardsToPlayer(int playerIndex, int numberOfCardsToDeal)
		{
			for (int i = 0; i < numberOfCardsToDeal; i++)
			{
				object content = new CardNetworking(CharacterDeck[0].GetTitle(), playerIndex, Constants.CHARACTER_CARD);
				sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
				dealSpecificCharacterToPlayerFromDeck(playerIndex, CharacterDeck[0].GetTitle());
			}
		}

		public void DealActionCardsToPlayer(int playerIndex, int numberOfCardsToDeal)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				for (int i = 0; i < numberOfCardsToDeal; i++)
				{
					//object content = new CardNetworking(ActionDeck[0].GetTitle(), playerIndex, Constants.ACTION_CARD);
					//sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
					//dealSpecificActionCardToPlayerFromDeck(playerIndex, ActionDeck[0].GetTitle());
				}
			}
		}

		public void DealNextRelicSpoilsToPlayer(int playerIndex)
		{
			for (int spoilsIndex = 0; spoilsIndex < SpoilsDeck.Count; spoilsIndex++)
			{
				if (SpoilsDeck[spoilsIndex].GetIsRelic())
				{
					object content = new CardNetworking(SpoilsDeck[spoilsIndex].GetTitle(), playerIndex, Constants.SPOILS_CARD);
					sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
					dealSpecificSpoilToPlayerFromDeck(playerIndex, SpoilsDeck[spoilsIndex].GetTitle());
					break;
				}
			}
		}

		public bool DealNextMasterCharacterToPlayer(int playerIndex)
		{
			bool characterDealt = false;
			for (int characterDeckIndex = 0; characterDeckIndex < CharacterDeck.Count; characterDeckIndex++)
			{
				if (CharacterDeck[characterDeckIndex].GetIsMaster())
				{
					object content = new CardNetworking(CharacterDeck[characterDeckIndex].GetTitle(), playerIndex, Constants.CHARACTER_CARD);
					sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
					dealSpecificCharacterToPlayerFromDeck(playerIndex, CharacterDeck[characterDeckIndex].GetTitle());
					characterDealt = true;
					break;
				}
			}
			return characterDealt;
		}

		public bool DealNextAlcoholSpoilsToPlayer(int playerIndex)
		{
			bool spoilsDealt = false;
			for (int spoilsIndex = 0; spoilsIndex < SpoilsDeck.Count; spoilsIndex++)
			{
				if (SpoilsDeck[spoilsIndex].GetSpoilsTypes().Contains(SpoilsTypes.Alcohol))
				{
					object content = new CardNetworking(SpoilsDeck[spoilsIndex].GetTitle(), playerIndex, Constants.SPOILS_CARD);
					sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
                    dealSpecificSpoilToPlayerFromDeck(playerIndex, SpoilsDeck[spoilsIndex].GetTitle());
					spoilsDealt = true;
					break;
				}
			}
			return spoilsDealt;
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

		public void ApplyPhysicalDamageToWholeParty(int playerIndex, int amountOfDamage)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
				{
					Players[playerIndex].AddPhysicalDamageToCharacter(characterIndex, amountOfDamage);
					handleCharacterDeathIfNecessary(playerIndex, characterIndex, false);
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
				EventManager.D6DamageNeedsDistributing(numOfD6s, Constants.DAMAGE_PHYSICAL);
			}
		}

		public void DistributeD6InfectedDamageToParty(int playerIndex, int numOfD6s)
		{
			if (playerIndex == GetIndexForMyPlayer())
			{
				EventManager.D6DamageNeedsDistributing(numOfD6s, Constants.DAMAGE_INFECTED);
			}
		}

		public void DistributeD6HealingPhysicalDamage(int playerIndex, int numOfD6s)
		{
			if (playerIndex == GetIndexForMyPlayer())
			{
				EventManager.D6HealingNeedsDistributing(numOfD6s, Constants.HEAL_PHYSICAL);
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

		public int RollMovement(int playerIndex)
		{
			int d6Roll = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				d6Roll = DiceRoller.RollDice(Constants.D6);
			}

			return d6Roll;
		}

		public void RollFlight(int playerIndex, bool wasResourceEncounter)
        {
			int d6Roll = DiceRoller.RollDice(Constants.D6);
			int bonusMovement = GetBonusMovement(playerIndex);
			int totalMovement = d6Roll + bonusMovement;

			//Get the highest combat value
			EncounterCard curEncounter = GetCurrentEncounter(playerIndex);
			List<(Skills, int)> skillChecks = curEncounter.GetSkillChecks();
			int highestValue = 0;
			foreach ((Skills skill, int value) in skillChecks)
			{
				if (skill == Skills.Combat && value > highestValue)
				{
					highestValue = value;
				}
			}

			//Compare highest combat value to the flight movement value
			byte status;
			if (totalMovement > highestValue)
			{
				EventManager.ShowGenericPopup("Flight successful! You needed a " + highestValue + " and rolled a " + totalMovement + "(" + d6Roll + "+" + bonusMovement + ")");
				status = Constants.STATUS_FLIGHT;
			}
			else
			{
				EventManager.ShowGenericPopup("Flight failed! You needed a " + highestValue + " but rolled a " + totalMovement + "(" + d6Roll + "+" + bonusMovement + ")");
				status = Constants.STATUS_FAILED;
			}
			EncounterStatusNetworking encounterStatus = new EncounterStatusNetworking(playerIndex, (byte)GetPlayerEncounterType(playerIndex), status, wasResourceEncounter, curEncounter.GetTitle(), curEncounter.GetD6Rolls(), curEncounter.GetIndividualPassFail());
			sendNetworkEvent(encounterStatus, ReceiverGroup.Others, Constants.EvEncounterStatus);
			handleEncounterStatusEvent(encounterStatus);
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

		public void SetPlayerIsMoving(int playerIndex, bool isMoving)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].SetPlayerIsMoving(isMoving);
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
				bool isDoingEncounter = (encounterType != Constants.ENCOUNTER_NONE);
				Players[playerIndex].SetPlayerIsDoingAnEncounter(isDoingEncounter);
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

		public void SetPlayerIsHealing(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				HealingDeedNetworking healingDeed = new HealingDeedNetworking(playerIndex, Constants.HEALING_DEED_BEGIN);
				sendNetworkEvent(healingDeed, ReceiverGroup.Others, Constants.EvHealingDeed);
				handleHealingDeedEvent(healingDeed);
			}
		}

		public bool GetPlayerIsHealing(int playerIndex)
		{
			bool isHealing = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				isHealing = Players[playerIndex].GetPlayerIsHealing();
			}
			return isHealing;
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

		public int GetSkillTotalForCharacter(int playerIndex, int characterIndex, int skillIndex)
		{
			int skillValue = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				Skills requestedSkill = Skills.Medical;
				if (GetPlayerIsDoingAnEncounter(playerIndex))
				{
					requestedSkill = CurrentPlayerEncounter[playerIndex].GetSkillChecks()[skillIndex].Item1;
				}

				skillValue = Players[playerIndex].GetTotalForCharacterSkill(characterIndex, requestedSkill);
			}
			return skillValue;
		}

		public int GetCombatSkillTotalForCharacterMeleeOnly(int playerIndex, int characterIndex)
		{
			int skillValue = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				skillValue = Players[playerIndex].GetCombatSkillMeleeOnly(characterIndex);
			}
			return skillValue;
		}

		public int GetSkillTotalForVehicle(int playerIndex, int skillIndex)
		{
			int skillValue = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				Skills requestedSkill = Skills.Medical;
				if (GetPlayerIsDoingAnEncounter(playerIndex))
                {
					requestedSkill = CurrentPlayerEncounter[playerIndex].GetSkillChecks()[skillIndex].Item1;
				}

				skillValue = Players[playerIndex].GetTotalForVehicleSkill(requestedSkill);
			}
			return skillValue;
		}

		public int GetCharacterAutoSuccesses(int playerIndex, int characterIndex, int skillIndex)
		{
			int autoSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				Skills requestedSkill = Skills.Medical;
				if (GetPlayerIsDoingAnEncounter(playerIndex))
                {
					requestedSkill = CurrentPlayerEncounter[playerIndex].GetSkillChecks()[skillIndex].Item1;
				}

				autoSuccesses = Players[playerIndex].GetCharacterAutoSuccesses(characterIndex, skillIndex, requestedSkill);
			}
			return autoSuccesses;
		}

		public int GetCharacterCombatAutoSuccessesMeleeOnly(int playerIndex, int characterIndex, int skillIndex)
		{
			int autoSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				autoSuccesses = Players[playerIndex].GetCharacterCombatAutoSuccessesMeleeOnly(characterIndex, skillIndex);
			}
			return autoSuccesses;
		}

		public int GetCharacterRolledSuccesses(int playerIndex, int characterIndex, int skillIndex)
		{
			int rolledSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				Skills requestedSkill = Skills.Medical;
				if (GetPlayerIsDoingAnEncounter(playerIndex))
				{
					requestedSkill = CurrentPlayerEncounter[playerIndex].GetSkillChecks()[skillIndex].Item1;
				}

				rolledSuccesses = Players[playerIndex].GetCharacterRolledSuccesses(characterIndex, skillIndex, requestedSkill);
			}
			return rolledSuccesses;
		}

		public int GetCharacterCombatRolledSuccessesMeleeOnly(int playerIndex, int characterIndex, int skillIndex)
		{
			int rolledSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				rolledSuccesses = Players[playerIndex].GetCharacterCombatRolledSuccessesMeleeOnly(characterIndex, skillIndex);
			}
			return rolledSuccesses;
		}

		public int GetVehicleAutoSuccesses(int playerIndex, int skillIndex)
		{
			int autoSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				Skills requestedSkill = Skills.Medical;
				if (GetPlayerIsDoingAnEncounter(playerIndex))
				{
					requestedSkill = CurrentPlayerEncounter[playerIndex].GetSkillChecks()[skillIndex].Item1;
				}
					
				autoSuccesses = Players[playerIndex].GetVehicleAutoSuccesses(skillIndex, requestedSkill);
			}
			return autoSuccesses;
		}

		public int GetVehicleRolledSuccesses(int playerIndex, int skillIndex)
		{
			int rolledSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				Skills requestedSkill = Skills.Medical;
				if (GetPlayerIsDoingAnEncounter(playerIndex))
				{
					requestedSkill = CurrentPlayerEncounter[playerIndex].GetSkillChecks()[skillIndex].Item1;
				}

				rolledSuccesses = Players[playerIndex].GetVehicleRolledSuccesses(skillIndex, requestedSkill);
			}
			return rolledSuccesses;
		}

		public int GetTownTechSuccesses(int playerIndex, int skillIndex)
		{
			int townTechSuccesses = 0;

			if (isPlayerIndexInRange(playerIndex))
			{
				Skills requestedSkill = Skills.Medical;
				if (GetPlayerIsDoingAnEncounter(playerIndex))
				{
					requestedSkill = CurrentPlayerEncounter[playerIndex].GetSkillChecks()[skillIndex].Item1;
				}

				townTechSuccesses = Players[playerIndex].GetTownTechSuccesses(requestedSkill);
			}

			return townTechSuccesses;
		}

		public int GetPartyTotalSuccesses(int playerIndex, int skillIndex)
		{
			int totalSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				Skills requestedSkill = Skills.Medical;
				if (GetPlayerIsDoingAnEncounter(playerIndex))
				{
					requestedSkill = CurrentPlayerEncounter[playerIndex].GetSkillChecks()[skillIndex].Item1;
				}

				totalSuccesses = Players[playerIndex].GetTotalPartySuccesses(skillIndex, requestedSkill);
			}
			return totalSuccesses;
		}

		public int GetIndividualTotalSuccesses(int playerIndex, int characterIndex, int skillIndex)
		{
			int totalSuccesses = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				Skills requestedSkill = Skills.Medical;
				if (GetPlayerIsDoingAnEncounter(playerIndex))
				{
					requestedSkill = CurrentPlayerEncounter[playerIndex].GetSkillChecks()[skillIndex].Item1;
				}

				totalSuccesses = Players[playerIndex].GetTotalIndividualSuccesses(characterIndex, skillIndex, requestedSkill);
			}
			return totalSuccesses;
		}

		public int GetLastCharacterRoll(int playerIndex, int characterIndex, int skillIndex)
		{
			int lastRoll = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				lastRoll = Players[playerIndex].GetLastCharacterDiceRoll(characterIndex, skillIndex);
			}
			return lastRoll;
		}

		public int GetLastVehicleRoll(int playerIndex, int skillIndex)
		{
			int lastRoll = 0;
			if (isPlayerIndexInRange(playerIndex))
			{
				lastRoll = Players[playerIndex].GetLastVehicleDiceRoll(skillIndex);
			}
			return lastRoll;
		}

		public void RollCharacterEncounter(int playerIndex, int characterIndex, int skillIndex)
		{
			int diceRoll = DiceRoller.RollDice(Constants.D10);
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddCharacterDiceRoll(characterIndex, skillIndex, diceRoll);
			}
		}

		public void RollVehicleEncounter(int playerIndex, int skillIndex)
		{
			int diceRoll = DiceRoller.RollDice(Constants.D10);
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddVehicleDiceRoll(skillIndex, diceRoll);
			}
		}

		public bool DoesCharacterHaveRollsRemainingForSkill(int playerIndex, int characterIndex, int skillIndex)
		{
			bool hasRemaining = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				int lastRoll = Players[playerIndex].GetLastCharacterDiceRoll(characterIndex, skillIndex);
                if (lastRoll == Constants.HAS_NOT_ROLLED || lastRoll == Constants.CRIT_SUCCESS)
                {
					hasRemaining = true;
				}
			}
            return hasRemaining;
		}

        public bool DoesVehicleHaveRollsRemainingForSkill(int playerIndex, int skillIndex)
        {
			bool hasRemaining = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				int lastRoll = Players[playerIndex].GetLastVehicleDiceRoll(skillIndex);
				if (lastRoll == Constants.HAS_NOT_ROLLED || lastRoll == Constants.CRIT_SUCCESS)
				{
					hasRemaining = true;
				}
			}
			return hasRemaining;
		}

		public bool IsEncounterFinished(int playerIndex, int currentCharacterEncounterIndex)
		{
			bool isFinished = true;

			if (isPlayerIndexInRange(playerIndex))
			{
				List<(Skills, int)> skillChecks = CurrentPlayerEncounter[playerIndex].GetSkillChecks();
				if (!CurrentPlayerEncounter[playerIndex].GetIsIndividualCheck())
				{
					List<bool> skillHasRollsRemaining = new List<bool>();
					for (int skillIndex = 0; skillIndex < skillChecks.Count; skillIndex++)
					{
						skillHasRollsRemaining.Add(false);
					}
					if (!EncounterWasSuccessful(playerIndex))
					{
						//Check all characters
						for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
						{
							for (int skillIndex = 0; skillIndex < skillChecks.Count; skillIndex++)
							{
								if (DoesCharacterHaveRollsRemainingForSkill(playerIndex, characterIndex, skillIndex))
								{
									skillHasRollsRemaining[skillIndex] = true;
								}
							}
						}

						//Check vehicle
						for (int skillIndex = 0; skillIndex < skillChecks.Count; skillIndex++)
						{
							if (DoesVehicleHaveRollsRemainingForSkill(playerIndex, skillIndex))
							{
								skillHasRollsRemaining[skillIndex] = true;
								break;
							}
						}

						//If any particular skill is out of rolls and the encounter wasn't successful, then we should say fail
						bool skillCheckFailed = false;
						for (int skillIndex = 0; skillIndex < skillChecks.Count; skillIndex++)
						{
							if (!skillHasRollsRemaining[skillIndex] && GetPartyTotalSuccesses(playerIndex, skillIndex) < skillChecks[skillIndex].Item2)
							{
								skillCheckFailed = true;
								break;
							}
						}
						isFinished = skillCheckFailed;
					}
				}
				else
				{
					if (!IndividualEncounterWasSuccessful(playerIndex, currentCharacterEncounterIndex))
					{
						//Check skills for the current individual character
						for (int skillIndex = 0; skillIndex < skillChecks.Count; skillIndex++)
						{
							if (DoesCharacterHaveRollsRemainingForSkill(playerIndex, currentCharacterEncounterIndex, skillIndex))
							{
								isFinished = false;
								break;
							}
						}
					}
				}
			}

			return isFinished;
		}

		public bool IsHealingFinished(int playerIndex)
        {
			bool isFinished = true;

			if (isPlayerIndexInRange(playerIndex))
			{
				if (!haveAllCharactersRolledOnce(playerIndex, 0))
				{
					//Check all characters
					for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
					{
						if (DoesCharacterHaveRollsRemainingForSkill(playerIndex, characterIndex, 0))
						{
							isFinished = false;
							break;
						}
					}

					//Check vehicle
					if (DoesVehicleHaveRollsRemainingForSkill(playerIndex, 0))
					{
						isFinished = false;
					}
				}
			}

			return isFinished;
		}

		public bool IsPartyInStartingLocation(int playerIndex)
		{
			bool isInStartLocation = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				if (GetPartyLocation(playerIndex).Equals(GetFaction(playerIndex).GetBaseLocation()))
				{
					isInStartLocation = true;
				}
			}
			return isInStartLocation;
		}

		public bool IsPartyInTown(int playerIndex)
		{
			bool isInTown = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				List<Faction> factions = (new DefaultFactionInfo()).GetDefaultFactionList();
				for (int factionIndex = 0; factionIndex < factions.Count; factionIndex++)
				{
					if (GetPartyLocation(playerIndex).Equals(factions[factionIndex].GetBaseLocation()))
					{
						isInTown = true;
						break;
					}
				}
			}
			return isInTown;
		}

		public Faction GetFactionTownPartyIsIn(int playerIndex)
		{
			Faction faction = null;
			if (isPlayerIndexInRange(playerIndex))
			{
				List<Faction> factions = (new DefaultFactionInfo()).GetDefaultFactionList();
				for (int factionIndex = 0; factionIndex < factions.Count; factionIndex++)
				{
					if (GetPartyLocation(playerIndex).Equals(factions[factionIndex].GetBaseLocation()))
					{
						faction = factions[factionIndex];
						break;
					}
				}
			}
			return faction;
		}

		public int GetPlayerIndexForFaction(Faction faction)
		{
			int index = -1;
			if (faction != null)
			{
				for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
				{
					if (Players[playerIndex].GetPlayerFaction().GetName().Equals(faction.GetName()))
					{
						index = playerIndex;
						break;
					}
				}
			}
			return index;
		}

		public bool EncounterWasSuccessful(int playerIndex)
		{
			bool wasSuccessful = true;

			if (isPlayerIndexInRange(playerIndex))
			{
				if (!CurrentPlayerEncounter[playerIndex].GetIsIndividualCheck())
				{
					List<(Skills, int)> skillChecks = CurrentPlayerEncounter[playerIndex].GetSkillChecks();
					for (int skillIndex = 0; skillIndex < skillChecks.Count; skillIndex++)
					{
						if (GetPartyTotalSuccesses(playerIndex, skillIndex) < skillChecks[skillIndex].Item2 || !haveAllCharactersRolledOnce(playerIndex, skillIndex))
						{
							wasSuccessful = false;
							break;
						}
					}
				}
			}

			return wasSuccessful;
		}

		public bool IndividualEncounterWasSuccessful(int playerIndex, int currentCharacterIndex)
		{
			bool wasSuccessful = true;

			if (isPlayerIndexInRange(playerIndex))
			{
				List<(Skills, int)> skillChecks = CurrentPlayerEncounter[playerIndex].GetSkillChecks();
				for (int skillIndex = 0; skillIndex < skillChecks.Count; skillIndex++)
				{
					if (GetIndividualTotalSuccesses(playerIndex, currentCharacterIndex, skillIndex) < skillChecks[skillIndex].Item2 || !hasIndividualRolledOnce(playerIndex, currentCharacterIndex, skillIndex))
					{
						wasSuccessful = false;
						break;
					}
				}
			}

			return wasSuccessful;
		}

		public bool EncounterForIndividualWasSuccessful(int playerIndex, int characterIndex)
		{
			bool wasSuccessful = true;

			if (isPlayerIndexInRange(playerIndex))
			{
				List<(Skills, int)> skillChecks = CurrentPlayerEncounter[playerIndex].GetSkillChecks();
				for (int skillIndex = 0; skillIndex < skillChecks.Count; skillIndex++)
				{
					if (GetIndividualTotalSuccesses(playerIndex, characterIndex, skillIndex) < skillChecks[skillIndex].Item2)
					{
						wasSuccessful = false;
						break;
					}
				}
			}

			return wasSuccessful;
		}

		public void SetEncounterResultAccepted(int playerIndex, bool wasResourceEncounter)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				byte status = (EncounterWasSuccessful(playerIndex)) ? Constants.STATUS_PASSED : Constants.STATUS_FAILED;
				EncounterStatusNetworking encounterStatus = new EncounterStatusNetworking(playerIndex, (byte)GetPlayerEncounterType(playerIndex), status, wasResourceEncounter, 
					CurrentPlayerEncounter[playerIndex].GetTitle(), CurrentPlayerEncounter[playerIndex].GetD6Rolls(), CurrentPlayerEncounter[playerIndex].GetIndividualPassFail());
				sendNetworkEvent(encounterStatus, ReceiverGroup.Others, Constants.EvEncounterStatus);
				handleEncounterStatusEvent(encounterStatus);
			}
		}

		public void AddSalvageAtStartOfEncounter(int playerIndex, bool wasResourceEncounter)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				EncounterStatusNetworking encounterStatus = new EncounterStatusNetworking(playerIndex, (byte)GetPlayerEncounterType(playerIndex), Constants.STATUS_BEGIN, wasResourceEncounter, 
					CurrentPlayerEncounter[playerIndex].GetTitle(), CurrentPlayerEncounter[playerIndex].GetD6Rolls(), CurrentPlayerEncounter[playerIndex].GetIndividualPassFail());
				sendNetworkEvent(encounterStatus, ReceiverGroup.Others, Constants.EvEncounterStatus);
				handleEncounterStatusEvent(encounterStatus);
			}
		}

		public void SetHealingResultAccepted(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				HealingDeedNetworking healingDeed = new HealingDeedNetworking(playerIndex, Constants.HEALING_DEED_COMPLETE);
				sendNetworkEvent(healingDeed, ReceiverGroup.Others, Constants.EvHealingDeed);
				handleHealingDeedEvent(healingDeed);
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

		public void NetworkSalvage(int playerIndex, int amount, byte action)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				SalvageNetworking salvage = new SalvageNetworking(playerIndex, amount, action);
				sendNetworkEvent(salvage, ReceiverGroup.Others, Constants.EvSalvage);
				handleSalvageNetworkingEvent(salvage);
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
				if (playerIndex == GetIndexForMyPlayer())
				{
					EventManager.ShowGenericPopup("You've gained " + weeksToGain.ToString() + " weeks!");
				}
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

		public void DealSetAmountOfPhysicalDamageToIndividual(int playerIndex, int characterIndex, int amountOfDamage)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddPhysicalDamageToCharacter(characterIndex, amountOfDamage);
				handleCharacterDeathIfNecessary(playerIndex, characterIndex, false);
			}
		}

		public void DealSetAmountOfInfectedDamageToIndividual(int playerIndex, int characterIndex, int amountOfDamage)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddInfectedDamageToCharacter(characterIndex, amountOfDamage);
				handleCharacterDeathIfNecessary(playerIndex, characterIndex, false);
			}
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

		public void CharacterCrownTakesSetAmountOfHeal(int playerIndex, int characterIndex, int amountToHeal, byte healType)
        {
			if (isPlayerIndexInRange(playerIndex))
			{
				CharacterHealthNetworking characterHealth = new CharacterHealthNetworking(playerIndex, characterIndex, healType, amountToHeal, false);
				sendNetworkEvent(characterHealth, ReceiverGroup.Others, Constants.EvCharacterHealth);
				handleCharacterHealthEvent(characterHealth);
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
					Players[playerIndex].RemoveVehicleFromParty();
					DiscardedSpoilsDeck.Add(vehicle);

					if (playerIndex == GetIndexForMyPlayer())
					{
						EventManager.ShowGenericPopup("Vehicle was destroyed with all its gear!");
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

		public bool IsResourceOwned(Coordinates location)
		{
			bool isOwned = false;
			for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
			{
				List<Resource> resourcesOwned = Players[playerIndex].GetAllResourcesOwned();
				for (int resourceIndex = 0; resourceIndex < resourcesOwned.Count; resourceIndex++)
				{
					if (location.Equals(resourcesOwned[resourceIndex].GetLocation()))
					{
						isOwned = true;
						break;
					}
				}
			}
			return isOwned;
		}

		public bool IsResourceOwnedByPlayer(Coordinates location, int playerIndexToCheck)
		{
			bool isOwned = false;
			for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
			{
				List<Resource> resourcesOwned = Players[playerIndex].GetAllResourcesOwned();
				for (int resourceIndex = 0; resourceIndex < resourcesOwned.Count; resourceIndex++)
				{
					if (location.Equals(resourcesOwned[resourceIndex].GetLocation()) && playerIndexToCheck == playerIndex)
					{
						isOwned = true;
						break;
					}
				}
			}
			return isOwned;
		}

		public int WhichIndexOwnsResouce(Coordinates location)
		{
			int ownerIndex = Constants.INVALID_INDEX;
			for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
			{
				List<Resource> resourcesOwned = Players[playerIndex].GetAllResourcesOwned();
				for (int resourceIndex = 0; resourceIndex < resourcesOwned.Count; resourceIndex++)
				{
					if (location.Equals(resourcesOwned[resourceIndex].GetLocation()))
					{
						ownerIndex = playerIndex;
						break;
					}
				}
			}
			return ownerIndex;
		}

        public Resource GetResource(int ownerIndex, Coordinates locationOfResource)
        {
			Resource resource = null;

			if (isPlayerIndexInRange(ownerIndex))
			{
				List<Resource> resourcesOwned = Players[ownerIndex].GetAllResourcesOwned();
				for (int resourceIndex = 0; resourceIndex < resourcesOwned.Count; resourceIndex++)
				{
					if (resourcesOwned[resourceIndex].GetLocation().Equals(locationOfResource))
					{
						resource = resourcesOwned[resourceIndex];
						break;
					}
				}
			}

			return resource;
        }

		public bool HasDoneEncounterSinceLastMove(int playerIndex)
		{
			return HasDoneEncounterSinceMovement[playerIndex];
		}

		public void CaptureResource(Coordinates locationOfResource, int indexOfCapturingPlayer)
		{
			int indexOfResourceOwner = WhichIndexOwnsResouce(locationOfResource);
			if (isPlayerIndexInRange(indexOfResourceOwner) && isPlayerIndexInRange(indexOfCapturingPlayer))
			{
				ResourceNetworking resourceNetworking = new ResourceNetworking(indexOfResourceOwner, locationOfResource, indexOfCapturingPlayer);
				sendNetworkEvent(resourceNetworking, ReceiverGroup.Others, Constants.EvResource);
				handleResourceEvent(resourceNetworking);
			}
			else
			{
				Debug.LogError("CaptureResource: One of the indices was out of bounds: owner--" + indexOfResourceOwner + " or capturer--" + indexOfCapturingPlayer);
			}
		}

		public void AddBonusMovement(int playerIndex, int amount)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddBonusMovement(amount);
			}
		}

		public void SubtractBonusMovement(int playerIndex, int amount)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].SubtractBonusMovement(amount);
			}
		}

		public void GainPsychResistance(int playerIndex, int characterIndex, int amount)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddPsychResistance(characterIndex, amount);
			}
		}

		public void LosePsychResistance(int playerIndex, int characterIndex, int amount)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].SubtractPsychResistance(characterIndex, amount);
			}
		}

		public void GainCarryWeight(int playerIndex, int characterIndex, int amount)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddCarryCapacityToCharacter(characterIndex, amount);
			}
			else if (characterIndex == Constants.VEHICLE_INDEX)
			{
				Debug.LogError("GainCarryWeight -- implement for vehicles");
			}
		}

		public void LoseCarryWeight(int playerIndex, int characterIndex, int amount)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].SubtractCarryCapacityFromCharacter(characterIndex, amount);
			}
			else if (characterIndex == Constants.VEHICLE_INDEX)
			{
				Debug.LogError("LoseCarryWeight -- implement for vehicles");
			}
		}

		public void LoseAllEquippedSpoils(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				List<CharacterCard> charactersInParty = Players[playerIndex].GetActiveCharacters();
				for (int characterIndex = 0; characterIndex < charactersInParty.Count; characterIndex++)
				{
					if (charactersInParty[characterIndex] != null)
					{
						List<SpoilsCard> equippedCharacterSpoils = charactersInParty[characterIndex].GetEquippedSpoils();
						for (int spoilsIndex = equippedCharacterSpoils.Count - 1; spoilsIndex >= 0; spoilsIndex--)
						{
							SpoilsCard card = equippedCharacterSpoils[spoilsIndex];
							removeSpecificSpoilsFromSlot(playerIndex, characterIndex, card.GetTitle());
							SpoilsDeck.Remove(card);
							DiscardedSpoilsDeck.Add(card);
						}
					}
				}

				SpoilsCard vehicle = Players[playerIndex].GetActiveVehicle();
				if(vehicle != null)
                {
					List<SpoilsCard> equippedVehicleSpoils = vehicle.GetEquippedSpoils();
					for (int spoilsIndex = equippedVehicleSpoils.Count - 1; spoilsIndex >= 0; spoilsIndex--)
					{
						SpoilsCard card = equippedVehicleSpoils[spoilsIndex];
						removeSpecificSpoilsFromVehicle(playerIndex, card.GetTitle());
						SpoilsDeck.Remove(card);
						DiscardedSpoilsDeck.Add(card);
					}
				}

				EventManager.ShowGenericPopup("All equipped spoils have been discarded!");
			}
		}

		public void LoseAllEquippedRangeWeapons(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				List<CharacterCard> charactersInParty = Players[playerIndex].GetActiveCharacters();
				for (int characterIndex = 0; characterIndex < charactersInParty.Count; characterIndex++)
				{
					if (charactersInParty[characterIndex] != null)
					{
						List<SpoilsCard> equippedCharacterSpoils = charactersInParty[characterIndex].GetEquippedSpoils();
						for (int spoilsIndex = equippedCharacterSpoils.Count - 1; spoilsIndex >= 0; spoilsIndex--)
						{
							SpoilsCard card = equippedCharacterSpoils[spoilsIndex];
							if(card.GetSpoilsTypes().Contains(SpoilsTypes.Ranged_Weapon))
                            {
								removeSpecificSpoilsFromSlot(playerIndex, characterIndex, card.GetTitle());
								SpoilsDeck.Remove(card);
								DiscardedSpoilsDeck.Add(card);
							}
						}
					}
				}
			}
		}

		public void LoseAllAllySpoilsCards(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				//Remove allies from party
				List<CharacterCard> charactersInParty = Players[playerIndex].GetActiveCharacters();
				for (int characterIndex = 0; characterIndex < charactersInParty.Count; characterIndex++)
				{
					if (charactersInParty[characterIndex] != null)
					{
						List<SpoilsCard> equippedCharacterSpoils = charactersInParty[characterIndex].GetEquippedSpoils();
						for (int spoilsIndex = equippedCharacterSpoils.Count - 1; spoilsIndex >= 0; spoilsIndex--)
						{
							SpoilsCard card = equippedCharacterSpoils[spoilsIndex];
							if (card.GetSpoilsTypes().Contains(SpoilsTypes.Ally))
							{
								removeSpecificSpoilsFromSlot(playerIndex, characterIndex, card.GetTitle());
								SpoilsDeck.Remove(card);
								DiscardedSpoilsDeck.Add(card);
							}
						}
					}
				}

				//Remove allies from auction house
				List<SpoilsCard> auctionHouse = Players[playerIndex].GetAuctionHouseCards();
				for (int spoilsIndex = auctionHouse.Count - 1; spoilsIndex >= 0; spoilsIndex--)
				{
					SpoilsCard card = auctionHouse[spoilsIndex];
					if (card.GetSpoilsTypes().Contains(SpoilsTypes.Ally))
					{
						removeSpecificCardFromAuctionHouse(playerIndex, card.GetTitle());
						SpoilsDeck.Remove(card);
						DiscardedSpoilsDeck.Add(card);
					}
				}
			}
		}

		public void ApplyEffectToPlayer(int playerIndex, Effect effectToApply)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddActiveEffect(effectToApply);
			}
		}

		public void RemoveActiveEffect(int playerIndex, Effect effectToRemove)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveActiveEffect(effectToRemove);
			}
		}

		public List<Effect> GetActiveEffects(int playerIndex)
		{
			List<Effect> effects = new List<Effect>();
			if(isPlayerIndexInRange(playerIndex))
            {
				effects = Players[playerIndex].GetActiveEffects();
            }

			return effects;
		}

		public void DiscardEquippedAllies(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				//Remove from characters
				List<CharacterCard> partyMembers = Players[playerIndex].GetActiveCharacters();
				for (int characterIndex = 0; characterIndex < Constants.NUM_PARTY_MEMBERS; characterIndex++)
				{
					if (partyMembers[characterIndex] != null)
					{
						List<SpoilsCard> equippedGear = partyMembers[characterIndex].GetEquippedSpoils();
						for (int spoilsIndex = equippedGear.Count - 1; spoilsIndex >= 0; spoilsIndex--)
						{
							SpoilsCard card = equippedGear[spoilsIndex];
							if (card.GetSpoilsTypes().Contains(SpoilsTypes.Ally))
							{
								removeSpecificSpoilsFromSlot(playerIndex, characterIndex, card.GetTitle());
								SpoilsDeck.Remove(card);
								DiscardedSpoilsDeck.Add(card);
							}
						}
					}
				}

				//Remove from vehicle
				SpoilsCard vehicle = GetActiveVehicle(playerIndex);
				if (vehicle != null)
				{
					List<SpoilsCard> equippedGear = vehicle.GetEquippedSpoils();
					for (int spoilsIndex = equippedGear.Count - 1; spoilsIndex >= 0; spoilsIndex--)
					{
						SpoilsCard card = equippedGear[spoilsIndex];
						if (card.GetSpoilsTypes().Contains(SpoilsTypes.Ally))
						{
							removeSpecificSpoilsFromVehicle(playerIndex, card.GetTitle());
							SpoilsDeck.Remove(card);
							DiscardedSpoilsDeck.Add(card);
						}
					}
				}
			}
		}

		public void DiscardEquippedHorses(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				SpoilsCard vehicle = GetActiveVehicle(playerIndex);
				if (vehicle != null && vehicle.GetSpoilsTypes().Contains(SpoilsTypes.Horse))
				{
					//Equipment goes back to auction house
					List<SpoilsCard> equippedGear = vehicle.GetAttachments();
					for (int spoilsIndex = equippedGear.Count - 1; spoilsIndex >= 0; spoilsIndex--)
					{
						SpoilsCard card = equippedGear[spoilsIndex];
						removeSpecificSpoilsFromVehicle(playerIndex, card.GetTitle());
						addSpecificCardToAuctionHouse(playerIndex, card.GetTitle());
					}

					//Remove horse
					Players[playerIndex].RemoveVehicleFromParty();
					SpoilsDeck.Remove(vehicle);
					DiscardedSpoilsDeck.Add(vehicle);
				}
			}
		}

		public void RollD6ForEachCharacterForEncounter(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				for(int characterIndex = 0; characterIndex < Constants.NUM_PARTY_MEMBERS; characterIndex++)
                {
					int d6Roll = DiceRoller.RollDice(Constants.D6);
					if (CurrentPlayerEncounter[playerIndex] != null)
					{
						CurrentPlayerEncounter[playerIndex].SetD6RollForCharacter(characterIndex, d6Roll);
					}
					else
					{
						Debug.LogError("Encounter was not set for " + playerIndex + " in RollD6ForEachCharacterForEncounter");
					}
				}
			}
		}

		public Dice GetDiceRoller()
		{
			return DiceRoller;
		}

		public void GainSkillAmount(int playerIndex, int characterIndex, Skills skill, int amount)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				CharacterCard character = Players[playerIndex].GetActiveCharacters()[characterIndex];
				if (character != null)
				{
					character.GainSkillAmount(skill, amount);
				}
			}
		}

		public void LoseSkillAmount(int playerIndex, int characterIndex, Skills skill, int amount)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				CharacterCard character = Players[playerIndex].GetActiveCharacters()[characterIndex];
				if (character != null)
				{
					character.LoseSkillAmount(skill, amount);
				}
			}
		}

		public bool IsSpoilsTypeEquipped(int playerIndex, int characterIndex, SpoilsTypes spoilsType)
		{
			bool isEquipped = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				CharacterCard character = Players[playerIndex].GetActiveCharacters()[characterIndex];
				if (character != null)
				{
					List<SpoilsCard> spoils = character.GetEquippedSpoils();
					for (int spoilsIndex = 0; spoilsIndex < spoils.Count; spoilsIndex++)
					{
						if (spoils[spoilsIndex].GetSpoilsTypes().Contains(spoilsType))
						{
							isEquipped = true;
							break;
						}
					}
				}
			}

			return isEquipped;
		}

		public int GetNumberOfSpoilsTypeEquippedToCharacter(int playerIndex, int characterIndex, SpoilsTypes spoilsType)
		{
			int numEquipped = 0;

			if (isPlayerIndexInRange(playerIndex))
			{
				CharacterCard character = Players[playerIndex].GetActiveCharacters()[characterIndex];
				if (character != null)
				{
					List<SpoilsCard> spoils = character.GetEquippedSpoils();
					for (int spoilsIndex = 0; spoilsIndex < spoils.Count; spoilsIndex++)
					{
						if (spoils[spoilsIndex].GetSpoilsTypes().Contains(spoilsType))
						{
							numEquipped++;
						}
					}
				}
			}

			return numEquipped;
		}

		public bool IsSpecificSpoilsEquipped(int playerIndex, int characterIndex, string spoilsName)
		{
			bool isEquipped = false;
			if (isPlayerIndexInRange(playerIndex))
			{
				CharacterCard character = Players[playerIndex].GetActiveCharacters()[characterIndex];
				if (character != null)
				{
					List<SpoilsCard> spoils = character.GetEquippedSpoils();
					for (int spoilsIndex = 0; spoilsIndex < spoils.Count; spoilsIndex++)
					{
						if (spoils[spoilsIndex].GetTitle().Equals(spoilsName))
						{
							isEquipped = true;
							break;
						}
					}
				}
			}

			return isEquipped;
		}

		public bool IsVehicleOfCertainType(int playerIndex, SpoilsTypes type)
		{
			bool isOfCertainType = false;

			if (isPlayerIndexInRange(playerIndex))
			{
				SpoilsCard vehicle = Players[playerIndex].GetActiveVehicle();
				if (vehicle != null)
				{
					if (vehicle.GetSpoilsTypes().Contains(type))
					{
						isOfCertainType = true;
					}
				}
			}

			return isOfCertainType;
		}

		public bool IsSpecificVehicleInParty(int playerIndex, string vehicleName)
		{
			bool isSpecificVehicleInParty = false;

			if (isPlayerIndexInRange(playerIndex))
			{
				SpoilsCard vehicle = Players[playerIndex].GetActiveVehicle();
				if (vehicle != null)
				{
					if (vehicle.GetTitle().Equals(vehicleName))
					{
						isSpecificVehicleInParty = true;
					}
				}
			}

			return isSpecificVehicleInParty;
		}

		public void UpdateCharacterSlotTotals(int playerIndex, int characterIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].UpdateCharacterSlotTotals(characterIndex);
			}
		}

		public bool IsPlayerAllowedToBuyTownDefenseChip(int playerIndex)
		{
			bool isAllowed = false;

			if (isPlayerIndexInRange(playerIndex))
			{
				if(Players[playerIndex].GetNumberOfTownDefenseChips() < Constants.MAX_TOWN_DEFENSE_CHIPS_ALLOWED_TO_OWN)
                {
					isAllowed = true;
				}
			}

			return isAllowed;
		}

		public bool IsPlayerAllowedToSellTownDefenseChip(int playerIndex)
		{
			bool isAllowed = false;

			if (isPlayerIndexInRange(playerIndex))
			{
				if (Players[playerIndex].GetNumberOfTownDefenseChips() > 0)
				{
					isAllowed = true;
				}
			}

			return isAllowed;
		}			

		public bool IsPlayerAllowedToBuyTownTech(int playerIndex)
		{
			bool isAllowed = false;

			if (Players[playerIndex].GetTownTechs().Count < MaxTownTechs)
			{
				isAllowed = true;
			}

			return isAllowed;
		}

		public bool IsPlayerAllowedToUpgradeTownTech(int playerIndex)
		{
			bool isAllowed = false;

			List<TownTech> townTechs = Players[playerIndex].GetTownTechs();
			for (int townTechIndex = 0; townTechIndex < townTechs.Count; ++townTechIndex)
			{
				if (townTechs[townTechIndex].GetTier() != Constants.TIER_2)
				{
					isAllowed = true;
					break;
				}
			}

			return isAllowed;
		}

		public int GetCostOfTownDefenseChip(int playerIndex)
		{
			int cost = Constants.INVALID_COST;

			if (isPlayerIndexInRange(playerIndex))
			{
				int numChipsOwned = Players[playerIndex].GetNumberOfTownDefenseChips();
				cost = Constants.TOWN_DEFENSE_CHIP_COST[numChipsOwned];
			}

			return cost;
		}

		public void PurchaseTownDefenseChip(int playerIndex)
		{
            if (isPlayerIndexInRange(playerIndex))
            {
				TownDefenseNetworking townDefense = new TownDefenseNetworking(playerIndex, Constants.BUY_TOWN_DEFENSE);
				sendNetworkEvent(townDefense, ReceiverGroup.Others, Constants.EvTownDefense);
				handleTownDefenseEvent(townDefense);
			}
		}

		public void SellTownDefenseChip(int playerIndex)
        {
			if (isPlayerIndexInRange(playerIndex))
			{
				TownDefenseNetworking townDefense = new TownDefenseNetworking(playerIndex, Constants.SELL_TOWN_DEFENSE);
				sendNetworkEvent(townDefense, ReceiverGroup.Others, Constants.EvTownDefense);
				handleTownDefenseEvent(townDefense);
			}
		}

		public int GetNumberOfTownDefenseChipsOwned(int playerIndex)
		{
			int numOwned = 0;

			if(isPlayerIndexInRange(playerIndex))
            {
				numOwned = Players[playerIndex].GetNumberOfTownDefenseChips();
			}

			return numOwned;
		}

		public void GainTownTechSuccesses(int playerIndex, Skills skill, int amountGained)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddTownTechSuccesses(skill, amountGained);
			}
		}

		public void LoseTownTechSuccesses(int playerIndex, Skills skill, int amountLost)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveTownTechSuccesses(skill, amountLost);
			}
		}

		public int GetPurchaseCostOfTownTech(int townTechNumber)
		{
			return Constants.DEFAULT_TOWN_TECHS.GetTownTechByName(Constants.TOWN_TECH_NUMBER_TO_NAME[townTechNumber]).GetPurchaseCost();
		}

		public int GetUpgradeCostOfTownTech(int townTechNumber)
		{
			return Constants.DEFAULT_TOWN_TECHS.GetTownTechByName(Constants.TOWN_TECH_NUMBER_TO_NAME[townTechNumber]).GetUpgradeCost();
		}

		public void PurchaseTownTech(int playerIndex, int townTechNumber)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				TownTechNetworking townTechNetworking = new TownTechNetworking(playerIndex, Constants.BUY_TOWN_TECH, Constants.TOWN_TECH_NUMBER_TO_NAME[townTechNumber]);
				sendNetworkEvent(townTechNetworking, ReceiverGroup.Others, Constants.EvTownTech);
				handleTownTechEvent(townTechNetworking);
			}
		}

		public void UpgradeTownTech(int playerIndex, int townTechNumber)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				TownTechNetworking townTechNetworking = new TownTechNetworking(playerIndex, Constants.UPGRADE_TOWN_TECH, Constants.TOWN_TECH_NUMBER_TO_NAME[townTechNumber]);
				sendNetworkEvent(townTechNetworking, ReceiverGroup.Others, Constants.EvTownTech);
				handleTownTechEvent(townTechNetworking);
			}
		}

		public void DowngradeTownTech(int playerIndex, int townTechIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				TownTechNetworking townTechNetworking = new TownTechNetworking(playerIndex, Constants.DOWNGRADE_TOWN_TECH, Players[playerIndex].GetTownTechs()[townTechIndex].GetTechName());
				sendNetworkEvent(townTechNetworking, ReceiverGroup.Others, Constants.EvTownTech);
				handleTownTechEvent(townTechNetworking);
			}
		}

		public void SellTownTech(int playerIndex, int townTechIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				TownTechNetworking townTechNetworking = new TownTechNetworking(playerIndex, Constants.SELL_TOWN_TECH, Players[playerIndex].GetTownTechs()[townTechIndex].GetTechName());
				sendNetworkEvent(townTechNetworking, ReceiverGroup.Others, Constants.EvTownTech);
				handleTownTechEvent(townTechNetworking);
			}
		}

		public int GetNumberOfTownTechsSold(int townTechNumber)
		{
			return TechsUsed[Constants.TOWN_TECH_NUMBER_TO_NAME[townTechNumber]];
		}

		public bool DoesPlayerOwnTownTechOfTier(int playerIndex, int townTechNumber, int tier)
		{
			bool owns = false;

			if (isPlayerIndexInRange(playerIndex))
			{
				List<TownTech> townTechs = Players[playerIndex].GetTownTechs();
				for (int townTechIndex = 0; townTechIndex < townTechs.Count; ++townTechIndex)
				{
					if (Constants.TOWN_TECH_NAME_TO_NUMBER[townTechs[townTechIndex].GetTechName()] == townTechNumber && townTechs[townTechIndex].GetTier() == tier)
					{
						owns = true;
						break;
					}
				}
			}

			return owns;
		}

		public void AddWeekPenalty(int playerIndex, int amountOfWeeksToPenalize)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				EventManager.ShowGenericPopup("You've been delayed " + amountOfWeeksToPenalize.ToString() + " weeks!");
				Players[playerIndex].AddWeekPenalty(amountOfWeeksToPenalize);
			}
		}

		public int GetWeekPenaltyAmount(int playerIndex)
		{
			int penaltyAmount = 0;

			if(isPlayerIndexInRange(playerIndex))
			{
				penaltyAmount = Players[playerIndex].GetWeekPenaltyAmount();
			}

			return penaltyAmount;
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
				dealSpoilsCardsToPlayers();
				dealCharacterCardsToPlayers();
				//dealActionCardsToPlayers();
			}
		}

		//Only called by master client
		private void dealSpoilsCardsToPlayers()
		{
			int dealingIndex = 0;
			for (int i = 0; i < StartingSpoilsCards; i++)
			{
				for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
				{
					bool cardWasDealt = false;
					do
					{
						SpoilsCard curSpoilsCard = SpoilsDeck[dealingIndex];
						if (curSpoilsCard.GetIsStartingCard() || curSpoilsCard.GetSpoilsTypes().Contains(SpoilsTypes.Event))
						{
							Debug.Log("NOT DEALING " + curSpoilsCard.GetTitle());
							dealingIndex++;
						}
						else
						{
							cardWasDealt = true;
							Players[playerIndex].AddSpoilsCardToAuctionHouse(curSpoilsCard);
							Debug.Log("Dealt spoils card " + curSpoilsCard.GetTitle() + " to player " + playerIndex);
							object content = new CardNetworking(curSpoilsCard.GetTitle(), playerIndex, Constants.SPOILS_CARD);
							sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
							SpoilsDeck.RemoveAt(dealingIndex);
							EventManager.AuctionHouseChanged();
						}
					} while (!cardWasDealt);
				}
			}
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
					EventManager.TownRosterChanged();
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
					EventManager.AuctionHouseChanged();
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to deal specific card " + cardName + " to player, but it was not found in the deck");
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
					EventManager.AuctionHouseChanged();
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to deal specific DISCARDED SPOILS card " + cardName + " to player, but it was not found in the deck");
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
					EventManager.AuctionHouseChanged();
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
					EventManager.TownRosterChanged();
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to deal specific card " + cardName + " to player, but it was not found in the deck");
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
				Debug.LogError("Tried to deal specific card " + cardName + " to player, but it was not found in the deck");
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
					EventManager.TownRosterChanged();
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to remove specific character card " + cardName + " from player town roster, but it was not found");
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
					EventManager.AuctionHouseChanged();
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to remove specific spoils card " + cardName + " from player auction house, but it was not found");
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
					handleOnPartyCardUnequipRewardsAndPunishments(playerIndex, spoilsCard);
					SpoilsDeck.Add(spoilsCard); //TODO don't add to the deck but rather some temp place
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to remove specific spoils " + cardName + " from player slot, but it was not found");
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
					handleOnPartyCardUnequipRewardsAndPunishments(playerIndex, stowable);
					SpoilsDeck.Add(stowable); //TODO don't add to spoils deck. Store in temp location
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to remove specific spoils " + cardName + " from vehicle slot, but it was not found");
			}
		}

		private void removeCharacterFromParty(int playerIndex, int characterIndex)
		{
            CharacterCard character = Players[playerIndex].GetActiveCharacters()[characterIndex];
			handleOnPartyCardUnequipRewardsAndPunishments(playerIndex, character);
			Players[playerIndex].RemoveAllSpoilsFromActiveCharacter(characterIndex);
			LinksManager.HandleLinks(this, playerIndex, characterIndex);
			Players[playerIndex].RemoveCharacterFromParty(characterIndex);
            CharacterDeck.Add(character); //TODO don't add to character deck
        }

		private void removeCharacterFromPartyAndDiscardEquipment(int playerIndex, int characterIndex)
		{
			//Remove non-party spoils spoils
			List<SpoilsCard> equippedSpoilsToMoveBackToAuctionHouse = Players[playerIndex].GetActiveCharacters()[characterIndex].GetEquippedSpoils();
			for (int spoilsIndex = equippedSpoilsToMoveBackToAuctionHouse.Count - 1; spoilsIndex >= 0; spoilsIndex--)
			{
				SpoilsCard card = equippedSpoilsToMoveBackToAuctionHouse[spoilsIndex];
				if (!card.GetSpoilsTypes().Contains(SpoilsTypes.Party_Equipment))
				{
					removeSpecificSpoilsFromSlot(playerIndex, characterIndex, card.GetTitle());
					SpoilsDeck.Remove(card);
					DiscardedSpoilsDeck.Add(card);
				}
			}

			CharacterCard character = Players[playerIndex].GetActiveCharacters()[characterIndex];
			Players[playerIndex].RemoveAllSpoilsFromActiveCharacter(characterIndex);
			LinksManager.HandleLinks(this, playerIndex, characterIndex);
			Players[playerIndex].RemoveCharacterFromParty(characterIndex);
			character.ClearAllSpoils(); //Clears remaining party equipment from this card
			CharacterDeck.Add(character); //TODO don't add to character deck
		}

		private void addSpecificCharacterToSlot(int playerIndex, int slotIndex, string cardName)
		{
			bool found = false;
			for (int i = 0; i < CharacterDeck.Count; i++) //TODO don't grab from deck but some temp location (rework removeSpecificCardFromTownRoster)
			{
				if (CharacterDeck[i].GetTitle() == cardName)
				{
					Players[playerIndex].AddCharacterToParty(slotIndex, CharacterDeck[i]);
					handleOnPartyCardEquipRewardsAndPunishments(playerIndex, CharacterDeck[i], slotIndex);
					CharacterDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to add specific character " + cardName + " to player slot, but it was not found");
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
					handleOnPartyCardEquipRewardsAndPunishments(playerIndex, SpoilsDeck[i], slotIndex);
					SpoilsDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to add specific spoils " + cardName + " to player slot, but it was not found");
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
					handleOnPartyCardEquipRewardsAndPunishments(playerIndex, SpoilsDeck[i], Constants.VEHICLE_INDEX);
					SpoilsDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to add specific spoils " + cardName + " to vehicle slot, but it was not found");
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
					EventManager.TownRosterChanged();
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to add specific character card " + cardName + " to player town roster, but it was not found");
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
					EventManager.AuctionHouseChanged();
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to add specific spoils card " + cardName + " to player auction house, but it was not found");
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
					handleOnPartyCardEquipRewardsAndPunishments(playerIndex, spoilsCard, Constants.VEHICLE_INDEX);
					SpoilsDeck.RemoveAt(i);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.LogError("Tried to add specific vehicle card " + cardName + " to player party, but it was not found");
			}
		}

		private void moveCharacterBetweenSlots(int playerIndex, int characterSlotFoundIn, int characterSlotMovingTo)
		{
			Players[playerIndex].MoveCharacterBetweenSlots(characterSlotFoundIn, characterSlotMovingTo);
		}

		private void handleOnPartyCardEquipRewardsAndPunishments(int playerIndex, PartyCard cardEquipped, int slotIndex)
		{
			//Rewards on equip
			List<Reward> rewardsOnEquip = cardEquipped.GetRewardsWhenEquipped();
			for (int i = 0; i < rewardsOnEquip.Count; i++)
			{
				rewardsOnEquip[i].SetCharacterIndex(slotIndex);
				rewardsOnEquip[i].HandleReward(this, playerIndex);
			}
			//Punishments on equip
			List<Punishment> punishmentsOnEquip = cardEquipped.GetPunishmentsWhenEquipped();
			for (int i = 0; i < punishmentsOnEquip.Count; i++)
			{
				punishmentsOnEquip[i].SetCharacterIndex(slotIndex);
				punishmentsOnEquip[i].HandlePunishment(this, playerIndex);
			}

			//Rewards on removal
			List<Reward> rewardsOnUnequip = cardEquipped.GetRewardsWhenUnequipped();
			for (int i = 0; i < rewardsOnUnequip.Count; i++)
			{
				rewardsOnUnequip[i].SetCharacterIndex(slotIndex);
			}
			//Punishments on removal
			List<Punishment> punishmentsOnUnequip = cardEquipped.GetPunishmentsWhenUnequipped();
			for (int i = 0; i < punishmentsOnUnequip.Count; i++)
			{
				punishmentsOnUnequip[i].SetCharacterIndex(slotIndex);
			}
		}

		private void handleOnPartyCardUnequipRewardsAndPunishments(int playerIndex, PartyCard cardRemoved)
		{
			//Rewards on removal
			List<Reward> rewardsOnRemoval = cardRemoved.GetRewardsWhenUnequipped();
			for (int i = 0; i < rewardsOnRemoval.Count; i++)
			{
				rewardsOnRemoval[i].HandleReward(this, playerIndex);
				rewardsOnRemoval[i].SetCharacterIndex(Constants.INVALID_INDEX);
			}
			//Punishments on removal
			List<Punishment> punishmentsOnRemoval = cardRemoved.GetPunishmentsWhenUnequipped();
			for (int i = 0; i < punishmentsOnRemoval.Count; i++)
			{
				punishmentsOnRemoval[i].HandlePunishment(this, playerIndex);
				punishmentsOnRemoval[i].SetCharacterIndex(Constants.INVALID_INDEX);
			}

			//Rewards on equip
			List<Reward> rewardsOnEquip = cardRemoved.GetRewardsWhenEquipped();
			for (int i = 0; i < rewardsOnEquip.Count; i++)
			{
				rewardsOnEquip[i].SetCharacterIndex(Constants.INVALID_INDEX);
			}
			//Punishments on equip
			List<Punishment> punishmentsOnEquip = cardRemoved.GetPunishmentsWhenEquipped();
			for (int i = 0; i < punishmentsOnEquip.Count; i++)
			{
				punishmentsOnEquip[i].SetCharacterIndex(Constants.INVALID_INDEX);
			}
		}

		private void countTownTechsThatAreInUse()
		{
			TownTechs = Constants.DEFAULT_TOWN_TECHS.GetDefaultTownTechList();
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

		private void handleTownTechsOnStart(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				List<TownTech> townTechs = Players[playerIndex].GetTownTechs();
				for (int townTechIndex = 0; townTechIndex < townTechs.Count; ++townTechIndex)
				{
					TownTechManager.HandleTownTechPurchase(this, playerIndex, townTechs[townTechIndex]);
					if (townTechs[townTechIndex].GetTier() == Constants.TIER_2)
					{
						TownTechManager.HandleTownTechUpgrade(this, playerIndex, townTechs[townTechIndex]);
					}
				}
			}
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

		private void applyTownDefenseDamage(int capturingPlayerIndex)
		{
			int numChips = Players[capturingPlayerIndex].GetNumberOfTownDefenseChips();
			List<CharacterCard> characters = Players[capturingPlayerIndex].GetActiveCharacters();
			for (int characterIndex = 0; characterIndex < characters.Count; characterIndex++)
            {
				if (characters[characterIndex] != null)
				{
					characters[characterIndex].AddPhysicalDamage(numChips);
					handleCharacterDeathIfNecessary(capturingPlayerIndex, characterIndex, false);
				}
			}
		}


		private void handleTownEventRoll(int playerIndex, int townEventRoll)
        {
			switch (townEventRoll)
			{
				case 1:
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
					//No effect
					break;
			}
		}

		private void handlePartyExploitsMovement(int playerIndex, Coordinates coords)
		{
			int previousWeeksRemaining = Players[playerIndex].GetRemainingPartyExploitWeeks();
			Players[playerIndex].SetRemainingPartyExploitWeeks(previousWeeksRemaining - MovementWeekCost);
			PlayerPieceManagerInst.MovePiece(playerIndex, coords);
			Players[playerIndex].SetPartyLocation(coords);
			HasDoneEncounterSinceMovement[playerIndex] = false;
		}

		private void handlePartyExploitsEncounter(int playerIndex, byte encounterType, string encounterCardName)
		{
			Players[playerIndex].ResetAllCharacterDiceRolls();
			Players[playerIndex].ResetAllVehicleDiceRolls();

			if (encounterType == Constants.ENCOUNTER_PLAINS)
			{
				CurrentPlayerEncounter[playerIndex] = PlainsCard.FindCardInDeckByTitle(encounterCardName, PlainsDeck);
				if (CurrentPlayerEncounter[playerIndex] == null)
				{
					Debug.LogError("Error. Couldn't find plains encounter card with title " + encounterCardName);
				}
				Players[playerIndex].SetNumberOfSkillChecks(CurrentPlayerEncounter[playerIndex].GetSkillChecks().Count);
				HandleActionsOnBegin();
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
					Players[playerIndex].SetPlayerIsDoingAnEncounter(false);
					Players[playerIndex].SetEncounterType(Constants.ENCOUNTER_NONE);
					EncounterWasSent = false;

					List<int> d6Rolls = eventStatus.GetD6Rolls();
					List<byte> passFail = eventStatus.GetIndividualPassFail();
					for (int characterIndex = 0; characterIndex < Constants.NUM_PARTY_MEMBERS; characterIndex++)
					{
						CurrentPlayerEncounter[playerIndex].SetD6RollForCharacter(characterIndex, d6Rolls[characterIndex]);
						CurrentPlayerEncounter[playerIndex].SetIndividualPassFail(characterIndex, passFail[characterIndex]);
					}

					int previousWeeksRemaining = Players[playerIndex].GetRemainingPartyExploitWeeks();
					if (!eventStatus.GetWasResourceEncounter())
					{
						Players[playerIndex].SetRemainingPartyExploitWeeks(previousWeeksRemaining - EncounterWeekCost);
					}
					else
                    {
						Players[playerIndex].SetRemainingPartyExploitWeeks(previousWeeksRemaining - ResourceWeekCost);
					}

					if (Players[playerIndex].GetWeekPenaltyAmount() > 0 && playerIndex == GetIndexForMyPlayer())
					{
						EventManager.ShowGenericPopup("You've overspent " + Players[playerIndex].GetWeekPenaltyAmount().ToString() + " weeks! Delay added.");
					}

					if (status == Constants.STATUS_PASSED || CurrentPlayerEncounter[playerIndex].GetIsIndividualCheck())
					{
						EncounterResultsHandler.HandleSuccess(this, playerIndex);
						if (eventStatus.GetWasResourceEncounter())
                        {
							Coordinates resourceLocation = Players[playerIndex].GetPartyLocation();
							Resource resourceGained = new Resource(new Coordinates(resourceLocation.GetX(), resourceLocation.GetY()));
							Players[playerIndex].AddResourceOwned(resourceGained);
							ResourcePieceManagerInst.CreatePiece(playerIndex, Players[playerIndex].GetPlayerFaction(), resourceGained.GetLocation());
						}
					}
					if (status == Constants.STATUS_FAILED || CurrentPlayerEncounter[playerIndex].GetIsIndividualCheck())
					{
						EncounterResultsHandler.HandleFailure(this, playerIndex);
					}

					Players[playerIndex].ResetAllCharacterDiceRolls();
					Players[playerIndex].ResetAllVehicleDiceRolls();
					HasDoneEncounterSinceMovement[playerIndex] = true;


					if (eventStatus.GetEncounterType() == Constants.ENCOUNTER_PLAINS)
                    {
						PlainsCard card = PlainsCard.FindCardInDeckByTitle(CurrentPlayerEncounter[playerIndex].GetTitle(), PlainsDeck);
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
				else if(status == Constants.STATUS_FLIGHT)
                {
					Debug.LogError("When you flight, you should be able to move 1 hex away. This is not implemented at this time");

					Players[playerIndex].SetPlayerIsDoingAnEncounter(false);
					Players[playerIndex].SetEncounterType(Constants.ENCOUNTER_NONE);
					EncounterWasSent = false;
					HasDoneEncounterSinceMovement[playerIndex] = false;

					int previousWeeksRemaining = Players[playerIndex].GetRemainingPartyExploitWeeks();
					if (!eventStatus.GetWasResourceEncounter())
					{
						Players[playerIndex].SetRemainingPartyExploitWeeks(previousWeeksRemaining - EncounterWeekCost);
					}
					else
					{
						Players[playerIndex].SetRemainingPartyExploitWeeks(previousWeeksRemaining - ResourceWeekCost);
					}

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
			PhotonPeer.RegisterType(typeof(ResourceNetworking), Constants.EvResource, ResourceNetworking.SerializeResource, ResourceNetworking.DeserializeResource);
			PhotonPeer.RegisterType(typeof(HealingDeedNetworking), Constants.EvHealingDeed, HealingDeedNetworking.SerializeHealingDeed, HealingDeedNetworking.DeserializeHealingDeed);
			PhotonPeer.RegisterType(typeof(ShuffleNetworking), Constants.EvShuffle, ShuffleNetworking.SerializeShuffle, ShuffleNetworking.DeserializeShuffle);
			PhotonPeer.RegisterType(typeof(SalvageNetworking), Constants.EvSalvage, SalvageNetworking.SerializeSalvage, SalvageNetworking.DeserializeSalvage);
			PhotonPeer.RegisterType(typeof(TownDefenseNetworking), Constants.EvTownDefense, TownDefenseNetworking.SerializeTownDefense, TownDefenseNetworking.DeserializeTownDefense);
			PhotonPeer.RegisterType(typeof(TownTechNetworking), Constants.EvTownTech, TownTechNetworking.SerializeTownTech, TownTechNetworking.DeserializeTownTech);
		}

		private void sendNetworkEvent(object content, ReceiverGroup group, byte eventCode)
		{		
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = group };
			SendOptions sendOptions = new SendOptions { Reliability = true };
			PhotonNetwork.RaiseEvent(eventCode, content, raiseEventOptions, sendOptions);
		}

		private void handlePlayerCardNetworkUpdate(PlayerCardNetworking playerInfo)
		{
			int playerIndex = playerInfo.GetPlayerIndex();
			if (playerIndex == GetIndexForMyPlayer())
			{
				return;
			}
			string cardName = playerInfo.GetCardName();
			int slotIndex = playerInfo.GetFirstSlotIndex();
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
				removeCharacterFromParty(playerIndex, slotIndex);
			}
			else if (playerInfo.GetActionByte() == Constants.ADD_VEHICLE)
			{
				addSpecificVehicleToParty(playerIndex, cardName);
			}
			else if (playerInfo.GetActionByte() == Constants.REMOVE_VEHICLE)
			{
				SpoilsCard vehicle = Players[playerIndex].GetActiveVehicle();
				handleOnPartyCardUnequipRewardsAndPunishments(playerIndex, vehicle);
				Players[playerIndex].RemoveVehicleFromParty();
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
			else if (playerInfo.GetActionByte() == Constants.MOVE_CHARACTER_BETWEEN_SLOTS)
			{
				moveCharacterBetweenSlots(playerIndex, playerInfo.GetFirstSlotIndex(), playerInfo.GetSecondSlotIndex());
			}

			GameObject.Find("UIManager").GetComponent<GameUIManager>().ForceRedrawCharacterScreen();
		}

		private void handleSendingNetworkingUpdatePlayerInfo(object content)
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
			if (characterHealth.GetHealthEventType() == Constants.DAMAGE_PHYSICAL)
			{
				Players[playerIndex].AddPhysicalDamageToCharacter(characterIndex, characterHealth.GetAmount());
			}
			else if (characterHealth.GetHealthEventType() == Constants.DAMAGE_INFECTED)
			{
				Players[playerIndex].AddInfectedDamageToCharacter(characterIndex, characterHealth.GetAmount());
			}
			else if (characterHealth.GetHealthEventType() == Constants.DAMAGE_RADIATION)
			{
				Players[playerIndex].AddRadiationDamageToCharacter(characterIndex, characterHealth.GetAmount());
			}
			else if (characterHealth.GetHealthEventType() == Constants.HEAL_PHYSICAL)
			{
				Players[playerIndex].RemovePhysicalDamageFromCharacter(characterIndex, characterHealth.GetAmount());
			}
			else if (characterHealth.GetHealthEventType() == Constants.HEAL_INFECTED)
			{
				Players[playerIndex].RemoveInfectedDamageFromCharacter(characterIndex, characterHealth.GetAmount());
			}
			else if (characterHealth.GetHealthEventType() == Constants.HEAL_RADIATION)
			{
				Players[playerIndex].RemoveRadiationDamageFromCharacter(characterIndex, characterHealth.GetAmount());
			}

			handleCharacterDeathIfNecessary(playerIndex, characterIndex, characterHealth.GetShouldDiscardEquipmentIfDead());
		}

		private void handleCharacterDeathIfNecessary(int playerIndex, int characterIndex, bool shouldDiscardEquipmentOnDeath)
		{
			if (Players[playerIndex].GetActiveCharacters()[characterIndex] != null && Players[playerIndex].GetActiveCharacters()[characterIndex].GetHpRemaining() <= 0)
			{
				//Remove character
				CharacterCard character = Players[playerIndex].GetActiveCharacters()[characterIndex];
				if (shouldDiscardEquipmentOnDeath)
				{
					removeCharacterFromPartyAndDiscardEquipment(playerIndex, characterIndex);
				}
				else
				{
					removeCharacterFromParty(playerIndex, characterIndex);
				}
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

		private void handleResourceProduction()
        {
			for (int playerIndex = 0; playerIndex < PhotonNetwork.PlayerList.Length; playerIndex++)
			{
				int numberOfOwnedResources = Players[playerIndex].GetAllResourcesOwned().Count;
				int salvageToGain = 0;
				int townHealthToGain = 0;
                if (numberOfOwnedResources == 1)
                {
					salvageToGain = 1;
					townHealthToGain = 1;
				}
                else if (numberOfOwnedResources == 2)
                {
					salvageToGain = 4;
					townHealthToGain = 2;
				}
				else if (numberOfOwnedResources == 3)
				{
					salvageToGain = 9;
					townHealthToGain = 3;
				}
				else if (numberOfOwnedResources == 4)
				{
					salvageToGain = 16;
					townHealthToGain = 4;
				}
				else if (numberOfOwnedResources == 5)
				{
					salvageToGain = 25;
					townHealthToGain = 5;
				}
				Players[playerIndex].AddSalvageToPlayer(salvageToGain);
				Players[playerIndex].AddTownHealth(townHealthToGain);

				if (playerIndex == GetIndexForMyPlayer())
				{
					EventManager.ShowGenericPopup("You gained " + salvageToGain + " salvage coins and " + townHealthToGain + " town health because you own " + numberOfOwnedResources + " resources!");
				}
			}
		}

		private void handleResourceEvent(ResourceNetworking resourceNetworking)
		{
			int indexOfResourceOwner = resourceNetworking.GetOwnerIndex();
			Coordinates locationOfResource = resourceNetworking.GetResourceLocation();
			int indexOfCapturingPlayer = resourceNetworking.GetCaptorIndex();
			int myIndex = GetIndexForMyPlayer();

			HasDoneEncounterSinceMovement[indexOfCapturingPlayer] = true;

			Resource resourceToExchange = GetResource(indexOfResourceOwner, locationOfResource);
			applyTownDefenseDamage(indexOfCapturingPlayer);
			if (Players[indexOfCapturingPlayer].GetNumberOfCharactersActive() > 0)
			{
				Players[indexOfResourceOwner].RemoveResourceOwned(resourceToExchange);
				ResourcePieceManagerInst.RemovePiece(indexOfResourceOwner, locationOfResource);
				Players[indexOfCapturingPlayer].AddResourceOwned(resourceToExchange);
				ResourcePieceManagerInst.CreatePiece(indexOfCapturingPlayer, Players[indexOfCapturingPlayer].GetPlayerFaction(), locationOfResource);
				if (myIndex == indexOfCapturingPlayer)
				{
					EventManager.ShowGenericPopup("You've stolen the resource!");
				}
				else if (myIndex == indexOfResourceOwner)
				{
					EventManager.ShowGenericPopup("You've had a resource stolen!");
				}
			}
			else
			{
				if (indexOfCapturingPlayer == myIndex)
				{
					EventManager.ShowGenericPopup("You didn't capture the resource because everyone in your party died!");
				}
			}

			int remainingWeeks = Players[indexOfCapturingPlayer].GetRemainingPartyExploitWeeks();
			Players[indexOfCapturingPlayer].SetRemainingPartyExploitWeeks(remainingWeeks - ResourceWeekCost);
		}

		private void handleHealingDeedEvent(HealingDeedNetworking healingDeedNetworking)
		{
			byte status = healingDeedNetworking.GetStatusByte();
			int playerIndex = healingDeedNetworking.GetPlayerIndex();
			if (status == Constants.HEALING_DEED_BEGIN)
			{
				Players[playerIndex].SetPlayerIsHealing(true);
				Players[playerIndex].SetNumberOfSkillChecks(1);
			}
			else
			{
				Players[playerIndex].SetPlayerIsHealing(false);
				Players[playerIndex].ResetAllCharacterDiceRolls();
				Players[playerIndex].ResetAllVehicleDiceRolls();
				int previousWeeksCost = Players[playerIndex].GetRemainingPartyExploitWeeks();
				Players[playerIndex].SetRemainingPartyExploitWeeks(previousWeeksCost - HealingWeekCost);
			}
		}

		private void handleShuffleEvent(ShuffleNetworking shuffle)
		{
			byte deckToShuffle = shuffle.GetDeckToShuffle();
			if (deckToShuffle == Constants.SHUFFLE_ACTION)
			{
				for (int cardIndex = DiscardedActionCards.Count - 1; cardIndex >= 0; cardIndex--)
				{
					ActionDeck.Add(DiscardedActionCards[cardIndex]);
					DiscardedActionCards.RemoveAt(cardIndex);
				}
				ActionDeck = Card.ShuffleDeck(ActionDeck);
			}
			else if (deckToShuffle == Constants.SHUFFLE_CHARACTERS)
			{
				for (int cardIndex = DiscardedCharacters.Count - 1; cardIndex >= 0; cardIndex--)
				{
					CharacterDeck.Add(DiscardedCharacters[cardIndex]);
					DiscardedCharacters.RemoveAt(cardIndex);
				}
				CharacterDeck = Card.ShuffleDeck(CharacterDeck);
			}
			else if (deckToShuffle == Constants.SHUFFLE_CITYRAD)
			{
				//TODO when city rad encounter implemented
			}
			else if (deckToShuffle == Constants.SHUFFLE_MOUNTAINS)
			{
				//TODO when mountain encounter implemented
			}
			else if (deckToShuffle == Constants.SHUFFLE_PLAINS)
			{
				for (int cardIndex = DiscardedPlainsCards.Count - 1; cardIndex >= 0; cardIndex--)
				{
					PlainsDeck.Add(DiscardedPlainsCards[cardIndex]);
					DiscardedPlainsCards.RemoveAt(cardIndex);
				}
				PlainsDeck = Card.ShuffleDeck(PlainsDeck);
			}
			else if (deckToShuffle == Constants.SHUFFLE_SPOILS)
			{
				for (int cardIndex = DiscardedSpoilsDeck.Count - 1; cardIndex >= 0; cardIndex--)
				{
					SpoilsDeck.Add(DiscardedSpoilsDeck[cardIndex]);
					DiscardedSpoilsDeck.RemoveAt(cardIndex);
				}
				SpoilsDeck = Card.ShuffleDeck(SpoilsDeck);
			}
		}

		private void handleSalvageNetworkingEvent(SalvageNetworking salvageNetworking)
		{
			int playerIndex = salvageNetworking.GetPlayerIndex();
			byte action = salvageNetworking.GetAction();
			if (action == Constants.SALVAGE_GAIN)
			{
				Players[playerIndex].AddSalvageToPlayer(salvageNetworking.GetAmount());
			}
			else if(action == Constants.SALVAGE_LOSE)
            {
				Players[playerIndex].RemoveSalvageFromPlayer(salvageNetworking.GetAmount());
			}
		}

		private void handleTownDefenseEvent(TownDefenseNetworking townDefenseNetworking)
		{
			int playerIndex = townDefenseNetworking.GetPlayerIndex();
			byte action = townDefenseNetworking.GetAction();
			if (action == Constants.BUY_TOWN_DEFENSE)
			{
				int numberOwned = Players[playerIndex].GetNumberOfTownDefenseChips();
				int cost = Constants.TOWN_DEFENSE_CHIP_COST[numberOwned];
				Players[playerIndex].SetNumberOfTownDefenseChips(numberOwned + 1);
				Players[playerIndex].RemoveSalvageFromPlayer(cost);
			}
			else if (action == Constants.SELL_TOWN_DEFENSE)
			{
				Players[playerIndex].SetNumberOfTownDefenseChips(Players[playerIndex].GetNumberOfTownDefenseChips() - 1);
				Players[playerIndex].AddSalvageToPlayer(Constants.SALVAGE_FOR_SELLING_TOWN_DEFENSE_CHIP);
			}
			else if (action == Constants.USE_TOWN_DEFENSE_FOR_TOWN_HEALTH)
			{
				//TODO in future story
			}
		}

		private void handleTownTechEvent(TownTechNetworking townTechNetworking)
		{
			int playerIndex = townTechNetworking.GetPlayerIndex();
			byte action = townTechNetworking.GetActionByte();
			string townTechName = townTechNetworking.GetTechName();

			if (action == Constants.BUY_TOWN_TECH)
			{
				TownTech townTechToBuy = new TownTech(Constants.DEFAULT_TOWN_TECHS.GetTownTechByName(townTechName));
				Players[playerIndex].AddTownTech(townTechToBuy);
				Players[playerIndex].RemoveSalvageFromPlayer(townTechToBuy.GetPurchaseCost());
				TechsUsed[townTechName]++;
				Players[playerIndex].AddPrestige(1);
				Players[playerIndex].AddTownHealth(5);
				EventManager.ShowGenericPopup("For purchasing a town tech, you also gained 1 prestige and 5 town health!");
				TownTechManager.HandleTownTechPurchase(this, playerIndex, townTechToBuy);
			}
			else if (action == Constants.SELL_TOWN_TECH)
			{
				List<TownTech> townTechs = Players[playerIndex].GetTownTechs();
				for (int townTechIndex = 0; townTechIndex < townTechs.Count; ++townTechIndex)
				{
					if (townTechs[townTechIndex].GetTechName().Equals(townTechName))
					{
						Players[playerIndex].AddSalvageToPlayer(townTechs[townTechIndex].GetSellCost());
						TownTechManager.HandleTownTechSell(this, playerIndex, townTechs[townTechIndex]);
						Players[playerIndex].SellTownTech(townTechIndex);
						Players[playerIndex].SubtractPrestige(1);
						Players[playerIndex].SubtractTownHealth(5);
						if (playerIndex == GetIndexForMyPlayer())
						{
							EventManager.ShowGenericPopup("For selling a town tech, you also lost 1 prestige and 5 town health!");
						}
						break;
					}
				}
			}
			else if (action == Constants.UPGRADE_TOWN_TECH)
			{
				List<TownTech> townTechs = Players[playerIndex].GetTownTechs();
				for (int townTechIndex = 0; townTechIndex < townTechs.Count; ++townTechIndex)
				{
					if (townTechs[townTechIndex].GetTechName().Equals(townTechName))
					{
						Players[playerIndex].UpgradeTownTech(townTechIndex);
						Players[playerIndex].RemoveSalvageFromPlayer(townTechs[townTechIndex].GetUpgradeCost());
						TownTechManager.HandleTownTechUpgrade(this, playerIndex, townTechs[townTechIndex]);
						break;
					}
				}
			}
			else if (action == Constants.DOWNGRADE_TOWN_TECH)
			{
				List<TownTech> townTechs = Players[playerIndex].GetTownTechs();
				for (int townTechIndex = 0; townTechIndex < townTechs.Count; ++townTechIndex)
				{
					if (townTechs[townTechIndex].GetTechName().Equals(townTechName))
					{
						Players[playerIndex].DowngradeTownTech(townTechIndex);
						Players[playerIndex].AddSalvageToPlayer(townTechs[townTechIndex].GetSellCost());
						TownTechManager.HandleTownTechDowngrade(this, playerIndex, townTechs[townTechIndex]);
						break;
					}
				}
			}
		}

		private void endPhaseForAllPlayers()
        {
			TurnManager.BeginNextPhase();
		}

		private void shuffleDecksIfNeeded()
		{
			shuffleEncounterDecksIfNeeded();
			if (CharacterDeck.Count == 0)
			{
				shuffleCharacterDeck();
			}
			if (SpoilsDeck.Count == 0)
			{
				shuffleSpoilsDeck();
			}
		}

		private void shuffleEncounterDecksIfNeeded()
        {
			if (PlainsDeck.Count == 0)
			{
				shufflePlainsDeck();
			}

			//todo for mountains

			//todo for city/rad
		}

		private void shufflePlainsDeck()
		{
			while (DiscardedPlainsCards.Count > 0)
			{
				PlainsDeck.Add(DiscardedPlainsCards[0]);
				DiscardedPlainsCards.RemoveAt(0);
			}
			PlainsDeck = Card.ShuffleDeck(PlainsDeck);
			Debug.Log("Shuffled plains encounter deck");
		}

		private void shuffleCharacterDeck()
		{
			while (DiscardedCharacters.Count > 0)
			{
				CharacterDeck.Add(DiscardedCharacters[0]);
				DiscardedCharacters.RemoveAt(0);
			}
			CharacterDeck = Card.ShuffleDeck(CharacterDeck);
			Debug.Log("Shuffled characters deck");
		}

		private void shuffleSpoilsDeck()
		{
			while (DiscardedSpoilsDeck.Count > 0)
			{
				SpoilsDeck.Add(DiscardedSpoilsDeck[0]);
				DiscardedSpoilsDeck.RemoveAt(0);
			}
			SpoilsDeck = Card.ShuffleDeck(SpoilsDeck);
			Debug.Log("Shuffled spoils deck");
		}

		private byte getDeckToShuffleFromEncounterType(int encounterType)
		{
			byte deckByte = Constants.SHUFFLE_PLAINS;
			if (encounterType == Constants.ENCOUNTER_CITY_RAD)
			{
				deckByte = Constants.SHUFFLE_CITYRAD;
			}
			else if (encounterType == Constants.ENCOUNTER_MOUNTAINS)
			{
				deckByte = Constants.SHUFFLE_MOUNTAINS;
			}
			return deckByte;
		}

		private List<Precheck> getPrechecks(int encounterType, int cardIndex)
		{
			List<Precheck> prechecks = PlainsDeck[cardIndex].GetPrechecks();
			if (encounterType == Constants.ENCOUNTER_CITY_RAD)
			{
				//prechecks = CityRadDeck[cardIndex].GetPrechecks();
			}
			else if (encounterType == Constants.ENCOUNTER_MOUNTAINS)
			{
				//prechecks = MountaisDeck[cardIndex].GetPrechecks();
			}
			return prechecks;
		}

		private void figureOutMyUserId()
		{
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
		}

		private void createMap()
		{
			GameObject mapCreationGO = GameObject.Find("Map");
			MapCreation mapCreation = mapCreationGO.GetComponent<MapCreation>();
			mapCreation.CreateMap(MapLayoutInst);
			PlayerPieceManagerInst.SetMap(mapCreation);
			MissionManagerInst.SetMap(mapCreation);
			ResourcePieceManagerInst.SetMap(mapCreation);
		}

		private void handleNewGameNetworkingIfNeeded()
		{
			NewGameState = GameObject.Find("GameCreation");
			if (NewGameState != null && PhotonNetwork.IsMasterClient)
			{
				GameObject mapCreationGO = GameObject.Find("Map");
				MapCreation mapCreation = mapCreationGO.GetComponent<MapCreation>();

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
					handleTownTechsOnStart(playerIndex);
				}
				ReceivedMyFactionInformation = true;

				CameraManager mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraManager>();
				mainCamera.MoveCameraToFactionBaseLocation(mapCreation, Players[GetIndexForMyPlayer()].GetPlayerFaction());

				generateMissionLocations();
				sendMissionLocationsToOtherPlayers();

				//Interpret any modifiers
				//TODO when these are implemented
			}
		}

		private void createDecks()
		{
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

		private void handleEffectsResolveSubphase()
		{
			int myIndex = GetIndexForMyPlayer();
			for (int playerIndex = 0; playerIndex < PhotonNetwork.PlayerList.Length; playerIndex++)
			{
				List<CharacterCard> party = Players[playerIndex].GetActiveCharacters();
				for (int characterIndex = 0; characterIndex < Constants.NUM_PARTY_MEMBERS; characterIndex++)
				{
					if (party[characterIndex] != null && party[characterIndex].GetAmountOfInfectedDamage() > 0)
					{
						int remainingHp = party[characterIndex].GetHpRemaining() - 1;
						DealSetAmountOfInfectedDamageToIndividual(playerIndex, characterIndex, 1);
						if (playerIndex == myIndex)
						{
							EventManager.CharacterCrownHasTakenDamage(characterIndex, 1, Constants.DAMAGE_INFECTED, remainingHp, false);
						}
					}
				}
			}
		}

		private void handleGameStartIfNeeded()
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

		private void handleEffects()
		{
			for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
			{
				EffectsManager.HandleEffects(this, playerIndex);
			}
		}

		private void handleLinks()
		{
			for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
			{
				LinksManager.HandleLinks(this, playerIndex);
			}
		}

		private void handlePhase()
		{
			int myIndex = GetIndexForMyPlayer();
			if (Players[myIndex].GetPlayerIsMoving())
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
			else if (Players[myIndex].GetPlayerIsDoingAnEncounter() && !EncounterWasSent)
			{
				PartyExploitsNetworking content = new PartyExploitsNetworking(myIndex, Constants.PARTY_EXPLOITS_ENCOUNTER);
				content.SetEncounterType((byte)GetPlayerEncounterType(myIndex));
				int cardIndex = 0;
				bool prechecksHeld;
				do
				{
					prechecksHeld = true;
					List<Precheck> prechecks = getPrechecks(GetPlayerEncounterType(myIndex), cardIndex);
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

					if (cardIndex >= PlainsDeck.Count && DiscardedPlainsCards.Count > 0)
					{
						Debug.Log("Ran out of cards in the deck and there are discarded cards. Shuffling and networking to try to find a card where prechecks hold");
						ShuffleNetworking shuffle = new ShuffleNetworking(getDeckToShuffleFromEncounterType(GetPlayerEncounterType(myIndex)));
						sendNetworkEvent(shuffle, ReceiverGroup.Others, Constants.EvShuffle);
						handleShuffleEvent(shuffle);
						cardIndex = 0;
					}
					else if (cardIndex >= PlainsDeck.Count && DiscardedPlainsCards.Count == 0)
					{
						Debug.Log("Ran out of cards in the deck, but there are no cards int he discard deck, so we have to do the first card even though we didn't pass prechecks");
						cardIndex = 0;
						break;
					}
				}
				while (cardIndex < PlainsDeck.Count && !prechecksHeld);

				PlainsDeck[cardIndex].ResetState();
				string nextPlainsEncounterCardName = PlainsDeck[cardIndex].GetTitle();
				content.SetEncounterCardName(nextPlainsEncounterCardName);
				sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvPartyExploits);
				handlePartyExploitsNetworkUpdate(content);
				EncounterWasSent = true;
			}
			else if (GetIsItMyTurn() && ShouldSkipPhase)
			{
				EndPhase(myIndex);
				ShouldSkipPhase = false;
			}
			else if (CurrentPhase == Phases.Party_Exploits_Party)
			{
				for (int playerIndex = 0; playerIndex < Players.Count; ++playerIndex)
				{
					int penaltyAmount = Players[playerIndex].GetWeekPenaltyAmount();
					if (penaltyAmount > 0 && Players[playerIndex].GetRemainingPartyExploitWeeks() > 0)
					{
						Players[playerIndex].SetRemainingPartyExploitWeeks(Players[playerIndex].GetRemainingPartyExploitWeeks() - penaltyAmount);
						Players[playerIndex].ResetWeekPenalty();
					}
				}
			}
		}

		private bool haveAllCharactersRolledOnce(int playerIndex, int skillIndex)
		{
			bool allHaveRolledOnce = true;
			for (int characterIndex = 0; characterIndex < Constants.NUM_PARTY_MEMBERS; characterIndex++)
			{
				if (Players[playerIndex].GetActiveCharacters()[characterIndex] != null && Players[playerIndex].GetLastCharacterDiceRoll(characterIndex, skillIndex) == Constants.HAS_NOT_ROLLED)
				{
					allHaveRolledOnce = false;
					break;
				}

				if (Players[playerIndex].GetActiveVehicle() != null && Players[playerIndex].GetLastVehicleDiceRoll(skillIndex) == Constants.HAS_NOT_ROLLED)
				{
					allHaveRolledOnce = false;
					break;
				}
			}

			return allHaveRolledOnce;
		}

		private bool hasIndividualRolledOnce(int playerIndex, int characterIndex, int skillIndex)
		{
			bool hasRolledOnceForSkill = true;

			if (Players[playerIndex].GetActiveCharacters()[characterIndex] != null && Players[playerIndex].GetLastCharacterDiceRoll(characterIndex, skillIndex) == Constants.HAS_NOT_ROLLED)
			{
				hasRolledOnceForSkill = false;
			}

			return hasRolledOnceForSkill;
		}
		#endregion
	}
}