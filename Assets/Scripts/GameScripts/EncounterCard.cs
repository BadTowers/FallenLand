using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterCard : Card {

	int salvageReward; //Value you get from attempting the card
	Dictionary<GameManager.SkillCheck, int> skillChecks; //Dictionary mapping skill checks required to how many successes are needed

}
