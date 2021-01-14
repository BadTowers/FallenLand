using System.Collections.Generic;

namespace FallenLand
{
	public abstract class EncounterCard : Card
	{
		private int SalvageReward;
		private List<(Skills, int)> SkillChecksRequired = new List<(Skills, int)>();
		private string DescriptionText;
		private bool PsychCheckAfterEncounter;
		List<Reward> RewardsOnSuccess = new List<Reward>();
		List<Punishment> PunishmentsOnSuccess = new List<Punishment>();
		List<Punishment> PunishmentsOnFail = new List<Punishment>();
		private string SuccessHeaderText;
		private string SuccessDescriptionText;
		private string FailureHeaderText;
		private string FailureDescriptionText;
		private List<Action> ActionsOnBegin = new List<Action>();
		private List<EncounterTypes> Classifications = new List<EncounterTypes>();
		private List<Precheck> PrechecksAfterDraw = new List<Precheck>();
		private bool FlightAllowed;
		private bool IsMeleeOnly;
		private bool IsIndividualCheck;
		private List<int> D6Rolls;
		private List<byte> IndividualPassFail;

		public EncounterCard(string title) : base(title)
		{
			initText();
			D6Rolls = new List<int>();
			IndividualPassFail = new List<byte>();
			for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
			{
				D6Rolls.Add(0);
				IndividualPassFail.Add(Constants.STATUS_BEGIN);
			}
		}

        public void ResetState()
        {
			for (int i = 0; i < Constants.NUM_PARTY_MEMBERS; i++)
			{
				D6Rolls[i] = 0;
				IndividualPassFail[i] = Constants.STATUS_BEGIN;
			}
		}


		public void SetIndividualPassFail(int characterIndex, byte status)
		{
			IndividualPassFail[characterIndex] = status;
		}

		public List<byte> GetIndividualPassFail()
		{
			return IndividualPassFail;
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

		public void SetIsIndividualCheck(bool isIndividual)
		{
			IsIndividualCheck = isIndividual;
		}

		public bool GetIsIndividualCheck()
		{
			return IsIndividualCheck;
		}

		public void SetD6RollForCharacter(int characterIndex, int roll)
		{
			D6Rolls[characterIndex] = roll;
		}

		public List<int> GetD6Rolls()
		{
			return D6Rolls;
		}

		public void SetMakePsychCheckAfterEncounter(bool psychCheck)
		{
			PsychCheckAfterEncounter = psychCheck;
		}

		public bool GetMakePsychCheckAfterEncounter()
		{
			return PsychCheckAfterEncounter;
		}

		public void SetFlightAllowed(bool isAllowed)
		{
			FlightAllowed = isAllowed;
		}

		public bool GetFlightAllowed()
		{
			return FlightAllowed;
		}

		public void SetIsMeleeOnly(bool meleeOnly)
		{
			IsMeleeOnly = meleeOnly;
		}

		public bool GetIsMeleeOnly()
		{
			return IsMeleeOnly;
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

        public void AddRewardOnSuccess(Reward reward)
        {
			RewardsOnSuccess.Add(reward);
		}

		public List<Reward> GetRewardsOnSuccess()
		{
			return RewardsOnSuccess;
		}

		public void AddPunishmentOnSuccess(Punishment punishment)
		{
			PunishmentsOnSuccess.Add(punishment);
		}

		public List<Punishment> GetPunishmentsOnSuccess()
		{
			return PunishmentsOnSuccess;
		}

		public void AddPunishmentOnFail(Punishment punishment)
		{
			PunishmentsOnFail.Add(punishment);
		}

		public List<Punishment> GetPunishmentsOnFail()
		{
			return PunishmentsOnFail;
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
