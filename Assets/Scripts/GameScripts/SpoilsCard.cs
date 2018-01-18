using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoilsCard : PartyCard {

	private List<SpoilsTypes> types; //The list of all spoils types the card qualifies as
	private int sellValue; //The value of the card when sold to the bank
	private int carryWeight; //The weight of the item
	//specialAbilities. Psych resistance etc TODO
	//uniqueAbilities. Once per game, do X Y Z. etc TODO

	public SpoilsCard(string title) : base(title) {

	}

	public SpoilsCard(string title, List<SpoilsTypes> types) : base(title) {
		this.types = types;
	}

	public void setTypes(List<SpoilsTypes> types) {
		this.types = types;
	}

	public List<SpoilsTypes> getTypes() {
		return this.types;
	}

	public void setSellValue(int value) {
		this.sellValue = value;
	}

	public int getSellValue() {
		return this.sellValue;
	}

	public void setCarryWeight(int weight){
		this.carryWeight = weight;
	}

	public int getCarryWeight() {
		return this.carryWeight;
	}
}
