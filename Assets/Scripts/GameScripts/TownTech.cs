using System.Collections.Generic;

namespace FallenLand
{
	public class TownTech
	{
		private string TechName;
		private int PurchaseCost;
		private int UpgradeCost;
		private int Tier;
		private int SellCost;
		private ConditionalGain ConditionalGains;
		private bool IsStartingTech;
		private int Id;

		public TownTech(string name)
		{
			TechName = name;
			Tier = Constants.TIER_1;
		}

		public void SetTechName(string name)
		{
			TechName = name;
		}

		public string GetTechName()
		{
			return TechName;
		}

		public void SetPurchaseCost(int purchaseCost)
		{
			PurchaseCost = purchaseCost;
		}

		public int GetPurchaseCost()
		{
			return PurchaseCost;
		}

		public void SetUpgradeCost(int upgradeCost)
		{
			UpgradeCost = upgradeCost;
		}

		public int GetUpgradeCost()
		{
			return UpgradeCost;
		}

		public void SetTier(int tier)
		{
			Tier = tier;
		}

		public int GetTier()
		{
			return Tier;
		}

		public void SetSellCost(int sellCost)
		{
			SellCost = sellCost;
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

		public void SetIsStartingTech(bool isStartingTownTech)
		{
			IsStartingTech = isStartingTownTech;
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
