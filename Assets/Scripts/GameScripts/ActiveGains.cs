using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActiveGains {

	//Skill check successes
	Combat_Skill_Check_Successes,
	Survival_Skill_Check_Successes,
	Diplomacy_Skill_Check_Successes,
	Mechanical_Skill_Check_Successes,
	Techinical_Skill_Check_Successes,
	Medical_Skill_Check_Successes,

	//Faction stuff
	Gain_Salvage,
	Gain_Prestige,
	Gain_Town_Health,

	//Encounters (TODO FINISH)
	Ignore_Ambush,
	Ignore_Perishable,

	//Opponents
	Damage_Opponent_Party,
	Damage_Opponent_Characters,
	Remove_Prestige,
	Remove_Town_Health,

	//Movement
	Ignore_Delays,
	Ignore_Action_Card_Movement,
}
