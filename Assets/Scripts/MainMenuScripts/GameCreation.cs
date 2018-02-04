using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCreation : MonoBehaviour {

	public Factions.name faction;
	public GameMode mode;
	public ArrayList modifiers;
	public bool wasRead = false;
	public SoloII soloIIDifficulty;



	void Start() {
		modifiers = new ArrayList();
	}

	void Update(){
		if (!wasRead) {
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	public static string getGameModeName(GameMode gt) {
		switch (gt) {
		case GameMode.NormalGame:
			return "Normal Game\n";
		case GameMode.SoloI:
			return "Solo Variant I";
		case GameMode.SoloII:
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

	public static string getRules(GameMode gt){
		switch (gt) {
		case GameMode.SoloI:
			return "This solo variation of the game works essentially the same as a normal multiplayer game, but every other faction is neutral. " +
				"The aim is to reach the victory condition in as few of turns as possible. " +
				"How quickly can you raise your faction to the top?";
		case GameMode.SoloII:
			return "This solo variation of the game pits you against \"AI\" players that are dictated by a seperate town events chart." +
			"Do you have what it takes to survive against all odds?";
		default:
			return "ERROR";
		}
	}
}
