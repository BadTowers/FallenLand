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
			initLists();
			extractTownTechsFromFaction();
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
			}
		}

		public void AddStowableToVehicle(SpoilsCard stowableCard)
		{
			if (stowableCard != null && Vehicle != null && stowableCard.GetSpoilsTypes().Contains(SpoilsTypes.Stowable))
			{
				Vehicle.AttachSpoilsCard(stowableCard);
			}
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

		public void AddSalvageToPlayer(int salvageToAdd)
		{
			if (salvageToAdd > 0)
			{
				AmountOfSalvage += salvageToAdd;
			}
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

		public void AddTownTech(TownTech techToAdd)
		{
			if (techToAdd != null)
			{
				TownTechs.Add(techToAdd);
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
			}
		}

		public void RemoveCharacterFromParty(int characterIndex)
		{
			ActiveCharacters[characterIndex] = null;
		}

		public void RemoveSpoilsCardFromActiveVehicle(SpoilsCard card)
		{
			if (Vehicle != null && Vehicle.GetEquippedSpoils().Contains(card))
			{
				Vehicle.RemoveSpoilsCard(card);
			}
		}

		public void RemoveActiveVehicle()
		{
			Vehicle = null;
		}

		public void AddCharacterToParty(int characterIndex, CharacterCard character)
		{
			if (character != null && ActiveCharacters[characterIndex] == null)
			{
				ActiveCharacters[characterIndex] = character;
			}
		}

		public void AddSpoilsToCharacter(int characterIndex, SpoilsCard card)
		{
			if (ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].AttachSpoilsCard(card);
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

			for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
			{
				ActiveCharacters.Add(null);
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
	}
}
