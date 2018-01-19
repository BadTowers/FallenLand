using System.Collections;
using System.Collections.Generic;

public class DefaultGame {

	public Dictionary<GameInformation.GameValues, int> defaultValues = new Dictionary<GameInformation.GameValues, int>{
		{GameInformation.GameValues.Starting_Town_Health, 30},
		{GameInformation.GameValues.Starting_Prestige, 1},
		{GameInformation.GameValues.Starting_Salvage, 10},
		{GameInformation.GameValues.Win_Prestige, 20},
		{GameInformation.GameValues.Win_Town_Health, 80}
	};
}
