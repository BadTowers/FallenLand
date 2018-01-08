using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownTechs {

	public enum name{
		ENERGY_PRODUCTION,
		GARRISON,
		LAW_AND_ORDER,
		LEARNING_CENTER,
		MACHINIST_SHOP,
		MARKETPLACE,
		MEDICAL_CENTER,
		COMMUNICATION_CENTER,
		WATER_AND_SUPPLIES,
		NULL
	}
	
	public static string getName(TownTechs.name tech)
	{
		switch (tech) {
		case name.ENERGY_PRODUCTION:
			return "Energy Production";
		case name.GARRISON:
			return "Garrison";
		case name.LAW_AND_ORDER:
			return "Law and Order";
		case name.LEARNING_CENTER:
			return "Learning Center";
		case name.MACHINIST_SHOP:
			return "Machinist Shop";
		case name.MARKETPLACE:
			return "Marketplace";
		case name.MEDICAL_CENTER:
			return "Medical Center";
		case name.COMMUNICATION_CENTER:
			return "Communication Center";
		case name.WATER_AND_SUPPLIES:
			return "Water and Supplies";
		case name.NULL:
			return "NULL";
		default:
			return "Error";
		}
	}

	public static TownTechs.name getFaction(int num){
		switch (num) {
		case 1:
			return name.ENERGY_PRODUCTION;
		case 2:
			return name.GARRISON;
		case 3:
			return name.LAW_AND_ORDER;
		case 4:
			return name.LEARNING_CENTER;
		case 5:
			return name.MACHINIST_SHOP;
		case 6:
			return name.MARKETPLACE;
		case 7:
			return name.MEDICAL_CENTER;
		case 8:
			return name.COMMUNICATION_CENTER;
		case 9:
			return name.WATER_AND_SUPPLIES;
		default:
			return name.NULL;
		}
	}
}
