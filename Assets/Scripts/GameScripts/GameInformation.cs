using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour {

	public enum GameValues{
		Starting_Town_Health,
		Starting_Prestige,
		Starting_Salvage,
		Starting_Character_Cards,
		Starting_Action_Cards,
		Starting_Spoils_Cards,
		Win_Town_Health,
		Win_Prestige,
	}

	public enum WinConditions{
		Town_Health,
		Prestige,
	}

	public enum SoloII {
		Null, 
		SoloIIStandard, 
		SoloIIModerate, 
		SoloIIDifficult, 
		SoloIIUltimate,
	}

	public enum GameModifier {
		Null, 
		ProjectGodsHammer, 
		Ronin, 
		HarshReality, 
		HarshRealityMod1, 
		HarshRealityMod2, 
		Demo, 
		DemoMod1, 
		Timed, 
		Expert, 
		Short, 
		Veteran,
	}

	public enum GameModes{
		Null, 
		NormalGame, 
		SoloI, 
		SoloII
	}

	public static int getHumanPlayerCount(GameModes gm){
		switch(gm) {
		case GameModes.Null:
			return -1;
		case GameModes.NormalGame:
			return -1; //TODO fix this once it's actually implemented
		case GameModes.SoloI:
			return 1;
		case GameModes.SoloII:
			return 1;
		default:
			return -1;
		}
	}

	public static int getComputerPlayerCount(GameModes gm){
		switch(gm) {
		case GameModes.Null:
			return -1;
		case GameModes.NormalGame:
			return -1; //TODO fix this once it's actually implemented
		case GameModes.SoloI:
			return 0;
		case GameModes.SoloII:
			return 0;
		default:
			return -1;
		}
	}

}
