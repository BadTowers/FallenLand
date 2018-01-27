using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSpoilsCards : MonoBehaviour{

	public List<SpoilsCard> spoilsCards; //The list of all default spoils cards

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
	 * curCard = new SpoilsCard("");
	 * curCard.curCard.setTitleSubString(""); //Optional
	 * curCard.setTypes();
	 * curCard.setCarryWeight();
	 * curCard.setSellValue();
	 * curCard.setBaseSkills(new Dictionary<Skills, int>{
	 * 	
	 * });
	 * curCard.setStaticGains(new Dictionary<Gains, int>{ //Optional
	 * 	
	 * });
	 * curCard.setConditionalGains(new Dictionary<Gains, int>{ //Optional
	 * 		
	 * });
	 * curCard.setWhenUsable(new List<Times>{ //Optional (Needed if there are active gains)
	 * 		
	 * });
	 * curCard.setNumberOfUses( //Optional (Needed if there are active gains)
	 * 		
	 * );
	 * curCard.setDiscard( //Optional (Needed if there are active gains)
	 * 		
	 * );
	 * curCard.setRestrictions(new List<Restrictions>(){ //Optional
	 * 		
	 * });
	 * spoilsCards.Add(curCard);
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
	 *      tempCard = new SpoilsCard("");
	 *	tempCard.setConditionalGains(new Dictionary<Gains, int>{
	 *		{Gains.Reroll_Any_Critical_Fail, 1}
	 *	});
	 *	tempCard.setWhenUsable(new List<Times>(){
	 *		Times.After_Any_Skill_Critical_Failure
	 *	});
	 *	tempCard.setNumberOfUses(
	 *		Uses.Once_Per_Turn
	 *	);
	 *	tempCard.setDiscard(
	 *		true
	 *	);
	 *	tempCard.setWhenTempEnd(
	 *		Times.After_Party_Exploits_Phase
	 *	);
	 *	curCard.addD6Option(tempCard);
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


	//Called before Start()
	void Awake(){
		//Initialize the lists for the cards
		spoilsCards = new List<SpoilsCard>();

		const int VALUE_NOT_NEEDED = -1;

		//Add the cards to the list
		SpoilsCard curCard;
		SpoilsCard tempCard;


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("A Case of the Finest Champagne"); //Create the card and set the title
		curCard.setTypes(SpoilsTypes.Stowable, SpoilsTypes.Alcohol, SpoilsTypes.Equipment); //Set all types the card fulfils
		curCard.setCarryWeight(2); //Set how much the item weights
		curCard.setSellValue(6); //Set the value of the card
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 3},
			{Skills.Medical, 1}
		});
		/* No statics */
		curCard.setConditionalGains( //Set the active abilities the card can do
			new Dictionary<Gains, int>{ //Set 1 of conditionals
				{Gains.Gain_Spoils_Cards, 2}}, //1.1
			new Dictionary<Gains, int>{ //Set 2 of conditionals
				{Gains.Gain_Action_Cards, 2}} //2.1
		);
		curCard.setWhenUsable( //Set when the conditionals are useable
			new List<Times>(){ //Set 1
				Times.After_Successful_Mission_Or_Encounter}, //1.1
			new List<Times>(){ //Set 2
				Times.After_Successful_Mission_Or_Encounter} //2.1
		);
		curCard.setNumberOfUses( //Set how many uses each active has
			Uses.Once, //Set 1
			Uses.Once //Set 2
		);
		curCard.setDiscard( //Set if the active use causes the card to be discarded
			true, //Set 1
			true //Set 2
		);
		/* No restrictions */
		spoilsCards.Add(curCard); //Add the card to the list of all cards


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("6 Armored War Horses");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Horse);
		curCard.setCarryWeight(12);
		curCard.setSellValue(12);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1}, //Passive 1
			{Gains.All_Hex_Movement_Cost, 1} //Passive 2
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Fernando the Chauffer");
		curCard.setTypes(SpoilsTypes.Ally);
		curCard.setCarryWeight(0);
		curCard.setSellValue(0); //Can't be sold
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 3},
			{Skills.Mechanical, 4},
			{Skills.Medical, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2},
			{Gains.Gain_Carry_Weight, 4},
			{Gains.Prevent_Distruction, VALUE_NOT_NEEDED},
			{Gains.Prevent_Theft, VALUE_NOT_NEEDED}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Pay_Salvage, 5}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		curCard.setNumberOfUses(
			Uses.Once
		);
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(new List<Restrictions>(){ //Set 1 of restrictions
				Restrictions.Equip_To_Vehicle //1.1
			}
		);
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Portable Generator");
		curCard.setTypes(SpoilsTypes.Vehicle_Equipment);
		curCard.setCarryWeight(0);
		curCard.setSellValue(16);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 2},
			{Skills.Mechanical, 3},
			{Skills.Technical, 5}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Lose_Movement, 1}
		});
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){ //Set 1 of restrictions
				Restrictions.Equip_To_Vehicle, //1.1
				Restrictions.Four_Wheels_Or_More //1.2
			}
		);
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Genuine Sock Monkey Puppet");
		curCard.setTypes(SpoilsTypes.Equipment);
		curCard.setCarryWeight(0);
		curCard.setSellValue(3);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 1},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			//No statics
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Give_Opponent_This_Item, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.Party_Target_Of_Theft
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Matching Baja Buggies");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
		curCard.setCarryWeight(8);
		curCard.setSellValue(14);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 1},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2},
			{Gains.All_Hex_Movement_Cost, 1}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("5.56mm Military Rifle");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
		curCard.setCarryWeight(5);
		curCard.setSellValue(12);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 7}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Silenced 9mm Submachine Gun");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
		curCard.setCarryWeight(4);
		curCard.setSellValue(14);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, VALUE_NOT_NEEDED}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);



		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Mercenary Armor");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor);
		curCard.setCarryWeight(3);
		curCard.setSellValue(14);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 1}
		});
		/* No conditionals */
		curCard.setRestrictions( new List<Restrictions>(){ //Set 1
				Restrictions.Not_Used_With_Other_Armor, //1.1
				Restrictions.Not_Used_With_Other_Clothing //1.2
			}
		);
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Semi Truck");
		curCard.setTitleSubString("With Trailer");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
		curCard.setCarryWeight(20);
		curCard.setSellValue(26);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 6},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 2},
			{Skills.Mechanical, 1},
			{Skills.Medical, 3}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Equip_Second_Vehicle_Face_Down, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.Vehicle_Destroyed
		});
		curCard.setNumberOfUses(
			Uses.Once
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Conscription");
		curCard.setTypes(SpoilsTypes.Event);
		curCard.setCarryWeight(0);
		curCard.setSellValue(5);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			//No skills
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			//No statics
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Draw_Spoils_Cards, 6}, //1.1
			{Gains.Keep_Spoils_Cards, 4}, //1.2
			{Gains.Swap_New_Characters_Freely, VALUE_NOT_NEEDED} //1.3
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		curCard.setNumberOfUses(
			Uses.Once
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Survival Knife");
		curCard.setTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Knife);
		curCard.setCarryWeight(1);
		curCard.setSellValue(3);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 2},
			{Skills.Medical, 1}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("9mm Submachine Gun");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
		curCard.setCarryWeight(4);
		curCard.setSellValue(12);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Computer Technical Manual");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
		curCard.setCarryWeight(0);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 2},
			{Skills.Technical, 4}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Technical_Skill_Check_Automatic_Pass, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.After_Technical_Skill_Check_Failure
		});
		curCard.setNumberOfUses(
			Uses.Once
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Cordless Power Drill");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical);
		curCard.setCarryWeight(2);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 4},
			{Skills.Technical, 1}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Arnold Schwartz's");
		curCard.setTitleSubString("Kronan the Barbarian Sword");
		curCard.setTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Sword, SpoilsTypes.Relic);
		curCard.setCarryWeight(4);
		curCard.setSellValue(14);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Medical, 1}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Avoid_Death, VALUE_NOT_NEEDED},
			{Gains.Remove_Character_All_Damage, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.After_Death
		});
		curCard.setNumberOfUses(
			Uses.Once_Per_Game
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Pre-War Diaster Kit");
		curCard.setTypes(SpoilsTypes.Equipment);
		curCard.setCarryWeight(4);
		curCard.setSellValue(11);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 2},
			{Skills.Diplomacy, 2},
			{Skills.Mechanical, 2},
			{Skills.Technical, 2},
			{Skills.Medical, 2}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Roll_D6, 1}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.Before_Party_Exploits_Phase
		});
		curCard.setNumberOfUses(
			Uses.Once_Per_Turn
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		tempCard = new SpoilsCard("Pre-War Diaster Kit"); //When a 1 is rolled
		tempCard.setTitleSubString("Bonus Roll - 1");
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
		tempCard = new SpoilsCard("Pre-War Diaster Kit"); //When a 2 is rolled
		tempCard.setTitleSubString("Bonus Roll - 2");
		tempCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Action_Cards, 1}
		});
		tempCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		tempCard.setNumberOfUses(
			Uses.Once_Per_Turn
		);
		tempCard.setDiscard(
			true
		);
		tempCard.setWhenTempEnd(
			Times.Never
		);
		tempCard = new SpoilsCard("Pre-War Diaster Kit"); //When a 3 is rolled
		tempCard.setTitleSubString("Bonus Roll - 3");
		tempCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Heal_D6_Damage, 2}
		});
		tempCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		tempCard.setNumberOfUses(
			Uses.Once_Per_Turn
		);
		tempCard.setDiscard(
			true
		);
		tempCard.setWhenTempEnd(
			Times.Never
		);
		curCard.addD6Option(tempCard);
		tempCard = new SpoilsCard("Pre-War Diaster Kit"); //When a 4 is rolled
		tempCard.setTitleSubString("Bonus Roll - 4");
		tempCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
		tempCard.setWhenUsable(new List<Times>(){
			Times.Immediately
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
		tempCard = new SpoilsCard("Pre-War Diaster Kit"); //When a 5 is rolled
		tempCard.setTitleSubString("Bonus Roll - 5");
		tempCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Salvage, 3}
		});
		tempCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		tempCard.setNumberOfUses(
			Uses.Once_Per_Turn
		);
		tempCard.setDiscard(
			true
		);
		tempCard.setWhenTempEnd(
			Times.Never
		);
		curCard.addD6Option(tempCard);
		curCard.addD6Option(null); //Roll 6 = no effect
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Biomedical Kit");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
		curCard.setCarryWeight(3);
		curCard.setSellValue(15);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 1},
			{Skills.Technical, 4},
			{Skills.Medical, 4}
		});
		/* No statics */
		curCard.setConditionalGains(
			new Dictionary<Gains, int>{ //Set 1 of conditionals
				{Gains.Remove_Party_All_Physical_Damage, VALUE_NOT_NEEDED}, //1.1
				{Gains.Remove_Party_All_Infected_Damage, VALUE_NOT_NEEDED}}, //1.2
			new Dictionary<Gains, int>{ //Set 2 of conditionals
				{Gains.Medical_Skill_Check_Automatic_Pass, VALUE_NOT_NEEDED}} //2.1
		);
		curCard.setWhenUsable(
			new List<Times>(){ //Set 1
				Times.Anytime}, //1.1
			new List<Times>(){ //Set 2
				Times.After_Medical_Skill_Check_Failure} //2.1
		);
		curCard.setNumberOfUses(
			Uses.Once,
			Uses.Once
		);
		curCard.setDiscard(
			true,
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Crate of Medical Supplies");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical, SpoilsTypes.Stowable);
		curCard.setCarryWeight(7);
		curCard.setSellValue(10);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 2},
			{Skills.Medical, 5}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Remove_Party_All_Physical_Damage, VALUE_NOT_NEEDED},
			{Gains.Remove_Party_All_Infected_Damage, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.Anytime
		});
		curCard.setNumberOfUses(
			Uses.Once
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Extra Rusty Cleaver");
		curCard.setTypes(SpoilsTypes.Melee_Weapon);
		curCard.setCarryWeight(1);
		curCard.setSellValue(3);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Deals_Infected_Damage, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Damage_Opponent_Character_By_Crown_Infected, 1}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.After_PvP_Round
		});
		curCard.setNumberOfUses(
			Uses.Once_Per_PvP_Round
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Wrist Rocker Slingshot");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon);
		curCard.setCarryWeight(1);
		curCard.setSellValue(2);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Top o' the Line Stun Gun");
		curCard.setTypes(SpoilsTypes.Melee_Weapon);
		curCard.setCarryWeight(1);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Technical, 1},
			{Skills.Medical, 1}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Roll_D6, 1}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.After_Successful_Mission_Or_Encounter
		});
		curCard.setNumberOfUses(
			Uses.Once_Per_Successful_Encounter_Or_Mission
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		tempCard = new SpoilsCard("Top o' the Line Stun Gun"); //When a 1 is rolled
		tempCard.setTitleSubString("Bonus Roll - 1");
		tempCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Spoils_Cards, 1}
		});
		tempCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		tempCard.setNumberOfUses(
			Uses.Once
		);
		tempCard.setDiscard(
			true
		);
		tempCard.setWhenTempEnd(
			Times.Never
		);
		curCard.addD6Option(tempCard);
		curCard.addD6Option(null);
		curCard.addD6Option(null);
		curCard.addD6Option(null);
		curCard.addD6Option(null);
		curCard.addD6Option(null);
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Sniper Scope Kit");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Permenant);
		curCard.setCarryWeight(0);
		curCard.setSellValue(10);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, VALUE_NOT_NEEDED}
		});
		/* No conditionals */
		curCard.setRestrictions(
			new List<Restrictions>(){ //Set 1
				Restrictions.Equip_To_Assault_Rifle //1.1
			},
			new List<Restrictions>(){ //Set 2
				Restrictions.Equip_To_Rifle //2.1
			}
		);
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Snub Nose .357 Revolver");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
		curCard.setCarryWeight(2);
		curCard.setSellValue(7);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Sawed Off Double Barreled");
		curCard.setTitleSubString("12 Gauge Breech Loading Shotgun");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Melee_Weapon, SpoilsTypes.Shotgun);
		curCard.setCarryWeight(3);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Cannot_Be_Stolen, VALUE_NOT_NEEDED},
			{Gains.Goes_To_Auction_House_Upon_Death, VALUE_NOT_NEEDED}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Indestructible Tennis Racquet");
		curCard.setTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Sporting_Goods);
		curCard.setCarryWeight(1);
		curCard.setSellValue(1);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Diplomacy, 1}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_PVP_Combat_Successes, 2}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.During_PvP, //1.1
			Times.When_Opposing_Party_Grenades_Equipped //1.2
		});
		curCard.setNumberOfUses(
			Uses.Once_Per_PvP_Round
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Armored Humvee");
		curCard.setTitleSubString("With .50 Caliber MG Turret");
		curCard.setTypes(SpoilsTypes.Vehicle);
		curCard.setCarryWeight(12);
		curCard.setSellValue(29);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 9},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 2},
			{Skills.Mechanical, 1},
			{Skills.Medical, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2},
			{Gains.All_Hex_Movement_Cost, 1}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("The Motherload");
		curCard.setTitleSubString("You have discovered a secret room!");
		curCard.setTypes(SpoilsTypes.Event);
		curCard.setCarryWeight(0);
		curCard.setSellValue(0);
		/* No base skills */
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Spoils_Cards, 5}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Immediately
		});
		curCard.setNumberOfUses(
			Uses.Once
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Retro Mini Camper");
		curCard.setTypes(SpoilsTypes.Vehicle_Equipment);
		curCard.setCarryWeight(0);
		curCard.setSellValue(12);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 3},
			{Skills.Mechanical, 3},
			{Skills.Medical, 3}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Lose_Movement, 1},
			{Gains.Gain_Carry_Weight, 8}
		});
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			{Restrictions.Equip_To_Vehicle},
			{Restrictions.Four_Wheels_Or_More}
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Chris the Trophy Spouse");
		curCard.setTypes(SpoilsTypes.Ally);
		curCard.setCarryWeight(0);
		curCard.setSellValue(0);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 3},
			{Skills.Medical, 3}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Carry_Weight, 4},
			{Gains.Gain_Prestige, 1},
			{Gains.Gain_Psych_Resistence, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Pay_Salvage, 4}
		});
		curCard.setWhenUsable(new List<Times>{
			{Times.Immediately}
		});
		curCard.setNumberOfUses(
			Uses.Once
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Alien Plasma Pistol");
		curCard.setTypes(SpoilsTypes.Top_Secret, SpoilsTypes.Ranged_Weapon, SpoilsTypes.Relic);
		curCard.setCarryWeight(1);
		curCard.setSellValue(19);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Diplomacy, 2},
			{Skills.Technical, 3}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 1},
			{Gains.Deals_Radiation_Damage, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Damage_Opponent_Character_By_Crown_Radiation, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_PvP_Round
		});
		curCard.setNumberOfUses(
			Uses.Once_Per_PvP_Round
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Sledge Hammer");
		curCard.setTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Blunt);
		curCard.setCarryWeight(4);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Mechanical, 2}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Mechanical_Skill_Check_Automatic_Pass, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_Lock_Picking_Encounters
		});
		curCard.setNumberOfUses(
			Uses.Once
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Combat Welding & Cutting Torch");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical);
		curCard.setCarryWeight(4);
		curCard.setSellValue(12);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Mechanical, 2},
			{Skills.Technical, 1}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Roll_D6, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Combat_Skill_Check_Success
		});
		curCard.setNumberOfUses(
			Uses.Once
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		tempCard = new SpoilsCard("Compact Welding & Cutting Torch"); //When a 1 or 2 is rolled
		tempCard.setTitleSubString("Roll Bonus - 1/2");
		tempCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Spoils_Cards, 4}
		});
		tempCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		tempCard.setNumberOfUses(
			Uses.Once
		);
		tempCard.setDiscard(
			true
		);
		tempCard.setWhenTempEnd(
			Times.Never
		);
		curCard.addD6Option(tempCard); //1
		curCard.addD6Option(tempCard); //2
		curCard.addD6Option(null);
		curCard.addD6Option(null);
		curCard.addD6Option(null);
		curCard.addD6Option(null);
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Designer Biker Leathers");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor, SpoilsTypes.Clothing);
		curCard.setCarryWeight(1);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 1}
		});
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Not_Used_With_Other_Armor
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Dork Squad");
		curCard.setTitleSubString("Computer Repair Car");
		curCard.setTypes(SpoilsTypes.Vehicle);
		curCard.setCarryWeight(10);
		curCard.setSellValue(17);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 3},
			{Skills.Technical, 5},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Reroll_Technical_Skill_Check, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>{
			{Times.After_Technical_Skill_Check_Failure},
			{Times.During_Mission_Or_Encounter}
		});
		curCard.setNumberOfUses(
			Uses.Once_Per_Turn
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Heavy Rocket Launcher");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Heavy, SpoilsTypes.Relic);
		curCard.setCarryWeight(8);
		curCard.setSellValue(21);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 10}
		});
		/* No static gains */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Destroy_Oppenent_Vehicle, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Before_PvP
		});
		curCard.setNumberOfUses(
			Uses.Once_Per_Game
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Case of Excellent Whiskey");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Alcohol, SpoilsTypes.Stowable);
		curCard.setCarryWeight(3);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Diplomacy, 3},
			{Skills.Medical, 1}
		});
		/* No statics */
		/* No actives */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Experimental Laser Rifle");
		curCard.setTitleSubString("Top Secret Weapon");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Top_Secret, SpoilsTypes.Heavy);
		curCard.setCarryWeight(7);
		curCard.setSellValue(24);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 8},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 2},
			{Skills.Mechanical, 1},
			{Skills.Technical, 2},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 1}
		});
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Not_Used_With_Backback
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("9mm Semi Automatic Pistol");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
		curCard.setCarryWeight(2);
		curCard.setSellValue(5);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("7.62mm Assault Rifle");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
		curCard.setCarryWeight(5);
		curCard.setSellValue(14);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 7}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Masamune Crafted Katana");
		curCard.setQuote("A 14th century masterpiece created by Japan's greatest sword maker.");
		curCard.setTypes(SpoilsTypes.Relic, SpoilsTypes.Melee_Weapon, SpoilsTypes.Sword);
		curCard.setCarryWeight(2);
		curCard.setSellValue(16);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, VALUE_NOT_NEEDED},
			{Gains.Gain_Psych_Resistence, 1}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		//todo asdf
	}
}
