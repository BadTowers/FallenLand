using System.Collections;
using System.Collections.Generic;

public enum Gains {

	//General
	No_Effect,
	Cannot_Be_Stolen,
	Goes_To_Auction_House_Upon_Death,

	//Skill check successes
	Gain_Party_Combat_Skill_Check_Successes, //Adds successes to the total for party checks
	Gain_Party_Survival_Skill_Check_Successes,
	Gain_Party_Diplomacy_Skill_Check_Successes,
	Gain_Party_Mechanical_Skill_Check_Successes,
	Gain_Party_Technical_Skill_Check_Successes,
	Gain_Party_Medical_Skill_Check_Successes,
	Gain_Party_Failed_Skill_Check_Successes,
	Gain_Individual_Combat_Skill_Check_Successes, //Adds successes to the total for individual checks
	Gain_Individual_Survival_Skill_Check_Successes,
	Gain_Individual_Diplomacy_Skill_Check_Successes,
	Gain_Individual_Mechanical_Skill_Check_Successes,
	Gain_Individual_Technical_Skill_Check_Successes,
	Gain_Individual_Medical_Skill_Check_Successes,
	Gain_Individual_Failed_Skill_Check_Successes,
	Lose_Party_Combat_Skill_Check_Successes, //Removes successes from the total for party checks
	Lose_Party_Survival_Skill_Check_Successes,
	Lose_Party_Diplomacy_Skill_Check_Successes,
	Lose_Party_Mechanical_Skill_Check_Successes,
	Lose_Party_Technical_Skill_Check_Successes,
	Lose_Party_Medical_Skill_Check_Successes,
	Lose_Party_Failed_Skill_Check_Successes,
	Lose_Individual_Combat_Skill_Check_Successes, //Removes successes from the total for individual checks
	Lose_Individual_Survival_Skill_Check_Successes,
	Lose_Individual_Diplomacy_Skill_Check_Successes,
	Lose_Individual_Mechanical_Skill_Check_Successes,
	Lose_Individual_Technical_Skill_Check_Successes,
	Lose_Individual_Medical_Skill_Check_Successes,
	Lose_Individual_Failed_Skill_Check_Successes,
	Combat_Skill_Checks_Automatic_Pass, //Auto passes this particular skill check
	Survival_Skill_Checks_Automatic_Pass,
	Diplomacy_Skill_Checks_Automatic_Pass,
	Mechanical_Skill_Checks_Automatic_Pass,
	Technical_Skill_Checks_Automatic_Pass,
	Medical_Skill_Checks_Automatic_Pass,
	Failed_Skill_Checks_Automatic_Pass,
	Skill_Checks_Automatic_Pass,
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
	Gain_Town_Defense_Chips,
	Lose_Town_Defense_Chips,

	//Party
	Ignore_Radiation_Damage_From_Hexes,
	Ignore_Radiation_Damage,

	//Ally
	Prevent_Any_Character_Death, //In a dictionary, set the value as the HP they have after the prevention

	//Encounters/Missions
	Ignore_Ambush_Encounters,
	Ignore_Ambush_Missions,
	Ignore_Ambush_Encounters_And_Missions,
	Ignore_Perishable_Encounters,
	Ignore_Perishable_Missions,
	Ignore_Perishable_Encounters_And_Missions,
	Auto_Succeed_Ambush_Encounters,
	Auto_Succeed_Ambush_Missions,
	Auto_Succeed_Ambush_Encounters_And_Missions,
	Auto_Succeed_Sigma_Bunker_Encounters,
	Auto_Succeed_Sigma_Bunker_Missions,
	Auto_Succeed_Sigma_Bunker_Encounters_And_Missions,
	Auto_Succeed_Lock_Picking_Encounters,
	Auto_Succeed_Lock_Picking_Missions,
	Auto_Succeed_Lock_Picking_Encounters_And_Missions,
	Auto_Succeed_Perishable_Encounters,
	Auto_Succeed_Combat_Encounters,
	Ignore_Negatives_Of_Enoucnter_Failure,
	Ignore_Negatives_Of_Mission_Failure,
	Ignore_Negatives_Of_Encounter_Or_Mission_Failure,

