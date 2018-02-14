using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCreation : MonoBehaviour {

	public Factions.name faction;
	public GameInformation.GameModes mode;
	public List<GameInformation.GameModifier> modifiers;
	public bool wasRead = false;
	public GameInformation.SoloII soloIIDifficulty;


	void Start() {
		modifiers = new List<GameInformation.GameModifier>();
	}

	void Update(){
		if (!wasRead) {
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
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

	public static string getRules(GameInformation.GameModes gt){
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
