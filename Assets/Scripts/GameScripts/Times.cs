
namespace FallenLand
{
	public enum Times
	{
		//General
		Anytime,
		Immediately,
		Never,
		Start_Of_Game,

		//Town
		Town_Target_Of_Action_Card_Or_World_Card,

		//Clothing
		Equipped_With_An_Axe,
		Equipped_With_Industrial_Chainsaw,
		Equipped_With_Rusty_Cleaver,

		//Actions against player
		Party_Target_Of_Theft,

		//Characters
		After_Death,

		//Party
		Any_Party_Member_Death,
		After_Each_Movement,

		//Opponents
		Opponent_Discarded_Book_Spoils,

		//Vehicle
		Vehicle_Destroyed,
		Has_No_Vehicle,

		//Cards
		Character_Card_Received_As_Reward,
		When_Drawn,
		After_Sell_Spoils_Card_From_Auction_House_To_Another_Player,
		Negative_Action_Card_Against_Player,
		After_Ally_Card_Is_Gained,

		//Specific card equipped
		Axe_Equipped,
		Compass_and_Maps_Equipped,
		Indestructible_Tennis_Racquet_Equipped,
		Rifle_Equipped,
		Shotgun_Equipped,
		Sledge_Hammer_Equipped,
		Sock_Monkey_Puppet_Equipped,

		//Skill checks
		After_Combat_Skill_Check_Failure,
		After_Survival_Skill_Check_Failure,
		After_Diplomacy_Skill_Check_Failure,
		After_Mechanical_Skill_Check_Failure,
		After_Technical_Skill_Check_Failure,
		After_Medical_Skill_Check_Failure,
		After_Any_Skill_Check_Failure,
		After_Combat_Skill_Critical_Failure,
		After_Survival_Skill_Critical_Failure,
		After_Diplomacy_Skill_Critical_Failure,
		After_Mechanical_Skill_Critical_Failure,
		After_Technical_Skill_Critical_Failure,
		After_Medical_Skill_Critical_Failure,
		After_Any_Skill_Critical_Failure,
		After_Combat_Skill_Check_Success,
		After_Survival_Skill_Check_Success,
		After_Diplomacy_Skill_Check_Success,
		After_Mechanical_Skill_Check_Success,
		After_Technical_Skill_Check_Success,
		After_Medical_Skill_Check_Success,
		After_Any_Skill_Check_Success,
		After_Any_Skill_Check_Fail_Encounter,
		After_Any_Skill_Check_Fail_Mission,
		During_Combat_Skill_Check,
		During_Survival_Skill_Check,
		During_Diplomacy_Skill_Check,
		During_Mechanical_Skill_Check,
		During_Technical_Skill_Check,
		During_Medical_Skill_Check,

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
		Before_PvP,
		During_PvP,
		After_PvP,
		After_PvP_Round,
		When_Opposing_Party_Grenades_Equipped,
		During_PVP_Flight,

		//Encounters/Missions
		During_Encounter_Mission_Or_PvP,
		During_Encounter_Or_PvP,
		During_Mission_Or_PvP,
		After_Successful_Mission_Or_Encounter,
		After_Failed_Mission_Or_Encounter,
		After_Drawing_Ambush_Encounter,
		After_Drawing_Perishable_Encounter,
		During_Mission,
		During_Encounter,
		During_Encounter_Or_Mission,
		During_Lock_Picking_Encounters,
		During_Perishable_Encounters,
		During_Ambush_Encounters,
		During_Gladiatorial_Events_Encounters,
		During_Rad_Zombie_Encounters,
		Before_Drawing_City_Rad_Encounter_Card,
		During_Combat_Encounter_Card,
		After_Combat_Encounter_Success,
		During_Melee_Weapons_Only,
		During_Encounter_Flight,
		During_Solo_Encounter,
		Vehicle_Combat_Or_Biker_Gang_Encounter_Drawn,
		During_Environmetal_Hazard_Encounter_Card,
		During_Mission_Card_Sigma_In_Title_Any_Player,


		//Locations
		Within_1_Hex_Of_Enemy_Party,
		Within_1_Hex_Of_Enemy_Town,
		In_Neutral_Starting_Town,
		Moving_Into_Plains_Hex,
		Moving_Into_Mountain_Hex,
		Movint_Into_CityRad_Hex,
		First_Move_Into_Plains_Hex,
		First_Move_Into_Mountain_Hex,
		First_Move_Into_CityRad_Hex,
		Return_To_Town_Location,
		Within_1_Hex_Of_The_War_Wagon,

		//Deeds
		During_Movement_Deed,
		During_Healing_Deed,
		During_Encounter_Deed,
		During_Mission_Deed,

		//Dice rolls
		Rolled_10_On_This_Characters_Skill_Check,

	}
}
