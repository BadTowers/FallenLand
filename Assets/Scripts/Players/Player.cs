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
		private List<Dictionary<Skills, int>> ActiveCharacterTotalStats;
		private List<int> ActiveCharacterRemainingCarryWeights;
		private List<int> ActiveCharacterUsedCarryWeights;
		private Dictionary<Skills, int> ActiveVehicleTotalStats;
		private int ActiveVehicleRemainingCarryWeight;
		private int TownHealth;
		private int Prestige;
		private int RemainingPartyExploitWeeks;
		private bool PlayerIsMoving;
		private Coordinates PartyLocation;
		private bool PlayerIsDoingAnEncounter;
		private bool PlayerIsHealing;
		private int EncounterType;
		private int ActiveVehicleUsedCarryWeight;
		private List<List<List<int>>> CharacterDiceRolls;
		private List<List<int>> VehicleDiceRolls;
		private readonly List<Resource> ResourcesOwned = new List<Resource>();
		private int BonusMovementGained;
		private List<Effect> ActiveEffects = new List<Effect>();
		private List<SpoilsCard> PartyEquipment = new List<SpoilsCard>();
		private int NumberOfTownDefenseChips;
		private readonly Dictionary<Skills, int> TownTechSuccesses = new Dictionary<Skills, int>();
		private int WeekPenalty;

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
			ActiveVehicleRemainingCarryWeight = 0;
			initDataStructures();
			extractTownTechsFromFaction();
			TownHealth = 1;
			Prestige = 1;
			RemainingPartyExploitWeeks = 4;
			PlayerIsDoingAnEncounter = false;
			EncounterType = Constants.ENCOUNTER_NONE;

			foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
			{
				TownTechSuccesses[skill] = 0;
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

		public int GetActiveCharacterRemainingCarryWeight(int characterIndex)
		{
			return ActiveCharacterRemainingCarryWeights[characterIndex];
		}

		public int GetActiveCharacterUsedCarryWeight(int characterIndex)
		{
			return ActiveCharacterUsedCarryWeights[characterIndex];
		}

		public int GetActiveCharacterTotalCarryWeight(int characterIndex)
		{
			int carryWeight = 0;
			if (characterIndex < ActiveCharacters.Count && ActiveCharacters[characterIndex] != null)
			{
				carryWeight = ActiveCharacters[characterIndex].GetCarryCapacity();
			}
			return carryWeight;
		}

		public void AddCarryCapacityToCharacter(int characterIndex, int amount)
		{
			if (characterIndex >= 0 && characterIndex < ActiveCharacters.Count && ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].AddCarryCapacity(amount);
			}
		}

		public void SubtractCarryCapacityFromCharacter(int characterIndex, int amount)
		{
			if (characterIndex >= 0 && characterIndex < ActiveCharacters.Count && ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].SubtractCarryCapacity(amount);
			}
		}

		public int GetActiveCharacterRemainingPsych(int characterIndex)
		{
			int remainingPsych = 0;
			if (characterIndex >= 0 && characterIndex < ActiveCharacters.Count && ActiveCharacters[characterIndex] != null)
			{
				remainingPsych = ActiveCharacters[characterIndex].GetPsychRemaning();
			}
			return remainingPsych;
		}

		public void SetActiveCharacterRemainingPsych(int characterIndex, int remaining)
		{
			if (characterIndex >= 0 && characterIndex < ActiveCharacters.Count && ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].SetPsychRemaining(remaining);
			}
		}

        public int GetActiveCharacterRemainingHealth(int characterIndex)
        {
			int remainingHealth = 0;
			if (characterIndex >= 0 && characterIndex < ActiveCharacters.Count && ActiveCharacters[characterIndex] != null)
			{
				remainingHealth = ActiveCharacters[characterIndex].GetHpRemaining();
			}
			return remainingHealth;
		}

		public int GetActiveCharacterMaxHealth(int characterIndex)
		{
			int maxHealth = 0;
			if (characterIndex >= 0 && characterIndex < ActiveCharacters.Count && ActiveCharacters[characterIndex] != null)
			{
				maxHealth = ActiveCharacters[characterIndex].GetMaxHp();
			}
			return maxHealth;
		}

		public int GetActiveCharacterPsychResistance(int characterIndex)
		{
			int psychRes = 0;
			if (characterIndex >= 0 && characterIndex < ActiveCharacters.Count && ActiveCharacters[characterIndex] != null)
			{
				psychRes = ActiveCharacters[characterIndex].GetPsychResistance();
			}
			return psychRes;
		}

		public bool GetActiveCharacterLinkActive(int characterIndex)
		{
			bool isActive = false;

			if (characterIndex >= 0 && characterIndex < ActiveCharacters.Count && ActiveCharacters[characterIndex] != null)
			{
				LinkCommon link = ActiveCharacters[characterIndex].GetCharacterLink();
				if (link != null)
				{
					isActive = link.GetLinkIsActive();
				}
			}

			return isActive;
		}

		public Dictionary<Skills, int> GetActiveVehicleStats()
		{
			return ActiveVehicleTotalStats;
		}

		public int GetActiveVehicleRemainingCarryWeight()
		{
			return ActiveVehicleRemainingCarryWeight;
		}

		public int GetActiveVehicleUsedCarryWeight()
		{
			return ActiveVehicleUsedCarryWeight;
		}

        public int GetActiveVehicleTotalCarryWeight()
        {
            int carryWeight = 0;
            if (Vehicle != null)
            {
                carryWeight = Vehicle.GetCarryWeight();
            }
            return carryWeight;
        }

		public Coordinates GetPartyLocation()
		{
			return PartyLocation;
		}

		public void SetPartyLocation(Coordinates coords)
		{
			PartyLocation = coords;
		}

		public void SetPlayerIsDoingAnEncounter(bool isDoing)
		{
			PlayerIsDoingAnEncounter = isDoing;
		}

		public bool GetPlayerIsDoingAnEncounter()
		{
			return PlayerIsDoingAnEncounter;
		}

		public void SetPlayerIsHealing(bool isHealing)
		{
			PlayerIsHealing = isHealing;
		}

		public bool GetPlayerIsHealing()
		{
			return PlayerIsHealing;
		}

		public void SetEncounterType(int encounterType)
		{
			if (encounterType >= Constants.ENCOUNTER_NONE && encounterType <= Constants.ENCOUNTER_CITY_RAD)
			{
				EncounterType = encounterType;
			}
		}

		public int GetEncounterType()
		{
			return EncounterType;
		}

		public int GetTownHealth()
        {
			return TownHealth;
        }

        public void SetTownHealth(int townHealth)
        {
			if (townHealth > 0)
			{
				TownHealth = townHealth;
			}
			else
			{
				TownHealth = 1;
			}
        }

		public void AddTownHealth(int amountToAdd)
		{
			if (amountToAdd >= 0)
			{
				TownHealth += amountToAdd;
			}
		}

		public void SubtractTownHealth(int amountToSubtract)
		{
			if (amountToSubtract >= 0)
			{
				if (TownHealth - amountToSubtract > 0)
				{
					TownHealth -= amountToSubtract;
				}
				else
				{
					TownHealth = 1;
				}
			}
		}

		public int GetPrestige()
		{
			return Prestige;
		}

		public void SetPrestige(int prestige)
		{
			if (prestige > 0)
			{
				Prestige = prestige;
			}
			else
            {
				Prestige = 1;
			}
		}

		public void AddPrestige(int amountToAdd)
		{
			if (amountToAdd >= 0)
			{
				Prestige += amountToAdd;
			}
		}

		public void SubtractPrestige(int amountToSubtract)
		{
			if (amountToSubtract >= 0)
			{
				if (Prestige - amountToSubtract > 0)
				{
					Prestige -= amountToSubtract;
				}
				else
				{
					Prestige = 1;
				}
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
				if (card.GetSpoilsTypes().Contains(SpoilsTypes.Party_Equipment))
				{
					removeGroupEquipment(card);
					updateAllCharacterSlotTotals();
				}
				else
				{
					UpdateCharacterSlotTotals(characterIndex);
				}
			}
		}

		public void RemoveAllSpoilsFromActiveCharacter(int characterIndexToRemove)
		{
			List<SpoilsCard> equippedSpoils = ActiveCharacters[characterIndexToRemove].GetEquippedSpoils();
			for (int i = equippedSpoils.Count - 1; i >= 0; i--)
			{
				SpoilsCard card = equippedSpoils[i];
				if (!equippedSpoils[i].GetSpoilsTypes().Contains(SpoilsTypes.Party_Equipment))
				{
					ActiveCharacters[characterIndexToRemove].RemoveSpoilsCard(card);
					AddSpoilsCardToAuctionHouse(card);
				}
				else
				{
					ActiveCharacters[characterIndexToRemove].RemoveSpoilsCard(card);
					bool isOtherCharacterInParty = false;
					for (int x = 0; x < Constants.NUM_PARTY_MEMBERS; x++)
					{
						if (ActiveCharacters[x] != null && x != characterIndexToRemove)
						{
							isOtherCharacterInParty = true;
							break;
						}
					}
					if (!isOtherCharacterInParty)
					{
						AddSpoilsCardToAuctionHouse(card);
						PartyEquipment.Remove(card);
					}
				}
			}
		}

		public void RemoveCharacterFromParty(int characterIndexToRemove)
		{
			if (ActiveCharacters[characterIndexToRemove] != null)
			{
				ActiveCharacters[characterIndexToRemove] = null;
				UpdateCharacterSlotTotals(characterIndexToRemove);
			}
		}

		public void RemoveStowableFromActiveVehicle(SpoilsCard card)
		{
			if (Vehicle != null && Vehicle.GetEquippedSpoils().Contains(card))
			{
				Vehicle.RemoveSpoilsCard(card);
				updateVehicleSlotTotals();
			}
		}

		public void RemoveVehicleFromParty()
		{
			Vehicle = null;
			updateVehicleSlotTotals();
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

		public void AddSpoilsToActiveVehicle(SpoilsCard spoilsCard)
		{
			if (IsAllowedToEquipSpoilsToVehicle(spoilsCard))
			{
				Vehicle.AttachSpoilsCard(spoilsCard);
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

		public void SellTownTech(int techIndexToSell)
		{
			if (techIndexToSell >= 0 && techIndexToSell < TownTechs.Count)
			{
				TownTechs.RemoveAt(techIndexToSell);
			}
		}

		public void UpgradeTownTech(int techIndexToUpgrade)
		{
			if(techIndexToUpgrade >= 0 && techIndexToUpgrade < TownTechs.Count)
            {
				TownTechs[techIndexToUpgrade].SetTier(Constants.TIER_2);
			}
		}

		public void DowngradeTownTech(int techIndexToDowngrade)
		{
			if (techIndexToDowngrade >= 0 && techIndexToDowngrade < TownTechs.Count)
			{
				TownTechs[techIndexToDowngrade].SetTier(Constants.TIER_1);
			}
		}

		public void AddCharacterToParty(int characterIndex, CharacterCard character)
		{
			if (character != null && ActiveCharacters[characterIndex] == null)
			{
				ActiveCharacters[characterIndex] = character;
				for (int partyEquipmentIndex = 0; partyEquipmentIndex < PartyEquipment.Count; partyEquipmentIndex++)
				{
					ActiveCharacters[characterIndex].AttachSpoilsCard(PartyEquipment[partyEquipmentIndex]);
				}
				UpdateCharacterSlotTotals(characterIndex);
			}
		}

		public void MoveCharacterBetweenSlots(int characterIndexFrom, int characterIndexTo)
		{
			ActiveCharacters[characterIndexTo] = ActiveCharacters[characterIndexFrom];
			ActiveCharacters[characterIndexFrom] = null;
			UpdateCharacterSlotTotals(characterIndexFrom);
			UpdateCharacterSlotTotals(characterIndexTo);
		}

		public void AddSpoilsToCharacter(int characterIndex, SpoilsCard card)
		{
			if (ActiveCharacters[characterIndex] != null)
			{
				if (card.GetSpoilsTypes().Contains(SpoilsTypes.Party_Equipment))
				{
					addGroupEquipment(card);
					updateAllCharacterSlotTotals();
				}
				else
				{
					ActiveCharacters[characterIndex].AttachSpoilsCard(card);
					UpdateCharacterSlotTotals(characterIndex);
				}
			}
		}

		public bool IsAllowedToAddSpoilsCardToCharacter(int characterIndex, SpoilsCard card)
		{
			bool isAllowed = false;
			if (characterIndex < ActiveCharacters.Count && ActiveCharacters[characterIndex] != null && 
				!card.GetSpoilsTypes().Contains(SpoilsTypes.Vehicle) && !card.GetSpoilsTypes().Contains(SpoilsTypes.Vehicle_Equipment) &&
				ActiveCharacterRemainingCarryWeights[characterIndex] - card.GetCarryWeight() >= 0)
			{
				isAllowed = true;
				if (card.GetSpoilsTypes().Contains(SpoilsTypes.Party_Equipment))
				{
					//Check if all other characters have capacity
					for (int charIndex = 0; charIndex < Constants.NUM_PARTY_MEMBERS; charIndex++)
					{
						if (ActiveCharacters[charIndex] != null && ActiveCharacterRemainingCarryWeights[charIndex] - card.GetCarryWeight() < 0)
						{
							isAllowed = false;
							break;
						}
					}
				}
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
			if (Vehicle != null && card != null && ActiveVehicleRemainingCarryWeight - card.GetCarryWeight() >= 0 &&
				(card.GetSpoilsTypes().Contains(SpoilsTypes.Stowable) || card.GetSpoilsTypes().Contains(SpoilsTypes.Vehicle_Equipment)))
			{
				isAllowed = true;
			}
			return isAllowed;
		}

		public bool IsAllowedToAddCharacterToParty(int characterIndex, int carryCapacity)
		{
			bool isAllowed = false;
			if (ActiveCharacters[characterIndex] == null)
			{
				for (int partyEquipmentIndex = 0; partyEquipmentIndex < PartyEquipment.Count; partyEquipmentIndex++)
				{
					carryCapacity -= PartyEquipment[partyEquipmentIndex].GetCarryWeight();
				}

				if (carryCapacity >= 0)
				{
					isAllowed = true;
				}
			}
			return isAllowed;
		}

		public int GetRemainingPartyExploitWeeks()
		{
			return RemainingPartyExploitWeeks;
		}

		public void SetRemainingPartyExploitWeeks(int remainingWeeks)
		{
			if (remainingWeeks >= 0)
			{
				RemainingPartyExploitWeeks = remainingWeeks;
			}
			else
			{
				WeekPenalty = System.Math.Abs(remainingWeeks);
				RemainingPartyExploitWeeks = 0;
				EventManager.ShowGenericPopup("You've overspent " + WeekPenalty.ToString() + " weeks! Delay added.");
			}
		}

		public void SetPlayerIsMoving(bool isMoving)
		{
			PlayerIsMoving = isMoving;
		}

		public bool GetPlayerIsMoving()
		{
			return PlayerIsMoving;
		}

		public int GetTotalForCharacterSkill(int characterIndex, Skills skill)
		{
			return ActiveCharacterTotalStats[characterIndex][skill];
		}

		public int GetTotalForVehicleSkill(Skills skill)
		{
			return ActiveVehicleTotalStats[skill];
		}

		public int GetCombatSkillMeleeOnly(int characterIndex)
		{
			int combatSkillAmountMeleeOnly = 0;
			CharacterCard character = ActiveCharacters[characterIndex];
			if (character != null)
			{
				combatSkillAmountMeleeOnly += character.GetBaseSkills()[Skills.Combat];
				List<SpoilsCard> attachedSpoils = character.GetEquippedSpoils();
				for (int i = 0; i < attachedSpoils.Count; i++)
				{
					if (!attachedSpoils[i].GetSpoilsTypes().Contains(SpoilsTypes.Ranged_Weapon))
					{
						combatSkillAmountMeleeOnly += attachedSpoils[i].GetBaseSkills()[Skills.Combat];
					}
				}
			}

			return combatSkillAmountMeleeOnly;
		}

		public int GetCharacterAutoSuccesses(int characterIndex, int skillIndex, Skills skill)
		{
			int autoSuccesses = 0;
            if (!CharacterDiceRolls[characterIndex][skillIndex].Contains(Constants.CRIT_FAIL) && ActiveCharacters[characterIndex] != null)
            {
                autoSuccesses = (ActiveCharacterTotalStats[characterIndex][skill] / 10);
            }
            return autoSuccesses;
		}

		public int GetCharacterCombatAutoSuccessesMeleeOnly(int characterIndex, int skillIndex)
		{
			int autoSuccesses = 0;
			if (!CharacterDiceRolls[characterIndex][skillIndex].Contains(Constants.CRIT_FAIL) && ActiveCharacters[characterIndex] != null)
			{
				autoSuccesses = GetCombatSkillMeleeOnly(characterIndex) / 10;
			}
			return autoSuccesses;
		}

		public int GetCharacterRolledSuccesses(int characterIndex, int skillIndex, Skills skill)
		{
			int rolledSuccesses = 0;
            if (!CharacterDiceRolls[characterIndex][skillIndex].Contains(Constants.CRIT_FAIL) && ActiveCharacters[characterIndex] != null)
            {
                int numberToRollBelow = ActiveCharacterTotalStats[characterIndex][skill] % 10;
                for (int rolledIndex = 0; rolledIndex < CharacterDiceRolls[characterIndex][skillIndex].Count; rolledIndex++)
                {
                    if (CharacterDiceRolls[characterIndex][skillIndex][rolledIndex] == Constants.CRIT_SUCCESS || CharacterDiceRolls[characterIndex][skillIndex][rolledIndex] <= numberToRollBelow)
                    {
                        rolledSuccesses += 1;
                    }
                }
            }
            return rolledSuccesses;
		}

		public int GetCharacterCombatRolledSuccessesMeleeOnly(int characterIndex, int skillIndex)
		{
			int rolledSuccesses = 0;
			if (!CharacterDiceRolls[characterIndex][skillIndex].Contains(Constants.CRIT_FAIL) && ActiveCharacters[characterIndex] != null)
			{
				int numberToRollBelow = GetCombatSkillMeleeOnly(characterIndex) % 10;
				for (int rolledIndex = 0; rolledIndex < CharacterDiceRolls[characterIndex][skillIndex].Count; rolledIndex++)
				{
					if (CharacterDiceRolls[characterIndex][skillIndex][rolledIndex] == Constants.CRIT_SUCCESS || CharacterDiceRolls[characterIndex][skillIndex][rolledIndex] <= numberToRollBelow)
					{
						rolledSuccesses += 1;
					}
				}
			}
			return rolledSuccesses;
		}

		public int GetVehicleAutoSuccesses(int skillIndex, Skills skill)
		{
			int autoSuccesses = 0;
            if (!VehicleDiceRolls[skillIndex].Contains(Constants.CRIT_FAIL) && Vehicle != null)
            {
                autoSuccesses = (int)(ActiveVehicleTotalStats[skill] / 10);
            }
            return autoSuccesses;
		}

		public int GetVehicleRolledSuccesses(int skillIndex, Skills skill)
		{
			int rolledSuccesses = 0;
            if (!VehicleDiceRolls[skillIndex].Contains(Constants.CRIT_FAIL) && Vehicle != null)
            {
                int numberToRollBelow = ActiveVehicleTotalStats[skill] % 10;
                for (int rolledIndex = 0; rolledIndex < VehicleDiceRolls[skillIndex].Count; rolledIndex++)
                {
                    if (VehicleDiceRolls[skillIndex][rolledIndex] == Constants.CRIT_SUCCESS || VehicleDiceRolls[skillIndex][rolledIndex] <= numberToRollBelow)
                    {
                        rolledSuccesses += 1;
                    }
                }
            }
            return rolledSuccesses;
		}

		public int GetTownTechSuccesses(Skills skill)
		{
			 return TownTechSuccesses[skill];
		}

		public int GetTotalPartySuccesses(int skillIndex, Skills skill)
		{
			int totalSuccesses = 0;
            for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
            {
                totalSuccesses += GetCharacterAutoSuccesses(characterIndex, skillIndex, skill);
                totalSuccesses += GetCharacterRolledSuccesses(characterIndex, skillIndex, skill);
            }
            totalSuccesses += GetVehicleAutoSuccesses(skillIndex, skill);
            totalSuccesses += GetVehicleRolledSuccesses(skillIndex, skill);

			totalSuccesses += GetTownTechSuccesses(skill);

            return totalSuccesses;
		}

		public int GetTotalIndividualSuccesses(int characterIndex, int skillIndex, Skills skill)
		{
			return GetCharacterAutoSuccesses(characterIndex, skillIndex, skill) + GetCharacterRolledSuccesses(characterIndex, skillIndex, skill);
		}

		public void AddCharacterDiceRoll(int characterIndex, int skillCheckIndex, int diceRoll)
		{
			CharacterDiceRolls[characterIndex][skillCheckIndex].Add(diceRoll);
		}

		public void AddVehicleDiceRoll(int skillIndex, int diceRoll)
		{
			VehicleDiceRolls[skillIndex].Add(diceRoll);
		}

		public int GetLastCharacterDiceRoll(int characterIndex, int skillIndex)
		{
			int lastRoll = Constants.HAS_NOT_ROLLED;
            int numRollsInList = CharacterDiceRolls[characterIndex][skillIndex].Count;

            if (numRollsInList > 0)
            {
                lastRoll = CharacterDiceRolls[characterIndex][skillIndex][numRollsInList - 1];
            }
            else if (ActiveCharacters[characterIndex] == null)
            {
                lastRoll = Constants.CRIT_FAIL;
            }

            return lastRoll;
		}

		public int GetLastVehicleDiceRoll(int skillIndex)
		{
			int lastRoll = Constants.HAS_NOT_ROLLED;
            int numRollsInList = VehicleDiceRolls[skillIndex].Count;

            if (numRollsInList > 0)
            {
                lastRoll = VehicleDiceRolls[skillIndex][numRollsInList - 1];
            }
            else if (Vehicle == null)
            {
                lastRoll = Constants.CRIT_FAIL;
            }

            return lastRoll;
		}

		public void ResetAllCharacterDiceRolls()
		{
			for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
			{
				CharacterDiceRolls[characterIndex] = new List<List<int>>();
			}
		}

		public void ResetAllVehicleDiceRolls()
		{
			VehicleDiceRolls = new List<List<int>>();
		}

		public void SetNumberOfSkillChecks(int numChecks)
		{
			//Set for characters
			for (int characterIndex = 0; characterIndex < Constants.MAX_NUM_PLAYERS; characterIndex++)
			{
				for (int checkIndex = 0; checkIndex < numChecks; checkIndex++)
				{
					CharacterDiceRolls[characterIndex].Add(new List<int>());
				}
			}

			//Set for vehicles
			for (int checkIndex = 0; checkIndex < numChecks; checkIndex++)
			{
				VehicleDiceRolls.Add(new List<int>());
			}
		}

		public void AddInfectedDamageToCharacter(int characterIndex, int amountOfInfectedDamage)
		{
			if (characterIndex >= 0 && characterIndex < Constants.MAX_NUM_PLAYERS && ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].AddInfectedDamage(amountOfInfectedDamage);
			}
		}

		public void RemoveInfectedDamageFromCharacter(int characterIndex, int amountOfInfectedHeal)
		{
			if (characterIndex >= 0 && characterIndex < Constants.MAX_NUM_PLAYERS && ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].RemoveInfectedDamage(amountOfInfectedHeal);
			}
		}

		public int GetAmountOfInfectedDamageForCharacter(int characterIndex)
		{
			int amountOfInfectedDamage = 0;
			if (characterIndex >= 0 && characterIndex < Constants.MAX_NUM_PLAYERS && ActiveCharacters[characterIndex] != null)
			{
				amountOfInfectedDamage = ActiveCharacters[characterIndex].GetAmountOfInfectedDamage();
			}
			return amountOfInfectedDamage;
		}

		public int GetAmountOfRadiationDamageForCharacter(int characterIndex)
		{
			int amountOfRadiationDamage = 0;
			if (characterIndex >= 0 && characterIndex < Constants.MAX_NUM_PLAYERS && ActiveCharacters[characterIndex] != null)
			{
				amountOfRadiationDamage = ActiveCharacters[characterIndex].GetAmountOfRadiationDamage();
			}
			return amountOfRadiationDamage;
		}

		public void AddPhysicalDamageToCharacter(int characterIndex, int amountOfPhysicalDamage)
		{
			if (characterIndex >= 0 && characterIndex < Constants.MAX_NUM_PLAYERS && ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].AddPhysicalDamage(amountOfPhysicalDamage);
			}
		}

		public void RemovePhysicalDamageFromCharacter(int characterIndex, int amountOfPhysicalHeal)
		{
			if (characterIndex >= 0 && characterIndex < Constants.MAX_NUM_PLAYERS && ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].RemovePhysicalDamage(amountOfPhysicalHeal);
			}
		}

		public void AddRadiationDamageToCharacter(int characterIndex, int amountOfRadiationDamage)
		{
			if (characterIndex >= 0 && characterIndex < Constants.MAX_NUM_PLAYERS && ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].AddRadiationDamage(amountOfRadiationDamage);
			}
		}

		public void RemoveRadiationDamageFromCharacter(int characterIndex, int amountOfRadiationHeal)
		{
			if (characterIndex >= 0 && characterIndex < Constants.MAX_NUM_PLAYERS && ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].RemoveRadiationDamage(amountOfRadiationHeal);
			}
		}

		public void AddResourceOwned(Resource resource)
		{
			ResourcesOwned.Add(resource);
			Prestige += Constants.PRESTIGE_GAINED_FOR_RESOURCE;
		}

		public void RemoveResourceOwned(Resource resource)
        {
			ResourcesOwned.Remove(resource);
			Prestige -= Constants.PRESTIGE_GAINED_FOR_RESOURCE;
		}

		public List<Resource> GetAllResourcesOwned()
		{
			return ResourcesOwned;
		}

		public void AddBonusMovement(int amountToAdd)
		{
			BonusMovementGained += amountToAdd;
		}

		public void SubtractBonusMovement(int amountToSubtract)
		{
			BonusMovementGained -= amountToSubtract;
		}

		public int GetBonusMovement()
		{
			return BonusMovementGained;
		}

		public void AddPsychResistance(int characterIndex, int amount)
		{
			if (characterIndex >= 0 && characterIndex < Constants.MAX_NUM_PLAYERS && ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].AddPsychResistance(amount);
			}
		}

		public void SubtractPsychResistance(int characterIndex, int amount)
		{
			if (characterIndex >= 0 && characterIndex < Constants.MAX_NUM_PLAYERS && ActiveCharacters[characterIndex] != null)
			{
				ActiveCharacters[characterIndex].SubtractPsychResistance(amount);
			}
		}

		public void AddActiveEffect(Effect effectToAdd)
        {
			ActiveEffects.Add(effectToAdd);
		}
		
		public void RemoveActiveEffect(Effect effectToRemove)
        {
			ActiveEffects.Remove(effectToRemove);
		}

		public List<Effect> GetActiveEffects()
        {
			return ActiveEffects;
		}

		public void UpdateCharacterSlotTotals(int indexToUpdate)
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
				int remainingCarryWeightTemp = ActiveCharacters[indexToUpdate].GetCarryCapacity();
				int usedCarryWeightTemp = 0;
				for (int i = 0; i < equippedSpoils.Count; i++)
				{
					remainingCarryWeightTemp -= equippedSpoils[i].GetCarryWeight();
					usedCarryWeightTemp += equippedSpoils[i].GetCarryWeight();
				}
				ActiveCharacterRemainingCarryWeights[indexToUpdate] = remainingCarryWeightTemp;
				ActiveCharacterUsedCarryWeights[indexToUpdate] = usedCarryWeightTemp;
			}
			else
			{
				foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
				{
					ActiveCharacterTotalStats[indexToUpdate][skill] = 0;
					ActiveCharacterRemainingCarryWeights[indexToUpdate] = 0;
					ActiveCharacterUsedCarryWeights[indexToUpdate] = 0;
				}
			}
		}

		public int GetNumberOfTownDefenseChips()
		{
			return NumberOfTownDefenseChips;
		}

		public void SetNumberOfTownDefenseChips(int numChips)
		{
			if(numChips >= 0 && numChips <= 5)
            {
				NumberOfTownDefenseChips = numChips;
			}
		}

		public void AddTownTechSuccesses(Skills skill, int amount)
		{
			TownTechSuccesses[skill] += amount;
		}

		public void RemoveTownTechSuccesses(Skills skill, int amount)
		{
			int oldAmount = TownTechSuccesses[skill];
			TownTechSuccesses[skill] -= amount;

			if (TownTechSuccesses[skill] < 0)
			{
				TownTechSuccesses[skill] = 0;
				UnityEngine.Debug.LogWarning("Town tech successes were tried to be removed, but that put it below 0. Skill was " + skill.ToString() 
					+ ", value before was " + oldAmount.ToString()
					+ ", and amount to be removed was " + amount.ToString());
			}
		}

		public int GetWeekPenaltyAmount()
        {
			return WeekPenalty;
		}

		public void AddWeekPenalty(int amountToAdd)
        {
			if (amountToAdd > 0)
			{
				WeekPenalty += amountToAdd;
			}
		}

		public void ResetWeekPenalty()
        {
			WeekPenalty = 0;
		}






		private void initDataStructures()
		{
			AuctionHouse = new List<SpoilsCard>();
			ActionCardsInHand = new List<ActionCard>();
			TownRoster = new List<CharacterCard>();
			ActiveCharacters = new List<CharacterCard>();
			TownTechs = new List<TownTech>();
			ActiveCharacterRemainingCarryWeights = new List<int>();
			ActiveCharacterUsedCarryWeights = new List<int>();
			ActiveVehicleTotalStats = new Dictionary<Skills, int>();
			ActiveCharacterTotalStats = new List<Dictionary<Skills, int>>();
			CharacterDiceRolls = new List<List<List<int>>>();
			VehicleDiceRolls = new List<List<int>>();

			for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
			{
				ActiveCharacters.Add(null);
				ActiveCharacterTotalStats.Add(new Dictionary<Skills, int>());
				CharacterDiceRolls.Add(new List<List<int>>());
				foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
				{
					ActiveCharacterTotalStats[i].Add(skill, 0);
				}
				ActiveCharacterRemainingCarryWeights.Add(0);
				ActiveCharacterUsedCarryWeights.Add(0);
			}

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

		private void updateAllCharacterSlotTotals()
        {
			for (int characterIndex = 0; characterIndex < Constants.NUM_PARTY_MEMBERS; characterIndex++)
			{
				UpdateCharacterSlotTotals(characterIndex);
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
				int tempCarryWeight = Vehicle.GetCarryWeight();
				for (int i = 0; i < equippedSpoils.Count; i++)
				{
					tempCarryWeight -= equippedSpoils[i].GetCarryWeight();
				}
				ActiveVehicleRemainingCarryWeight = tempCarryWeight;
				ActiveVehicleUsedCarryWeight = Vehicle.GetCarryWeight() - ActiveVehicleRemainingCarryWeight;
			}
			else
			{
				foreach (Skills skill in System.Enum.GetValues(typeof(Skills)))
				{
					ActiveVehicleTotalStats[skill] = 0;
					ActiveVehicleRemainingCarryWeight = 0;
					ActiveVehicleUsedCarryWeight = 0;
				}
			}
		}

		private void addGroupEquipment(SpoilsCard card)
		{
			PartyEquipment.Add(card);
			for(int characterIndex = 0; characterIndex < Constants.NUM_PARTY_MEMBERS; characterIndex++)
            {
				if (ActiveCharacters[characterIndex] != null)
				{
					ActiveCharacters[characterIndex].AttachSpoilsCard(card);
				}
			}
		}

		private void removeGroupEquipment(SpoilsCard card)
		{
			PartyEquipment.Remove(card);
			for (int characterIndex = 0; characterIndex < Constants.NUM_PARTY_MEMBERS; characterIndex++)
			{
				if (ActiveCharacters[characterIndex] != null)
				{
					ActiveCharacters[characterIndex].RemoveSpoilsCard(card);
				}
			}
		}
	}
}
