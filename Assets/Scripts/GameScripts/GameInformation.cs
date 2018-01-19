using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour {

	public enum GameValues{
		Starting_Town_Health,
		Starting_Prestige,
		Starting_Salvage,
		Win_Town_Health,
		Win_Prestige,
	}

	public enum WinConditions{
		Town_Health,
		Prestige,
		Both,
	}

	public static int getStartingValue(GameValues stat){
		switch (stat) {
		case GameValues.Starting_Salvage:
			return 10;
		case GameValues.Starting_Prestige:
			return 1;
		case GameValues.Starting_Town_Health:
			return 30;
		case GameValues.Win_Prestige:
			return 20;
		case GameValues.Win_Town_Health:
			return 80;
		}
	}

}
