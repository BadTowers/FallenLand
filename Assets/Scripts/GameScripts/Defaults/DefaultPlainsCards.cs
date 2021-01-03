using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class DefaultPlainsCards
	{
		private List<PlainsCard> PlainsCards;

		public DefaultPlainsCards()
		{
			PlainsCards = new List<PlainsCard>();

			PlainsCard curCard;
			int curID = 0;

			Debug.Log("Instantiating plains cards...");

			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("A Helping Hand");
			curCard.SetSalvageReward(2);
			curCard.SetDescriptionText("Ahead, the picturesque farm house is indeed in poor condition, yet may provide ample shelter against the insurgent rainstorm. " +
				"A grizzled old farmer steps out of the shadows of the porch and confronts you with an antique shotgun. After a barrage of questions and seemingly correct answers, Mac warms " +
				"up to you and invites you to sample his stash of the very finest pre-war whiskies. After a few drinks to warm you pu, Mac offers you a deal. \"I'll let you folks weather out " +
				"the storm here, if y'all help me fix my tractor. With Ol' Betsy, life's still worth living'.\" He prattles on about his tractor for what seems an eternity, mentioning a more " +
				"substantial reward if you are successful.");
            curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Mechanical, 4),
				(Skills.Technical, 3)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("Draw the next Relic Spoils card, discarding all others. You may place your party on the nearest Mission chip and attempt it at no cost in weeks.");
			curCard.SetSuccessDescriptionText("Mac is filled with joy and smiling as he gives you the reward.");
			curCard.AddReward(new GainNextRelicSpoilsCard());
			//TODO add success gain is that you have the ability to move to the nearest mission and do it at no weeks cost
			curCard.SetFailureHeaderText("All Party members automatically suffer 1 point of Psychological Damage.");
			curCard.SetFailureDescriptionText("Inconsolable at the loss of Ol' Betsy, a heartbroken Mac ushers you out. As you pass the rusted mailbox at the end of the drive, a lone gunshot " +
				"echoes from within the house.");
			curCard.AddPunishment(new ApplyPsychDamageToWholeParty(1));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Fix It Already");
			curCard.SetSalvageReward(3);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Mechanical, 3),
				(Skills.Technical, 3)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new LoseMostValuableSpoilsThatAreNotVehicle(1));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Signs of the False Prophet");
			curCard.SetSalvageReward(4);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Survival, 4),
				(Skills.Technical, 4),
				(Skills.Combat, 5)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetFlightAllowed(true);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(3));
			curCard.AddReward(new GainActionCards(1));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6PhysicalDamage(5));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Mass Exodus");
			curCard.SetSalvageReward(4);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Survival, 5),
				(Skills.Diplomacy, 4)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(1));
			curCard.AddReward(new GainPrestige(2));
			curCard.AddReward(new GainTownHealth(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new LosePrestige(1));
			//TODO add punishment for 2 week penalty chip when that is implemented
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Gruesome Cannibal Carnival");
			curCard.SetSalvageReward(5);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Combat, 7)
			});
			curCard.SetMakePsychCheckAfterEncounter(true);
			curCard.SetFlightAllowed(true);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(3));
			curCard.AddReward(new GainActionCards(3));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6InfectedDamage(6));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Bamboozeled");
			curCard.SetSalvageReward(3);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Combat, 4)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetFlightAllowed(true);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(1));
			//TODO add reward as gain the next alcohol spoils. If none are in the deck, gain 5 salvage
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			//TODO add punishment. roll 1d6 to determine character. If 6 or crown empty, ignore, else that crown sustains 2d6 physical damage
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Eaters Hunting Party");
			curCard.SetSalvageReward(3);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Combat, 6)
			});
			curCard.SetMakePsychCheckAfterEncounter(true);
			curCard.SetFlightAllowed(true);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6InfectedDamage(4));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Raging Forest Fire");
			curCard.SetSalvageReward(4);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Survival, 4)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.AddClassification(EncounterTypes.EnvironmentalHazard);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainActionCards(1));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6InfectedDamage(5));
			//TODO add punishment of 2 week penalty chip
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Colossal Carnage");
			curCard.SetSalvageReward(2);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Diplomacy, 4),
				(Skills.Medical, 3)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainTownHealth(2));
			//TODO gain 2 town defense chips as a reward
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			//TODO punishment--roll 1d6. ignore on 6 or empty, else lose a weapon on that character. if they don't have a weapon, discard most valueable spoils card
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Children of the Maize");
			curCard.SetSalvageReward(2);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Diplomacy, 3)
			});
			curCard.SetMakePsychCheckAfterEncounter(true);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainActionCards(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6PhysicalDamage(5));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Fortified Small Town");
			curCard.SetSalvageReward(5);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Diplomacy, 3)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			//TODO punishment--CHOICE: pay 10 salvage or be delayed 2 weeks
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Bio Diesel Plant");
			curCard.SetSalvageReward(8);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Mechanical, 3),
				(Skills.Technical, 3)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainTownHealth(3));
			curCard.AddReward(new GainPartyExploitsWeeks(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6InfectedDamage(4));
			curCard.AddPunishment(new LoseTownHealth(2));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Recruitment");
			curCard.SetSalvageReward(2);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Diplomacy, 3)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(1));
			curCard.AddReward(new GainActionCards(1));
			curCard.AddReward(new GainCharacterCards(1));
			curCard.AddReward(new GainPartyExploitsWeeks(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			//No punishments for this card
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Caravan Escort");
			curCard.SetSalvageReward(4);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Technical, 4)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(2));
			curCard.AddReward(new GainTownHealth(3));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new LoseTownHealth(3));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Shoot Out at the Okey Dokey");
			curCard.SetSalvageReward(3);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Survival, 3),
				(Skills.Combat, 6)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetFlightAllowed(true);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new LosePrestige(1));
			curCard.AddPunishment(new TakeD6PhysicalDamage(6));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Showdown at High Noon");
			curCard.SetSalvageReward(5);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Combat, 6)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetFlightAllowed(false);
			curCard.AddActionOnBegin(new MovePartyToStartingTownLocation());
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(2));
			curCard.AddReward(new GainSalvageCoins(5));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6PhysicalDamage(6));
			curCard.AddPunishment(new LoseTownHealth(3));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Smooth Sailing");
			curCard.SetSalvageReward(0);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Diplomacy, 0)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.AddClassification(EncounterTypes.Special);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainPartyExploitsWeeks(1));
			curCard.AddReward(new GainHealD6PhysicalDamage(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			//No punishments for this card
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Sole Survivor");
			curCard.SetSalvageReward(2);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Medical, 3)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(1));
			curCard.AddReward(new GainCharacterCards(1));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeInfectedDamage(1));
			curCard.AddPunishment(new EveryoneLoseTownHealth(3));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Hungry Locals");
			curCard.SetSalvageReward(3);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Medical, 4)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainActionCards(2));
			//TODO reward -- draw the next 4 encounter cards for one deck and order them however you'd like
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new LoseTownHealth(1));
			//TODO punishment -- discard all "ally" spoils cards
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Brotherhood of the Apocalypse");
			curCard.SetSalvageReward(5);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Combat, 7)
			});
			curCard.SetFlightAllowed(true);
			curCard.AddClassification(EncounterTypes.TheBrotherhood);
			curCard.AddPrecheck(new NotPlayingBrotherhood());
			curCard.SetMakePsychCheckAfterEncounter(true);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(3));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6PhysicalDamage(6));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Don't Drink the Punch");
			curCard.SetSalvageReward(2);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Technical, 3),
				(Skills.Combat, 5)
			});
			curCard.SetFlightAllowed(true);
			curCard.AddClassification(EncounterTypes.TheBrotherhood);
			curCard.AddClassification(EncounterTypes.Mystery);
			curCard.AddPrecheck(new NotPlayingBrotherhood());
			curCard.SetMakePsychCheckAfterEncounter(true);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainPrestige(1));
			curCard.AddReward(new GainSpoilsCards(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6PhysicalDamage(5));
			curCard.AddPunishment(new LosePrestige(1));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("A Shining Example");
			curCard.SetSalvageReward(5);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Survival, 3)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(1));
			//TODO reward -- may place party on nearest mission chip and attempt it at no week cost
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new CharacterCrownTakesD6PhysicalDamage(1));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Ronin");
			curCard.SetSalvageReward(3);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Diplomacy, 5)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainNextMasterCharacterElseChoose());
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			//This card has no punishments
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Blood on the Highway");
			curCard.SetSalvageReward(4);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Combat, 7)
			});
			curCard.SetFlightAllowed(true);
			curCard.AddClassification(EncounterTypes.VehicleCombat);
			curCard.AddClassification(EncounterTypes.BikerGang);
			curCard.AddPrecheck(new HasMotorizedVehicle());
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(3));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6PhysicalDamage(7));
			curCard.AddPunishment(new VehicleDestroyed());
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Tainted Supplies");
			curCard.SetSalvageReward(1);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Medical, 3),
				(Skills.Survival, 4)
			});
			curCard.AddClassification(EncounterTypes.Perishables);
			curCard.SetMakePsychCheckAfterEncounter(true);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(1));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new LoseMostValuableSpoilsThatAreNotVehicle(1));
			//TODO punishment -- 2 week delay chip
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Orphans, How Cute!");
			curCard.SetSalvageReward(3);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Combat, 6)
			});
			int characterCrownIndex = 0;
			int amountOfDamage = 3;
			curCard.AddActionOnBegin(new DealSetAmountOfPhysicalDamageToCharacterCrown(characterCrownIndex, amountOfDamage));
			curCard.SetMakePsychCheckAfterEncounter(true);
			curCard.SetFlightAllowed(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6PhysicalDamage(6));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Destitute Enclave");
			curCard.SetSalvageReward(3);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Combat, 5)
			});
			characterCrownIndex = 2;
			amountOfDamage = 3;
			curCard.AddActionOnBegin(new DealSetAmountOfPhysicalDamageToCharacterCrown(characterCrownIndex, amountOfDamage));
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetFlightAllowed(true);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6PhysicalDamage(5));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Extra Terrestrial");
			curCard.SetSalvageReward(5);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Diplomacy, 4),
				(Skills.Technical, 4),
				(Skills.Mechanical, 4)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainAlphaCentauriArmorSpoils());
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new LoseRandomCharacterCrownAndTheirEquipment());
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Scare Crow");
			curCard.SetSalvageReward(3);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Combat, 5)
			});
			curCard.SetMakePsychCheckAfterEncounter(true);
			curCard.SetFlightAllowed(true);
			int numD6s = 2;
			characterCrownIndex = 2;
			curCard.AddActionOnBegin(new DealD6PhysicalDamageToCharacterCrown(characterCrownIndex, numD6s));
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6PhysicalDamage(4));
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("Wild Horses");
			curCard.SetSalvageReward(4);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Survival, 3),
				(Skills.Survival, 3)
			});
			curCard.AddClassification(EncounterTypes.WildAnimals);
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainPrestige(1));
			curCard.AddReward(new GainTownHealth(3));
			curCard.AddReward(new GainSpecificSpoilsElseSalvage("6 Fast Horses", 15));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6PhysicalDamage(3));
			//todo punishment -- you are delayed 1 week
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("The Hitchhiker");
			curCard.SetSalvageReward(2);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Diplomacy, 4)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.AddPrecheck(new HasMotorizedVehicle());
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainCharacterCards(1));
			curCard.AddReward(new GainSpoilsCards(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new VehicleDestroyed());
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("A Breath of Fresh Air");
			curCard.SetSalvageReward(0);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Diplomacy, 0)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.AddClassification(EncounterTypes.Special);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			//TODO reward if the party has camping gear, auto heal to full health, else attempt heal with 2 auto successes
			//TODO reward may draw another encounter at no cost in weeks
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			//There are no punishments on this card
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("A Midnight Visitation");
			curCard.SetSalvageReward(3);
			curCard.SetDescriptionText("");
			curCard.SetSkillChecks(new List<(Skills, int)>
			{
				(Skills.Combat, 6)
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetFlightAllowed(true);
			curCard.AddClassification(EncounterTypes.Ambush);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(3));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6PhysicalDamage(6));
			//TODO add punishment -- player to the left chooses 2 equipped spoils to discard
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard);
		}

		public List<PlainsCard> GetPlainsCards()
		{
			return PlainsCards;
		}

		public PlainsCard GetPlainsCardFromName(string name)
		{
			PlainsCard plainsCard = null;
			for (int i = 0; i < PlainsCards.Count; i++)
			{
				if (PlainsCards[i].GetTitle() == name)
				{
					plainsCard = PlainsCards[i];
					break;
				}
			}
			return plainsCard;
		}
	}
}
