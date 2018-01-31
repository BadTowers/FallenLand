using System.Collections;
using System.Collections.Generic;

public enum Restrictions  {

	//General
	Equip_To_All_Party_Members_Or_None,
	Cannot_Be_Sold,

	//Cards
	Cant_Be_Drawn_During_Setup,
	Excludes_World_Cards,

	//Vehicle
	Four_Wheels_Or_More,
	Not_Bicycles,
	Not_Horses,

	//Allies
	Equip_To_Vehicle,
	Discard_If_Not_Purchased,

	//Clothing
	Not_Used_With_Other_Clothing,
	Not_Used_With_Other_Armor,
	Not_Used_With_Backback,

	//Weapon Mods
	Equip_To_Assault_Rifle,
	Equip_To_Rifle,

	//Healing
	Excludes_Healing_Deed,
}
