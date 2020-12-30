using System.Collections.Generic;

namespace FallenLand
{
	public abstract class EncounterCard : Card
	{
		private int SalvageReward;
		private List<(Skills, int)> SkillChecksRequired = new List<(Skills, int)>();
		private string DescriptionText;
		private bool PsychCheckAfterEncounter;
		List<Reward> Rewards = new List<Reward>();
		List<Punishment> Punishments = new List<Punishment>();
		private string SuccessHeaderText;
		private string SuccessDescriptionText;
		private string FailureHeaderText;
		private string FailureDescriptionText;
		private List<Action> ActionsOnBegin = new List<Action>();
		private List<EncounterTypes> Classifications = new List<EncounterTypes>();
		private List<Precheck> PrechecksAfterDraw = new List<Precheck>();

		public EncounterCard(string title) : base(title)
		{
			initText();
		}

		public EncounterCard(string title, int salvageReward) : base(title)
		{
			initSalvageReward(salvageReward);
			initText();
		}

		public void SetSkillChecks(List<(Skills, int)> skillChecks)
		{
            if (skillChecks != null)
			{
				SkillChecksRequired = skillChecks;
			}
		}

		public List<(Skills, int)> GetSkillChecks()
		{
			return SkillChecksRequired;
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

		public void AddActionOnBegin(Action action)
		{
			ActionsOnBegin.Add(action);
		}

        public List<Action> GetActionsOnBegin()
        {
			return ActionsOnBegin;
        }

		public void AddClassification(EncounterTypes type)
		{
			Classifications.Add(type);
		}

		public List<EncounterTypes> GetClassifications()
		{
			return Classifications;
		}

		public void AddPrecheck(Precheck check)
		{
			PrechecksAfterDraw.Add(check);
		}

		public List<Precheck> GetPrechecks()
		{
			return PrechecksAfterDraw;
		}

		private void initText()
		{
			FailureHeaderText = "";
			SuccessHeaderText = "";
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
