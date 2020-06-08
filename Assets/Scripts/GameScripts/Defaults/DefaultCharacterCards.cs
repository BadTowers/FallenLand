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


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Quinn Rubins");
			curCard.SetTitleSubString("Dexterous Sniper");
			curCard.SetQuote("I was a sniper with the Death's Head Mercs, but now I've found my true calling.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 9},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 6}
			});
			//TODO add link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Alan Deacon");
			curCard.SetTitleSubString("Seasoned INvestigator");
			curCard.SetQuote("Don't ever lie to me. I'll always find out the truth.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 5},
				{Skills.Technical, 7},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Sensei Tonaka");
			curCard.SetTitleSubString("Ninjutsu Sensei");
			curCard.SetQuote("You must become one with the shadows.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(9);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 10},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 6}
			});
			curCard.SetHasFirstStrike(true);
			curCard.SetIsMaster(true);
			//TODO add link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Ivory Pace");
			curCard.SetTitleSubString("Fiery Flight Nurse");
			curCard.SetQuote("You kill the slavers. I'll help the refugees.");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 4},
				{Skills.Technical, 6},
				{Skills.Medical, 8}
			});
			//TODO add link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Dylan Mackenzie");
			curCard.SetTitleSubString("Intense Survival Guide");
			curCard.SetQuote("Well? WHat are you all waiting for? Let's do this!");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 9},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 6},
				{Skills.Medical, 8}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Captain Washington");
			curCard.SetTitleSubString("Caravan Officer");
			curCard.SetQuote("I'll get us there alive. Just put me behind the wheel and give me that hand-cannon.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 10},
				{Skills.Technical, 6},
				{Skills.Medical, 6}
			});
			curCard.SetIsMaster(true);
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Miles Krakauer");
			curCard.SetTitleSubString("Energetic Paramedic");
			curCard.SetQuote("I've seen a lot of actiom. Sure it was rough, but it honed my mad skills.");
			curCard.SetCarryCapacity(12);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
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
			curCard = new CharacterCard("Charlton Hallaway");
			curCard.SetTitleSubString("Paranoid Arms Dealer");
			curCard.SetQuote("Charlton don't take no shit! You feel me?");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 4},
				{Skills.Technical, 4},
				{Skills.Medical, 6}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Sean Cahill");
			curCard.SetTitleSubString("Skill Tactician");
			curCard.SetQuote("This is a war game and someone's feelings are getting hurt.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 7},
				{Skills.Medical, 6}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Almiah Bitar");
			curCard.SetTitleSubString("Acrobatic Thief");
			curCard.SetQuote("Hurry! Over the fence, they're coming.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 4},
				{Skills.Technical, 6},
				{Skills.Medical, 4}
			});
			//TODO add conditional gain (choose 1)
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Norris Blake");
			curCard.SetTitleSubString("Inventor");
			curCard.SetQuote("Shut it. Can't you see I'm working? C'mon!");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 8},
				{Skills.Technical, 7},
				{Skills.Medical, 4}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Deforest Tanner MD");
			curCard.SetTitleSubString("Caustic Trauma Surgeon");
			curCard.SetQuote("I may be an elitist, but unlike you, I've actually been out there--in the chaos.");
			curCard.SetCarryCapacity(12);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 6},
				{Skills.Technical, 6},
				{Skills.Medical, 10}
			});
			curCard.SetIsMaster(true);
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Preston Wayne Ascott");
			curCard.SetTitleSubString("Eater posing as an Anesthesiologist");
			curCard.SetQuote("(Smiling) You know I love you all to pieces.");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(9);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 4},
				{Skills.Technical, 4},
				{Skills.Medical, 6}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Monica Pitcher");
			curCard.SetTitleSubString("Baker Street Bootlegger");
			curCard.SetQuote("Some people think I am spiteful, but I have a whimsical side, too.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 7},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Laroy Jenkinz");
			curCard.SetTitleSubString("Grifter");
			curCard.SetQuote("Life's a game. And I'm ALWAYS on top.");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 8},
				{Skills.Mechanical, 4},
				{Skills.Technical, 4},
				{Skills.Medical, 4}
			});
			//TODO add conditional gain
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Guy Turner");
			curCard.SetTitleSubString("Professional Prize Fighter");
			curCard.SetQuote("How about a friendly wager on our fight?");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 6},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Jane Doe");
			curCard.SetTitleSubString("Amnesiac with a Dark Past");
			curCard.SetQuote("I don't remember anything before the accident. But since then, I've been places you'd never even dream of going.");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 9},
				{Skills.Medical, 7}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Samuel Young");
			curCard.SetTitleSubString("Orphan and Party Mascot");
			curCard.SetQuote("I may be young, but I can get places you can't. Especially when things get bad...");
			curCard.SetCarryCapacity(10);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 4},
				{Skills.Technical, 6},
				{Skills.Medical, 4}
			});
			//TODO add link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Sheila Axler");
			curCard.SetTitleSubString("Precocious Runaway");
			curCard.SetQuote("My folks were the lucky ones. They died from some super plague. I'm just stuck here with all of you.");
			curCard.SetCarryCapacity(12);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 4},
				{Skills.Mechanical, 8},
				{Skills.Technical, 8},
				{Skills.Medical, 6}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Bonz");
			curCard.SetTitleSubString("Purveyor of Ill-Gotten Goods");
			curCard.SetQuote("Hurray for me. Screw you!");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 7},
				{Skills.Technical, 7},
				{Skills.Medical, 7}
			});
			curCard.AddPassiveGain(Gains.Gain_Movement, 1);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Annabelle");
			curCard.SetTitleSubString("Cybernetic A.I. and Sleep Agent");
			curCard.SetQuote("I'm smarter, stronger, faster, and dealier.");
			curCard.SetCarryCapacity(17);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 11},
				{Skills.Survival, 8},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 9},
				{Skills.Technical, 9},
				{Skills.Medical, 8}
			});
			curCard.AddPassiveGain(Gains.Gain_Armor, 2);
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Dmitri the Cleaner");
			curCard.SetTitleSubString("Faction Hitman");
			curCard.SetQuote("Show me the target, my friend.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 9},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Kurtis Wyatt");
			curCard.SetTitleSubString("Redneck Salvager");
			curCard.SetQuote("Whatcha' lookin' at? You think I'm purty?");
			curCard.SetCarryCapacity(15);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 4},
				{Skills.Mechanical, 7},
				{Skills.Technical, 7},
				{Skills.Medical, 4}
			});
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Sheldon Benson");
			curCard.SetTitleSubString("Wannabe Bad Ass");
			curCard.SetQuote("You got the goods? I got connections.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 5},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Clayton Pitt");
			curCard.SetTitleSubString("Conniving Grease Monkey");
			curCard.SetQuote("This here's a BRAND NEW alternator.");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 8},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Steven Cartwright PhD");
			curCard.SetTitleSubString("Insightful U.S. History Professor");
			curCard.SetQuote("The human experience can be thoroughly understood by examining the past.");
			curCard.SetCarryCapacity(12);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 7},
				{Skills.Technical, 7},
				{Skills.Medical, 4}
			});
			curCard.AddPassiveGain(Gains.Gain_Prestige, 1);
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Joshua Dean");
			curCard.SetTitleSubString("Malevolent Teenager");
			curCard.SetQuote("I'll make them Pay. Check THIS out...");
			curCard.SetCarryCapacity(12);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 7},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Juan Upton");
			curCard.SetTitleSubString("Construction Foreman");
			curCard.SetQuote("Get outta' here. The whole place is rigger.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 8},
				{Skills.Technical, 5},
				{Skills.Medical, 4}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Randall Davis");
			curCard.SetTitleSubString("Disgruntled Postal Worker");
			curCard.SetQuote("You really don't want to keep pissing me off. I've freaked out on pricks like you for less...");
			curCard.SetCarryCapacity(17);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 4},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 6},
				{Skills.Medical, 4}
			});
			//TODO add link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Dante Slade");
			curCard.SetTitleSubString("Heroic Biker");
			curCard.SetQuote("I used to lead The Highwaymen, but I just wanted to get back on the open road.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 5},
				{Skills.Mechanical, 8},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Augustus Vinventia");
			curCard.SetTitleSubString("Insightful Chaplain");
			curCard.SetQuote("Too late, I uncovered the truth about the Z-666 project. I was cryogenically frozen as the bombs behan to fall.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 9},
				{Skills.Mechanical, 5},
				{Skills.Technical, 7},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Bill Pitcher");
			curCard.SetTitleSubString("Faction Engineer");
			curCard.SetQuote("Change is unavoidable. I ensure it's in our favor.");
			curCard.SetCarryCapacity(14);
			curCard.SetMaxHp(5);
			curCard.SetPsychResistance(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 7},
				{Skills.Technical, 7},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Ignatius Eckersley");
			curCard.SetTitleSubString("Self-Righteous Preacher");
			curCard.SetQuote("The end times are upon us. The evil doers must burn. BURN!");
			curCard.SetCarryCapacity(11);
			curCard.SetMaxHp(9);
			curCard.SetPsychResistance(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 6},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 3},
				{Skills.Mechanical, 6},
				{Skills.Technical, 8},
				{Skills.Medical, 7}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Buck Liddell");
			curCard.SetTitleSubString("MMA Berserker");
			curCard.SetQuote("I was raised fighting in the gladiator pits. There's no such thing as a fair fight.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 9},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 4},
				{Skills.Technical, 5},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Bennie Ocean");
			curCard.SetTitleSubString("Holistic Hippie M.D.");
			curCard.SetQuote("Just relax and trust me, man. I'm a real doctor, man.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 5},
				{Skills.Survival, 6},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 4},
				{Skills.Technical, 5},
				{Skills.Medical, 9}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Lt. \"Red\" Naxela");
			curCard.SetTitleSubString("Glowing Navy Hero");
			curCard.SetQuote("It takes two to the chest and one in the head to touch the hearts and minds of your enemy.");
			curCard.SetCarryCapacity(16);
			curCard.SetMaxHp(8);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 8},
				{Skills.Survival, 7},
				{Skills.Diplomacy, 7},
				{Skills.Mechanical, 6},
				{Skills.Technical, 7},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Evander Stuart");
			curCard.SetTitleSubString("Militia Guardsman");
			curCard.SetQuote("Count me in. I'm way overdue for an adventure.");
			curCard.SetCarryCapacity(13);
			curCard.SetMaxHp(7);
			curCard.SetPsychResistance(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 7},
				{Skills.Survival, 5},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 6},
				{Skills.Technical, 6},
				{Skills.Medical, 5}
			});
			//TODO add link
			//TODO add conditional gain
			curCard.SetId(curID);
			curID++;
			CharacterCards.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new CharacterCard("Monty Reese");
			curCard.SetTitleSubString("Gamer");
			curCard.SetQuote("Awww... Do I get a saving throw?");
			curCard.SetCarryCapacity(17);
			curCard.SetMaxHp(6);
			curCard.SetPsychResistance(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 4},
				{Skills.Diplomacy, 6},
				{Skills.Mechanical, 7},
				{Skills.Technical, 8},
				{Skills.Medical, 6}
			});
			//TODO add link
			//TODO add conditional gain
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