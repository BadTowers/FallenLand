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

		curCard = new SpoilsCard("A Case of the Finest Champagne");
		curCard.setTypes(SpoilsTypes.Stowable, SpoilsTypes.Alcohol, SpoilsTypes.Equipment);
		curCard.setCarryWeight(2);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{{Skills.Diplomacy, 3}, {Skills.Medical, 1}});
		curCard.setPassiveGains(Gains.None);
		curCard.setActiveGains(
			new Dictionary<Gains, int> //Set 1 of actives
			{Gains.Gain_Spoils_Cards, 2}, //1.1
			new Dictionary<Gains, int> //Set 2 of actives
			{Gains.Gain_Action_Cards, 2} //2.1
		);
		curCard.setWhenUsable(
			Times.After_Successful_Mission_Or_Encounter, //Set 1
			Times.After_Successful_Mission_Or_Encounter //Set 2
		);
		curCard.setNumberOfUses(
			Uses.Once, //Set 1
			Uses.Once //Set 2
		);
		curCard.setDiscard(
			true, //Set 1
			true //Set 2
		);
		//Special. Discard after a successful Encounter or Mission card to draw 2 Spoils or 2 Action cards
		spoilsCards.Add(curCard);

		curCard = new SpoilsCard("6 Armored War Horses");
	}
}
