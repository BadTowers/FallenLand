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
		curCard.setBaseSkills(new Dictionary<Skills, int>{{Skills.Diplomacy, 3}, {Skills.Medical, 1}}); //Set what skills the card adds to
		curCard.setPassiveGains(Gains.None); //Set what passive gains the spoils card gives
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
		spoilsCards.Add(curCard); //Add the card to the list of all cards


		curCard = new SpoilsCard("6 Armored War Horses");
	}
}
