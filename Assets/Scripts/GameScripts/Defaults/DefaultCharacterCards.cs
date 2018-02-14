using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCharacterCards {

	private List<CharacterCard> characterCards;


	public DefaultCharacterCards(){
		//Initialize the lists for the cards
		characterCards = new List<CharacterCard>();

		//const int VALUE_NOT_NEEDED = -1;

		//Add the cards to the list
		CharacterCard curCard;
		//CharacterCard tempCard;

		Debug.Log("Instantiating character cards...");

		//TODO

		//placeholder. inserts a bunch of blanks DEBUG THINGY
		for(int i = 0; i < 80; i++) {
			curCard = new CharacterCard("test " + i.ToString());
			characterCards.Add(curCard);
		}
	}

	public List<CharacterCard> getCharacterCards(){
		return this.characterCards;
	}
}
