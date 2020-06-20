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

					//Send faction information to other players
					object content = new FactionNetworking(factionName, playerIndex);
					sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvSendFactionInformation);

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
			else if (eventCode == Constants.EvSendPlayerInformation)
			{
				Debug.Log("Received updated player information");
				PlayerNetworking playerInfo = (PlayerNetworking)photonEvent.CustomData;
				handlePlayerNetworkUpdate(playerInfo);
			}
			else if (eventCode == Constants.EvRequestUpdateToPlayerInformation)
			{
				Debug.Log("Got a request to update player information");
				object playerInfo = photonEvent.CustomData;
				sendNetworkEvent(playerInfo, ReceiverGroup.Others, Constants.EvSendPlayerInformation);
				handlePlayerNetworkUpdate((PlayerNetworking)playerInfo);
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
				object content = new PlayerNetworking(GetIndexForMyPlayer(), Constants.REMOVE_FROM_AUCTION_HOUSE, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void RemoveCharacterFromTownRoster(int playerIndex, CharacterCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveCharacterFromTownRoster(card);
				object content = new PlayerNetworking(GetIndexForMyPlayer(), Constants.REMOVE_FROM_TOWN_ROSTER, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void RemoveSpoilsCardFromPlayerActiveParty(int playerIndex, int characterSlotIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveSpoilsCardFromActiveCharacter(characterSlotIndex, card);
				object content = new PlayerNetworking(GetIndexForMyPlayer(), Constants.REMOVE_SPOILS_FROM_SLOT, card.GetTitle(), characterSlotIndex);
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void RemoveCharacterFromActiveParty(int playerIndex, int characterSlotFoundIn)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveCharacterFromParty(characterSlotFoundIn);
				object content = new PlayerNetworking(GetIndexForMyPlayer(), Constants.REMOVE_CHARACTER_FROM_SLOT, "", characterSlotFoundIn);
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void RemoveSpoilsCardFromActiveVehicle(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveStowableFromActiveVehicle(card);
				object content = new PlayerNetworking(GetIndexForMyPlayer(), Constants.REMOVE_SPOILS_FROM_VEHICLE, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void RemoveActiveVehicle(int playerIndex)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].RemoveActiveVehicle();
				object content = new PlayerNetworking(GetIndexForMyPlayer(), Constants.REMOVE_VEHICLE, "");
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AssignSpoilsCardToCharacter(int playerIndex, int characterIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddSpoilsToCharacter(characterIndex, card);
				object content = new PlayerNetworking(GetIndexForMyPlayer(), Constants.ADD_SPOILS_TO_SLOT, card.GetTitle(), characterIndex);
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AssignCharacterToParty(int playerIndex, int characterIndex, CharacterCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddCharacterToParty(characterIndex, card);
				object content = new PlayerNetworking(GetIndexForMyPlayer(), Constants.ADD_CHARACTER_TO_SLOT, card.GetTitle(), characterIndex);
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AddSpoilsToAuctionHouse(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddSpoilsCardToAuctionHouse(card);
				object content = new PlayerNetworking(GetIndexForMyPlayer(), Constants.ADD_TO_AUCTION_HOUSE, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AddCharacterToTownRoster(int playerIndex, CharacterCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddCharacterCardToTownRoster(card);
				object content = new PlayerNetworking(GetIndexForMyPlayer(), Constants.ADD_TO_TOWN_ROSTER, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AddVehicleToActiveParty(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddVehicleToParty(card);
				object content = new PlayerNetworking(GetIndexForMyPlayer(), Constants.ADD_VEHICLE, card.GetTitle());
				handleNetworkingUpdatePlayerInfo(content);
			}
		}

		public void AddSpoilsToActiveVehicle(int playerIndex, SpoilsCard card)
		{
			if (isPlayerIndexInRange(playerIndex))
			{
				Players[playerIndex].AddSpoilsToActiveVehicle(card);
				object content = new PlayerNetworking(GetIndexForMyPlayer(), Constants.ADD_SPOILS_TO_VEHICLE, card.GetTitle());
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
			object content = new CardNetworking(cardName, playerIndex, Constants.SPOILS_CARD);
			sendNetworkEvent(content, ReceiverGroup.Others, Constants.EvDealCard);
			dealSpecificSpoilToPlayerFromDeck(playerIndex, cardName);
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

		private void registerPhotonCallbacks()
		{
			PhotonPeer.RegisterType(typeof(CardNetworking), Constants.EvDealCard, CardNetworking.SerializeCard, CardNetworking.DeserializeCard);
			PhotonPeer.RegisterType(typeof(FactionNetworking), Constants.EvSendFactionInformation, FactionNetworking.SerializeFaction, FactionNetworking.DeserializeFaction);
			PhotonPeer.RegisterType(typeof(PlayerNetworking), Constants.EvSendPlayerInformation, PlayerNetworking.SerializePlayer, PlayerNetworking.DeserializePlayer);
			PhotonPeer.RegisterType(typeof(PlayerNetworking), Constants.EvRequestUpdateToPlayerInformation, PlayerNetworking.SerializePlayer, PlayerNetworking.DeserializePlayer);
		}

		private void sendNetworkEvent(object content, ReceiverGroup group, byte eventCode)
		{		
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = group };
			SendOptions sendOptions = new SendOptions { Reliability = true };
			PhotonNetwork.RaiseEvent(eventCode, content, raiseEventOptions, sendOptions);
		}

		private void handlePlayerNetworkUpdate(PlayerNetworking playerInfo)
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

		private void townBusinessPhase_DealSubphase()
		{
			for (int i = 0; i < Players.Count; i++)
			{
				Players[i].AddActionCardToHand(ActionDeck[0]);
				Debug.Log("Dealt card " + ActionDeck[0].GetTitle());
				object content = ActionDeck[0];
				RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
				SendOptions sendOptions = new SendOptions { Reliability = true };
				PhotonNetwork.RaiseEvent(Constants.EvDealCard, content, raiseEventOptions, sendOptions);
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
