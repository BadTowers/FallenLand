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

}