	//Deeds
	Healing_Deed_Salvage_Coin_Cost,

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
	Select_Character_From_Opposing_Party,
	Discard_Selected_Opposing_Character_Equipment,
	Kill_Selected_Character_From_Opposing_Party,
	Steal_Spoils_From_Opposing_Party_Excluding_Vehicles,
	Steal_Spoils_From_Opposing_Town_Auction_House,
	Steal_D6_Salvage,
	Steal_D10_Salvage,

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
	Prevent_Destruction,
	Equip_Second_Vehicle_Face_Down,
	Equip_Second_Vehicle_Face_Up,
	Keep_Stowables,
	Keep_All_Stowables,
	Discard_Equipped_Vehicle,
	Lose_Stowables,
	Lose_All_Stowables,
	Ignore_All_Vehicle_Equipment_Movement_Penalties,
	Choose_Which_Vehicle_To_Discard,
	Stacks_With_Other_Vehicles,

	//Character
	Gain_Psych_Resistence,
	Lose_Psych_Resistence,
	Gain_Carry_Weight,
	Lose_Carry_Weight,
	Gain_Health,
	Lose_Health,
	Avoid_Death,
	Heal_D6_Damage_Physical, //Does not apply to all members
	Heal_D6_Damage_Infected,
	Heal_D6_Damage_Physical_Or_Infected,
	Heal_D10_Damage_Physical,
	Heal_D10_Damage_Infected,
	Heal_D10_Damage_Physical_Or_Infected,
	Remove_Party_All_Damage,
	Remove_Party_Physical_Damage, //Remove this number from all members
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

	//Cards general
	Gain_Spoils_Cards, //Added, no catches
	Gain_Action_Cards,
	Gain_Character_Cards,
	Lose_Spoils_Cards,
	Lose_Action_Cards,
	Lose_Character_Cards,
	Draw_Spoils_Cards, //Combined with keep. ex draw 4, keep 2
	Draw_Character_Cards,
	Draw_Encounter_Cards,
	Keep_Encounter_Cards,
	Keep_Spoils_Cards, //Combined with draw.
	Keep_Character_Cards,
	Swap_New_Characters_Freely,
	Take_Spoils_Cards_From_Top_Discard_Pile,
	Any_Spoils_Cards_From_Deck,
	Any_Spoils_Cards_From_Discard,
	Any_Spoils_Cards_From_Deck_Or_Discard,
	Any_Nonevent_Spoils_Cards_From_Deck,
	Any_Nonevent_Spoils_Cards_From_Discard,
	Any_Nonevent_Spoils_Cards_From_Deck_Or_Discard,
	Any_Vehicle_Spoils_Cards_From_Deck,
	Any_Vehicle_Spoils_Cards_From_Discard,
	Any_Vehicle_Spoils_Cards_From_Deck_Or_Discard,
	Place_Into_Town_Roster, //For characters
	Place_Into_Auction_House, //For spoils

	//Special
	Gain_Kurtis_Wyatt_Character_Card,

	//Hiring
	Pay_Salvage,

	//D6 rewards
	Roll_D6,

	//D10 rewards
	Roll_D10,

	//Dice modifiers
	Subtract_From_Roll,
	Add_To_Roll,

	//Town tech
	Upgrade_Town_Tech_T2,
	Steal_Opponent_Town_Tech,

	//NPCMs
	Remove_NPCM_Currently_In_Play,

	//Resources
	Gain_Resource_Location,
	Lose_Resource_Location,

	//Theft
	Take_Characters_From_Opponent_Town_Roster_Into_Players_TR,

	//Damage Types
	Radiation_Damage_Treated_As_Physical,
	Infected_Damage_Treated_As_Physical,

	//Cards specific
	Gain_Spoils_Card_Paramedic_Med_Kit,
	Gain_Spoils_Card_Compound_Hunting_Bow,
}
