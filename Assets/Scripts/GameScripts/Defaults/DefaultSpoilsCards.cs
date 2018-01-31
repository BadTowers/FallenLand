using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSpoilsCards{

	private Dictionary<string, int> multiples = new Dictionary<string, int>(){ //The names of the cards that, by default, are in the deck more than once
		{"Basic Med Kit", 2},
		{"Swat Body Armor", 2},
		{"First Aid Kit", 2}
	};

	private List<SpoilsCard> spoilsCards; //The list of all default spoils cards

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


	//Called before Start()
	public DefaultSpoilsCards(){
		//Initialize the lists for the cards
		spoilsCards = new List<SpoilsCard>();

		const int VALUE_NOT_NEEDED = -1;

		//Add the cards to the list
		SpoilsCard curCard;
		SpoilsCard tempCard;

		Debug.Log("Instantiating spoils cards...");


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
			Uses.Unlimited, //Set 1
			Uses.Unlimited //Set 2
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
			{Gains.Prevent_Destruction, VALUE_NOT_NEEDED},
			{Gains.Prevent_Theft, VALUE_NOT_NEEDED}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Pay_Salvage, 5}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(new List<Restrictions>(){ //Set 1 of restrictions
			Restrictions.Equip_To_Vehicle, //1.1
			Restrictions.Discard_If_Not_Purchased //1.2
		});
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
			Restrictions.Not_Used_With_Other_Clothing, //1.2
			Restrictions.Equip_As_First_Item //1.3
		});
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
			Uses.Unlimited
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
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Cant_Be_Drawn_During_Setup
		});
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
			{Gains.Technical_Skill_Checks_Automatic_Pass, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.After_Technical_Skill_Check_Failure
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
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
			{Gains.Remove_Character_Damage_All, VALUE_NOT_NEEDED}
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
			{Gains.Heal_D6_Damage_Physical, 2}
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
				{Gains.Remove_Party_Physical_Damage_All, VALUE_NOT_NEEDED}, //1.1
				{Gains.Remove_Party_Infected_Damage_All, VALUE_NOT_NEEDED}}, //1.2
			new Dictionary<Gains, int>{ //Set 2 of conditionals
				{Gains.Medical_Skill_Checks_Automatic_Pass, VALUE_NOT_NEEDED}} //2.1
		);
		curCard.setWhenUsable(
			new List<Times>(){ //Set 1
				Times.Anytime}, //1.1
			new List<Times>(){ //Set 2
				Times.After_Medical_Skill_Check_Failure} //2.1
		);
		curCard.setNumberOfUses(
			Uses.Unlimited,
			Uses.Unlimited
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
			{Gains.Remove_Party_Physical_Damage_All, VALUE_NOT_NEEDED},
			{Gains.Remove_Party_Infected_Damage_All, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.Anytime
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
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
			Uses.Unlimited
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
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
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
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Cant_Be_Drawn_During_Setup
		});
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
			Restrictions.Equip_To_Vehicle,
			Restrictions.Four_Wheels_Or_More
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
			Times.Immediately
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Discard_If_Not_Purchased
		});
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
			{Gains.Mechanical_Skill_Checks_Automatic_Pass, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_Lock_Picking_Encounters
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
			Uses.Unlimited
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
			Uses.Unlimited
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
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing,
			Restrictions.Equip_As_First_Item
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Dork Squad");
		curCard.setTitleSubString("Computer Repair Car");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
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
			{Times.During_Encounter_Or_Mission}
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


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Basic Med Kit");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
		curCard.setCarryWeight(2);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Medical, 3}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Remove_Party_Physical_Damage, 3}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Anytime
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Special Forces Manual");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
		curCard.setCarryWeight(0);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 3},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Psych_Resistence, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Combat_Skill_Checks_Automatic_Pass, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Combat_Skill_Check_Failure, //1.1
			Times.During_Encounter_Or_Mission //1.2
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Unlimited Stash of Duct Tape");
		curCard.setTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Mechanical);
		curCard.setCarryWeight(2);
		curCard.setSellValue(4);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 3},
			{Skills.Technical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Ignore_Break_Relic_Action_Cards, VALUE_NOT_NEEDED},
			{Gains.Ignore_Broken_Action_Cards, VALUE_NOT_NEEDED}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Roll_D6, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_End_Turn_Phase
		});
		curCard.setNumberOfUses(
			Uses.Once_Per_Turn
		);
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_All_Party_Members_Or_None
		});
		tempCard = new SpoilsCard("Unlimited Stash of Duct Tape");
		tempCard.setTitleSubString("Roll 1/2");
		tempCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Take_Spoils_Cards_From_Top_Discard_Pile, 1}
		});
		tempCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		tempCard.setNumberOfUses(
			Uses.Unlimited
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
		curCard = new SpoilsCard("Practically New Ambulance");
		curCard.setTitleSubString("With Obnoxiously Loud Sirens");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Relic, SpoilsTypes.Four_Wheeled);
		curCard.setCarryWeight(14);
		curCard.setSellValue(29);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 2},
			{Skills.Technical, 2},
			{Skills.Medical, 9}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 3}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Heal_D6_Damage_Physical_Or_Infected, 2}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_End_Turn_Phase
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
		curCard = new SpoilsCard("Five Machetes");
		curCard.setTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Melee_Weapon, SpoilsTypes.Sword);
		curCard.setCarryWeight(2);
		curCard.setSellValue(14);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 1}
		});
		/* No statics */
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_All_Party_Members_Or_None
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Bars of Gold");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Stowable);
		curCard.setCarryWeight(10);
		curCard.setSellValue(25);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 4}
		});
		/* No statics */
		curCard.setConditionalGains(
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
		curCard.setWhenUsable(
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
		curCard.setNumberOfUses(
			Uses.Unlimited,
			Uses.Unlimited,
			Uses.Unlimited
		);
		curCard.setDiscard(
			true,
			true,
			true
		);
		/* No restrictions */
		curCard.setDiscardToTop(false); //This card gets discarded to the bottom of the pile
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Fred Rodgers' Sweater");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor, SpoilsTypes.Clothing, SpoilsTypes.Relic);
		curCard.setCarryWeight(2);
		curCard.setSellValue(16);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 2},
			{Skills.Technical, 1},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Steal_Opponent_Town_Tech, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Within_1_Hex_Of_Enemy_Town
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
		curCard = new SpoilsCard("Water Purification Canteens");
		curCard.setTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Medical, SpoilsTypes.Camping_Gear);
		curCard.setCarryWeight(1);
		curCard.setSellValue(5);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 1},
			{Skills.Medical, 2}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Skill_Checks_Automatic_Pass, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Drawing_Perishable_Encounter
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_All_Party_Members_Or_None
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Grenades");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Heavy);
		curCard.setCarryWeight(7);
		curCard.setSellValue(16);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 9}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Combat_Skill_Checks_Automatic_Pass, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_Encounter_Or_Mission
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Police Interceptor");
		curCard.setTitleSubString("With Hypnotic Lights");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
		curCard.setCarryWeight(10);
		curCard.setSellValue(19);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Diplomacy, 4},
			{Skills.Medical, 3}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 3}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Take_Characters_From_Opponent_Town_Roster_Into_Players_TR, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Within_1_Hex_Of_Enemy_Town
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
		curCard = new SpoilsCard("Finders Keepers");
		curCard.setQuote("You have found the item of your dreams...");
		curCard.setTypes(SpoilsTypes.Event);
		curCard.setCarryWeight(0);
		curCard.setSellValue(0);
		curCard.setBaseSkills(new Dictionary<Skills, int>{

		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Any_Nonevent_Spoils_Cards_From_Deck_Or_Discard, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Immediately
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Cant_Be_Drawn_During_Setup
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Swat Body Armor");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor, SpoilsTypes.Clothing);
		curCard.setCarryWeight(2);
		curCard.setSellValue(14);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Diplomacy, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 1}
		});
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Equip_As_First_Item, 
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("9mm Pistol");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
		curCard.setCarryWeight(2);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Paramedic Medical Kit");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
		curCard.setCarryWeight(1);
		curCard.setSellValue(10);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 2},
			{Skills.Medical, 5}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Remove_Party_Physical_Damage, 5}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Anytime
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("First Aid Kit");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
		curCard.setCarryWeight(1);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 1},
			{Skills.Medical, 2}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Remove_Party_Physical_Damage, 2}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Anytime
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Classic All American");
		curCard.setTitleSubString("Performance Muscle Car");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
		curCard.setCarryWeight(10);
		curCard.setSellValue(19);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Diplomacy, 3},
			{Skills.Mechanical, 2},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 4}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Character_Cards, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Character_Card_Received_As_Reward
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
		curCard = new SpoilsCard("Macho Tow Truck");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Six_Wheeled);
		curCard.setCarryWeight(13);
		curCard.setSellValue(19);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Diplomacy, 3},
			{Skills.Mechanical, 5},
			{Skills.Technical, 3}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Roll_D10, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_End_Turn_Phase
		});
		curCard.setNumberOfUses(
			Uses.Once_Per_Turn
		);
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(new List<Restrictions>(){

		});
		tempCard = new SpoilsCard("Macho Towing Truck"); //When a 1 is rolled
		tempCard.setTitleSubString("Bonus Roll - 1-3");
		tempCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Any_Vehicle_Spoils_Cards_From_Discard, 1}
		});
		tempCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		tempCard.setNumberOfUses(
			Uses.Unlimited
		);
		tempCard.setDiscard(
			true
		);
		tempCard.setWhenTempEnd(
			Times.After_Party_Exploits_Phase
		);
		curCard.addD6Option(tempCard); //1
		curCard.addD6Option(tempCard); //2
		curCard.addD6Option(tempCard); //3
		curCard.addD6Option(null); //4
		curCard.addD6Option(null);
		curCard.addD6Option(null); //6
		curCard.addD6Option(null);
		curCard.addD6Option(null); //8
		curCard.addD6Option(null);
		curCard.addD6Option(null); //10
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Five Classic .45 Pistols");
		curCard.setTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
		curCard.setCarryWeight(2);
		curCard.setSellValue(30);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3}
		});
		/* No statics */
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_All_Party_Members_Or_None
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Contact Truck");
		curCard.setTitleSubString("With Matching Yellow Hardhats");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
		curCard.setCarryWeight(12);
		curCard.setSellValue(18);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 2},
			{Skills.Mechanical, 4},
			{Skills.Technical, 4},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Keep_All_Stowables, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Vehicle_Destroyed
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Jackpot");
		curCard.setTypes(SpoilsTypes.Event);
		curCard.setQuote("You have stumbled upon a concealed compartment!");
		curCard.setCarryWeight(0);
		curCard.setSellValue(0);
		curCard.setBaseSkills(new Dictionary<Skills, int>{

		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Spoils_Cards, 4}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Immediately
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Cant_Be_Drawn_During_Setup
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Heavy Armor Plating");
		curCard.setTypes(SpoilsTypes.Vehicle_Equipment, SpoilsTypes.Permenant);
		curCard.setCarryWeight(4);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Lose_Movement, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Prevent_Destruction, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Vehicle_Destroyed
		});
		curCard.setNumberOfUses(
			Uses.Once_Per_Game
		);
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_Vehicle,
			Restrictions.Four_Wheels_Or_More
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("5 Matching Pink Mopeds");
		curCard.setQuote("At least the thieves had a sense of humor...");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Jinxed, SpoilsTypes.Two_Wheeled);
		curCard.setCarryWeight(10);
		curCard.setSellValue(0);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 1},
			{Skills.Technical, 1},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Discard_Equipped_Vehicle, VALUE_NOT_NEEDED},
			{Gains.Lose_All_Stowables, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Immediately
		});
		curCard.setNumberOfUses(
			Uses.Once_Per_Game
		);
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Cannot_Be_Sold
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Badass Socket Set");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical, SpoilsTypes.Stowable);
		curCard.setCarryWeight(2);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 3},
			{Skills.Technical, 2}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Salvage, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Successful_Mission_Or_Encounter
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
		curCard = new SpoilsCard("Jugs O'Moonshine");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Alcohol, SpoilsTypes.Stowable);
		curCard.setCarryWeight(3);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 2}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Diplomacy_Skill_Checks_Automatic_Pass, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Diplomacy_Skill_Check_Failure
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Militia Rifle");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
		curCard.setCarryWeight(5);
		curCard.setSellValue(12);
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("High Tech Utility Belt");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Backpack);
		curCard.setCarryWeight(0);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 2},
			{Skills.Mechanical, 2},
			{Skills.Technical, 2},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Carry_Weight, 2}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("5.56mm Assault Rifle");
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
		curCard = new SpoilsCard("Patton");
		curCard.setTypes(SpoilsTypes.Ally);
		curCard.setCarryWeight(0);
		curCard.setSellValue(0);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Prevent_Theft, VALUE_NOT_NEEDED},
			{Gains.Gain_Carry_Weight, 2},
			{Gains.Gain_Psych_Resistence, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Prevent_Any_Character_Death, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Any_Party_Member_Death
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Cannot_Be_Sold
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Compound Hunting Bow");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Bow);
		curCard.setCarryWeight(4);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 2}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Classic .45 Pistol");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
		curCard.setCarryWeight(2);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("William H Bonnie's");
		curCard.setTitleSubString("Matching .45 Revolvers");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun, SpoilsTypes.Relic);
		curCard.setCarryWeight(4);
		curCard.setSellValue(20);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 7},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Psych_Resistence, 1}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Cheap Mountain Bikes");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Two_Wheeled);
		curCard.setCarryWeight(10);
		curCard.setSellValue(7);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 1},
			{Skills.Medical, 1}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Ram Plate");
		curCard.setTypes(SpoilsTypes.Vehicle_Equipment, SpoilsTypes.Permenant);
		curCard.setCarryWeight(2);
		curCard.setSellValue(5);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Lose_Movement, 1},
			{Gains.Auto_Succeed_Ambush_Encounters, VALUE_NOT_NEEDED}
		});
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_Vehicle,
			Restrictions.Four_Wheels_Or_More
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Espresso Van");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
		curCard.setCarryWeight(10);
		curCard.setSellValue(23);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 4},
			{Skills.Mechanical, 1},
			{Skills.Technical, 1},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 4}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Salvage, 4}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_End_Turn_Phase
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
		curCard = new SpoilsCard("Experimental Battle Suit");
		curCard.setTitleSubString("Top Secret Weapon");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor, SpoilsTypes.Relic);
		curCard.setCarryWeight(2);
		curCard.setSellValue(23);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 1},
			{Skills.Technical, 2},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 1},
			{Gains.Infected_Damage_Treated_As_Physical, VALUE_NOT_NEEDED},
			{Gains.Radiation_Damage_Treated_As_Physical, VALUE_NOT_NEEDED},
			{Gains.Gain_Armor, 2}
		});
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard(".45 Semi Automatic Pistol");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
		curCard.setCarryWeight(1);
		curCard.setSellValue(7);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Expired Pre-War Library Card");
		curCard.setTypes(SpoilsTypes.Equipment);
		curCard.setCarryWeight(0);
		curCard.setSellValue(4);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 2},
			{Skills.Mechanical, 2},
			{Skills.Technical, 2},
			{Skills.Medical, 2}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Take_Spoils_Cards_From_Top_Discard_Pile, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Opponent_Discarded_Book_Spoils
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
		curCard = new SpoilsCard("The President's Football");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Technical, SpoilsTypes.Relic);
		curCard.setCarryWeight(4);
		curCard.setSellValue(20);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 1},
			{Skills.Diplomacy, 3},
			{Skills.Mechanical, 2},
			{Skills.Technical, 4},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 1},
			{Gains.Auto_Succeed_Sigma_Bunker_Missions, VALUE_NOT_NEEDED}
		});
		/* No conditionals */
		/* No restrctions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Titanium Softball Bat");
		curCard.setTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Blunt, SpoilsTypes.Sporting_Goods);
		curCard.setCarryWeight(2);
		curCard.setSellValue(3);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
		/* No statics */
		/* No conditionals */
		/* No restrctions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard(".50 Caliber Sniper Rifle");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Heavy, SpoilsTypes.Relic);
		curCard.setCarryWeight(6);
		curCard.setSellValue(22);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 8},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 1}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Select_Character_From_Opposing_Party, 1},
			{Gains.Roll_D6, 1}
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
		tempCard = new SpoilsCard(".50 Caliber Sniper Rifle");
		tempCard.setTitleSubString("Roll - 1-4");
		tempCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Kill_Selected_Character_From_Opposing_Party, 1},
			{Gains.Discard_Selected_Opposing_Character_Equipment, VALUE_NOT_NEEDED}
		});
		tempCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		tempCard.setNumberOfUses(
			Uses.Once_Per_Game
		);
		tempCard.setDiscard(
			true
		);
		tempCard.setWhenTempEnd(
			Times.After_Party_Exploits_Phase
		);
		curCard.addD6Option(tempCard); //1
		curCard.addD6Option(tempCard);
		curCard.addD6Option(tempCard);
		curCard.addD6Option(tempCard); //4
		curCard.addD6Option(null); //5
		curCard.addD6Option(null); //6
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Soldering Kit");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Technical, SpoilsTypes.Stowable);
		curCard.setCarryWeight(2);
		curCard.setSellValue(5);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 2},
			{Skills.Technical, 3}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Lock Pick Guide and Tools");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
		curCard.setCarryWeight(0);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 2},
			{Skills.Technical, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Auto_Succeed_Lock_Picking_Encounters, VALUE_NOT_NEEDED}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Salvage, 2}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_End_Turn_Phase
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
		curCard = new SpoilsCard("Lead Filled Kempo Gloves");
		curCard.setTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Fist);
		curCard.setCarryWeight(0);
		curCard.setSellValue(4);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Combat_Skill_Check_Successes, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_Gladiatorial_Events_Encounters
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
		curCard = new SpoilsCard("Scary Hockey Mask");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Relic);
		curCard.setCarryWeight(0);
		curCard.setSellValue(4);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Health, 1}
		});
		curCard.setConditionalGains(
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
		curCard.setWhenUsable(
			new List<Times>{ //Set 1
				Times.Equipped_With_An_Axe, //1.1
				Times.During_Encounter_Mission_Or_PvP, //1.2
			},
			new List<Times>{ //Set 2
				Times.Equipped_With_Industrial_Chainsaw, //2.1
				Times.During_Encounter_Mission_Or_PvP,
			},
			new List<Times>{ //Set 3
				Times.Equipped_With_Rusty_Cleaver, //3.1
				Times.During_Encounter_Mission_Or_PvP,
			}
		);
		curCard.setNumberOfUses(
			Uses.Unlimited,
			Uses.Unlimited,
			Uses.Unlimited
		);
		curCard.setDiscard(
			false,
			false,
			false
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Firefighter's Axe");
		curCard.setTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Axe);
		curCard.setCarryWeight(3);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Mechanical_Skill_Checks_Automatic_Pass, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_Lock_Picking_Encounters
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
		curCard = new SpoilsCard("6.8mm Advanced Rifle");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
		curCard.setCarryWeight(5);
		curCard.setSellValue(15);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 7},
			{Skills.Survival, 1}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Elite Camping Backpack");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Backpack, SpoilsTypes.Camping_Gear);
		curCard.setCarryWeight(0);
		curCard.setSellValue(10);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 2},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Carry_Weight, 5}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Flare Gun Pistol");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
		curCard.setCarryWeight(1);
		curCard.setSellValue(4);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 2}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Ignore_Negatives_Of_Encounter_Or_Mission_Failure, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Failed_Mission_Or_Encounter
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Vendetta Daggers");
		curCard.setTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Knife, SpoilsTypes.Relic);
		curCard.setCarryWeight(2);
		curCard.setSellValue(13);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 4}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Dear Old Ma's Repair Kit");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical);
		curCard.setCarryWeight(2);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 1},
			{Skills.Mechanical, 2},
			{Skills.Technical, 2},
			{Skills.Medical, 1}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Ultimate Set of Tools");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical, SpoilsTypes.Stowable);
		curCard.setCarryWeight(8);
		curCard.setSellValue(14);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 5},
			{Skills.Technical, 3}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Any_Spoils_Cards_From_Discard, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Anytime
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
		curCard = new SpoilsCard("A History of World Diplomacy");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
		curCard.setCarryWeight(1);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 4}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Diplomacy_Skill_Checks_Automatic_Pass, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Diplomacy_Skill_Check_Failure
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard(".223 Sniper Rifle");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Rifle);
		curCard.setCarryWeight(4);
		curCard.setSellValue(12);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Survival, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, VALUE_NOT_NEEDED}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Trunk of Unlimited Disguises");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Stowable);
		curCard.setCarryWeight(4);
		curCard.setSellValue(7);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 1}
		});
		/* No statics */
		curCard.setConditionalGains(
			new Dictionary<Gains, int>{ //set 1
				{Gains.Steal_Spoils_From_Opposing_Party_Excluding_Vehicles, 1} //1.1
			},
			new Dictionary<Gains, int>{ //set 2
				{Gains.Steal_Spoils_From_Opposing_Town_Auction_House, 1} //2.1
			}
		);
		curCard.setWhenUsable(
			new List<Times>{ //set 1
				Times.Within_1_Hex_Of_Enemy_Party //1.1
			},
			new List<Times>{ //set 2
				Times.Within_1_Hex_Of_Enemy_Town //2.1
			}
		);
		curCard.setNumberOfUses(
			Uses.Once_Per_Turn
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Fallen Land Board Game");
		curCard.setQuote("A strange pre-war board game about the apocalypse...");
		curCard.setTypes(SpoilsTypes.Stowable);
		curCard.setCarryWeight(2);
		curCard.setSellValue(13);
		curCard.setBaseSkills(new Dictionary<Skills, int>{

		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 2}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Blower or Supercharger");
		curCard.setTypes(SpoilsTypes.Vehicle_Equipment, SpoilsTypes.Permenant);
		curCard.setCarryWeight(0);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1},
			{Gains.Ignore_All_Vehicle_Equipment_Movement_Penalties, VALUE_NOT_NEEDED}
		});
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_Vehicle, 
			Restrictions.Four_Wheels_Or_More
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("The War Wagon");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Relic, SpoilsTypes.Six_Wheeled);
		curCard.setCarryWeight(16);
		curCard.setSellValue(40);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 10},
			{Skills.Survival, 3}, 
			{Skills.Diplomacy, 4},
			{Skills.Mechanical, 3},
			{Skills.Technical, 2},
			{Skills.Medical, 4}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 2},
			{Gains.Gain_Movement, 2}
		});
		curCard.setConditionalGains(
			new Dictionary<Gains, int>{ //Set 1
				{Gains.Gain_Character_Cards, 2} //1.1
			},
			new Dictionary<Gains, int>{ //Set 2
				{Gains.Roll_D6, 1} //2.1
			}
		);
		curCard.setWhenUsable(
			new List<Times>{ //Set 1
				Times.Immediately
			},
			new List<Times>{ //Set 2
				Times.Vehicle_Destroyed
			}
		);
		curCard.setNumberOfUses(
			Uses.Unlimited,
			Uses.Unlimited
		);
		curCard.setDiscard(
			false, false
		);
		/* No restrictions */
		tempCard = new SpoilsCard("The War Wagon");
		tempCard.setTitleSubString("Roll - 1-3");
		tempCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Prevent_Destruction, 1}
		});
		tempCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		tempCard.setNumberOfUses(
			Uses.Unlimited
		);
		tempCard.setDiscard(
			true
		);
		tempCard.setWhenTempEnd(
			Times.Immediately
		);
		curCard.addD6Option(tempCard); //1
		curCard.addD6Option(tempCard);
		curCard.addD6Option(tempCard); //3
		curCard.addD6Option(null); //4
		curCard.addD6Option(null);
		curCard.addD6Option(null); //6
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard(".22 Small Bore Rifle");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Rifle);
		curCard.setCarryWeight(3);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 1}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Lumberjack Axe");
		curCard.setTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Axe);
		curCard.setCarryWeight(4);
		curCard.setSellValue(7);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 2}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Nifty Multi-Tool");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Mechanical, SpoilsTypes.Melee_Weapon);
		curCard.setCarryWeight(1);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Mechanical, 2},
			{Skills.Technical, 1},
			{Skills.Medical, 1}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Vintage .45 Submachine Gun");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
		curCard.setCarryWeight(5);
		curCard.setSellValue(13);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Brass Knuckles");
		curCard.setTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Fist);
		curCard.setCarryWeight(0);
		curCard.setSellValue(3);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Combat_Skill_Check_Successes, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_Gladiatorial_Events_Encounters
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
		curCard = new SpoilsCard("Luxurious Designer Suit");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Clothing);
		curCard.setCarryWeight(1);
		curCard.setSellValue(10);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 5}
		});
		/* No statics */
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing,
			Restrictions.Equip_As_First_Item
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Heavy Duty Flashlight");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Blunt, SpoilsTypes.Melee_Weapon);
		curCard.setCarryWeight(1);
		curCard.setSellValue(12);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 2},
			{Skills.Mechanical, 2},
			{Skills.Technical, 1}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Combat Medic Satchel");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
		curCard.setCarryWeight(4);
		curCard.setSellValue(12);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 2},
			{Skills.Medical, 7}
		});
		/* No statics */
		curCard.setConditionalGains(
			new Dictionary<Gains, int>{ //Set 1
				{Gains.Remove_Party_Physical_Damage, 4} //1.1
			},
			new Dictionary<Gains, int>{ //Set 2
				{Gains.Prevent_Any_Character_Death, 1} //2.1
			}
		);
		curCard.setWhenUsable(
			new List<Times>{ //Set 1
				Times.Anytime //1.1
			},
			new List<Times>{ //Set 2
				Times.Any_Party_Member_Death //2.1
			}
		);
		curCard.setNumberOfUses(
			Uses.Unlimited,
			Uses.Unlimited
		);
		curCard.setDiscard(
			true,
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Ultimate Laptop");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Technical);
		curCard.setCarryWeight(3);
		curCard.setSellValue(18);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 3},
			{Skills.Technical, 5},
			{Skills.Medical, 3}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("12 Guage Pump Shotgun");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Shotgun);
		curCard.setCarryWeight(4);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Rocket Launcher");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Heavy, SpoilsTypes.Relic);
		curCard.setCarryWeight(7);
		curCard.setSellValue(18);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 9}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Destroy_Oppenent_Vehicle, 1}
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
		curCard = new SpoilsCard("Camping Gear");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Camping_Gear, SpoilsTypes.Stowable);
		curCard.setCarryWeight(4);
		curCard.setSellValue(10);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 3},
			{Skills.Medical, 2}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Ol' Rusty");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
		curCard.setCarryWeight(5);
		curCard.setSellValue(0);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 2},
			{Skills.Technical, 1},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1},
			{Gains.Stacks_With_Other_Vehicles, 1}
		});
		curCard.setConditionalGains(
			new Dictionary<Gains, int>{ //set 1
				{Gains.Gain_Kurtis_Wyatt_Character_Card, VALUE_NOT_NEEDED} //1.1
			},
			new Dictionary<Gains, int>{ //set 2
				{Gains.Choose_Which_Vehicle_To_Discard, VALUE_NOT_NEEDED} //2.1
			}
		);
		curCard.setWhenUsable(
			new List<Times>{ //set 1
				Times.Immediately //1.1
			},
			new List<Times>{ //set 2
				Times.Vehicle_Destroyed //2.1
			}
		);
		curCard.setNumberOfUses(
			Uses.Unlimited, //1.1
			Uses.Unlimited //2.1
		);
		curCard.setDiscard(
			false,
			false
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Chopper and Pilot");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Zero_Wheeled);
		curCard.setCarryWeight(16);
		curCard.setSellValue(0);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 6},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 3},
			{Skills.Mechanical, 3},
			{Skills.Technical, 3},
			{Skills.Medical, 3}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 8},
			{Gains.All_Hex_Movement_Cost, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Pay_Salvage, 10}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Immediately
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Cannot_Be_Sold,
			Restrictions.Discard_If_Not_Purchased
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Industrial Chainsaw");
		curCard.setTypes(SpoilsTypes.Melee_Weapon);
		curCard.setCarryWeight(5);
		curCard.setSellValue(11);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 2},
			{Skills.Mechanical, 1}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Combat_Skill_Check_Successes, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_Rad_Zombie_Encounters
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
		curCard = new SpoilsCard("Gyrocopter");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Relic, SpoilsTypes.Zero_Wheeled); //May not be a zero wheel vehicle?
		curCard.setCarryWeight(2);
		curCard.setSellValue(25);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 1},
			{Skills.Mechanical, 4}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Stacks_With_Other_Vehicles, 1},
			{Gains.Gain_Movement, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Roll_D6, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Each_Movement
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(new List<Restrictions>(){

		});
		tempCard = new SpoilsCard("Gyrocopter");
		tempCard.setTitleSubString("Roll - 1-2");
		tempCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Draw_Encounter_Cards, 2},
			{Gains.Keep_Encounter_Cards, 1}
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
		curCard.addD6Option(tempCard); //1
		curCard.addD6Option(tempCard); //2
		curCard.addD6Option(null);  //3
		curCard.addD6Option(null);
		curCard.addD6Option(null);
		curCard.addD6Option(null); //6
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Nifty Chemistry Set");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Technical, SpoilsTypes.Stowable);
		curCard.setCarryWeight(3);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Technical, 4},
			{Skills.Medical, 3}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Luxury SUV");
		curCard.setTitleSubString("With Spinner Rims and Hydraulics");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
		curCard.setCarryWeight(12);
		curCard.setSellValue(19);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 2},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 1},
			{Skills.Medical, 3}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Steal_D10_Salvage, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.Within_1_Hex_Of_Enemy_Town
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
		curCard = new SpoilsCard("Geiger Counter");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Stowable);
		curCard.setCarryWeight(3);
		curCard.setSellValue(9);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Technical, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Ignore_Radiation_Damage_From_Hexes, VALUE_NOT_NEEDED}
		});
		curCard.setConditionalGains(
			new Dictionary<Gains, int>{ //set 1
				{Gains.Gain_Spoils_Cards, 1} //1.1
			},
			new Dictionary<Gains, int>{ //set 2
				{Gains.Gain_Action_Cards, 1} //2.1
			}
		);
		curCard.setWhenUsable(
			new List<Times>{ //set 1
				Times.Before_Drawing_City_Rad_Encounter_Card //1.1
			},
			new List<Times>{ //set 2
				Times.Before_Drawing_City_Rad_Encounter_Card //2.1
			}
		);
		curCard.setNumberOfUses(
			Uses.Unlimited,
			Uses.Unlimited
		);
		curCard.setDiscard(
			false,
			false
		);
		curCard.setRestrictions(new List<Restrictions>(){

		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Cache of Military Body Armor");
		curCard.setTypes(SpoilsTypes.Party_Equipment, SpoilsTypes.Armor);
		curCard.setCarryWeight(2);
		curCard.setSellValue(25);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Diplomacy, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 1}
		});
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_All_Party_Members_Or_None,
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Enigma Van");
		curCard.setTitleSubString("With Custom 60's Paint Job");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Relic, SpoilsTypes.Four_Wheeled);
		curCard.setCarryWeight(20);
		curCard.setSellValue(24);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 3},
			{Skills.Technical, 3},
			{Skills.Medical, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Reroll_Any_Skill_Check, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Any_Skill_Check_Fail_Mission
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
		curCard = new SpoilsCard("Pro Fishing Gear & Tackle");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Camping_Gear, SpoilsTypes.Stowable);
		curCard.setCarryWeight(2);
		curCard.setSellValue(7);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 3}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Psych_Resistence, 1},
			{Gains.Auto_Succeed_Perishable_Encounters, VALUE_NOT_NEEDED}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("6 Fast Horses");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Horse);
		curCard.setCarryWeight(14);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 3},
			{Skills.Diplomacy, 1},
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
		curCard = new SpoilsCard("Henry's Guide to Repairs");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
		curCard.setCarryWeight(0);
		curCard.setSellValue(10);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 3},
			{Skills.Technical, 2}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Mechanical_Skill_Checks_Automatic_Pass, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Mechanical_Skill_Check_Failure
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Roadkill Cookbook");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
		curCard.setCarryWeight(0);
		curCard.setSellValue(4);curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Survival, 3},
			{Skills.Diplomacy, 1}
		});

		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Survival_Skill_Checks_Automatic_Pass, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Survival_Skill_Check_Failure
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("High Tech Body Armor");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Armor);
		curCard.setCarryWeight(3);
		curCard.setSellValue(15);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Diplomacy, 2}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 2}
		});
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Not_Used_With_Other_Armor, 
			Restrictions.Not_Used_With_Other_Clothing,
			Restrictions.Equip_As_First_Item
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Larry's Guide to Civil War Surgery");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
		curCard.setCarryWeight(0);
		curCard.setSellValue(7);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Medical, 3}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Medical_Skill_Checks_Automatic_Pass, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Medical_Skill_Check_Failure
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Excludes_Healing_Deed
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Flame Thrower");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Melee_Weapon, SpoilsTypes.Heavy_Weapon, SpoilsTypes.Relic);
		curCard.setCarryWeight(7);
		curCard.setSellValue(24);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 10}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Auto_Succeed_Combat_Encounters, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.During_Combat_Encounter_Card
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			true
		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Not_Used_With_Backback,
			Restrictions.Excludes_World_Cards
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("4.6mm Submachine Gun");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
		curCard.setCarryWeight(3);
		curCard.setSellValue(17);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 6}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Radiation and Biohazard Suits");
		curCard.setTypes(SpoilsTypes.Party_Equipment);
		curCard.setCarryWeight(3);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, -1},
			{Skills.Survival, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Lose_Movement, 1},
			{Gains.Ignore_Radiation_Damage, VALUE_NOT_NEEDED},
			{Gains.Infected_Damage_Treated_As_Physical, VALUE_NOT_NEEDED}
		});
		/* No conditionals */
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Equip_To_All_Party_Members_Or_None
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard(".44 Semi Automatic Pistol");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Handgun);
		curCard.setCarryWeight(3);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("High Tech Crossbow");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Bow);
		curCard.setCarryWeight(4);
		curCard.setSellValue(7);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 3},
			{Skills.Survival, 2}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Autographed Bat");
		curCard.setTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Blunt, SpoilsTypes.Sporting_Goods, SpoilsTypes.Relic);
		curCard.setCarryWeight(1);
		curCard.setSellValue(15);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}, 
			{Skills.Diplomacy, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Psych_Resistence, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Spoils_Cards, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Combat_Encounter_Success
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
		curCard = new SpoilsCard("10 Gauge Pump Shotgun");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Shotgun);
		curCard.setCarryWeight(4);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 4},
			{Skills.Survival, 2}
		});
		/* No statics */
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Leather Bull Whip");
		curCard.setTypes(SpoilsTypes.Melee_Weapon, SpoilsTypes.Blunt);
		curCard.setCarryWeight(1);
		curCard.setSellValue(5);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1}
		});
		/* No statics */
		curCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Roll_D6, 1}
		});
		curCard.setWhenUsable(new List<Times>{
			Times.After_Successful_Mission_Or_Encounter
		});
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			false
		);
		/* No restrictions */
		tempCard = new SpoilsCard("Leather Bull Whip");
		tempCard.setTitleSubString("Roll - 1");
		tempCard.setConditionalGains(new Dictionary<Gains, int>{
			{Gains.Gain_Spoils_Cards, 1}
		});
		tempCard.setWhenUsable(new List<Times>(){
			Times.Immediately
		});
		tempCard.setNumberOfUses(
			Uses.Unlimited
		);
		tempCard.setDiscard(
			true
		);
		tempCard.setWhenTempEnd(
			Times.Never
		);
		curCard.addD6Option(tempCard); //1
		curCard.addD6Option(null); //2
		curCard.addD6Option(null);
		curCard.addD6Option(null); //4
		curCard.addD6Option(null);
		curCard.addD6Option(null); //6
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("5.56mm Bolt Action Rifle");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Rifle);
		curCard.setCarryWeight(4);
		curCard.setSellValue(15);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5},
			{Skills.Survival, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, VALUE_NOT_NEEDED}
		});
		/* No conditional */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("12 Gauge Bullpup Shotgun");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Shotgun);
		curCard.setCarryWeight(4);
		curCard.setSellValue(10);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
		/* No statics */
		/* No conditional */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("The Duke's Cowboy Outfit");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Clothing, SpoilsTypes.Relic);
		curCard.setCarryWeight(0);
		curCard.setSellValue(14);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 4},
			{Skills.Diplomacy, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1},
			{Gains.Gain_Psych_Resistence, 1}
		});
		curCard.setConditionalGains(new Dictionary<Gains, int>{

		});
		curCard.setWhenUsable(new List<Times>{

		});
		curCard.setNumberOfUses(

		);
		curCard.setDiscard(

		);
		curCard.setRestrictions(new List<Restrictions>(){
			Restrictions.Equip_As_First_Item,
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing
		});
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("American Iron Custom Choppers");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Two_Wheeled);
		curCard.setCarryWeight(12);
		curCard.setSellValue(13);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 2},
			{Skills.Survival, 1},
			{Skills.Diplomacy, 1},
			{Skills.Mechanical, 3},
			{Skills.Medical, 1}
		});
		curCard.setStaticGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2}
		});
		/* No conditionals */
		/* No restrictions */
		spoilsCards.Add(curCard);






		//Now that all cards are added, let's ID them all and account for duplicates that need to be added
		int count = spoilsCards.Count;
		for(int i = 0; i < count; i++) {
			spoilsCards[i].setID(i); //ID current one

			//See if this card is a duplicate
			if (multiples.ContainsKey(spoilsCards[i].getTitle())) { //If the name of this card is a name in the multiples dictionary
				for(int j = 1; j < multiples[spoilsCards[i].getTitle()]; j++) { //For the number of multiples to add
					SpoilsCard newCard = spoilsCards[i].deepCopy();
					spoilsCards.Add(newCard); //add the multiple
					//Debug.Log("Adding multiple for " + spoilsCards[i].getTitle());
				}
			}
		}
	}


	public List<SpoilsCard> getSpoilsCards(){
		return this.spoilsCards;
	}
}
