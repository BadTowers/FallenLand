using System.Collections.Generic;

namespace FallenLand
{
	public abstract class EncounterCard : Card
	{
		private int SalvageReward;
		private Dictionary<Skills, int> SkillChecksRequired;
		private Dictionary<Skills, bool> ArePartySkillChecks = new Dictionary<Skills, bool>();
		private string DescriptionText;
		private bool PsychCheckAfterEncounter;
		List<Reward> Rewards = new List<Reward>();
		List<Punishment> Punishments = new List<Punishment>();
		private string SuccessHeaderText;
		private string SuccessDescriptionText;
		//FailurePunishments. The punishment the player gets for failing the skill checks TODO
		private string FailureHeaderText;
		private string FailureDescriptionText;
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

		public void SetArePartySkillCheck(Dictionary<Skills, bool> arePartySkillChecks)
		{
			ArePartySkillChecks = arePartySkillChecks;
		}

		public Dictionary<Skills, bool> GetArePartySkillCheck()
		{
			return ArePartySkillChecks;
		}

		public void SetMakePsychCheckAfterEncounter(bool psychCheck)
		{
			PsychCheckAfterEncounter = psychCheck;
		}

		public bool GetMakePsychCheckAfterEncounter()
		{
			return PsychCheckAfterEncounter;
		}

		public void SetDescriptionText(string text)
		{
			DescriptionText = text;
		}

		public string GetDescriptionText()
		{
			return DescriptionText;
		}

		public void SetSuccessHeaderText(string successText)
		{
			SuccessHeaderText = successText;
		}

		public string GetSuccessHeaderText()
		{
			return SuccessHeaderText;
		}

		public void SetSuccessDescriptionText(string descriptionText)
		{
			SuccessDescriptionText = descriptionText;
		}

		public string GetSuccessDescriptionText()
		{
			return SuccessDescriptionText;
		}

		public void SetFailureHeaderText(string failureText)
		{
			FailureHeaderText = failureText;
		}

		public string GetFailureHeaderText()
		{
			return FailureHeaderText;
		}

		public void SetFailureDescriptionText(string descriptionText)
		{
			FailureDescriptionText = descriptionText;
		}

		public string GetFailureDescriptionText()
		{
			return FailureDescriptionText;
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

        public void AddReward(Reward reward)
        {
			Rewards.Add(reward);
		}

		public List<Reward> GetRewards()
		{
			return Rewards;
		}

		public void AddPunishment(Punishment punishment)
		{
			Punishments.Add(punishment);
		}

		public List<Punishment> GetPunishments()
		{
			return Punishments;
		}

		private void initText()
		{
			FailureHeaderText = "";
			SuccessHeaderText = "";
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
}
