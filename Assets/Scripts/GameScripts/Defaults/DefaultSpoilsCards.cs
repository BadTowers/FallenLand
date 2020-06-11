using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class DefaultSpoilsCards
	{
		private Dictionary<string, int> multiples = new Dictionary<string, int>()
		{
		{"Basic Med Kit", 2},
		{"Swat Body Armor", 2},
		{"First Aid Kit", 2}
		};
		private List<SpoilsCard> SpoilsCardsDeck;

		/*
		 *
		 * NOTES:
		 * 	The title of the card is given in the constructor. This comes from the middle of the card below the image.
		 * 	The spoils types are defined on the upper right side of the card (EXCEPTION, relic is located in the statics)
		 * 	The base skills are the 6 numbers along the bottom of the card. Blanks = 0.
		 * 	The statics are listed to the right of the title on the card. They are things that are ALWAYS gained and DO NOT
		 * 		rely on a particular condition, such as phase, during pvp, after skill checks, etc
		 *	The conditionals are listed on the right side below the types. A conditional does NOT mean that it has to be activated to
		 *		be used. In some cases, it acts as a passive. What makes it a conditional is that it has times when it can
		 *		be used, as well has how many times it can be used. conditionals can also cause the card to be discarded after using.
		 *		EXAMPLE 1) Once every Town Business Phase, the play MAY pay 5 salvage for a salvage card.
		 *			In this example, the user has an ACTIVE CHOICE to perform the action, as well as limits on
		 *			WHEN it can occur (the town business phase) and HOW MANY times it can occur (once per turn).
		 *		EXAMPLE 2) If the opponent has grenades exquipped during PvP, you gain 2 combat successes
		 *			In this example, the user doesn't have to activate this ablility. It's passive in that as long as
		 *			the conditions are met, it automatically happens. This still constitutes being an ACTIVE because
		 *			there are conditions (only during PvP and only if the opponent has grenades equipped). This ability
		 *			would be a passive if it always gave some benefit, regardless of phase, time, etc.
		 *	The conditionals are described by: Conditional gains (what is gained with the conditional, such as movement, spoils cards, etc),
		 *		when the conditional is useable (specific phases or conditions that must be true to use the active), how many
		 *		the conditional is useable (maybe it's once and then you lose the card, maybe it's once per turn, maybe it's once
		 *		per round of PvP, maybe it's after a passed or failed encounter or mission, etc.), and whether or not to discard
		 *		the spoils card after the active has completed.
		 *	Restrictions are conditions that must be upheld at all times for the spoils card to be equipped. These include
		 *		being attached to a vehicle, not being combined with other types of clothing or armor, etc.
		 *
		 *
		 * Below is the block of code used to define a spoils card. The ones marked as optional don't need to be included
		 * 	if they aren't relevent to the card.
		 *
		  curCard = new SpoilsCard("");
		  curCard.curCard.setTitleSubString(""); //Optional
		  curCard.setTypes();
		  curCard.setCarryWeight();
		  curCard.setSellValue();
		  curCard.setBaseSkills(new Dictionary<Skills, int>{

		  });
		  curCard.setStaticGains(new Dictionary<Gains, int>{ //Optional

		  });
		  curCard.setConditionalGains(new Dictionary<Gains, int>{ //Optional

		  });
		  curCard.setWhenUsable(new List<Times>{ //Optional (Needed if there are active gains)

		  });
		  curCard.setNumberOfUses( //Optional (Needed if there are active gains)

		  );
		  curCard.setDiscard( //Optional (Needed if there are active gains)

		  );
		  curCard.setRestrictions(new List<Restrictions>(){ //Optional

		  });
		  curCard.setID(curID);
			curID++;
			spoilsCards.Add(curCard);
		 *
		 *
		 *
		 *
		 * Sometimes, cards will say roll a d6 and then include a chart for the results of each dice outcome.
		 * 	(Example, pre-war disaster kit)
		 * 	(1 = re-roll 1 crit fail skill check)
		 * 	(2 = Draw an action card)
		 * 	(3 = Heal 2d6 damage)
		 * 	(4 = Gain +2 movement)
		 * 	(5 = Gain 3 Salvage coins)
		 * 	(6 = no effect)
		 * In order to code these effects into a single card, each spoils card has the ability to hold 6 additional teporary
		 * 	spoils cards for these effects. We notice that rolls 1-5 are all Gains that could be assigned to an active gains
		 * 	portion of a card. Therefore, when a card needs to have outcomes for a d6 roll, we use the following code to
		 * 	do that:
		 *
		 *
				tempCard = new SpoilsCard("");
			tempCard.setConditionalGains(new Dictionary<Gains, int>{
				{Gains.Reroll_Any_Critical_Fail, 1}
			});
			tempCard.setWhenUsable(new List<Times>(){
				Times.After_Any_Skill_Critical_Failure
			});
			tempCard.setNumberOfUses(
				Uses.Once_Per_Turn
			);
			tempCard.setDiscard(
				true
			);
			tempCard.setWhenTempEnd(
				Times.After_Party_Exploits_Phase
			);
			curCard.addD6Option(tempCard);
		 *
		 *
		 * We create a new spoils card effectively the same way we have been, but there is a new addition--setWhenTempEnd. Because some
		 * 	cards, such as the pre-war disaster kit, give a movement bonus for that party exploits phase. This is not a bonus
		 * 	that should carry outside of this phase, so we set its temporary end to be after the party exploits phase. This will
		 * 	effectively allow the game manage to look through all spoils cards of a player after each phase and see if any
		 * 	need to be removed. Other gains, such as salvage, are something that are gained but not lost, so the active
		 * 	portion of that temp card would give 3 salvage immediately, then discard that card without considering the
		 * 	expiration of the effect (since there isn't an expiration to gaining 3 salvage in this case).
		 */


		public DefaultSpoilsCards()
		{
			//Initialize the lists for the cards
			SpoilsCardsDeck = new List<SpoilsCard>();

			const int VALUE_NOT_NEEDED = -1;

			//Add the cards to the list
			SpoilsCard curCard;
			SpoilsCard tempCard;
			int curID = 0;
			ConditionalGain conditionalGain;
			List<Reward> rewardChoice;

			Debug.Log("Instantiating spoils cards...");


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("A Case of the Finest Champagne"); //Create the card and set the title
			curCard.SetSpoilsTypes(SpoilsTypes.Stowable, SpoilsTypes.Alcohol, SpoilsTypes.Equipment); //Set all types the card fulfils
			curCard.SetCarryWeight(2); //Set how much the item weights
			curCard.SetSellValue(6); //Set the value of the card
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Diplomacy, 3},
				{Skills.Medical, 1}
			});
			/* No statics */
			conditionalGain = new ConditionalGain();
			rewardChoice = new List<Reward>
			{
				new GainSpoilsCards(2)
            };
            conditionalGain.AddRewardChoice(rewardChoice);
			rewardChoice = new List<Reward>
			{
				new GainActionCards(2)
            };
            conditionalGain.AddRewardChoice(rewardChoice);
			conditionalGain.SetWhenRewardCanBeGained(Times.After_Successful_Mission_Or_Encounter);
			conditionalGain.SetNumberOfTimesThisRewardCanBeClaimed(Uses.Unlimited);
			conditionalGain.SetDiscardAfterClaimingReward(true);
			curCard.AddConditionalGain(conditionalGain);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard); //Add the card to the list of all cards


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("6 Armored War Horses");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Horse);
			curCard.SetCarryWeight(12);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 4},
				{Skills.Survival, 2},
				{Skills.Diplomacy, 2}
			});
			curCard.SetStaticGains(new Dictionary<Gains, int>
			{
				{Gains.Gain_Movement, 1}, //Passive 1
				{Gains.All_Hex_Movement_Cost, 1} //Passive 2
			});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Fernando the Chauffer");
			curCard.SetSpoilsTypes(SpoilsTypes.Ally);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(0); //Can't be sold
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				{Skills.Combat, 2},
				{Skills.Survival, 1},
				{Skills.Diplomacy, 3},
				{Skills.Mechanical, 4},
				{Skills.Medical, 2}
			});
			curCard.SetStaticGains(new Dictionary<Gains, int>
			{
				{Gains.Gain_Movement, 2},
				{Gains.Gain_Carry_Weight, 4},
				{Gains.Prevent_Destruction, VALUE_NOT_NEEDED},
				{Gains.Prevent_Theft, VALUE_NOT_NEEDED},
				{Gains.Discard_If_Not_Purchased, VALUE_NOT_NEEDED}
			});
			conditionalGain = new ConditionalGain();
			rewardChoice = new List<Reward>
			{
				new OptionalPaySavage(5)
            };
            conditionalGain.AddRewardChoice(rewardChoice);
			conditionalGain.SetWhenRewardCanBeGained(Times.Immediately);
			conditionalGain.SetNumberOfTimesThisRewardCanBeClaimed(Uses.Unlimited);
			curCard.SetRestrictions(new List<Restrictions>()
			{ //Set 1 of restrictions
				Restrictions.Equip_To_Vehicle, //1.1
				Restrictions.Discard_If_Not_Purchased //1.2
			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Portable Generator");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle_Equipment);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(16);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 2},
			{Skills.Mechanical, 3},
			{Skills.Technical, 5}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Lose_Movement, 1}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){ //Set 1 of restrictions
			Restrictions.Equip_To_Vehicle, //1.1
			Restrictions.Four_Wheels_Or_More //1.2
		}
			);
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Genuine Sock Monkey Puppet");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 1},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>
			{
				//No statics
			});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Give_Opponent_This_Item, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>(){
			Times.Party_Target_Of_Theft
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Matching Baja Buggies");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
			curCard.SetCarryWeight(8);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 1},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2},
			{Gains.All_Hex_Movement_Cost, 1}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("5.56mm Military Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 7}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Silenced 9mm Submachine Gun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, VALUE_NOT_NEEDED}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);



			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Mercenary Armor");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 1}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){ //Set 1
			Restrictions.Not_Used_With_Other_Armor, //1.1
			Restrictions.Not_Used_With_Other_Clothing, //1.2
			Restrictions.Equip_As_First_Item //1.3
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Semi Truck");
			curCard.SetTitleSubString("With Trailer");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
			curCard.SetCarryWeight(20);
			curCard.SetSellValue(26);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 6},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 2},
			{Skills.Mechanical, 1},
			{Skills.Medical, 3}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Equip_Second_Vehicle_Face_Down, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>(){
			Times.Vehicle_Destroyed
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Conscription");
			curCard.SetSpoilsTypes(SpoilsTypes.Event);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{
				//No skills
			});
			curCard.SetStaticGains(new Dictionary<Gains, int>
			{
				//No statics
			});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Draw_Spoils_Cards, 6}, //1.1
			{Gains.Keep_Spoils_Cards, 4}, //1.2
			{Gains.Swap_New_Characters_Freely, VALUE_NOT_NEEDED} //1.3
		});
			curCard.SetWhenUsable(new List<Times>(){
			Times.Immediately
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Cant_Be_Drawn_During_Setup
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Survival Knife");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Knife);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 2},
			{Skills.Medical, 1}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("9mm Submachine Gun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Computer Technical Manual");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 2},
			{Skills.Technical, 4}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Technical_Skill_Checks_Automatic_Pass, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>(){
			Times.After_Technical_Skill_Check_Failure
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Cordless Power Drill");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 4},
			{Skills.Technical, 1}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Arnold Schwartz's");
			curCard.SetTitleSubString("Kronan the Barbarian Sword");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Sword, SpoilsTypes.Relic);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Medical, 1}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Avoid_Death, VALUE_NOT_NEEDED},
			{Gains.Remove_Character_Damage_All, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>(){
			Times.After_Death
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Game
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Pre-War Diaster Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(11);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 2},
			{Skills.Diplomacy, 2},
			{Skills.Mechanical, 2},
			{Skills.Technical, 2},
			{Skills.Medical, 2}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Roll_D6, 1}
		});
			curCard.SetWhenUsable(new List<Times>(){
			Times.Before_Party_Exploits_Phase
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			tempCard = new SpoilsCard("Pre-War Diaster Kit"); //When a 1 is rolled
			tempCard.SetTitleSubString("Bonus Roll - 1");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Reroll_Any_Critical_Fail, 1}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.After_Any_Skill_Critical_Failure
		});
			tempCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.After_Party_Exploits_Phase
			);
			curCard.AddD6Option(tempCard);
			tempCard = new SpoilsCard("Pre-War Diaster Kit"); //When a 2 is rolled
			tempCard.SetTitleSubString("Bonus Roll - 2");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Action_Cards, 1}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.Immediately
		});
			tempCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.Never
			);
			curCard.AddD6Option(tempCard);
			tempCard = new SpoilsCard("Pre-War Diaster Kit"); //When a 3 is rolled
			tempCard.SetTitleSubString("Bonus Roll - 3");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Heal_D6_Damage_Physical, 2}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.Immediately
		});
			tempCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.Never
			);
			curCard.AddD6Option(tempCard);
			tempCard = new SpoilsCard("Pre-War Diaster Kit"); //When a 4 is rolled
			tempCard.SetTitleSubString("Bonus Roll - 4");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.Immediately
		});
			tempCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.After_Party_Exploits_Phase
			);
			curCard.AddD6Option(tempCard);
			tempCard = new SpoilsCard("Pre-War Diaster Kit"); //When a 5 is rolled
			tempCard.SetTitleSubString("Bonus Roll - 5");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Salvage, 3}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.Immediately
		});
			tempCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.Never
			);
			curCard.AddD6Option(tempCard);
			curCard.AddD6Option(null); //Roll 6 = no effect
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Biomedical Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(15);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 1},
			{Skills.Technical, 4},
			{Skills.Medical, 4}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(
				new Dictionary<Gains, int>{ //Set 1 of conditionals
				{Gains.Remove_Party_Physical_Damage_All, VALUE_NOT_NEEDED}, //1.1
				{Gains.Remove_Party_Infected_Damage_All, VALUE_NOT_NEEDED}}, //1.2
				new Dictionary<Gains, int>{ //Set 2 of conditionals
				{Gains.Medical_Skill_Checks_Automatic_Pass, VALUE_NOT_NEEDED}} //2.1
			);
			curCard.SetWhenUsable(
				new List<Times>(){ //Set 1
				Times.Anytime}, //1.1
				new List<Times>(){ //Set 2
				Times.After_Medical_Skill_Check_Failure} //2.1
			);
			curCard.SetNumberOfUses(
				Uses.Unlimited,
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true,
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Crate of Medical Supplies");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(7);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 2},
			{Skills.Medical, 5}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Remove_Party_Physical_Damage_All, VALUE_NOT_NEEDED},
			{Gains.Remove_Party_Infected_Damage_All, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>(){
			Times.Anytime
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Extra Rusty Cleaver");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Deals_Infected_Damage, 1}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Damage_Opponent_Character_By_Crown_Infected, 1}
		});
			curCard.SetWhenUsable(new List<Times>(){
			Times.After_PvP_Round
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_PvP_Round
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Wrist Rocker Slingshot");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(2);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Top o' the Line Stun Gun");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Technical, 1},
			{Skills.Medical, 1}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Roll_D6, 1}
		});
			curCard.SetWhenUsable(new List<Times>(){
			Times.After_Successful_Mission_Or_Encounter
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Successful_Encounter_Or_Mission
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			tempCard = new SpoilsCard("Top o' the Line Stun Gun"); //When a 1 is rolled
			tempCard.SetTitleSubString("Bonus Roll - 1");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Spoils_Cards, 1}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.Immediately
		});
			tempCard.SetNumberOfUses(
				Uses.Unlimited
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.Never
			);
			curCard.AddD6Option(tempCard);
			curCard.AddD6Option(null);
			curCard.AddD6Option(null);
			curCard.AddD6Option(null);
			curCard.AddD6Option(null);
			curCard.AddD6Option(null);
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Sniper Scope Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Permenant);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 2}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, VALUE_NOT_NEEDED}
		});
			/* No conditionals */
			curCard.SetRestrictions(
				new List<Restrictions>(){ //Set 1
				Restrictions.Equip_To_Assault_Rifle //1.1
				},
				new List<Restrictions>(){ //Set 2
				Restrictions.Equip_To_Rifle //2.1
				}
			);
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Snub Nose .357 Revolver");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Sawed Off Double Barreled");
			curCard.SetTitleSubString("12 Gauge Breech Loading Shotgun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Melee_Weapon, SpoilsTypes.Shotgun);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Cannot_Be_Stolen, VALUE_NOT_NEEDED},
			{Gains.Goes_To_Auction_House_Upon_Death, VALUE_NOT_NEEDED}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Indestructible Tennis Racquet");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Sporting_Goods);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(1);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Diplomacy, 1}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_PVP_Combat_Successes, 2}
		});
			curCard.SetWhenUsable(new List<Times>(){
			Times.During_PvP, //1.1
			Times.When_Opposing_Party_Grenades_Equipped //1.2
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_PvP_Round
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Armored Humvee");
			curCard.SetTitleSubString("With .50 Caliber MG Turret");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
			curCard.SetCarryWeight(12);
			curCard.SetSellValue(29);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 9},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 2},
			{Skills.Mechanical, 1},
			{Skills.Medical, 2}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2},
			{Gains.All_Hex_Movement_Cost, 1}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("The Motherload");
			curCard.SetTitleSubString("You have discovered a secret room!");
			curCard.SetSpoilsTypes(SpoilsTypes.Event);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(0);
			/* No base skills */
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Spoils_Cards, 5}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Immediately
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Cant_Be_Drawn_During_Setup
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Retro Mini Camper");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle_Equipment);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 3},
			{Skills.Mechanical, 3},
			{Skills.Medical, 3}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Lose_Movement, 1},
			{Gains.Gain_Carry_Weight, 8}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_Vehicle,
			Restrictions.Four_Wheels_Or_More
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Chris the Trophy Spouse");
			curCard.SetSpoilsTypes(SpoilsTypes.Ally);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 3},
			{Skills.Medical, 3}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Carry_Weight, 4},
			{Gains.Gain_Prestige, 1},
			{Gains.Gain_Psych_Resistence, 1},
			{Gains.Discard_If_Not_Purchased, VALUE_NOT_NEEDED}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Optional_Pay_Salvage, 4}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Immediately
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Discard_If_Not_Purchased
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Alien Plasma Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Top_Secret, SpoilsTypes.Ranged_Weapon, SpoilsTypes.Relic);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(19);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Diplomacy, 2},
			{Skills.Technical, 3}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 1},
			{Gains.Deals_Radiation_Damage, 1}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Damage_Opponent_Character_By_Crown_Radiation, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_PvP_Round
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_PvP_Round
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Sledge Hammer");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Blunt);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Mechanical, 2}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Mechanical_Skill_Checks_Automatic_Pass, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.During_Lock_Picking_Encounters
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Combat Welding & Cutting Torch");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Mechanical, 2},
			{Skills.Technical, 1}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Roll_D6, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Combat_Skill_Check_Success
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			tempCard = new SpoilsCard("Compact Welding & Cutting Torch"); //When a 1 or 2 is rolled
			tempCard.SetTitleSubString("Roll Bonus - 1/2");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Spoils_Cards, 4}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.Immediately
		});
			tempCard.SetNumberOfUses(
				Uses.Unlimited
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.Never
			);
			curCard.AddD6Option(tempCard); //1
			curCard.AddD6Option(tempCard); //2
			curCard.AddD6Option(null);
			curCard.AddD6Option(null);
			curCard.AddD6Option(null);
			curCard.AddD6Option(null);
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Designer Biker Leathers");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor, SpoilsTypes.Clothing);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{

			});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 1}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing,
			Restrictions.Equip_As_First_Item
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Dork Squad");
			curCard.SetTitleSubString("Computer Repair Car");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(17);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 3},
			{Skills.Technical, 5},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Reroll_Technical_Skill_Check, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>{
			{Times.After_Technical_Skill_Check_Failure},
			{Times.During_Encounter_Or_Mission}
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Heavy Rocket Launcher");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Heavy, SpoilsTypes.Relic);
			curCard.SetCarryWeight(8);
			curCard.SetSellValue(21);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 10}
		});
			/* No static gains */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Destroy_Oppenent_Vehicle, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Before_PvP
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Game
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Case of Excellent Whiskey");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Alcohol, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Diplomacy, 3},
			{Skills.Medical, 1}
		});
			/* No statics */
			/* No actives */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Experimental Laser Rifle");
			curCard.SetTitleSubString("Top Secret Weapon");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Top_Secret, SpoilsTypes.Heavy);
			curCard.SetCarryWeight(7);
			curCard.SetSellValue(24);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 8},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 2},
			{Skills.Mechanical, 1},
			{Skills.Technical, 2},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 1}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Not_Used_With_Backback
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("9mm Semi Automatic Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("7.62mm Assault Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 7}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Masamune Crafted Katana");
			curCard.SetQuote("A 14th century masterpiece created by Japan's greatest sword maker.");
			curCard.SetSpoilsTypes(SpoilsTypes.Relic, SpoilsTypes.Melee_Weapon, SpoilsTypes.Sword);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(16);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, VALUE_NOT_NEEDED},
			{Gains.Gain_Psych_Resistence, 1}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Basic Med Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Medical, 3}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Remove_Party_Physical_Damage, 3}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Anytime
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Special Forces Manual");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 3},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Psych_Resistence, 1}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Combat_Skill_Checks_Automatic_Pass, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Combat_Skill_Check_Failure, //1.1
			Times.During_Encounter_Or_Mission //1.2
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Unlimited Stash of Duct Tape");
			curCard.SetSpoilsTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Mechanical);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 3},
			{Skills.Technical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Ignore_Break_Relic_Action_Cards, VALUE_NOT_NEEDED},
			{Gains.Ignore_Broken_Action_Cards, VALUE_NOT_NEEDED}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Roll_D6, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.During_End_Turn_Phase
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			curCard.SetDiscard(
				false
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_All_Party_Members_Or_None
		});
			tempCard = new SpoilsCard("Unlimited Stash of Duct Tape");
			tempCard.SetTitleSubString("Roll 1/2");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Take_Spoils_Cards_From_Top_Discard_Pile, 1}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.Immediately
		});
			tempCard.SetNumberOfUses(
				Uses.Unlimited
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.Never
			);
			curCard.AddD6Option(tempCard); //1
			curCard.AddD6Option(tempCard); //2
			curCard.AddD6Option(null);
			curCard.AddD6Option(null);
			curCard.AddD6Option(null);
			curCard.AddD6Option(null);
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Practically New Ambulance");
			curCard.SetTitleSubString("With Obnoxiously Loud Sirens");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Relic, SpoilsTypes.Four_Wheeled);
			curCard.SetCarryWeight(14);
			curCard.SetSellValue(29);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 2},
			{Skills.Technical, 2},
			{Skills.Medical, 9}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 3}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Heal_D6_Damage_Physical_Or_Infected, 2}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.During_End_Turn_Phase
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Five Machetes");
			curCard.SetSpoilsTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Melee_Weapon, SpoilsTypes.Sword);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 1}
		});
			/* No statics */
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_All_Party_Members_Or_None
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Bars of Gold");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(25);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 4}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(
				new Dictionary<Gains, int>{ //Set 1
				{Gains.Upgrade_Town_Tech_T2, 1} //1.1
				},
				new Dictionary<Gains, int>{ //Set 2
				{Gains.Remove_NPCM_Currently_In_Play, 1} //2.1
				},
				new Dictionary<Gains, int>{ //Set 3
				{Gains.Gain_Resource_Location, 1} //3.1
				}
			);
			curCard.SetWhenUsable(
				new List<Times>{ //Set 1
				Times.Anytime //1.1
				},
				new List<Times>{ //Set 2
				Times.Anytime //2.1
				},
				new List<Times>{ // Set 3
				Times.Anytime //3.1
				}
			);
			curCard.SetNumberOfUses(
				Uses.Unlimited,
				Uses.Unlimited,
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true,
				true,
				true
			);
			/* No restrictions */
			curCard.SetDiscardToTop(false); //This card gets discarded to the bottom of the pile
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Fred Rodgers' Sweater");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor, SpoilsTypes.Clothing, SpoilsTypes.Relic);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(16);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 2},
			{Skills.Technical, 1},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 1}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Steal_Opponent_Town_Tech, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Within_1_Hex_Of_Enemy_Town
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Water Purification Canteens");
			curCard.SetSpoilsTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Medical, SpoilsTypes.Camping_Gear);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 1},
			{Skills.Medical, 2}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Skill_Checks_Automatic_Pass, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Drawing_Perishable_Encounter
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_All_Party_Members_Or_None
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Grenades");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Heavy);
			curCard.SetCarryWeight(7);
			curCard.SetSellValue(16);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 9}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Combat_Skill_Checks_Automatic_Pass, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.During_Encounter_Or_Mission
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Police Interceptor");
			curCard.SetTitleSubString("With Hypnotic Lights");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(19);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Diplomacy, 4},
			{Skills.Medical, 3}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 3}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Take_Characters_From_Opponent_Town_Roster_Into_Players_TR, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Within_1_Hex_Of_Enemy_Town
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Finders Keepers");
			curCard.SetQuote("You have found the item of your dreams...");
			curCard.SetSpoilsTypes(SpoilsTypes.Event);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{

			});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Any_Nonevent_Spoils_Cards_From_Deck_Or_Discard, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Immediately
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Cant_Be_Drawn_During_Setup
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Swat Body Armor");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor, SpoilsTypes.Clothing);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Diplomacy, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 1}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Equip_As_First_Item,
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("9mm Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Paramedic Medical Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 2},
			{Skills.Medical, 5}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Remove_Party_Physical_Damage, 5}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Anytime
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("First Aid Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 1},
			{Skills.Medical, 2}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Remove_Party_Physical_Damage, 2}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Anytime
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Classic All American");
			curCard.SetTitleSubString("Performance Muscle Car");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(19);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Diplomacy, 3},
			{Skills.Mechanical, 2},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 4}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Character_Cards, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Character_Card_Received_As_Reward
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Macho Tow Truck");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Six_Wheeled);
			curCard.SetCarryWeight(13);
			curCard.SetSellValue(19);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Diplomacy, 3},
			{Skills.Mechanical, 5},
			{Skills.Technical, 3}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Roll_D10, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.During_End_Turn_Phase
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			curCard.SetDiscard(
				false
			);
			curCard.SetRestrictions(new List<Restrictions>()
			{

			});
			tempCard = new SpoilsCard("Macho Towing Truck"); //When a 1 is rolled
			tempCard.SetTitleSubString("Bonus Roll - 1-3");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Any_Vehicle_Spoils_Cards_From_Discard, 1}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.Immediately
		});
			tempCard.SetNumberOfUses(
				Uses.Unlimited
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.After_Party_Exploits_Phase
			);
			curCard.AddD10Option(tempCard); //1
			curCard.AddD10Option(tempCard); //2
			curCard.AddD10Option(tempCard); //3
			curCard.AddD10Option(null); //4
			curCard.AddD10Option(null);
			curCard.AddD10Option(null); //6
			curCard.AddD10Option(null);
			curCard.AddD10Option(null); //8
			curCard.AddD10Option(null);
			curCard.AddD10Option(null); //10
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Five Classic .45 Pistols");
			curCard.SetSpoilsTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(30);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3}
		});
			/* No statics */
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_All_Party_Members_Or_None
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Contact Truck");
			curCard.SetTitleSubString("With Matching Yellow Hardhats");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
			curCard.SetCarryWeight(12);
			curCard.SetSellValue(18);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 2},
			{Skills.Mechanical, 4},
			{Skills.Technical, 4},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Keep_All_Stowables, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Vehicle_Destroyed
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Jackpot");
			curCard.SetSpoilsTypes(SpoilsTypes.Event);
			curCard.SetQuote("You have stumbled upon a concealed compartment!");
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{

			});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Spoils_Cards, 4}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Immediately
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Cant_Be_Drawn_During_Setup
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Heavy Armor Plating");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle_Equipment, SpoilsTypes.Permenant);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Lose_Movement, 1}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Prevent_Destruction, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Vehicle_Destroyed
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Game
			);
			curCard.SetDiscard(
				false
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_Vehicle,
			Restrictions.Four_Wheels_Or_More
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("5 Matching Pink Mopeds");
			curCard.SetQuote("At least the thieves had a sense of humor...");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Jinxed, SpoilsTypes.Two_Wheeled);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 1},
			{Skills.Technical, 1},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Discard_Equipped_Vehicle, VALUE_NOT_NEEDED},
			{Gains.Lose_All_Stowables, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Immediately
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Game
			);
			curCard.SetDiscard(
				false
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Cannot_Be_Sold
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Badass Socket Set");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 3},
			{Skills.Technical, 2}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Salvage, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Successful_Mission_Or_Encounter
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Jugs O'Moonshine");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Alcohol, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 2}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Diplomacy_Skill_Checks_Automatic_Pass, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Diplomacy_Skill_Check_Failure
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Militia Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 7}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("High Tech Utility Belt");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Backpack);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 2},
			{Skills.Mechanical, 2},
			{Skills.Technical, 2},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Carry_Weight, 2}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("5.56mm Assault Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 7}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Patton");
			curCard.SetSpoilsTypes(SpoilsTypes.Ally);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Prevent_Theft, VALUE_NOT_NEEDED},
			{Gains.Gain_Carry_Weight, 2},
			{Gains.Gain_Psych_Resistence, 1}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Prevent_Any_Character_Death_And_Set_HP_To, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Any_Party_Member_Death
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Cannot_Be_Sold
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Compound Hunting Bow");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Bow);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 2}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Classic .45 Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("William H Bonnie's");
			curCard.SetTitleSubString("Matching .45 Revolvers");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun, SpoilsTypes.Relic);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(20);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 7},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 2}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Psych_Resistence, 1}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Cheap Mountain Bikes");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Two_Wheeled);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 1},
			{Skills.Medical, 1}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Ram Plate");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle_Equipment, SpoilsTypes.Permenant);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Lose_Movement, 1},
			{Gains.Auto_Succeed_Ambush_Encounters, VALUE_NOT_NEEDED}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_Vehicle,
			Restrictions.Four_Wheels_Or_More
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Espresso Van");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
			curCard.SetCarryWeight(10);
			curCard.SetSellValue(23);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 4},
			{Skills.Mechanical, 1},
			{Skills.Technical, 1},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 4}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Salvage, 4}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.During_End_Turn_Phase
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Experimental Battle Suit");
			curCard.SetTitleSubString("Top Secret Weapon");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor, SpoilsTypes.Relic);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(23);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 1},
			{Skills.Technical, 2},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 1},
			{Gains.Infected_Damage_Treated_As_Physical, VALUE_NOT_NEEDED},
			{Gains.Radiation_Damage_Treated_As_Physical, VALUE_NOT_NEEDED},
			{Gains.Gain_Armor, 2}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard(".45 Semi Automatic Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Expired Pre-War Library Card");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 2},
			{Skills.Mechanical, 2},
			{Skills.Technical, 2},
			{Skills.Medical, 2}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Take_Spoils_Cards_From_Top_Discard_Pile, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Opponent_Discarded_Book_Spoils
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("The President's Football");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Technical, SpoilsTypes.Relic);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(20);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 1},
			{Skills.Diplomacy, 3},
			{Skills.Mechanical, 2},
			{Skills.Technical, 4},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 1},
			{Gains.Auto_Succeed_Sigma_Bunker_Missions, VALUE_NOT_NEEDED}
		});
			/* No conditionals */
			/* No restrctions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Titanium Softball Bat");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Blunt, SpoilsTypes.Sporting_Goods);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
			/* No statics */
			/* No conditionals */
			/* No restrctions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard(".50 Caliber Sniper Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Heavy, SpoilsTypes.Relic);
			curCard.SetCarryWeight(6);
			curCard.SetSellValue(22);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 8},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 1}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Select_Character_From_Opposing_Party, 1},
			{Gains.Roll_D6, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Before_PvP
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Game
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			tempCard = new SpoilsCard(".50 Caliber Sniper Rifle");
			tempCard.SetTitleSubString("Roll - 1-4");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Kill_Selected_Character_From_Opposing_Party, 1},
			{Gains.Discard_Selected_Opposing_Character_Equipment, VALUE_NOT_NEEDED}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.Immediately
		});
			tempCard.SetNumberOfUses(
				Uses.Once_Per_Game
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.After_Party_Exploits_Phase
			);
			curCard.AddD6Option(tempCard); //1
			curCard.AddD6Option(tempCard);
			curCard.AddD6Option(tempCard);
			curCard.AddD6Option(tempCard); //4
			curCard.AddD6Option(null); //5
			curCard.AddD6Option(null); //6
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Soldering Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Technical, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 2},
			{Skills.Technical, 3}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Lock Pick Guide and Tools");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 2},
			{Skills.Technical, 2}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Auto_Succeed_Lock_Picking_Encounters, VALUE_NOT_NEEDED}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Salvage, 2}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.During_End_Turn_Phase
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Lead Filled Kempo Gloves");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Fist);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Individual_Combat_Skill_Check_Successes, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.During_Gladiatorial_Events_Encounters
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Scary Hockey Mask");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Relic);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Health, 1}
		});
			curCard.SetConditionalGains_dep(
				new Dictionary<Gains, int>{ //Set 1
				{Gains.Combat_Skill_Checks_Automatic_Pass, 1} //1.1
				},
				new Dictionary<Gains, int>{ //Set 2
				{Gains.Combat_Skill_Checks_Automatic_Pass, 1} //2.1
				},
				new Dictionary<Gains, int>{ //Set 3
				{Gains.Combat_Skill_Checks_Automatic_Pass, 1} //3.1
				}
			);
			curCard.SetWhenUsable(
				new List<Times>{ //Set 1
				Times.Axe_Equipped, //1.1
				Times.During_Encounter_Mission_Or_PvP, //1.2
				},
				new List<Times>{ //Set 2
				Times.Industrial_Chainsaw_Equipped, //2.1
				Times.During_Encounter_Mission_Or_PvP,
				},
				new List<Times>{ //Set 3
				Times.Rusty_Cleaver_Equipped, //3.1
				Times.During_Encounter_Mission_Or_PvP,
				}
			);
			curCard.SetNumberOfUses(
				Uses.Unlimited,
				Uses.Unlimited,
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false,
				false,
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Firefighter's Axe");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Axe);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Mechanical_Skill_Checks_Automatic_Pass, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.During_Lock_Picking_Encounters
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("6.8mm Advanced Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(15);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 7},
			{Skills.Survival, 1}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Elite Camping Backpack");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Backpack, SpoilsTypes.Camping_Gear);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 2},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Carry_Weight, 5}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Flare Gun Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 2}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Ignore_Negatives_Of_Encounter_Or_Mission_Failure, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Failed_Mission_Or_Encounter
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Vendetta Daggers");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Knife, SpoilsTypes.Relic);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(13);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 4}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Dear Old Ma's Repair Kit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 1},
			{Skills.Mechanical, 2},
			{Skills.Technical, 2},
			{Skills.Medical, 1}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Ultimate Set of Tools");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(8);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 5},
			{Skills.Technical, 3}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Any_Spoils_Cards_From_Discard, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Anytime
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Game
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("A History of World Diplomacy");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 4}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Diplomacy_Skill_Checks_Automatic_Pass, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Diplomacy_Skill_Check_Failure
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard(".223 Sniper Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Rifle);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Survival, 2}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, VALUE_NOT_NEEDED}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Trunk of Unlimited Disguises");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 1}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(
				new Dictionary<Gains, int>{ //set 1
				{Gains.Steal_Spoils_From_Opposing_Party_Excluding_Vehicles, 1} //1.1
				},
				new Dictionary<Gains, int>{ //set 2
				{Gains.Steal_Spoils_From_Opposing_Town_Auction_House, 1} //2.1
				}
			);
			curCard.SetWhenUsable(
				new List<Times>{ //set 1
				Times.Within_1_Hex_Of_Enemy_Party //1.1
				},
				new List<Times>{ //set 2
				Times.Within_1_Hex_Of_Enemy_Town //2.1
				}
			);
			curCard.SetNumberOfUses(
				Uses.Once_Per_Turn,
				Uses.Once_Per_Turn
			);
			curCard.SetDiscard(
				false,
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Fallen Land Board Game");
			curCard.SetQuote("A strange pre-war board game about the apocalypse...");
			curCard.SetSpoilsTypes(SpoilsTypes.Stowable);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(13);
			curCard.SetBaseSkills(new Dictionary<Skills, int>
			{

			});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 2}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Blower or Supercharger");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle_Equipment, SpoilsTypes.Permenant);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1},
			{Gains.Ignore_All_Vehicle_Equipment_Movement_Penalties, VALUE_NOT_NEEDED}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_Vehicle,
			Restrictions.Four_Wheels_Or_More
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("The War Wagon");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Relic, SpoilsTypes.Six_Wheeled);
			curCard.SetCarryWeight(16);
			curCard.SetSellValue(40);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 10},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 4},
			{Skills.Mechanical, 3},
			{Skills.Technical, 2},
			{Skills.Medical, 4}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 2},
			{Gains.Gain_Movement, 2}
		});
			curCard.SetConditionalGains_dep(
				new Dictionary<Gains, int>{ //Set 1
				{Gains.Gain_Character_Cards, 2} //1.1
				},
				new Dictionary<Gains, int>{ //Set 2
				{Gains.Roll_D6, 1} //2.1
				}
			);
			curCard.SetWhenUsable(
				new List<Times>{ //Set 1
				Times.Immediately
				},
				new List<Times>{ //Set 2
				Times.Vehicle_Destroyed
				}
			);
			curCard.SetNumberOfUses(
				Uses.Unlimited,
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false, false
			);
			/* No restrictions */
			tempCard = new SpoilsCard("The War Wagon");
			tempCard.SetTitleSubString("Roll - 1-3");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Prevent_Destruction, 1}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.Immediately
		});
			tempCard.SetNumberOfUses(
				Uses.Unlimited
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.Immediately
			);
			curCard.AddD6Option(tempCard); //1
			curCard.AddD6Option(tempCard);
			curCard.AddD6Option(tempCard); //3
			curCard.AddD6Option(null); //4
			curCard.AddD6Option(null);
			curCard.AddD6Option(null); //6
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard(".22 Small Bore Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Rifle);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 1}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Lumberjack Axe");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Axe);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 2}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Nifty Multi-Tool");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical, SpoilsTypes.Melee_Weapon);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(6);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Mechanical, 2},
			{Skills.Technical, 1},
			{Skills.Medical, 1}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Vintage .45 Submachine Gun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(13);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Brass Knuckles");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Fist);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(3);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Individual_Combat_Skill_Check_Successes, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.During_Gladiatorial_Events_Encounters
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Luxurious Designer Suit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Clothing);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 5}
		});
			/* No statics */
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing,
			Restrictions.Equip_As_First_Item
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Heavy Duty Flashlight");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Blunt, SpoilsTypes.Melee_Weapon);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 2},
			{Skills.Mechanical, 2},
			{Skills.Technical, 1}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Combat Medic Satchel");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(12);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 2},
			{Skills.Medical, 7}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(
				new Dictionary<Gains, int>{ //Set 1
				{Gains.Remove_Party_Physical_Damage, 4} //1.1
				},
				new Dictionary<Gains, int>{ //Set 2
				{Gains.Prevent_Any_Character_Death_And_Set_HP_To, 1} //2.1
				}
			);
			curCard.SetWhenUsable(
				new List<Times>{ //Set 1
				Times.Anytime //1.1
				},
				new List<Times>{ //Set 2
				Times.Any_Party_Member_Death //2.1
				}
			);
			curCard.SetNumberOfUses(
				Uses.Unlimited,
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true,
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Ultimate Laptop");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Technical);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(18);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 3},
			{Skills.Technical, 5},
			{Skills.Medical, 3}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("12 Guage Pump Shotgun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Shotgun);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Rocket Launcher");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Heavy, SpoilsTypes.Relic);
			curCard.SetCarryWeight(7);
			curCard.SetSellValue(18);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 9}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Destroy_Oppenent_Vehicle, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Before_PvP
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Game
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Camping Gear");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Camping_Gear, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 3},
			{Skills.Medical, 2}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Ol' Rusty");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 2},
			{Skills.Technical, 1},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1},
			{Gains.Stacks_With_Other_Vehicles, 1}
		});
			curCard.SetConditionalGains_dep(
				new Dictionary<Gains, int>{ //set 1
				{Gains.Gain_Kurtis_Wyatt_Character_Card, VALUE_NOT_NEEDED} //1.1
				},
				new Dictionary<Gains, int>{ //set 2
				{Gains.Choose_Which_Vehicle_To_Discard, VALUE_NOT_NEEDED} //2.1
				}
			);
			curCard.SetWhenUsable(
				new List<Times>{ //set 1
				Times.Immediately //1.1
				},
				new List<Times>{ //set 2
				Times.Vehicle_Destroyed //2.1
				}
			);
			curCard.SetNumberOfUses(
				Uses.Unlimited, //1.1
				Uses.Unlimited //2.1
			);
			curCard.SetDiscard(
				false,
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Chopper and Pilot");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Zero_Wheeled);
			curCard.SetCarryWeight(16);
			curCard.SetSellValue(0);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 6},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 3},
			{Skills.Mechanical, 3},
			{Skills.Technical, 3},
			{Skills.Medical, 3}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 8},
			{Gains.All_Hex_Movement_Cost, 1},
			{Gains.Discard_If_Not_Purchased, VALUE_NOT_NEEDED}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Optional_Pay_Salvage, 10}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Immediately
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Cannot_Be_Sold,
			Restrictions.Discard_If_Not_Purchased
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Industrial Chainsaw");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon);
			curCard.SetCarryWeight(5);
			curCard.SetSellValue(11);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 2},
			{Skills.Mechanical, 1}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Individual_Combat_Skill_Check_Successes, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.During_Rad_Zombie_Encounters
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Gyrocopter");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Relic, SpoilsTypes.Zero_Wheeled); //May not be a zero wheel vehicle?
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(25);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 1},
			{Skills.Mechanical, 4}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Stacks_With_Other_Vehicles, 1},
			{Gains.Gain_Movement, 1}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Roll_D6, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Each_Movement
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			curCard.SetRestrictions(new List<Restrictions>()
			{

			});
			tempCard = new SpoilsCard("Gyrocopter");
			tempCard.SetTitleSubString("Roll - 1-2");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Draw_Encounter_Cards, 2},
			{Gains.Keep_Encounter_Cards, 1}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.After_Any_Skill_Critical_Failure
		});
			tempCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.After_Party_Exploits_Phase
			);
			curCard.AddD6Option(tempCard); //1
			curCard.AddD6Option(tempCard); //2
			curCard.AddD6Option(null);  //3
			curCard.AddD6Option(null);
			curCard.AddD6Option(null);
			curCard.AddD6Option(null); //6
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Nifty Chemistry Set");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Technical, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Technical, 4},
			{Skills.Medical, 3}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Luxury SUV");
			curCard.SetTitleSubString("With Spinner Rims and Hydraulics");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
			curCard.SetCarryWeight(12);
			curCard.SetSellValue(19);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 1},
			{Skills.Medical, 3}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Steal_D10_Salvage, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.Within_1_Hex_Of_Enemy_Town
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Geiger Counter");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(9);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Technical, 2}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Ignore_Radiation_Damage_From_Hexes, VALUE_NOT_NEEDED}
		});
			curCard.SetConditionalGains_dep(
				new Dictionary<Gains, int>{ //set 1
				{Gains.Gain_Spoils_Cards, 1} //1.1
				},
				new Dictionary<Gains, int>{ //set 2
				{Gains.Gain_Action_Cards, 1} //2.1
				}
			);
			curCard.SetWhenUsable(
				new List<Times>{ //set 1
				Times.Before_Drawing_City_Rad_Encounter_Card //1.1
				},
				new List<Times>{ //set 2
				Times.Before_Drawing_City_Rad_Encounter_Card //2.1
				}
			);
			curCard.SetNumberOfUses(
				Uses.Unlimited,
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false,
				false
			);
			curCard.SetRestrictions(new List<Restrictions>()
			{

			});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Cache of Military Body Armor");
			curCard.SetSpoilsTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Armor);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(25);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Diplomacy, 2}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 1}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_All_Party_Members_Or_None,
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Enigma Van");
			curCard.SetTitleSubString("With Custom 60's Paint Job");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Relic, SpoilsTypes.Four_Wheeled);
			curCard.SetCarryWeight(20);
			curCard.SetSellValue(24);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 3},
			{Skills.Technical, 3},
			{Skills.Medical, 2}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Reroll_Any_Skill_Check, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Any_Skill_Check_Fail_Mission
		});
			curCard.SetNumberOfUses(
				Uses.Once_Per_Turn
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Pro Fishing Gear & Tackle");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Camping_Gear, SpoilsTypes.Stowable);
			curCard.SetCarryWeight(2);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 3}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Psych_Resistence, 1},
			{Gains.Auto_Succeed_Perishable_Encounters, VALUE_NOT_NEEDED}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("6 Fast Horses");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Horse);
			curCard.SetCarryWeight(14);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 1},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2},
			{Gains.All_Hex_Movement_Cost, 1}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Henry's Guide to Repairs");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 3},
			{Skills.Technical, 2}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Mechanical_Skill_Checks_Automatic_Pass, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Mechanical_Skill_Check_Failure
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Roadkill Cookbook");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(4);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 3},
			{Skills.Diplomacy, 1}
		});

			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Survival_Skill_Checks_Automatic_Pass, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Survival_Skill_Check_Failure
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("High Tech Body Armor");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(15);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Diplomacy, 2}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 2}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing,
			Restrictions.Equip_As_First_Item
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Larry's Guide to Civil War Surgery");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Medical, 3}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Medical_Skill_Checks_Automatic_Pass, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Medical_Skill_Check_Failure
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Excludes_Healing_Deed
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Flame Thrower");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Melee_Weapon, SpoilsTypes.Heavy_Weapon, SpoilsTypes.Relic);
			curCard.SetCarryWeight(7);
			curCard.SetSellValue(24);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 10}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Auto_Succeed_Combat_Encounters, VALUE_NOT_NEEDED}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.During_Combat_Encounter_Card
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				true
			);
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Not_Used_With_Backback,
			Restrictions.Excludes_World_Cards
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("4.6mm Submachine Gun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(17);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 6}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Radiation and Biohazard Suits");
			curCard.SetSpoilsTypes(SpoilsTypes.Party_Equipment);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, -1},
			{Skills.Survival, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Lose_Movement, 1},
			{Gains.Ignore_Radiation_Damage, VALUE_NOT_NEEDED},
			{Gains.Infected_Damage_Treated_As_Physical, VALUE_NOT_NEEDED}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_All_Party_Members_Or_None
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard(".44 Semi Automatic Pistol");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
			curCard.SetCarryWeight(3);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("High Tech Crossbow");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Bow);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(7);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 2}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Autographed Bat");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Blunt, SpoilsTypes.Sporting_Goods, SpoilsTypes.Relic);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(15);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Diplomacy, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Psych_Resistence, 1}
		});
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Spoils_Cards, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Combat_Encounter_Success
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("10 Gauge Pump Shotgun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Shotgun);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(8);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 2}
		});
			/* No statics */
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("Leather Bull Whip");
			curCard.SetSpoilsTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Blunt);
			curCard.SetCarryWeight(1);
			curCard.SetSellValue(5);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1}
		});
			/* No statics */
			curCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Roll_D6, 1}
		});
			curCard.SetWhenUsable(new List<Times>{
			Times.After_Successful_Mission_Or_Encounter
		});
			curCard.SetNumberOfUses(
				Uses.Unlimited
			);
			curCard.SetDiscard(
				false
			);
			/* No restrictions */
			tempCard = new SpoilsCard("Leather Bull Whip");
			tempCard.SetTitleSubString("Roll - 1");
			tempCard.SetConditionalGains_dep(new Dictionary<Gains, int>{
			{Gains.Gain_Spoils_Cards, 1}
		});
			tempCard.SetWhenUsable(new List<Times>(){
			Times.Immediately
		});
			tempCard.SetNumberOfUses(
				Uses.Unlimited
			);
			tempCard.SetDiscard(
				true
			);
			tempCard.SetWhenTempEnd(
				Times.Never
			);
			curCard.AddD6Option(tempCard); //1
			curCard.AddD6Option(null); //2
			curCard.AddD6Option(null);
			curCard.AddD6Option(null); //4
			curCard.AddD6Option(null);
			curCard.AddD6Option(null); //6
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("5.56mm Bolt Action Rifle");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Rifle);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(15);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Survival, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, VALUE_NOT_NEEDED}
		});
			/* No conditional */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("12 Gauge Bullpup Shotgun");
			curCard.SetSpoilsTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Shotgun);
			curCard.SetCarryWeight(4);
			curCard.SetSellValue(10);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
			/* No statics */
			/* No conditional */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("The Duke's Cowboy Outfit");
			curCard.SetSpoilsTypes(SpoilsTypes.Equipment, SpoilsTypes.Clothing, SpoilsTypes.Relic);
			curCard.SetCarryWeight(0);
			curCard.SetSellValue(14);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 4},
			{Skills.Diplomacy, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1},
			{Gains.Gain_Psych_Resistence, 1}
		});
			/* No conditionals */
			curCard.SetRestrictions(new List<Restrictions>(){
			Restrictions.Equip_As_First_Item,
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing
		});
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);


			/****************************************************************************************************************************************************************/
			curCard = new SpoilsCard("American Iron Custom Choppers");
			curCard.SetSpoilsTypes(SpoilsTypes.Vehicle, SpoilsTypes.Two_Wheeled);
			curCard.SetCarryWeight(12);
			curCard.SetSellValue(13);
			curCard.SetBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 3},
			{Skills.Medical, 1}
		});
			curCard.SetStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
			/* No conditionals */
			/* No restrictions */
			curCard.SetId(curID);
			curID++;
			SpoilsCardsDeck.Add(curCard);






			//Now that all cards are added, let's ID them all and account for duplicates that need to be added
			int count = SpoilsCardsDeck.Count;
			for (int i = 0; i < count; i++)
			{
				SpoilsCardsDeck[i].SetId(i); //ID current one

				//See if this card is a duplicate
				if (multiples.ContainsKey(SpoilsCardsDeck[i].GetTitle()))
				{ //If the name of this card is a name in the multiples dictionary
					for (int j = 1; j < multiples[SpoilsCardsDeck[i].GetTitle()]; j++)
					{ //For the number of multiples to add
						SpoilsCard newCard = SpoilsCardsDeck[i].DeepCopy();
						SpoilsCardsDeck.Add(newCard); //add the multiple
													  //Debug.Log("Adding multiple for " + spoilsCards[i].getTitle());
					}
				}
			}
		}


		public List<SpoilsCard> GetSpoilsCards()
		{
			return SpoilsCardsDeck;
		}
	}
}