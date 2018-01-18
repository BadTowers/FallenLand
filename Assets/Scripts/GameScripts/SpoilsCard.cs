using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoilsCard : PartyCard {

	private List<SpoilsTypes> types; //The list of all spoils types the card qualifies as
	private int sellValue; //The value of the card when sold to the bank
	private int carryWeight; //The weight of the item
	//specialAbilities. Psych resistance etc TODO
	//uniqueAbilities. Once per game, do X Y Z. etc TODO
}
