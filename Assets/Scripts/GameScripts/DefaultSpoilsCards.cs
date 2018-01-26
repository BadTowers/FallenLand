using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSpoilsCards : MonoBehaviour{

	public List<SpoilsCard> spoilsCards;


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
		/* No passives */
		curCard.setActiveGains( //Set the active abilities the card can do
			new Dictionary<Gains, int>{ //Set 1 of actives
				{Gains.Gain_Spoils_Cards, 2}}, //1.1
			new Dictionary<Gains, int>{ //Set 2 of actives
				{Gains.Gain_Action_Cards, 2}} //2.1
		);
		curCard.setWhenUsable( //Set when the actives are useable
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1}, //Passive 1
			{Gains.All_Hex_Movement_Cost, 1} //Passive 2
		});
		/* No actives */
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2},
			{Gains.Gain_Carry_Weight, 4},
			{Gains.Prevent_Distruction, VALUE_NOT_NEEDED},
			{Gains.Prevent_Theft, VALUE_NOT_NEEDED}
		});
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
			{Skills.Techinical, 5}
		});
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.Lose_Movement, 1}
		});
		/* No actives */
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			//No passives
		});
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2},
			{Gains.All_Hex_Movement_Cost, 1}
		});
		/* No actives */
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
		/* No passives */
		/* No actives */
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, VALUE_NOT_NEEDED}
		});
		/* No actives */
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.Gain_Armor, 1}
		});
		/* No actives */
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 1}
		});
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			//No passives
		});
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
		/* No passives */
		/* No actives */
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
		/* No passives */
		/* No actives */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Computer Technical Manual");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Book);
		curCard.setCarryWeight(0);
		curCard.setSellValue(8);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Mechanical, 2},
			{Skills.Techinical, 4}
		});
		/* No passives */
		curCard.setActiveGains(new Dictionary<Gains, int>{
			{Gains.Techinical_Skill_Check_Pass, VALUE_NOT_NEEDED}
		});
		curCard.setWhenUsable(new List<Times>(){
			Times.After_Techinical_Skill_Check_Failure
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
			{Skills.Techinical, 1}
		});
		/* No passives */
		/* No actives */
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
		/* No passives */
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
			{Skills.Techinical, 2},
			{Skills.Medical, 2}
		});
		/* No passives */
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
		tempCard = new SpoilsCard("Option 1"); //When a 1 is rolled
		tempCard.setActiveGains(new Dictionary<Gains, int>{
			{Gains.Reroll_Any_Critical_Fail, VALUE_NOT_NEEDED}
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
		tempCard = new SpoilsCard("Option 2"); //When a 2 is rolled
		tempCard.setActiveGains(new Dictionary<Gains, int>{
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
		tempCard = new SpoilsCard("Option 3"); //When a 3 is rolled
		tempCard.setActiveGains(new Dictionary<Gains, int>{
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
		tempCard = new SpoilsCard("Option 4"); //When a 4 is rolled
		tempCard.setActiveGains(new Dictionary<Gains, int>{
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
		tempCard = new SpoilsCard("Option 5"); //When a 5 is rolled
		tempCard.setActiveGains(new Dictionary<Gains, int>{
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
		//Roll 6 = no effect
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Biomedical Kit");
		curCard.setTypes(SpoilsTypes.Equipment, SpoilsTypes.Medical);
		curCard.setCarryWeight(3);
		curCard.setSellValue(15);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 1},
			{Skills.Techinical, 4},
			{Skills.Medical, 4}
		});
		/* No passives */
		curCard.setActiveGains(
			new Dictionary<Gains, int>{ //Set 1 of actives
				{Gains.Remove_Party_All_Physical_Damage, VALUE_NOT_NEEDED}, //1.1
				{Gains.Remove_Party_All_Infected_Damage, VALUE_NOT_NEEDED}}, //1.2
			new Dictionary<Gains, int>{ //Set 2 of actives
				{Gains.Medical_Skill_Check_Pass, VALUE_NOT_NEEDED}} //2.1
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
		/* No passives */
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.Deals_Infected_Damage, 1}
		});
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
		/* No passives */
		/* No actives */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("Top o' the Line Stun Gun");
		curCard.setTypes(SpoilsTypes.Melee_Weapon);
		curCard.setCarryWeight(1);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 1},
			{Skills.Techinical, 1},
			{Skills.Medical, 1}
		});
		/* No passives */
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
		tempCard = new SpoilsCard("Option 1"); //When a 1 is rolled
		tempCard.setActiveGains(new Dictionary<Gains, int>{
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
		//Rolling a 2-6 has no effect
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, VALUE_NOT_NEEDED}
		});
		/* No actives */
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
		/* No passives */
		/* No actives */
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.Cannot_Be_Stolen, VALUE_NOT_NEEDED},
			{Gains.Goes_To_Auction_House_Upon_Death, VALUE_NOT_NEEDED}
		});
		/* No actives */
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
		/* No passives */
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.Gain_Movement, 2},
			{Gains.All_Hex_Movement_Cost, 1}
		});
		/* No actives */
		/* No restrictions */
		spoilsCards.Add(curCard);


		/****************************************************************************************************************************************************************/
		curCard = new SpoilsCard("The Motherload");
		curCard.setTitleSubString("You have discovered a secret room!");
		curCard.setTypes(SpoilsTypes.Event);
		curCard.setCarryWeight(0);
		curCard.setSellValue(0);
		/* No base skills */
		/* No passives */
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.Lose_Movement, 1},
			{Gains.Gain_Carry_Weight, 8}
		});
		/* No actives */
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
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.Gain_Carry_Weight, 4},
			{Gains.Gain_Prestige, 1},
			{Gains.Gain_Psych_Resistence, 1}
		});
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
			{Skills.Techinical, 3}
		});
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.Gain_Prestige, 1},
			{Gains.Deals_Radiation_Damage, 1}
		});
		curCard.setActiveGains(new Dictionary<Gains, int>{
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
		/* No passives */
		curCard.setActiveGains(new Dictionary<Gains, int>{
			{Gains.Mechanical_Skill_Check_Pass}
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



	}
}
