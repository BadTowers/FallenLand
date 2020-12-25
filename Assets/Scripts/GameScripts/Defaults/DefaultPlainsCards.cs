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
            curCard.SetSkillChecks(new Dictionary<Skills, int>
			{
				[Skills.Mechanical] = 4,
				[Skills.Technical] = 3
			});
			curCard.SetArePartySkillCheck(new Dictionary<Skills, bool>
			{
				[Skills.Mechanical] = true,
				[Skills.Technical] = true
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
			curCard.SetSkillChecks(new Dictionary<Skills, int>
			{
				[Skills.Mechanical] = 3,
				[Skills.Technical] = 3
			});
			curCard.SetArePartySkillCheck(new Dictionary<Skills, bool>
			{
				[Skills.Mechanical] = true,
				[Skills.Technical] = true
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
			curCard.SetSkillChecks(new Dictionary<Skills, int>
			{
				[Skills.Survival] = 4,
				[Skills.Technical] = 4,
				[Skills.Combat] = 5
			});
			curCard.SetArePartySkillCheck(new Dictionary<Skills, bool>
			{
				[Skills.Survival] = true,
				[Skills.Technical] = true,
				[Skills.Combat] = true
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
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
			curCard.SetSkillChecks(new Dictionary<Skills, int>
			{
				[Skills.Survival] = 5,
				[Skills.Diplomacy] = 4
			});
			curCard.SetArePartySkillCheck(new Dictionary<Skills, bool>
			{
				[Skills.Survival] = true,
				[Skills.Diplomacy] = true
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
			curCard.SetSkillChecks(new Dictionary<Skills, int>
			{
				[Skills.Combat] = 7
			});
			curCard.SetArePartySkillCheck(new Dictionary<Skills, bool>
			{
				[Skills.Combat] = true
			});
			curCard.SetMakePsychCheckAfterEncounter(true);
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
			curCard.SetSkillChecks(new Dictionary<Skills, int>
			{
				[Skills.Combat] = 4
			});
			curCard.SetArePartySkillCheck(new Dictionary<Skills, bool>
			{
				[Skills.Combat] = true
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
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
			curCard.SetSkillChecks(new Dictionary<Skills, int>
			{
				[Skills.Combat] = 6
			});
			curCard.SetArePartySkillCheck(new Dictionary<Skills, bool>
			{
				[Skills.Combat] = true
			});
			curCard.SetMakePsychCheckAfterEncounter(true);
			curCard.SetSuccessHeaderText("");
			curCard.SetSuccessDescriptionText("");
			curCard.AddReward(new GainSpoilsCards(2));
			curCard.SetFailureHeaderText("");
			curCard.SetFailureDescriptionText("");
			curCard.AddPunishment(new TakeD6InfectedDamage(4));
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
