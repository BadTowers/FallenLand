using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class Perk
	{
		private List<Times> WhenUsable;
		private List<Uses> NumberOfUses;
		private Dictionary<Gains, int> StaticGains;
		private Dictionary<Gains, int> ConditionalGains;
		private string PerkTitle;
		private string PerkDescription;
		private List<Dictionary<Gains, int>> D6Options;


		public Perk(string title)
		{
			WhenUsable = new List<Times>();
			NumberOfUses = new List<Uses>();
			StaticGains = new Dictionary<Gains, int>();
			ConditionalGains = new Dictionary<Gains, int>();
			PerkTitle = title;
			D6Options = new List<Dictionary<Gains, int>>();
		}

		public void SetTimes(List<Times> whenUsable)
		{
			if (whenUsable != null)
			{
				WhenUsable = whenUsable;
			}
		}

		public List<Times> GetTimes()
		{
			return WhenUsable;
		}

		public void SetUses(List<Uses> numUses)
		{
			if (numUses != null)
			{
				NumberOfUses = numUses;
			}
		}

		public List<Uses> GetUses()
		{
			return NumberOfUses;
		}

		public void SetStaticGains(Dictionary<Gains, int> staticGains)
		{
			if (staticGains != null)
			{
				StaticGains = staticGains;
			}
		}

		public Dictionary<Gains, int> GetStaticGains()
		{
			return StaticGains;
		}

		public void SetConditionalGains(Dictionary<Gains, int> conditionalGains)
		{
			if (conditionalGains != null)
			{
				ConditionalGains = conditionalGains;
			}
		}

		public Dictionary<Gains, int> GetConditionalGains()
		{
			return ConditionalGains;
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
