using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour {

    //TODO rework this
    //Similar to Factions, create a GameMode class.
    //Add the attributes to it as needed

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

    //TODO this shouldn't be a static function. This should be tied to something in the game manager itself
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

    //TODO move this to the game manager
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

    public static string getGameModeName(GameInformation.GameModes gt) {
        switch (gt) {
            case GameInformation.GameModes.NormalGame:
                return "Normal Game\n";
            case GameInformation.GameModes.SoloI:
                return "Solo Variant I";
            case GameInformation.GameModes.SoloII:
                return "Solo Variant II";
            default:
                return "NULL";
        }
    }

    public static string getSoloIITypeName(GameInformation.SoloII st) {
        switch (st) {
            case GameInformation.SoloII.SoloIIStandard:
                return "Standard--1 Enemy";
            case GameInformation.SoloII.SoloIIModerate:
                return "Moderate--2 Enemies";
            case GameInformation.SoloII.SoloIIDifficult:
                return "Difficult--3 Enemies";
            case GameInformation.SoloII.SoloIIUltimate:
                return "Ultimate--4 Enemies";
            default:
                return "NULL";
        }
    }

    public static string getRules(GameInformation.GameModes gt) {
        switch (gt) {
            case GameInformation.GameModes.SoloI:
                return "This solo variation of the game works essentially the same as a normal multiplayer game, but every other faction is neutral. " +
                    "The aim is to reach the victory condition in as few of turns as possible. " +
                    "How quickly can you raise your faction to the top?";
            case GameInformation.GameModes.SoloII:
                return "This solo variation of the game pits you against \"AI\" players that are dictated by a seperate town events chart." +
                "Do you have what it takes to survive against all odds?";
            default:
                return "ERROR";
        }
    }

}
