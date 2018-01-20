using System.Collections;
using System.Collections.Generic;
using System;

public class PartyCard : NonencounterCard {
	
	private Dictionary<Skills, int> baseSkills; //The base numbers the party card has for each skill

	public PartyCard(string text) : base(text) {
		baseSkills = new Dictionary<Skills, int>();
	}

	public void setBaseSkills(Dictionary<Skills, int> skills){
		//For each skill passed in, add it and its value to the dictionary
		foreach(Skills curSkill in skills.Keys) {
			baseSkills.Add(curSkill, skills[curSkill]);
		}

		//For each remaining skill that wasn't passed in, set it to 0
		foreach(Skills skill in Enum.GetValues(typeof(Skills))) {
			if(!baseSkills.ContainsKey(skill)) {
				baseSkills.Add(skill, 0);
			}
		}
	}
}
