using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCard : PartyCard {

	private int hp; //The max hp the character has
	private int psychResistance; //The psych resistance the character has
	private int carryCapacity; //The carry capacity that a character has
	//link. This would map some spoils card to some bonuses. ex) any two wheeled vehicle -> +1 movement and +6 carrying capacity TODO
	//specialAbilities. What bonuses the character card gets. TDC cost 3 less. Auto pass certain encounters. etc TODO

	public CharacterCard(string title) : base(title) {

	}

	public void setHP(int hp) {
		this.hp = hp;
	}

	public int getHP() {
		return this.hp;
	}

	public void setPsychResistance(int r) {
		this.psychResistance = r;
	}

	public int getPsychResistance() {
		return this.psychResistance;
	}

	public void setCarryCapacity(int c) {
		this.carryCapacity = c;
	}

	public int getCarryCapacity() {
		return this.carryCapacity;
	}
}

