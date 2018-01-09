using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCreation : MonoBehaviour {

	public enum GameType {NormalGame, SoloI, SoloII};
	public enum GameModifiers {ProjectGodsHammer, Ronin, HarshReality, TownTechUpgradesCountDouble, StartWithFewerCards, 
								DemoGamePurchase, DemoGameTradeBeforeGame, Timed, Expert, Short, Veteran, Demo};
	public enum SoloII {SoloIIStandard, SoloIIModerate, SoloIIDifficult, SoloIIUltimate};

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
}
