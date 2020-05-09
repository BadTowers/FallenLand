using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultActionCards
{
	private List<ActionCard> ActionCards;

	public DefaultActionCards()
	{
		ActionCards = new List<ActionCard>();

		//Add the cards to the list
		ActionCard curCard;

		Debug.Log("Instantiating action cards...");

		//TODO

		//placeholder. inserts a bunch of blanks DEBUG THINGY
		for(int i = 0; i < 80; i++) {
			curCard = new ActionCard("test " + i.ToString());
			ActionCards.Add(curCard);
		}
	}

	public List<ActionCard> GetActionCards()
	{
		return ActionCards;
	}
}
