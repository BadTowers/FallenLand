using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EncounterCard : Card {

	private int salvageReward; //Value you get from attempting the card
	private Dictionary<Skills, int> skillChecks; //Dictionary mapping skill checks required to how many successes are needed
	//SuccessRewards. The reward the player gets for succeeding the skill checks TODO
	private string successText; //The text assigned to the success portion of the card
	//FailurePunishments. The punishment the player gets for failing the skill checks TODO
	private string failureText; //The text assigned to the failure portion of the card
	//specificInstructions. Things that must be true or must be done to complete the card (move to nearest rad hex, don't complete if you don't have vehicle, etc) TODO
	//classifiation. Some cards are classified (vehicle combat, biker gang, sigma, etc. Can be none) TODO

	public EncounterCard(string title) : base(title){

	}

	public EncounterCard(string title, Dictionary<Skills, int> skillChecks) : base(title)
	{
		this.skillChecks = skillChecks;
	}

	public EncounterCard(string title, int salvageReward) : base(title){
		this.salvageReward = salvageReward;
	}

	public EncounterCard(string title, int salvageReward, Dictionary<Skills, int> skillChecks) : base(title){
		this.salvageReward = salvageReward;
		this.skillChecks = skillChecks;
	}

	public void setSkillChecks(Dictionary<Skills, int> skillChecks){
		this.skillChecks = skillChecks;
	}

	public Dictionary<Skills, int> getSkillChecks(){
		return this.skillChecks;
	}

	public void setSuccessText(string success){
		this.successText = success;
	}

	public string getSuccessText() {
		return this.successText;
	}

	public void setFailureText(string failure){
		this.failureText = failure;
	}

	public string getFailureText(){
		return this.failureText;
	}

	public void setSalvageReward(int sr) {
		this.salvageReward = sr;
	}

	public int getSalvageReward(){
		return this.salvageReward;
	}
}
