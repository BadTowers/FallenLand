using System.Collections.Generic;
using System;

namespace FallenLand
{
	public class PartyCard : NonencounterCard
	{
		private Dictionary<Skills, int> BaseSkills;
		private string TitleSubString;
		private string Quote;

		public PartyCard(string text) : base(text)
		{
			BaseSkills = new Dictionary<Skills, int>();
			foreach (Skills skill in Enum.GetValues(typeof(Skills)))
			{
				if (!BaseSkills.ContainsKey(skill))
				{
					BaseSkills.Add(skill, 0);
				}
			}
		}

		public void SetBaseSkills(Dictionary<Skills, int> skills)
		{
			if (skills != null)
			{
				BaseSkills = new Dictionary<Skills, int>();
				foreach (Skills curSkill in skills.Keys)
				{
					BaseSkills.Add(curSkill, skills[curSkill]);
				}

				//For each remaining skill that wasn't passed in, set it to 0
				foreach (Skills skill in Enum.GetValues(typeof(Skills)))
				{
					if (!BaseSkills.ContainsKey(skill))
					{
						BaseSkills.Add(skill, 0);
					}
				}
			}
		}

		public Dictionary<Skills, int> GetBaseSkills()
		{
			return BaseSkills;
		}

		public void SetTitleSubString(string titleSubString)
		{
			TitleSubString = titleSubString;
		}

		public string GetTitleSubString()
		{
			return TitleSubString;
		}

		public void SetQuote(string quote)
		{
			Quote = quote;
		}

		public string GetQuote()
		{
			return Quote;
		}
	}

}