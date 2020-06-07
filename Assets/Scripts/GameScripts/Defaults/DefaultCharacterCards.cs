using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class DefaultCharacterCards
	{
		private List<CharacterCard> CharacterCards;

		public DefaultCharacterCards()
		{
			CharacterCards = new List<CharacterCard>();
			int curID = 0;

			//Add the cards to the list
			CharacterCard curCard;
			ConditionalGain link;
			ConditionalGain conditionalGain;
			Dictionary<Gains, int> rewardChoice;

			Debug.Log("Instantiating character cards...");


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Addison Morley");
			curCard.SetTitleSubString("Veteran Park Ranger");
			curCard.SetQuote("It's way too quiet. Something's not right.");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 9},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 6}
			});
			link = new ConditionalGain();
            rewardChoice = new Dictionary<Gains, int>
            {
                { Gains.Gain_Survival, 1 },
                { Gains.Gain_Combat, 2 }
            };
            link.AddRewardChoice(rewardChoice);
			link.AddWhenRewardCanBeGained(new List<Times>() { Times.Axe_Equipped, Times.Compass_and_Maps_Equipped });
			link.SetNumberOfTimesThisRewardCanBeClaimed(Uses.Unlimited);
			curCard.SetLink(link);
			conditionalGain = new ConditionalGain();
			conditionalGain.SetWhenRewardCanBeGained(new List<Times>() { Times.After_Ally_Card_Is_Gained });
			conditionalGain.SetNumberOfTimesThisRewardCanBeClaimed(Uses.Unlimited);
            rewardChoice = new Dictionary<Gains, int>
            {
                { Gains.Gain_Character_Cards_May_Be_Assigned_To_Party, 1 }
            };
            conditionalGain.AddRewardChoice(rewardChoice);
			curCard.AddConditionalGain(conditionalGain);
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard); //Add the card to the list of all cards
		}

		public List<CharacterCard> GetCharacterCards()
		{
			return CharacterCards;
		}
	}

}