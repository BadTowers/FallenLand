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

}
