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
		//SpoilsCard curCard;
		//SpoilsCard tempCard;

		Debug.Log("Instantiating character cards...");

		//TODO
	}

	public List<CharacterCard> getCharacterCards(){
		return this.characterCards;
	}
}
