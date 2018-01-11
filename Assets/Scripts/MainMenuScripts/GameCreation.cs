using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCreation : MonoBehaviour {

	public enum GameType {Null, NormalGame, SoloI, SoloII};
	public enum GameModifiers {Null, ProjectGodsHammer, Ronin, HarshReality, HarshRealityMod1, HarshRealityMod2, 
								Demo, DemoMod1, Timed, Expert, Short, Veteran};
	public enum SoloII {Null, SoloIIStandard, SoloIIModerate, SoloIIDifficult, SoloIIUltimate};

	public GameType gameMode;
	public ArrayList allModifiers;
	public bool wasRead = false;



	void Start() {
		allModifiers = new ArrayList();
	}

	void Awake(){
		if (!wasRead) {
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	public static string getGameTypeName(GameType gt) {
		switch (gt) {
		case GameType.NormalGame:
			return "Normal Game\n";
		case GameType.SoloI:
			return "Solo Variant I";
		case GameType.SoloII:
			return "Solo Variant II";
		default:
			return "NULL";
		}
	}

	public static string getSoloIITypeName(SoloII st) {
		switch (st) {
		case SoloII.SoloIIStandard:
			return "Standard--1 Enemy";
		case SoloII.SoloIIModerate:
			return "Moderate--2 Enemies";
		case SoloII.SoloIIDifficult:
			return "Difficult--3 Enemies";
		case SoloII.SoloIIUltimate:
			return "Ultimate--4 Enemies";
		default:
			return "NULL";
		}
	}

	public static string getRules(GameType gt){
		switch (gt) {
		case GameType.SoloI:
			return "This solo variation of the game works essentially the same as a normal multiplayer game, but every other faction is neutral. " +
				"The aim is to reach the victory condition in as few of turns as possible. " +
				"How quickly can you raise your faction to the top?";
		case GameType.SoloII:
			return "This solo variation of the game pits you against \"AI\" players that are dictated by a seperate town events chart." +
			"Do you have what it takes to survive against all odds?";
		default:
			return "ERROR";
		}
	}
}
