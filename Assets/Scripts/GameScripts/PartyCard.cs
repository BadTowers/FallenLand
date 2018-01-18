using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyCard : NonencounterCard {
	
	private Dictionary<Skills, int> baseSkills; //The base numbers the party card has for each skill

	public PartyCard(string text) : base(text) {

	}
}
