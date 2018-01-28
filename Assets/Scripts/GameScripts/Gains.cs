using System.Collections;
using System.Collections.Generic;

public enum Gains {

	//General
	No_Effect,
	Cannot_Be_Stolen,
	Goes_To_Auction_House_Upon_Death,

	//Location
	Within_1_Hex_Of_Opponent_Town,

	//Skill check successes
	Gain_Combat_Skill_Check_Successes, //Adds successes to the total
	Gain_Survival_Skill_Check_Successes,
	Gain_Diplomacy_Skill_Check_Successes,
	Gain_Mechanical_Skill_Check_Successes,
	Gain_Technical_Skill_Check_Successes,
	Gain_Medical_Skill_Check_Successes,
	Gain_Failed_Skill_Check_Successes,
	Lose_Combat_Skill_Check_Successes, //Removes successes from the total
	Lose_Survival_Skill_Check_Successes,
	Lose_Diplomacy_Skill_Check_Successes,
	Lose_Mechanical_Skill_Check_Successes,
	Losen_Technical_Skill_Check_Successes,
	Lose_Medical_Skill_Check_Successes,
	Lose_Failed_Skill_Check_Successes,
	Combat_Skill_Check_Automatic_Pass, //Auto passes this particular skill check
	Survival_Skill_Check_Automatic_Pass,
	Diplomacy_Skill_Check_Automatic_Pass,
	Mechanical_Skill_Check_Automatic_Pass,
	Technical_Skill_Check_Automatic_Pass,
	Medical_Skill_Check_Automatic_Pass,
	Failed_Skill_Check_Automatic_Pass,
	Reroll_Combat_Skill_Check, //Retry the whole skill check of this type (Reroll all dice)
	Reroll_Survival_Skill_Check,
	Reroll_Diplomacy_Skill_Check,
	Reroll_Mechanical_Skill_Check,
	Reroll_Technical_Skill_Check,
	Reroll_Medical_Skill_Check,
	Reroll_Any_Skill_Check,
	Reroll_Failed_Skill_Check,
	Reroll_Combat_Critical_Fail, //Reroll a critical failure roll
	Reroll_Survival_Critical_Fail,
	Reroll_Diplomacy_Critical_Fail,
	Reroll_Mechanical_Critical_Fail,
	Reroll_Techinical_Critical_Fail,
	Reroll_Medical_Critical_Fail,
	Reroll_Any_Critical_Fail,

	//Combat
	First_Strike,
	Gain_Armor,
	Lose_Armor,
	Gain_PVP_Combat_Successes,
	Lose_PVP_Combat_Successes,
	Destroy_Oppenent_Vehicle,

	//Faction stuff
	Gain_Salvage,
	Gain_Prestige,
	Gain_Town_Health,
	Lost_Salvage,
	Lose_Prestige,
	Lose_Town_Health,

	//Encounters
	Ignore_Ambush_Encounters_Missions,
	_Encounters_Missions,

	//Action cards
	Ignore_Break_Relic_Action_Cards,
	Ignore_Broken_Action_Cards,

	//Weapons
	Deals_Radiation_Damage,
	Deals_Infected_Damage,

	//Opponents
	Damage_Opponent_Party_Physical,
	Damage_Opponent_Party_Infected,
	Damage_Opponent_Party_Radiation,
	Damage_Opponent_Character_By_Crown_Physical,
	Damage_Opponent_Character_By_Crown_Infected,
	Damage_Opponent_Character_By_Crown_Radiation,
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
	Avoid_Death,
	Heal_D6_Damage_Physical,
	Heal_D6_Damage_Infected,
	Heal_D6_Damage_Physical_Or_Infected,
	Heal_D10_Damage_Physical,
	Heal_D10_Damage_Infected,
	Heal_D10_Damage_Physical_Or_Infected,
	Remove_Party_All_Damage,
	Remove_Party_Physical_Damage,
	Remove_Party_Infected_Damage,
	Remove_Party_Radiation_Damage,
	Remove_Party_Psych_Damage,
	Remove_Character_Damage,
	Remove_Character_Physical_Damage,
	Remove_Character_Infected_Damage,
	Remove_Character_Radiation_Damage,
	Remove_Character_Psych_Damage,
	Remove_Party_Physical_Damage_All,
	Remove_Party_Infected_Damage_All,
	Remove_Party_Radiation_Damage_All,
	Remove_Party_Psych_Damage_All,
	Remove_Character_Damage_All,
	Remove_Character_Physical_Damage_All,
	Remove_Character_Infected_Damage_All,
	Remove_Character_Radiation_Damage_All,
	Remove_Character_Psych_Damage_All,

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
	Take_Spoils_Card_From_Top_Discard_Pile,

	//Hiring
	Pay_Salvage,

	//D6 rewards
	Roll_D6,

	//D10 rewards
	Roll_D10,

	//Town tech
	Upgrade_Town_Tech_T2,
	Steal_Opponent_Town_Tech,

	//NPCMs
	Remove_NPCM_Currently_In_Play,

	//Resources
	Gain_Resource_Location,
	Lose_Resource_Location,

}
