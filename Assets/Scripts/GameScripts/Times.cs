using System.Collections;
using System.Collections.Generic;

public enum Times {

	//General
	Anytime,
	Immediately,
	Never,

	//Actions against player
	Party_Target_Of_Theft,

	//Characters
	After_Death,

	//Vehicle
	Vehicle_Destroyed,

	//Skill checks
	After_Combat_Skill_Check_Failure,
	After_Survival_Skill_Check_Failure,
	After_Diplomacy_Skill_Check_Failure,
	After_Mechanical_Skill_Check_Failure,
	After_Techinical_Skill_Check_Failure,
	After_Medical_Skill_Check_Failure,
	After_Any_Skill_Check_Failure,
	After_Combat_Skill_Critical_Failure,
	After_Survival_Skill_Critical_Failure,
	After_Diplomacy_Skill_Critical_Failure,
	After_Mechanical_Skill_Critical_Failure,
	After_Techinical_Skill_Critical_Failure,
	After_Medical_Skill_Critical_Failure,
	After_Any_Skill_Critical_Failure,

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
	Before_Effects_Phase,
	Before_Town_Business_Phase,
	Before_Deal_Subphase,
	Before_Resource_Production_Subphase,
	Before_Action_House_Subphase,
	Before_Town_Events_Chart_Subphase,
	Before_Financial_Period_Subphase,
	Before_Sell_Subphase,
	Before_Purchase_Subphase,
	Before_Hire_Subphase,
	Before_Party_Exploits_Phase,
	Before_NPCMs_Subphase,
	Before_Party_Exploits_Subphase,
	Before_End_Turn_Phase,
	After_Effects_Phase,
	After_Town_Business_Phase,
	After_Deal_Subphase,
	After_Resource_Production_Subphase,
	After_Action_House_Subphase,
	After_Town_Events_Chart_Subphase,
	After_Financial_Period_Subphase,
	After_Sell_Subphase,
	After_Purchase_Subphase,
	After_Hire_Subphase,
	After_Party_Exploits_Phase,
	After_NPCMs_Subphase,
	After_Party_Exploits_Subphase,
	After_End_Turn_Phase,

	//PvP
	During_PvP,
	After_PvP_Round,
	When_Opposing_Party_Grenades_Equipped,

	//Encounters/Missions
	After_Successful_Mission_Or_Encounter,
	After_Failed_Mission_Or_Encounter,
	After_Drawing_Ambush_Encounter,
	After_Drawing_Perishable_Encounter,

	//Locations
	Within_X_Hexes_Of_Enemy_Party,
	Within_X_Hexes_Of_Enemy_Town,

}
