using System.Collections;
using System.Collections.Generic;

public static class DefaultGame {

	//The number of each thing a player starts with
	public static Dictionary<GameInformation.GameValues, int>startingNumbers = new Dictionary<GameInformation.GameValues, int>{
		{GameInformation.GameValues.Starting_Town_Health, 30},
		{GameInformation.GameValues.Starting_Prestige, 1},
		{GameInformation.GameValues.Starting_Salvage, 10},
		{GameInformation.GameValues.Starting_Action_Cards, 3},
		{GameInformation.GameValues.Starting_Character_Cards, 6},
		{GameInformation.GameValues.Starting_Spoils_Cards, 10}
	};

	//Win conditions are groups by ORs at the top level and ANDs at the bottom level
	//[ [1], [2, 3], [4] ] means that you can win by [1] OR [2 AND 3] OR [4]
	/*
	 * EXAMPLE: The below code says there are THREE possible win conditions.
	 * THE FIRST WIN CONDITION: You must have required prestige AND town health
	 * THE SECOND WIN CONDITION: You must have a certain amount of salvage (made up)
	 * THE THIRD WIN CONDITION: You must have a certain amount of spoils cards (Made up)
	 * public List<Dictionary<GameInformation.WinConditions, int>> winConditions = new List<Dictionary<GameInformation.WinConditions, int>>() {
		//Option 1: 20 prestige AND 100 Town Health
		new Dictionary<GameInformation.WinConditions, int>()
		{
			{GameInformation.WinConditions.Prestige, 20},
			{GameInformation.WinConditions.Town_Health, 100}
		},
		//Option 2: 80 Salvage
		new Dictionary<GameInformation.WinConditions, int>()
		{
			{GameInformation.WinConditions.Salvage, 80},
		},
		//Option 3: 15 spoils
		new Dictionary<GameInformation.WinConditions, int>()
		{
			{GameInformation.WinConditions.Spoils, 15},
		}
	};
	 * */
	public static List<Dictionary<GameInformation.WinConditions, int>> winConditions = new List<Dictionary<GameInformation.WinConditions, int>>() {
		//Option 1: 20 prestige
		new Dictionary<GameInformation.WinConditions, int>()
		{
			{GameInformation.WinConditions.Prestige, 20},
		},
		//option 2: 80 Town Health
		new Dictionary<GameInformation.WinConditions, int>()
		{
			{GameInformation.WinConditions.Town_Health, 80},
		}
	};
}
