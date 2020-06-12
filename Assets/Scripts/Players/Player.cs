using System.Collections.Generic;

namespace FallenLand
{
	public abstract class Player
	{
		private List<SpoilsCard> AuctionHouse;
		private List<ActionCard> ActionCardsInHand;
		private List<CharacterCard> ActiveCharacters;
		private SpoilsCard Vehicle;
		private List<CharacterCard> TownRoster;
		private Faction FactionOfPlayer;
		private List<TownTech> TownTechs;
		private int AmountOfSalvage;
		private int Id;
		private List<Dictionary<Skills, int>> ActiveCharacterTotalStats;
		private List<int> ActiveCharacterCarryWeights;
	    private Dictionary<Skills, int> ActiveVehicleTotalStats;
		private int ActiveVehicleCarryWeight;
		private List<Coordinates> OwnedResourceLocations;

		public Player(Faction faction, int startingSalvage)
		{
			if (startingSalvage < 0)
			{
				startingSalvage = 0;
			}
			if (faction == null)
			{
				faction = new Faction("dummy faction", new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION));
			}

			AmountOfSalvage = startingSalvage;
			FactionOfPlayer = faction;
			Vehicle = null;
			ActiveVehicleCarryWeight = 0;
			initLists();
			extractTownTechsFromFaction();
		}

		public List<SpoilsCard> GetAuctionHouseCards()
		{
			return AuctionHouse;
		}

		public List<ActionCard> GetActionCards()
		{
			return ActionCardsInHand;
		}

		public List<CharacterCard> GetTownRoster()
		{
			return TownRoster;
		}

		public void SetPlayerFaction(Faction faction)
		{
			if (faction != null)
			{
				FactionOfPlayer = faction;
			}
			extractTownTechsFromFaction();
		}

		public Faction GetPlayerFaction()
		{
			return FactionOfPlayer;
		}

		public int GetSalvageAmount()
		{
			return AmountOfSalvage;
		}

		public List<TownTech> GetTownTechs()
		{
			return TownTechs;
		}

		public List<CharacterCard> GetActiveCharacters()
		{
			return ActiveCharacters;
		}

		public SpoilsCard GetActiveVehicle()
		{
			return Vehicle;
		}

		public int GetNumberOfCharactersActive()
		{
			int count = 0;
			for (int i = 0; i < ActiveCharacters.Count; i++)
			{
				if (ActiveCharacters[i] != null)
				{
					count++;
				}
			}
			return count;
		}

		public int GetNumberOfActiveVehicles()
		{
			int count = 0;
			if (Vehicle != null)
			{
				count++;
			}
			return count;
		}

		public Dictionary<Skills, int> GetActiveCharacterStats(int characterIndex)
		{
			return ActiveCharacterTotalStats[characterIndex];
		}

		public int GetActiveCharacterCarryWeight(int characterIndex)
		{
			return ActiveCharacterCarryWeights[characterIndex];
		}

		public Dictionary<Skills, int> GetActiveVehicleStats()
		{
			return ActiveVehicleTotalStats;
		}

		public int GetActiveVehicleCarryWeight()
		{
			return ActiveVehicleCarryWeight;
		}

		public List<Coordinates> GetOwnedResources()
		{
			return OwnedResourceLocations;
		}

		public void RemoveSalvageFromPlayer(int salvageToRemove)
		{
			if (salvageToRemove > 0)
			{
				AmountOfSalvage -= salvageToRemove;
			}
			if (AmountOfSalvage < 0)
			{
				AmountOfSalvage = 0;
			}
		}

		public void RemoveSpoilsCardFromAuctionHouse(SpoilsCard card)
		{
			if (AuctionHouse.Contains(card))
			{
				AuctionHouse.Remove(card);
			}
		}

		public void RemoveCharacterFromTownRoster(CharacterCard card)
		{
			if (TownRoster.Contains(card))
			{
				TownRoster.Remove(card);
			}
		}

		public void RemoveSpoilsCardFromActiveCharacter(int characterIndex, SpoilsCard card)
		{
			if (ActiveCharacters[characterIndex].GetEquippedSpoils().Contains(card))
			{
				ActiveCharacters[characterIndex].RemoveSpoilsCard(card);
				updateCharacterSlotTotals(characterIndex);
			}
		}

		public void RemoveCharacterFromParty(int characterIndex)
		{
			ActiveCharacters[characterIndex] = null;
			updateCharacterSlotTotals(characterIndex);
		}

		public void RemoveStowableFromActiveVehicle(SpoilsCard card)
		{
			if (Vehicle != null && Vehicle.GetEquippedSpoils().Contains(card))
			{
				Vehicle.RemoveSpoilsCard(card);
				updateVehicleSlotTotals();
			}
		}

		public void RemoveActiveVehicle()
		{
			Vehicle = null;
			updateVehicleSlotTotals();
		}

		public void AddOwnedResource(Coordinates coord)
		{
			if (coord != null)
			{
				OwnedResourceLocations.Add(coord);
			}
		}

		public void AddSalvageToPlayer(int salvageToAdd)
		{
			if (salvageToAdd > 0)
			{
				AmountOfSalvage += salvageToAdd;
			}
		}

		public void AddSpoilsCardToAuctionHouse(SpoilsCard spoilsCard)
		{
			if (spoilsCard != null)
			{
				AuctionHouse.Add(spoilsCard);
			}
		}

		public void AddCharacterCardToTownRoster(CharacterCard characterCard)
		{
			if (characterCard != null)
			{
				TownRoster.Add(characterCard);
			}
		}

		public void AddActionCardToHand(ActionCard actionCard)
		{
			if (actionCard != null)
			{
				ActionCardsInHand.Add(actionCard);
			}
		}

