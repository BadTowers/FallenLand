using System.Collections;
using System.Collections.Generic;

public enum Times {

	//General
	Anytime,
	Immediately,

	//Actions against player
	Party_Target_Of_Theft,

	//Skill checks
	After_Combat_Skill_Check_Failure,
	After_Survival_Skill_Check_Failure,
	After_Diplomacy_Skill_Check_Failure,
	After_Mechanical_Skill_Check_Failure,
	After_Techinical_Skill_Check_Failure,
	After_Medical_Skill_Check_Failure,

	//Phases
	During_Effects_Phase,
	During_Town_Business_Phase,
	During_Deal_Subphase,
	During_Resource_Production_Subphase,
	During_Action_House_Subphase,
	During_Town_Events_Chart_Subphase,
	During_Financial_Period_Subphase,
	During_Sell_Subphase,
	During_Purchase_Subphase,
	During_Hire_Subphase,
	During_Party_Exploits_Phase,
	During_NPCMs_Subphase,
	During_Party_Exploits_Subphase,
	During_End_Turn_Phase,

	//PvP
	During_PvP,
	After_PvP_Round,

	//Encounters/Missions
	After_Successful_Mission_Or_Encounter,
	After_Failed_Mission_Or_Encounter,
	After_Drawing_Ambush_Encounter,
	After_Drawing_Perishable_Encounter,

	//Locations
	Within_X_Hexes_Of_Enemy_Party,
	Within_X_Hexes_Of_Enemy_Town,

}
