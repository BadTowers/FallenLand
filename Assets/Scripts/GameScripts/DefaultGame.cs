using System.Collections;
using System.Collections.Generic;

public static class DefaultGame {

	//The number of each thing a player starts with
	public static Dictionary<GameInformation.GameValues, int> defaultStartingNumbers = new Dictionary<GameInformation.GameValues, int>{
		{GameInformation.GameValues.Starting_Town_Health, 30},
		{GameInformation.GameValues.Starting_Prestige, 1},
		{GameInformation.GameValues.Starting_Salvage, 10},
		{GameInformation.GameValues.Starting_Action_Cards, 3},
		{GameInformation.GameValues.Starting_Character_Cards, 6},
		{GameInformation.GameValues.Starting_Spoils_Cards, 10}
	};
		
	public static Dictionary<GameInformation.GameValues, int> defaultWinNumbers = new Dictionary<GameInformation.GameValues, int> {
		{GameInformation.GameValues.Win_Prestige, 20},
		{GameInformation.GameValues.Win_Town_Health, 80}
	};

	//Win conditions are groups by ORs at the top level and ANDs at the bottom level
	//[ [1], [2, 3], [4] ] means that you can win by [1] OR [2 AND 3] OR [4]
	/*
	 * EXAMPLE: The below code says there are THREE possible win conditions.
	 * THE FIRST WIN CONDITION: You must have required prestige AND town health
	 * THE SECOND WIN CONDITION: You must have a certain amount of salvage (made up)
	 * THE THIRD WIN CONDITION: You must have a certain amount of spoils cards (Made up)
	 * NOTE:
	 * 	THE VALUES for the win conditions are specified in a dictionary in this class.
	 * public List<List<GameInformation.WinConditions>> winConditions = new List<List<GameInformation.WinConditions>>() {
		new List<GameInformation.WinConditions>()
		{
			GameInformation.WinConditions.Prestige,
			GameInformation.WinConditions.Town_Health;
		},
		new List<GameInformation.WinConditions>()
		{
			GameInformation.WinConditions.Salvage (made up)
		},
		new List<GameInformation.WinConditions>()
		{
			GameInformation.WinConditions.Spoils (made up)
		}
	};
	 * */
	public static List<List<GameInformation.WinConditions>> winConditions = new List<List<GameInformation.WinConditions>>() {
		new List<GameInformation.WinConditions>()
		{
			GameInformation.WinConditions.Prestige
		},
		new List<GameInformation.WinConditions>()
		{
			GameInformation.WinConditions.Town_Health
		}
	};
}
