using System.Collections.Generic;

namespace FallenLand
{
	public class TownTech
	{
		private string TechName;
		private int PurchaseCost;
		private int UpgradeCost;
		private int Tier; //tier 1 or 2
		private int SellCost;
		private ConditionalGain ConditionalGains;
		private Dictionary<Gains, int> PassiveGains;
		private bool IsStartingTech;
		private int Id;

		public TownTech(string name)
		{
			TechName = name;
			PassiveGains = new Dictionary<Gains, int>();
		}

		public void SetTechName(string n)
		{
			TechName = n;
		}

		public string GetTechName()
		{
			return TechName;
		}

		public void SetPurchaseCost(int c)
		{
			PurchaseCost = c;
		}

		public int GetPurchaseCost()
		{
			return PurchaseCost;
		}

		public void SetUpgradeCost(int c)
		{
			UpgradeCost = c;
		}

		public int GetUpgradeCost()
		{
			return UpgradeCost;
		}

		public void SetTier(int t)
		{
			Tier = t;
		}

		public int GetTier()
		{
			return Tier;
		}

		public void SetSellCost(int s)
		{
			SellCost = s;
		}

		public int GetSellCost()
		{
			return SellCost;
		}

		public void SetConditionalGains(ConditionalGain condGains)
		{
			if (condGains != null)
			{
				ConditionalGains = condGains;
			}
		}

		public ConditionalGain GetConditionalGain()
		{
			return ConditionalGains;
		}

        public void AddPassiveGain(Gains gain, int amount)
        {
			PassiveGains.Add(gain, amount);

		}

		public Dictionary<Gains, int> GetPassiveGains()
		{
			return PassiveGains;

		}

		public void SetIsStartingTech(bool b)
		{
			IsStartingTech = b;
		}

		public bool GetIsStartingTech()
		{
			return IsStartingTech;
		}

		public void SetId(int id)
		{
			Id = id;
		}

		public int GetId()
		{
			return Id;
		}
	}
}
