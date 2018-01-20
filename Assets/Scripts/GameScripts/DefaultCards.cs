using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCards : MonoBehaviour{

	public List<SpoilsCard> spoilsCards;

	void Awake(){
		//Initialize the lists for the cards
		spoilsCards = new List<SpoilsCard>();

		//Add the cards to the list
		/* SPOILS */
		SpoilsCard curCard;
		//Card 1
		curCard = new SpoilsCard("A Case of the Finest Champagne");
		curCard.setTypes(SpoilsTypes.Stowable, SpoilsTypes.Alcohol, SpoilsTypes.Equipment);
		curCard.setCarryWeight(2);
		curCard.setSellValue(6);
		curCard.setBaseSkills(new Dictionary<Skills, int>{{Skills.Diplomacy, 3}, {Skills.Medical, 1}});
		spoilsCards.Add(curCard);
	}
}
