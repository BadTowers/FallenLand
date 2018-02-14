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
		ActionCard curCard;
		//SpoilsCard tempCard;

		Debug.Log("Instantiating action cards...");

		//TODO

		//placeholder. inserts a bunch of blanks DEBUG THINGY
		for(int i = 0; i < 80; i++) {
			curCard = new ActionCard("test " + i.ToString());
			actionCards.Add(curCard);
		}
	}

	public List<ActionCard> getActionCards(){
		return this.actionCards;
	}
}
