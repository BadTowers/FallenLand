using System.Collections.Generic;

namespace FallenLand
{
	public class MissionCard : EncounterCard
	{

		private Dictionary<Skills, int> OptionalSkillChecks;
		private string OptionalSuccessText;
		//optionalSuccessRewards. The reward received for succeeding at the optional skill check
		private string OptionalFailureText;
		//optionalFailurePunishments. The punishment for failing at the optional skill check

		public MissionCard(string title) : base(title)
		{
			initOptionalSkillChecks(null);
			initText();
			SetSalvageReward(0);
		}

		public void SetOptionalSkillChecks(Dictionary<Skills, int> optionalSkillChecks)
		{
			if (optionalSkillChecks != null)
			{
				OptionalSkillChecks = optionalSkillChecks;
			}
			initText();
		}

		public Dictionary<Skills, int> GetOptionalSkillChecks()
		{
			return OptionalSkillChecks;
		}

		public void SetOptionalSuccessText(string text)
		{
			OptionalSuccessText = text;
		}

		public string GetOptionalSuccessText()
		{
			return OptionalSuccessText;
		}

		public void SetOptionalFailureText(string text)
		{
			OptionalFailureText = text;
		}

		public string GetOptionalFailureText()
		{
			return OptionalFailureText;
		}


		private void initText()
		{
			OptionalSuccessText = "";
			OptionalFailureText = "";
		}

		private void initOptionalSkillChecks(Dictionary<Skills, int> optionalSkillChecks)
		{
			if (optionalSkillChecks == null)
			{
				optionalSkillChecks = new Dictionary<Skills, int>();
			}
			OptionalSkillChecks = optionalSkillChecks;
		}
	}

}