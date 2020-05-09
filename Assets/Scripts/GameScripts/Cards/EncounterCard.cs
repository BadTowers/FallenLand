using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EncounterCard : Card
{

	private int SalvageReward;
	private Dictionary<Skills, int> SkillChecksRequired;
	//SuccessRewards. The reward the player gets for succeeding the skill checks TODO
	private string SuccessText;
	//FailurePunishments. The punishment the player gets for failing the skill checks TODO
	private string FailureText;
	//specificInstructions. Things that must be true or must be done to complete the card (move to nearest rad hex, don't complete if you don't have vehicle, etc) TODO
	//classifiation. Some cards are classified (vehicle combat, biker gang, sigma, etc. Can be none) TODO

	public EncounterCard(string title) : base(title)
	{
		initSkillChecks(null);
		initText();
	}

	public EncounterCard(string title, Dictionary<Skills, int> skillChecks) : base(title)
	{
		initSkillChecks(skillChecks);
		initText();
	}

	public EncounterCard(string title, int salvageReward) : base(title)
	{
		initSalvageReward(salvageReward);
		initSkillChecks(null);
		initText();
	}

	public EncounterCard(string title, int salvageReward, Dictionary<Skills, int> skillChecks) : base(title)
	{
		initSalvageReward(salvageReward);
		initSkillChecks(skillChecks);
		initText();
	}

	public void SetSkillChecks(Dictionary<Skills, int> skillChecks)
	{
		if (skillChecks != null)
		{
			SkillChecksRequired = skillChecks;
		}
	}

	public Dictionary<Skills, int> GetSkillChecks()
	{
		return SkillChecksRequired;
	}

	public void SetSuccessText(string successText)
	{
		SuccessText = successText;
	}

	public string GetSuccessText()
	{
		return SuccessText;
	}

	public void SetFailureText(string failureText)
	{
		FailureText = failureText;
	}

	public string GetFailureText()
	{
		return FailureText;
	}

	public void SetSalvageReward(int salvageReward)
	{
		if (salvageReward >= 0)
		{
			SalvageReward = salvageReward;
		}
	}

	public int GetSalvageReward()
	{
		return SalvageReward;
	}


	private void initText()
	{
		FailureText = "";
		SuccessText = "";
	}

	private void initSkillChecks(Dictionary<Skills, int> skillChecks)
	{
		if (skillChecks == null)
		{
			skillChecks = new Dictionary<Skills, int>();
		}
		SkillChecksRequired = skillChecks;
	}

	private void initSalvageReward(int salvageReward)
	{
		if (salvageReward >= 0)
		{
			SalvageReward = salvageReward;
		}
	}
}
