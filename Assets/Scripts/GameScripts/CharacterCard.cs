using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCard : PartyCard {

	private int hp; //The max hp the character has
	private int psychResistance; //The psych resistance the character has
	private int carryCapacity; //The carry capacity that a character has
	private string titleSubString; //The string that appears below names
	private string quote; //The quote that appears on the character card
	//link. This would map some spoils card to some bonuses. ex) any two wheeled vehicle -> +1 movement and +6 carrying capacity TODO
	//specialAbilities. What bonuses the character card gets. TDC cost 3 less. Auto pass certain encounters. etc TODO
}

