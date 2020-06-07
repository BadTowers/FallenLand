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


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Ashton Campbell");
			curCard.SetTitleSubString("Resourceful Scavenger");
			curCard.SetQuote("As a salvager, I can find just about anything.");
			curCard.SetCarryCapacity(17);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 5},
				{Skills.Technical, 6},
				{Skills.Medical, 6}
			});
			link = new ConditionalGain();
			rewardChoice = new Dictionary<Gains, int>
			{
				{ Gains.Gain_Spoils_Cards, 2 }
			};
			link.AddRewardChoice(rewardChoice);
			link.AddWhenRewardCanBeGained(new List<Times>() { Times.Binoculars_Equipped, Times.Flare_Gun_Equipped });
			link.SetNumberOfTimesThisRewardCanBeClaimed(Uses.Once_Per_Game);
			curCard.SetLink(link);
			conditionalGain = new ConditionalGain();
			conditionalGain.SetWhenRewardCanBeGained(new List<Times>() { Times.After_Successful_Store_Loot_Encounter });
			conditionalGain.SetNumberOfTimesThisRewardCanBeClaimed(Uses.Unlimited);
			rewardChoice = new Dictionary<Gains, int>
			{
				{ Gains.Gain_Spoils_Cards, 2 }
			};
			conditionalGain.AddRewardChoice(rewardChoice);
			curCard.AddConditionalGain(conditionalGain);
			conditionalGain = new ConditionalGain();
			conditionalGain.SetWhenRewardCanBeGained(new List<Times>() { Times.During_Rad_Zombie_Encounters });
			conditionalGain.SetNumberOfTimesThisRewardCanBeClaimed(Uses.Unlimited);
            rewardChoice = new Dictionary<Gains, int>
            {
                { Gains.Gain_Combat, 10 }
            };
            conditionalGain.AddRewardChoice(rewardChoice);
            curCard.AddConditionalGain(conditionalGain);
            curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Peter Kelsey");
			curCard.SetTitleSubString("Chatty Repairman");
			curCard.SetQuote("I've been told I'm best in small doses.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 4},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 8},
				{Skills.Technical, 9},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("SSG Carter Neil");
			curCard.SetTitleSubString("Veteran Town Scout");
			curCard.SetQuote("They won't even see us coming, until it's too late.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(9);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 5},
				{Skills.Technical, 6},
				{Skills.Medical, 7}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Orison Lech");
			curCard.SetTitleSubString("Faction Bureaucrat");
			curCard.SetQuote("Believe me. I'll always find a way to make our enemies pay.");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 9},
				{Skills.Mechanical, 6},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Bruce Stephens");
			curCard.SetTitleSubString("Exile");
			curCard.SetQuote("My last group sent me out here to die... I didn't...");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 4},
				{Skills.Mechanical, 9},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add passive gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Wade Marlow");
			curCard.SetTitleSubString("Friendly Iowan");
			curCard.SetQuote("You've heard of Midwestern charm, right?");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 5},
				{Skills.Technical, 6},
				{Skills.Medical, 6}
			});
			//TODO add link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Max Gibson");
			curCard.SetTitleSubString("Wasteland Vigilante");
			curCard.SetQuote("I've seen a few road wars. It's a nasty business.");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(9);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 5},
				{Skills.Medical, 4}
			});
			//TODO add link
			//TODO add conditional gain
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