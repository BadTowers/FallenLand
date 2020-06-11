using System.Collections.Generic;

namespace FallenLand
{
	public class Perk
	{
		private Dictionary<Gains, int> PassiveGains;
		private ConditionalGain ConditionalGain;
		private string PerkTitle;
		private string PerkDescription;
		private List<Dictionary<Gains, int>> D6Options;

		public Perk(string title)
		{
			PassiveGains = new Dictionary<Gains, int>();
			PerkTitle = title;
			D6Options = new List<Dictionary<Gains, int>>();
		}

		public void SetPassiveGains(Dictionary<Gains, int> passiveGains)
		{
			if (passiveGains != null)
			{
				PassiveGains = passiveGains;
			}
		}

		public Dictionary<Gains, int> GetPassiveGains()
		{
			return PassiveGains;
		}

		public void SetConditionalGain(ConditionalGain conditionalGain)
		{
			if (conditionalGain != null)
			{
				ConditionalGain = conditionalGain;
			}
		}

		public ConditionalGain GetConditionalGain()
		{
			return ConditionalGain;
		}

		public void SetPerkTitle(string title)
		{
			PerkTitle = title;
		}

		public string GetPerkTitle()
		{
			return PerkTitle;
		}

		public void SetPerkDescription(string description)
		{
			PerkDescription = description;
		}

		public string GetPerkDescription()
		{
			return PerkDescription;
		}

		public void AddD6Option(Dictionary<Gains, int> d6Option)
		{
			if (d6Option != null)
			{
				D6Options.Add(d6Option);
			}
		}

		public List<Dictionary<Gains, int>> GetD6Options()
		{
			return D6Options;
		}
	}
}