		public void AddVehicleToParty(SpoilsCard vehicleCard)
		{
			if (vehicleCard != null && Vehicle == null && vehicleCard.GetSpoilsTypes().Contains(SpoilsTypes.Vehicle))
			{
				Vehicle = vehicleCard;
				updateVehicleSlotTotals();
			}
		}

		public void AddStowableToActiveVehicle(SpoilsCard stowableCard)
		{
			if (stowableCard != null && Vehicle != null && stowableCard.GetSpoilsTypes().Contains(SpoilsTypes.Stowable))
			{
				Vehicle.AttachSpoilsCard(stowableCard);
				updateVehicleSlotTotals();
			}
		}

		public void AddTownTech(TownTech techToAdd)
		{
			if (techToAdd != null)
			{
				TownTechs.Add(techToAdd);
			}
		}

		public void AddCharacterToParty(int characterIndex, CharacterCard character)
		{
			if (character != null && ActiveCharacters[characterIndex] == null)
			{
				ActiveCharacters[characterIndex] = character;
				updateCharacterSlotTotals(characterIndex);
			}
		}

		public void AddSpoilsToCharacter(int characterIndex, SpoilsCard card)
		{
			if (ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].AttachSpoilsCard(card);
				updateCharacterSlotTotals(characterIndex);
			}
		}

		public bool IsAllowedToAddSpoilsCardToCharacter(int characterIndex, SpoilsCard card)
		{
			bool isAllowed = false;
			if (characterIndex < ActiveCharacters.Count && ActiveCharacters[characterIndex] != null && !card.GetSpoilsTypes().Contains(SpoilsTypes.Vehicle))
			{
				isAllowed = true;
			}
			return isAllowed;
		}

		public bool IsAllowedToEquipVehicleToSlot()
		{
			bool isAllowed = false;
			if (Vehicle == null)
			{
				isAllowed = true;
			}
			return isAllowed;
		}

		public bool IsAllowedToEquipSpoilsToVehicle(SpoilsCard card)
		{
			bool isAllowed = false;
			if (Vehicle != null && card != null && card.GetSpoilsTypes().Contains(SpoilsTypes.Stowable))
			{
				isAllowed = true;
			}
			return isAllowed;
		}

		public bool IsAllowedToAddCharacterToParty(int characterIndex)
		{
			bool isAllowed = false;
			if (ActiveCharacters[characterIndex] == null)
			{
				isAllowed = true;
			}
			return isAllowed;
		}


		private void initLists()
		{
			AuctionHouse = new List<SpoilsCard>();
			ActionCardsInHand = new List<ActionCard>();
			TownRoster = new List<CharacterCard>();
			ActiveCharacters = new List<CharacterCard>();
			TownTechs = new List<TownTech>();
			ActiveCharacterCarryWeights = new List<int>();
			OwnedResourceLocations = new List<Coordinates>();

			for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
			{
				ActiveCharacters.Add(null);
			}

			ActiveCharacterTotalStats = new List<Dictionary<Skills, int>>();
			for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
			{
				ActiveCharacterTotalStats.Add(new Dictionary<Skills, int>());
				foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
				{
					ActiveCharacterTotalStats[i].Add(skill, 0);
				}
				ActiveCharacterCarryWeights.Add(0);
			}

			ActiveVehicleTotalStats = new Dictionary<Skills, int>();
			foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
			{
				ActiveVehicleTotalStats.Add(skill, 0);
			}
		}

		private void extractTownTechsFromFaction()
		{
			List<TownTech> techs = FactionOfPlayer.GetStartingTownTechs();
			if (techs != null)
			{
				TownTechs = techs;
			}
		}

		private void updateCharacterSlotTotals(int indexToUpdate)
		{
			if (ActiveCharacters[indexToUpdate] != null)
			{
				Dictionary<Skills, int> currentCharacterSkills = ActiveCharacters[indexToUpdate].GetBaseSkills();
				List<SpoilsCard> equippedSpoils = ActiveCharacters[indexToUpdate].GetEquippedSpoils();
				foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
				{
					int tempSum = currentCharacterSkills[skill];
					for (int i = 0; i < equippedSpoils.Count; i++)
					{
						tempSum += equippedSpoils[i].GetBaseSkills()[skill];
					}

					ActiveCharacterTotalStats[indexToUpdate][skill] = tempSum;
				}
				int tempCarryWeight = 0;
				for (int i = 0; i < equippedSpoils.Count; i++)
				{
					tempCarryWeight += equippedSpoils[i].GetCarryWeight();
				}
				ActiveCharacterCarryWeights[indexToUpdate] = tempCarryWeight;
			}
			else
			{
				foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
				{
					ActiveCharacterTotalStats[indexToUpdate][skill] = 0;
					ActiveCharacterCarryWeights[indexToUpdate] = 0;
				}
			}
		}

		private void updateVehicleSlotTotals()
		{
			if (Vehicle != null)
			{
				List<SpoilsCard> equippedSpoils = Vehicle.GetEquippedSpoils();
				foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
				{
					int tempSum = Vehicle.GetBaseSkills()[skill];
					for (int i = 0; i < equippedSpoils.Count; i++)
					{
						tempSum += equippedSpoils[i].GetBaseSkills()[skill];
					}

					ActiveVehicleTotalStats[skill] = tempSum;
				}
				int tempCarryWeight = 0;
				for (int i = 0; i < equippedSpoils.Count; i++)
				{
					tempCarryWeight += equippedSpoils[i].GetCarryWeight();
				}
				ActiveVehicleCarryWeight = tempCarryWeight;
			}
			else
			{
				foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
				{
					ActiveVehicleTotalStats[skill] = 0;
					ActiveVehicleCarryWeight = 0;
				}
			}
		}
	}
}
