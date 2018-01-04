﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCreation : MonoBehaviour {

	public enum GameType {NormalGame, DemoGame, ExpertGame, ShortGame, TimedGame, VeteranGame, SoloI,
							SoloIIStandard, SoloIIModerate, SoloIIDifficult, SoloIIUltimate};
	public enum GameModifiers {ProjectGodsHammer, Ronin, HarshReality, TownTechUpgradesCountDouble, StartWithFewerCards, 
								DemoGamePurchase, DemoGameTradeBeforeGame};

	public GameType gameMode;
	public ArrayList allModifiers;

	void Start() {
		allModifiers = new ArrayList();
	}
}
