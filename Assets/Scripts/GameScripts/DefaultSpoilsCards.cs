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
			new Dictionary<Gains, int> //Set 1 of actives
			{Gains.Gain_Spoils_Cards, 2}, //1.1
			new Dictionary<Gains, int> //Set 2 of actives
			{Gains.Gain_Action_Cards, 2} //2.1
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
		curCard.setWhenUsable(new List<Times> {
			//No actives
		});
		curCard.setNumberOfUses(new List<Uses> {
			//No actives
		});
		curCard.setDiscard(
			//No actives
		);
		curCard.setRestrictions(
			//No restrictions
		);
		spoilsCards.Add(curCard);


		curCard = new SpoilsCard("Fernando the Chauffer");
		curCard.setTypes(SpoilsTypes.Ally);
		curCard.setCarryWeight();
		curCard.setSellValue();
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
		curCard.setWhenUsable(new List<Times> {
			{Times.Immediately}
		});
		curCard.setNumberOfUses(new List<Uses> {
			{Uses.Once}
		});
		curCard.setDiscard(
			false
		);
		curCard.setRestrictions(
			Restrictions.Equip_To_Vehicle
		);
		spoilsCards.Add(curCard);
	}
}
