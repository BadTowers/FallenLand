using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCard : EncounterCard {

	private Dictionary<Skills, int> optionalSkillChecks; //Dictionary mapping optional skill checks to how many successes are needed
	private string optionalSuccessText; //The success text for the optional portion of the mission
	//optionalSuccessRewards. The reward received for succeeding at the optional skill check
	private string optionalFailureText; //The failure text for teh optional portion of the mission
	//optionalFailurePunishments. The punishment for failing at the optional skill check

	public MissionCard(string title) : base(title){

	}

	public MissionCard(string title, Dictionary<Skills, int> optionalSkillChecks) : base(title) {
		this.optionalSkillChecks = optionalSkillChecks;
	}
		
	public void setOptionalSuccessText(string text){
		this.optionalSuccessText = text;
	}

	public string getOptionalSuccessText() {
		return this.optionalSuccessText;
	}

	public void setOptionalFailureText(string text){
		this.optionalFailureText = text;
	}

	public string getOptionalFailureText(){
		return this.optionalFailureText;
	}
}
