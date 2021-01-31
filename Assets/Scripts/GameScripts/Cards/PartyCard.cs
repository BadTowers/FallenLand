﻿using System.Collections.Generic;
using System;

namespace FallenLand
{
	public class PartyCard : NonencounterCard
	{
		private Dictionary<Skills, int> BaseSkills;
		private string TitleSubString;
		private string Quote;
		private List<ConditionalGain> ConditionalGains;
		private Dictionary<Gains, int> PassiveGains;

		public PartyCard(string text) : base(text)
		{
			BaseSkills = Constants.ALL_SKILLS_ZERO;
			ConditionalGains = new List<ConditionalGain>();
			PassiveGains = new Dictionary<Gains, int>();
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

		public void AddConditionalGain(ConditionalGain conditionalGain)
		{
			ConditionalGains.Add(conditionalGain);
		}

        public List<ConditionalGain> GetConditionalGains()
        {
			return ConditionalGains;
        }

		public void AddPassiveGain(Gains gain, int amountGained)
		{
			PassiveGains.Add(gain, amountGained);
		}

		public Dictionary<Gains, int> GetPassiveGains()
		{
			return PassiveGains;
		}

		public void AddSkillAmount(Skills skill, int amount)
		{
			if (amount > 0)
			{
				BaseSkills[skill] += amount;
			}
		}

		public void RemoveSkillAmount(Skills skill, int amount)
		{
			if (amount > 0)
			{
				BaseSkills[skill] -= amount;
				if (BaseSkills[skill] < 0)
				{
					BaseSkills[skill] = 0;
					UnityEngine.Debug.LogWarning("Tried to set skill below 0: " + skill.ToString());
				}
			}
        }
	}

}