using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perk {
	//A perk has times it can be used
	private List<Times> whenUsable;
	//A perk has a certain number of uses
	private List<Uses> uses;
	//A perk has gains given as a result of using it
	private Dictionary<Gains, int> staticGains; //Passive type gains that are always active
	private List<Dictionary<Gains, int>> conditionalGains; //List of different conditional ability choices the player has
	//A perk has a title
	private string perkTitle;
	//A perk has a text description
	private string perkDescription;


	//Constructor
	public Perk(string title){
		this.perkTitle = title;
	}

	//TODO times
	//TODO

	//TODO uses
	//TODO

	//TODO staticGains
	//TODO

	//TODO conditionalGains
	//TODO

	public void setPerkTitle(string title){
		this.perkTitle = title;
	}

	public string getPerkTitle(){
		return this.perkTitle;
	}

	public void setPerkDescription(string desc){
		this.perkDescription = desc;
	}

	public string getPerkDescription(){
		return this.perkDescription;
	}
}
