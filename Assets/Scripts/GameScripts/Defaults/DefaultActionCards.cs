using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultActionCards {

	private List<ActionCard> actionCards;


	public DefaultActionCards(){
		//Initialize the lists for the cards
		actionCards = new List<ActionCard>();

		//const int VALUE_NOT_NEEDED = -1;

		//Add the cards to the list
		//SpoilsCard curCard;
		//SpoilsCard tempCard;

		Debug.Log("Instantiating action cards...");

		//TODO
	}

	public List<ActionCard> getActionCards(){
		return this.actionCards;
	}
}
