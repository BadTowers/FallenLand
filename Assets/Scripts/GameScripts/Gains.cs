using System.Collections;
using System.Collections.Generic;

public enum Gains {

	//Skill check successes
	Combat_Skill_Check_Successes,
	Survival_Skill_Check_Successes,
	Diplomacy_Skill_Check_Successes,
	Mechanical_Skill_Check_Successes,
	Techinical_Skill_Check_Successes,
	Medical_Skill_Check_Successes,

	//Combat
	First_Strike,
	Gain_Armor,
	Lose_Armor,

	//Faction stuff
	Gain_Salvage,
	Gain_Prestige,
	Gain_Town_Health,
	Lost_Salvage,
	Lose_Prestige,
	Lose_Town_Health,

	//Encounters (TODO FINISH)
	Ignore_Ambush,
	Ignore_Perishable,

	//Opponents
	Damage_Opponent_Party,
	Damage_Opponent_Characters,
	Remove_Prestige,
	Remove_Town_Health,
	Give_Opponent_This_Item,

	//Movement
	Ignore_Delays,
	Ignore_Action_Card_Movement,
	Gain_Movement,
	Lose_Movement,
	All_Hex_Movement_Cost,
	Mountain_Hexes_Cost,
	Plains_Hexes_Cost,
	CityRad_Hexes_Cost,

	//Clothing
	Can_Combine_With_Armor,

	//Vehicles
	Prevent_Theft,
	Prevent_Distruction,
	Equip_Second_Vehicle_Face_Down,
	Equip_Second_Vehicle_Face_Up,

	//Character
	Gain_Psych_Resistence,
	Lose_Psych_Resistence,
	Gain_Carry_Weight,
	Lose_Carry_Weight,

	//Cards
	Gain_Spoils_Cards,
	Gain_Action_Cards,
	Gain_Character_Cards,
	Lose_Spoils_Cards,
	Lose_Action_Cards,
	Lose_Character_Cards,
	Draw_Spoils_Cards,
	Draw_Character_Cards,
	Keep_Spoils_Cards,
	Keep_Character_Cards,
	Swap_New_Characters_Freely,

	//Hiring
	Pay_Salvage,

}
