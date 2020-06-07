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


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Joseph Young Wolf");
			curCard.SetTitleSubString("Big Game Hunter");
			curCard.SetQuote("Sure, I've trained town scouts. But I'm a tracker and prefer the open road.");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetIsMaster(true);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 10},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 6},
				{Skills.Technical, 5},
				{Skills.Medical, 6}
			});
			link = new ConditionalGain();
			rewardChoice = new Dictionary<Gains, int>
			{
				{ Gains.Gain_Movement, 1 },
				{ Gains.Gain_Combat, 2 }
			};
			link.AddRewardChoice(rewardChoice);
			link.AddWhenRewardCanBeGained(new List<Times>() { Times.Rifle_Equipped, Times.Shotgun_Equipped });
			link.SetNumberOfTimesThisRewardCanBeClaimed(Uses.Unlimited);
			curCard.SetLink(link);
			curCard.AddPassiveGain(Gains.Gain_Party_Survival_Skill_Check_Successes, 1);
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Norton Carlin");
			curCard.SetTitleSubString("Outrageous Comedian");
			curCard.SetQuote("I mean c'mon, you Eaters don't want me. I know your mothers. In fact, (althought this seems like the wrong time), I'm your father.");
			curCard.SetCarryCapacity(10);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 6},
				{Skills.Technical, 6},
				{Skills.Medical, 6}
			});
			link = new ConditionalGain();
			rewardChoice = new Dictionary<Gains, int>
			{
				{ Gains.Gain_Diplomacy, 2 }
			};
			link.AddRewardChoice(rewardChoice);
			link.AddWhenRewardCanBeGained(new List<Times>() { Times.Indestructible_Tennis_Racquet_Equipped, Times.Sledge_Hammer_Equipped, Times.Sock_Monkey_Puppet_Equipped });
			link.SetNumberOfTimesThisRewardCanBeClaimed(Uses.Unlimited);
			curCard.SetLink(link);
			conditionalGain = new ConditionalGain();
			conditionalGain.SetWhenRewardCanBeGained(new List<Times>() { Times.Rolled_10_On_This_Characters_Skill_Check });
			conditionalGain.SetNumberOfTimesThisRewardCanBeClaimed(Uses.Once_Per_Turn);
			rewardChoice = new Dictionary<Gains, int>
			{
				{ Gains.Reroll_Die_That_Were_10s, 1 }
			};
			conditionalGain.AddRewardChoice(rewardChoice);
			curCard.AddConditionalGain(conditionalGain);
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Martha Mother Trucker");
			curCard.SetTitleSubString("Matron of the I-80 Caravaners");
			curCard.SetQuote("Since the Maddening, I've been to both coasts and everywhere in between.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 9},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			curCard.AddPassiveGain(Gains.Gain_Movement, 1);
			conditionalGain = new ConditionalGain();
			conditionalGain.SetWhenRewardCanBeGained(new List<Times>() { Times.During_Movement_Deed }, new List<Times>() { Times.Within_1_Hex_Of_The_War_Wagon});
			conditionalGain.SetNumberOfTimesThisRewardCanBeClaimed(Uses.Unlimited);
            rewardChoice = new Dictionary<Gains, int>
            {
                { Gains.Roll_D6, 1 }
            };
            conditionalGain.AddRewardChoice(rewardChoice);
			conditionalGain.AddD6Option(new Dictionary<Gains, int>() { { Gains.Steal_The_War_Wagon, 1 } });//1
			conditionalGain.AddD6Option(new Dictionary<Gains, int>() { { Gains.Steal_The_War_Wagon, 1 } });//2
			conditionalGain.AddD6Option(new Dictionary<Gains, int>() { { Gains.Steal_The_War_Wagon, 1 } });//3
			conditionalGain.AddD6Option(new Dictionary<Gains, int>() { { Gains.Steal_The_War_Wagon, 1 } });//4
			conditionalGain.AddD6Option(new Dictionary<Gains, int>() { { Gains.Gain_Week_Penalty_Chip, 1 } });//5
			conditionalGain.AddD6Option(new Dictionary<Gains, int>() { { Gains.Gain_Week_Penalty_Chip, 1 } });//6
            curCard.AddConditionalGain(conditionalGain);
            curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);
		}

		public List<CharacterCard> GetCharacterCards()
		{
			return CharacterCards;
		}
	}

}