using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSpoilsCards : MonoBehaviour{

	public List<SpoilsCard> spoilsCards;


	//Called before Start()
	void Awake(){
		//Initialize the lists for the cards
		spoilsCards = new List<SpoilsCard>();

		//Add the cards to the list
		SpoilsCard curCard;


		curCard = new SpoilsCard("A Case of the Finest Champagne"); //Create the card and set the title
		curCard.setTypes(SpoilsTypes.Stowable, SpoilsTypes.Alcohol, SpoilsTypes.Equipment); //Set all types the card fulfils
		curCard.setCarryWeight(2); //Set how much the item weights
		curCard.setSellValue(6); //Set the value of the card
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Diplomacy, 3},
			{Skills.Medical, 1}
		});
		curCard.setPassiveGains(new Dictionary<Gains, int>{ //Set what passive gains the spoils card gives
			//No passives
		}); 
		curCard.setActiveGains( //Set the active abilities the card can do
			new Dictionary<Gains, int>{ //Set 1 of actives
				{Gains.Gain_Spoils_Cards, 2}}, //1.1
			new Dictionary<Gains, int>{ //Set 2 of actives
				{Gains.Gain_Action_Cards, 2}} //2.1
		);
		curCard.setWhenUsable( //Set when the actives are useable
			Times.After_Successful_Mission_Or_Encounter, //Set 1
			Times.After_Successful_Mission_Or_Encounter //Set 2
		);
		curCard.setNumberOfUses( //Set how many uses each active has
			Uses.Once, //Set 1
			Uses.Once //Set 2
		);
		curCard.setDiscard( //Set if the active use causes the card to be discarded
			true, //Set 1
			true //Set 2
		);
		curCard.setRestrictions(
			//No restrictions
		);
		spoilsCards.Add(curCard); //Add the card to the list of all cards


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
		curCard.setActiveGains(new Dictionary<Gains, int>{
			//No actives
		});
		curCard.setWhenUsable(
			//No actives
		);
		curCard.setNumberOfUses(
			//No actives
		);
		curCard.setDiscard(
			//No actives
		);
		curCard.setRestrictions(
			//No restrictions
		);
		spoilsCards.Add(curCard);


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
			{Gains.Prevent_Distruction, -1}, //int value of -1 means nothing in this case
			{Gains.Prevent_Theft, -1} //int value of -1 means nothing in this case
		});
		curCard.setActiveGains(new Dictionary<Gains, int>{
			{Gains.Pay_Salvage, 5}
		});
		curCard.setWhenUsable(
			Times.Immediately
		);
		curCard.setNumberOfUses(
			Uses.Once
		);
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(
			Restrictions.Equip_To_Vehicle
		);
		spoilsCards.Add(curCard);


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
		curCard.setActiveGains(new Dictionary<Gains, int>{
			//No actives
		});
		curCard.setWhenUsable(
			//No actives
		);
		curCard.setNumberOfUses(
			//No actives
		);
		curCard.setDiscard(
			//No actives
		);
		curCard.setRestrictions(
			Restrictions.Equip_To_Vehicle,
			Restrictions.Four_Wheels_Or_More
		);
		spoilsCards.Add(curCard);


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
			{Gains.Give_Opponent_This_Item, -1} //int -1 means nothing in this case
		});
		curCard.setWhenUsable(
			Times.Party_Target_Of_Theft
		);
		curCard.setNumberOfUses(
			Uses.Unlimited
		);
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(
			//No restrictions
		);
		spoilsCards.Add(curCard);


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
		curCard.setActiveGains(new Dictionary<Gains, int>{
			//No actives
		});
		curCard.setWhenUsable(
			//No actives
		);
		curCard.setNumberOfUses(
			//No actives
		);
		curCard.setDiscard(
			//No actives
		);
		curCard.setRestrictions(
			//No restrictions
		);
		spoilsCards.Add(curCard);


		curCard = new SpoilsCard("5.56mm Military Rifle");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Assault_Rifle);
		curCard.setCarryWeight(5);
		curCard.setSellValue(12);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 7}
		});
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			//No passives
		});
		curCard.setActiveGains(new Dictionary<Gains, int>{
			//No actives
		});
		curCard.setWhenUsable(
			//No actives
		);
		curCard.setNumberOfUses(
			//No actives
		);
		curCard.setDiscard(
			//No actives
		);
		curCard.setRestrictions(
			//No restrictions
		);
		spoilsCards.Add(curCard);


		curCard = new SpoilsCard("Silenced 9mm Submachine Gun");
		curCard.setTypes(SpoilsTypes.Ranged_Weapon, SpoilsTypes.Submachine_Gun);
		curCard.setCarryWeight(4);
		curCard.setSellValue(14);
		curCard.setBaseSkills(new Dictionary<Skills, int>{
			{Skills.Combat, 5}
		});
		curCard.setPassiveGains(new Dictionary<Gains, int>{
			{Gains.First_Strike, -1} //int -1 means nothing here
		});
		curCard.setActiveGains(new Dictionary<Gains, int>{
			//No actives
		});
		curCard.setWhenUsable(
			//No actives
		);
		curCard.setNumberOfUses(
			//No actives
		);
		curCard.setDiscard(
			//No actives
		);
		curCard.setRestrictions(
			//No restrictions
		);
		spoilsCards.Add(curCard);



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
		curCard.setActiveGains(new Dictionary<Gains, int>{
			//No actives
		});
		curCard.setWhenUsable(
			//No actives
		);
		curCard.setNumberOfUses(
			//No actives
		);
		curCard.setDiscard(
			//No actives
		);
		curCard.setRestrictions(
			Restrictions.Not_Used_With_Other_Armor,
			Restrictions.Not_Used_With_Other_Clothing
		);
		spoilsCards.Add(curCard);


		curCard = new SpoilsCard("Semi Truck");
		curCard.setTitleSubString("With Trailer");
		curCard.setTypes(SpoilsTypes.Vehicle, SpoilsTypes.Four_Wheeled);
		curCard.setCarryWeight(0);
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
			{Gains.Equip_Second_Vehicle_Face_Down, -1} //int -1 means nothing here
		});
		curCard.setWhenUsable(
			Times.Vehicle_Destroyed
		);
		curCard.setNumberOfUses(
			Uses.Once
		);
		curCard.setDiscard(
			true
		);
		curCard.setRestrictions(
			//No restrictions
		);
		spoilsCards.Add(curCard);


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
			{Gains.Draw_Spoils_Cards, 6, Gains.Keep_Spoils_Cards, 4, Gains.Swap_New_Characters_Freely, -1}
		});
		curCard.setWhenUsable(
			Times.Immediately
		);
		curCard.setNumberOfUses(
			Uses.Once
		);
		curCard.setDiscard(
			true
		);
		curCard.setRestrictions(
			//No restrictions
		);
		spoilsCards.Add(curCard);
	}
}
