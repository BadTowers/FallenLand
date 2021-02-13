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
		private readonly List<Reward> OnPurchaseRewards = new List<Reward>();
		private readonly List<Punishment> OnSellPunishments = new List<Punishment>();
		private readonly List<Reward> OnUpgradeRewards = new List<Reward>();
		private readonly List<Punishment> OnDowngradePunishments = new List<Punishment>();

		public TownTech(string name)
		{
			TechName = name;
			Tier = Constants.TIER_1;
		}

		public void SetTechName(string techName)
		{
			TechName = techName;
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

		public void SetIsStartingTech(bool isStartingTech)
		{
			IsStartingTech = isStartingTech;
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

		public void AddOnPurchaseReward(Reward reward)
		{
			OnPurchaseRewards.Add(reward);
		}

		public List<Reward> GetOnPurchaseRewards()
		{
			return OnPurchaseRewards;
		}

		public void AddOnSellPunishment(Punishment punishment)
		{
			OnSellPunishments.Add(punishment);
		}

		public List<Punishment> GetOnSellPunishments()
		{
			return OnSellPunishments;
		}

		public void AddOnUpgradeReward(Reward reward)
		{
			OnUpgradeRewards.Add(reward);
		}

		public List<Reward> GetOnUpgradeRewards()
		{
			return OnUpgradeRewards;
		}

		public void AddOnDowngradePunishment(Punishment punishment)
		{
			OnDowngradePunishments.Add(punishment);
		}

		public List<Punishment> GetOnDowngradePunishments()
		{
			return OnDowngradePunishments;
		}
	}
}
