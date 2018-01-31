using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCard : NonpartyCard {

	private int sellValue; //The value the card can be sold to the bank for
	//phase. This is the phase the card can be played in
	//Actions. The list of actions the card can do. Sometimes this is one thing. Sometimes this is a list of things and can pick one. TODO

	public ActionCard(string title) : base(title) {

	}

	public void setSellValue(int sv){
		this.sellValue = sv;
	}

	public int getSellValue() {
		return this.sellValue;
	}

}
